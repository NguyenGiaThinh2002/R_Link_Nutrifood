using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                //var content = new StringContent($"{{\"qr_code\":\"{entry.Code}\"}}", Encoding.UTF8, "application/json");
                var content = new StringContent($@"
                {{
                    ""id"": {entry.Id},
                    ""qr_code"": ""{entry.Code}"",
                    ""plant"": ""{Shared.Settings.FactoryCode}"",
                    ""wms_number"": ""{Shared.Settings.WmsNumber}"",
                    ""resource_code"": ""{Shared.Settings.RLinkId}"",
                    ""resource_name"": ""{Shared.Settings.LineName}"",
                    ""printed_date"": ""{entry.PrintedDate}"",
                    ""status"": ""{entry.PrintedStatus}""
                }}", Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);
                string responseContent = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseContent);
                entry.SaasStatus = json.Value<string>("status");
                entry.ServerStatus = json.Value<string>("serverStatus");
                entry.SaasError = "";
                entry.ServerError = json.Value<string>("serverError");

                if (response.IsSuccessStatusCode)
                {
                    _storageService.MarkAsSent(entry.Id, entry.SaasStatus, entry.ServerStatus, entry.SaasError, entry.ServerError);
                }
                else
                {
                    //_storageService.AppendEntry(entry); // Re-append entry for retry
                    entry.SaasStatus = "failed";
                    entry.SaasError = "Response Status is " + response.StatusCode;
                    _storageService.MarkAsFailed(entry.Id, entry.SaasStatus, entry.ServerStatus, entry.SaasError, entry.ServerError);
                    _queue.Add(entry);
                }
            }
            catch (Exception ex)
            {
                entry.SaasStatus = "failed";
                entry.SaasError = ex.Message;
                //_storageService.AppendEntry(entry);
                _storageService.MarkAsFailed(entry.Id, entry.SaasStatus, entry.ServerStatus, entry.SaasError, entry.ServerError);
                _queue.Add(entry);
                // Do nothing if it fails
            }
        }

        public void Stop()
        {
            _cts.Cancel();
            _queue.CompleteAdding();
        }

        //public void Start()
        //{
        //    Task.Run(async() =>
        //    {
        //        foreach (var entry in _queue.GetConsumingEnumerable(_cts.Token))
        //        {
        //            //while (!_cts.Token.IsCancellationRequested)
        //            //{
        //            //    try
        //            //    {
        //            //        var content = new StringContent($"{{\"code\":\"{entry.Code}\"}}", Encoding.UTF8, "application/json");
        //            //        var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);

        //            //        if (response.IsSuccessStatusCode)
        //            //        {
        //            //            _storageService.MarkAsSent(entry.Id);
        //            //            break; // ✅ Success, exit retry loop and go to next entry
        //            //        }
        //            //        else
        //            //        {
        //            //            await Task.Delay(1000, _cts.Token); // 🚧 Retry after 1 second
        //            //        }
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        // This covers network issues, server disconnect, etc.
        //            //        await Task.Delay(1000, _cts.Token); // ⏳ Wait and retry
        //            //    }
        //            //    await Task.Delay(100); // Optional throttle
        //            //}


        //            try
        //            {
        //                var content = new StringContent($"{{\"code\":\"{entry.Code}\"}}", Encoding.UTF8, "application/json");
        //                var response = await _httpClient.PostAsync(_endpoint, content);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    _storageService.MarkAsSent(entry.Id);
        //                }
        //                else
        //                {
        //                    await Task.Delay(1000); // wait before retry
        //                }
        //            }
        //            catch
        //            {
        //                // server might be down, wait and retry
        //                await Task.Delay(1000);
        //                // retry or ignore
        //            }
        //            await Task.Delay(100); // Throttle to avoid overwhelming the endpoint
        //        }
        //    }, _cts.Token);
        //}


    }

}
