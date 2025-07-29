using BarcodeVerificationSystem.Model.Payload;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Services
{
    public class ApiService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<T> GetApiWithModel<T>(string url)
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // throws if not 2xx

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(responseContent);

            return result;
        }

        public async Task<JArray> GetApiDataAsync(string apiUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            //request.Headers.Add("Content-Type", "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            if ((string)json["status"] == "success")
            {
                return (JArray)json["data"];
            }
            else
            {
                throw new Exception("API returned error status.");
            }
        }

        public async Task<bool> PostApiDataAsync(string apiUrl, object payload)
        {
            try
            {
                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                using (content)
                {
                    var response = await _client.PostAsync(apiUrl, content, cts.Token);

                    if (!response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"HTTP {response.StatusCode}: {responseBody}");
                    }

                    return response.IsSuccessStatusCode;
                }
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine($"[Timeout] Request timed out: {ex.Message}");
                return false;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"[HttpRequest] {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Unexpected] {ex.Message}");
                return false;
            }
        }
        public void Dispose()
        {
            _client.Dispose();
            //GC.SuppressFinalize(this);

        }

    }
}