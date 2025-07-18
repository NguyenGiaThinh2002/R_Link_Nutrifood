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
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDatabaseType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPayload
            // 
            this.txtPayload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtPayload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayload.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtPayload.Location = new System.Drawing.Point(33, 245);
            this.txtPayload.Margin = new System.Windows.Forms.Padding(5);
            this.txtPayload.Multiline = true;
            this.txtPayload.Name = "txtPayload";
            this.txtPayload.ReadOnly = true;
            this.txtPayload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPayload.Size = new System.Drawing.Size(803, 291);
            this.txtPayload.TabIndex = 6;
            this.txtPayload.WordWrap = false;
            // 
            // dgvItems
            // 
            this.dgvItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvItems.Location = new System.Drawing.Point(33, 94);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(5);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(660, 141);
            this.dgvItems.TabIndex = 10;
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(708, 94);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(130, 32);
            this.btnAction.TabIndex = 11;
            this.btnAction.Text = "Generate Code";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnGetInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetInfo.FlatAppearance.BorderSize = 0;
            this.btnGetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetInfo.ForeColor = System.Drawing.Color.White;
            this.btnGetInfo.Location = new System.Drawing.Point(563, 41);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(130, 32);
            this.btnGetInfo.TabIndex = 12;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.UseVisualStyleBackColor = false;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.BackColor = System.Drawing.Color.White;
            this.txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOrderId.Location = new System.Drawing.Point(33, 46);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(5);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(504, 27);
            this.txtOrderId.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(708, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "Create Offline";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.getDataOffline_Click);
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabaseType.Location = new System.Drawing.Point(29, 16);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(75, 25);
            this.lblDatabaseType.TabIndex = 18;
            this.lblDatabaseType.Text = "Order ID: ";
            // 
            // frmGetDispatchingInfo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.lblDatabaseType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.txtPayload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGetDispatchingInfo";
            this.Text = "Order Info Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPayload;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDatabaseType;
    }

}
