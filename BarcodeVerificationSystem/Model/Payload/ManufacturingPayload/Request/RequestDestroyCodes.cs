using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Request
{
    public class RequestDestroyCodes
    {
        public List<Qrcode> qrcodes { get; set; }
        public string username { get; set; }
        public string notes { get; set; }
        public string sync_date { get; set; }
        public string status { get; set; }
        public string batch { get; set; }
        public string mauf_date { get; set; }
        public string expired_date { get; set; }
        public string plant { get; set; }
    }
    public class Qrcode
    {
        public string qr_code { get; set; }
        public string scan_date { get; set; }
    }
}
