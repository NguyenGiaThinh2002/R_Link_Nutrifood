﻿using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestRePrint
    {
        public string qr_code { get; set; }
        public string job_name { get; set; } = Shared.CurrentJob.FileName;
        public string unique_code { get; set; }
        public DateTime scan_date { get; set; }
        public DateTime sync_date { get; set; } = DateTime.Now;
        public string notes { get; set; } = "test";
        public string status { get; set; } = "Reprint";
        public string plant { get; set; } = Shared.Settings.FactoryCode;
        public string resource_code { get; set; } = Shared.Settings.LineId;
        public string resource_name { get; set; } = Shared.Settings.LineName;
        public string username { get; set; } = CurrentUser.UserCode;
        public string material_number { get; set; } =
                Shared.CurrentJob.DispatchingOrderPayload.payload.items[Shared.CurrentJob.SelectedMaterialIndex].material_number;
    }
}
