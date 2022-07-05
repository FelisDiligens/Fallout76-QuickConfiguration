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

        /*
         * Event handler:
         */

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (PlayClicked != null)
                PlayClicked(sender, e);
        }
        public event EventHandler PlayClicked;

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (ApplyClicked != null)
                ApplyClicked(sender, e);
        }
        public event EventHandler ApplyClicked;

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (SettingsClicked != null)
                SettingsClicked(sender, e);
        }
        public event EventHandler SettingsClicked;

        private void buttonMods_Click(object sender, EventArgs e)
        {
            if (ModsClicked != null)
                ModsClicked(sender, e);
        }
        public event EventHandler ModsClicked;

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateClicked != null)
                UpdateClicked(sender, e);
        }
        public event EventHandler UpdateClicked;

        /*
         * Tool strip stuff
         */

        private void gameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gamesConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolInstallationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void steamScreenshotFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gamePhotosFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editFallout76iniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editFallout76PrefsiniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editFallout76CustominiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
