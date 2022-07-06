using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Utilities;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain
{
    public partial class UserControlSideNav : UserControl
    {
        // Create your private font collection object.
        PrivateFontCollection pfc = new PrivateFontCollection();

        public UserControlSideNav()
        {
            InitializeComponent();
            ProfileManager.ProfileChanged += ProfileManager_ProfileChanged;

            InitCustomLabelFont();
            labelLogo.Font = new Font(pfc.Families[0], labelLogo.Font.Size);

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "buttonProfile"
            });
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        // https://stackoverflow.com/a/23520042
        // https://stackoverflow.com/questions/1955629/c-sharp-using-an-embedded-font-on-a-textbox/1956043#1956043
        private void InitCustomLabelFont()
        {
            // create a buffer to read in to
            byte[] fontData = Resources.overseer;
            int fontLength = fontData.Length;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, fontLength);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            // free the unsafe memory
            // Marshal.FreeCoTaskMem(data);
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

        #region Button event handler

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

        #endregion

        #region Tool strip

        /*
         * Tool strip
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
        #endregion
    }
}
