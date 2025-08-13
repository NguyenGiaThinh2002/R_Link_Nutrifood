using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload
{
    internal class ResponsePrinted
    {
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string error_code { get; set; }
        public string message { get; set; }
        public bool is_sucess_sap { get; set; }
        public int sap_status_code { get; set; }
        public string sap_error_code { get; set; }
        public string sap_message { get; set; }
    }
}
