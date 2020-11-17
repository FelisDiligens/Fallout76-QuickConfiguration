using Fo76ini.Forms.FormNexusAPI;
using Fo76ini.Forms.FormProfiles;
using Fo76ini.Forms.FormSettings;
using Fo76ini.Forms.FormWhatsNew;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class Form1 : Form
    {
        private FormMods formMods;
        private FormWhatsNew formWhatsNew;
        private FormNexus formNexus;
        private FormProfiles formProfiles;

        private GameInstance game;

        public Form1()
        {
            InitializeComponent();

            // Handle changes:
            ProfileManager.ProfileChanged += OnProfileChanged;

            /*
             * Translations
             */

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            form.SpecialControls.Add(this.contextMenuStripGallery);
            Localization.LocalizedForms.Add(form);

            // Handle translations:
            Translation.LanguageChanged += OnLanguageChanged;

            // Assign a dropdown menu to hold languages:
            Localization.AssignDropDown(this.comboBoxLanguage);

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "labelConfigVersion",
                "labelAuthorName",
                "labelTranslationAuthor",
                "groupBoxWIP",
                "labelNewVersion",
                "labelGameEdition",
                "buttonDownloadLanguages",
                "buttonRefreshLanguage"
            });


            /*
             * Dropdowns
             */

            // Let's add options to the drop-down menus:

            // Display resolution usage statistics (and lists):
            // https://store.steampowered.com/hwsurvey/Steam-Hardware-Software-Survey-Welcome-to-Steam
            // https://www.rapidtables.com/web/dev/screen-resolution-statistics.html
            // https://w3codemasters.in/most-common-screen-resolutions/
            // https://www.reneelab.com/video-with-4-3-format.html
            // https://www.overclock.net/threads/list-of-display-resolutions-aspect-ratios.539967/
            // https://en.wikipedia.org/wiki/List_of_common_resolutions
            // TODO: Put iSizeW and iSizeH into Fallout76Custom.ini instead of Prefs.ini: https://www.reddit.com/r/fo76/comments/9z6jan/if_you_change_your_resolution_in/
            DropDown.Add("Resolution", new DropDown(
                this.comboBoxResolution,
                new string[] {
                    "Custom",
                    "",
                    "┌───────────────────────────────┐",
                    "│  4:3                          │",
                    "├───────────────────────────────┤",
                    "│ [4:3]    640 x  480 (VGA)     │",
                    "│ [4:3]    800 x  600 (SVGA)    │",
                    "│ [4:3]    960 x  720           │",
                    "│ [4:3]   1024 x  768 (XGA)     │",
                    "│ [4:3]   1152 x  864           │",
                    "│ [4:3]   1280 x  960           │",
                    "│ [4:3]   1400 x 1050           │",
                    "│ [4:3]   1440 x 1080           │",
                    "│ [4:3]   1600 x 1200           │",
                    "│ [4:3]   1920 x 1440           │",
                    "│ [4:3]   2048 x 1536           │",
                    "│ [4:3]   2880 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:3                          │",
                    "├───────────────────────────────┤",
                    "│ [5:3]    800 x  480           │",
                    "│ [5:3]   1280 x  768 (WXGA)    │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:4                          │",
                    "├───────────────────────────────┤",
                    "│ [5:4]   1152 x  960           │",
                    "│ [5:4]   1280 x 1024           │",
                    "│ [5:4]   2560 x 2048           │",
                    "│ [5:4]   5120 x 4096           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  8:5                          │",
                    "├───────────────────────────────┤",
                    "│ [8:5]   1280 x  800           │",
                    "│ [8:5]   1440 x  900           │",
                    "│ [8:5]   1680 x 1050           │",
                    "│ [8:5]   1920 x 1200           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:9                         │",
                    "├───────────────────────────────┤",
                    "│ [16:9]  1024 x  576           │",
                    "│ [16:9]  1152 x  648           │",
                    "│ [16:9]  1280 x  720 (HD)      │",
                    "│ [16:9]  1360 x  768           │",
                    "│ [16:9]  1365 x  768           │",
                    "│ [16:9]  1366 x  768           │",
                    "│ [16:9]  1536 x  864           │",
                    "│ [16:9]  1600 x  900           │",
                    "│ [16:9]  1920 x 1080 (Full HD) │",
                    "│ [16:9]  2560 x 1440 (WQHD)    │",
                    "│ [16:9]  3200 x 1800           │",
                    "│ [16:9]  3840 x 2160 (4K UHD1) │",
                    "│ [16:9]  5120 x 2880 (5K)      │",
                    "│ [16:9]  7680 x 4320 (8K UHD2) │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:10                        │",
                    "├───────────────────────────────┤",
                    "│ [16:10]  640 x  400           │",
                    "│ [16:10] 1280 x  800           │",
                    "│ [16:10] 1440 x  900           │",
                    "│ [16:10] 1680 x 1050           │",
                    "│ [16:10] 1920 x 1200           │",
                    "│ [16:10] 2560 x 1600           │",
                    "│ [16:10] 3840 x 2400           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  17:9                         │",
                    "├───────────────────────────────┤",
                    "│ [17:9]  2048 x 1080           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  21:9                         │",
                    "├───────────────────────────────┤",
                    "│ [21:9]  1920 x  800           │",
                    "│ [21:9]  2560 x 1080           │",
                    "│ [21:9]  3440 x 1440           │",
                    "│ [21:9]  3840 x 1600           │",
                    "│ [21:9]  5120 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "└───────────────────────────────┘",
                    ""
                }
            ));

            DropDown.Add("DisplayMode", new DropDown(
                this.comboBoxDisplayMode,
                new string[] {
                    "Fullscreen",
                    "Windowed",
                    "Borderless windowed",
                    "Borderless windowed (Fullscreen)"
                }
            ));

            DropDown.Add("AntiAliasing", new DropDown(
                this.comboBoxAntiAliasing,
                new string[] {
                    "TAA (default)",
                    "FXAA",
                    "Disabled"
                }
            ));

            DropDown.Add("AnisotropicFiltering", new DropDown(
                this.comboBoxAnisotropicFiltering,
                new string[] {
                    "None",
                    "2x",
                    "4x",
                    "8x (default)",
                    "16x"
                }
            ));

            DropDown.Add("ShadowTextureResolution", new DropDown(
                this.comboBoxShadowTextureResolution,
                new string[] {
                    "512 = Potato",
                    "1024 = Low",
                    "2048 = High (default)",
                    "4096 = Ultra"
                }
            ));

            DropDown.Add("ShadowBlurriness", new DropDown(
                this.comboBoxShadowBlurriness,
                new string[] {
                    "1x",
                    "2x",
                    "3x = Default, recommended"
                }
            ));

            DropDown.Add("Files", new DropDown(
                this.comboBoxCustomFile,
                new string[] {
                    "Fallout76.ini",
                    "Fallout76Prefs.ini",
                    "Fallout76Custom.ini"
                }
            ));
            this.comboBoxCustomFile.SelectedIndex = 0;

            DropDown.Add("VoiceChatMode", new DropDown(
                this.comboBoxVoiceChatMode,
                new string[] {
                    "Auto",
                    "Area",
                    "Team",
                    "None"
                }
            ));

            DropDown.Add("ShowActiveEffectsOnHUD", new DropDown(
                this.comboBoxShowActiveEffectsOnHUD,
                new string[] {
                    "Disabled",
                    "Detrimental",
                    "All"
                }
            ));

            DropDown.Add("iDirShadowSplits", new DropDown(
                this.comboBoxiDirShadowSplits,
                new string[] {
                    "1 - Low",
                    "2 - High / Medium",
                    "3 - Ultra"
                }
            ));


            /*
             * Event handlers:
             */

            // Disable scroll wheel on UI elements to prevent the user from accidentally changing values:
            PreventChangeOnMouseWheelForAllElements(this);

            // Event handler:
            this.FormClosing += this.Form1_FormClosing;
            this.Shown += this.Form1_Shown;
            this.KeyDown += this.Form1_KeyDown;

            this.backgroundWorkerGetLatestVersion.RunWorkerCompleted += backgroundWorkerGetLatestVersion_RunWorkerCompleted;
            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += backgroundWorkerDownloadLanguages_RunWorkerCompleted;

            this.backgroundWorkerEnableNWMode.RunWorkerCompleted += backgroundWorkerEnableNWMode_RunWorkerCompleted;
            this.backgroundWorkerDisableNWMode.RunWorkerCompleted += backgroundWorkerDisableNWMode_RunWorkerCompleted;


            // TODO: Pipboy screen preview
            InitPipboyScreen();
            this.colorPreviewPipboy.BackColorChanged += colorPreviewPipboy_BackColorChanged;
        }

        private PictureBox maskedPipScreen;
        private PictureBox colorizedPipScreen;

        private void InitPipboyScreen()
        {
            maskedPipScreen = new PictureBox();
            maskedPipScreen.Image = Resources.pipboy_preview_fg_masked;
            maskedPipScreen.SizeMode = this.pictureBoxPipboyPreview.SizeMode;
            maskedPipScreen.Size = this.pictureBoxPipboyPreview.Size;

            colorizedPipScreen = new PictureBox();
            colorizedPipScreen.Image = Resources.pipboy_preview_fg;
            colorizedPipScreen.SizeMode = this.pictureBoxPipboyPreview.SizeMode;
            colorizedPipScreen.Size = this.pictureBoxPipboyPreview.Size;

            colorizedPipScreen.Controls.Add(maskedPipScreen);
            this.pictureBoxPipboyPreview.Controls.Add(colorizedPipScreen);
        }

        private void UpdatePipboyScreen(Color targetColor)
        {
            Bitmap bmp = new Bitmap(Resources.pipboy_preview_fg);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int r = (int)Utils.Clamp(oldColor.R / 255.0 * targetColor.R, 0, 255);
                    int g = (int)Utils.Clamp(oldColor.G / 255.0 * targetColor.G, 0, 255);
                    int b = (int)Utils.Clamp(oldColor.B / 255.0 * targetColor.B, 0, 255);
                    Color newColor = Color.FromArgb(oldColor.A, r, g, b);
                    bmp.SetPixel(x, y, newColor);
                }
            }
            colorizedPipScreen.Image = bmp;
        }

        private void colorPreviewPipboy_BackColorChanged(object sender, EventArgs e)
        {
            UpdatePipboyScreen(this.colorPreviewPipboy.BackColor);
        }

        // Winforms Double Buffering
        // https://stackoverflow.com/questions/3718380/winforms-double-buffering/3718648#3718648
        // fixes the visual artifacts when scrolling
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// Disable scroll wheel on UI elements (NumericUpDown and ComboBox) to prevent the user from accidentally changing values
        /// </summary>
        private void PreventChangeOnMouseWheelForAllElements(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                // NumericUpDown and ComboBox:
                if (subControl.Name.StartsWith("num") || subControl.Name.StartsWith("comboBox") || subControl.Name.StartsWith("slider"))
                    subControl.MouseWheel += (object sender, MouseEventArgs e) => ((HandledMouseEventArgs)e).Handled = true;

                // TabControl, TabPage, and GroupBox:
                if (subControl.Name.StartsWith("tab") || subControl.Name.StartsWith("groupBox") || subControl.Name.StartsWith("panel"))
                    PreventChangeOnMouseWheelForAllElements(subControl);
            }
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            try
            {
                IniFiles.Load(game);
            }
            catch (IniParser.Exceptions.ParsingException exc)
            {
                // TODO: Uhh......
                MsgBox.Get("iniParsingError").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                //Application.Exit();
                return;
            }
            catch (FileNotFoundException exc)
            {
                // TODO: Format changed, msgbox broken
                // TODO: We should warn, or ask to generate new files, I guess...
                //MsgBox.Get("runGameToGenerateINI").FormatTitle(IniFiles.Instance.GetIniName(LegacyIniFile.F76), IniFiles.Instance.GetIniName(LegacyIniFile.F76Prefs)).Show(MessageBoxButtons.OK, MessageBoxIcon.Error);
                MsgBox.Get("runGameToGenerateINI").Show(MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                return;
            }
            LinkedTweaks.LoadValues();

            // Change image
            switch (e.ActiveGameInstance.Edition)
            {
                case GameEdition.Steam:
                    this.pictureBoxGameEdition.Image = Properties.Resources.steam;
                    this.toolStripStatusLabelEditionText.Text = "Steam";
                    this.labelGameEdition.Text = "Steam";
                    break;
                case GameEdition.BethesdaNet:
                    this.pictureBoxGameEdition.Image = Properties.Resources.bethesda;
                    this.toolStripStatusLabelEditionText.Text = "Bethesda.net";
                    this.labelGameEdition.Text = "Bethesda";
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.pictureBoxGameEdition.Image = Properties.Resources.bethesda_pts;
                    this.toolStripStatusLabelEditionText.Text = "Bethesda.net (PTS)";
                    this.labelGameEdition.Text = "Bethesda\n(PTS)";
                    break;
                case GameEdition.MSStore:
                    this.pictureBoxGameEdition.Image = Properties.Resources.msstore;
                    this.toolStripStatusLabelEditionText.Text = "Microsoft Store";
                    this.labelGameEdition.Text = "Microsoft\nStore";
                    break;
                default:
                    this.pictureBoxGameEdition.Image = Properties.Resources.help_128;
                    this.toolStripStatusLabelEditionText.Text = "?";
                    this.labelGameEdition.Text = "Unknown";
                    break;
            }

            this.toolStripStatusLabelGameText.Text = e.ActiveGameInstance?.Title;
            this.toolStripStatusLabelProfileText.Text = e.ActiveProfile?.Name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create folders, if not present:
            Directory.CreateDirectory(Shared.AppConfigFolder);
            Directory.CreateDirectory(Localization.LanguageFolder);

            // Link tweaks
            LinkInfo();
            LinkSliders();
            LinkControlsToTweaks();

            // Load config.ini
            IniFiles.LoadConfig();

            // Load game instances
            ProfileManager.Load();
            formProfiles = new FormProfiles();

            // TODO: Uh... where to put this?
            IniFiles.Config.Set("General", "sPreviousVersion", Shared.VERSION);

            // Load translations
            LinkedTweaks.SetToolTips(this.toolTip);
            Localization.GenerateDefaultTemplate();
            Localization.LookupLanguages();

            // TODO: Do we still need this?
            //this.timerCheckFiles.Enabled = true;

            // TODO: NW MODE BROKEN
            //LoadNuclearWinterConfiguration();

            // Load mods:
            /*ManagedMods.Instance.Load();*/
            NexusMods.Load();
            //TODO: this.formMods.LoadMods(Shared.GamePath);
            //this.formMods.UpdateUI();

            // Account profiles:
            // TODO: Account profiles
            /*this.accountProfileRadioButtons = new RadioButton[] { this.radioButtonAccount1, this.radioButtonAccount2, this.radioButtonAccount3, this.radioButtonAccount4, this.radioButtonAccount5, this.radioButtonAccount6, this.radioButtonAccount7, this.radioButtonAccount8 };
            foreach (RadioButton rbutton in this.accountProfileRadioButtons)
                rbutton.CheckedChanged += new System.EventHandler(this.radioButtonAccount_CheckedChanged);*/

            // Setup UI:
            UpdateCameraPositionUI(); // TODO: Rework camera UI

            Configuration.LoadWindowState("Form1", this);

            // Remove updater, if present:
            try
            {
                string updaterPath = Path.Combine(Shared.AppConfigFolder, "Updater");
                if (Directory.Exists(updaterPath))
                    Directory.Delete(updaterPath, true);
            }
            catch
            {
                // Yeah, well or not.
            }

            this.LoadGallery(); // TODO: Rework gallery

            MakePictureBoxButton(this.pictureBoxUpdateButton, "updateNowButton");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Check display resolution
            Size res = Utils.GetDisplayResolution();
            if (res.Width < 920 || res.Height < 750)
                MsgBox.Get("displayResolutionTooLow").FormatText($"{res.Width} x {res.Height}", "920 x 750").Show(MessageBoxIcon.Warning);

            // Check for updates
            CheckVersion();

            // Display "What's new?" dialog
            if (!IniFiles.Config.GetBool("Preferences", "bIgnoreUpdates", false))
                ShowWhatsNewConditionally();
        }

        private void ShowWhatsNewConditionally()
        {
            if (!IniFiles.Config.GetBool("Preferences", "bDisableWhatsNew", false) &&
                Utils.CompareVersions(Shared.VERSION, IniFiles.Config.GetString("General", "sPreviousVersion", "1.0.0")) > 0 &&
                (Shared.LatestVersion == null || Utils.CompareVersions(Shared.LatestVersion, Shared.VERSION) == 0))
                ShowWhatsNew();
        }

        private void ShowWhatsNew()
        {
            if (this.formWhatsNew == null)
                this.formWhatsNew = new FormWhatsNew();
            this.formWhatsNew.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // TODO: Do we need this?
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Configuration.SaveWindowState("Form1", this);
                if (IniFiles.Config.GetBool("Preferences", "bAutoApply", false))
                    ApplyChanges();
            }
        }

        /*
         **************************************************************
         * Check version
         **************************************************************
         */

        #region Check version

        public void CheckVersion(bool force = false)
        {
            if (this.backgroundWorkerGetLatestVersion.IsBusy)
                return;

            this.labelConfigVersion.Text = Shared.VERSION;
            IniFiles.Config.Set("General", "sVersion", Shared.VERSION);

            panelUpdate.Visible = false;

            if (!force && IniFiles.Config.GetBool("Preferences", "bIgnoreUpdates", false))
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                return;
            }

            this.labelConfigVersion.ForeColor = Color.Gray;
            this.pictureBoxSpinnerCheckForUpdates.Visible = true;

            // Checking version in background:
            this.backgroundWorkerGetLatestVersion.RunWorkerAsync();
        }

        private void backgroundWorkerGetLatestVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            Versioning.GetLatestVersion();
        }

        private void backgroundWorkerGetLatestVersion_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;

            // ShowWhatsNewConditionally(); // TODO: Why is this here though?

            // Failed:
            if (Shared.LatestVersion == null)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                panelUpdate.Visible = false;
                return;
            }

            if (Versioning.UpdateAvailable)
            {
                panelUpdate.Visible = true;
                labelNewVersion.Text = string.Format(Localization.GetString("newVersionAvailable"), Shared.LatestVersion);
                labelNewVersion.ForeColor = Color.Crimson;
                this.labelConfigVersion.ForeColor = Color.Red;
            }
            else
            {
                // All good, latest version:
                panelUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkGreen;
            }
        }

        #endregion

        /*
         **************************************************************
         * Event handlers
         **************************************************************
         */

        #region Nuclear Winter Mode
        // Nuclear Winter mode

        private void toolStripButtonToggleNuclearWinterMode_Click(object sender, EventArgs e)
        {
            if (Shared.NuclearWinterMode)
                DisableNuclearWinterMode();
            else
                EnableNuclearWinterMode();
        }

        private void RefreshNWModeButtonAppearance()
        {
            if (Shared.NuclearWinterMode)
            {
                this.toolStripButtonToggleNuclearWinterMode.Text = Localization.GetString("adventuremode");
                this.toolStripButtonToggleNuclearWinterMode.Image = Resources.adventures;
            }
            else
            {
                this.toolStripButtonToggleNuclearWinterMode.Text = Localization.GetString("nuclearwintermode");
                this.toolStripButtonToggleNuclearWinterMode.Image = Resources.fire;
            }
        }

        private void LoadNuclearWinterConfiguration()
        {
            // NW mode enabled?
            Shared.NuclearWinterMode = Configuration.bNWMode;

            // Show label:
            this.labelNWModeActive.Visible = Shared.NuclearWinterMode;

            // Fallout76Custom.ini renamed?
            // TODO: NW mode broke
            //IniFiles.Instance.renameF76Custom = Shared.NuclearWinterMode && IniFiles.Config.GetBool("NuclearWinter", "bRenameCustomINI", true);

            // Change button appearance:
            RefreshNWModeButtonAppearance();
        }

        public void DisableUI()
        {
            this.pictureBoxLoadingGIF.Visible = true;
            this.pictureBoxLoadingGIF.Width = this.Width;
        }

        public void EnableUI()
        {
            this.pictureBoxLoadingGIF.Visible = false;
        }

        private void EnableNuclearWinterMode()
        {
            DisableUI();
            this.backgroundWorkerEnableNWMode.RunWorkerAsync();
            this.labelNWModeActive.Visible = true;
        }

        private void DisableNuclearWinterMode()
        {
            DisableUI();
            this.backgroundWorkerDisableNWMode.RunWorkerAsync();
            this.labelNWModeActive.Visible = false;
        }

        private void backgroundWorkerEnableNWMode_DoWork(object sender, DoWorkEventArgs e)
        {
            // TODO: NW MODE broken
            return;

            Shared.NuclearWinterMode = true;

            /*
             * Fallout76Custom.ini:
             */
            // Remove resource lists:
            // TODO: NW MODE broken

            // Rename *.ini:
            //IniFiles.Instance.renameF76Custom = IniFiles.Config.GetBool("NuclearWinter", "bRenameCustomINI", true);
            //IniFiles.Instance.ResolveNWMode();


            /*
             * Mods:
             */

            // Mods are deployed, automatically disable mods?
            /*if (!ManagedMods.Instance.ModsDisabled && Configuration.bAutoDisableMods)
            {
                ManagedMods.Instance.ModsDisabled = true;
                this.Invoke(this.formMods.OpenUI);
                this.formMods.Deploy();
                this.Invoke(this.formMods.Hide);
                this.Invoke(() => { this.Focus(); });
            }*/


            /*
             * *.dll's:
             */

            // Rename added *.dll files:
            /*if (Configuration.bRenameDLLs)
                ManagedMods.Instance.RenameAddedDLLs();*/


            /*
             * Configuration:
             */

            // Save configuration:
            Configuration.bNWMode = true;
            //IniFiles.Instance.SaveAll();
        }

        private void backgroundWorkerDisableNWMode_DoWork(object sender, DoWorkEventArgs e)
        {
            // TODO: NW MODE broken
            return;

            Shared.NuclearWinterMode = false;

            /*
             * Fallout76Custom.ini:
             */
            // Restore archive lists:

            // Restore *.ini:
            //IniFiles.Instance.renameF76Custom = false;
            //IniFiles.Instance.ResolveNWMode();


            /*
             * Mods:
             */

            // Mods haven't been deployed yet, automatically enable mods?
            /*if (ManagedMods.Instance.ModsDisabled &&
                ManagedMods.Instance.Mods.Count() > 0 &&
                Configuration.bAutoDisableMods)
            {
                ManagedMods.Instance.ModsDisabled = false;
                this.Invoke(this.formMods.OpenUI);
                this.formMods.Deploy();
                this.Invoke(this.formMods.Hide);
                this.Invoke(() => { this.Focus(); });
            }*/


            /*
             * *.dll's:
             */

            // Restore added *.dll files:
            //ManagedMods.Instance.RestoreAddedDLLs();


            /*
             * Configuration:
             */

            // Save configuration:
            Configuration.bNWMode = false;
            //IniFiles.Instance.SaveAll();
        }

        private void backgroundWorkerEnableNWMode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Popup:
            MsgBox.Get("nwModeEnabled").Popup(MessageBoxIcon.Information);

            RefreshNWModeButtonAppearance();
            EnableUI();
        }

        private void backgroundWorkerDisableNWMode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Popup:
            MsgBox.Get("nwModeDisabled").Popup(MessageBoxIcon.Information);

            RefreshNWModeButtonAppearance();
            EnableUI();
        }
        #endregion

        #region Apply, Launch, and so on.
        public void ApplyChanges()
        {
            // Add custom lines to *.ini files:
            /*try
            {
                string f76Path = Path.Combine(IniFiles.ParentPath, "Fallout76.add.ini");
                if (File.Exists(f76Path))
                {
                    IniData f76Data = IniFiles.Instance.LoadIni(f76Path, false);
                    IniFiles.Instance.Merge(LegacyIniFile.F76, f76Data);
                }

                string f76PPath = Path.Combine(IniFiles.Instance.iniParentPath, "Fallout76Prefs.add.ini");
                if (File.Exists(f76PPath))
                {
                    IniData f76PData = IniFiles.Instance.LoadIni(f76PPath, false);
                    IniFiles.Instance.Merge(LegacyIniFile.F76Prefs, f76PData);
                }

                string f76CPath = Path.Combine(IniFiles.Instance.iniParentPath, "Fallout76Custom.add.ini");
                if (File.Exists(f76CPath))
                {
                    IniData f76CData = IniFiles.Instance.LoadIni(f76CPath, false);
                    IniFiles.Instance.Merge(LegacyIniFile.F76Custom, f76CData);
                }
            }
            catch (IniParser.Exceptions.ParsingException e)
            {
                MsgBox.Get("customIniFilesParsingError").FormatText(e.Message).Show(MessageBoxIcon.Error);
            }*/

            // Save changes:
            IniFiles.Save();
            //IniFiles.Instance.ResolveNWMode();
        }

        // "Apply" button:
        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            //TODO: Rework THIS!
            // Show a messagebox to ask the user, if they want to make a backup.
            if (!IniFiles.Config.GetBool("Preferences", "bSkipBackupQuestion", false))
            {
                DialogResult res = MsgBox.Get("backupAndSave").Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    return;
                //else if (res == DialogResult.Yes)
                // Make backups
                //IniFiles.Instance.BackupAll();
            }

            // Save stuff to INI
            ApplyChanges();
            MsgBox.Get("changesApplied").Popup(MessageBoxIcon.Information);
        }

        // [ ] "Make *.ini files read-only" checkbox:
        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.SetINIsReadOnly(this.checkBoxReadOnly.Checked);
        }

        // "Launch Game" button:
        private void toolStripSplitButtonLaunchGame_ButtonClick(object sender, EventArgs e)
        {
            uint uGameEdition = IniFiles.Config.GetUInt("Preferences", "uGameEdition", 0);
            uint uLaunchOption = IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1);
            string process = null;
            bool runExecutable = false;
            if (uLaunchOption == 1)
            {
                switch (uGameEdition)
                {
                    case (uint)GameEdition.BethesdaNet:
                        process = "bethesdanet://run/20";
                        break;
                    case (uint)GameEdition.Steam:
                        process = "steam://run/1151340"; // "steam://runappid/1151340"
                        break;
                    case (uint)GameEdition.BethesdaNetPTS:
                        process = "bethesdanet://run/57";
                        break;
                    case (uint)GameEdition.MSStore:
                        process = "ms-windows-store://pdp/?ProductId=9nkgnmnk3k3z";
                        break;
                    default:
                        MsgBox.Get("chooseGameEdition").Show(MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
            }
            else if (uLaunchOption == 2)
            {
                if (!Shared.ValidateGamePath())
                {
                    MsgBox.Get("modsGamePathNotSet").Show(MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                process = Path.GetFullPath(Path.Combine(Shared.GamePath, Shared.GameEdition == GameEdition.MSStore ? "Project76_GamePass.exe" : "Fallout76.exe"));
                runExecutable = true;
            }
            if (process != null)
            {
                if (IniFiles.Config.GetBool("Preferences", "bAutoApply", false))
                    ApplyChanges();
                try
                {
                    if (runExecutable)
                    {
                        // https://stackoverflow.com/questions/8720594/application-crashing-on-startup-using-process-start
                        // https://www.vbforums.com/showthread.php?489619-RESOLVED-2-0-Process-Start()-crashing-external-app
                        Process pr = new Process();
                        pr.StartInfo.FileName = process; // Shared.GameEdition == GameEdition.MSStore ? "Project76_GamePass.exe" : "Fallout76.exe";
                        pr.StartInfo.WorkingDirectory = Shared.GamePath;
                        pr.StartInfo.UseShellExecute = false;
                        pr.Start();
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(process);
                    }
                    if (IniFiles.Config.GetBool("Preferences", "bQuitOnLaunch", false))
                        this.Close();
                }
                catch (Exception ex)
                {
                    if (Shared.GameEdition == GameEdition.MSStore)
                    {
                        MsgBox.Get("msstoreRunExecutableFailed").FormatTitle(ex.Message).Show(MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        #endregion

        #region Event handlers

        // "Get the latest version from NexusMods" link:
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelManualDownloadPage.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.nexusmods.com/fallout76/mods/546?tab=files");
        }


        /*
         * Pipboy
         */

        private void buttonPipboyTargetReset_Click(object sender, EventArgs e)
        {
            this.numPipboyTargetWidth.Value = 876;
            this.numPipboyTargetHeight.Value = 700;
        }

        private void buttonPipboyTargetSetRecommended_Click(object sender, EventArgs e)
        {
            this.numPipboyTargetWidth.Value = 1752;
            this.numPipboyTargetHeight.Value = 1400;
        }



        private void toolStripButtonManageMods_Click(object sender, EventArgs e)
        {
            /*if (!formModsBackupCreated)
            {
                IniFiles.Instance.BackupAll("Backup_BeforeManageMods"); // Just to be sure...
                formModsBackupCreated = true;
            }*/
            this.formMods.OpenUI();
        }

        /*
         * Game edition
         */

        private void ChangeGameEdition(GameEdition edition)
        {
            // TODO
            /*
            bool restartRequired = Shared.GameEdition != GameEdition.Unknown && ((Shared.GameEdition == GameEdition.MSStore && edition != GameEdition.MSStore) || (Shared.GameEdition != GameEdition.MSStore && edition == GameEdition.MSStore));

            if (restartRequired && MsgBox.Get("msstoreRestartRequired").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                switch (Shared.GameEdition)
                {
                    case GameEdition.Steam:
                        this.radioButtonEditionSteam.Checked = true;
                        break;
                    case GameEdition.BethesdaNet:
                        this.radioButtonEditionBethesdaNet.Checked = true;
                        break;
                    case GameEdition.BethesdaNetPTS:
                        this.radioButtonEditionBethesdaNetPTS.Checked = true;
                        break;
                    case GameEdition.MSStore:
                        this.radioButtonEditionMSStore.Checked = true;
                        break;
                }
                return;
            }

            // Change image
            switch (edition)
            {
                case GameEdition.Steam:
                    this.pictureBoxGameEdition.Image = Properties.Resources.steam;
                    this.labelGameEdition.Text = "Steam";
                    break;
                case GameEdition.BethesdaNet:
                    this.pictureBoxGameEdition.Image = Properties.Resources.bethesda;
                    this.labelGameEdition.Text = "Bethesda";
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.pictureBoxGameEdition.Image = Properties.Resources.bethesda_pts;
                    this.labelGameEdition.Text = "Bethesda\n(PTS)";
                    break;
                case GameEdition.MSStore:
                    this.pictureBoxGameEdition.Image = Properties.Resources.msstore;
                    this.labelGameEdition.Text = "Microsoft\nStore";
                    break;
                default:
                    this.pictureBoxGameEdition.Image = Properties.Resources.help_128;
                    this.labelGameEdition.Text = "Unknown";
                    break;
            }

            // Currently, no way to launch game executable, if installed via MS Store:
            /*if (edition == GameEdition.MSStore)
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "uLaunchOption", 1);

                this.radioButtonLaunchViaExecutable.Checked = false;
                this.radioButtonLaunchViaExecutable.Enabled = false;
                this.radioButtonLaunchViaLink.Checked = true;
            }
            else
            {
                this.radioButtonLaunchViaExecutable.Enabled = true;
            }*/
            /*
            Shared.ChangeGameEdition(edition);
            //this.formMods.ChangeGameEdition(edition);
            this.formMods.UpdateUI();
            this.textBoxGamePath.Text = Shared.GamePath;

            if (restartRequired)
            {
                Configuration.SaveWindowState("Form1", this);
                Application.Restart();
            }*/
        }

        // Show password:
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/8185747/how-can-i-unmask-password-text-box-and-mask-it-back-to-password
            this.textBoxPassword.UseSystemPasswordChar = !this.checkBoxShowPassword.Checked;
            this.textBoxPassword.PasswordChar = !this.checkBoxShowPassword.Checked ? '\u2022' : '\0';
        }

        private void checkBoxQuitOnGameLaunch_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Preferences", "bQuitOnLaunch", this.checkBoxQuitOnGameLaunch.Checked);
        }

        private void checkBoxAutoApply_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Preferences", "bAutoApply", this.checkBoxAutoApply.Checked);
        }

        private void buttonUpdateNow_Click(object sender, EventArgs e)
        {
            // Set sInstallationPath:
            string installationPath = Path.GetFullPath(AppContext.BaseDirectory);
            IniFiles.Config.Set("Updater", "sInstallationPath", installationPath);
            IniFiles.Config.Save();

            // Copy updater.exe to <config-path>\Updater\:
            string updaterPath = Path.Combine(Shared.AppConfigFolder, "Updater");
            Directory.CreateDirectory(updaterPath);
            Directory.CreateDirectory(Path.Combine(updaterPath, "7z"));
            foreach (string file in Directory.EnumerateFiles(Shared.AppInstallationFolder, "*", SearchOption.AllDirectories))
                File.Copy(file, Path.Combine(updaterPath, file), true);

            // Run updater.exe:
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(updaterPath, "updater.exe");
            // If the program is installed into C:\Program Files (x86)\ then run the updater as admin:
            if (installationPath.Contains("C:\\Program Files"))
                startInfo.Verb = "runas";
            Process.Start(startInfo);
            Application.Exit();
        }

        private void checkBoxIgnoreUpdates_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Preferences", "bIgnoreUpdates", this.checkBoxIgnoreUpdates.Checked);
            this.CheckVersion();
        }


        /*
         * Tool strip:
         */

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppConfigFolder);
        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Localization.LanguageFolder);
        }

        private void toolInstallationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Directory.GetParent(Application.ExecutablePath).ToString());
        }

        private void gameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.GamePath);
        }

        private void gamesConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(IniFiles.ParentPath);
        }

        private void toolStripButtonNexusMods_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nexusmods.com/fallout76/mods/546");
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckVersion(true);
        }

        private void showUpdaterlogtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Shared.AppConfigFolder, "update.log.txt")))
                Utils.OpenNotepad(Path.Combine(Shared.AppConfigFolder, "update.log.txt"));
        }

        private string customAddFilePath = "";

        private void comboBoxCustomFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = "Invalid.add.ini";
            switch (this.comboBoxCustomFile.SelectedIndex)
            {
                case 0:
                    fileName = "Fallout76.add.ini";
                    break;
                case 1:
                    fileName = "Fallout76Prefs.add.ini";
                    break;
                case 2:
                    fileName = "Fallout76Custom.add.ini";
                    break;
            }
            this.customAddFilePath = Path.Combine(IniFiles.ParentPath, fileName);

            if (File.Exists(this.customAddFilePath))
                this.textBoxCustom.Text = File.ReadAllText(this.customAddFilePath);
            else
                this.textBoxCustom.Text = "";

            this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void textBoxCustom_TextChanged(object sender, EventArgs e)
        {
            if (!this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text += "*";
        }

        private void buttonCustomSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxCustom.Text == "")
            {
                if (File.Exists(this.customAddFilePath))
                    File.Delete(this.customAddFilePath);
            }
            else
            {
                File.WriteAllText(this.customAddFilePath, this.textBoxCustom.Text);
            }

            if (this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void editFallout76iniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76.Path))
                Utils.OpenNotepad(IniFiles.F76.Path);
        }

        private void editFallout76PrefsiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Prefs.Path))
                Utils.OpenNotepad(IniFiles.F76Prefs.Path);
        }

        private void editFallout76CustominiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Custom.Path))
                Utils.OpenNotepad(IniFiles.F76Custom.Path);
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

        private int GetSelectedAccountProfile()
        {
            // TODO: Account profiles
            int index = 0;
            /*foreach (RadioButton rbutton in this.accountProfileRadioButtons)
            {
                if (rbutton.Checked)
                    break;
                index++;
            }
            if (index >= this.accountProfileRadioButtons.Length)
                index = 0;*/
            return index;
        }

        private void checkBoxAlternativeINIMode_CheckedChanged(object sender, EventArgs e)
        {/*
            if (MsgBox.ShowID("restartRequired", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IniFiles.Instance.SaveConfig();
                //Application.Exit();
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                this.checkBoxAlternativeINIMode.Checked = altMode;
            }*/
        }


        /*
         * Credentials
         */

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfile();
            if (this.textBoxUserName.Text == "")
                IniFiles.Config.Remove("Login", $"s76UserName{index + 1}");
            else
                IniFiles.Config.Set("Login", $"s76UserName{index + 1}", this.textBoxUserName.Text);
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfile();
            if (this.textBoxPassword.Text == "")
                IniFiles.Config.Remove("Login", $"s76Password{index + 1}");
            else
                IniFiles.Config.Set("Login", $"s76Password{index + 1}", this.textBoxPassword.Text);
        }

        private void radioButtonAccount_CheckedChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfile();
            this.textBoxUserName.Text = IniFiles.Config.GetString("Login", $"s76UserName{index + 1}", "");
            this.textBoxPassword.Text = IniFiles.Config.GetString("Login", $"s76Password{index + 1}", "");
        }

        private void MakePictureBoxButton(PictureBox pictureBox, string localizedStringID)
        {
            pictureBox.Paint += new PaintEventHandler((paintSender, paintEventArgs) =>
            {
                paintEventArgs.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string text = Localization.GetString(localizedStringID);

                Font font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

                SizeF textSize = paintEventArgs.Graphics.MeasureString(text, font);
                PointF locationToDraw = new PointF();
                locationToDraw.X = (pictureBox.Width / 2) - (textSize.Width / 2);
                locationToDraw.Y = (pictureBox.Height / 2) - (textSize.Height / 2);

                paintEventArgs.Graphics.DrawString(text, font, Brushes.White, locationToDraw);
            });
            pictureBox.MouseEnter += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                pictureBox.Image = Resources.button_hover;
                pictureBox.Cursor = Cursors.Hand;
            });
            pictureBox.MouseLeave += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                pictureBox.Image = Resources.button;
                pictureBox.Cursor = Cursors.Default;
            });
        }

        private void launchViaSteamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Launch Steam version:
            System.Diagnostics.Process.Start("steam://run/1151340");
        }

        private void launchViaBethesdanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Launch Bethesda.net version:
            string gamePath = IniFiles.Config.GetString("Preferences", "sGamePathBethesdaNet", "");
            string execPath = Path.GetFullPath(Path.Combine(gamePath, "Fallout76.exe"));

            uint uLaunchOption = IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1);

            if (uLaunchOption == 1 || !File.Exists(execPath))
                System.Diagnostics.Process.Start("bethesdanet://run/20");
            else
            {
                Process pr = new Process();
                pr.StartInfo.FileName = execPath;
                pr.StartInfo.WorkingDirectory = gamePath;
                pr.StartInfo.UseShellExecute = false;
                pr.Start();
            }
        }

        private void launchViaBethesdanetPTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Launch Bethesda.net (PTS) version:
            string gamePath = IniFiles.Config.GetString("Preferences", "sGamePathBethesdaNetPTS", "");
            string execPath = Path.GetFullPath(Path.Combine(gamePath, "Fallout76.exe"));

            uint uLaunchOption = IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1);

            if (uLaunchOption == 1 || !File.Exists(execPath))
                System.Diagnostics.Process.Start("bethesdanet://run/57");
            else
            {
                Process pr = new Process();
                pr.StartInfo.FileName = execPath;
                pr.StartInfo.WorkingDirectory = gamePath;
                pr.StartInfo.UseShellExecute = false;
                pr.Start();
            }
        }



        // Check, if *.ini files have been changed:
        private void timerCheckFiles_Tick(object sender, EventArgs e)
        {
            // TODO: Do we reeeeaaally need this?
            // Check every 5 seconds, if files have been modified:
            /*if (IniFiles.FilesHaveBeenModified())
            {
                IniFiles.UpdateLastModifiedDates();

                // Don't prompt, if Fallout 76 is running....
                if (Shared.GameEdition == GameEdition.MSStore ?
                        //!Utils.IsProcessRunning("Project76_GamePass") :
                        !Utils.IsProcessRunning("Project76") :
                        !Utils.IsProcessRunning("Fallout76"))
                    MsgBox.Get("iniFilesModified").Popup(MessageBoxIcon.Warning);
            }*/
        }

        private void linkLabelAttribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenNotepad(@"Attribution.txt");
        }

        private void linkLabelWhatsNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowWhatsNew();
        }

        #endregion

        private void toolStripButtonProfiles_Click(object sender, EventArgs e)
        {
            // TODO
            (new FormSettings()).ShowDialog();
        }

        private void toolStripButtonNexusMods_Click_1(object sender, EventArgs e)
        {
            // TODO
            (new FormNexus()).ShowDialog();
        }

        // Detect resolution:
        private void buttonDetectResolution_Click(object sender, EventArgs e)
        {
            Size res = Utils.GetDisplayResolution();
            this.numCustomResW.Value = res.Width;
            this.numCustomResH.Value = res.Height;
        }

        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "Custom" selected, skip:
            if (this.comboBoxResolution.SelectedIndex == 0)
                return;

            // If an invalid option has been selected, set to "Custom" and skip:
            string res = this.comboBoxResolution.SelectedItem.ToString();
            Size? displaySize = GetResolutionFromString(res);
            if (!displaySize.HasValue)
            {
                this.comboBoxResolution.SelectedIndex = 0;
                return;
            }

            int width = displaySize.Value.Width;
            int height = displaySize.Value.Height;

            // Set the values of the NumericUpDowns (which in turn will trigger the event handlers which set the values in the *.ini files)
            if (this.numCustomResW.Value != width)
                this.numCustomResW.Value = width;

            if (this.numCustomResH.Value != height)
                this.numCustomResH.Value = height;
        }

        /// <summary>
        /// Extracts width and height from a string that looks like this: "[16:9] 1920 x 1080 (Full HD)"
        /// </summary>
        /// <returns>Width and height if a valid option has been selected. Otherwise null.</returns>
        private Size? GetResolutionFromString(String res)
        {
            if (!res.Contains("x"))
                return null;
            string[] split = res.Split('x').Select(x => x.Trim()).ToArray();
            int width = Convert.ToInt32(Regex.Match(split[0], @"[0-9]+$").Groups[0].Value);
            int height = Convert.ToInt32(Regex.Match(split[1], @"^[0-9]+").Groups[0].Value);
            return new Size(width, height);
        }

        /// <summary>
        /// Searches through the resolution combobox for an option that matches the given size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>The first occurence if a match was found. Otherwise -1.</returns>
        private int FindIndexInComboBox(Size size)
        {
            for (int i = 0; i < this.comboBoxResolution.Items.Count; i++)
            {
                string res = this.comboBoxResolution.Items[i].ToString();
                Size? s = GetResolutionFromString(res);
                if (s?.Width == size.Width && s?.Height == size.Height)
                    return i;
            }
            return -1;
        }

        private void numCustomRes_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size(
                Convert.ToInt32(numCustomResW.Value),
                Convert.ToInt32(numCustomResH.Value)
            );
            int i = FindIndexInComboBox(size);
            if (i > -1)
                this.comboBoxResolution.SelectedIndex = i;
            else
                this.comboBoxResolution.SelectedIndex = 0;
        }

        // TODO: Properly implement pipboy color presets
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(255, 182, 66);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(26, 255, 128);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(18, 255, 21);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(26, 255, 128);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(46, 207, 255);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.colorPreviewPipboy.BackColor = Color.FromArgb(192, 255, 255);
        }
    }
}
