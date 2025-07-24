using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestPrinted
    {
        public int id { get; set; }                          // ID QR code (auto-increment)
        public int index_qr_code { get; set; }               // Sequential index within a production session
        public string session_code { get; set; }             // Session run code
        public string qr_code { get; set; }                  // Printed QR code
        public string human_qr_code { get; set; }            // Unidecoded version of QR code
        public string plant { get; set; }                    // Plant code
        public string wave_key { get; set; }                 // Wave number (unique per plant)
        public string wms_number { get; set; }               // WMS order number (barcode)
        public string material_number { get; set; }          // Material code
        public string resource_code { get; set; }            // R-Link line code
        public string resource_name { get; set; }            // R-Link line name
        public string username { get; set; }                 // Operator username
        public DateTime printed_date { get; set; }           // QR printed timestamp
        public string status { get; set; }                   // QR code status (e.g. Printed)
    }
}
