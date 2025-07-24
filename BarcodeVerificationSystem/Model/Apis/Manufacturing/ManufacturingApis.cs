using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Apis.Manufacturing
{
    internal class ManufacturingApis
    {
        static string url = Shared.Settings.ApiUrl;
        static string productionMode = Shared.Settings.IsManufacturingMode ? "manufacturing" : "dispatching";
        static string rLinkId = Shared.Settings.RLinkId;
        static string orderId = Shared.Settings.OrderId;

        private static string _getOrderInfoUrl = $"{url}/getOrder/{orderId}";
        private static string _sendCheckedDataUrl = $"{url}/{rLinkId}/checkedData";
        private static string _sendPrintedDataUrl = $"{url}/{rLinkId}/printedData";
        private static string _sendParametersUrl = $"{url}/{rLinkId}/parameters";
        private static string _confirmCompletionUrl = $"{url}/api/loyalty/confirmcomplete";

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
        public static string getConfirmCompletionUrl()
        {
            return _confirmCompletionUrl;
        }
    }
}
