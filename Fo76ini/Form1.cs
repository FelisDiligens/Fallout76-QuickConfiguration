using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using IniParser.Model;

namespace Fo76ini
{
    public partial class Form1 : Form
    {
        public const String VERSION = "1.8";

        protected System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        private UILoader uiLoader = new UILoader();

        private FormMods formMods;
        private bool formModsBackupCreated = false;

        public static String OldAppConfigFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration");
        public static String AppConfigFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Fallout 76 Quick Configuration");

        //private Dictionary<String, ComboBoxContainer> comboBoxes = new Dictionary<String, ComboBoxContainer>();

        private static Form1 instance;
        public static Form1 Instance
        {
            get { return Form1.instance; }
        }

        public Form1()
        {
            Form1.instance = this;

            InitializeComponent();

            // Let's add options to the drop-down menus:

            // https://en.wikipedia.org/wiki/List_of_common_resolutions
            ComboBoxContainer.Add("Resolution", new ComboBoxContainer(
                this.comboBoxResolution,
                new String[] {
                    "Custom",
                    "640x480",
                    "800x600",
                    "1280x720",
                    "1280x768",
                    "1152x864",
                    "1440x900",
                    "1600x900",
                    "1280x960",
                    "1920x1080",
                    "2560x1080",
                    "3440x1440",
                    "2560x1440",
                    "3200x1800",
                    "5120x2160",
                    "5120x2880"
                }
            ));

            ComboBoxContainer.Add("DisplayMode", new ComboBoxContainer(
                this.comboBoxDisplayMode,
                new String[] {
                    "Fullscreen",
                    "Windowed",
                    "Borderless windowed",
                    "Borderless windowed (Fullscreen)"
                }
            ));

            ComboBoxContainer.Add("AntiAliasing", new ComboBoxContainer(
                this.comboBoxAntiAliasing,
                new String[] {
                    "TAA (default)",
                    "FXAA",
                    "Disabled"
                }
            ));

            ComboBoxContainer.Add("AnisotropicFiltering", new ComboBoxContainer(
                this.comboBoxAnisotropicFiltering,
                new String[] {
                    "None",
                    "2x",
                    "4x",
                    "8x (default)",
                    "16x"
                }
            ));

            ComboBoxContainer.Add("ShadowTextureResolution", new ComboBoxContainer(
                this.comboBoxShadowTextureResolution,
                new String[] {
                    "1024 = Low",
                    "2048 = High (default)",
                    "4096 = Ultra"
                }
            ));

            ComboBoxContainer.Add("ShadowBlurriness", new ComboBoxContainer(
                this.comboBoxShadowBlurriness,
                new String[] {
                    "1x",
                    "2x",
                    "3x = Default, recommended"
                }
            ));

            ComboBoxContainer.Add("Files", new ComboBoxContainer(
                this.comboBoxCustomFile,
                new String[] {
                    "Fallout76.ini",
                    "Fallout76Prefs.ini",
                    "Fallout76Custom.ini"
                }
            ));
            this.comboBoxCustomFile.SelectedIndex = 0;

            ComboBoxContainer.Add("VoiceChatMode", new ComboBoxContainer(
                this.comboBoxVoiceChatMode,
                new String[] {
                    "Auto",
                    "Area",
                    "Team",
                    "None"
                }
            ));

            ComboBoxContainer.Add("ShowActiveEffectsOnHUD", new ComboBoxContainer(
                this.comboBoxShowActiveEffectsOnHUD,
                new String[] {
                    "Disabled",
                    "Detrimental",
                    "All"
                }
            ));


            // Disable scroll wheel on UI elements to prevent the user from accidentally changing values:
            PreventChangeOnMouseWheelForAllElements(this);


            // Add messagebox data:
            /*
            translatedMessageBoxes["backupAndSave"] = new MessageBoxData("Backup and save", "Do you want to create a backup before applying all changes?\n\n    Press \"Yes\" to create a backup and save.\n    Press \"No\" to save without backup.\n    Press \"Cancel\" to abort.");
            translatedMessageBoxes["changesApplied"] = new MessageBoxData("Changes applied", "Changes have been applied. You may start the game now.");
            translatedMessageBoxes["chooseGameEdition"] = new MessageBoxData("Choose Game Edition", "Please pick your game edition under the General tab.");
            translatedMessageBoxes["runGameToGenerateINI"] = new MessageBoxData("Fallout76.ini and Fallout76Prefs.ini not found", "Please run the game first before using this tool.\nThe game will generate those files on first start-up.");
            */
            MsgBox.AddSharedMessageBoxes();

            // Event handler:
            this.FormClosing += this.Form1_FormClosing;
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
        /// <param name="control"></param>
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create folder, if not present:
            if (!Directory.Exists(Form1.AppConfigFolder))
                Directory.CreateDirectory(Form1.AppConfigFolder);

            // Create note to old config folder to inform users, if present:
            if (Directory.Exists(Form1.OldAppConfigFolder))
            {
                try
                {
                    using (StreamWriter f = new StreamWriter(Path.Combine(Form1.OldAppConfigFolder, "READ ME - CONFIG FOLDER HAS BEEN MOVED.txt")))
                    {
                        f.Write(
                            "Hi,\n\n"+
                            "the entire configuration folder has been moved from\n" +
                            "C:\\Users\\USERNAME\\Documents\\Fallout 76 Quick Configuration\\\n" +
                            "to\n" +
                            "C:\\Users\\USERNAME\\AppData\\Local\\Fallout 76 Quick Configuration\\\n" +
                            "due to write-permission issues.\n\n" +
                            "Therefore changes to these files won't have any effect.\n" +
                            "It's safe to delete this folder, if you don't need the log files.\n\n" +
                            "Users reported that the tool is crashing for them, because it can't write to the aforementioned folder.\n" +
                            "So I moved it in the hope that it'll fix the issue, at least in part.\n" +
                            "Also, it's a better place anyway, as the Documents folder is supposed to contain documents. (Who knew?)\n\n" +
                            "Anyways, happy hunting!"
                        );
                    }
                }
                catch
                {
                    MessageBox.Show(@"All configuration files have been moved to 'C:\Users\<yourname>\AppData\Local\Fallout 76 Quick Configuration'. Delete the old folder to stop this message from displaying.", "Old configuration path found");
                }
            }

            this.formMods = new FormMods();

            // Load QuickConfiguration.ini
            IniFiles.Instance.LoadConfig();

            // Load the languages
            LookupLanguages();

            // Load *.ini files:
            try
            {
                IniFiles.Instance.GameEdition = (GameEdition)IniFiles.Instance.GetInt(IniFile.Config, "Preferences", "uGameEdition", 0);
                IniFiles.Instance.LoadGameInis();
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "uGameEdition", (int)IniFiles.Instance.GameEdition);
            }
            catch (IniParser.Exceptions.ParsingException exc)
            {
                MessageBox.Show(exc.Message, "Couldn't parse *.ini files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            catch (FileNotFoundException exc)
            {
                MsgBox.Get("runGameToGenerateINI").FormatTitle(IniFiles.Instance.GetIniName(IniFile.F76), IniFiles.Instance.GetIniName(IniFile.F76Prefs)).Show(MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Load mods:
            ManagedMods.Instance.Load();
            this.formMods.UpdateUI();

            // Setup UI:
            ColorIni2Ui();
            UpdateCameraPositionUI();
            AddAllEventHandler();
            uiLoader.Update();

            CheckVersion();

            if (IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bOpenModManagerOnLaunch", false))
                this.formMods.OpenUI();

            IniFiles.Instance.LoadWindowState("Form1", this);

            // Remove updater, if present:
            try
            {
                String updaterPath = Path.Combine(Form1.AppConfigFolder, "Updater");
                if (Directory.Exists(updaterPath))
                    Directory.Delete(updaterPath, true);
            }
            catch
            {
                // Yeah, well or not.
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                IniFiles.Instance.SaveWindowState("Form1", this);
                if (IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bAutoApply", false))
                    ApplyChanges();
            }
        }

        private void CheckVersion(bool force = false)
        {
            this.labelConfigVersion.Text = VERSION;
            /*using (StreamWriter f = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration", "VERSION")))
                f.Write(VERSION);*/
            IniFiles.Instance.Set(IniFile.Config, "General", "sVersion", VERSION);

            if (!force && IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bIgnoreUpdates", false))
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                groupBoxUpdate.Visible = false;
                return;
            }

            String latestVersion = VERSION;
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                // wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/VERSION");
                latestVersion = Encoding.UTF8.GetString(raw).Trim();
            }
            catch (System.Net.WebException exc)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                groupBoxUpdate.Visible = false;
                return;
            }

            int cmp = Utils.CompareVersions(latestVersion, VERSION);
            if (cmp > 0)
            {
                groupBoxUpdate.Visible = true;
                labelNewVersion.Text = String.Format(Translation.localizedStrings["newVersionAvailable"], latestVersion);
                labelNewVersion.ForeColor = Color.Crimson;
                this.labelConfigVersion.ForeColor = Color.Red;
            }
            else if (cmp < 0)
            {
                groupBoxUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkBlue;
            }
            else
            {
                groupBoxUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkGreen;
            }
        }

        private void AddAllEventHandler()
        {
            // Link numericUpDown and sliders:
            UILoader.LinkSlider(this.sliderGrassFadeDistance, this.numGrassFadeDistance, 1);
            //LinkSlider(this.sliderGrassDensity, this.numGrassDensity, 1, true);
            UILoader.LinkSlider(this.sliderLODObjects, this.numLODObjects, 10);
            UILoader.LinkSlider(this.sliderLODItems, this.numLODItems, 10);
            UILoader.LinkSlider(this.sliderLODActors, this.numLODActors, 10);
            UILoader.LinkSlider(this.sliderShadowDistance, this.numShadowDistance, 1);
            UILoader.LinkSlider(this.sliderMouseSensitivity, this.numMouseSensitivity, 10000.0);
            UILoader.LinkSlider(this.sliderTAAPostOverlay, this.numTAAPostOverlay, 100);
            UILoader.LinkSlider(this.sliderTAAPostSharpen, this.numTAAPostSharpen, 100);

            UILoader.LinkSlider(this.sliderVolumeMaster, this.numVolumeMaster, 100);
            UILoader.LinkSlider(this.sliderAudioChat, this.numAudioChat, 1);
            UILoader.LinkSlider(this.sliderAudiofVal0, this.numAudiofVal0, 100);
            UILoader.LinkSlider(this.sliderAudiofVal1, this.numAudiofVal1, 100);
            UILoader.LinkSlider(this.sliderAudiofVal2, this.numAudiofVal2, 100);
            UILoader.LinkSlider(this.sliderAudiofVal3, this.numAudiofVal3, 100);
            UILoader.LinkSlider(this.sliderAudiofVal4, this.numAudiofVal4, 100);
            UILoader.LinkSlider(this.sliderAudiofVal5, this.numAudiofVal5, 100);
            UILoader.LinkSlider(this.sliderAudiofVal6, this.numAudiofVal6, 100);

            UILoader.LinkSlider(this.sliderFloatingQuestMarkersDistance, this.numFloatingQuestMarkersDistance, 10);
            UILoader.LinkSlider(this.sliderConversationHistorySize, this.numConversationHistorySize, 1);
            UILoader.LinkSlider(this.sliderHUDOpacity, this.numHUDOpacity, 100);


            /*
             ********************************************
             * Link control elements:
             ********************************************
             */

            // Make *.ini files read-only
            uiLoader.LinkCustom(this.checkBoxReadOnly,
                IniFiles.Instance.AreINIsReadOnly,
                IniFiles.Instance.SetINIsReadOnly
            );

            // Deny NTFS write-permission
            uiLoader.LinkBool(this.checkBoxDenyNTFSWritePermission, IniFile.Config, "Preferences", "bDenyNTFSWritePermission", false);

            /*
             * Settings
             */

            // Game Edition
            uiLoader.LinkList(
                new RadioButton[] { this.radioButtonEditionBethesdaNet, this.radioButtonEditionSteam, this.radioButtonEditionBethesdaNetPTS, this.radioButtonEditionMSStore },
                new String[] { "1", "2", "3", "4" },
                IniFile.Config, "Preferences", "uGameEdition",
                "0"
            );

            // Launch options
            uiLoader.LinkList(
                new RadioButton[] { this.radioButtonLaunchViaLink, this.radioButtonLaunchViaExecutable },
                new String[] { "1", "2" },
                IniFile.Config, "Preferences", "uLaunchOption",
                "1"
            );

            // Nuclear winter mode
            uiLoader.LinkBool(this.checkBoxNWMode, IniFile.Config, "Preferences", "bNWMode", false);

            // Close the tool when the game is launched
            uiLoader.LinkBool(this.checkBoxQuitOnGameLaunch, IniFile.Config, "Preferences", "bQuitOnLaunch", false);

            // Automatically apply changes when tool is closed or game is launched
            uiLoader.LinkBool(this.checkBoxAutoApply, IniFile.Config, "Preferences", "bAutoApply", false);

            // Don't ask me, when "Apply" is clicked.
            uiLoader.LinkBool(this.checkBoxSkipBackupQuestion, IniFile.Config, "Preferences", "bSkipBackupQuestion", false);

            // Open mod manager when tool is launched.
            uiLoader.LinkBool(this.checkBoxOpenManageModsOnLaunch, IniFile.Config, "Preferences", "bOpenModManagerOnLaunch", false);

            // Don't check for updates on startup.
            uiLoader.LinkBool(this.checkBoxIgnoreUpdates, IniFile.Config, "Preferences", "bIgnoreUpdates", false);

            // Does the user use multiple game editions when modding?
            uiLoader.LinkBool(this.checkBoxMultipleGameEditionsUsed, IniFile.Config, "Preferences", "bMultipleGameEditionsUsed", false);


            /*
             * General
             */

            // Credentials
            uiLoader.LinkString(this.textBoxUserName, IniFile.F76Custom, "Login", "s76UserName", "");
            uiLoader.LinkString(this.textBoxPassword, IniFile.F76Custom, "Login", "s76Password", "");

            // Disable Steam:
            uiLoader.LinkBoolNegated(this.checkBoxDisableSteam, IniFile.F76Custom, "General", "bSteamEnabled", true);

            // Play intro videos
            uiLoader.LinkCustom(this.checkBoxIntroVideos,
                () => {
                    String sIntroSequence = IniFiles.Instance.GetString("General", "sIntroSequence", "BGSLogo4k.bk2").Trim();
                    return sIntroSequence.Length > 0 && sIntroSequence != "0";
                },
                (value) => {
                    if (value)
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "General", "sIntroSequence");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "General", "uMainMenuDelayBeforeAllowSkip");
                    }
                    else
                    {
                        IniFiles.Instance.Set(IniFile.F76Custom, "General", "sIntroSequence", "");
                        IniFiles.Instance.Set(IniFile.F76Custom, "General", "uMainMenuDelayBeforeAllowSkip", "0");
                    }
                }
            );

            // Play music in main menu
            uiLoader.LinkBool(this.checkBoxMainMenuMusic, IniFile.F76Custom, "General", "bPlayMainMenuMusic", true);

            // Show splash screen with news on startup
            uiLoader.LinkBoolNegated(this.checkBoxShowSplash, IniFile.F76Custom, "General", "bSkipSplash", false);

            // General subtitles
            uiLoader.LinkBool(this.checkBoxGeneralSubtitles, IniFile.F76Prefs, "Interface", "bGeneralSubtitles", false);

            // Dialogue subtitles
            uiLoader.LinkBool(this.checkBoxDialogueSubtitles, IniFile.F76Prefs, "Interface", "bDialogueSubtitles", false);

            // Dialogue history
            uiLoader.LinkBool(this.checkBoxDialogueHistory, IniFile.F76Prefs, "MAIN", "bShowDialogueHistory", false);

            // Show damage numbers in nuclear winter
            uiLoader.LinkBool(this.checkBoxShowDamageNumbersNW, IniFile.F76Prefs, "NuclearWinter", "bShowDamageNumbers", true);

            // Show damage numbers in adventure mode
            uiLoader.LinkBool(this.checkBoxShowDamageNumbersA, IniFile.F76Prefs, "Adventure", "bShowDamageNumbers", false);

            // Show item rarity colors
            uiLoader.LinkBool(this.checkBoxItemRarityColorsNW, IniFile.F76Prefs, "NuclearWinter", "bEnableItemRarityColors", true);

            // Show Public Team Notifications
            uiLoader.LinkBool(this.checkBoxShowPublicTeamNotifications, IniFile.F76Prefs, "GamePlay", "bShowPublicTeamNotifications", true);

            // Show Floating Quest Markers
            uiLoader.LinkBool(this.checkBoxShowFloatingQuestMarkers, IniFile.F76Prefs, "GamePlay", "bShowFloatingQuestMarkers", true);

            // Show Floating Quest Text
            uiLoader.LinkBool(this.checkBoxShowFloatingQuestText, IniFile.F76Prefs, "GamePlay", "bShowFloatingQuestText", true);

            // Floating Quest Markers Draw Distance
            uiLoader.LinkFloat(this.numFloatingQuestMarkersDistance, IniFile.F76Prefs, "GamePlay", "fFloatingQuestMarkersDistance", 100.0f);

            // Show compass
            uiLoader.LinkBool(this.checkBoxShowCompass, IniFile.F76Prefs, "Interface", "bShowCompass", true);

            // Show crosshair
            uiLoader.LinkBool(this.checkBoxShowCrosshair, IniFile.F76Prefs, "MAIN", "bCrosshairEnabled", true);

            // Enable Power Armor HUD
            uiLoader.LinkBool(this.checkBoxEnablePowerArmorHUD, IniFile.F76Prefs, "MAIN", "bEnablePowerArmorHUD", true);

            // Show Other Players' Names
            uiLoader.LinkBool(this.checkBoxShowOtherPlayersNames, IniFile.F76Prefs, "Display", "bShowOtherPlayersNames", true);

            // Quests:
            uiLoader.LinkBool(this.checkBoxEnableQuestAutoTrackMain, IniFile.F76Prefs, "MAIN", "bEnableQuestAutoTrackMain", true);
            uiLoader.LinkBool(this.checkBoxEnableQuestAutoTrackSide, IniFile.F76Prefs, "MAIN", "bEnableQuestAutoTrackSide", true);
            uiLoader.LinkBool(this.checkBoxEnableQuestAutoTrackMisc, IniFile.F76Prefs, "MAIN", "bEnableQuestAutoTrackMisc", true);
            uiLoader.LinkBool(this.checkBoxEnableQuestAutoTrackEvent, IniFile.F76Prefs, "MAIN", "bEnableQuestAutoTrackEvent", true);
            uiLoader.LinkBool(this.checkBoxEnableQuestAutoTrackDaily, IniFile.F76Prefs, "MAIN", "bEnableQuestAutoTrackOther", false);

            // Conversation History Size
            uiLoader.LinkFloat(this.numConversationHistorySize, IniFile.F76Prefs, "Display", "fConversationHistorySize", 4.0f);

            // HUD Opacity
            uiLoader.LinkFloat(this.numHUDOpacity, IniFile.F76Prefs, "MAIN", "fHUDOpacity", 1.0f);

            // Show active effects on HUD
            uiLoader.LinkList(
                this.comboBoxShowActiveEffectsOnHUD,
                new String[] { "0", "1", "2" },
                IniFile.Config, "Interface", "uHUDActiveEffectWidget",
                "2", 2
            );


            /*
             * Display
             */

            // Display mode
            uiLoader.LinkCustom(this.comboBoxDisplayMode,
                () => {
                    bool bFullScreen = IniFiles.Instance.GetBool("Display", "bFull Screen", true);
                    bool bBorderless = IniFiles.Instance.GetBool("Display", "bBorderless", true);
                    bool bMaximizeWindow = IniFiles.Instance.GetBool("Display", "bMaximizeWindow", true);

                    if (bFullScreen)
                        return 0; // Fullscreen
                    else if (!bBorderless)
                        return 1; // Windowed
                    else if (bBorderless && !bMaximizeWindow)
                        return 2; // Borderless windowed
                    else
                        return 3; // Borderless windowed (Fullscreen)
                },
                (value) => {
                    bool bFullScreen, bBorderless, bMaximizeWindow;
                    switch (this.comboBoxDisplayMode.SelectedIndex)
                    {
                        case 0: // Fullscreen
                            bBorderless = true;
                            bFullScreen = true;
                            bMaximizeWindow = false;
                            break;
                        case 1: // Windowed
                            bBorderless = false;
                            bFullScreen = false;
                            bMaximizeWindow = false;
                            break;
                        case 3: // Borderless windowed (Fullscreen)
                            bBorderless = true;
                            bFullScreen = false;
                            bMaximizeWindow = true;
                            break;
                        default: // Borderless windowed: Default settings
                            bBorderless = true;
                            bFullScreen = false;
                            bMaximizeWindow = false;
                            break;
                    }
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "bFull Screen", bFullScreen);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "bBorderless", bBorderless);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "bMaximizeWindow", bMaximizeWindow);
                }
            );

            // Resolution
            uiLoader.LinkCustom(this.comboBoxResolution,
                () => {
                    int width = IniFiles.Instance.GetInt("Display", "iSize W", 1920);
                    int height = IniFiles.Instance.GetInt("Display", "iSize H", 1080);
                    int resIndex = Array.IndexOf(ComboBoxContainer.Get("Resolution").Items.ToArray(), $"{width}x{height}");
                    this.numCustomResW.Value = width;
                    this.numCustomResH.Value = height;
                    return resIndex > -1 ? resIndex : 0;
                },
                (value) => {
                    bool isCustomSelected = value == 0;
                    this.numCustomResW.Enabled = isCustomSelected;
                    this.numCustomResH.Enabled = isCustomSelected;

                    if (value != 0)
                    {
                        String[] splitted = this.comboBoxResolution.SelectedItem.ToString().Split(new String[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
                        int width = Convert.ToInt32(splitted[0]);
                        int height = Convert.ToInt32(splitted[1]);
                        IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "iSize W", width);
                        IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "iSize H", height);
                        this.numCustomResW.Value = width;
                        this.numCustomResH.Value = height;
                    }
                }
            );

            // Custom Resolution
            uiLoader.LinkInt(this.numCustomResW, IniFile.F76Prefs, "Display", "iSize W", 1920);
            uiLoader.LinkInt(this.numCustomResH, IniFile.F76Prefs, "Display", "iSize H", 1080);

            // Hide (or show) custom resolution on load:
            uiLoader.Add(() =>
            {
                bool isCustomSelected = this.comboBoxResolution.SelectedIndex == 0;
                this.numCustomResW.Enabled = isCustomSelected;
                this.numCustomResH.Enabled = isCustomSelected;
            });

            // Top most window
            uiLoader.LinkBool(this.checkBoxTopMostWindow, IniFile.F76Prefs, "Display", "bTopMostWindow", false);

            // Always active
            uiLoader.LinkBool(this.checkBoxAlwaysActive, IniFile.F76Custom, "General", "bAlwaysActive", true);

            // Fix HUD for 5:4 and 4:3 screens
            uiLoader.LinkCustom(this.checkBoxFixHUDFor5_4and4_3,
                () => {
                    return
                        Math.Abs(IniFiles.Instance.GetFloat("Interface", "fLockPositionY", 0f) - 100f) < 0.1 &&
                        Math.Abs(IniFiles.Instance.GetFloat("Interface", "fUIPowerArmorGeometry_TranslateZ", 0f) - -18.5f) < 0.1 &&
                        Math.Abs(IniFiles.Instance.GetFloat("Interface", "fUIPowerArmorGeometry_TranslateY", 0f) - 460f) < 0.1;
                },
                (value) => {
                    if (value)
                    {
                        IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fLockPositionY", 100f);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fUIPowerArmorGeometry_TranslateZ", -18.5f);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fUIPowerArmorGeometry_TranslateY", 460f);
                    }
                    else
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Interface", "fLockPositionY");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Interface", "fUIPowerArmorGeometry_TranslateZ");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Interface", "fUIPowerArmorGeometry_TranslateY");
                    }
                }
            );



            /*
             * Graphics
             */

            // Anti-Aliasing
            uiLoader.LinkList(this.comboBoxAntiAliasing,
                new String[] { "TAA", "FXAA", "" },
                IniFile.F76Prefs, "Display", "sAntiAliasing",
                "TAA", 2);

            // Anisotropic filtering
            uiLoader.LinkList(this.comboBoxAnisotropicFiltering,
                new String[] { "0", "2", "4", "8", "16" },
                IniFile.F76Prefs, "Display", "iMaxAnisotropy",
                "8", 3);

            // iPresentInterval
            // I'm not so sure about this anymore:
            //    Actually, it's not VSync but a fps cap, which is determined this way: Monitor refresh rate divided by iPresentInterval
            //    A 120 Hz monitor and iPresentInterval set to 2 will result in a 60fps cap.
            //uiLoader.LinkBool(this.checkBoxVSync, IniFile.F76Prefs, "Display", "iPresentInterval", true);
            uiLoader.LinkCustom(this.checkBoxVSync,
                () => IniFiles.Instance.GetInt("Display", "iPresentInterval", 1) != 0,
                (value) => {
                    if (value)
                    {
                        int defaultValue = IniFiles.Instance.GetInt(IniFile.Config, "Display", "iPresentInterval", -1);
                        if (defaultValue <= 0)
                        {
                            defaultValue = 1;
                            // Values of 2 and above cause black screen:
                            //int refreshRate = Utils.GetDisplayRefreshRate();
                            //defaultValue = Utils.Clamp(Convert.ToInt32(Math.Round(Convert.ToSingle(refreshRate) / 60f)), 1, 4);
                        }
                        IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "iPresentInterval", defaultValue);
                    }
                    else
                    {
                        int defaultValue = IniFiles.Instance.GetInt("Display", "iPresentInterval", -1);
                        if (defaultValue > 0)
                            IniFiles.Instance.Set(IniFile.Config, "Display", "iPresentInterval", defaultValue);
                        IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "iPresentInterval", 0);
                    }
                }
            );

            // Depth of Field
            uiLoader.LinkCustom(this.checkBoxDepthOfField,
                () => IniFiles.Instance.GetBool("ImageSpace", "bDynamicDepthOfField", true),
                (value) => {
                    if (value)
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "ImageSpace", "bDynamicDepthOfField");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFBlendRatio");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFMinFocalCoefDist");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFMaxFocalCoefDist");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFDynamicFarRange");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFCenterWeightInt");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Display", "fDOFFarDistance");
                    }
                    else
                    {
                        IniFiles.Instance.Set(IniFile.F76Custom, "ImageSpace", "bDynamicDepthOfField", false);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFBlendRatio", 0);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFMinFocalCoefDist", 999999);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFMaxFocalCoefDist", 99999999);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFDynamicFarRange", 99999999);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFCenterWeightInt", 0);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDOFFarDistance", 99999999);
                        /*
                           Things I wanted to add:

                           bDoDepthOfField    - DO NOT set this to 0. It will cause underwater effects to disappear.
                           bScreenSpaceBokeh  - Apparently some blur effect. Is it related to DOF?
                           bUseBlurShader     - ?
                        */
                    }
                }
            );

            // Motion Blur
            uiLoader.LinkBool(this.checkBoxMotionBlur, IniFile.F76Custom, "ImageSpace", "bMBEnable", true);

            // Radial Blur
            uiLoader.LinkBool(this.checkBoxRadialBlur, IniFile.F76Custom, "ImageSpace", "bDoRadialBlur", true);

            // Lens Flare
            uiLoader.LinkBool(this.checkBoxLensFlare, IniFile.F76Prefs, "ImageSpace", "bLensFlare", true);

            // Ambient Occlusion
            uiLoader.LinkBool(this.checkBoxAmbientOcclusion, IniFile.F76Prefs, "Display", "bSAOEnable", true);

            // Water / Displacement
            uiLoader.LinkBool(this.checkBoxWaterDisplacement, IniFile.F76Prefs, "Water", "bUseWaterDisplacements", true);

            // Weather / Fog
            uiLoader.LinkBool(this.checkBoxFogEnabled, IniFile.F76Prefs, "Weather", "bFogEnabled", true);

            // Weather / Rain Occlusion
            uiLoader.LinkBool(this.checkBoxWeatherRainOcclusion, IniFile.F76, "Weather", "bRainOcclusion", true);

            // Weather / Wetness Occlusion
            uiLoader.LinkBool(this.checkBoxWeatherWetnessOcclusion, IniFile.F76, "Weather", "bWetnessOcclusion", true);

            // Lighting / Volumetric Lighting
            uiLoader.LinkBool(this.checkBoxGodrays, IniFile.F76Prefs, "Display", "bVolumetricLightingEnable", true);

            // Shadows / Texture map resolution
            uiLoader.LinkList(this.comboBoxShadowTextureResolution,
                new String[] { "1024", "2048", "4096" },
                IniFile.F76Prefs, "Display", "iShadowMapResolution",
                "2048", 1);

            // Shadows / Blurriness
            uiLoader.LinkList(this.comboBoxShadowBlurriness,
                new String[] { "1", "2", "3" },
                IniFile.F76Prefs, "Display", "uiOrthoShadowFilter",
                "3", 2);

            // Shadow / Shadow distance
            // fShadowDistance was replaced by fDirShadowDistance in Fallout 4
            uiLoader.LinkInt(this.numShadowDistance, IniFile.F76Prefs, "Display", "fDirShadowDistance", 3000);

            // LOD Fade Distances
            uiLoader.LinkFloat(this.numLODObjects, IniFile.F76Prefs, "LOD", "fLODFadeOutMultObjects", 6.0f);
            uiLoader.LinkFloat(this.numLODItems, IniFile.F76Prefs, "LOD", "fLODFadeOutMultItems", 2.5f);
            uiLoader.LinkFloat(this.numLODActors, IniFile.F76Prefs, "LOD", "fLODFadeOutMultActors", 4.5f);

            // Grass / Enable grass
            uiLoader.LinkBool(this.checkBoxGrass, IniFile.F76Custom, "Grass", "bAllowCreateGrass", true);

            // Grass / Fade distance
            uiLoader.LinkCustom(this.numGrassFadeDistance,
                () => IniFiles.Instance.GetFloat("Grass", "fGrassStartFadeDistance", 3000),
                (value) => {
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Grass", "fGrassStartFadeDistance", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Grass", "fGrassMinStartFadeDistance", 0);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Grass", "fGrassMaxStartFadeDistance", value);
                }
            );

            // Grass / Density
            //LinkInt(this.numGrassDensity, IniFile.F76Custom, "Grass", "iMinGrassSize", 20);

            // TAA Sharpening

            uiLoader.LinkFloat(this.numTAAPostOverlay, IniFile.F76Custom, "Display", "fTAAPostOverlay", 0.21f);
            uiLoader.LinkFloat(this.numTAAPostSharpen, IniFile.F76Custom, "Display", "fTAAPostSharpen", 0.21f);



            /*
             * Audio
             */

            uiLoader.LinkBool(this.checkBoxEnableAudio, IniFile.F76Custom, "Audio", "bEnableAudio", true);

            uiLoader.LinkBool(this.checkBoxPushToTalk, IniFile.F76Prefs, "Voice", "bVoicePushToTalkEnabled", true);

            uiLoader.LinkFloat(this.numVolumeMaster, IniFile.F76Prefs, "AudioMenu", "fAudioMasterVolume", 1.0f);
            uiLoader.LinkInt(this.numAudioChat, IniFile.F76Prefs, "Voice", "uVivoxVoiceVolume", 100);
            uiLoader.LinkFloat(this.numAudiofVal0, IniFile.F76Prefs, "AudioMenu", "fVal0", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal1, IniFile.F76Prefs, "AudioMenu", "fVal1", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal2, IniFile.F76Prefs, "AudioMenu", "fVal2", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal3, IniFile.F76Prefs, "AudioMenu", "fVal3", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal4, IniFile.F76Prefs, "AudioMenu", "fVal4", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal5, IniFile.F76Prefs, "AudioMenu", "fVal5", 1.0f);
            uiLoader.LinkFloat(this.numAudiofVal6, IniFile.F76Prefs, "AudioMenu", "fVal6", 1.0f);

            uiLoader.LinkList(this.comboBoxVoiceChatMode,
                new String[] { "0", "1", "2", "3" },
                IniFile.F76Prefs, "Voice", "uTransmitPreference",
                "0", 0);


            /*
             * Controls
             */

            uiLoader.LinkBool(this.checkBoxMouseAcceleration, IniFile.F76Custom, "Controls", "bMouseAcceleration", true);

            // Fix mouse sensitivity
            uiLoader.LinkCustom(this.checkBoxFixMouseSensitivity,
                () => IniFiles.Instance.GetFloat("Controls", "fMouseHeadingXScale", 0.021f) != IniFiles.Instance.GetFloat("Controls", "fMouseHeadingYScale", 0.021f),
                (value) => { 
                    if (value)
                    {
                        int width = IniFiles.Instance.GetInt("Display", "iSize W", 1920);
                        int height = IniFiles.Instance.GetInt("Display", "iSize H", 1080);
                        float aspectRatio = width / height;
                        float YScale = 0.0f;

                        // 16:9
                        if (Math.Abs(aspectRatio - 16 / 9) < 0.01)
                            YScale = 0.03738f;

                        // 16:10
                        else if (Math.Abs(aspectRatio - 16 / 10) < 0.01)
                            YScale = 0.0336f;

                        // 21:9
                        else if (Math.Abs(aspectRatio - 21 / 9) < 0.01)
                            YScale = 0.042f;

                        // 4:3
                        else if (Math.Abs(aspectRatio - 4 / 3) < 0.01)
                            YScale = 0.028f;

                        // Unknown aspect ratio
                        else
                            YScale = aspectRatio * 0.021f;

                        IniFiles.Instance.Set(IniFile.F76Custom, "Controls", "fMouseHeadingXScale", 0.021f);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Controls", "fMouseHeadingYScale", YScale);

                        IniFiles.Instance.Set(IniFile.F76Custom, "Controls", "fPitchSpeedRatio", 1.0f);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Controls", "fIronSightsPitchSpeedRatio", 1.0f);
                    }
                    else
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "fMouseHeadingXScale");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "fMouseHeadingYScale");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "fPitchSpeedRatio");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "fIronSightsPitchSpeedRatio");
                    }
                }
            );

            // Fix aim sensitivity
            uiLoader.LinkCustom(this.checkBoxFixAimSensitivity,
                () => Math.Abs(IniFiles.Instance.GetFloat("Main", "fIronSightsFOVRotateMult", 0f) - 2.14f) < 0.1f,
                (value) => {
                    if (value)
                    {
                        IniFiles.Instance.Set(IniFile.F76Custom, "Controls", "fIronSightsFOVRotateMult", 2.136363636f);
                        IniFiles.Instance.Set(IniFile.F76Custom, "Main", "fIronSightsFOVRotateMult", 2.136363636f);
                    }
                    else
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "fIronSightsFOVRotateMult");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Main", "fIronSightsFOVRotateMult");
                    }
                }
            );

            // Mouse sensitivity slider
            uiLoader.LinkCustom(this.numMouseSensitivity,
                () => IniFiles.Instance.GetFloat("Controls", "fMouseHeadingSensitivity", 0.03f),
                (value) => {
                    // Fallout76Custom.ini had no effect. I hope Fallout76Prefs.ini will have an effect this time:
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Controls", "fMouseHeadingSensitivity", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Controls", "fMouseHeadingSensitivityY", value);
                }
            );

            // Gamepad
            uiLoader.LinkBool(this.checkBoxGamepadEnabled, IniFile.F76Prefs, "General", "bGamepadEnable", true);
            uiLoader.LinkBool(this.checkBoxGamepadRumble, IniFile.F76Custom, "Controls", "bGamePadRumble", true);

            uiLoader.LinkBool(this.checkBoxMouseInvertX, IniFile.F76Prefs, "Controls", "bInvertXValues", false);
            uiLoader.LinkBool(this.checkBoxMouseInvertY, IniFile.F76Prefs, "Controls", "bInvertYValues", false);



            /*
             * Pipboy
             */

            // Radiobuttons, Quickboy or Pipboy
            uiLoader.LinkBool(this.radioButtonQuickboy, this.radioButtonPipboy, IniFile.F76Prefs, "Pipboy", "bQuickboyMode", false);

            // Resolution
            uiLoader.LinkInt(this.numPipboyTargetWidth, IniFile.F76Prefs, "Display", "uPipboyTargetWidth", 876);
            uiLoader.LinkInt(this.numPipboyTargetHeight, IniFile.F76Prefs, "Display", "uPipboyTargetHeight", 700);


            /*
             * Camera
             */


            // Vanity mode
            uiLoader.LinkBool(this.checkBoxVanityMode, IniFile.F76Custom, "Camera", "bDisableAutoVanityMode", false, true);
            uiLoader.LinkBool(this.checkBoxForceVanityMode, IniFile.F76Custom, "Camera", "bForceAutoVanityMode", false);
            uiLoader.LinkCustom(this.checkBoxVanityMode,
                () => this.checkBoxVanityMode.Checked,
                (value) =>
                {
                    this.checkBoxForceVanityMode.Enabled = this.checkBoxVanityMode.Checked;
                    if (!this.checkBoxVanityMode.Checked)
                    {
                        this.checkBoxForceVanityMode.Checked = false;
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Camera", "bForceAutoVanityMode");
                    }
                }
            );
            uiLoader.Add(() => this.checkBoxForceVanityMode.Enabled = this.checkBoxVanityMode.Checked);

            // 1st person FOV
            uiLoader.LinkCustom(this.numFirstPersonFOV,
                () => IniFiles.Instance.GetFloat("Display", "fDefault1stPersonFOV", 80),
                (value) => {
                    IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Interface", "fDefault1stPersonFOV", value);
                }
            );

            // World FOV
            uiLoader.LinkCustom(this.numWorldFOV,
                () => IniFiles.Instance.GetFloat("Display", "fDefaultWorldFOV", 80),
                (value) => {
                    IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDefaultWorldFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fDefaultWorldFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "fDefaultWorldFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Interface", "fDefaultWorldFOV", value);
                }
            );

            // 3rd person ADS FOV
            uiLoader.LinkInt(this.numADSFOV, IniFile.F76Custom, "Camera", "f3rdPersonAimFOV", 50);

            // bApplyCameraNodeAnimations
            uiLoader.LinkBool(this.checkBoxbApplyCameraNodeAnimations, IniFile.F76Custom, "Camera", "bApplyCameraNodeAnimations", true);
        }


        /*
         **************************************************************
         * Event handlers
         **************************************************************
         */

        public void ApplyChanges()
        {
            // Add custom lines to *.ini files:
            String f76Path = Path.Combine(IniFiles.Instance.iniParentPath, "Fallout76.add.ini");
            if (File.Exists(f76Path))
            {
                IniData f76Data = IniFiles.Instance.LoadIni(f76Path);
                IniFiles.Instance.Merge(IniFile.F76, f76Data);
            }

            String f76PPath = Path.Combine(IniFiles.Instance.iniParentPath, "Fallout76Prefs.add.ini");
            if (File.Exists(f76PPath))
            {
                IniData f76PData = IniFiles.Instance.LoadIni(f76PPath);
                IniFiles.Instance.Merge(IniFile.F76Prefs, f76PData);
            }

            String f76CPath = Path.Combine(IniFiles.Instance.iniParentPath, "Fallout76Custom.add.ini");
            if (File.Exists(f76CPath))
            {
                IniData f76CData = IniFiles.Instance.LoadIni(f76CPath);
                IniFiles.Instance.Merge(IniFile.F76Custom, f76CData);
            }

            // Save changes:
            ColorUi2Ini();
            IniFiles.Instance.SaveAll(this.checkBoxReadOnly.Checked);
            IniFiles.Instance.ResolveNWMode();
        }

        // "Apply" button:
        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            // Show a messagebox to ask the user, if they want to make a backup.
            if (!IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bSkipBackupQuestion", false))
            {
                DialogResult res = MsgBox.Get("backupAndSave").Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    return;
                else if (res == DialogResult.Yes)
                    // Make backups
                    IniFiles.Instance.BackupAll();
            }

            // Save stuff to INI
            ApplyChanges();
            MsgBox.Get("changesApplied").Popup(MessageBoxIcon.Information);
        }

        // [ ] "Make *.ini files read-only" checkbox:
        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.SetINIsReadOnly(this.checkBoxReadOnly.Checked);
        }

        // "Launch Game" button:
        private void toolStripButtonLaunchGame_Click(object sender, EventArgs e)
        {
            uint uGameEdition = IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uGameEdition", 0);
            uint uLaunchOption = IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uLaunchOption", 1);
            String process = null;
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
                if (!ManagedMods.Instance.ValidateGamePath())
                {
                    MsgBox.Get("modsGamePathNotSet").Show(MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                process = Path.GetFullPath(Path.Combine(ManagedMods.Instance.GamePath, ManagedMods.Instance.GameEdition == GameEdition.MSStore ? "Project76_GamePass.exe" : "Fallout76.exe"));
            }
            if (process != null)
            {
                if (IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bAutoApply", false))
                    ApplyChanges();
                try
                {
                    System.Diagnostics.Process.Start(process);
                    if (IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bQuitOnLaunch", false))
                        this.Close();
                }
                catch (Exception ex)
                {
                    if (ManagedMods.Instance.GameEdition == GameEdition.MSStore)
                    {
                        MsgBox.Get("msstoreRunExecutableFailed").FormatTitle(ex.Message).Show(MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

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
            if (!formModsBackupCreated)
            {
                IniFiles.Instance.BackupAll("Backup_BeforeManageMods"); // Just to be sure...
                formModsBackupCreated = true;
            }
            this.formMods.OpenUI();
        }

        /*private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://felisdiligens.github.io/Fo76ini/index.html");
        }*/

        /*private void buttonFixIssuesEarlierVersion_Click(object sender, EventArgs e)
        {
            // Reset all values to default, that I removed but where present in previous versions.

            //LinkInt(this.numGrassDensity, IniFile.F76Custom, "Grass", "iMinGrassSize", 20);
            IniFiles.Instance.Remove(IniFile.F76Custom, "Grass", "iMinGrassSize");
            //IniFiles.Instance.Set(IniFile.F76, "Grass", "iMinGrassSize", 20);
            //IniFiles.Instance.Set(IniFile.F76Prefs, "Grass", "iMinGrassSize", 20);

            // IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterDisplacements", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterRefractions", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterReflections", true);
            // IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bFogEnabled", true);
            // IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bRainOcclusion", true);
            // IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bWetnessOcclusion", true);

            IniFiles.Instance.Set(IniFile.F76, "Display", "fSunUpdateThreshold", 0.5f);
            IniFiles.Instance.Set(IniFile.F76, "Display", "fSunShadowUpdateTime", 1.0f);

            // IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "bMouseAcceleration");

            MsgBox.Get("oldValuesResetToDefault").Popup(MessageBoxIcon.Information);
        }*/

        /*
         * Game edition
         */

        private void ChangeGameEdition(GameEdition edition)
        {
            bool restartRequired = ManagedMods.Instance.GameEdition != GameEdition.Unknown && ((ManagedMods.Instance.GameEdition == GameEdition.MSStore && edition != GameEdition.MSStore) || (ManagedMods.Instance.GameEdition != GameEdition.MSStore && edition == GameEdition.MSStore));

            if (restartRequired && MsgBox.Get("msstoreRestartRequired").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                switch (ManagedMods.Instance.GameEdition)
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
                    this.pictureBoxGameEdition.Image = Properties.Resources.question_mark;
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

            IniFiles.Instance.ChangeGameEdition(edition);
            this.formMods.ChangeGameEdition(edition);
            this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;

            if (restartRequired)
            {
                IniFiles.Instance.SaveWindowState("Form1", this);
                Application.Restart();
            }
        }

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionSteam.Checked)
                ChangeGameEdition(GameEdition.Steam);
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionBethesdaNet.Checked)
                ChangeGameEdition(GameEdition.BethesdaNet);
        }

        private void radioButtonEditionBethesdaNetPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionBethesdaNetPTS.Checked)
                ChangeGameEdition(GameEdition.BethesdaNetPTS);
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionMSStore.Checked)
                ChangeGameEdition(GameEdition.MSStore);
        }

        // Nuclear Winter mode
        private void checkBoxNWMode_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.nuclearWinterMode = checkBoxNWMode.Checked;
            if (IniFiles.Instance.nuclearWinterMode && !ManagedMods.Instance.nuclearWinterMode)
            {
                if (MsgBox.ShowID("nwModeEnabledButModsAreDeployed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Disable mods:
                    ManagedMods.Instance.nuclearWinterMode = true;
                    this.formMods.OpenUI();
                    this.formMods.Deploy();
                }
            }
            else if (!IniFiles.Instance.nuclearWinterMode && ManagedMods.Instance.nuclearWinterMode && ManagedMods.Instance.Mods.Count() > 0)
            {
                if (MsgBox.ShowID("nwModeDisabledAndModsAreStillDisabled", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Enable mods:
                    ManagedMods.Instance.nuclearWinterMode = false;
                    this.formMods.OpenUI();
                    this.formMods.Deploy();
                }
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/8185747/how-can-i-unmask-password-text-box-and-mask-it-back-to-password
            this.textBoxPassword.UseSystemPasswordChar = !this.checkBoxShowPassword.Checked;
            this.textBoxPassword.PasswordChar = !this.checkBoxShowPassword.Checked ? '\u2022' : '\0';
        }

        private void buttonDetectResolution_Click(object sender, EventArgs e)
        {
            int[] res = Utils.GetDisplayResolution();
            String resStr = $"{res[0]}x{res[1]}";

            ComboBoxContainer resolution = ComboBoxContainer.Get("Resolution");
            if (resolution.Contains(resStr))
            {
                int index = resolution.FindIndex(resStr);
                resolution.SelectedIndex = index;
            }
            else
            {
                resolution.SelectedIndex = 0;
            }
            this.numCustomResW.Value = res[0];
            this.numCustomResH.Value = res[1];
        }

        private void timerCheckFiles_Tick(object sender, EventArgs e)
        {
            // Check every 5 seconds, if files have been modified:
            if (IniFiles.Instance.FilesHaveBeenModified())
            {
                IniFiles.Instance.UpdateLastModifiedDates();

                // Don't prompt, if Fallout 76 is running....
                if (ManagedMods.Instance.GameEdition == GameEdition.MSStore ?
                        //!Utils.IsProcessRunning("Project76_GamePass") :
                        !Utils.IsProcessRunning("Project76") :
                        !Utils.IsProcessRunning("Fallout76"))
                    MsgBox.Get("iniFilesModified").Popup(MessageBoxIcon.Warning);
            }
        }

        private void checkBoxQuitOnGameLaunch_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "bQuitOnLaunch", this.checkBoxQuitOnGameLaunch.Checked);
        }

        private void checkBoxAutoApply_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "bAutoApply", this.checkBoxAutoApply.Checked);
        }

        private void checkBoxSkipBackupQuestion_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "bSkipBackupQuestion", this.checkBoxSkipBackupQuestion.Checked);
        }

        private void checkBoxOpenManageModsOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "bOpenModManagerOnLaunch", this.checkBoxOpenManageModsOnLaunch.Checked);
        }

        private void buttonUpdateNow_Click(object sender, EventArgs e)
        {
            // Set sInstallationPath:
            String installationPath = Path.GetFullPath(AppContext.BaseDirectory);
            IniFiles.Instance.Set(IniFile.Config, "Updater", "sInstallationPath", installationPath);
            IniFiles.Instance.SaveConfig();

            // Copy updater.exe to <config-path>\Updater\:
            String updaterPath = Path.Combine(Form1.AppConfigFolder, "Updater");
            List<String> updaterFiles = new List<String>() {
                "7z\\7za.dll",
                "7z\\7za.exe",
                "7z\\7zxa.dll",
                "INIFileParser.dll",
                "INIFileParser.xml",
                "Newtonsoft.Json.dll",
                "Newtonsoft.Json.xml",
                "updater.exe",
                "updater.exe.config",
                "updater.pdb"
            };
            Directory.CreateDirectory(updaterPath);
            Directory.CreateDirectory(Path.Combine(updaterPath, "7z"));
            foreach (String file in updaterFiles)
                File.Copy(file, Path.Combine(updaterPath, file), true);

            // Run updater.exe:
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(updaterPath, "updater.exe");
            // If the program is installed into C:\Program Files (x86)\ then run the updater as admin:
            if (installationPath.Contains("C:\\Program Files"))
                startInfo.Verb = "runas";
            Process.Start(startInfo);
            Application.Exit();
            //Environment.Exit(0);
        }

        private void checkBoxIgnoreUpdates_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "bIgnoreUpdates", this.checkBoxIgnoreUpdates.Checked);
            this.CheckVersion();
        }

        /*
         * Game path
         */

        // Pick game path
        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (ManagedMods.Instance.isDeploymentNecessary())
            {
                MsgBox.ShowID("modsDeploymentNecessary");
                return;
            }
            if (this.openFileDialogGamePath.ShowDialog() == DialogResult.OK)
            {
                String path = Path.GetDirectoryName(this.openFileDialogGamePath.FileName); // We want the path where Fallout76.exe resides.
                if (Directory.Exists(Path.Combine(path, "Data")))
                {
                    this.textBoxGamePath.Text = path;
                    ManagedMods.Instance.GamePath = path;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, path);
                    IniFiles.Instance.SaveConfig();
                    ManagedMods.Instance.Load();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        // Game path textbox changed
        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxGamePath.Focused)
            {
                if (ManagedMods.Instance.isDeploymentNecessary())
                {
                    if (this.textBoxGamePath.Text != ManagedMods.Instance.GamePath)
                        this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;
                    return;
                }
                else if (Directory.Exists(Path.Combine(this.textBoxGamePath.Text, "Data")))
                {
                    ManagedMods.Instance.GamePath = this.textBoxGamePath.Text;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, this.textBoxGamePath.Text);
                    IniFiles.Instance.SaveConfig();
                    ManagedMods.Instance.Load();
                    this.textBoxGamePath.ForeColor = Color.Black;
                    this.textBoxGamePath.BackColor = Color.White;
                }
                else
                {
                    this.textBoxGamePath.ForeColor = Color.White;
                    this.textBoxGamePath.BackColor = Color.Red;
                }
            }
        }

        private void radioButtonLaunchViaExecutable_CheckedChanged(object sender, EventArgs e)
        {
            this.labelLaunchOptionTip.Visible = false;
            this.labelLaunchOptionMSStoreNotice.Visible = false;

            if (ManagedMods.Instance.GameEdition == GameEdition.BethesdaNet || ManagedMods.Instance.GameEdition == GameEdition.BethesdaNetPTS)
                this.labelLaunchOptionTip.Visible = this.radioButtonLaunchViaExecutable.Checked;

            else if (ManagedMods.Instance.GameEdition == GameEdition.MSStore)
                this.labelLaunchOptionMSStoreNotice.Visible = this.radioButtonLaunchViaExecutable.Checked;
        }

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Form1.AppConfigFolder);
        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Path.Combine(Form1.AppConfigFolder, "languages"));
        }

        private void toolInstallationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Directory.GetParent(Application.ExecutablePath).ToString());
        }

        private void gameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(ManagedMods.Instance.GamePath);
        }

        private void gamesConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(IniFiles.Instance.iniParentPath);
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
            if (File.Exists(Path.Combine(Form1.AppConfigFolder, "updater.log.txt")))
                Utils.OpenNotepad(Path.Combine(Form1.AppConfigFolder, "updater.log.txt"));
        }

        private String customAddFilePath = "";

        private void comboBoxCustomFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fileName = "Invalid.add.ini";
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
            this.customAddFilePath = Path.Combine(IniFiles.Instance.iniParentPath, fileName);

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
    }
}
