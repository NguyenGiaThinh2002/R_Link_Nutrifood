using System.Windows.Forms;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    partial class frmGetDispatchingInfo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetDispatchingInfo));
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.wmsNumber = new DesignUI.CuzUI.CuzTextBox();
            this.btnGetInfo = new DesignUI.CuzUI.CuzButton();
            this.btnGenerate = new DesignUI.CuzUI.CuzButton();
            this.materialItemsTxt = new System.Windows.Forms.Label();
            this.shiptoCodeTxt = new System.Windows.Forms.Label();
            this.shiptoCode = new DesignUI.CuzUI.CuzTextBox();
            this.shipmentTxt = new System.Windows.Forms.Label();
            this.shipment = new DesignUI.CuzUI.CuzTextBox();
            this.waveKeyTxt = new System.Windows.Forms.Label();
            this.waveKey = new DesignUI.CuzUI.CuzTextBox();
            this.orderInfo = new System.Windows.Forms.Label();
            this.Close = new DesignUI.CuzUI.CuzButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvItems.Location = new System.Drawing.Point(33, 299);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(5);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 30;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(803, 249);
            this.dgvItems.TabIndex = 10;
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabaseType.Location = new System.Drawing.Point(29, 16);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(108, 25);
            this.lblDatabaseType.TabIndex = 18;
            this.lblDatabaseType.Text = "Wms Number:";
            // 
            // wmsNumber
            // 
            this.wmsNumber._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.wmsNumber._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.wmsNumber.BackColor = System.Drawing.Color.White;
            this.wmsNumber.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.wmsNumber.BorderFocusColor = System.Drawing.Color.Silver;
            this.wmsNumber.BorderRadius = 6;
            this.wmsNumber.BorderSize = 1;
            this.wmsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.wmsNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wmsNumber.Location = new System.Drawing.Point(33, 41);
            this.wmsNumber.Margin = new System.Windows.Forms.Padding(4);
            this.wmsNumber.Multiline = false;
            this.wmsNumber.Name = "wmsNumber";
            this.wmsNumber.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.wmsNumber.PasswordChar = false;
            this.wmsNumber.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.wmsNumber.PlaceholderText = "";
            this.wmsNumber.ReadOnly = false;
            this.wmsNumber.Size = new System.Drawing.Size(660, 35);
            this.wmsNumber.TabIndex = 120;
            this.wmsNumber.UnderlinedStyle = false;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo._BorderColor = System.Drawing.Color.Silver;
            this.btnGetInfo._BorderRadius = 15;
            this.btnGetInfo._BorderSize = 0;
            this.btnGetInfo._GradientsButton = false;
            this.btnGetInfo._Text = "Get Info";
            this.btnGetInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGetInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGetInfo.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnGetInfo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.btnGetInfo.FlatAppearance.BorderSize = 0;
            this.btnGetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnGetInfo.ForeColor = System.Drawing.Color.White;
            this.btnGetInfo.Location = new System.Drawing.Point(706, 34);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(130, 42);
            this.btnGetInfo.TabIndex = 121;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.TextColor = System.Drawing.Color.White;
            this.btnGetInfo.UseVisualStyleBackColor = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate._BorderColor = System.Drawing.Color.Silver;
            this.btnGenerate._BorderRadius = 15;
            this.btnGenerate._BorderSize = 0;
            this.btnGenerate._GradientsButton = false;
            this.btnGenerate._Text = "Generate Code";
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerate.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnGenerate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(706, 249);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 42);
            this.btnGenerate.TabIndex = 122;
            this.btnGenerate.Text = "Generate Code";
            this.btnGenerate.TextColor = System.Drawing.Color.White;
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // materialItemsTxt
            // 
            this.materialItemsTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.materialItemsTxt.Location = new System.Drawing.Point(29, 266);
            this.materialItemsTxt.Name = "materialItemsTxt";
            this.materialItemsTxt.Size = new System.Drawing.Size(208, 25);
            this.materialItemsTxt.TabIndex = 124;
            this.materialItemsTxt.Text = "Material Items:";
            // 
            // shiptoCodeTxt
            // 
            this.shiptoCodeTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.shiptoCodeTxt.Location = new System.Drawing.Point(90, 225);
            this.shiptoCodeTxt.Name = "shiptoCodeTxt";
            this.shiptoCodeTxt.Size = new System.Drawing.Size(132, 25);
            this.shiptoCodeTxt.TabIndex = 141;
            this.shiptoCodeTxt.Text = "Shipto Code:";
            // 
            // shiptoCode
            // 
            this.shiptoCode._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.shiptoCode._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.shiptoCode.BackColor = System.Drawing.Color.White;
            this.shiptoCode.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.shiptoCode.BorderFocusColor = System.Drawing.Color.Silver;
            this.shiptoCode.BorderRadius = 6;
            this.shiptoCode.BorderSize = 1;
            this.shiptoCode.Enabled = false;
            this.shiptoCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.shiptoCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shiptoCode.Location = new System.Drawing.Point(240, 215);
            this.shiptoCode.Margin = new System.Windows.Forms.Padding(4);
            this.shiptoCode.Multiline = false;
            this.shiptoCode.Name = "shiptoCode";
            this.shiptoCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.shiptoCode.PasswordChar = false;
            this.shiptoCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.shiptoCode.PlaceholderText = "";
            this.shiptoCode.ReadOnly = false;
            this.shiptoCode.Size = new System.Drawing.Size(450, 35);
            this.shiptoCode.TabIndex = 140;
            this.shiptoCode.UnderlinedStyle = false;
            // 
            // shipmentTxt
            // 
            this.shipmentTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.shipmentTxt.Location = new System.Drawing.Point(90, 175);
            this.shipmentTxt.Name = "shipmentTxt";
            this.shipmentTxt.Size = new System.Drawing.Size(105, 25);
            this.shipmentTxt.TabIndex = 139;
            this.shipmentTxt.Text = "Shipment:";
            // 
            // shipment
            // 
            this.shipment._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.shipment._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.shipment.BackColor = System.Drawing.Color.White;
            this.shipment.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.shipment.BorderFocusColor = System.Drawing.Color.Silver;
            this.shipment.BorderRadius = 6;
            this.shipment.BorderSize = 1;
            this.shipment.Enabled = false;
            this.shipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.shipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shipment.Location = new System.Drawing.Point(240, 165);
            this.shipment.Margin = new System.Windows.Forms.Padding(4);
            this.shipment.Multiline = false;
            this.shipment.Name = "shipment";
            this.shipment.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.shipment.PasswordChar = false;
            this.shipment.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.shipment.PlaceholderText = "";
            this.shipment.ReadOnly = false;
            this.shipment.Size = new System.Drawing.Size(450, 35);
            this.shipment.TabIndex = 138;
            this.shipment.UnderlinedStyle = false;
            // 
            // waveKeyTxt
            // 
            this.waveKeyTxt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.waveKeyTxt.Location = new System.Drawing.Point(90, 126);
            this.waveKeyTxt.Name = "waveKeyTxt";
            this.waveKeyTxt.Size = new System.Drawing.Size(116, 25);
            this.waveKeyTxt.TabIndex = 137;
            this.waveKeyTxt.Text = "Wave key:";
            // 
            // waveKey
            // 
            this.waveKey._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.waveKey._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.waveKey.BackColor = System.Drawing.Color.White;
            this.waveKey.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.waveKey.BorderFocusColor = System.Drawing.Color.Silver;
            this.waveKey.BorderRadius = 6;
            this.waveKey.BorderSize = 1;
            this.waveKey.Enabled = false;
            this.waveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.waveKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waveKey.Location = new System.Drawing.Point(240, 116);
            this.waveKey.Margin = new System.Windows.Forms.Padding(4);
            this.waveKey.Multiline = false;
            this.waveKey.Name = "waveKey";
            this.waveKey.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.waveKey.PasswordChar = false;
            this.waveKey.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.waveKey.PlaceholderText = "";
            this.waveKey.ReadOnly = false;
            this.waveKey.Size = new System.Drawing.Size(450, 35);
            this.waveKey.TabIndex = 136;
            this.waveKey.UnderlinedStyle = false;
            // 
            // orderInfo
            // 
            this.orderInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.orderInfo.Location = new System.Drawing.Point(29, 91);
            this.orderInfo.Name = "orderInfo";
            this.orderInfo.Size = new System.Drawing.Size(158, 25);
            this.orderInfo.TabIndex = 123;
            this.orderInfo.Text = "Order information:";
            // 
            // Close
            // 
            this.Close._BorderColor = System.Drawing.Color.Silver;
            this.Close._BorderRadius = 15;
            this.Close._BorderSize = 0;
            this.Close._GradientsButton = false;
            this.Close._Text = "Close";
            this.Close.BackColor = System.Drawing.Color.Red;
            this.Close.BackgroundColor = System.Drawing.Color.Red;
            this.Close.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Close.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(706, 556);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(130, 42);
            this.Close.TabIndex = 142;
            this.Close.Text = "Close";
            this.Close.TextColor = System.Drawing.Color.White;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // frmGetDispatchingInfo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(850, 607);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.shiptoCodeTxt);
            this.Controls.Add(this.shiptoCode);
            this.Controls.Add(this.shipmentTxt);
            this.Controls.Add(this.shipment);
            this.Controls.Add(this.waveKeyTxt);
            this.Controls.Add(this.waveKey);
            this.Controls.Add(this.materialItemsTxt);
            this.Controls.Add(this.orderInfo);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.wmsNumber);
            this.Controls.Add(this.lblDatabaseType);
            this.Controls.Add(this.dgvItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetDispatchingInfo";
            this.Text = "Getting Data";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblDatabaseType;
        private DesignUI.CuzUI.CuzTextBox wmsNumber;
        private DesignUI.CuzUI.CuzButton btnGetInfo;
        private DesignUI.CuzUI.CuzButton btnGenerate;
        private Label materialItemsTxt;
        private Label shiptoCodeTxt;
        private DesignUI.CuzUI.CuzTextBox shiptoCode;
        private Label shipmentTxt;
        private DesignUI.CuzUI.CuzTextBox shipment;
        private Label waveKeyTxt;
        private DesignUI.CuzUI.CuzTextBox waveKey;
        private Label orderInfo;
        private DesignUI.CuzUI.CuzButton Close;
    }

}
