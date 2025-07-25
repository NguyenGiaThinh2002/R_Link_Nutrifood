using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.View.CustomDialogs;
using Newtonsoft.Json.Linq;
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
using BarcodeVerificationSystem.Model.Apis;
using GenCode.Utils;
using BarcodeVerificationSystem.Model.Apis.Manufacturing;
using BarcodeVerificationSystem.Utils.CodeGeneration.Helper;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmGetManufacturingInfo : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public frmGetManufacturingInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitEvents();
            InitControl();
        }

        private void InitControl()
        {
            txtOrderId.Text = Shared.Settings.OrderId;

            if (!string.IsNullOrWhiteSpace(Shared.Settings.DispatchingPayload))
            {
                try { txtPayload.Text = JObject.Parse(Shared.Settings.DispatchingPayload).ToString(Formatting.Indented); }
                catch { txtPayload.Text = "Invalid JSON"; }
            }
            else txtPayload.Text = "No payload";

        }

        private void InitEvents()
        {
            Shared.OnSerialDeviceReadDataChange += Shared_OnSerialDeviceReadDataChange;
        }
        private void Shared_OnSerialDeviceReadDataChange(object sender, EventArgs e)
        {
            if ((Shared.OperStatus == OperationStatus.Running && Shared.OperStatus == OperationStatus.Processing)) return;
            try
            {
                if (sender is DetectModel)
                {
                    var detectModel = sender as DetectModel;
                    txtOrderId.Text = detectModel.Text.Trim();
                }
            }
            catch (Exception)
            {
            }
        }

        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            string orderId = txtOrderId.Text.Trim();
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Please enter a valid Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string apiUrl = ManufacturingApis.getOrderInfoUrl();

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string payload = await response.Content.ReadAsStringAsync();
                Shared.Settings.DispatchingPayload = payload;
                // Parse and display JSON
                var jsonObject = JObject.Parse(payload);
                txtPayload.Text = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);


            }
            catch (Exception ex)
            {
                Shared.Settings.DispatchingPayload = string.Empty;

                txtPayload.Text = $"Error: {ex.Message}";
                CustomMessageBox.Show($"Failed to retrieve order information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Shared.SaveSettings();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            var jsonObject = JObject.Parse(Shared.Settings.DispatchingPayload);

            //  var list = Base30AutoCodeGenerator.GenerateLineCodesForLoyalty(quantity: 100);
            bool isManufacturingMode = Shared.Settings.IsManufacturingMode;
            List<string> list;
            if (isManufacturingMode) // san xuat
            {
                list = Base30AutoCodeGenerator.GenerateLineCodesForLoyalty(quantity: 100);
            }
            else // xuat hang
            {
                list = AutoIDCodeGenerator.GenerateCodesWithAutoID(100);
            }


            string materialNumber = jsonObject["material"].ToString();
            string materialName = jsonObject["material_description"].ToString();

            // Example action: Display selected item details
            MessageBox.Show($"Performing action on item:\nMaterial Number: {materialNumber}\nMaterial Name: {materialName}",
                "Item Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
