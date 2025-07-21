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
using BarcodeVerificationSystem.Model.Apis;
using BarcodeVerificationSystem.Model.Payload;
using BarcodeVerificationSystem.View.SubForms;
using GenCode.Utils;
using System.IO;

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
                var items = Shared.Settings.OrderPayload.payload.item;

                
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
                string apiUrl = ApiModel.getOrderInfoUrl();

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var loginPayload = JsonConvert.DeserializeObject<OrderPayload>(await response.Content.ReadAsStringAsync());
                _frmJob._JobModel.OrderPayload = Shared.Settings.OrderPayload = loginPayload;
                txtPayload.Text = Shared.Settings.DispatchingPayload = JsonConvert.SerializeObject(loginPayload.payload, Newtonsoft.Json.Formatting.Indented);

                // Populate DataGridView with items  
                dgvItems.Rows.Clear();
                var items = loginPayload?.payload?.item.ToList();
                Shared.Settings.WmsNumber = loginPayload.payload.wms_number;

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
                txtPayload.Text = $"Error: {ex.Message}";
                dgvItems.Rows.Clear();
                btnAction.Enabled = false;
                CustomMessageBox.Show($"Failed to retrieve order information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Shared.SaveSettings();
        }

        private void GenCode()
        {
            //Task.Run(() =>
            //{
            //    Base30AutoCodeGenerator.GenerateLineCodes(lineIndex: 0, totalLines: 14, startValue: 100, initialCurrent: 100, quantity: 100); // Test 1 line
            //});
            //  Base30AutoCodeGenerator.RunBulkGenerationTest(10, 1000, totalLines: 1, 100, 100); // Test nhieu line

            List<string> test = Base30AutoCodeGenerator.GenerateLineCodes(lineIndex: 0, totalLines: 14, startValue: 100, initialCurrent: 100, quantity: 100);

        }

        private void btnGenerateCodes_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvItems.SelectedRows[0];
            string materialNumber = selectedRow.Cells["material_number"].Value.ToString();
            string materialName = selectedRow.Cells["material_name"].Value.ToString();

            var list = Base30AutoCodeGenerator.GenerateLineCodes(lineIndex: 0, totalLines: 14, startValue: 100, initialCurrent: 100, quantity: 100);

            string tableName = "DispatchingCodes"; // Example table name, adjust as needed
            string fileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            //string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "R-Link");
            string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "R-Link", "Database");

            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }

            string filePath = Path.Combine(documentsPath, fileName);
            Console.WriteLine(documentsPath);

            WriteStringListToCsv(list, filePath);
            Shared.databasePath = filePath;
            this.Close();
            // Example action: Display selected item details
            MessageBox.Show($"Performing action on item:\nMaterial Number: {materialNumber}\nMaterial Name: {materialName}",
                "Item Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void WriteStringListToCsv(List<string> list, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header
                    //writer.WriteLine("LineCode");

                    // Write each string in the list
                    foreach (var lineCode in list)
                    {
                        // Escape any quotes in the string and wrap in quotes to handle commas or special characters
                        //writer.WriteLine($"\"{lineCode.Replace("\"", "\"\"")}\"");
                        writer.WriteLine(lineCode);

                    }
                }
                Console.WriteLine($"Successfully wrote list to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }

        private void getDataOffline_Click(object sender, EventArgs e)
        {
            var offlineForm = new frmGetDataOffline();
            offlineForm.ShowDialog();
        }
    }

}
