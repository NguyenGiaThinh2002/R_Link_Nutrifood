﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Response
{
    public class ResponseRevervation
    {
        public bool is_success { get; set; }
        public string message { get; set; }
        public string material_doc { get; set; }
        public string reservation { get; set; }
        public string sales_org { get; set; }
        public string create_date { get; set; }
        public int add_qty { get; set; }
        public string print_template_name { get; set; }
        public List<Item> items { get; set; }
    }
    public class Item
    {
        public int line_id { get; set; }
        public string material_number { get; set; }
        public string material_name { get; set; }
        public string batch { get; set; }
        public string date_of_mauf { get; set; }
        public string expried_date { get; set; }
        public int qty { get; set; }
        public string uom { get; set; }
        public int qty_per_carton { get; set; }
        public string uom_per_carton { get; set; }
        public int qty_per_pallet { get; set; }
        public string uom_per_pallet { get; set; }
        public string issue_plant { get; set; }
        public string issue_sloc { get; set; }
        public string receive_plant { get; set; }
        public string receive_sloc { get; set; }
        public int printed_count { get; set; }

    }
}
