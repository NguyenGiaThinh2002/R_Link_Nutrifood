using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BarcodeVerificationSystem.Model.CodeGeneration
{
    public class DispatchingCode
    {
        private static string _url = "https://loyalty.nuti.vn/"; // 24 characters
        private static string _factoryId = "2"; // 2	Bình Dương - 3	Gia Lai - 4	Hưng Yên
        private static string _yearAndMonth = DateTime.Now.ToString("yyMM");

        //private string _yearAndMonth = "2507"; // 4 characters
        //private string _randomCode = "01234567890B"; // 12 characters

        public DispatchingCode(string url, string factoryId, string yearAndMonth, string randomCode)
        {
            _url = url;
            _factoryId = factoryId;
            _yearAndMonth = yearAndMonth;
            //_randomCode = randomCode; // Ký tự loại bỏ: O U E A I, W
        }
        public static string GenerateCode(string _randomCode)
        {
            if (_url.Length != 24 || _factoryId.Length != 1 || _yearAndMonth.Length != 4 || _randomCode.Length != 12) 
            {
                throw new ArgumentException("Invalid code length. Please check the input values.");
            }

            if (Shared.Settings.IsManufacturingMode)
            {
                throw new ArgumentException("Invalid code length. Please check the input values.");
            }

            return $"{_url}{_factoryId}{_yearAndMonth}{_randomCode}"; // Tong ky tu la 41
        }

        // to take the random code from the generated code
        public static bool TryParse(string code, out string randomCode)
        {
            randomCode = string.Empty;

            if (string.IsNullOrWhiteSpace(code) || code.Length != 27)
                return false;

            string urlPart = code.Substring(0, 10);
            string factoryIdPart = code.Substring(10, 1);
            string yearMonthPart = code.Substring(11, 4);
            string randomCodePart = code.Substring(15, 12);

            // Validate each segment's length and basic format
            if (urlPart.Length == 10 &&
                factoryIdPart.Length == 1 &&
                yearMonthPart.Length == 4 &&
                randomCodePart.Length == 12)
            {
                randomCode = randomCodePart;
                return true;
            }

            return false;
        }
    }
}
