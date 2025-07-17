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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BarcodeVerificationSystem.Model.Payload;
using System.Collections;
using BarcodeVerificationSystem.Model.Apis;

namespace BarcodeVerificationSystem.Services
{
    public class PermissionService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<UserPermission> GetPermissionsAsync(string username, string password)
        {
            string url = ApiModel.getLoginUrl(username, password);
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            var loginPayload = JsonConvert.DeserializeObject<LoginPayload>(json);

            string MaQuyen = "";
            if (loginPayload != null && loginPayload.data != null && loginPayload.data.Count > 0)
            {
                MaQuyen = loginPayload.data[0].MaQuyen;
            }
            else
            {
                return null;
            }

            string loginUrl = ApiModel.getPermissionUrl(MaQuyen);
            HttpResponseMessage response1 = await _client.GetAsync(loginUrl);
            response.EnsureSuccessStatusCode();
            string json1 = await response1.Content.ReadAsStringAsync();
            var permissionPayload = JsonConvert.DeserializeObject<PermissionPayload>(json1);

            Dictionary<string, bool> userPermission = new Dictionary<string, bool>();
            if (permissionPayload?.data != null)
            {
                List<PermissionDatum> permissions = permissionPayload.data;

                foreach (var item in permissions)
                {
                    if (!string.IsNullOrWhiteSpace(item.MaChucNang))
                    {
                        userPermission[item.MaChucNang] = true;
                    }
                }
            }
            else
            {
                return null;
            }

            return new UserPermission
            {
                Permissions = userPermission
            };
        }

        public async Task<UserPermission> GetPermissionsAsync_BK250716(object user)
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
