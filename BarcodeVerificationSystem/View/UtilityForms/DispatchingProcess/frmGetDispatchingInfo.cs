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
using BarcodeVerificationSystem.Utils.CodeGeneration.Helper;
using System.Collections.Generic;
using UILanguage;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using System.Text;
using BarcodeVerificationSystem.Services;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BarcodeVerificationSystem.View.NutrifoodUI;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmGetDispatchingInfo : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly frmJobNutri _frmJob;

        public frmGetDispatchingInfo(frmJobNutri frmJob)
        {
            _frmJob = frmJob;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupDataGridView();
            InitEvents();
            InitControl();
            InitLanguage();
        }

        private void InitLanguage()
        {
            btnGetInfo.Text = Lang.GetInfo;
            btnGenerate.Text = Lang.GenerateCodes;
            materialItemsTxt.Text = Lang.MaterialItems + ":";
            orderInfo.Text = Lang.OrderInfo + ":";
            Close.Text = Lang.Close;
        }

        private void InitControl()
        {
            wmsNumber.Text = Shared.Settings.OrderId;

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
                            item.material_group?.ToString(),
                            item.uom?.ToString(),
                            item.qty_per_pallet.ToString(),
                            item.qty.ToString(),
                            item.qty_per_carton.ToString(),
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
            wmsNumber.TextChanged += AdjustData;
            btnGetInfo.Click += btnGetInfo_Click;
            btnGenerate.Click += btnGenerateCodes_Click;
        }
        private void Shared_OnSerialDeviceReadDataChange(object sender, EventArgs e)
        {
            if ((Shared.OperStatus == OperationStatus.Running && Shared.OperStatus == OperationStatus.Processing)) return;
            try
            {
                if (sender is DetectModel detectModel)
                {
                    // UI update must be done on the main thread
                    if (wmsNumber.InvokeRequired)
                    {
                        wmsNumber.Invoke(new MethodInvoker(delegate
                        {
                            wmsNumber.Text = detectModel.Text.Trim();
                            Shared.Settings.OrderId = wmsNumber.Text.Trim();
                        }));
                    }
                    else
                    {
                        wmsNumber.Text = detectModel.Text.Trim();
                        Shared.Settings.OrderId = wmsNumber.Text.Trim();
                    }
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
            dgvItems.Columns.Add("material_group", "Item Group");
            dgvItems.Columns.Add("uom", "UOM");
            dgvItems.Columns.Add("qty_per_pallet", "Pallet");
            dgvItems.Columns.Add("qty", "Quantity");
            dgvItems.Columns.Add("qty_per_carton", "Quantity Per Carton");
            dgvItems.Columns.Add("total_cube", "Cube");

            //dgvItems.Columns.Add("status_desc", "Status");
            //dgvItems.Columns.Add("case_cnt", "Case Count");
            //dgvItems.Columns.Add("original_qty", "Original Quantity");
            //dgvItems.Columns.Add("total_qty_ctn", "Total Qty Ctn");
            //dgvItems.Columns.Add("gross_wgt", "Gross Weight");


            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
        }

        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            string orderId = wmsNumber.Text.Trim();
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Please enter a valid Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string apiUrl = DispatchingApis.GetOrderInfoUrl(orderId);

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var loginPayload = JsonConvert.DeserializeObject<ResponseOrder>(await response.Content.ReadAsStringAsync());
                Shared.Settings.DispatchingOrderPayload = loginPayload;

                // Populate DataGridView with items  
                dgvItems.Rows.Clear();
                var items = loginPayload?.payload?.item.ToList();
                Shared.Settings.WmsNumber = loginPayload.payload.wms_number;
                Shared.Settings.OrderId = wmsNumber.Text;

                waveKey.Text = loginPayload.payload.wave_key;
                shipment.Text = loginPayload.payload.shipment;
                shiptoCode.Text = loginPayload.payload.shipto_code;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        dgvItems.Rows.Add(
                            item.material_number?.ToString(),
                            item.material_name?.ToString(),
                            item.material_group?.ToString(),
                            item.uom?.ToString(),
                            item.qty_per_pallet.ToString(),
                            item.qty.ToString(),
                            item.qty_per_carton.ToString(),
                            item.cube.ToString()
                        //item.total_qty_ctn.ToString(),
                        //item.gross_wgt.ToString(),

                        );
                    }
                }

                btnGenerate.Enabled = dgvItems.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Shared.Settings.DispatchingOrderPayload = null;
                //txtPayload.Text = $"Error: {ex.Message}";
                dgvItems.Rows.Clear();
                btnGenerate.Enabled = false;
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
            //string numberOfCodes = selectedRow.Cells["total_qty_ctn"].Value.ToString();
            string selectedQy = selectedRow.Cells["qty"].Value.ToString();
            string selectedQtyPerCarton = selectedRow.Cells["qty_per_carton"].Value.ToString();

            int numberOfCodes = (int.Parse(selectedQy) / int.Parse(selectedQtyPerCarton));

            DialogResult result = CustomMessageBox.Show(
                         Lang.AreYouSureGenerateDispatchingCodes +
                         $"\nWMS Number: {wms_number}" +
                         $"\nNumber Of Codes: {numberOfCodes}" +
                         $"\nMaterial Number: {materialNumber}" +
                         $"\nMaterial Name: {materialName}",
                         Lang.Confirm,
                         MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool isManufacturingMode = Shared.Settings.IsManufacturingMode;
                List<string> list;
                if (isManufacturingMode) // san xuat
                {
                    list = Base30AutoCodeGenerator.GenerateLineCodesForLoyalty(quantity: numberOfCodes);
                }
                else // xuat hang
                {
                    list = AutoIDCodeGenerator.GenerateCodesWithAutoID( quantity: numberOfCodes);
                }

                SendGeneratedCodes(list);

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
                Shared.numberOfCodesGenerate = list.Count;
                this.Close();
            }

        }

        private async void SendGeneratedCodes(List<string> list)
        {
            var payload = Shared.Settings.DispatchingOrderPayload.payload;
            var selectedRow = dgvItems.SelectedRows[0];
            string materialNumber = selectedRow.Cells["material_number"].Value.ToString();
            string materialName = selectedRow.Cells["material_name"].Value.ToString();
            string jobName = _frmJob._JobModel.FileName;

            List<QrCode> qrCodes = new List<QrCode>();

            for (int i = 0; i< list.Count; i++)
            {
                string[] fields = list[i].Split(',');
                var t = new QrCode
                {
                    id = i + 1,
                    unique_code = fields[0],
                    qr_code = fields[1],
                    job_name = jobName
                };
                qrCodes.Add(t);
            }

            var request = new RequestBasedData
            {
                wms_number = payload.wms_number,
                job_name = jobName,
                material_number = materialNumber,
                wave_key = payload.wave_key,
                first_index = Shared.FirstGeneratedCodeIndex.ToString(),
                last_index = Shared.LastGeneratedCodeIndex.ToString(),
                qrCodes = qrCodes,
            };
            string url = DispatchingApis.GetSendGeneratedCodesUrl();

            await SendAsync(request, url);

            //string url = DispatchingApis.GetSendGeneratedCodesUrl();
            //var apiService = new ApiService();
            //var isResponsed = await apiService.PostApiDataAsync(url, request);
            //apiService.Dispose();
        }
        private async Task SendAsync(RequestBasedData data, string url)
        {

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(json);

            using (var ms = new MemoryStream())
            {
                using (var gzip = new GZipStream(ms, CompressionMode.Compress))
                {
                    gzip.Write(bytes, 0, bytes.Length);
                }

                var compressedBytes = ms.ToArray();
                var content = new ByteArrayContent(compressedBytes);
                content.Headers.ContentEncoding.Add("gzip");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(url, content);
                var responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseText);
            }
        }

        private byte[] Compress(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, CompressionMode.Compress, leaveOpen: false)) // ensure proper close
                {
                    gzip.Write(bytes, 0, bytes.Length);
                }
                return output.ToArray(); // This will now include the full compressed stream
            }
        }


        private void getDataOffline_Click(object sender, EventArgs e)
        {
            //var offlineForm = new frmGetDispatchingDataOffline();
            //offlineForm.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
