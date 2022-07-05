using ComboxExtended;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fo76ini;
using Fo76ini.Ini;
using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormWelcome;
using Fo76ini.Tweaks;

namespace Fo76ini.Forms.FormMain
{
    public partial class UserControlSideNav : UserControl
    {
        PrivateFontCollection pfc = new PrivateFontCollection();

        public UserControlSideNav()
        {
            InitializeComponent();

            InitCustomLabelFont();
            labelLogo.Font = new Font(pfc.Families[0], labelLogo.Font.Size);
        }


        // https://stackoverflow.com/a/23520042
        private void InitCustomLabelFont()
        {
            // Select your font from the resources.
            int fontLength = Properties.Resources.overseer.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.overseer;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (contextMenuStripBrowse.Visible)
                contextMenuStripBrowse.Hide();
            else
                contextMenuStripBrowse.Show(buttonBrowse, new Point(0, buttonBrowse.Height));
        }
    }
}
