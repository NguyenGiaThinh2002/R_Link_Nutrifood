using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UILanguage;

namespace BarcodeVerificationSystem.View
{
    public partial class UcCameraSettings : UserControl
    {
        private CameraModel _CameraModel;
        private int _Index = 0;
        private bool _firstLoad = false;
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                _CameraModel = Shared.Settings.CameraList.Count > _Index ?
                    Shared.Settings.CameraList[_Index] : new CameraModel { Index = _Index };
            }
        }
        private bool _IsBinding = false;

        public UcCameraSettings()
        {
            InitializeComponent();
            Load += UcCameraSettings_Load;

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            InitEvents();
            SetLanguage();
        }

        private int convertToIndexResolution(int width, int heigth)
        {
            if (width.Equals(240) && heigth.Equals(160))
            {
                return 0;
            }
            if (width.Equals(320) && heigth.Equals(240))
            {
                return 1;
            }
            if (width.Equals(480) && heigth.Equals(360))
            {
                return 2;
            }
            return 0;
        }

        private (int width, int height) ConvertFromIndexResolution(int index)
        {
            switch (index)
            {
                case 0:
                    return (240, 160);
                case 1:
                    return (320, 240);
                case 2:
                    return (480, 360);
                default:
                    return (240, 160);
            }
        }

        private void InitVisibiltyForCamType(CameraType cameraType)
        {
            switch (cameraType)
            {
                case CameraType.DM:
                    comboBoxCamType.SelectedIndex = 0;
                    break;
                case CameraType.IS:
                    comboBoxCamType.SelectedIndex = 1;
                    break;
                case CameraType.ISDual:
                    comboBoxCamType.SelectedIndex = 2;

                    break;
                default:
                    comboBoxCamType.SelectedIndex = 0;
                    break;
            }

            if (!_firstLoad)
            {
                // Remove for conflict
                //  txtSlaveIPAddress.Text = txtIPAddress.Text = string.Empty;
            }
            EnablePosition.Checked = Shared.Settings.EnablePosition;
            itemsPerHour.Checked = Shared.Settings.IsItemsPerHour;
            radioBarcodePosition.Checked = Shared.Settings.Position == SettingsModel.PositionType.BarcodePosition;
            radioLogoPosition.Checked = Shared.Settings.Position == SettingsModel.PositionType.LogoPosition;

            // Change language 
            labelMasterJobName.Text = cameraType.Equals(CameraType.IS) ? Lang.SingleJobFileName : Lang.MasterJobName;
            labelObjectNameMaster.Text = cameraType.Equals(CameraType.IS) ? Lang.ObjectNameSingle : Lang.ObjectNameMaster;

            // Visibility
            textBoxObjectNameSlave.Visible =
            labelObjectNameSlave.Visible =
            tableLayoutPanelObjectSym.Visible =
            textBoxSlaveJobName.Visible =
            labelSlaveJobName.Visible = lblSlaveIp.Visible =
            txtSlaveIPAddress.Visible = cameraType.Equals(CameraType.ISDual);

            PositionPanel.Visible = cameraType.Equals(CameraType.IS);
            CustomCommandPanel.Parent = this;

            switch (cameraType)
            {
                case CameraType.DM:
                    OutputTypePanel.Enabled = true;
                    OutputTypePanel.Location = new System.Drawing.Point(336, 207);
                    CustomCommandPanel.Location = new System.Drawing.Point(326, 247);
                    break;
                case CameraType.IS:
                    CommandErrorBox.Checked = true;
                    OutputTypePanel.Enabled = false;
                    OutputTypePanel.Location = new System.Drawing.Point(30, 394);
                    CustomCommandPanel.Location = new System.Drawing.Point(335, 397);
                    break;
                case CameraType.ISDual:
                    CommandErrorBox.Checked = true;
                    OutputTypePanel.Enabled = false;
                    OutputTypePanel.Location = new System.Drawing.Point(30, 394);
                    CustomCommandPanel.Location = new System.Drawing.Point(335, 397);
                    break;
                case CameraType.UKN:
                default:
                    OutputTypePanel.Enabled = true;
                    OutputTypePanel.Location = new System.Drawing.Point(336, 207);
                    CustomCommandPanel.Location = new System.Drawing.Point(326, 247);
                    break;
            }

            CustomCommandPanel.BringToFront();
            OutputTypePanel.Parent = this;
            OutputTypePanel.BringToFront();
            comboBox_ModeReadCamera.Visible =
            lblModeRead.Visible = cameraType.Equals(CameraType.DM);
            labelImageResolution.Visible =
            comboBoxImageResolution.Visible =
            groupBoxOCR.Visible = cameraType.Equals(CameraType.ISDual) || cameraType.Equals(CameraType.IS);

            // Init Value
            comboBoxImageResolution.SelectedIndex = convertToIndexResolution(_CameraModel.WidthImage, _CameraModel.HeigthImage);
            comboBox_ModeReadCamera.SelectedIndex = (cameraType.Equals(CameraType.DM) && (Shared.Settings.CameraList.FirstOrDefault().ReadMode == CameraModeRead.Basic)) ? 0 : 1;
            txtIPAddress.Text = _CameraModel.IP;
            txtSlaveIPAddress.Text = _CameraModel.ISSlaveIP;
            textBoxMasterJobName.Text = _CameraModel.CameraJobNameMaster;
            textBoxSlaveJobName.Text = _CameraModel.CameraJobNameSlave;

        }

        private void InitControls()
        {
            _IsBinding = true;
            InitVisibiltyForCamType(_CameraModel.CameraType);
            textBoxCommandError.Text = _CameraModel.CommandErrorOutput;
            textBoxObjectNameMaster.Text = _CameraModel.ObjectNameMaster.Replace(".ReadText", "").Replace(".Result00.String", "");
            textBoxObjectNameSlave.Text = _CameraModel.ObjectNameSlave.Replace(".ReadText", "").Replace(".Result00.String", "");
            UpdateCameraInfo();
            _IsBinding = false;
            bool[] listBoolCheckBox = UtilityFunctions.IntToBools(_CameraModel.ObjectSelectNum, 5);
            InitControlsAndEvents_IS();
        }

        private void InitControlsAndEvents_IS()

        {
            radioButtonSymMaster.Checked = _CameraModel.IsSymbolMaster;
            radioButtonTextMaster.Checked = !_CameraModel.IsSymbolMaster;

            radioButtonSymSlave.Checked = _CameraModel.IsSymbolSlave;
            radioButtonTextSlave.Checked = !_CameraModel.IsSymbolSlave;

            radioButtonSymMaster.CheckedChanged += RadioButtonMaster_CheckedChanged;
            radioButtonTextMaster.CheckedChanged += RadioButtonMaster_CheckedChanged;

            radioButtonSymSlave.CheckedChanged += RadioButtonSlave_CheckedChanged;
            radioButtonTextSlave.CheckedChanged += RadioButtonSlave_CheckedChanged;
        }

        private void RadioButtonSlave_CheckedChanged(object sender, EventArgs e)
        {
            _CameraModel.IsSymbolSlave = radioButtonSymSlave.Checked;
            _CameraModel.ObjectNameSlave = textBoxObjectNameSlave.Text;
            Shared.SaveSettings();
        }

        private void Shared_OnCameraStatusChange(object sender, EventArgs e)
        {
            UpdateCameraInfo();
        }

        private void UpdateCameraInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateCameraInfo()));
            }

            txtModel.Text = _CameraModel.Name;
            txtSerialNumber.Text = _CameraModel.SerialNumber;
        }

        private void InitEvents()
        {
            txtIPAddress.TextChanged += AdjustData;
            txtSlaveIPAddress.TextChanged += AdjustData;

            EnablePosition.CheckedChanged += AdjustData;
            radioBarcodePosition.CheckedChanged += AdjustData;
            radioLogoPosition.CheckedChanged += AdjustData;
            // Job Name
            textBoxMasterJobName.TextChanged += AdjustData;
            textBoxSlaveJobName.TextChanged += AdjustData;


            textBoxObjectNameMaster.TextChanged += AdjustData;
            textBoxObjectNameSlave.TextChanged += AdjustData;


            textBoxCommandError.TextChanged += AdjustData;

            Shared.OnLanguageChange += Shared_OnLanguageChange;
            Shared.OnCameraStatusChange += Shared_OnCameraStatusChange;

            Load += UcCameraSettings_Load;
            comboBoxCamType.SelectedIndexChanged += AdjustData;
            comboBoxImageResolution.SelectedIndexChanged += AdjustData;
            comboBox_ModeReadCamera.SelectedIndexChanged += AdjustData;
            IndexCheckBox.Checked = _CameraModel.IsIndexCommandEnable;
            OutputCameraBox.Checked = _CameraModel.OutputType == OutputType.OutputCamera;
            CommandErrorBox.Checked = _CameraModel.OutputType == OutputType.CommandError;
        }

        private void RadioButtonMaster_CheckedChanged(object sender, EventArgs e)
        {

            _CameraModel.IsSymbolMaster = radioButtonSymMaster.Checked;
            _CameraModel.ObjectNameMaster = textBoxObjectNameMaster.Text;


            Shared.SaveSettings();
        }

        private void CheckBoxSelectObjectChange(object sender, EventArgs e)
        {

            Shared.SaveSettings();
        }

        private void UcCameraSettings_Load(object sender, EventArgs e)
        {
            _firstLoad = true;
            InitControls();
            _firstLoad = false;
        }

        private void Shared_OnLanguageChange(object sender, EventArgs e)
        {
            SetLanguage();
        }

        private void AdjustData(object sender, EventArgs e)
        {
            if (_IsBinding)
            {
                return;
            }
            if (sender == txtIPAddress)
            {
                if (!_firstLoad) // prevent disconect by _firstLoad
                {
                    _CameraModel.IsConnected = false;
                }
                _CameraModel.IP = txtIPAddress.Text;
            }
            if (sender == txtSlaveIPAddress)
            {
                if (!_firstLoad)
                {
                    _CameraModel.IsConnected = false;
                }
                _CameraModel.ISSlaveIP = txtSlaveIPAddress.Text;
            }
            //else if(sender == textBoxPort)
            //{
            //    _CameraModel.IsConnected = false;
            //    _CameraModel.Port = textBoxPort.Text;
            //}
            //else if (sender == txtPassword)
            //{
            //    _CameraModel.Password = txtPassword.Text;
            //}
            //else if (sender == txtNoReadOutputString)
            //{
            //    _CameraModel.NoReadOutputString = txtNoReadOutputString.Text;
            //}
            else if (sender == textBoxCommandError)
            {
                if (textBoxCommandError.Text == "")
                {
                    textBoxCommandError.Text = "1";
                }
                _CameraModel.CommandErrorOutput = textBoxCommandError.Text;
            }
            else if (sender == textBoxMasterJobName)
            {
                if (!_firstLoad) // prevent disconect by _firstLoad
                {
                    _CameraModel.IsConnected = false;
                }
                _CameraModel.CameraJobNameMaster = textBoxMasterJobName.Text;
            }
            else if (sender == textBoxSlaveJobName)
            {
                if (!_firstLoad) // prevent disconect by _firstLoad
                {
                    _CameraModel.IsConnected = false;
                }
                _CameraModel.CameraJobNameSlave = textBoxSlaveJobName.Text;
            }
            else if (sender == comboBoxImageResolution)
            {
                _CameraModel.WidthImage = ConvertFromIndexResolution(comboBoxImageResolution.SelectedIndex).width;
                _CameraModel.HeigthImage = ConvertFromIndexResolution(comboBoxImageResolution.SelectedIndex).height;
            }
            else if (sender == comboBoxCamType)
            {
                switch (comboBoxCamType.SelectedIndex)
                {
                    case 0:
                        if (!(_CameraModel.CameraType == CameraType.DM))
                        {
                            _CameraModel.CameraType = CameraType.DM;
                            _CameraModel.IsConnected = false;
                        }
                        break;
                    case 1:
                        if (!(_CameraModel.CameraType == CameraType.IS))
                        {
                            _CameraModel.CameraType = CameraType.IS;
                            _CameraModel.IsConnected = false;
                        }
                        break;
                    case 2:
                        if (!(_CameraModel.CameraType == CameraType.ISDual))
                        {
                            _CameraModel.CameraType = CameraType.ISDual;
                            _CameraModel.IsConnected = false;
                        }

                        break;
                    default:
                        break;
                }
                InitVisibiltyForCamType(_CameraModel.CameraType);
            }
            else if (sender == textBoxObjectNameMaster)
            {
                _CameraModel.ObjectNameMaster = textBoxObjectNameMaster.Text;
            }
            else if (sender == textBoxObjectNameSlave)
            {
                _CameraModel.ObjectNameSlave = textBoxObjectNameSlave.Text;
            }
            else if (sender == comboBox_ModeReadCamera)
            {
                if (comboBox_ModeReadCamera.SelectedIndex == 0)
                {
                    Shared.Settings.CameraList.FirstOrDefault().ReadMode = CameraModeRead.Basic;
                    FrmJob.DMCamera?.Disconnect();
                    //Shared.CamController.Disconnect();
                    //Shared.Settings.CameraList.FirstOrDefault().IsConnected = false;
                    FrmJob.DMCamera?.Connect(Shared.Settings.CameraList.FirstOrDefault().IP);

                }
                else
                {
                    Shared.Settings.CameraList.FirstOrDefault().ReadMode = CameraModeRead.MultiRead;
                    FrmJob.DMCamera?.Disconnect();
                    //Shared.CamController.Disconnect();
                    //Shared.Settings.CameraList.FirstOrDefault().IsConnected = false;
                }
            }
            else if (sender == EnablePosition)
            {
                Shared.Settings.EnablePosition = EnablePosition.Checked;
            }
            else if (sender == itemsPerHour)
            {
                Shared.Settings.IsItemsPerHour = itemsPerHour.Checked;
            }
            else if (sender == radioBarcodePosition || sender == radioLogoPosition)
            {
                Shared.Settings.Position = radioBarcodePosition.Checked ? SettingsModel.PositionType.BarcodePosition : SettingsModel.PositionType.LogoPosition;
            }
            Shared.SaveSettings();
        }

        private void SetLanguage()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetLanguage()));
                return;
            }

            lblModel.Text = Lang.Model;
            //   lblNoReadOuputString.Text = Lang.NoReadOuputString;
            labelCamType.Text = Lang.Type;
            lblIPAddress.Text = Lang.IPAddress;
            lblSerialNumber.Text = Lang.SerialNumber;
            //   lblPassword.Text = Lang.Password;
            lblSlaveIp.Text = Lang.SlaveIPAddress;
            grbCamera.Text = Lang.CameraTMP;
            groupBoxOCR.Text = Lang.InsightVisionObjectSettings;
            labelObjectNameMaster.Text = Lang.ObjectNameMaster;
            labelObjectNameSlave.Text = Lang.ObjectNameSlave;
            labelImageResolution.Text = Lang.ImageResolution;
            radioButtonSymSlave.Text = radioButtonSymMaster.Text = Lang.IDRead;
            radioButtonTextSlave.Text = radioButtonTextMaster.Text = Lang.CharacterRead;
            lblModeRead.Text = Lang.DatamanReadMode;
            labelMasterJobName.Text = Lang.MasterJobName;
            labelSlaveJobName.Text = Lang.SlaveJobName;
            //  labelNotesOCR.Text = Lang.NotesForSettingCam;
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            textBoxCommandError.Enabled = true;
        }

        private void CustomCommandCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCommandError.Enabled = CustomCommandCheckBox.Checked;
        }

        private void IndexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // thinh dep trai dang lam
            _CameraModel.IsIndexCommandEnable = IndexCheckBox.Checked;
            Shared.SaveSettings();
        }

        private void grbCamera_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxCommandError_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _CameraModel.OutputType = OutputType.OutputCamera;
            Shared.SaveSettings();
        }

        private void CommandErrorBox_CheckedChanged(object sender, EventArgs e)
        {
            _CameraModel.OutputType = OutputType.CommandError;
            Shared.SaveSettings();
        }
    }
}
