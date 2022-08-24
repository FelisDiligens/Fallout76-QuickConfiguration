using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    // https://stackoverflow.com/a/29708562
    public class TabControlWithoutHeader : TabControl
    {
        public TabControlWithoutHeader() : base()
        {
            if (!this.DesignMode)
                this.Multiline = true;
        }

        // Unused.
        private void HideTabHeader()
        {
            // https://stackoverflow.com/a/10346520
            this.Appearance = TabAppearance.FlatButtons;
            this.ItemSize = new Size(0, 1);
            this.SizeMode = TabSizeMode.Fixed;
            this.TabStop = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !this.DesignMode)
                m.Result = new IntPtr(1);
            else
                base.WndProc(ref m);
        }
    }
}
