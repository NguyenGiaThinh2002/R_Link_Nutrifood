using BarcodeVerificationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Apis.Dispatching
{
    internal class DispatchingApis
    {
        static readonly string url = Shared.Settings.ApiUrl;
        static readonly string orderId = Shared.Settings.OrderId;
        static readonly string factoryCode = Shared.Settings.FactoryCode;

        private static string _getOrderInfoUrl = $"{url}/api/shipment/get/{factoryCode}";
        private static string _sendGeneratedCodesUrl = $"{url}/api/shipment/generatedCodes";
        private static string _printedDataUrl = $"{url}/api/shipment/printed";
        private static string _destroyCodesUrl = $"{url}/api/shipment/destroy";

        private static string _getReprintCodesUrl = $"{url}/api/production/reprint/get_info"; // ResponseListRePrint
        private static string _postReprintCodesUrl = $"{url}/api/production/reprint"; // ResponseListRePrint

        private static string _confirmCompletionUrl = $"{url}/api/shipment/confirmcomplete";
        private static string _monitorUrl = $"{url}/api/shipment/monitoring";

        private static string _getCurrentPrintedCodeInfo = $"{url}/api/shipment/getCurrentProcessing";

        public static string GetOrderInfoUrl(string wmsNumber)
        {
            return _getOrderInfoUrl + "/" + wmsNumber;
        }

        public static string GetSendGeneratedCodesUrl()
        {
            return _sendGeneratedCodesUrl; // _sendGeneratedCodesUrl
        }

        public static string GetPrintedDataUrl()
        {
            return _printedDataUrl;
        }

        public static string GetMonitorUrl()
        {
            return _monitorUrl;
        }

        public static string GetConfirmCompletionUrl()
        {
            return _confirmCompletionUrl;
        }
        public static string GetDestroyCodesUrl()
        {
            return _printedDataUrl; // _destroyCodesUrl
        }

        public static string GetSendReprintCodesUrl()
        {
            return _printedDataUrl;// _reprintCodesUrl
        }

        public static string GetCurrentPrintedCodeInfoUrl()  // ResponseCurrentPrintedCodeInfo
        {
            return _getCurrentPrintedCodeInfo;
        }
    }
}
