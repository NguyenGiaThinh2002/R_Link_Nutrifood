using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeVerificationSystem.Utils
{
    internal static class UIControlsFuncs
    {
        private static bool _tabSelectionEnabled = true;


        // Enable all specified controls
        public static void EnableControls(params Control[] controls)
        {
            if (controls == null) throw new ArgumentNullException(nameof(controls));
            foreach (var control in controls)
            {
                if (control != null) control.Enabled = true;
            }
        }

        // Disable all specified controls
        public static void DisableControls(params Control[] controls)
        {
            if (controls == null) throw new ArgumentNullException(nameof(controls));
            foreach (var control in controls)
            {
                if (control != null) control.Enabled = false;
            }
        }

        // Show all specified controls
        public static void ShowControls(params Control[] controls)
        {
            if (controls == null) throw new ArgumentNullException(nameof(controls));
            foreach (var control in controls)
            {
                if (control != null) control.Visible = true;
            }
        }

        // Hide all specified controls
        public static void HideControls(params Control[] controls)
        {
            if (controls == null) throw new ArgumentNullException(nameof(controls));
            foreach (var control in controls)
            {
                if (control != null) control.Visible = false;
            }
        }


        public static void HideControls(params object[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                switch (item)
                {
                    case Control control:
                        control.Visible = false;
                        break;

                    case ToolStripItem toolStripItem:
                        toolStripItem.Visible = false;
                        break;

                    default:
                        throw new NotSupportedException($"Unsupported type: {item?.GetType().Name}");
                }
            }
        }

            public static void EnableAllTabsSelection(TabControl tabControl)
        {
            if (tabControl == null) throw new ArgumentNullException(nameof(tabControl));
            _tabSelectionEnabled = true;
            tabControl.Selecting -= TabControl_Selecting; // Remove any existing handler
            tabControl.Selecting += TabControl_Selecting; // Re-attach handler
        }

        public static void DisableAllTabsSelection(TabControl tabControl)
        {
            if (tabControl == null) throw new ArgumentNullException(nameof(tabControl));
            _tabSelectionEnabled = false;
            tabControl.Selecting -= TabControl_Selecting; // Remove any existing handler
            tabControl.Selecting += TabControl_Selecting; // Re-attach handler
        }

        private static void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !_tabSelectionEnabled;
        }
        internal static void SetControlsEnabled(Control parent, bool enabled, Control exception)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl == exception)
                {
                    ctrl.Enabled = true; // Always enable the exception
                }
                else
                {
                    ctrl.Enabled = enabled;
                }

                // Recursively handle nested controls
                if (ctrl.HasChildren)
                {
                    SetControlsEnabled(ctrl, enabled, exception);
                }
            }
        }

    }
}
