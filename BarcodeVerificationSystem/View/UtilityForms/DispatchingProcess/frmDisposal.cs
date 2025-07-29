using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Apis.Dispatching;
using BarcodeVerificationSystem.Model.CodeGeneration;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UILanguage;
using BarcodeVerificationSystem.View.CustomDialogs;

namespace BarcodeVerificationSystem.View.UtilityForms.DispatchingProcess
{
    public partial class frmDisposal : Form
    {
        private Panel listContainer;
        private FlowLayoutPanel flowProducts;
        TextBox txtNotes = new TextBox();
        private Button btnAddProduct;
        private Button btnDispose;
        private List<RequestDisposal> disposedItems = new List<RequestDisposal>();
        private string notes = string.Empty;

        public frmDisposal()
        {
            InitializeComponent();
            InitializeLayout();
            RegisterEvents();
        }

        private void InitializeLayout()
        {
            this.Text = "Product List";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 800);
            this.BackColor = Color.White;

            // Label-like border panel container
            listContainer = new Panel();
            listContainer.Location = new Point(20, 70);
            listContainer.Size = new Size(940, 700);
            listContainer.BorderStyle = BorderStyle.FixedSingle;
            listContainer.BackColor = Color.WhiteSmoke;

            // Title label (acts like a border label)
            Label lblListTitle = new Label();
            lblListTitle.Text = "Product List";
            lblListTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblListTitle.BackColor = Color.White;
            lblListTitle.Location = new Point(10, 50);
            lblListTitle.Size = new Size(120, 20);

            // Flow panel for product items
            flowProducts = new FlowLayoutPanel();
            flowProducts.Location = new Point(10, 10);
            flowProducts.Size = new Size(920, 620); // Reduce height to make space for notes
            flowProducts.FlowDirection = FlowDirection.TopDown;
            flowProducts.WrapContents = false;
            flowProducts.AutoScroll = true;
            flowProducts.Padding = new Padding(5);
            flowProducts.BackColor = Color.White;

            // Notes label
            Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.Location = new Point(10, 640);
            lblNotes.Size = new Size(50, 20);

            // Notes TextBox
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Location = new Point(60, 635);
            txtNotes.Size = new Size(870, 50);
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.TextChanged += NotesTextBox_TextChanged;

            // Add to list container
            listContainer.Controls.Add(flowProducts);
            listContainer.Controls.Add(lblNotes);
            listContainer.Controls.Add(txtNotes);

            // Add container and title to form
            this.Controls.Add(listContainer);
            this.Controls.Add(lblListTitle);

            // Add product button (left top)
            btnAddProduct = new Button();
            btnAddProduct.Text = "Add Product";
            btnAddProduct.Size = new Size(150, 35);
            btnAddProduct.Location = new Point(20, 20);
            btnAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // this.Controls.Add(btnAddProduct);

            // Sort button (right top)
            btnDispose = new Button();
            btnDispose.Text = Lang.Dispose;
            btnDispose.Size = new Size(100, 35);
            btnDispose.Location = new Point(860, 20);
            btnDispose.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Controls.Add(btnDispose);
        }
        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                notes = txt.Text.Trim();
                //CustomMessageBox.Show("Note updated: " + notes, "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optional: store the note or trigger other logic here
            }
        }

        private void RegisterEvents()
        {
            btnAddProduct.Click += AddSampleProduct;
            Shared.OnSerialDeviceReadDataChange += AddReprintBarcodes;
            btnDispose.Click += BtnDispose_Click;
        }

        private async void BtnDispose_Click(object sender, EventArgs e)
        {
            var apiService = new ApiService();
            //await apiService.PostApiDataAsync(ReprintCodesUrl, reprintItems);
            //using (var apiService = new ApiService())
            //}

            try
            {

                string DisposedCodesUrl = DispatchingApis.GetDestroyCodesUrl();

                DateTime now = DateTime.Now;
                disposedItems.ForEach(item => { item.destroy_date = now; item.notes = notes; });
                //disposedItems.ForEach(item => item.notes = notes);
                var request = new RequestListDisposal
                {
                    qrCodes = disposedItems
                };

                bool isPosted =  await apiService.PostApiDataAsync(DisposedCodesUrl, request);
                if (isPosted)
                {
                    CustomMessageBox.Show("Reprint dispose sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                CustomMessageBox.Show("Failed to send dispose request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                disposedItems.Clear();
                flowProducts.Controls.Clear();
                notes = string.Empty; // Clear notes after disposal
                txtNotes.Clear();
            }
        }

        private void AddSampleProduct(object sender, EventArgs e)
        {
            var demoModel = new DetectModel { Text = "Demo Product " + DateTime.Now.ToLongTimeString() };
            AddReprintBarcodes(demoModel, EventArgs.Empty);
        }

        private void AddReprintBarcodes(object sender, EventArgs e)
        {
            if (Shared.OperStatus == OperationStatus.Running && Shared.OperStatus == OperationStatus.Processing)
                return;

            var model = sender as DetectModel;
            if (model == null || string.IsNullOrWhiteSpace(model.Text)) return;

            var item = new ProductItem(model.Text.Trim());
            item.OnDeleteClicked += delegate
            {
                RemoveItem(item);
            };

            AddItem(item);

            disposedItems.Add(new RequestDisposal
            {
                qr_code = model.Text.Trim(),
                unique_code = Dispatching.GetHumanReadableCode(model.Text.Trim()),
            });

            //reprintItems.Add(new RequestRePrint
            //{
            //    qr_code = model.Text.Trim(),
            //    unique_code = Dispatching.GetHumanReadableCode(model.Text.Trim()),
            //    notes = "Reprint request",
            //    sync_date = DateTime.Now // nay can chinh voi nut sort or st
            //});
        }

        private void AddItem(Control item)
        {
            if (flowProducts.InvokeRequired)
            {
                flowProducts.Invoke(new MethodInvoker(delegate
                {
                    flowProducts.Controls.Add(item);
                }));
            }
            else
            {
                flowProducts.Controls.Add(item);
            }
        }

        private void RemoveItem(Control item)
        {
            if (flowProducts.InvokeRequired)
            {
                flowProducts.Invoke(new MethodInvoker(delegate
                {
                    flowProducts.Controls.Remove(item);
                    item.Dispose();
                }));
            }
            else
            {
                flowProducts.Controls.Remove(item);
                item.Dispose();
            }
        }

        // Nested user control
        public class ProductItem : UserControl
        {
            public event EventHandler OnDeleteClicked;

            private Label lblName;
            private Button btnDelete;

            public string ProductName
            {
                get { return lblName.Text; }
                set { lblName.Text = value; }
            }

            public ProductItem(string productName)
            {
                this.Size = new Size(890, 50);
                this.Margin = new Padding(5);
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.FixedSingle;

                lblName = new Label();
                lblName.Text = productName;
                lblName.Font = new Font("Segoe UI", 9);
                lblName.Location = new Point(10, 10);
                lblName.Size = new Size(700, 30);
                lblName.TextAlign = ContentAlignment.MiddleLeft;

                btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.Size = new Size(80, 30);
                btnDelete.Location = new Point(790, 10);
                btnDelete.Click += delegate
                {
                    if (OnDeleteClicked != null)
                        OnDeleteClicked(this, EventArgs.Empty);
                };

                this.Controls.Add(lblName);
                this.Controls.Add(btnDelete);
            }
        }
    }

}
