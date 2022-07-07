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
        PrivateFontCollection pfc = new PrivateFontCollection();

        public UserControlSideNav()
        {
            InitializeComponent();
            ProfileManager.ProfileChanged += ProfileManager_ProfileChanged;

            labelLogo.Font = new Font(CustomFonts.Overseer, labelLogo.Font.Size);

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "buttonProfile"
            });

            this.buttonHome.Highlight = true;
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


        #region Navigation buttons

        /*
         * Event handler:
         */

        private void ResetNavButtonsHighlight()
        {
            this.buttonHome.Highlight = false;
            this.buttonSettings.Highlight = false;
            this.buttonCustom.Highlight = false;
            this.buttonGallery.Highlight = false;
            this.buttonProfile.Highlight = false;
            this.buttonTweaks.Highlight = false;
            this.buttonPipboy.Highlight = false;
            this.buttonNexusMods.Highlight = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonSettings.Highlight = true;

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
            ResetNavButtonsHighlight();
            this.buttonHome.Highlight = true;

            if (HomeClicked != null)
                HomeClicked(sender, e);
        }
        public event EventHandler HomeClicked;

        private void buttonTweaks_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonTweaks.Highlight = true;

            if (TweaksClicked != null)
                TweaksClicked(sender, e);
        }
        public event EventHandler TweaksClicked;

        private void buttonPipboy_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonPipboy.Highlight = true;

            if (PipboyClicked != null)
                PipboyClicked(sender, e);
        }
        public event EventHandler PipboyClicked;

        private void buttonGallery_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonGallery.Highlight = true;

            if (GalleryClicked != null)
                GalleryClicked(sender, e);
        }
        public event EventHandler GalleryClicked;

        private void buttonCustom_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonCustom.Highlight = true;

            if (CustomClicked != null)
                CustomClicked(sender, e);
        }
        public event EventHandler CustomClicked;

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonProfile.Highlight = true;

            if (ProfileClicked != null)
                ProfileClicked(sender, e);
        }
        public event EventHandler ProfileClicked;

        private void buttonNexusMods_Click(object sender, EventArgs e)
        {
            ResetNavButtonsHighlight();
            this.buttonNexusMods.Highlight = true;

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
