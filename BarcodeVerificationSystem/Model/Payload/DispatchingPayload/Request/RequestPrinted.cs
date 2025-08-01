using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestPrinted
    {
        public int id { get; set; }
        public string job_name { get; set; }
        public string qr_code { get; set; }                 
        public string unique_code { get; set; }
        //public string shipto_code { get; set; }
        //public string wms_number { get; set; }           
        public string material_number { get; set; } = 
            Shared.CurrentJob.DispatchingOrderPayload.payload.item[Shared.CurrentJob.SelectedMaterialIndex].material_number;
        public string resource_code { get; set; } = Shared.Settings.RLinkId;
        public string resource_name { get; set; } = Shared.Settings.LineName;
        public string username { get; set; } = CurrentUser.UserName;
        public DateTime printed_date { get; set; }
        public string status { get; set; } = "Printed";
        public DateTime sync_date { get; set; } = DateTime.Now;

    }
}

//public string plant { get; set; }                    // Plant code
//public string wave_key { get; set; }                 // Wave number (unique per plant)
