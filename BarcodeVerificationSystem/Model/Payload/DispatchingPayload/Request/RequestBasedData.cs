using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestBasedData
    {
        public string wms_number { get; set; }
        public string username { get; set; }
        public string plant { get; set; }
        public string job_name { get; set; }
        public string material_number { get; set; }
        public string wave_key { get; set; }

        public List<QrCode> qrCodes { get; set; } = new List<QrCode>();
    }
}
