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
    public class PictureBoxButton : UserControl
    {
        [Category("Custom")]
        [Description("The button image")]
        public Image Image { get; set; }

        [Category("Custom")]
        [Description("The image shown when you hover over the button.")]
        public Image ImageHover { get; set; }

        [Category("Custom")]
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

        private PictureBox pictureBox;

        public PictureBoxButton()
        {
            pictureBox = new PictureBox();
            pictureBox.Size = this.Size;
            pictureBox.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            // Necessary to make the click event work...
            pictureBox.Click += (object sender, EventArgs e) => {
                this.OnClick(e);
            };

            this.Controls.Add(pictureBox);
        }

        protected override void OnLoad(EventArgs e)
        {
            pictureBox.Image = Image;

            if (!this.DesignMode)
            {
                pictureBox.Paint += new PaintEventHandler((paintSender, paintEventArgs) =>
                {
                    paintEventArgs.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    SizeF textSize = paintEventArgs.Graphics.MeasureString(ButtonText, ButtonTextFont);
                    PointF locationToDraw = new PointF();
                    locationToDraw.X = (pictureBox.Width / 2) - (textSize.Width / 2);
                    locationToDraw.Y = (pictureBox.Height / 2) - (textSize.Height / 2);

                    paintEventArgs.Graphics.DrawString(ButtonText, ButtonTextFont, new SolidBrush(ButtonTextColor), locationToDraw);
                });

                pictureBox.MouseEnter += new EventHandler((mouseSender, mouseEventArgs) =>
                {
                    pictureBox.Image = ImageHover;
                    pictureBox.Cursor = Cursors.Hand;
                });

                pictureBox.MouseLeave += new EventHandler((mouseSender, mouseEventArgs) =>
                {
                    pictureBox.Image = Image;
                    pictureBox.Cursor = Cursors.Default;
                });
            }
        }
    }
}
