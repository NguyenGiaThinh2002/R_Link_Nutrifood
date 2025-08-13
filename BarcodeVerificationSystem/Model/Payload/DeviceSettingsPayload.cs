using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload
{
    internal class DeviceSettingsPayload
    {
        public string resource_code { get; set; }
        public string resource_name { get; set; }
        public string device_name { get; set; }
        public string resource_type { get; set; }
        public string plant { get; set; }

    }
}
