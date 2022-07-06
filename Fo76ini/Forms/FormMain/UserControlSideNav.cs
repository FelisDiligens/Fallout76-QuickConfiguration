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
using Fo76ini.Utilities;

namespace Fo76ini.Forms.FormMain
{
    public partial class UserControlSideNav : UserControl
    {
        PrivateFontCollection pfc = new PrivateFontCollection();

        public UserControlSideNav()
        {
            InitializeComponent();
            ProfileManager.ProfileChanged += ProfileManager_ProfileChanged; ;

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

        private void ProfileManager_ProfileChanged(object sender, ProfileEventArgs e)
        {
            // Get profile
            GameInstance game = e.ActiveGameInstance;

            // Change image
            this.buttonProfile.Image = game.Get24pxBitmap();

            // Change caption
            this.buttonProfile.Text = game.Title + "\nEdition: " + game.GetCaption() + "";

            // Force redraw
            this.buttonProfile.Refresh();
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

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (HomeClicked != null)
                HomeClicked(sender, e);
        }
        public event EventHandler HomeClicked;

        private void buttonTweaks_Click(object sender, EventArgs e)
        {
            if (TweaksClicked != null)
                TweaksClicked(sender, e);
        }
        public event EventHandler TweaksClicked;

        private void buttonPipboy_Click(object sender, EventArgs e)
        {
            if (PipboyClicked != null)
                PipboyClicked(sender, e);
        }
        public event EventHandler PipboyClicked;

        private void buttonGallery_Click(object sender, EventArgs e)
        {
            if (GalleryClicked != null)
                GalleryClicked(sender, e);
        }
        public event EventHandler GalleryClicked;

        private void buttonCustom_Click(object sender, EventArgs e)
        {
            if (CustomClicked != null)
                CustomClicked(sender, e);
        }
        public event EventHandler CustomClicked;

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            if (ProfileClicked != null)
                ProfileClicked(sender, e);
        }
        public event EventHandler ProfileClicked;

        private void buttonNexusMods_Click(object sender, EventArgs e)
        {
            if (NexusClicked != null)
                NexusClicked(sender, e);
        }
        public event EventHandler NexusClicked;

        /*
         * Tool strip stuff
         */

        private void gameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ProfileManager.SelectedGame.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }
            Utils.OpenExplorer(ProfileManager.SelectedGame.GamePath);
        }

        private void gamesConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(IniFiles.ParentPath);
        }

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppConfigFolder);
        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppTranslationsFolder);
        }

        private void toolInstallationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Directory.GetParent(Application.ExecutablePath).ToString());
        }

        private void steamScreenshotFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string steamFolder = @"C:\Program Files (x86)\Steam\userdata\";
            if (Directory.Exists(steamFolder))
            {
                steamFolder = Path.Combine(Directory.GetDirectories(steamFolder)[0], @"760\remote\1151340\screenshots");
                Utils.OpenExplorer(steamFolder);
            }
        }

        private void gamePhotosFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string photosFolder = Path.Combine(IniFiles.ParentPath, "Photos");
            if (Directory.Exists(photosFolder))
            {
                photosFolder = Directory.GetDirectories(photosFolder)[0];
                Utils.OpenExplorer(photosFolder);
            }
        }

        private void editFallout76iniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76.FilePath))
                Utils.OpenFile(IniFiles.F76.FilePath);
        }

        private void editFallout76PrefsiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Prefs.FilePath))
                Utils.OpenFile(IniFiles.F76Prefs.FilePath);
        }

        private void editFallout76CustominiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Custom.FilePath))
                Utils.OpenFile(IniFiles.F76Custom.FilePath);
        }

        private void UserControlSideNav_Load(object sender, EventArgs e)
        {

        }
    }
}
