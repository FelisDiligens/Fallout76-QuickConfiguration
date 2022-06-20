using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    public class ColorPreview : PictureBox
    {
        public event EventHandler ColorChanged;

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (this.ColorChanged != null)
                    this.ColorChanged(this, new EventArgs());
            }
        }
    }
}
