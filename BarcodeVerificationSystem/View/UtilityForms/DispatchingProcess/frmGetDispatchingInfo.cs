using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.View.CustomDialogs;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using GenCode.Utils;
using System.IO;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.Model.Apis.Dispatching;
using BarcodeVerificationSystem.Model.CodeGeneration;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmGetDispatchingInfo : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly FrmJob _frmJob;

        public frmGetDispatchingInfo(FrmJob frmJob)
        {
            _frmJob = frmJob;
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
                //var items = JsonConvert.DeserializeObject<List<JToken>>(Shared.Settings.JTokenDispatchingItemsJson);
                var items = Shared.Settings.DispatchingOrderPayload.payload.item;

                
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dgvItems.Rows.Add(
                            item.material_number?.ToString(),
                            item.material_name?.ToString(),
                            item.status_desc?.ToString(),
                            item.item_group?.ToString(),
                            item.uom_name?.ToString(),
                            item.case_cnt.ToString(),
                            item.pallet.ToString(),
                            item.original_qty.ToString(),
                            item.total_qty_ctn.ToString(),
                            item.gross_wgt.ToString(),
                            item.cube.ToString()
                        );
                    }
                }
            }
            catch { /* optionally log error */ }

        }

        private void InitEvents()
        {
            Shared.OnSerialDeviceReadDataChange += Shared_OnSerialDeviceReadDataChange;
            txtOrderId.TextChanged += AdjustData;
            btnGetInfo.Click += btnGetInfo_Click;
            btnAction.Click += btnGenerateCodes_Click;
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
                    Shared.Settings.OrderId = txtOrderId.Text.Trim();
                }
            }
            catch (Exception)
            {
            }
        }

        private void AdjustData(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TextBox textBox when textBox.Name == "txtOrderId":
                    Shared.Settings.OrderId = textBox.Text.Trim();
                    break;
                default:
                    break;
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
                string apiUrl = DispatchingApis.getOrderInfoUrl(orderId);

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var loginPayload = JsonConvert.DeserializeObject<ResponseOrder>(await response.Content.ReadAsStringAsync());
                Shared.Settings.DispatchingOrderPayload = loginPayload;
                txtPayload.Text = Shared.Settings.DispatchingPayload = JsonConvert.SerializeObject(loginPayload.payload, Newtonsoft.Json.Formatting.Indented);

                // Populate DataGridView with items  
                dgvItems.Rows.Clear();
                var items = loginPayload?.payload?.item.ToList();
                Shared.Settings.WmsNumber = loginPayload.payload.wms_number;
                Shared.Settings.OrderId = txtOrderId.Text;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dgvItems.Rows.Add(
                            item.material_number?.ToString(),
                            item.material_name?.ToString(),
                            item.status_desc?.ToString(),
                            item.item_group?.ToString(),
                            item.uom_name?.ToString(),
                            item.case_cnt.ToString(),
                            item.pallet.ToString(),
                            item.original_qty.ToString(),
                            item.total_qty_ctn.ToString(),
                            item.gross_wgt.ToString(),
                            item.cube.ToString()

                        );
                    }
                }

                btnAction.Enabled = dgvItems.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Shared.Settings.DispatchingPayload = string.Empty;
                Shared.Settings.DispatchingOrderPayload = null;
                txtPayload.Text = $"Error: {ex.Message}";
                dgvItems.Rows.Clear();
                btnAction.Enabled = false;
                CustomMessageBox.Show($"Failed to retrieve order information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Shared.SaveSettings();
        }

        private void btnGenerateCodes_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int lineIndex = dgvItems.SelectedRows[0].Index;

            _frmJob._JobModel.SelectedMaterialIndex = lineIndex;
            _frmJob._JobModel.DispatchingOrderPayload = Shared.Settings.DispatchingOrderPayload;

            //Shared.Settings.DispatchingModel = _frmJob._JobModel.DispatchingModel = new Dispatching(
            //    Shared.Settings.DispatchingOrderPayload.payload.shipto_code,
            //    Shared.Settings.DispatchingOrderPayload.payload.shipment,
            //    Shared.Settings.FactoryCode
            //);

            var selectedRow = dgvItems.SelectedRows[0];
            string materialNumber = selectedRow.Cells["material_number"].Value.ToString();
            string materialName = selectedRow.Cells["material_name"].Value.ToString();
            string wms_number = Shared.Settings.WmsNumber;
            string numberOfCodes = selectedRow.Cells["total_qty_ctn"].Value.ToString();

            DialogResult result = CustomMessageBox.Show(
                $"Are you sure you want to generate dispatching codes for:" +
                $"\nWMS Number: {wms_number}" +
                $"\nNumber Of Codes: {numberOfCodes}" +
                $"\nMaterial Number: {materialNumber}" +
                $"\nMaterial Name: {materialName}",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var list = Base30AutoCodeGenerator.GenerateLineCodes(quantity: int.Parse(numberOfCodes));

                string tableName = "DispatchingCodes"; // Example table name, adjust as needed
                string fileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "R-Link", "Database");

                if (!Directory.Exists(documentsPath))
                {
                    Directory.CreateDirectory(documentsPath);
                }

                string filePath = Path.Combine(documentsPath, fileName);
                CsvConvert.WriteStringListToCsv(list, filePath); // Ensure this method is accessible
                Shared.databasePath = filePath;
                this.Close();
            }

           

        }

        private void getDataOffline_Click(object sender, EventArgs e)
        {
            //var offlineForm = new frmGetDispatchingDataOffline();
            //offlineForm.ShowDialog();
        }
    }

}
