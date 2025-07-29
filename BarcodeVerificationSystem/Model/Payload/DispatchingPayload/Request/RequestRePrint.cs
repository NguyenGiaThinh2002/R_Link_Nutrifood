using BarcodeVerificationSystem.Controller;
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
        public string unique_code { get; set; }
        public string plant { get; set; } = Shared.Settings.FactoryCode;
        public string resource_code { get; set; } = Shared.Settings.RLinkId;
        public string resource_name { get; set; } = Shared.Settings.LineName;
        public string username { get; set; } = CurrentUser.UserName;
        public string notes { get; set; }
        public DateTime scan_date { get; set; } = DateTime.Now;
        public string status { get; set; } = "RePrint";
        public DateTime sync_date { get; set; }
    }
}
