using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestRePrint
    {
        public int id { get; set; }
        public int index_qr_code { get; set; }
        public string session_code { get; set; }
        public string qr_code { get; set; }
        public string human_qr_code { get; set; }
        public string wms_reservation_code { get; set; }
        public string material { get; set; }
        public string resource_code { get; set; }
        public string resource_name { get; set; }
        public string username { get; set; }
        public string notes { get; set; }
        public string printed_date { get; set; }
    }
}
