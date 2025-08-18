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
using BarcodeVerificationSystem.Services;
using BarcodeVerificationSystem.Utils;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class PrintingSenderService : ISenderService<PrintingDataEntry>
    {
        private readonly BlockingCollection<PrintingDataEntry> _queue;
        private readonly IStorageService<PrintingDataEntry> _storageService;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ApiService apiService = new ApiService();
        private readonly string _endpoint;

        public PrintingSenderService(BlockingCollection<PrintingDataEntry> queue, IStorageService<PrintingDataEntry> storageService, string endpoint)
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
                        index_qr_code = entry.Id,
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
                    //var jsonContent = JsonConvert.SerializeObject(printedContent, new JsonSerializerSettings
                    //{
                    //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                    //});
                    //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    //var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);
                    //var responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Raw API Response:");
                    //Console.WriteLine(responseBody);
                    //response.EnsureSuccessStatusCode();
                    //var ResponsePrinted = JsonConvert.DeserializeObject<ResponsePrinted>(await response.Content.ReadAsStringAsync());

                    var ResponsePrinted = await apiService.PostApiDataAsync<ResponsePrinted>(_endpoint, printedContent);

                    entry.SaasStatus = ResponsePrinted.is_success ? "success" : "failed";
                    entry.SAPStatus = ResponsePrinted.is_success_sap ? "success" : "failed";
                    entry.SaasError = ResponsePrinted.message ?? string.Empty;
                    entry.SAPError = ResponsePrinted.message_sap ?? string.Empty;

                    var syncDataModel = new SyncDataParams(SyncDataParams.SyncDataType.SentData, entry.Id){};

                    Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);

                    if (ResponsePrinted.is_success)
                    {
                        Shared.CurrentJob.NumberOfSaaSSentCodes++;
                        Shared.CurrentJob.SaveFile(filePath); // Có thể không save ở đây nhưng khi đọc job phải đọc file lên và đếm lại.
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SaaSSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }
                    if (ResponsePrinted.is_success_sap)
                    {
                        Shared.CurrentJob.NumberOfSAPSentCodes++;
                        Shared.CurrentJob.SaveFile(filePath);
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SAPSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }

                    if (ResponsePrinted.is_success && ResponsePrinted.is_success_sap) // nho chinh khuc nay
                    {
                        _storageService.MarkAsSent(entry.Id, entry.PrintedDate,  entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                    }
                    else
                    {
                        _storageService.MarkAsFailed(entry.Id, entry.PrintedDate, entry.SaasStatus, entry.SAPStatus, entry.SaasError, entry.SAPError);
                        _queue.Add(entry);
                        ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.PrintedDate + entry.SaasStatus + entry.SAPStatus + entry.SaasError + entry.SAPError);
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
                ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.PrintedDate + entry.SaasStatus + entry.SAPStatus + entry.SaasError + entry.SAPError + ex.Message);
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
