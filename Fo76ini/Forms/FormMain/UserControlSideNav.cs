using Fo76ini.Controls;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
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

        List<StyledButton> tabButtons;
        int selectedTabIndex = -1;

        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                selectedTabIndex = value;
                UpdateNavButtonsHighlight();
            }
        }

        public UserControlSideNav()
        {
            InitializeComponent();
            ProfileManager.ProfileChanged += ProfileManager_ProfileChanged;

            Translation.LanguageChanged += OnLanguageChanged;

            labelLogo.Font = new Font(CustomFonts.Overseer, labelLogo.Font.Size);

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "buttonProfile"
            });

            this.buttonHome.Highlight = true;

            // The order of (tab) buttons have to be the same as the order of tabpages:
            tabButtons = new List<StyledButton>
            {
                this.buttonHome,
                this.buttonTweaks,
                // buttonMods
                this.buttonPipboy,
                this.buttonGallery,
                this.buttonCustom,
                this.buttonSettings,
                this.buttonNexusMods,
                // buttonUpdate
                this.buttonProfile
            };
        }

        private void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            // Change caption
            GameInstance game = ProfileManager.SelectedGame;
            this.buttonProfile.Text = game.Title + "\n" + Localization.GetString("gameEdition") + ": " + game.GetCaption() + "";

            // Change font size
            Font smallButtonFont;
            switch (Localization.Locale)
            {
                case "ru-RU":
                    smallButtonFont = new Font(buttonApply.Font.FontFamily, 8);
                    break;
                case "en-US":
                    smallButtonFont = new Font(buttonApply.Font.FontFamily, 10);
                    break;
                default:
                    smallButtonFont = new Font(buttonApply.Font.FontFamily, 9);
                    break;
            }
            this.buttonPlay.Font = smallButtonFont;
            this.buttonApply.Font = smallButtonFont;
            this.buttonBrowse.Font = smallButtonFont;
        }

        private void ProfileManager_ProfileChanged(object sender, ProfileEventArgs e)
        {
            // Get profile
            GameInstance game = e.ActiveGameInstance;

            // Change image
            this.buttonProfile.Image = game.Get24pxBitmap();

            // Change caption
            this.buttonProfile.Text = game.Title + "\n" + Localization.GetString("gameEdition") + ": " + game.GetCaption() + "";

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

        private void UpdateNavButtonsHighlight()
        {
            foreach (StyledButton button in tabButtons)
                button.Highlight = false;

            if (selectedTabIndex >= 0)
                tabButtons[selectedTabIndex].Highlight = true;
        }

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
