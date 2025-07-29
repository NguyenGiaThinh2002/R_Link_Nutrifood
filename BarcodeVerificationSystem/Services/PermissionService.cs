﻿using Newtonsoft.Json;
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
using System.Windows.Forms.Design;

namespace BarcodeVerificationSystem.Services
{
    public class PermissionService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<UserPermission> GetPermissionsAsync(string username, string password)
        {
            var apiService = new ApiService();
                try
                {
                    string loginUrl = ApiModel.getLoginUrl(username, password);
                    var loginPayload = await apiService.GetApiWithModel<LoginPayload>(loginUrl);

                    if (loginPayload?.data?.Count == 0) return null;
                    string maQuyen = loginPayload.data[0].ma_quyen;
                    string permissionUrl = ApiModel.getPermissionUrl(maQuyen);
                    var permPayload = await apiService.GetApiWithModel<PermissionPayload>(permissionUrl);

                    if (permPayload?.data == null) return null;

                    var userPermissions = permPayload.data
                        .Where(p => !string.IsNullOrWhiteSpace(p.ma_chuc_nang))
                        .ToDictionary(p => p.ma_chuc_nang, _ => true);

                    return new UserPermission
                    {
                        OnlineUserModel = loginPayload.data[0],
                        Permissions = userPermissions
                    };
                }
                catch (Exception)
                {
                    return null;
                }
        }

    }

}


// Get login data
//var loginResponse = await _client.GetAsync(ApiModel.getLoginUrl(username, password));
//loginResponse.EnsureSuccessStatusCode();
//var loginPayload = JsonConvert.DeserializeObject<LoginPayload>(await loginResponse.Content.ReadAsStringAsync());