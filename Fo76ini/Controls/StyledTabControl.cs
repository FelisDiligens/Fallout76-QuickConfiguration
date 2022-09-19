using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrightIdeasSoftware.TreeListView;
using Fo76ini.Interface;
using System.ComponentModel;

namespace Fo76ini.Controls
{
    public class StyledTabControl : TabControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [AmbientValue(false)]
        [Category("Appearance")]
        [Description("Background color.")]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        public override Color BackColor { get; set; }

        public Color SelectedTabButtonBackColor { get; set; }
        public Color MouseOverTabButtonBackColor { get; set; }
        public Color TabButtonBackColor { get; set; }
        public Color TabButtonForeColor { get; set; }
        public Color HeaderColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }

        public StyledTabControl() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            TabButtonForeColor = Color.Black;
            TabButtonBackColor = Color.FromArgb(240, 240, 240);
            MouseOverTabButtonBackColor = Color.LightGray;
            SelectedTabButtonBackColor = Color.Silver;

            HeaderColor = Color.FromArgb(240, 240, 240);
            BackColor = Color.White;
            BorderColor = Color.Gray;
            BorderWidth = 1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the background:
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);

            Rectangle headerRect = new Rectangle(ClientRectangle.X,
                                                 ClientRectangle.Y,
                                                 ClientRectangle.Width,
                                                 GetTabRect(0).Height + 4);

            // Draw the header background:
            using (SolidBrush brush = new SolidBrush(HeaderColor))
                e.Graphics.FillRectangle(brush, headerRect);

            Rectangle borderRect = new Rectangle(ClientRectangle.X + (BorderWidth / 2),
                                                 ClientRectangle.Y + (BorderWidth / 2),
                                                 ClientRectangle.Width - BorderWidth,
                                                 ClientRectangle.Height - BorderWidth);

            // Draw border:
            if (BorderWidth > 0)
            {
                Brush borderBrush = new SolidBrush(BorderColor);
                Pen borderPen = new Pen(borderBrush, BorderWidth);
                e.Graphics.DrawRectangle(borderPen, borderRect);
            }

            // Draw the tabs:
            for (int i = 0; i < TabPages.Count; ++i)
            {
                TabPage tab = TabPages[i];
                Rectangle tabRect = GetTabRect(i);
                bool selected = i == this.SelectedIndex;
                bool hovered = tabRect.Contains(this.PointToClient(MousePosition));

                // Determine color:
                Color buttonBackColor = TabButtonBackColor;
                if (selected)
                    buttonBackColor = SelectedTabButtonBackColor;
                else if (hovered)
                    buttonBackColor = MouseOverTabButtonBackColor;

                // Draw the tab button background:
                using (SolidBrush brush = new SolidBrush(buttonBackColor))
                    e.Graphics.FillRectangle(brush, tabRect);

                // Draw the tab button text:
                SizeF textSize = e.Graphics.MeasureString(tab.Text, Font);
                RectangleF textRect = CreateTabHeaderTextRect(textSize, tabRect);
                using (SolidBrush brush = new SolidBrush(TabButtonForeColor))
                    e.Graphics.DrawString(tab.Text, Font, brush, textRect);
            }
        }

        /* protected override void OnDrawItem(DrawItemEventArgs e) { } */

        private RectangleF CreateTabHeaderTextRect(SizeF textSize, RectangleF tabRect)
        {
            RectangleF textRect = new RectangleF();
            
            textRect.X = tabRect.X + (tabRect.Width - textSize.Width) / 2;
            textRect.Y = tabRect.Y + (tabRect.Height - textSize.Height) / 2;

            return textRect;
        }
    }
}
