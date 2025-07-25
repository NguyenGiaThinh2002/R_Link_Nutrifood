using BarcodeVerificationSystem.Controller;
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

namespace BarcodeVerificationSystem.View.UcSettings
{
    public partial class ucProductionSetting : UserControl
    {
        public ucProductionSetting()
        {
            InitializeComponent();
            InitControls();
            InitEvents();
            InitLanguage();
        }

        private void InitLanguage()
        {
            lineIdLabel.Text = Lang.LineID;
            lineNameLabel.Text = Lang.LineName;
            factoryCodeLabel.Text = Lang.FactoryCode;
            radProductionModeEnable.Text = Lang.Enable;
            radProductionModeDisable.Text = Lang.Disable;
            manufacturingRad.Text = Lang.Manufacturing;
            dispatchingRad.Text = Lang.Dispatching;
            productionMode.Text = Lang.ProductionMode;
            dataDisplay.Text = Lang.DisplayData;
            maskData.Text = Lang.MaskData;
            dataIncrease.Text = Lang.IncreasedData;
            groupBoxProductionSettings.Text = Lang.ProductionSettings;
            labelApi.Text = Lang.URLPath;
        }

        private void InitControls()
        {
            apiTextbox.Text = Shared.Settings.ApiUrl;
            numIncreasedData.Value = Shared.Settings.IncreasedDataPercent;
            manufacturingRad.Checked = Shared.Settings.IsManufacturingMode;
            dispatchingRad.Checked = !Shared.Settings.IsManufacturingMode;
            maskData.Checked = Shared.Settings.MaskData;
            lineName.Text = Shared.Settings.LineName;
            factoryCode.Text = Shared.Settings.FactoryCode;
            LineId.Text = Shared.Settings.RLinkId;
            lineIndexTextBox.Text = Shared.Settings.LineIndex.ToString();

            //maskData.Enabled = !Shared.UserPermission.isOnline;
            onlineProductionSettings.Enabled = !Shared.UserPermission.isOnline;
        }

        private void InitEvents()
        {
            apiTextbox.TextChanged += AdjustData;
            //comboBoxRLinkId.SelectedIndexChanged += AdjustData;
            numIncreasedData.ValueChanged += AdjustData;
            manufacturingRad.CheckedChanged += AdjustData;
            dispatchingRad.CheckedChanged += AdjustData; 
            maskData.CheckedChanged += AdjustData;
            lineName.TextChanged += AdjustData;
            factoryCode.TextChanged += AdjustData;
            LineId.TextChanged += AdjustData;
            lineIndexTextBox.TextChanged += AdjustData;
            radProductionModeDisable.CheckedChanged += AdjustData;
            radProductionModeEnable.CheckedChanged += AdjustData;
            radProductionModeDisable.CheckedChanged += FrmJob.RadioButton_CheckedChanged;
            radProductionModeEnable.CheckedChanged += FrmJob.RadioButton_CheckedChanged;
            radProductionModeDisable.Checked = !Shared.Settings.IsProductionMode;
            radProductionModeEnable.Checked = Shared.Settings.IsProductionMode;

        }

        private void AdjustData(object sender, EventArgs args)
        {
            switch (sender)
            {
                case TextBox tb:
                    if (tb == apiTextbox)
                        Shared.Settings.ApiUrl = tb.Text;
                    else if (tb == lineName)
                        Shared.Settings.LineName = tb.Text;
                    else if (tb == factoryCode)
                        Shared.Settings.FactoryCode = tb.Text;
                    else if (tb == LineId)
                        Shared.Settings.RLinkId = tb.Text;
                    else if (tb == lineIndexTextBox)
                        Shared.Settings.LineIndex = int.Parse(tb.Text);
                    break;
                //case ComboBox cb:
                //    if (cb == comboBoxRLinkId)
                //        Shared.Settings.RLinkId = cb.SelectedItem?.ToString() ?? string.Empty;
                //    break;
                case NumericUpDown num:
                    if (num == numIncreasedData)
                        Shared.Settings.IncreasedDataPercent = (int)numIncreasedData.Value;
                    break;
                case RadioButton rb:
                    if (rb == manufacturingRad)
                        Shared.Settings.IsManufacturingMode = true;
                    else if (rb == dispatchingRad)
                        Shared.Settings.IsManufacturingMode = false;
                    if (rb == radProductionModeDisable)
                        Shared.Settings.IsProductionMode = false;
                    else if (rb == radProductionModeEnable)
                        Shared.Settings.IsProductionMode = true;
                    break;
                case CheckBox cbx:
                    if(cbx == maskData)
                        Shared.Settings.MaskData = cbx.Checked;
                    break;
            }
            Shared.SaveSettings();

        }

    }
}
