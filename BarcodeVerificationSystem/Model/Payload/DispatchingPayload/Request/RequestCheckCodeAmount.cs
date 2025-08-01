using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestCheckCodeAmount
    {
        public string plant { get; set; }
        public string wave_key { get; set; }
        public string wms_number { get; set; }
        public string material_number { get; set; }
        public string username { get; set; }
    }
}
