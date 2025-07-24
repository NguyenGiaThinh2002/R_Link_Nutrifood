using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.View.CustomDialogs;
using GenCode.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Force.DeepCloner;


namespace BarcodeVerificationSystem.View.SubForms
{
    public partial class frmGetDispatchingDataOffline : Form
    {
        private readonly FrmJob _frmJob;
        private CreateScrollablePanel itemScrollablePanel;
        private Panel _panel;


        private ResponseOrder _orderPayload = new ResponseOrder
        {
            isSuccessed = true,
            message = "Success",
            payload = new ResponseOrder.Payload
            {
                item = new List<ResponseOrder.Item>
                {
                    new ResponseOrder.Item()
                }
            }
        };


        public frmGetDispatchingDataOffline(FrmJob frmJob)
        {
            _frmJob = frmJob;
            if(Shared.Settings.DispatchingOrderPayload != null)
            {
                //_orderPayload = Shared.Settings.OrderPayload;
                _orderPayload = Shared.Settings.DispatchingOrderPayload.DeepClone();

            }

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitEvents();
            SetupDataGridView();
            InitControl();

            CreateScrollablePanel payloadScrollablePanel = new CreateScrollablePanel();
            Panel payloadScrollPanel = payloadScrollablePanel.CreatePanel(33, 273, 803, 263, this.Controls);

            if (Shared.Settings.DispatchingOrderPayload != null)
            {
                payloadScrollablePanel.CreateTextBoxes(Shared.Settings.DispatchingOrderPayload.payload, "payload", payloadScrollPanel);
            }
            else
            {
                payloadScrollablePanel.CreateTextBoxes(_orderPayload.payload, "payload", payloadScrollPanel);
            }

            //payloadScrollablePanel.CreateTextBoxes(_orderPayload.payload, _orderPayload.payload.GetType().GetProperties().Count() - 1, payloadScrollPanel);
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

        private void InitControl()
        {
            //txtOrderId.Text = Shared.Settings.OrderId;

            try
            {
                //var items = JsonConvert.DeserializeObject<List<JToken>>(Shared.Settings.JTokenDispatchingItemsJson);
                _orderPayload = Shared.Settings.DispatchingOrderPayload.DeepClone();
                var items = Shared.Settings.DispatchingOrderPayload.payload.item;
                dgvItems.Rows.Clear(); // Clear existing rows before adding new ones


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
            btnAction.Click += btnGenerateCodes_Click;
            addMaterial.Click += AddMaterial_Click;
            deleteButton.Click += DeleteButton_Click;
            btnEdit.Click += BtnEdit_Click;

            //deleteButton.Click += WrapWithSave(DeleteButton_Click);
        }

        private EventHandler WrapWithSave(EventHandler originalHandler)
        {
            return (sender, e) =>
            {
                originalHandler?.Invoke(sender, e); // Run original logic
                Shared.Settings.DispatchingOrderPayload = _orderPayload;
                Shared.SaveSettings();
            };
        }

        private void SetAllNamesDefault()
        {
            dgvItems.Visible = true;
            addMaterial.Visible = true;
            btnEdit.Text = "Edit";
            deleteButton.Text = "Delete";
        }

        private void SetAllNameEditing()
        {
            dgvItems.Visible = false;
            btnEdit.Text = "Save";
            deleteButton.Text = "Cancel";
            addMaterial.Visible = false;
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Text == "Edit")
            {
                SetAllNameEditing();

                int _lineIndex = dgvItems.SelectedRows[0].Index;

                ClearItemScrollPanel();
                itemScrollablePanel = new CreateScrollablePanel();
                _panel = itemScrollablePanel.CreatePanel(33, 94, 660, 169, this.Controls);
                itemScrollablePanel.CreateTextBoxes(_orderPayload.payload.item[_lineIndex], "", _panel);
            }
            else if(btnEdit.Text == "Save")
            {
                SetAllNamesDefault();
                Shared.Settings.DispatchingOrderPayload = _orderPayload;
                Shared.SaveSettings();
                InitControl();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(deleteButton.Text == "Delete")
            {
                int lineIndex = dgvItems.SelectedRows[0].Index;
                if (lineIndex >= 0 && lineIndex < _orderPayload.payload.item.Count)
                {
                    _orderPayload.payload.item.RemoveAt(lineIndex);
                    dgvItems.Rows.RemoveAt(lineIndex);
                }

                Shared.Settings.DispatchingOrderPayload = _orderPayload;
                Shared.SaveSettings();
            }
            else if(deleteButton.Text == "Cancel")
            {
                SetAllNamesDefault();
            }
            InitControl();
        }

        bool CheckEmpty(TextBox box, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                MessageBox.Show($"{fieldName} cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return true;
            }
            return false;
        }

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            if(addMaterial.Text == "Add Material")
            {
                SetAllNameEditing();

                _orderPayload.payload.item.Add(new ResponseOrder.Item());


                ClearItemScrollPanel();
                itemScrollablePanel = new CreateScrollablePanel();
                _panel = itemScrollablePanel.CreatePanel(33, 94, 660, 169, this.Controls);
                itemScrollablePanel.CreateTextBoxes(_orderPayload.payload.item.LastOrDefault(), "", _panel);
            }

        }

        private void ClearItemScrollPanel()
        {
            if (itemScrollablePanel != null && _panel != null)
            {
                itemScrollablePanel = null;
                _panel.Controls.Clear();          // remove all child controls
                this.Controls.Remove(_panel);      // remove panel from form
                _panel.Dispose();                  // free memory
                _panel = null;                     // clear reference
            }
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


        //private void btnGenerateCodes_Click(object sender, EventArgs e)
        //{
        //    string materialNumber = orderID.Text;
        //    string materialName = materialID.Text;
        //    string wms_number = wmsNumber.Text;
        //    string codeNumber = numberOfCodes.Text;

        //    if (string.IsNullOrEmpty(materialNumber) ||
        //        string.IsNullOrEmpty(materialName) ||
        //        string.IsNullOrEmpty(wms_number) ||
        //        string.IsNullOrEmpty(codeNumber))
        //    {
        //        // Handle empty field case (e.g., show error message)
        //        CustomMessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return; // Exit the method or block
        //    }

        //    DialogResult result = CustomMessageBox.Show(
        //        $"Are you sure you want to generate dispatching codes for:" +
        //        $"\nWMS Number: {wms_number}" +
        //        $"\nMaterial Number: {materialNumber}" +
        //        $"\nMaterial Name: {materialName}" +
        //        $"\nNumber of Codes: {codeNumber}",
        //        "Confirm Action",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        var list = Base30AutoCodeGenerator.GenerateLineCodes(lineIndex: 0, totalLines: 14, startValue: 100, initialCurrent: 100, quantity: int.Parse(codeNumber));

        //        string tableName = "DispatchingCodes"; // Example table name, adjust as needed
        //        string fileName = $"{tableName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        //        //string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "R-Link");
        //        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "R-Link", "Database");

        //        if (!Directory.Exists(documentsPath))
        //        {
        //            Directory.CreateDirectory(documentsPath);
        //        }

        //        string filePath = Path.Combine(documentsPath, fileName);
        //        Console.WriteLine(documentsPath);

        //        CsvConvert.WriteStringListToCsv(list, filePath);
        //        Shared.databasePath = filePath;

        //        _frmJob._JobModel.OrderPayload.payload.wms_number = wms_number;
        //        _frmJob._JobModel.OrderPayload.payload.item[0].material_number = materialNumber;
        //        _frmJob._JobModel.OrderPayload.payload.item[0].material_name = materialName;


        //        this.Close();
        //    }



        //}

    }
}
