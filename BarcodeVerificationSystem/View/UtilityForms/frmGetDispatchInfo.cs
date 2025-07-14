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
using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.View.CustomDialogs;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmGetDispatchInfo : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public frmGetDispatchInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupDataGridView();
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

            try
            {
                var items = JsonConvert.DeserializeObject<List<JToken>>(Shared.Settings.JTokenDispatchingItemsJson);
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dgvItems.Rows.Add(
                            item["material_number"]?.ToString(),
                            item["material_name"]?.ToString(),
                            item["status_desc"]?.ToString(),
                            item["item_group"]?.ToString(),
                            item["uom_name"]?.ToString(),
                            item["case_cnt"]?.ToString(),
                            item["pallet"]?.ToString(),
                            item["original_qty"]?.ToString(),
                            item["total_qty_ctn"]?.ToString(),
                            item["gross_wgt"]?.ToString(),
                            item["cube"]?.ToString()
                        );
                    }
                }
            }
            catch { /* optionally log error */ }

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

        private void SetupDataGridView()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("material_number", "Material Number");
            dgvItems.Columns.Add("material_name", "Material Name");
            dgvItems.Columns.Add("status_desc", "Status");
            dgvItems.Columns.Add("item_group", "Item Group");
            dgvItems.Columns.Add("uom_name", "UOM");
            dgvItems.Columns.Add("case_cnt", "Case Count");
            dgvItems.Columns.Add("pallet", "Pallet");
            dgvItems.Columns.Add("original_qty", "Original Quatity");
            dgvItems.Columns.Add("total_qty_ctn", "Total Qty Ctn");
            dgvItems.Columns.Add("gross_wgt", "Gross Weight");
            dgvItems.Columns.Add("cube", "Cube");

            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
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
                Shared.Settings.OrderId = orderId;
                string productionMode = Shared.Settings.IsManufacturingMode ? "manufacturing" : "dispatching";
                string apiUrl = Shared.Settings.ApiUrl + "/" + Shared.Settings.RLinkId + "/" + productionMode + "/getOrder/" + orderId;

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string payload = await response.Content.ReadAsStringAsync();
                Shared.Settings.DispatchingPayload = payload;
                // Parse and display JSON
                var jsonObject = JObject.Parse(payload);
                txtPayload.Text = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                // Populate DataGridView with items  
                dgvItems.Rows.Clear();
                var items = jsonObject["item"]?.Children().ToList();
                string wms_number = jsonObject["wms_number"]?.ToString();

                Shared.Settings.WmsNumber = wms_number;
                Shared.Settings.JTokenDispatchingItems = items;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dgvItems.Rows.Add(
                            item["material_number"]?.ToString(),
                            item["material_name"]?.ToString(),
                            item["status_desc"]?.ToString(),
                            item["item_group"]?.ToString(),
                            item["uom_name"]?.ToString(),
                            item["case_cnt"]?.ToString(),
                            item["pallet"]?.ToString(),
                            item["original_qty"]?.ToString(),
                            item["total_qty_ctn"]?.ToString(),
                            item["gross_wgt"]?.ToString(),
                            item["cube"]?.ToString()

                        );
                    }
                }

                btnAction.Enabled = dgvItems.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Shared.Settings.DispatchingPayload = string.Empty;
                Shared.Settings.JTokenDispatchingItems = new List<JToken>();
                Shared.Settings.JTokenDispatchingItemsJson = "[]";

                txtPayload.Text = $"Error: {ex.Message}";
                dgvItems.Rows.Clear();
                btnAction.Enabled = false;
                CustomMessageBox.Show($"Failed to retrieve order information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Shared.SaveSettings();
        }

        private void btnPerform(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvItems.SelectedRows[0];
            string materialNumber = selectedRow.Cells["material_number"].Value.ToString();
            string materialName = selectedRow.Cells["material_name"].Value.ToString();

            // Example action: Display selected item details
            MessageBox.Show($"Performing action on item:\nMaterial Number: {materialNumber}\nMaterial Name: {materialName}",
                "Item Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
