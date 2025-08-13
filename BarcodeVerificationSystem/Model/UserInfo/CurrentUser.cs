using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.UserInfo
{
    internal class CurrentUser
    {
        public static string UserName = Shared.UserPermission?.OnlineUserModel?.ten_tai_khoan ?? SecurityController.Decrypt(Shared.LoggedInUser.UserName, "rynan_encrypt_remember");
        public static string UserCode = Shared.UserPermission?.OnlineUserModel?.ma_tai_khoan ?? SecurityController.Decrypt(Shared.LoggedInUser.UserName, "rynan_encrypt_remember");
    }
}
