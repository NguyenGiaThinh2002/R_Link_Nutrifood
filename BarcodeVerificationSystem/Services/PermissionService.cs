using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BarcodeVerificationSystem.Model.UserPermission;
using Newtonsoft.Json.Linq;
using BarcodeVerificationSystem.Controller;

namespace BarcodeVerificationSystem.Services
{
    public class PermissionService
    {
        private static readonly HttpClient _client = new HttpClient();

        //public async Task<UserPermission> GetPermissionsAsync(object user)
        //{
        //    string url = $"http://192.168.15.189:5555/settings/apiTestCalling1";

        //    // Serialize user object to JSON
        //    string jsonPayload = JsonConvert.SerializeObject(user);
        //    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //    // Send POST request with user in body
        //    var response = await _client.PostAsync(url, content);
        //    response.EnsureSuccessStatusCode();

        //    string json = await response.Content.ReadAsStringAsync();

        //    var dict = JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
            

        //    return new UserPermission { Permissions = dict };
        //}

        public async Task<UserPermission> GetPermissionsAsync(object user)
        {
              
            string url = Shared.Settings.ApiUrl + "/getPermission";

            string jsonPayload = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            // Expected JSON: { status: true/false, permissions: { ... } }
            var obj = JsonConvert.DeserializeObject<JObject>(json);

            bool status = obj["status"]?.ToObject<bool>() ?? false;
            if (!status)
            {
                return null;
            }
            var permissions = obj["permissions"]?.ToObject<Dictionary<string, bool>>() ?? new Dictionary<string, bool>();

            return new UserPermission
            {
                Permissions = permissions
            };
        }

    }

}
