using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using BarcodeVerificationSystem.View;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using BarcodeVerificationSystem.Model.Payload;
using System.Windows;
using BarcodeVerificationSystem.Model;
using CommonVariable;
using BarcodeVerificationSystem.Controller.NutrifoodController.DispatchingController;
using BarcodeVerificationSystem.Model.Apis.Dispatching;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class PrintingSenderService : ISenderService<PrintingDataEntry>
    {
        private readonly BlockingCollection<PrintingDataEntry> _queue;
        private readonly IStorageService<PrintingDataEntry> _storageService;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _endpoint;

        public PrintingSenderService(BlockingCollection<PrintingDataEntry> queue, IStorageService<PrintingDataEntry> storageService, string endpoint)
        {
            _queue = queue;
            _storageService = storageService;
            _endpoint = endpoint;
        }

        public void Start()
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

        private async Task ProcessEntryAsync(PrintingDataEntry entry)
        {
            try
            {
                string filePath = CommVariables.PathJobsApp + Shared.CurrentJob.FileName + Shared.Settings.JobFileExtension;

                var printedContent = new object();

                if (Shared.PrintMode.IsPrintingMode || Shared.PrintMode.IsPrintingModeOffline)
                {
                    printedContent = new RequestPrinted
                    {
                        id = entry.Id,
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        printed_date = DateTime.Parse(entry.PrintedDate),
                        shipto_name = Shared.CurrentJob.DispatchingOrderPayload.payload.shipto_name,  // 
                        shipto_code = Shared.CurrentJob.DispatchingOrderPayload.payload.shipto_code, // 
                        resource_code = Shared.Settings.LineId,
                        resource_name = Shared.Settings.LineName,
                    };
                }
               
                if(Shared.PrintMode.IsReprintMode)
                {
                    printedContent = new RequestRePrint
                    {
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        scan_date = DateTime.Parse(entry.PrintedDate),

                    };
                }

                if (Shared.UserPermission.isOnline)
                {
                    var jsonContent = JsonConvert.SerializeObject(printedContent, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);
                    response.EnsureSuccessStatusCode();
                    var ResponsePrinted = JsonConvert.DeserializeObject<ResponsePrinted>(await response.Content.ReadAsStringAsync());

                    entry.SaasStatus = ResponsePrinted.is_success ? "success" : "failed";
                    entry.SAPStatus = ResponsePrinted.is_sucess_sap ? "success" : "failed";
                    entry.SaasError = ResponsePrinted.message;
                    entry.SAPError = ResponsePrinted.sap_message;

                    var syncDataModel = new SyncDataParams(SyncDataParams.SyncDataType.SentData, entry.Id){};

                    Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);

                    if (ResponsePrinted.is_success)
                    {
                        Shared.CurrentJob.NumberOfSaaSSentCodes++;
                        Shared.CurrentJob.SaveFile(filePath); // Có thể không save ở đây nhưng khi đọc job phải đọc file lên và đếm lại.
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SaaSSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }
                    if (ResponsePrinted.is_sucess_sap)
                    {
                        Shared.CurrentJob.NumberOfSAPSentCodes++;
                        Shared.CurrentJob.SaveFile(filePath);
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SAPSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        _storageService.MarkAsSent(entry.Id, entry.PrintedDate,  entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                    }
                    else
                    {
                        //_storageService.AppendEntry(entry); // Re-append entry for retry
                        entry.SaasStatus = "failed";
                        entry.SaasError = "Response Status is " + response.StatusCode;
                        _storageService.MarkAsFailed(entry.Id, entry.PrintedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                        _queue.Add(entry);
                    }
                }
                else
                {
                    _storageService.MarkAsFailed(entry.Id, entry.PrintedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                }

            }
            catch (Exception ex)
            {
                entry.SaasStatus = "failed";
                entry.SaasError = ex.Message;
                //_storageService.AppendEntry(entry);
                _storageService.MarkAsFailed(entry.Id, entry.PrintedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                _queue.Add(entry);
                // Do nothing if it fails
            }
        }

        public void Stop()
        {
            //_httpClient.Dispose();
            _cts.Cancel();
            _queue.CompleteAdding();
        }


    }

}
