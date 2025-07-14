namespace BarcodeVerificationSystem.View
{
    partial class UcCameraSettings
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
            this.grbCamera = new System.Windows.Forms.GroupBox();
            this.PositionPanel = new System.Windows.Forms.GroupBox();
            this.EnablePosition = new System.Windows.Forms.CheckBox();
            this.radioBarcodePosition = new System.Windows.Forms.RadioButton();
            this.radioLogoPosition = new System.Windows.Forms.RadioButton();
            this.labelImageResolution = new System.Windows.Forms.Label();
            this.comboBoxImageResolution = new System.Windows.Forms.ComboBox();
            this.txtSlaveIPAddress = new IPAddressControlLib.IPAddressControl();
            this.lblSlaveIp = new System.Windows.Forms.Label();
            this.lblModeRead = new System.Windows.Forms.Label();
            this.comboBox_ModeReadCamera = new System.Windows.Forms.ComboBox();
            this.groupBoxOCR = new System.Windows.Forms.GroupBox();
            this.OutputTypePanel = new System.Windows.Forms.Panel();
            this.CommandErrorBox = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.OutputCameraBox = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomCommandPanel = new System.Windows.Forms.Panel();
            this.CustomCommandCheckBox = new System.Windows.Forms.CheckBox();
            this.IndexCheckBox = new System.Windows.Forms.CheckBox();
            this.labelCommandError = new System.Windows.Forms.Label();
            this.textBoxCommandError = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelObjectSym = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonTextSlave = new System.Windows.Forms.RadioButton();
            this.radioButtonSymSlave = new System.Windows.Forms.RadioButton();
            this.labelMasterJobName = new System.Windows.Forms.Label();
            this.textBoxObjectNameSlave = new System.Windows.Forms.TextBox();
            this.labelObjectNameSlave = new System.Windows.Forms.Label();
            this.labelSlaveJobName = new System.Windows.Forms.Label();
            this.textBoxSlaveJobName = new System.Windows.Forms.TextBox();
            this.textBoxMasterJobName = new System.Windows.Forms.TextBox();
            this.radioButtonTextMaster = new System.Windows.Forms.RadioButton();
            this.radioButtonSymMaster = new System.Windows.Forms.RadioButton();
            this.textBoxObjectNameMaster = new System.Windows.Forms.TextBox();
            this.labelObjectNameMaster = new System.Windows.Forms.Label();
            this.labelCamType = new System.Windows.Forms.Label();
            this.comboBoxCamType = new System.Windows.Forms.ComboBox();
            this.txtIPAddress = new IPAddressControlLib.IPAddressControl();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.itemsPerHour = new System.Windows.Forms.CheckBox();
            this.grbCamera.SuspendLayout();
            this.PositionPanel.SuspendLayout();
            this.groupBoxOCR.SuspendLayout();
            this.OutputTypePanel.SuspendLayout();
            this.CustomCommandPanel.SuspendLayout();
            this.tableLayoutPanelObjectSym.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCamera
            // 
            this.grbCamera.BackColor = System.Drawing.Color.White;
            this.grbCamera.Controls.Add(this.itemsPerHour);
            this.grbCamera.Controls.Add(this.PositionPanel);
            this.grbCamera.Controls.Add(this.labelImageResolution);
            this.grbCamera.Controls.Add(this.comboBoxImageResolution);
            this.grbCamera.Controls.Add(this.txtSlaveIPAddress);
            this.grbCamera.Controls.Add(this.lblSlaveIp);
            this.grbCamera.Controls.Add(this.lblModeRead);
            this.grbCamera.Controls.Add(this.comboBox_ModeReadCamera);
            this.grbCamera.Controls.Add(this.groupBoxOCR);
            this.grbCamera.Controls.Add(this.labelCamType);
            this.grbCamera.Controls.Add(this.comboBoxCamType);
            this.grbCamera.Controls.Add(this.txtIPAddress);
            this.grbCamera.Controls.Add(this.lblSerialNumber);
            this.grbCamera.Controls.Add(this.txtSerialNumber);
            this.grbCamera.Controls.Add(this.lblIPAddress);
            this.grbCamera.Controls.Add(this.lblModel);
            this.grbCamera.Controls.Add(this.txtModel);
            this.grbCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCamera.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.grbCamera.Location = new System.Drawing.Point(0, 0);
            this.grbCamera.Name = "grbCamera";
            this.grbCamera.Size = new System.Drawing.Size(990, 500);
            this.grbCamera.TabIndex = 18;
            this.grbCamera.TabStop = false;
            this.grbCamera.Text = "Camera";
            this.grbCamera.Enter += new System.EventHandler(this.grbCamera_Enter);
            // 
            // PositionPanel
            // 
            this.PositionPanel.Controls.Add(this.EnablePosition);
            this.PositionPanel.Controls.Add(this.radioBarcodePosition);
            this.PositionPanel.Controls.Add(this.radioLogoPosition);
            this.PositionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionPanel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PositionPanel.Location = new System.Drawing.Point(22, 142);
            this.PositionPanel.Name = "PositionPanel";
            this.PositionPanel.Size = new System.Drawing.Size(628, 97);
            this.PositionPanel.TabIndex = 79;
            this.PositionPanel.TabStop = false;
            this.PositionPanel.Text = "Position Settings";
            // 
            // EnablePosition
            // 
            this.EnablePosition.AutoSize = true;
            this.EnablePosition.Location = new System.Drawing.Point(15, 27);
            this.EnablePosition.Name = "EnablePosition";
            this.EnablePosition.Size = new System.Drawing.Size(153, 24);
            this.EnablePosition.TabIndex = 77;
            this.EnablePosition.Text = "Enable Position";
            this.EnablePosition.UseVisualStyleBackColor = true;
            // 
            // radioBarcodePosition
            // 
            this.radioBarcodePosition.AutoSize = true;
            this.radioBarcodePosition.Location = new System.Drawing.Point(249, 27);
            this.radioBarcodePosition.Name = "radioBarcodePosition";
            this.radioBarcodePosition.Size = new System.Drawing.Size(163, 24);
            this.radioBarcodePosition.TabIndex = 75;
            this.radioBarcodePosition.TabStop = true;
            this.radioBarcodePosition.Text = "Barcode Position";
            this.radioBarcodePosition.UseVisualStyleBackColor = true;
            // 
            // radioLogoPosition
            // 
            this.radioLogoPosition.AutoSize = true;
            this.radioLogoPosition.Location = new System.Drawing.Point(249, 61);
            this.radioLogoPosition.Name = "radioLogoPosition";
            this.radioLogoPosition.Size = new System.Drawing.Size(136, 24);
            this.radioLogoPosition.TabIndex = 76;
            this.radioLogoPosition.TabStop = true;
            this.radioLogoPosition.Text = "Logo Position";
            this.radioLogoPosition.UseVisualStyleBackColor = true;
            // 
            // labelImageResolution
            // 
            this.labelImageResolution.AutoSize = true;
            this.labelImageResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageResolution.Location = new System.Drawing.Point(671, 142);
            this.labelImageResolution.Name = "labelImageResolution";
            this.labelImageResolution.Size = new System.Drawing.Size(134, 20);
            this.labelImageResolution.TabIndex = 51;
            this.labelImageResolution.Text = "Image Resolution";
            // 
            // comboBoxImageResolution
            // 
            this.comboBoxImageResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxImageResolution.FormattingEnabled = true;
            this.comboBoxImageResolution.Items.AddRange(new object[] {
            "240*160",
            "320*240",
            "480*360"});
            this.comboBoxImageResolution.Location = new System.Drawing.Point(675, 169);
            this.comboBoxImageResolution.Name = "comboBoxImageResolution";
            this.comboBoxImageResolution.Size = new System.Drawing.Size(304, 28);
            this.comboBoxImageResolution.TabIndex = 50;
            // 
            // txtSlaveIPAddress
            // 
            this.txtSlaveIPAddress.AllowInternalTab = false;
            this.txtSlaveIPAddress.AutoHeight = true;
            this.txtSlaveIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtSlaveIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSlaveIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSlaveIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlaveIPAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSlaveIPAddress.Location = new System.Drawing.Point(21, 169);
            this.txtSlaveIPAddress.MinimumSize = new System.Drawing.Size(126, 26);
            this.txtSlaveIPAddress.Name = "txtSlaveIPAddress";
            this.txtSlaveIPAddress.ReadOnly = false;
            this.txtSlaveIPAddress.Size = new System.Drawing.Size(302, 26);
            this.txtSlaveIPAddress.TabIndex = 49;
            this.txtSlaveIPAddress.Text = "...";
            // 
            // lblSlaveIp
            // 
            this.lblSlaveIp.AutoSize = true;
            this.lblSlaveIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlaveIp.Location = new System.Drawing.Point(18, 142);
            this.lblSlaveIp.Name = "lblSlaveIp";
            this.lblSlaveIp.Size = new System.Drawing.Size(130, 20);
            this.lblSlaveIp.TabIndex = 48;
            this.lblSlaveIp.Text = "Slave IP Address";
            // 
            // lblModeRead
            // 
            this.lblModeRead.AutoSize = true;
            this.lblModeRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeRead.Location = new System.Drawing.Point(342, 142);
            this.lblModeRead.Name = "lblModeRead";
            this.lblModeRead.Size = new System.Drawing.Size(92, 20);
            this.lblModeRead.TabIndex = 47;
            this.lblModeRead.Text = "Mode Read";
            // 
            // comboBox_ModeReadCamera
            // 
            this.comboBox_ModeReadCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ModeReadCamera.FormattingEnabled = true;
            this.comboBox_ModeReadCamera.Items.AddRange(new object[] {
            "Basic Read (Image+Code)",
            "Multi-Sync Read with TCP/IP (Code)"});
            this.comboBox_ModeReadCamera.Location = new System.Drawing.Point(346, 169);
            this.comboBox_ModeReadCamera.Name = "comboBox_ModeReadCamera";
            this.comboBox_ModeReadCamera.Size = new System.Drawing.Size(304, 28);
            this.comboBox_ModeReadCamera.TabIndex = 46;
            // 
            // groupBoxOCR
            // 
            this.groupBoxOCR.Controls.Add(this.OutputTypePanel);
            this.groupBoxOCR.Controls.Add(this.CustomCommandPanel);
            this.groupBoxOCR.Controls.Add(this.tableLayoutPanelObjectSym);
            this.groupBoxOCR.Controls.Add(this.labelMasterJobName);
            this.groupBoxOCR.Controls.Add(this.textBoxObjectNameSlave);
            this.groupBoxOCR.Controls.Add(this.labelObjectNameSlave);
            this.groupBoxOCR.Controls.Add(this.labelSlaveJobName);
            this.groupBoxOCR.Controls.Add(this.textBoxSlaveJobName);
            this.groupBoxOCR.Controls.Add(this.textBoxMasterJobName);
            this.groupBoxOCR.Controls.Add(this.radioButtonTextMaster);
            this.groupBoxOCR.Controls.Add(this.radioButtonSymMaster);
            this.groupBoxOCR.Controls.Add(this.textBoxObjectNameMaster);
            this.groupBoxOCR.Controls.Add(this.labelObjectNameMaster);
            this.groupBoxOCR.Location = new System.Drawing.Point(21, 245);
            this.groupBoxOCR.Name = "groupBoxOCR";
            this.groupBoxOCR.Size = new System.Drawing.Size(969, 249);
            this.groupBoxOCR.TabIndex = 45;
            this.groupBoxOCR.TabStop = false;
            this.groupBoxOCR.Text = "OCR Settings";
            // 
            // OutputTypePanel
            // 
            this.OutputTypePanel.Controls.Add(this.CommandErrorBox);
            this.OutputTypePanel.Controls.Add(this.flowLayoutPanel1);
            this.OutputTypePanel.Controls.Add(this.OutputCameraBox);
            this.OutputTypePanel.Controls.Add(this.label4);
            this.OutputTypePanel.Location = new System.Drawing.Point(16, 181);
            this.OutputTypePanel.Name = "OutputTypePanel";
            this.OutputTypePanel.Size = new System.Drawing.Size(311, 40);
            this.OutputTypePanel.TabIndex = 71;
            // 
            // CommandErrorBox
            // 
            this.CommandErrorBox.AutoSize = true;
            this.CommandErrorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandErrorBox.Location = new System.Drawing.Point(236, 8);
            this.CommandErrorBox.Name = "CommandErrorBox";
            this.CommandErrorBox.Size = new System.Drawing.Size(57, 24);
            this.CommandErrorBox.TabIndex = 77;
            this.CommandErrorBox.TabStop = true;
            this.CommandErrorBox.Text = "PLC";
            this.CommandErrorBox.UseVisualStyleBackColor = true;
            this.CommandErrorBox.CheckedChanged += new System.EventHandler(this.CommandErrorBox_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // OutputCameraBox
            // 
            this.OutputCameraBox.AutoSize = true;
            this.OutputCameraBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputCameraBox.Location = new System.Drawing.Point(127, 8);
            this.OutputCameraBox.Name = "OutputCameraBox";
            this.OutputCameraBox.Size = new System.Drawing.Size(87, 24);
            this.OutputCameraBox.TabIndex = 76;
            this.OutputCameraBox.TabStop = true;
            this.OutputCameraBox.Text = "Camera ";
            this.OutputCameraBox.UseVisualStyleBackColor = true;
            this.OutputCameraBox.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 72;
            this.label4.Text = "Output Type:";
            // 
            // CustomCommandPanel
            // 
            this.CustomCommandPanel.Controls.Add(this.CustomCommandCheckBox);
            this.CustomCommandPanel.Controls.Add(this.IndexCheckBox);
            this.CustomCommandPanel.Controls.Add(this.labelCommandError);
            this.CustomCommandPanel.Controls.Add(this.textBoxCommandError);
            this.CustomCommandPanel.Location = new System.Drawing.Point(313, 164);
            this.CustomCommandPanel.Name = "CustomCommandPanel";
            this.CustomCommandPanel.Size = new System.Drawing.Size(653, 74);
            this.CustomCommandPanel.TabIndex = 71;
            // 
            // CustomCommandCheckBox
            // 
            this.CustomCommandCheckBox.AutoSize = true;
            this.CustomCommandCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomCommandCheckBox.Location = new System.Drawing.Point(19, 6);
            this.CustomCommandCheckBox.Name = "CustomCommandCheckBox";
            this.CustomCommandCheckBox.Size = new System.Drawing.Size(174, 24);
            this.CustomCommandCheckBox.TabIndex = 69;
            this.CustomCommandCheckBox.Text = "Custom Command";
            this.CustomCommandCheckBox.UseVisualStyleBackColor = true;
            this.CustomCommandCheckBox.CheckedChanged += new System.EventHandler(this.CustomCommandCheckBox_CheckedChanged);
            // 
            // IndexCheckBox
            // 
            this.IndexCheckBox.AutoSize = true;
            this.IndexCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexCheckBox.Location = new System.Drawing.Point(199, 6);
            this.IndexCheckBox.Name = "IndexCheckBox";
            this.IndexCheckBox.Size = new System.Drawing.Size(202, 24);
            this.IndexCheckBox.TabIndex = 70;
            this.IndexCheckBox.Text = "Index After Command";
            this.IndexCheckBox.UseVisualStyleBackColor = true;
            this.IndexCheckBox.CheckedChanged += new System.EventHandler(this.IndexCheckBox_CheckedChanged);
            // 
            // labelCommandError
            // 
            this.labelCommandError.AutoSize = true;
            this.labelCommandError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommandError.Location = new System.Drawing.Point(15, 47);
            this.labelCommandError.Name = "labelCommandError";
            this.labelCommandError.Size = new System.Drawing.Size(121, 20);
            this.labelCommandError.TabIndex = 67;
            this.labelCommandError.Text = "Command Error";
            // 
            // textBoxCommandError
            // 
            this.textBoxCommandError.Enabled = false;
            this.textBoxCommandError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommandError.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxCommandError.Location = new System.Drawing.Point(146, 44);
            this.textBoxCommandError.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCommandError.Name = "textBoxCommandError";
            this.textBoxCommandError.Size = new System.Drawing.Size(499, 26);
            this.textBoxCommandError.TabIndex = 66;
            this.textBoxCommandError.TextChanged += new System.EventHandler(this.textBoxCommandError_TextChanged);
            // 
            // tableLayoutPanelObjectSym
            // 
            this.tableLayoutPanelObjectSym.ColumnCount = 1;
            this.tableLayoutPanelObjectSym.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelObjectSym.Controls.Add(this.radioButtonTextSlave, 0, 1);
            this.tableLayoutPanelObjectSym.Controls.Add(this.radioButtonSymSlave, 0, 0);
            this.tableLayoutPanelObjectSym.Location = new System.Drawing.Point(225, 95);
            this.tableLayoutPanelObjectSym.Name = "tableLayoutPanelObjectSym";
            this.tableLayoutPanelObjectSym.RowCount = 2;
            this.tableLayoutPanelObjectSym.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelObjectSym.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelObjectSym.Size = new System.Drawing.Size(158, 63);
            this.tableLayoutPanelObjectSym.TabIndex = 0;
            // 
            // radioButtonTextSlave
            // 
            this.radioButtonTextSlave.AutoSize = true;
            this.radioButtonTextSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTextSlave.Location = new System.Drawing.Point(3, 31);
            this.radioButtonTextSlave.Name = "radioButtonTextSlave";
            this.radioButtonTextSlave.Size = new System.Drawing.Size(100, 24);
            this.radioButtonTextSlave.TabIndex = 63;
            this.radioButtonTextSlave.TabStop = true;
            this.radioButtonTextSlave.Text = "Text Read";
            this.radioButtonTextSlave.UseVisualStyleBackColor = true;
            // 
            // radioButtonSymSlave
            // 
            this.radioButtonSymSlave.AutoSize = true;
            this.radioButtonSymSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSymSlave.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSymSlave.Name = "radioButtonSymSlave";
            this.radioButtonSymSlave.Size = new System.Drawing.Size(122, 22);
            this.radioButtonSymSlave.TabIndex = 62;
            this.radioButtonSymSlave.TabStop = true;
            this.radioButtonSymSlave.Text = "Symbol Read";
            this.radioButtonSymSlave.UseVisualStyleBackColor = true;
            // 
            // labelMasterJobName
            // 
            this.labelMasterJobName.AutoSize = true;
            this.labelMasterJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMasterJobName.Location = new System.Drawing.Point(534, 37);
            this.labelMasterJobName.Name = "labelMasterJobName";
            this.labelMasterJobName.Size = new System.Drawing.Size(64, 20);
            this.labelMasterJobName.TabIndex = 65;
            this.labelMasterJobName.Text = "Master";
            // 
            // textBoxObjectNameSlave
            // 
            this.textBoxObjectNameSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObjectNameSlave.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxObjectNameSlave.Location = new System.Drawing.Point(225, 64);
            this.textBoxObjectNameSlave.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxObjectNameSlave.Name = "textBoxObjectNameSlave";
            this.textBoxObjectNameSlave.Size = new System.Drawing.Size(204, 26);
            this.textBoxObjectNameSlave.TabIndex = 64;
            // 
            // labelObjectNameSlave
            // 
            this.labelObjectNameSlave.AutoSize = true;
            this.labelObjectNameSlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObjectNameSlave.Location = new System.Drawing.Point(221, 42);
            this.labelObjectNameSlave.Name = "labelObjectNameSlave";
            this.labelObjectNameSlave.Size = new System.Drawing.Size(173, 20);
            this.labelObjectNameSlave.TabIndex = 61;
            this.labelObjectNameSlave.Text = "Object Name (Slave)";
            // 
            // labelSlaveJobName
            // 
            this.labelSlaveJobName.AutoSize = true;
            this.labelSlaveJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSlaveJobName.Location = new System.Drawing.Point(534, 96);
            this.labelSlaveJobName.Name = "labelSlaveJobName";
            this.labelSlaveJobName.Size = new System.Drawing.Size(53, 20);
            this.labelSlaveJobName.TabIndex = 60;
            this.labelSlaveJobName.Text = "Slave";
            // 
            // textBoxSlaveJobName
            // 
            this.textBoxSlaveJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSlaveJobName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxSlaveJobName.Location = new System.Drawing.Point(538, 121);
            this.textBoxSlaveJobName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSlaveJobName.Name = "textBoxSlaveJobName";
            this.textBoxSlaveJobName.Size = new System.Drawing.Size(204, 26);
            this.textBoxSlaveJobName.TabIndex = 59;
            // 
            // textBoxMasterJobName
            // 
            this.textBoxMasterJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMasterJobName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxMasterJobName.Location = new System.Drawing.Point(538, 64);
            this.textBoxMasterJobName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMasterJobName.Name = "textBoxMasterJobName";
            this.textBoxMasterJobName.Size = new System.Drawing.Size(204, 26);
            this.textBoxMasterJobName.TabIndex = 58;
            // 
            // radioButtonTextMaster
            // 
            this.radioButtonTextMaster.AutoSize = true;
            this.radioButtonTextMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTextMaster.Location = new System.Drawing.Point(16, 123);
            this.radioButtonTextMaster.Name = "radioButtonTextMaster";
            this.radioButtonTextMaster.Size = new System.Drawing.Size(100, 24);
            this.radioButtonTextMaster.TabIndex = 52;
            this.radioButtonTextMaster.TabStop = true;
            this.radioButtonTextMaster.Text = "Text Read";
            this.radioButtonTextMaster.UseVisualStyleBackColor = true;
            // 
            // radioButtonSymMaster
            // 
            this.radioButtonSymMaster.AutoSize = true;
            this.radioButtonSymMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSymMaster.Location = new System.Drawing.Point(16, 95);
            this.radioButtonSymMaster.Name = "radioButtonSymMaster";
            this.radioButtonSymMaster.Size = new System.Drawing.Size(122, 24);
            this.radioButtonSymMaster.TabIndex = 51;
            this.radioButtonSymMaster.TabStop = true;
            this.radioButtonSymMaster.Text = "Symbol Read";
            this.radioButtonSymMaster.UseVisualStyleBackColor = true;
            // 
            // textBoxObjectNameMaster
            // 
            this.textBoxObjectNameMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObjectNameMaster.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxObjectNameMaster.Location = new System.Drawing.Point(16, 64);
            this.textBoxObjectNameMaster.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxObjectNameMaster.Name = "textBoxObjectNameMaster";
            this.textBoxObjectNameMaster.Size = new System.Drawing.Size(204, 26);
            this.textBoxObjectNameMaster.TabIndex = 56;
            // 
            // labelObjectNameMaster
            // 
            this.labelObjectNameMaster.AutoSize = true;
            this.labelObjectNameMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObjectNameMaster.Location = new System.Drawing.Point(12, 42);
            this.labelObjectNameMaster.Name = "labelObjectNameMaster";
            this.labelObjectNameMaster.Size = new System.Drawing.Size(184, 20);
            this.labelObjectNameMaster.TabIndex = 48;
            this.labelObjectNameMaster.Text = "Object Name (Master)";
            // 
            // labelCamType
            // 
            this.labelCamType.AutoSize = true;
            this.labelCamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCamType.Location = new System.Drawing.Point(18, 33);
            this.labelCamType.Name = "labelCamType";
            this.labelCamType.Size = new System.Drawing.Size(43, 20);
            this.labelCamType.TabIndex = 38;
            this.labelCamType.Text = "Type";
            // 
            // comboBoxCamType
            // 
            this.comboBoxCamType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCamType.FormattingEnabled = true;
            this.comboBoxCamType.Items.AddRange(new object[] {
            "DM Series",
            "IS Series",
            "IS Series Dual"});
            this.comboBoxCamType.Location = new System.Drawing.Point(67, 30);
            this.comboBoxCamType.Name = "comboBoxCamType";
            this.comboBoxCamType.Size = new System.Drawing.Size(138, 28);
            this.comboBoxCamType.TabIndex = 37;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.AllowInternalTab = false;
            this.txtIPAddress.AutoHeight = true;
            this.txtIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIPAddress.Location = new System.Drawing.Point(21, 101);
            this.txtIPAddress.MinimumSize = new System.Drawing.Size(126, 26);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.ReadOnly = false;
            this.txtIPAddress.Size = new System.Drawing.Size(302, 26);
            this.txtIPAddress.TabIndex = 32;
            this.txtIPAddress.Text = "...";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(342, 75);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(107, 20);
            this.lblSerialNumber.TabIndex = 23;
            this.lblSerialNumber.Text = "Serial number";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNumber.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSerialNumber.Location = new System.Drawing.Point(346, 101);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(304, 26);
            this.txtSerialNumber.TabIndex = 24;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.Location = new System.Drawing.Point(18, 75);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(87, 20);
            this.lblIPAddress.TabIndex = 21;
            this.lblIPAddress.Text = "IP Address";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(672, 75);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(52, 20);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Model";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtModel.Location = new System.Drawing.Point(675, 101);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(302, 26);
            this.txtModel.TabIndex = 19;
            // 
            // itemsPerHour
            // 
            this.itemsPerHour.AutoSize = true;
            this.itemsPerHour.Location = new System.Drawing.Point(675, 29);
            this.itemsPerHour.Name = "itemsPerHour";
            this.itemsPerHour.Size = new System.Drawing.Size(212, 24);
            this.itemsPerHour.TabIndex = 80;
            this.itemsPerHour.Text = "Items Per Hour Display";
            this.itemsPerHour.UseVisualStyleBackColor = true;
            // 
            // UcCameraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbCamera);
            this.Name = "UcCameraSettings";
            this.Size = new System.Drawing.Size(990, 500);
            this.grbCamera.ResumeLayout(false);
            this.grbCamera.PerformLayout();
            this.PositionPanel.ResumeLayout(false);
            this.PositionPanel.PerformLayout();
            this.groupBoxOCR.ResumeLayout(false);
            this.groupBoxOCR.PerformLayout();
            this.OutputTypePanel.ResumeLayout(false);
            this.OutputTypePanel.PerformLayout();
            this.CustomCommandPanel.ResumeLayout(false);
            this.CustomCommandPanel.PerformLayout();
            this.tableLayoutPanelObjectSym.ResumeLayout(false);
            this.tableLayoutPanelObjectSym.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCamera;
        private IPAddressControlLib.IPAddressControl txtIPAddress;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label labelCamType;
        private System.Windows.Forms.ComboBox comboBoxCamType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblModeRead;
        private System.Windows.Forms.ComboBox comboBox_ModeReadCamera;
        private IPAddressControlLib.IPAddressControl txtSlaveIPAddress;
        private System.Windows.Forms.Label lblSlaveIp;
        private System.Windows.Forms.Label labelImageResolution;
        private System.Windows.Forms.ComboBox comboBoxImageResolution;
        private System.Windows.Forms.GroupBox groupBoxOCR;
        private System.Windows.Forms.CheckBox CustomCommandCheckBox;
        private System.Windows.Forms.Label labelCommandError;
        private System.Windows.Forms.TextBox textBoxCommandError;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelObjectSym;
        private System.Windows.Forms.RadioButton radioButtonTextSlave;
        private System.Windows.Forms.RadioButton radioButtonSymSlave;
        private System.Windows.Forms.Label labelMasterJobName;
        private System.Windows.Forms.TextBox textBoxObjectNameSlave;
        private System.Windows.Forms.Label labelObjectNameSlave;
        private System.Windows.Forms.Label labelSlaveJobName;
        private System.Windows.Forms.TextBox textBoxSlaveJobName;
        private System.Windows.Forms.TextBox textBoxMasterJobName;
        private System.Windows.Forms.RadioButton radioButtonTextMaster;
        private System.Windows.Forms.RadioButton radioButtonSymMaster;
        private System.Windows.Forms.TextBox textBoxObjectNameMaster;
        private System.Windows.Forms.Label labelObjectNameMaster;
        private System.Windows.Forms.CheckBox IndexCheckBox;
        private System.Windows.Forms.Panel CustomCommandPanel;
        private System.Windows.Forms.RadioButton CommandErrorBox;
        private System.Windows.Forms.RadioButton OutputCameraBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel OutputTypePanel;
        private System.Windows.Forms.GroupBox PositionPanel;
        private System.Windows.Forms.CheckBox EnablePosition;
        private System.Windows.Forms.RadioButton radioBarcodePosition;
        private System.Windows.Forms.RadioButton radioLogoPosition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox itemsPerHour;
    }
}
