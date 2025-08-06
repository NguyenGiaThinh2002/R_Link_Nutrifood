namespace BarcodeVerificationSystem.View.UcSettings
{
    partial class ucProductionSetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.apiTextbox = new System.Windows.Forms.TextBox();
            this.labelApi = new System.Windows.Forms.Label();
            this.comboBoxRLinkId = new System.Windows.Forms.ComboBox();
            this.lineIdLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.radProductionModeEnable = new System.Windows.Forms.RadioButton();
            this.radProductionModeDisable = new System.Windows.Forms.RadioButton();
            this.groupBoxProductionSettings = new System.Windows.Forms.GroupBox();
            this.lineIndex = new System.Windows.Forms.Label();
            this.lineIndexTextBox = new System.Windows.Forms.TextBox();
            this.onlineProductionSettings = new System.Windows.Forms.Panel();
            this.productionMode = new System.Windows.Forms.Label();
            this.manufacturingRad = new System.Windows.Forms.RadioButton();
            this.dispatchingRad = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dataIncrease = new System.Windows.Forms.Label();
            this.numIncreasedData = new System.Windows.Forms.NumericUpDown();
            this.maskData = new System.Windows.Forms.CheckBox();
            this.dataDisplay = new System.Windows.Forms.Label();
            this.LineId = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.factoryCode = new System.Windows.Forms.TextBox();
            this.lineNameLabel = new System.Windows.Forms.Label();
            this.lineName = new System.Windows.Forms.TextBox();
            this.factoryCodeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxProductionSettings.SuspendLayout();
            this.onlineProductionSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncreasedData)).BeginInit();
            this.SuspendLayout();
            // 
            // apiTextbox
            // 
            this.apiTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.apiTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiTextbox.Location = new System.Drawing.Point(215, 106);
            this.apiTextbox.MinimumSize = new System.Drawing.Size(361, 30);
            this.apiTextbox.Name = "apiTextbox";
            this.apiTextbox.Size = new System.Drawing.Size(439, 26);
            this.apiTextbox.TabIndex = 0;
            // 
            // labelApi
            // 
            this.labelApi.AutoSize = true;
            this.labelApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApi.Location = new System.Drawing.Point(48, 109);
            this.labelApi.Name = "labelApi";
            this.labelApi.Size = new System.Drawing.Size(57, 20);
            this.labelApi.TabIndex = 39;
            this.labelApi.Text = "Api url:";
            // 
            // comboBoxRLinkId
            // 
            this.comboBoxRLinkId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRLinkId.FormattingEnabled = true;
            this.comboBoxRLinkId.Items.AddRange(new object[] {
            "R1",
            "R2",
            "R3",
            "R4"});
            this.comboBoxRLinkId.Location = new System.Drawing.Point(866, 443);
            this.comboBoxRLinkId.Name = "comboBoxRLinkId";
            this.comboBoxRLinkId.Size = new System.Drawing.Size(103, 28);
            this.comboBoxRLinkId.TabIndex = 40;
            this.comboBoxRLinkId.Visible = false;
            // 
            // lineIdLabel
            // 
            this.lineIdLabel.AutoSize = true;
            this.lineIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineIdLabel.Location = new System.Drawing.Point(48, 178);
            this.lineIdLabel.Name = "lineIdLabel";
            this.lineIdLabel.Size = new System.Drawing.Size(61, 20);
            this.lineIdLabel.TabIndex = 41;
            this.lineIdLabel.Text = "Line Id:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.radProductionModeEnable, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.radProductionModeDisable, 1, 0);
            this.tableLayoutPanel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel5.Location = new System.Drawing.Point(215, 37);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(439, 38);
            this.tableLayoutPanel5.TabIndex = 42;
            // 
            // radProductionModeEnable
            // 
            this.radProductionModeEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.radProductionModeEnable.BackColor = System.Drawing.Color.White;
            this.radProductionModeEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radProductionModeEnable.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.radProductionModeEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radProductionModeEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProductionModeEnable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.radProductionModeEnable.Location = new System.Drawing.Point(0, 0);
            this.radProductionModeEnable.Margin = new System.Windows.Forms.Padding(0);
            this.radProductionModeEnable.Name = "radProductionModeEnable";
            this.radProductionModeEnable.Size = new System.Drawing.Size(219, 38);
            this.radProductionModeEnable.TabIndex = 3;
            this.radProductionModeEnable.TabStop = true;
            this.radProductionModeEnable.Text = "Enable";
            this.radProductionModeEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radProductionModeEnable.UseVisualStyleBackColor = false;
            // 
            // radProductionModeDisable
            // 
            this.radProductionModeDisable.Appearance = System.Windows.Forms.Appearance.Button;
            this.radProductionModeDisable.BackColor = System.Drawing.Color.White;
            this.radProductionModeDisable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radProductionModeDisable.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.radProductionModeDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radProductionModeDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProductionModeDisable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.radProductionModeDisable.Location = new System.Drawing.Point(219, 0);
            this.radProductionModeDisable.Margin = new System.Windows.Forms.Padding(0);
            this.radProductionModeDisable.Name = "radProductionModeDisable";
            this.radProductionModeDisable.Size = new System.Drawing.Size(220, 38);
            this.radProductionModeDisable.TabIndex = 4;
            this.radProductionModeDisable.TabStop = true;
            this.radProductionModeDisable.Text = "Disable";
            this.radProductionModeDisable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radProductionModeDisable.UseVisualStyleBackColor = false;
            // 
            // groupBoxProductionSettings
            // 
            this.groupBoxProductionSettings.Controls.Add(this.lineIndex);
            this.groupBoxProductionSettings.Controls.Add(this.lineIndexTextBox);
            this.groupBoxProductionSettings.Controls.Add(this.onlineProductionSettings);
            this.groupBoxProductionSettings.Controls.Add(this.LineId);
            this.groupBoxProductionSettings.Controls.Add(this.progressBar1);
            this.groupBoxProductionSettings.Controls.Add(this.factoryCode);
            this.groupBoxProductionSettings.Controls.Add(this.lineNameLabel);
            this.groupBoxProductionSettings.Controls.Add(this.lineName);
            this.groupBoxProductionSettings.Controls.Add(this.factoryCodeLabel);
            this.groupBoxProductionSettings.Controls.Add(this.comboBoxRLinkId);
            this.groupBoxProductionSettings.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxProductionSettings.Controls.Add(this.lineIdLabel);
            this.groupBoxProductionSettings.Controls.Add(this.labelApi);
            this.groupBoxProductionSettings.Controls.Add(this.apiTextbox);
            this.groupBoxProductionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProductionSettings.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBoxProductionSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxProductionSettings.Name = "groupBoxProductionSettings";
            this.groupBoxProductionSettings.Size = new System.Drawing.Size(984, 494);
            this.groupBoxProductionSettings.TabIndex = 50;
            this.groupBoxProductionSettings.TabStop = false;
            this.groupBoxProductionSettings.Text = "Production Settings";
            // 
            // lineIndex
            // 
            this.lineIndex.AutoSize = true;
            this.lineIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineIndex.Location = new System.Drawing.Point(48, 376);
            this.lineIndex.Name = "lineIndex";
            this.lineIndex.Size = new System.Drawing.Size(86, 20);
            this.lineIndex.TabIndex = 79;
            this.lineIndex.Text = "Line Index:";
            // 
            // lineIndexTextBox
            // 
            this.lineIndexTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lineIndexTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineIndexTextBox.Location = new System.Drawing.Point(215, 370);
            this.lineIndexTextBox.Name = "lineIndexTextBox";
            this.lineIndexTextBox.Size = new System.Drawing.Size(103, 26);
            this.lineIndexTextBox.TabIndex = 78;
            // 
            // onlineProductionSettings
            // 
            this.onlineProductionSettings.Controls.Add(this.productionMode);
            this.onlineProductionSettings.Controls.Add(this.manufacturingRad);
            this.onlineProductionSettings.Controls.Add(this.dispatchingRad);
            this.onlineProductionSettings.Controls.Add(this.label2);
            this.onlineProductionSettings.Controls.Add(this.dataIncrease);
            this.onlineProductionSettings.Controls.Add(this.numIncreasedData);
            this.onlineProductionSettings.Controls.Add(this.maskData);
            this.onlineProductionSettings.Controls.Add(this.dataDisplay);
            this.onlineProductionSettings.Location = new System.Drawing.Point(460, 138);
            this.onlineProductionSettings.Name = "onlineProductionSettings";
            this.onlineProductionSettings.Size = new System.Drawing.Size(509, 240);
            this.onlineProductionSettings.TabIndex = 51;
            this.onlineProductionSettings.Visible = false;
            // 
            // productionMode
            // 
            this.productionMode.AutoSize = true;
            this.productionMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionMode.Location = new System.Drawing.Point(22, 40);
            this.productionMode.Name = "productionMode";
            this.productionMode.Size = new System.Drawing.Size(133, 20);
            this.productionMode.TabIndex = 43;
            this.productionMode.Text = "Production Mode:";
            // 
            // manufacturingRad
            // 
            this.manufacturingRad.AutoSize = true;
            this.manufacturingRad.Location = new System.Drawing.Point(198, 36);
            this.manufacturingRad.Name = "manufacturingRad";
            this.manufacturingRad.Size = new System.Drawing.Size(142, 24);
            this.manufacturingRad.TabIndex = 44;
            this.manufacturingRad.TabStop = true;
            this.manufacturingRad.Text = "Manufacturing";
            this.manufacturingRad.UseVisualStyleBackColor = true;
            // 
            // dispatchingRad
            // 
            this.dispatchingRad.AutoSize = true;
            this.dispatchingRad.Location = new System.Drawing.Point(360, 36);
            this.dispatchingRad.Name = "dispatchingRad";
            this.dispatchingRad.Size = new System.Drawing.Size(122, 24);
            this.dispatchingRad.TabIndex = 45;
            this.dispatchingRad.TabStop = true;
            this.dispatchingRad.Text = "Dispatching";
            this.dispatchingRad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "%";
            // 
            // dataIncrease
            // 
            this.dataIncrease.AutoSize = true;
            this.dataIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataIncrease.Location = new System.Drawing.Point(22, 168);
            this.dataIncrease.Name = "dataIncrease";
            this.dataIncrease.Size = new System.Drawing.Size(141, 20);
            this.dataIncrease.TabIndex = 46;
            this.dataIncrease.Text = "Data increased by:";
            // 
            // numIncreasedData
            // 
            this.numIncreasedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIncreasedData.Location = new System.Drawing.Point(198, 163);
            this.numIncreasedData.Name = "numIncreasedData";
            this.numIncreasedData.Size = new System.Drawing.Size(103, 26);
            this.numIncreasedData.TabIndex = 48;
            // 
            // maskData
            // 
            this.maskData.AutoSize = true;
            this.maskData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskData.Location = new System.Drawing.Point(198, 97);
            this.maskData.Name = "maskData";
            this.maskData.Size = new System.Drawing.Size(198, 24);
            this.maskData.TabIndex = 70;
            this.maskData.Text = "Partially Mask Values";
            this.maskData.UseVisualStyleBackColor = true;
            // 
            // dataDisplay
            // 
            this.dataDisplay.AutoSize = true;
            this.dataDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDisplay.Location = new System.Drawing.Point(22, 101);
            this.dataDisplay.Name = "dataDisplay";
            this.dataDisplay.Size = new System.Drawing.Size(100, 20);
            this.dataDisplay.TabIndex = 71;
            this.dataDisplay.Text = "Data display:";
            this.dataDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineId
            // 
            this.LineId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LineId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineId.Location = new System.Drawing.Point(215, 171);
            this.LineId.Name = "LineId";
            this.LineId.Size = new System.Drawing.Size(103, 26);
            this.LineId.TabIndex = 77;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(433, 136);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1, 355);
            this.progressBar1.TabIndex = 76;
            this.progressBar1.Visible = false;
            // 
            // factoryCode
            // 
            this.factoryCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.factoryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factoryCode.Location = new System.Drawing.Point(215, 304);
            this.factoryCode.Name = "factoryCode";
            this.factoryCode.Size = new System.Drawing.Size(103, 26);
            this.factoryCode.TabIndex = 75;
            // 
            // lineNameLabel
            // 
            this.lineNameLabel.AutoSize = true;
            this.lineNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineNameLabel.Location = new System.Drawing.Point(48, 242);
            this.lineNameLabel.Name = "lineNameLabel";
            this.lineNameLabel.Size = new System.Drawing.Size(89, 20);
            this.lineNameLabel.TabIndex = 74;
            this.lineNameLabel.Text = "Line Name:";
            // 
            // lineName
            // 
            this.lineName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineName.Location = new System.Drawing.Point(215, 236);
            this.lineName.Name = "lineName";
            this.lineName.Size = new System.Drawing.Size(103, 26);
            this.lineName.TabIndex = 73;
            // 
            // factoryCodeLabel
            // 
            this.factoryCodeLabel.AutoSize = true;
            this.factoryCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factoryCodeLabel.Location = new System.Drawing.Point(48, 307);
            this.factoryCodeLabel.Name = "factoryCodeLabel";
            this.factoryCodeLabel.Size = new System.Drawing.Size(108, 20);
            this.factoryCodeLabel.TabIndex = 72;
            this.factoryCodeLabel.Text = "Factory Code:";
            // 
            // ucProductionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxProductionSettings);
            this.Name = "ucProductionSetting";
            this.Size = new System.Drawing.Size(990, 500);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxProductionSettings.ResumeLayout(false);
            this.groupBoxProductionSettings.PerformLayout();
            this.onlineProductionSettings.ResumeLayout(false);
            this.onlineProductionSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncreasedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox apiTextbox;
        private System.Windows.Forms.Label labelApi;
        private System.Windows.Forms.ComboBox comboBoxRLinkId;
        private System.Windows.Forms.Label lineIdLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton radProductionModeEnable;
        private System.Windows.Forms.RadioButton radProductionModeDisable;
        private System.Windows.Forms.GroupBox groupBoxProductionSettings;
        private System.Windows.Forms.RadioButton dispatchingRad;
        private System.Windows.Forms.RadioButton manufacturingRad;
        private System.Windows.Forms.Label productionMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dataIncrease;
        private System.Windows.Forms.NumericUpDown numIncreasedData;
        private System.Windows.Forms.Label dataDisplay;
        private System.Windows.Forms.CheckBox maskData;
        private System.Windows.Forms.TextBox factoryCode;
        private System.Windows.Forms.Label lineNameLabel;
        private System.Windows.Forms.TextBox lineName;
        private System.Windows.Forms.Label factoryCodeLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox LineId;
        private System.Windows.Forms.Panel onlineProductionSettings;
        private System.Windows.Forms.TextBox lineIndexTextBox;
        private System.Windows.Forms.Label lineIndex;
    }
}
