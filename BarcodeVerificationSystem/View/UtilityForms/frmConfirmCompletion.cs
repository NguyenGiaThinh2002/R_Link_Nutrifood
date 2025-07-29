using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using BarcodeVerificationSystem.View.CustomDialogs;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities;
using BarcodeVerificationSystem.Model.Apis.Manufacturing;
using BarcodeVerificationSystem.Model.Apis.Dispatching;
using System.Threading;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.Services;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmConfirmCompletion : Form
    {
        private JobModel _jobModel;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public frmConfirmCompletion(JobModel jobModel)
        {
            _jobModel = jobModel;
            InitializeComponent();
            InitControls();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitControls()
        {
            wmsNumber.Text = _jobModel.DispatchingOrderPayload.payload.wms_number;
            materialID.Text = _jobModel.DispatchingOrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_number;
            materialName.Text = _jobModel.DispatchingOrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_name;
        }

        private async void btnConfirmCompletion_Click(object sender, EventArgs e)
        {

            try
            {
                var confirmCompletionContent = new RequestConfirmCompletion
                {
                    wms_number = _jobModel.DispatchingOrderPayload.payload.wms_number,
                    wave_key = _jobModel.DispatchingOrderPayload.payload.wave_key,
                    material_number = _jobModel.DispatchingOrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_number,
                    actual_quantity = int.Parse(numberOfCodes.Text),
                    notes = note.Text,
                    confirm_type = Shared.Settings.IsManufacturingMode ? "Loyalty" : "Shipment",
                };

                string endpoint = Shared.Settings.IsManufacturingMode
                        ? ManufacturingApis.getConfirmCompletionUrl()
                        : DispatchingApis.GetConfirmCompletionUrl();

                //var jsonContent = JsonConvert.SerializeObject(confirmCompletionContent, new JsonSerializerSettings
                //{
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                //});
                //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    
                //var response = await _httpClient.PostAsync(endpoint, content, _cts.Token);

                var apiService = new ApiService();
                var isResponsed = await apiService.PostApiDataAsync(endpoint, confirmCompletionContent);
                //apiService.Dispose();

                CustomMessageBox.Show("Job completed successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}
