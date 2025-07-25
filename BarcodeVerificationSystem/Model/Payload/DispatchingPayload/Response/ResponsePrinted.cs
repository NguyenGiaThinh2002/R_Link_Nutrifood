using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload
{
    internal class ResponsePrinted
    {
        public bool isSuccessed { get; set; }
        public int status_code { get; set; }
        public string error_code { get; set; }
        public string message { get; set; }
        public bool isSuccessed_sap { get; set; }
        public int status_code_sap { get; set; }
        public string error_code_sap { get; set; }
        public string message_sap { get; set; }
    }
}
