using System;
using System.Windows.Forms;
using System.Drawing;
using Fo76ini.Utilities;

namespace Fo76ini.Controls
{
    public class PipboyPreview : UserControl
    {
        private Color _previewColor;
        public Color PreviewColor
        {
            get { return _previewColor; }
            set
            {
                _previewColor = value;
                UpdatePreview();
            }
        }

        public Image MaskImage
        {
            get { return mask.Image; }
            set { mask.Image = value; }
        }

        public Image ScreenImage { get; set; }

        public PictureBoxSizeMode SizeMode
        { 
            get { return screen.SizeMode; }
            set
            {
                mask.SizeMode = value;
                screen.SizeMode = value;
            }
        }

        private PictureBox mask;
        private PictureBox screen;

        public PipboyPreview()
        {
            mask = new PictureBox();
            screen = new PictureBox();

            mask.Size = this.Size;
            mask.BackColor = Color.Transparent;
            screen.Size = this.Size;
            screen.BackColor = Color.Transparent;

            screen.Controls.Add(mask);
            this.Controls.Add(screen);
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateControls();
            UpdatePreview();
        }

        public void UpdateControls()
        {
            mask.Image = MaskImage;
            mask.SizeMode = this.SizeMode;
            mask.Size = this.Size;

            screen.Image = ScreenImage;
            screen.SizeMode = this.SizeMode;
            screen.Size = this.Size;
        }

        public void UpdatePreview()
        {
            if (this.screen == null ||
                this.ScreenImage == null ||
                this.PreviewColor == null)
                return;

            Bitmap bmp = new Bitmap(ScreenImage);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int r = (int)Utils.Clamp(oldColor.R / 255.0 * PreviewColor.R, 0, 255);
                    int g = (int)Utils.Clamp(oldColor.G / 255.0 * PreviewColor.G, 0, 255);
                    int b = (int)Utils.Clamp(oldColor.B / 255.0 * PreviewColor.B, 0, 255);
                    Color newColor = Color.FromArgb(oldColor.A, r, g, b);
                    bmp.SetPixel(x, y, newColor);
                }
            }
            screen.Image = bmp;
        }
    }
}
