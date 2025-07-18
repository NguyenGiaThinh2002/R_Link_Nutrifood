using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Apis
{
    internal class ApiModel
    {
        static string url = Shared.Settings.ApiUrl;
        static string productionMode = Shared.Settings.IsManufacturingMode ? "manufacturing" : "dispatching";
        static string rLinkId = Shared.Settings.RLinkId;
        static string orderId = Shared.Settings.OrderId;

        private static string _loginUrl = $"{url}/api/3C7937B217D14EBC803206646A17D896";
        private static string _permissionUrl = $"{url}/api/D5A06FABB7774BF3B911B15E8CD104B4";
        //private static string _getOrderInfoUrl = $"{url}/{rLinkId}/{productionMode}/getOrder/{orderId}";
        private static string _getOrderInfoUrl = $"{url}/getOrder/{orderId}";

        private static string _sendCheckedDataUrl = $"{url}/{rLinkId}/checkedData";
        private static string _sendPrintedDataUrl = $"{url}/{rLinkId}/printedData";
        private static string _sendParametersUrl = $"{url}/{rLinkId}/parameters";


        public static string getLoginUrl(string username, string password)
        {
            return _loginUrl + $"/{username}/{password}";
        }

        public static string getPermissionUrl(string maQuyen)
        {
            return _permissionUrl + $"/{maQuyen}";
        }

        public static string getOrderInfoUrl()
        {
            return _getOrderInfoUrl;
        }

        public static string getSendCheckedDataUrl()
        {
            return _sendCheckedDataUrl;
        }

        public static string getSendPrintedDataUrl()
        {
            return _sendPrintedDataUrl;
        }

        public static string getSendParametersUrl()
        {
            return _sendParametersUrl;
        }
   }
}
