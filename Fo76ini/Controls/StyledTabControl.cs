using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrightIdeasSoftware.TreeListView;

namespace Fo76ini.Controls
{
    public class StyledTabControl : TabControl, IThemable
    {
        public String VisualStyle { get; set; }
        public Color SelectedTabButtonBackColor;
        public Color TabButtonBackColor;
        public Color TabButtonForeColor;
        public Color HeaderColor;
        public Color BorderColor;
        public int BorderWidth;

        public StyledTabControl() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            VisualStyle = "Default";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // fill in the whole rect
            using (SolidBrush br = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(br, ClientRectangle);
            }

            // draw the tabs
            for (int i = 0; i < TabPages.Count; ++i)
            {
                TabPage tab = TabPages[i];
                bool selected = i == this.SelectedIndex;

                // Get the text area of the current tab
                RectangleF tabTextArea = (RectangleF)GetTabRect(i);

                // determine how to draw the tab based on which type of tab it is
                Color tabBackColor = Color.Silver;
                Color selectedTabBackColor = Color.Magenta;
                Color tabTextColor = Color.White;

                // draw the background
                if (selected)
                {
                    using (SolidBrush br = new SolidBrush(selectedTabBackColor))
                    {
                        e.Graphics.FillRectangle(br, tabTextArea);
                    }
                }
                else
                {
                    using (SolidBrush br = new SolidBrush(tabBackColor))
                    {
                        e.Graphics.FillRectangle(br, tabTextArea);
                    }
                }

                // draw the tab header text
                using (SolidBrush brush = new SolidBrush(tabTextColor))
                {
                    e.Graphics.DrawString(tab.Text, Font, brush, CreateTabHeaderTextRect(tabTextArea));
                }
            }
        }

        /* protected override void OnDrawItem(DrawItemEventArgs e) { } */

        private RectangleF CreateTabHeaderTextRect(RectangleF tabTextArea)
        {
            tabTextArea.X += 3;
            tabTextArea.Y += 1;

            tabTextArea.Height -= 1;

            return tabTextArea;
        }
    }
}
