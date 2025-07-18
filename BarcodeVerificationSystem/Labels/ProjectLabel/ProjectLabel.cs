using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Labels.ProjectLabel
{
    public class ProjectLabel
    {
        public enum LabelType
        {
            Default,
            Nutrifood
        }
        private static LabelType _labelType = LabelType.Nutrifood;
        //public static LabelType ProjectType { get => _labelType; set => _labelType = value; }
        public static bool IsNutrifood => _labelType == LabelType.Nutrifood;
        public static bool IsDefault => _labelType == LabelType.Default;
    }
}
