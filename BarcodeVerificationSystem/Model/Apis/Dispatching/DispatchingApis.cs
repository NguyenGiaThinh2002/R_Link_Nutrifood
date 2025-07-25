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

        //private static string _getOrderInfoUrl = $"{url}/api/shipment/get/plant/wms_code"; WTF is this
        private static string _getOrderInfoUrl = $"{url}/api/shipment/get/{factoryCode}";

        //private static string _getOrderInfoUrl = $"{url}/getOrder/{orderId}";
        private static string _printedDataUrl = $"{url}/api/shipment/printed";
        private static string _monitorUrl = $"{url}/api/shipment/monitoring";
        private static string _confirmCompletionUrl = $"{url}/api/shipment/confirmcomplete";

        private static string _destroyCodesUrl = $"{url}/api/shipment/destroy";
        private static string _reprintCodesUrl = $"{url}/api/production/reprint";

        public static string getOrderInfoUrl(string wmsNumber)
        {
            return _getOrderInfoUrl + "/" + wmsNumber;
        }

        public static string getPrintedDataUrl()
        {
            return _printedDataUrl;
        }

        public static string getMonitorUrl()
        {
            return _monitorUrl;
        }

        public static string getConfirmCompletionUrl()
        {
            return _confirmCompletionUrl;
        }
        public static string getDestroyCodesUrl()
        {
            return _destroyCodesUrl;
        }

        public static string getReprintCodesUrl()
        {
            return _reprintCodesUrl;
        }
    }
}
