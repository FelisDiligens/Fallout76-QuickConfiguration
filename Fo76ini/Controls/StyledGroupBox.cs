using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Fo76ini.Interface;

namespace Fo76ini.Controls
{
    public enum TextAlignment
    {
        Left,
        Center,
        Right
    }

    public class StyledGroupBox : GroupBox
    {
        public Color TitleForeColor;
        public TextAlignment TitleAlignment;
        public Color BorderColor;
        public int BorderWidth;
        public int TitleBorderMargin;
        public int TitleBorderPadding;

        public StyledGroupBox () : base()
        {
            this.DoubleBuffered = true;

            BackColor = Color.FromArgb(34, 34, 34);
            TitleForeColor = Color.White;
            TitleAlignment = TextAlignment.Left;
            BorderColor = Color.FromArgb(68, 68, 68);
            BorderWidth = 1;
            TitleBorderMargin = 6;
            TitleBorderPadding = 4;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //GroupBoxRenderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);
            e.Graphics.Clear(this.BackColor);

            Brush borderBrush = new SolidBrush(BorderColor);
            Pen borderPen = new Pen(borderBrush, BorderWidth);
            SizeF strSize = e.Graphics.MeasureString(Text, Font);
            Rectangle rect = new Rectangle(ClientRectangle.X,
                                           ClientRectangle.Y + (int)(strSize.Height / 2),
                                           ClientRectangle.Width - BorderWidth,
                                           ClientRectangle.Height - (int)(strSize.Height / 2) - BorderWidth);

            // Draw background:
            if (BackColor != Color.Transparent)
                using (var brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, rect);

            // Draw text:
            // TextRenderer.DrawText(e.Graphics, Text, this.Font, rect, TitleForeColor);
            e.Graphics.DrawString(Text, Font, new SolidBrush(TitleForeColor), TitleBorderMargin + TitleBorderPadding, 0);

            // Draw border:
            // Left
            e.Graphics.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
            // Right
            e.Graphics.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            // Bottom
            e.Graphics.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            // Top, left
            e.Graphics.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + TitleBorderMargin, rect.Y));
            // Top, right
            e.Graphics.DrawLine(borderPen, new Point(rect.X + TitleBorderMargin + TitleBorderPadding * 2 + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
        }
    }
}
