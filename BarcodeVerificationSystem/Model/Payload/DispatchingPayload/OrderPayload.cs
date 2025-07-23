using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload
{
    public class OrderPayload
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public Payload payload { get; set; }

        public class Item
        {
            public string material_number { get; set; }
            public string material_name { get; set; }
            public string status_desc { get; set; }
            public string item_group { get; set; }
            public string uom_name { get; set; }
            public int case_cnt { get; set; }
            public int pallet { get; set; }
            public int original_qty { get; set; }
            public int total_qty_ctn { get; set; }
            public int gross_wgt { get; set; }
            public int cube { get; set; }
        }

        public class Payload
        {
            public string wave_key { get; set; }
            public string wms_number { get; set; }
            public string shipment { get; set; }
            public string door { get; set; }
            public string pick_list_count { get; set; }
            public string list_delivery_order { get; set; }
            public string list_sales_order { get; set; }
            public string soldto_code { get; set; }
            public string soldto_name { get; set; }
            public string shipto_code { get; set; }
            public string shipto_name { get; set; }
            public string shipto_address { get; set; }
            public string wave_desc { get; set; }
            public string warehouse { get; set; }
            public string trailer_number { get; set; }
            public string driver_number { get; set; }
            public string wave_type { get; set; }
            public string delivery_date { get; set; }
            public string effective_date { get; set; }
            public string notes { get; set; }
            public List<Item> item { get; set; }
        }
    }
}
