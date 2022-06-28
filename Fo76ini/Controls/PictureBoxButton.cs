using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    /// <summary>
    /// Uses a PictureBox as a button.
    /// Makes use of two images (one for hover over) to make a fancy button.
    /// </summary>
    public class PictureBoxButton : UserControl
    {
        #region Designer Properties

        [Category("Custom")]
        [Description("The image shown when the button is in a normal/untouched state.")]
        public Image Image { get; set; }

        [Category("Custom")]
        [Description("The image shown when you hover over the button.")]
        public Image ImageHover { get; set; }

        [Category("Custom")]
        [Description("The text shown in the center of the button.")]
        public String ButtonText { get; set; }

        private Font _buttonTextFont = DefaultFont; //  new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

        [Bindable(true)]
        [Browsable(true)]
        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Font ButtonTextFont
        {
            get { return _buttonTextFont; }
            set { _buttonTextFont = value; }
        }

        [Category("Custom")]
        public Color ButtonTextColor { get; set; }

        [Category("Custom")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public PictureBoxSizeMode SizeMode { get; set; }

        #endregion

        private PictureBox pictureBox;

        public PictureBoxButton()
        {
            pictureBox = new PictureBox();
            pictureBox.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;
            pictureBox.BackColor = Color.Transparent;
            this.BackColor = Color.Transparent;

            // Necessary to make the click event work...
            pictureBox.Click += (object sender, EventArgs e) => {
                this.OnClick(e);
            };

            this.Controls.Add(pictureBox);
        }

        public void SetImages(Image image, Image imageHover)
        {
            Image = image;
            ImageHover = imageHover;
            pictureBox.Image = Image;
        }

        protected override void OnLoad(EventArgs e)
        {
            pictureBox.Image = Image;
            pictureBox.Size = this.Size;
            pictureBox.SizeMode = SizeMode;

            if (!this.DesignMode)
            {
                pictureBox.Paint += new PaintEventHandler((paintSender, paintEventArgs) =>
                {
                    // Draw the text:
                    paintEventArgs.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    SizeF textSize = paintEventArgs.Graphics.MeasureString(ButtonText, ButtonTextFont);
                    PointF locationToDraw = new PointF();
                    locationToDraw.X = (pictureBox.Width / 2) - (textSize.Width / 2);
                    locationToDraw.Y = (pictureBox.Height / 2) - (textSize.Height / 2);

                    paintEventArgs.Graphics.DrawString(ButtonText, ButtonTextFont, new SolidBrush(ButtonTextColor), locationToDraw);
                });

                pictureBox.MouseEnter += new EventHandler((mouseSender, mouseEventArgs) =>
                {
                    // Set hover image:
                    pictureBox.Image = ImageHover;
                    pictureBox.Cursor = Cursors.Hand;
                });

                pictureBox.MouseLeave += new EventHandler((mouseSender, mouseEventArgs) =>
                {
                    // Set normal image:
                    pictureBox.Image = Image;
                    pictureBox.Cursor = Cursors.Default;
                });
            }
        }
    }
}
