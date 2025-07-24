using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestConfirmCompletion
    {
        public string plant { get; set; }
        public string wave_key { get; set; }
        public string wms_number { get; set; }
        public string material_number { get; set; }
        public string resource_code { get; set; }
        public string resource_name { get; set; }
        public int actual_quantity { get; set; }
        public string username { get; set; }
        public string notes { get; set; }
        public string confirm_type { get; set; }
        public DateTime confirm_date { get; set; }
    }
}
