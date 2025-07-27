using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Labels.DevModeLabel
{
    internal class DevMode
    {
        public enum DevModeLabel
        {
            OffDevMode,
            OnDevMode,
        }
        public enum LoginLabel
        {
            AdminOfflineMode,
            AdminOnlineMode,
            SupportOfflineMode,
            OperatorOfflineMode,
            OperatorOnlineMode,
        }
        private static DevModeLabel _devMode = DevModeLabel.OnDevMode;
        private static LoginLabel _labelType = LoginLabel.OperatorOfflineMode;
        //public static LabelType ProjectType { get => _labelType; set => _labelType = value; }
        public static bool IsDevMode => _devMode == DevModeLabel.OnDevMode;
        public static LoginLabel LabelType => _labelType;
    }
}
