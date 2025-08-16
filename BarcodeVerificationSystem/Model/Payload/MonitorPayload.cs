using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload
{
    internal class MonitorPayload
    {
        public int printed_codes_number { get; set; }
        public int generated_codes_number { get; set; }
        public int sent_saas_codes { get; set; }
        public int sent_sap_codes { get; set; }
        public bool is_software_connected { get; set; }

        public string plant { get; set; }
        public string device_code { get; set; } = Shared.Settings.RLinkName;
        public string resource_code { get; set; }
        public string resource_name { get; set; }
        public string ip_address_rlink { get; set; }
        public bool is_running { get; set; }
        public string username { get; set; } = "user031"; //  CurrentUser.UserCode
        public string ip_address_printer { get; set; }
        public string ip_address_camera { get; set; }
        public bool is_printer_connected { get; set; }
        public bool is_camera_connected { get; set; }
        public DateTime timestamp { get; set; }
    }
}
