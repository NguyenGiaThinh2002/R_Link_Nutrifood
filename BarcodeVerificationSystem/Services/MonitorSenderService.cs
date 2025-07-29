using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Apis.Dispatching;
using BarcodeVerificationSystem.Model.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Services
{
    internal class MonitorSenderService
    {
        public static async void SendParametersToServer()
        {
            await Task.Run(() => SendParametersToServerAsync());
        }

        private static async void SendParametersToServerAsync()
        {
            ApiService apiService = new ApiService();

            try
            {
                while (true)
                {

                    try
                    {
                        var settings = Shared.Settings;
                        string url = DispatchingApis.GetMonitorUrl();

                        var monitor = new MonitorPayload
                        {
                            plant = settings.FactoryCode,
                            resource_code = settings.RLinkId,
                            resource_name = settings.LineName,
                            ip_address_rlink = GetLocalIPv4Address(),
                            is_running = Shared.OperStatus == Model.OperationStatus.Running,
                            ip_address_printer = settings.PrinterList[0].IP,
                            ip_address_camera = settings.CameraList[0].IP,
                            is_printer_connected = settings.PrinterList[0].IsConnected,
                            is_camera_connected = settings.CameraList[0].IsConnected,
                            timestamp = DateTime.Now
                        };

                        await apiService.PostApiDataAsync(url, monitor);
                    }
                    catch (Exception)
                    {
                        //apiService.Dispose();
                    }

                    await Task.Delay(2000);
                }
            }
            catch (OperationCanceledException)
            {
                //apiService.Dispose();
                Console.WriteLine("Thread send parameters to server was stopped!");
            }
            catch (Exception ex)
            {
                //apiService.Dispose();
                Console.WriteLine("Error sending parameters to server: " + ex.Message);
            }
        }

        private static string GetLocalIPv4Address()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ip = host
                    .AddressList
                    .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);

                return ip?.ToString() ?? "No IPv4 address found";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }


    //object parameters = new
    //{
    //    NumberPrinted,
    //    ReceivedCode,
    //    _NumberOfSentPrinter,
    //    TotalChecked,
    //    NumberOfCheckPassed,
    //    NumberOfCheckFailed
    //};


    //var jsonContent = JsonConvert.SerializeObject(printedContent, new JsonSerializerSettings
    //{
    //    ContractResolver = new CamelCasePropertyNamesContractResolver()
    //});
    //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    //var response = await _httpClient.PostAsync(_endpoint, content, _cts.Token);
}
