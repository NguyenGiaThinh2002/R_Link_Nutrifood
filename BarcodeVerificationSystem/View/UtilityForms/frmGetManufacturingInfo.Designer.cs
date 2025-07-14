namespace BarcodeVerificationSystem.View.UtilityForms
{
    partial class frmGetManufacturingInfo
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
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabaseType.Location = new System.Drawing.Point(43, 47);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(75, 25);
            this.lblDatabaseType.TabIndex = 17;
            this.lblDatabaseType.Text = "Order ID: ";
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(708, 40);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(130, 32);
            this.btnAction.TabIndex = 16;
            this.btnAction.Text = "Generate Code";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOrderId.BackColor = System.Drawing.Color.White;
            this.txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOrderId.Location = new System.Drawing.Point(126, 44);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(5);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(408, 27);
            this.txtOrderId.TabIndex = 15;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnGetInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetInfo.FlatAppearance.BorderSize = 0;
            this.btnGetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetInfo.ForeColor = System.Drawing.Color.White;
            this.btnGetInfo.Location = new System.Drawing.Point(562, 40);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(130, 32);
            this.btnGetInfo.TabIndex = 14;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.UseVisualStyleBackColor = false;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtPayload
            // 
            this.txtPayload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtPayload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayload.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtPayload.Location = new System.Drawing.Point(126, 92);
            this.txtPayload.Margin = new System.Windows.Forms.Padding(5);
            this.txtPayload.Multiline = true;
            this.txtPayload.Name = "txtPayload";
            this.txtPayload.ReadOnly = true;
            this.txtPayload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPayload.Size = new System.Drawing.Size(710, 431);
            this.txtPayload.TabIndex = 13;
            this.txtPayload.WordWrap = false;
            // 
            // frmGetManufacturingInfo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.lblDatabaseType);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.txtPayload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGetManufacturingInfo";
            this.Text = "Order Info Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatabaseType;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtPayload;
    }

}