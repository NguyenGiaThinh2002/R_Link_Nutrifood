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
                    plant = Shared.Settings.FactoryCode,
                    wms_number = _jobModel.DispatchingOrderPayload.payload.wms_number,
                    wave_key = _jobModel.DispatchingOrderPayload.payload.wave_key,
                    material_number = _jobModel.DispatchingOrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_number,
                    resource_code = Shared.Settings.RLinkId,
                    resource_name = Shared.Settings.LineName,
                    actual_quantity = int.Parse(numberOfCodes.Text),
                    username = Shared.UserPermission?.OnlineUserModel?.ten_tai_khoan ?? Shared.LoggedInUser.UserName,
                    notes = note.Text,
                    confirm_type = Shared.Settings.IsManufacturingMode ? "Loyalty" : "Shipment",
                    confirm_date = DateTime.Now
                };

                var jsonContent = JsonConvert.SerializeObject(confirmCompletionContent, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string endpoint = Shared.Settings.IsManufacturingMode
                    ? ManufacturingApis.getConfirmCompletionUrl()
                    : DispatchingApis.getConfirmCompletionUrl();
                var response = await _httpClient.PostAsync(endpoint, content, _cts.Token);

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
