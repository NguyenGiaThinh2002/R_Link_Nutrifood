using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using BarcodeVerificationSystem.Controller;
using Newtonsoft.Json.Linq;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.Services;
using CommonVariable;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Request;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Response;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class VerificationSenderService : ISenderService<VerificationDataEntry>
    {
        private readonly BlockingCollection<VerificationDataEntry> _queue;
        private readonly IStorageService<VerificationDataEntry> _storageService;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly ApiService apiService = new ApiService();
        private readonly string _endpoint;
        private readonly string _databasePath;

        public VerificationSenderService(BlockingCollection<VerificationDataEntry> queue, IStorageService<VerificationDataEntry> storageService, string endpoint)
        {
            _queue = queue;
            _storageService = storageService;
            _endpoint = endpoint;
        }

        public void Start()
        {
            try
            {
                Task.Run(async () =>
                {
                    foreach (var entry in _queue.GetConsumingEnumerable(_cts.Token))
                    {
                        _ = ProcessEntryAsync(entry); // fire-and-forget task
                        await Task.Delay(100); // optional small delay to avoid CPU spike
                    }
                }, _cts.Token);
            }
            catch (Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in Start PrintingSenderService: " + ex.Message);
            }

        }

        private async Task ProcessEntryAsync(VerificationDataEntry entry)
        {
            try
            {
                string filePath = CommVariables.PathJobsApp + Shared.CurrentJob.FileName + Shared.Settings.JobFileExtension;
                var payload = Shared.CurrentJob.ManufacturingOrderPayload;

                //var printedContent = new object();

                //if (Shared.PrintMode.IsPrintingMode || Shared.PrintMode.IsPrintingModeOffline)
                //{
                  
                //}
                RequestChecked request = new RequestChecked
                {
                    index_qr_code = entry.Id,
                    qr_code = entry.Code,
                    unique_code = entry.UniqueCode,
                    process_order = payload.process_order,
                    material_number = payload.material_number,
                    check_date = entry.VerifiedDate,
                    status = entry.Status,
                    print_type = "process_order",
                    batch = payload.batch_info[0].batch,
                    mauf_date = payload.batch_info[0].mauf_date,
                    expired_date = payload.batch_info[0].expired_date,
                };

                if (Shared.UserPermission.isOnline)
                {
                    var ResponsePrinted = await apiService.PostApiDataAsync<ResponseChecked>(_endpoint, request);

                    entry.SaasStatus = ResponsePrinted.is_success ? "success" : "failed";
                    entry.SAPStatus = ResponsePrinted.is_success_sap ? "success" : "failed";
                    entry.SaasError = ResponsePrinted.message ?? string.Empty;
                    entry.SAPError = ResponsePrinted.message_sap ?? string.Empty;

                    var syncDataModel = new SyncDataParams(SyncDataParams.SyncDataType.SentData, entry.Id) { };

                    //if (ResponsePrinted.is_success)
                    //{
                    //    Shared.CurrentJob.NumberOfSaaSSentCodes++;
                    //    Shared.CurrentJob.SaveFile(filePath); // Có thể không save ở đây nhưng khi đọc job phải đọc file lên và đếm lại.

                    //    syncDataModel.DataType = SyncDataParams.SyncDataType.SaaSSuccess;
                    //    Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    //}
                    //if (ResponsePrinted.is_success_sap)
                    //{
                    //    Shared.CurrentJob.NumberOfSAPSentCodes++;
                    //    Shared.CurrentJob.SaveFile(filePath);
                    //    syncDataModel.DataType = SyncDataParams.SyncDataType.SAPSuccess;
                    //    Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    //}

                    if (ResponsePrinted.is_success && ResponsePrinted.is_success_sap) // nho chinh khuc nay
                    {
                        _storageService.MarkAsSent(entry.Id, entry.VerifiedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                    }
                    else
                    {
                        _storageService.MarkAsFailed(entry.Id, entry.VerifiedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                        _queue.Add(entry);
                    }

                    if (!ResponsePrinted.is_success_sap)
                    {
                        ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.VerifiedDate + entry.SaasStatus + entry.SAPStatus + entry.SaasError + entry.SAPError);
                    }
                }
                else
                {
                    _storageService.MarkAsFailed(entry.Id, entry.VerifiedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                }

            }
            catch (Exception ex)
            {
                entry.SaasStatus = "failed";
                entry.SaasError = ex.Message;
                ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.VerifiedDate + entry.SaasStatus + entry.SAPStatus + entry.SaasError + entry.SAPError + ex.Message);
                //_storageService.AppendEntry(entry);
                _storageService.MarkAsFailed(entry.Id, entry.VerifiedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                _queue.Add(entry);
            }
        }

        public void Stop()
        {
            _cts.Cancel();
            _queue.CompleteAdding();
        }
    }
}
