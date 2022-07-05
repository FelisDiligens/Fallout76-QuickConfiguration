using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    /// <summary>
    /// A button that can be styled to whatever you want.
    /// </summary>
    public partial class StyledButton : Button
    {
        #region Designer Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [AmbientValue(false)]
        [Category("Appearance")]
        [Description("Background color when mouse isn't touching the button.")]
        [DefaultValue(typeof(Color), "75, 75, 75")]
        public override Color BackColor { get; set; }

        [Category("Appearance")]
        [Description("Background color when mouse is hovering over button.")]
        [DefaultValue(typeof(Color), "220, 180, 42")]
        public Color MouseOverBackColor { get; set; }

        [Category("Appearance")]
        [Description("Background color when mouse is clicking on button.")]
        [DefaultValue(typeof(Color), "250, 210, 72")]
        public Color MouseDownBackColor { get; set; }

        [Category("Appearance")]
        [Description("The color of the border, if used.")]
        [DefaultValue(typeof(Color), "0, 0, 0")]
        public Color BorderColor { get; set; }

        /*[Category("Appearance")]
        [Description("Rounded corners. Default is 0 px.")]
        [DefaultValue(0)]
        public int BorderRadius { get; set; }*/

        [Category("Appearance")]
        [Description("How wide is the border? Set to 0 to not draw a border.")]
        [DefaultValue(0)]
        public int BorderWidth { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [AmbientValue(false)]
        [Category("Appearance")]
        [Description("Padding of text and image")]
        [DefaultValue(0)]
        public new int Padding { get; set; }

        #endregion

        private bool _mouseOver = false;
        private bool _mouseDown = false;

        public StyledButton() : base()
        {
            // Set property defaults:
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(75, 75, 75);
            MouseOverBackColor = Color.FromArgb(220, 180, 42);
            MouseDownBackColor = Color.FromArgb(250, 210, 72);
            BorderColor = Color.FromArgb(0, 0, 0);
            BorderWidth = 0;
            //BorderRadius = 0;
            Padding = 0;


            /*
             * Use mouse events to redraw the button:
             */

            this.MouseEnter += (object sender, EventArgs e) =>
            {
                _mouseOver = true;
                this.Refresh();
            };

            this.MouseLeave += (object sender, EventArgs e) =>
            {
                _mouseOver = false;
                this.Refresh();
            };

            this.MouseDown += (object sender, MouseEventArgs e) =>
            {
                _mouseDown = true;
                this.Refresh();
            };

            this.MouseUp += (object sender, MouseEventArgs e) =>
            {
                _mouseDown = false;
                this.Refresh();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            // Variables:
            Rectangle rect = Rectangle.FromLTRB(0, 0, Width, Height);
            Rectangle BGRect = Rectangle.FromLTRB(
                BorderWidth,
                BorderWidth,
                Width - BorderWidth,
                Height - BorderWidth);

            e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);

            // Draw border:
            e.Graphics.FillRectangle(new SolidBrush(BorderColor), rect);
            
            // Draw background:
            if (_mouseDown)
                e.Graphics.FillRectangle(new SolidBrush(MouseDownBackColor), BGRect);
            else if (_mouseOver)
                e.Graphics.FillRectangle(new SolidBrush(MouseOverBackColor), BGRect);
            else
                e.Graphics.FillRectangle(new SolidBrush(BackColor), BGRect);

            // Draw image:
            if (Image != null)
                e.Graphics.DrawImage(this.Image, GetImageRect());

            // Draw text:
            Size textSize = TextRenderer.MeasureText(e.Graphics, Text, this.Font);
            e.Graphics.DrawString(Text, this.Font, new SolidBrush(ForeColor), GetTextRect(textSize));
        }

        private RectangleF GetRect(ContentAlignment align, Size size, bool forText)
        {
            float x = 0;
            switch (align)
            {
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                case ContentAlignment.BottomCenter:
                    x = Width / 2 - size.Width / 2;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.TopLeft:
                case ContentAlignment.BottomLeft:
                    if (forText && Image != null && ImageAlign == ContentAlignment.MiddleLeft)
                        x = Padding + Image.Width + 5;
                    else
                        x = Padding;
                    break;
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                case ContentAlignment.BottomRight:
                    x = Width - size.Width - Padding;
                    break;
            }

            float y = 0;
            switch (align)
            {
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    y = Height / 2 - size.Height / 2;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    y = Padding;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    y = Width - size.Width - Padding;
                    break;
            }

            float width = size.Width;
            float height = size.Height;

            // For some reason, it cuts of the last character:
            if (forText)
                width += 10;

            return new RectangleF(
                        x,
                        y,
                        width, height);
        }

        private RectangleF GetImageRect ()
        {
            return GetRect(ImageAlign, Image.Size, false);
        }

        private RectangleF GetTextRect(Size textSize)
        {
            return GetRect(TextAlign, textSize, true);
        }
    }
}
