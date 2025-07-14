using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UILanguage;

namespace BarcodeVerificationSystem.View
{
    public partial class UcSensorSettings : UserControl
    {
        private bool _IsBinding = false;

        private int _CurrentSensorIndex { get; set; } = 0;
        public UcSensorSettings()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            InitEvents();
            SetLanguage();
        }

        private void InitControls()
        {
            _IsBinding = true;
            sensorOneBtn.BackColor = _CurrentSensorIndex == 0 ? Color.FromArgb(0, 170, 230) : Color.White;
            sensorTwoBtn.BackColor = _CurrentSensorIndex == 1 ? Color.FromArgb(0, 170, 230) : Color.White;
            grBoxSensor.Text = Lang.Sensor + " " + (_CurrentSensorIndex + 1);
         
            radioResumeA.Checked = Shared.Settings.ResumeEncoder == SettingsModel.ResumeEncoderType.ResumeA;
            radioResumeAB.Checked = Shared.Settings.ResumeEncoder == SettingsModel.ResumeEncoderType.ResumeAB;
            radioV1.Checked = Shared.Settings.PLCVersion == 0;
            grbResumeEncoder.Visible = delayOutputPanel.Visible = radioV2.Checked = Shared.Settings.PLCVersion == 1;

            numSensorControllerPort2.Value = Shared.Settings.SensorControllerPort2;
            comboPLCPort.SelectedIndex = Shared.Settings.NumberOfPort - 1;
            Port2Panel.Visible = Shared.Settings.NumberOfPort > 1;

            EnableResumeEncoder.Checked = Shared.Settings.ResumeEncoderEnable;
            radSensorControllerEnable.Checked = Shared.Settings.SensorControllerEnable;
            radSensorControllerDisable.Checked = !Shared.Settings.SensorControllerEnable;
            txtSensorControllerIP.Text = Shared.Settings.SensorControllerIP;
            numSensorControllerPort.Value = Shared.Settings.SensorControllerPort;
            numSensorControllerPulseEncoder.Value = Shared.Settings.SensorControllerPulseEncoder[_CurrentSensorIndex];
            numSensorControllerEncoderDiameter.Value = (decimal)Shared.Settings.SensorControllerEncoderDiameter[_CurrentSensorIndex];
            numSensorControllerDelayBefore.Value = Shared.Settings.SensorControllerDelayBefore[_CurrentSensorIndex];
            numSensorControllerDelayAfter.Value = Shared.Settings.SensorControllerDelayAfter[_CurrentSensorIndex];
            numGapLength1.Value = Shared.Settings.GapLength1[_CurrentSensorIndex];
            numLength2Error1.Value = Shared.Settings.Length2Error1[_CurrentSensorIndex];
            numericDelayOutputError.Value = Shared.Settings.DelayOutputError[_CurrentSensorIndex];
            EnableSensorController(Shared.Settings.SensorControllerEnable);
            _IsBinding = false;
        }

        private void InitEvents()
        {
            radSensorControllerEnable.CheckedChanged += AdjustData;
            radSensorControllerDisable.CheckedChanged += AdjustData;

            radSensorControllerEnable.CheckedChanged += FrmJob.RadioButton_CheckedChanged;
            radSensorControllerDisable.CheckedChanged += FrmJob.RadioButton_CheckedChanged;
            comboPLCPort.SelectedIndexChanged += AdjustData;

            txtSensorControllerIP.TextChanged += AdjustData;
            //numSensorControllerPort.ValueChanged += AdjustData;
            //numSensorControllerPulseEncoder.ValueChanged += AdjustData;
            //numSensorControllerEncoderDiameter.ValueChanged += AdjustData;
            //numSensorControllerDelayBefore.ValueChanged += AdjustData;
            //numSensorControllerDelayAfter.ValueChanged += AdjustData;
            //numGapLength1.ValueChanged += AdjustData;
            //numLength2Error1.ValueChanged += AdjustData;

            numSensorControllerPort.KeyUp += AdjustData;
            numSensorControllerPort2.KeyUp += AdjustData;
            numSensorControllerPulseEncoder.KeyUp += AdjustData;
            numSensorControllerEncoderDiameter.KeyUp += AdjustData;
            numSensorControllerDelayBefore.KeyUp += AdjustData;
            numSensorControllerDelayAfter.KeyUp += AdjustData;
            numGapLength1.KeyUp += AdjustData;
            numLength2Error1.KeyUp += AdjustData;

            btnContenResponseClear.Click += AdjustData;
            SendPort2.Click += AdjustData;
            EnableResumeEncoder.CheckedChanged += AdjustData;
            radioResumeA.CheckedChanged += AdjustData;
            radioResumeAB.CheckedChanged += AdjustData;
            radioV1.CheckedChanged += AdjustData;
            radioV2.CheckedChanged += AdjustData;
            numericDelayOutputError.KeyUp += AdjustData;

            Shared.OnLanguageChange += Shared_OnLanguageChange;
            Shared.OnRepeatTCPMessageChange += Shared_OnRepeatTCPMessageChange;
            this.Load += UcSensorSettings_Load;
        }

        private void UcSensorSettings_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void Shared_OnLanguageChange(object sender, EventArgs e)
        {
            SetLanguage();
        }

        private void Shared_OnRepeatTCPMessageChange(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Shared_OnRepeatTCPMessageChange(sender, e)));
                return;
            }

            if (sender is string)
            {
                var message = sender as string;
                richTXTContentResponse.Text = richTXTContentResponse.Text.Insert(0, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ": " + message + "\n");
                try
                {
                    richTXTContentResponse.SelectedText = message;
                    richTXTContentResponse.ScrollToCaret();
                }
                catch
                {

                }
            }
        }

        private void SetLanguage()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetLanguage()));
                return;
            }
            grbSensorController.Text = Lang.SensorController;
            lblSensorControllerIP.Text = Lang.IPAddress;
            lblSensorControllerPort.Text = Lang.Port;
            radSensorControllerEnable.Text = Lang.Enable;
            radSensorControllerDisable.Text = Lang.Disable;
            lblContentResponse.Text = Lang.ResponseContent;
            btnContenResponseClear.Text = Lang.ClearResponse;

            lblSensorControllerDelayBefore.Text = Lang.DelaySensor;
            lblSensorControllerDelayAfter.Text = Lang.DisableSensor;
            lblSensorControllerPulseEncoder.Text = Lang.PulseEncoder;
            lblSensorControllerEncoderDiameter.Text = Lang.EncoderDiameter;
            lblErrorCondition.Text = Lang.ErrorCondition;
            lblUnit.Text = Lang.Unit;
            lblDelayOutputError.Text = Lang.DelayOutputError;
            sensorOneBtn.Text = Lang.Sensor + " " + 1;
            sensorTwoBtn.Text = Lang.Sensor + " " + 2;
            grbResumeEncoder.Text = Lang.EncoderSettings;
            EnableResumeEncoder.Text = Lang.ResumeEncoder;
            radioResumeA.Text = Lang.ResumeA;
            radioResumeAB.Text = Lang.ResumeAB;
            versionLabel.Text = Lang.PLCversion + ": ";
        }

        private void AdjustData(object sender, EventArgs e)
        {
            if (_IsBinding)
            {
                return;
            }

            if (sender == radSensorControllerEnable)
            {
                if (radSensorControllerEnable.Checked == true)
                {
                    Shared.Settings.SensorControllerEnable = true;
                    EnableSensorController(Shared.Settings.SensorControllerEnable);
                }
            }
            else if (sender == radSensorControllerDisable)
            {
                if (radSensorControllerDisable.Checked == true)
                {
                    Shared.Settings.SensorControllerEnable = false;
                    EnableSensorController(Shared.Settings.SensorControllerEnable);
                }
            }
            else if (sender == txtSensorControllerIP)
            {
                Shared.Settings.SensorControllerIP = txtSensorControllerIP.Text;
            }
            else if (sender == numSensorControllerPort)
            {
                Shared.Settings.SensorControllerPort = (int)numSensorControllerPort.Value;
            }
            else if (sender == numSensorControllerPort2)
            {
                Shared.Settings.SensorControllerPort2 = (int)numSensorControllerPort2.Value;
            }
            else if (sender == numSensorControllerPulseEncoder)
            {
                Shared.Settings.Set(Shared.Settings.SensorControllerPulseEncoder, _CurrentSensorIndex, (int)numSensorControllerPulseEncoder.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == numSensorControllerEncoderDiameter)
            {
                Shared.Settings.Set(Shared.Settings.SensorControllerEncoderDiameter, _CurrentSensorIndex, (float)numSensorControllerEncoderDiameter.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == numSensorControllerDelayBefore)
            {
                Shared.Settings.Set(Shared.Settings.SensorControllerDelayBefore, _CurrentSensorIndex, (int)numSensorControllerDelayBefore.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == numSensorControllerDelayAfter)
            {
                Shared.Settings.Set(Shared.Settings.SensorControllerDelayAfter, _CurrentSensorIndex, (int)numSensorControllerDelayAfter.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == btnContenResponseClear)
            {
                richTXTContentResponse.Text = "";
                richTXTContentResponse.Clear();
            }
            else if (sender == SendPort2)
            {
                Shared.SensorController.Send2(Shared.Settings.CameraList.FirstOrDefault().CommandErrorOutput);
            }
            else if (sender == numGapLength1)
            {
                Shared.Settings.Set(Shared.Settings.GapLength1, _CurrentSensorIndex, (int)numGapLength1.Value);

                Shared.SendSettingToSensorController();
            }
            else if (sender == numLength2Error1)
            {
                Shared.Settings.Set(Shared.Settings.Length2Error1, _CurrentSensorIndex, (int)numLength2Error1.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == numericDelayOutputError)
            {
                Shared.Settings.Set(Shared.Settings.DelayOutputError, _CurrentSensorIndex, (int)numericDelayOutputError.Value);
                Shared.SendSettingToSensorController();
            }
            else if (sender == EnableResumeEncoder)
            {
                Shared.Settings.ResumeEncoderEnable = EnableResumeEncoder.Checked;
                if (Shared.Settings.ResumeEncoderEnable)
                    Shared.SendCommandToSensorController(Shared.Settings.ResumeEncoder == SettingsModel.ResumeEncoderType.ResumeA ? Shared.ResumeA : Shared.ResumeAB);

            }
            else if (sender == radioResumeA)
            {
                Shared.Settings.ResumeEncoder = radioResumeA.Checked ? SettingsModel.ResumeEncoderType.ResumeA : SettingsModel.ResumeEncoderType.ResumeAB;
                if (Shared.Settings.ResumeEncoderEnable)
                    Shared.SendCommandToSensorController(Shared.Settings.ResumeEncoder == SettingsModel.ResumeEncoderType.ResumeA ? Shared.ResumeA : Shared.ResumeAB);

            }
            else if (sender == radioV1)
            {
                Shared.Settings.PLCVersion = radioV1.Checked ? 0 : 1;
                grbResumeEncoder.Visible = delayOutputPanel.Visible = Shared.Settings.PLCVersion == 1;
            }
            else if (sender == comboPLCPort)
            {
                Shared.Settings.NumberOfPort = comboPLCPort.SelectedIndex + 1;
                Port2Panel.Visible = Shared.Settings.NumberOfPort > 1;

            }

            Shared.SaveSettings();
        }

        private void EnableSensorController(bool isEnable)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => EnableSensorController(isEnable)));
                return;
            }

            txtSensorControllerIP.Enabled = isEnable;
            numSensorControllerPort.Enabled = isEnable;
            numSensorControllerPort2.Enabled = isEnable;
            SendPort2.Enabled = isEnable;
            grbResumeEncoder.Enabled = isEnable;
            numSensorControllerPulseEncoder.Enabled = isEnable;
            numericDelayOutputError.Enabled = isEnable;
            numSensorControllerEncoderDiameter.Enabled = isEnable;
            numSensorControllerDelayBefore.Enabled = isEnable;
            numSensorControllerDelayAfter.Enabled = isEnable;
            numGapLength1.Enabled = isEnable;
            numLength2Error1.Enabled = isEnable;
        }

        private void SensorTwoBtn_Click(object sender, EventArgs e)
        {
            _CurrentSensorIndex = 1;
            InitControls();
        }

        private void SensorOneBtn_Click(object sender, EventArgs e)
        {
            _CurrentSensorIndex = 0;
            InitControls();
        }
    }
}
