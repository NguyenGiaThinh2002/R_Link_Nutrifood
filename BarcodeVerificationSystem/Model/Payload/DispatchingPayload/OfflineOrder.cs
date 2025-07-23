using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload
{
    internal class OfflineOrder
    {
        public string wave_key { get; set; }
        public string wms_number { get; set; }
        public string shipment { get; set; }
        public string material_number { get; set; }
        public string material_name { get; set; }
        public int total_qty_ctn { get; set; }

    }
}
