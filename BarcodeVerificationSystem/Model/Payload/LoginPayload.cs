using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload
{

    internal class Datum
    {
        public string _id { get; set; }
        public string MaQuyen { get; set; }
        public string MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
    }

    internal class LoginPayload
    {
        public string msg { get; set; }
        public bool success { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<object> DisplayFields { get; set; }
        public List<Datum> data { get; set; }
    }

}
