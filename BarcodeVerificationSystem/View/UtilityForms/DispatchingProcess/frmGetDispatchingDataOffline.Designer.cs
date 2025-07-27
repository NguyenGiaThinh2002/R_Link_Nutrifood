namespace BarcodeVerificationSystem.View.SubForms
{
    partial class frmGetDispatchingDataOffline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetDispatchingDataOffline));
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderID = new DesignUI.CuzUI.CuzTextBox();
            this.materialID = new DesignUI.CuzUI.CuzTextBox();
            this.numberOfCodes = new DesignUI.CuzUI.CuzTextBox();
            this.btnGenerate = new DesignUI.CuzUI.CuzButton();
            this.wmsNumber = new DesignUI.CuzUI.CuzTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new DesignUI.CuzUI.CuzButton();
            this.txtOrderId = new DesignUI.CuzUI.CuzTextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.addMaterial = new DesignUI.CuzUI.CuzButton();
            this.deleteButton = new DesignUI.CuzUI.CuzButton();
            this.Close = new DesignUI.CuzUI.CuzButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabaseType.Location = new System.Drawing.Point(59, 31);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(75, 25);
            this.lblDatabaseType.TabIndex = 22;
            this.lblDatabaseType.Text = "Order ID: ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(45, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Material ID: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(2, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Number of codes:";
            // 
            // orderID
            // 
            this.orderID._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.orderID._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.orderID.BackColor = System.Drawing.Color.White;
            this.orderID.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.orderID.BorderFocusColor = System.Drawing.Color.Silver;
            this.orderID.BorderRadius = 6;
            this.orderID.BorderSize = 1;
            this.orderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.orderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.orderID.Location = new System.Drawing.Point(168, 23);
            this.orderID.Margin = new System.Windows.Forms.Padding(4);
            this.orderID.Multiline = false;
            this.orderID.Name = "orderID";
            this.orderID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.orderID.PasswordChar = false;
            this.orderID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.orderID.PlaceholderText = "";
            this.orderID.ReadOnly = false;
            this.orderID.Size = new System.Drawing.Size(450, 35);
            this.orderID.TabIndex = 121;
            this.orderID.UnderlinedStyle = false;
            // 
            // materialID
            // 
            this.materialID._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.materialID._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.materialID.BackColor = System.Drawing.Color.White;
            this.materialID.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.materialID.BorderFocusColor = System.Drawing.Color.Silver;
            this.materialID.BorderRadius = 6;
            this.materialID.BorderSize = 1;
            this.materialID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.materialID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.materialID.Location = new System.Drawing.Point(168, 93);
            this.materialID.Margin = new System.Windows.Forms.Padding(4);
            this.materialID.Multiline = false;
            this.materialID.Name = "materialID";
            this.materialID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.materialID.PasswordChar = false;
            this.materialID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.materialID.PlaceholderText = "";
            this.materialID.ReadOnly = false;
            this.materialID.Size = new System.Drawing.Size(450, 35);
            this.materialID.TabIndex = 122;
            this.materialID.UnderlinedStyle = false;
            // 
            // numberOfCodes
            // 
            this.numberOfCodes._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.numberOfCodes._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.numberOfCodes.BackColor = System.Drawing.Color.White;
            this.numberOfCodes.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.numberOfCodes.BorderFocusColor = System.Drawing.Color.Silver;
            this.numberOfCodes.BorderRadius = 6;
            this.numberOfCodes.BorderSize = 1;
            this.numberOfCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numberOfCodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numberOfCodes.Location = new System.Drawing.Point(168, 218);
            this.numberOfCodes.Margin = new System.Windows.Forms.Padding(4);
            this.numberOfCodes.Multiline = false;
            this.numberOfCodes.Name = "numberOfCodes";
            this.numberOfCodes.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.numberOfCodes.PasswordChar = false;
            this.numberOfCodes.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.numberOfCodes.PlaceholderText = "";
            this.numberOfCodes.ReadOnly = false;
            this.numberOfCodes.Size = new System.Drawing.Size(450, 35);
            this.numberOfCodes.TabIndex = 123;
            this.numberOfCodes.UnderlinedStyle = false;
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
            this.btnGenerate.Location = new System.Drawing.Point(708, 37);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 42);
            this.btnGenerate.TabIndex = 124;
            this.btnGenerate.Text = "Generate Code";
            this.btnGenerate.TextColor = System.Drawing.Color.White;
            this.btnGenerate.UseVisualStyleBackColor = false;
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
            this.wmsNumber.Location = new System.Drawing.Point(168, 159);
            this.wmsNumber.Margin = new System.Windows.Forms.Padding(4);
            this.wmsNumber.Multiline = false;
            this.wmsNumber.Name = "wmsNumber";
            this.wmsNumber.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.wmsNumber.PasswordChar = false;
            this.wmsNumber.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.wmsNumber.PlaceholderText = "";
            this.wmsNumber.ReadOnly = false;
            this.wmsNumber.Size = new System.Drawing.Size(450, 35);
            this.wmsNumber.TabIndex = 125;
            this.wmsNumber.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(31, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 126;
            this.label3.Text = "Wms number:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDatabaseType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.wmsNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.orderID);
            this.panel1.Controls.Add(this.numberOfCodes);
            this.panel1.Controls.Add(this.materialID);
            this.panel1.Location = new System.Drawing.Point(33, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 63);
            this.panel1.TabIndex = 127;
            this.panel1.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit._BorderColor = System.Drawing.Color.Silver;
            this.btnEdit._BorderRadius = 15;
            this.btnEdit._BorderSize = 0;
            this.btnEdit._GradientsButton = false;
            this.btnEdit._Text = "Edit";
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEdit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEdit.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnEdit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(708, 154);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 42);
            this.btnEdit.TabIndex = 130;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // txtOrderId
            // 
            this.txtOrderId._ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOrderId._ReadOnlyBorderFocusColor = System.Drawing.Color.Gainsboro;
            this.txtOrderId.BackColor = System.Drawing.Color.White;
            this.txtOrderId.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.txtOrderId.BorderFocusColor = System.Drawing.Color.Silver;
            this.txtOrderId.BorderRadius = 6;
            this.txtOrderId.BorderSize = 1;
            this.txtOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtOrderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOrderId.Location = new System.Drawing.Point(33, 44);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderId.Multiline = false;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtOrderId.PasswordChar = false;
            this.txtOrderId.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOrderId.PlaceholderText = "";
            this.txtOrderId.ReadOnly = false;
            this.txtOrderId.Size = new System.Drawing.Size(660, 35);
            this.txtOrderId.TabIndex = 129;
            this.txtOrderId.UnderlinedStyle = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgvItems.Location = new System.Drawing.Point(33, 94);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(5);
            this.dgvItems.MaximumSize = new System.Drawing.Size(660, 169);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 30;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(660, 169);
            this.dgvItems.TabIndex = 131;
            // 
            // addMaterial
            // 
            this.addMaterial._BorderColor = System.Drawing.Color.Silver;
            this.addMaterial._BorderRadius = 15;
            this.addMaterial._BorderSize = 0;
            this.addMaterial._GradientsButton = false;
            this.addMaterial._Text = "Add Material";
            this.addMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addMaterial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addMaterial.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.addMaterial.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.addMaterial.FlatAppearance.BorderSize = 0;
            this.addMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMaterial.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.addMaterial.ForeColor = System.Drawing.Color.White;
            this.addMaterial.Location = new System.Drawing.Point(708, 94);
            this.addMaterial.Name = "addMaterial";
            this.addMaterial.Size = new System.Drawing.Size(130, 42);
            this.addMaterial.TabIndex = 132;
            this.addMaterial.Text = "Add Material";
            this.addMaterial.TextColor = System.Drawing.Color.White;
            this.addMaterial.UseVisualStyleBackColor = false;
            // 
            // deleteButton
            // 
            this.deleteButton._BorderColor = System.Drawing.Color.Silver;
            this.deleteButton._BorderRadius = 15;
            this.deleteButton._BorderSize = 0;
            this.deleteButton._GradientsButton = false;
            this.deleteButton._Text = "Delete";
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteButton.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.deleteButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(708, 212);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(130, 42);
            this.deleteButton.TabIndex = 133;
            this.deleteButton.Text = "Delete";
            this.deleteButton.TextColor = System.Drawing.Color.White;
            this.deleteButton.UseVisualStyleBackColor = false;
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
            this.Close.Location = new System.Drawing.Point(708, 546);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(130, 42);
            this.Close.TabIndex = 143;
            this.Close.Text = "Close";
            this.Close.TextColor = System.Drawing.Color.White;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(35, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 144;
            this.label4.Text = "Wms Number:";
            // 
            // frmGetDispatchingDataOffline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addMaterial);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGetDispatchingDataOffline";
            this.Text = "Getting Data";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDatabaseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DesignUI.CuzUI.CuzTextBox orderID;
        private DesignUI.CuzUI.CuzTextBox materialID;
        private DesignUI.CuzUI.CuzTextBox numberOfCodes;
        private DesignUI.CuzUI.CuzButton btnGenerate;
        private DesignUI.CuzUI.CuzTextBox wmsNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private DesignUI.CuzUI.CuzButton btnEdit;
        private DesignUI.CuzUI.CuzTextBox txtOrderId;
        private System.Windows.Forms.DataGridView dgvItems;
        private DesignUI.CuzUI.CuzButton addMaterial;
        private DesignUI.CuzUI.CuzButton deleteButton;
        private DesignUI.CuzUI.CuzButton Close;
        private System.Windows.Forms.Label label4;
    }
}