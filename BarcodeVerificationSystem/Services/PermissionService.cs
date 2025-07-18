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
            // Get login data
            var loginResponse = await _client.GetAsync(ApiModel.getLoginUrl(username, password));
            loginResponse.EnsureSuccessStatusCode();
            var loginPayload = JsonConvert.DeserializeObject<LoginPayload>(await loginResponse.Content.ReadAsStringAsync());

            if (loginPayload?.data?.Count == 0) return null;
            string maQuyen = loginPayload.data[0].MaQuyen;

            // Get permissions
            var permResponse = await _client.GetAsync(ApiModel.getPermissionUrl(maQuyen));
            permResponse.EnsureSuccessStatusCode();
            var permPayload = JsonConvert.DeserializeObject<PermissionPayload>(await permResponse.Content.ReadAsStringAsync());

            if (permPayload?.data == null) return null;

            var userPermissions = permPayload.data
                .Where(p => !string.IsNullOrWhiteSpace(p.MaChucNang))
                .ToDictionary(p => p.MaChucNang, _ => true);

            return new UserPermission
            {
                OnlineUserModel = loginPayload.data[0],
                Permissions = userPermissions
            };
        }

        //public async Task<UserPermission> GetPermissionsAsync(string username, string password)
        //{
        //    string url = ApiModel.getLoginUrl(username, password);
        //    HttpResponseMessage response = await _client.GetAsync(url);
        //    response.EnsureSuccessStatusCode();
        //    string json = await response.Content.ReadAsStringAsync();
        //    var loginPayload = JsonConvert.DeserializeObject<LoginPayload>(json);

        //    string MaQuyen = "";
        //    if (loginPayload != null && loginPayload.data != null && loginPayload.data.Count > 0)
        //    {
        //        MaQuyen = loginPayload.data[0].MaQuyen;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    string loginUrl = ApiModel.getPermissionUrl(MaQuyen);
        //    HttpResponseMessage response1 = await _client.GetAsync(loginUrl);
        //    response.EnsureSuccessStatusCode();
        //    string json1 = await response1.Content.ReadAsStringAsync();
        //    var permissionPayload = JsonConvert.DeserializeObject<PermissionPayload>(json1);

        //    Dictionary<string, bool> userPermission = new Dictionary<string, bool>();
        //    if (permissionPayload?.data != null)
        //    {
        //        List<PermissionDatum> permissions = permissionPayload.data;

        //        foreach (var item in permissions)
        //        {
        //            if (!string.IsNullOrWhiteSpace(item.MaChucNang))
        //            {
        //                userPermission[item.MaChucNang] = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    return new UserPermission
        //    {
        //        OnlineUserModel = loginPayload.data[0],
        //        Permissions = userPermission
        //    };
        //}

    }

}
