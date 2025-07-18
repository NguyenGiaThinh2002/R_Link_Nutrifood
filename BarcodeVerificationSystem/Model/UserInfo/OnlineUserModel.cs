using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.UserInfo
{
    public class OnlineUserModel
    {
        public string _id { get; set; }
        public string MaQuyen { get; set; }
        public string TenQuyen { get; set; }
        public string MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
    }
}
