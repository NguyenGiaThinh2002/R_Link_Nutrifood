using BarcodeVerificationSystem.Model.Apis.Manufacturing;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Request;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Response;
using BarcodeVerificationSystem.Services.Interface;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.View.CustomDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeVerificationSystem.Services.Manufacturing
{
    public class ManufacturingService : IManufacturingService
    {
        private readonly IApiService _apiService;
        public ManufacturingService()
        {
            _apiService = new ApiService();
        }

        public async Task<ResponseProcessOrder> GetProcessOrderAsync(string resourceCode, string plant)
        {
            return await _apiService.GetApiWithModelAsync<ResponseProcessOrder>(ManufacturingApis.getProcessOrderInfoUrl(resourceCode, plant));
        }

        public async Task<ResponseRevervation> GetReservationAsync(string plant, string material_doc)
        {
            return await _apiService.GetApiWithModelAsync<ResponseRevervation>(ManufacturingApis.getReservationUrl(plant, material_doc));
        }
        public async Task<ResponseBatchInfo> GetBatchInfoAsync(string plant, string material_doc)
        {
            return await _apiService.GetApiWithModelAsync<ResponseBatchInfo>(ManufacturingApis.getBatchInfoUrl(plant, material_doc));
        }

        public async Task<ResponseDestroyCodes> PostDestroyCodesAsync(RequestDestroyCodes payload)
        {
            return await _apiService.PostApiDataAsync<ResponseDestroyCodes>(ManufacturingApis.postDestroyCodesUrl(), payload);
        }

        public async Task<ResponseGeneratedCodes> PostGeneratedCodesAsync(RequestGeneratedCodes payload)
        {
            return await _apiService.PostCompressedDataAsync<ResponseGeneratedCodes>(ManufacturingApis.postGeneratedCodesUrl(), payload);
        }

        public async Task<ResponsePrintedAmount> PostPrintedAmountAsync(RequestPrintedAmount payload)
        {
            return await _apiService.PostApiDataAsync<ResponsePrintedAmount>(ManufacturingApis.postPrintedDataUrl(), payload);
        }

        public Task<ResponsePrinted> PostPrintedDataAsync(RequestPrinted payload)
        {
            return _apiService.PostApiDataAsync<ResponsePrinted>(ManufacturingApis.postPrintedDataUrl(), payload);
        }

        public async Task<ResponsePrinted> PostReservationAsync(RequestPrinted payload)
        {
            return await _apiService.PostApiDataAsync<ResponsePrinted>(ManufacturingApis.postReservationUrl(), payload);
        }

        public Task<ResponseChecked> PostVerifiedDataAsync(RequestChecked payload)
        {
            return _apiService.PostApiDataAsync<ResponseChecked>(ManufacturingApis.postCheckedDataUrl(), payload);
        }


        



    }
}
