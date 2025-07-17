using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BarcodeVerificationSystem.Model.CodeGeneration
{
    public class ManufacturingCode
    { 
        private static string _shiptoCode = "2000000573"; // 10 characters
        private static string _shipmentCode = "00136999"; // 8 characters
        private static string _lineCode = "B2"; //Bình Dương: B1 ; B2 -- Hưng Yên: H1 ; H2
        //private string _randomCode = "1sd34d"; // 6 characters

        public ManufacturingCode(string shiptoCode, string shipment, string lineCode, string randomCode)
        {
            _shiptoCode = shiptoCode;
            _shipmentCode = shipment;
            _lineCode = lineCode;
            //_randomCode = randomCode; // Ký tự loại bỏ: O U E A I, W
        }

        public string GenerateCode(string _randomCode)
        {
            if (_shiptoCode.Length != 10 || _shipmentCode.Length != 8 || _lineCode.Length != 2 || _randomCode.Length != 6)
            {
                MessageBox.Show("Invalid code length. Please check the input values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!Shared.Settings.IsManufacturingMode)
            {
                MessageBox.Show("Manufacturing code generation is not available in dispatching mode.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }

            return $"{_shiptoCode}{_shipmentCode}{_lineCode}{_randomCode}";
        }

        public static bool TryParse(string fullCode, out string randomCode)
        {
            randomCode = string.Empty;

            if (string.IsNullOrWhiteSpace(fullCode) || fullCode.Length != 26)
                return false;

            string shipToPart = fullCode.Substring(0, 10);
            string shipmentPart = fullCode.Substring(10, 8);
            string lineCodePart = fullCode.Substring(18, 2);
            string randomPart = fullCode.Substring(20, 6);

            // Validate parts length (redundant here but makes logic explicit)
            if (shipToPart.Length == 10 &&
                shipmentPart.Length == 8 &&
                lineCodePart.Length == 2 &&
                randomPart.Length == 6)
            {
                randomCode = randomPart;
                return true;
            }

            //if (shipToPart == _shiptoCode &&
            //    shipmentPart == _shipmentCode &&
            //    lineCodePart == _lineCode)
            //{
            //    randomCode = randomPart;
            //    return true;
            //}

            return false;
        }
    }
}
