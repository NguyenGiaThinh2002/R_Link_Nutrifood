using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.ComponentModel;

namespace BarcodeVerificationSystem.Controller.HistorySync
{
    [DesignerCategory("Code")]
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 10;
        public Color ButtonColor { get; set; } = Color.FromArgb(0, 122, 204);
        public Color HoverColor { get; set; } = Color.FromArgb(0, 102, 184);
        public Color TextColor { get; set; } = Color.White;

        private bool isHovering = false;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ButtonColor;
            ForeColor = TextColor;
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Cursor = Cursors.Hand;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            MouseEnter += (s, e) => { isHovering = true; Invalidate(); };
            MouseLeave += (s, e) => { isHovering = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            int radius = BorderRadius;

            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                // Clear background with parent's color
                using (SolidBrush bg = new SolidBrush(this.Parent.BackColor))
                {
                    g.FillRectangle(bg, rect);
                }

                // Fill rounded button
                using (SolidBrush brush = new SolidBrush(isHovering ? HoverColor : ButtonColor))
                {
                    g.FillPath(brush, path);
                }

                // Draw text centered
                TextRenderer.DrawText(
                    g, Text, Font, rect, TextColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }


}
