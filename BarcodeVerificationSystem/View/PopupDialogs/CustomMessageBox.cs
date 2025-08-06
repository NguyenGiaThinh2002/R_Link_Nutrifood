using DesignUI.CuzMesageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UILanguage;

namespace BarcodeVerificationSystem.View.CustomDialogs
{

    public static class CustomMessageBox
    {
        public static DialogResult Show(string text, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // Create the original message box
            FormMessageBox formMessageBox = new FormMessageBox(text, title, buttons, icon);

            // Use reflection to set the title if it's not correctly set
            PropertyInfo titleProperty = typeof(Form).GetProperty("Text", BindingFlags.Instance | BindingFlags.Public);
            if (titleProperty != null)
            {
                titleProperty.SetValue(formMessageBox, title);
            }
            formMessageBox.TopMost = true;
            return formMessageBox.ShowDialog();
        }

        public static bool IsResultShow(string text)
        {
            // Create the original message box with default buttons and icon
            var result = Show(text, Lang.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
