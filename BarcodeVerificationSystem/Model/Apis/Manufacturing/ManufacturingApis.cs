using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Apis.Manufacturing
{
    public class ManufacturingApis
    {
        public ManufacturingApis() { }

        static string url = Shared.Settings.ApiUrl;

        private static string _getReservationUrl = $"{url}/api/production/get_reservation";
        private static string _getProcessOrderInfoUrl = $"{url}/api/production/get_process_order";
        private static string _getBatchInfoUrl = $"{url}/api/production/get_batch_info";

        private static string _postCurrentPrintedCodeInfo = $"{url}/api/production/getCurrentProcessing";
        private static string _postGeneratedCodesUrl = $"{url}/api/production/pushDatabase";
        private static string _postPrintedDataUrl = $"{url}/api/production/printed";
        private static string _postCheckedDataUrl = $"{url}/api/production/checked";
        private static string _postDestroyCodesUrl = $"{url}/api/production/destroy";
        private static string _postReservationUrl = $"{url}/api/production/reservation";

        public static string getReservationUrl(string plant, string material_doc)
        {
            return $"{_getReservationUrl}?plant={plant}&material_doc={material_doc}" ;
        }

        public static string getProcessOrderInfoUrl(string resourceCode, string plant)
        {
            return $"{_getProcessOrderInfoUrl}/?resource_code={resourceCode}&plant={plant}";
        }

        public static string getBatchInfoUrl(string plant, string process_order)
        {
            return $"{_getBatchInfoUrl}/?plant={plant}&process_order={process_order}";
        }

        public static string postCurrentPrintedCodeInfo()
        {
            return _postCurrentPrintedCodeInfo;
        }

        public static string postDestroyCodesUrl()
        {
            return _postDestroyCodesUrl;
        }

        public static string postPrintedDataUrl()
        {
            return _postPrintedDataUrl;
        }

        public static string postReservationUrl()
        {
            return _postReservationUrl;
        }

        public static string postGeneratedCodesUrl()
        {
            return _postGeneratedCodesUrl;
        }

        public static string postCheckedDataUrl()
        {
            return _postCheckedDataUrl;
        }

    }
}
