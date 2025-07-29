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
        private static string _sendGeneratedCodesUrl = $"{url}/api/shipment/orderCodes";
        private static string _printedDataUrl = $"{url}/api/shipment/printed";
        private static string _monitorUrl = $"{url}/api/shipment/monitoring";
        private static string _confirmCompletionUrl = $"{url}/api/shipment/confirmcomplete";
        private static string _destroyCodesUrl = $"{url}/api/shipment/destroy";
        private static string _reprintCodesUrl = $"{url}/api/production/reprint";

        public static string GetOrderInfoUrl(string wmsNumber)
        {
            return _getOrderInfoUrl + "/" + wmsNumber;
        }

        public static string GetSendGeneratedCodesUrl()
        {
            return _printedDataUrl; // _sendGeneratedCodesUrl
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
    }
}
