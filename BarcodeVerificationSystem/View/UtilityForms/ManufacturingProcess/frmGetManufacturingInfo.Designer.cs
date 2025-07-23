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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetManufacturingInfo));
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.txtOrderId = new DesignUI.CuzUI.CuzTextBox();
            this.btnGetInfo = new DesignUI.CuzUI.CuzButton();
            this.btnAction = new DesignUI.CuzUI.CuzButton();
            this.SuspendLayout();
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatabaseType.Location = new System.Drawing.Point(44, 44);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(75, 25);
            this.lblDatabaseType.TabIndex = 17;
            this.lblDatabaseType.Text = "Order ID: ";
            // 
            // txtPayload
            // 
            this.txtPayload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
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
            this.txtOrderId.Location = new System.Drawing.Point(126, 34);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderId.Multiline = false;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtOrderId.PasswordChar = false;
            this.txtOrderId.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOrderId.PlaceholderText = "";
            this.txtOrderId.ReadOnly = false;
            this.txtOrderId.Size = new System.Drawing.Size(408, 35);
            this.txtOrderId.TabIndex = 122;
            this.txtOrderId.UnderlinedStyle = false;
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
            this.btnGetInfo.Location = new System.Drawing.Point(556, 27);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(130, 42);
            this.btnGetInfo.TabIndex = 123;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.TextColor = System.Drawing.Color.White;
            this.btnGetInfo.UseVisualStyleBackColor = false;
            // 
            // btnAction
            // 
            this.btnAction._BorderColor = System.Drawing.Color.Silver;
            this.btnAction._BorderRadius = 15;
            this.btnAction._BorderSize = 0;
            this.btnAction._GradientsButton = false;
            this.btnAction._Text = "Generate Code";
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAction.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAction.FillColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnAction.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(707, 27);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(130, 42);
            this.btnAction.TabIndex = 124;
            this.btnAction.Text = "Generate Code";
            this.btnAction.TextColor = System.Drawing.Color.White;
            this.btnAction.UseVisualStyleBackColor = false;
            // 
            // frmGetManufacturingInfo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(875, 550);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblDatabaseType);
            this.Controls.Add(this.txtPayload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetManufacturingInfo";
            this.Text = "Getting Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatabaseType;
        private System.Windows.Forms.TextBox txtPayload;
        private DesignUI.CuzUI.CuzTextBox txtOrderId;
        private DesignUI.CuzUI.CuzButton btnGetInfo;
        private DesignUI.CuzUI.CuzButton btnAction;
    }

}