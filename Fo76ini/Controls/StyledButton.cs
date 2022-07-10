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
        [DefaultValue(typeof(Color), "225, 225, 225")]
        public override Color BackColor { get; set; }

        [Category("Appearance")]
        [Description("Background color when mouse is hovering over button.")]
        [DefaultValue(typeof(Color), "229, 241, 251")]
        public Color MouseOverBackColor { get; set; }

        [Category("Appearance")]
        [Description("Background color when mouse is clicking on button.")]
        [DefaultValue(typeof(Color), "204, 228, 247")]
        public Color MouseDownBackColor { get; set; }

        [Category("Appearance")]
        [Description("The color of the border, if used.")]
        [DefaultValue(typeof(Color), "173, 173, 173")]
        public Color BorderColor { get; set; }

        [Category("Appearance")]
        [Description("The color of the border, if used and when mouse is hovering over button")]
        [DefaultValue(typeof(Color), "0, 120, 215")]
        public Color BorderMouseOverColor { get; set; }

        [Category("Appearance")]
        [Description("The color of the border, if used and when mouse is clicking on button")]
        [DefaultValue(typeof(Color), "0, 84, 153")]
        public Color BorderMouseDownColor { get; set; }

        /*[Category("Appearance")]
        [Description("Rounded corners. Default is 0 px.")]
        [DefaultValue(0)]
        public int BorderRadius { get; set; }*/

        [Category("Appearance")]
        [Description("How wide is the border in pixels? Set to 0 to not draw a border.")]
        [DefaultValue(1)]
        public uint BorderWidth { get; set; }

        [Category("Appearance")]
        [Description("When 'Highlight' is set to true, the button will have a left 'ribbon' with this color.")]
        [DefaultValue(typeof(Color), "220, 180, 42")]
        public Color HighlightRibbonColor { get; set; }

        [Category("Appearance")]
        [Description("When 'Highlight' is set to true, the button will have this background color.")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color HighlightBackColor { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [AmbientValue(false)]
        [Category("Appearance")]
        [Description("Padding of text and image")]
        [DefaultValue(0)]
        public new int Padding { get; set; }

        #endregion

        /// <summary>
        /// Can be set to true, so that the button is highlighted.
        /// </summary>
        [Browsable(false)]
        public bool Highlight
        {
            get { return _highlight; }
            set
            {
                _highlight = value;
                this.Refresh();
            }
        }
        private bool _highlight = false;

        private bool _mouseOver = false;
        private bool _mouseDown = false;

        public StyledButton() : base()
        {
            // Set property defaults:
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(225, 225, 225);
            MouseOverBackColor = Color.FromArgb(229, 241, 251);
            MouseDownBackColor = Color.FromArgb(204, 228, 247);
            BorderColor = Color.FromArgb(173, 173, 173);
            BorderMouseOverColor = Color.FromArgb(0, 120, 215);
            BorderMouseDownColor = Color.FromArgb(0, 84, 153);
            BorderWidth = 1;
            //BorderRadius = 0;
            HighlightRibbonColor = Color.FromArgb(220, 180, 42);
            HighlightBackColor = Color.Silver;
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
            Rectangle ButtonRect = Rectangle.FromLTRB(0, 0, Width, Height);
            Rectangle BorderRect = Rectangle.FromLTRB(0, 0,
                (int)(Width - BorderWidth),
                (int)(Height - BorderWidth));
            Rectangle BackgroundRect = Rectangle.FromLTRB(
                (int)BorderWidth,
                (int)BorderWidth,
                (int)(Width - BorderWidth),
                (int)(Height - BorderWidth));

            // Reset our canvas:
            e.Graphics.FillRectangle(new SolidBrush(Color.White), ButtonRect); // this.Parent.BackColor ?

            // Draw background:
            if (Highlight)
                e.Graphics.FillRectangle(new SolidBrush(HighlightBackColor), BackgroundRect);
            else if (_mouseDown)
                e.Graphics.FillRectangle(new SolidBrush(MouseDownBackColor), BackgroundRect);
            else if (_mouseOver)
                e.Graphics.FillRectangle(new SolidBrush(MouseOverBackColor), BackgroundRect);
            else
                e.Graphics.FillRectangle(new SolidBrush(BackColor), BackgroundRect);

            // Draw border:
            if (BorderWidth >= 1)
            {
                if (_mouseDown)
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(BorderMouseDownColor), BorderWidth), BorderRect);
                else if (_mouseOver)
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(BorderMouseOverColor), BorderWidth), BorderRect);
                else
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(BorderColor), BorderWidth), BorderRect);
            }

            // Draw "Highlight" ribbon:
            if (Highlight)
                e.Graphics.FillRectangle(
                    new SolidBrush(HighlightRibbonColor),
                    Rectangle.FromLTRB(
                        0,
                        0,
                        4,
                        Height));

            // Draw image:
            if (Image != null)
                e.Graphics.DrawImage(this.Image, GetImageRect());

            // Get text size:
            // https://stackoverflow.com/a/48108648
            // Size textSize = TextRenderer.MeasureText(e.Graphics, Text, this.Font);
            SizeF textSize = e.Graphics.MeasureString(Text, this.Font);

            // Draw text:
            e.Graphics.DrawString(Text, this.Font, new SolidBrush(ForeColor), GetTextRect(textSize));
        }

        private RectangleF GetRect(ContentAlignment align, SizeF size, bool forText)
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
                        x = Padding + Image.Width + 10;
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
                    y = Height - size.Height - Padding;
                    break;
            }

            float width = size.Width;
            float height = size.Height;

            return new RectangleF(
                        x,
                        y,
                        width, height);
        }

        private RectangleF GetImageRect ()
        {
            return GetRect(ImageAlign, Image.Size, false);
        }

        private RectangleF GetTextRect(SizeF textSize)
        {
            return GetRect(TextAlign, textSize, true);
        }
    }
}
