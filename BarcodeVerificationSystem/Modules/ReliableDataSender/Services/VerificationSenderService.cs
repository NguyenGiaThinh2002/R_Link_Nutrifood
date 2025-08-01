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

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class VerificationSenderService : ISenderService<VerificationDataEntry>
    {
        private readonly BlockingCollection<VerificationDataEntry> _queue;
        private readonly IStorageService<VerificationDataEntry> _storageService;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _endpoint;
        public VerificationSenderService(BlockingCollection<VerificationDataEntry> queue, IStorageService<VerificationDataEntry> storageService, string endpoint)
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

        private async Task ProcessEntryAsync(VerificationDataEntry entry)
        {
            try
            {
                //var content = new StringContent($"{{\"qr_code\":\"{entry.Code}\"}}", Encoding.UTF8, "application/json");
                var content = new StringContent($@"
                {{
                    ""qr_code"": ""{entry.Code}"",
                    ""plant"": ""{Shared.Settings.FactoryCode}"",
                    ""wms_number"": ""{Shared.Settings.WmsNumber}"",
                    ""resource_code"": ""{Shared.Settings.RLinkId}"",
                    ""resource_name"": ""{Shared.Settings.LineName}"",
                    ""printed_date"": ""{entry.VerifiedDate}"",
                    ""status"": ""{entry.VerifiedStatus}""
                }}", Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);
                string responseContent = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(responseContent);
                string status = json.Value<string>("status");
                string serverStatus = json.Value<string>("serverStatus");
                string serverError = json.Value<string>("serverError");
                string saasError = "";

                if (response.IsSuccessStatusCode)
                {
                    _storageService.MarkAsSent(entry.Id, entry.VerifiedDate, status, serverStatus, saasError, serverError);
                }
                else
                {
                    //_storageService.AppendEntry(entry); // Re-append entry for retry
                    _queue.Add(entry);
                }
            }
            catch
            {
                //_storageService.AppendEntry(entry);
                _queue.Add(entry);
                // Do nothing if it fails
            }
        }

        public void Stop()
        {
            _cts.Cancel();
            _queue.CompleteAdding();
        }
    }
}
