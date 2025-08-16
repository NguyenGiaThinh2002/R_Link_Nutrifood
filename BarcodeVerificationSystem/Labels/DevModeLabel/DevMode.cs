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
            OperatorOnlineMode,
            OperatorOfflineMode,
            SupportOfflineMode,
            AdminOfflineMode,
            AdminOnlineMode,
        }
        private static LoginLabel _labelType = LoginLabel.SupportOfflineMode;

        private static DevModeLabel _devMode = DevModeLabel.OffDevMode;
        public static bool IsDevMode => _devMode == DevModeLabel.OnDevMode;
        public static LoginLabel LabelType => _labelType;
    }
}
