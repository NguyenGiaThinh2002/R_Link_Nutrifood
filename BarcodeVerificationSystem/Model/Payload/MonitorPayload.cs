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
        public string plant { get; set; }
        public string resource_code { get; set; }
        public string resource_name { get; set; }
        public string ip_address_rlink { get; set; }
        public bool is_running { get; set; }
        public string username { get; set; } = CurrentUser.UserName;
        public string ip_address_printer { get; set; }
        public string ip_address_camera { get; set; }
        public bool is_printer_connected { get; set; }
        public bool is_camera_connected { get; set; }
        public DateTime timestamp { get; set; }
    }
}
