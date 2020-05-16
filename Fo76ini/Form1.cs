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

namespace Fo76ini
{
    public partial class Form1 : Form
    {
        public const String VERSION = "1.5.2";

        protected System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        private UILoader uiLoader = new UILoader();

        private FormMods formMods;
        private bool formModsBackupCreated = false;


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
                if (subControl.Name.StartsWith("num") || subControl.Name.StartsWith("comboBox"))
                    subControl.MouseWheel += (object sender, MouseEventArgs e) => ((HandledMouseEventArgs)e).Handled = true;

                // TabControl, TabPage, and GroupBox:
                if (subControl.Name.StartsWith("tab") || subControl.Name.StartsWith("groupBox"))
                    PreventChangeOnMouseWheelForAllElements(subControl);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load QuickConfiguration.ini
            IniFiles.Instance.LoadConfig();

            this.formMods = new FormMods();
            //this.formMods.Show();
            //this.formMods.Hide();

            // Load the languages
            LookupLanguages();

            //this.formMods.UpdateModsUI();

            // Load *.ini files:
            try
            {
                IniFiles.Instance.LoadGameInis();
            }
            catch (IniParser.Exceptions.ParsingException exc)
            {
                MessageBox.Show(exc.Message, "Couldn't parse *.ini files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            catch (FileNotFoundException exc)
            {
                MsgBox.Get("runGameToGenerateINI").Show(MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Setup UI:
            ColorIni2Ui();
            AddAllEventHandler();
            uiLoader.Update();

            CheckVersion();
        }

        private void CheckVersion()
        {
            this.labelConfigVersion.Text = VERSION;
            using (StreamWriter f = new StreamWriter("VERSION"))
                f.Write(VERSION);

            String latestVersion = VERSION;
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/VERSION");
                latestVersion = Encoding.UTF8.GetString(raw).Trim();
            }
            catch (System.Net.WebException exc)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                linkLabelDownloadPage.Visible = false;
                labelNewVersion.Visible = false;
                return;
            }

            int cmp = Utils.CompareVersions(latestVersion, VERSION);
            if (cmp > 0)
            {
                linkLabelDownloadPage.Visible = true;
                labelNewVersion.Text = String.Format(Translation.localizedStrings["newVersionAvailable"], latestVersion);
                labelNewVersion.ForeColor = Color.Crimson;
                labelNewVersion.Visible = true;
                this.labelConfigVersion.ForeColor = Color.Red;
            }
            else if (cmp < 0)
            {
                linkLabelDownloadPage.Visible = false;
                labelNewVersion.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkBlue;
            }
            else
            {
                linkLabelDownloadPage.Visible = false;
                labelNewVersion.Visible = false;
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

            /*
             * Underneath tabcontrol
             */

            // Game Edition
            uiLoader.LinkList(
                new RadioButton[] { this.radioButtonEditionBethesdaNet, this.radioButtonEditionSteam },
                new String[] { "1", "2" },
                IniFile.Config, "Preferences", "uGameEdition",
                "0"
            );

            // Nuclear winter mode
            uiLoader.LinkBool(
                this.checkBoxNWMode,
                IniFile.Config, "Preferences", "bNWMode",
                false
            );


            /*
             * General
             */

            // Credentials
            uiLoader.LinkString(this.textBoxUserName, IniFile.F76Custom, "Login", "s76UserName", "");
            uiLoader.LinkString(this.textBoxPassword, IniFile.F76Custom, "Login", "s76Password", "");

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

            // Play music in main menu
            uiLoader.LinkBool(this.checkBoxMainMenuMusic, IniFile.F76Custom, "General", "bPlayMainMenuMusic", true);

            // Show splash screen with news on startup
            uiLoader.LinkBoolNegated(this.checkBoxShowSplash, IniFile.F76Custom, "General", "bSkipSplash", false);

            // General subtitles
            uiLoader.LinkBool(this.checkBoxGeneralSubtitles, IniFile.F76Prefs, "Interface", "bGeneralSubtitles", false);

            // Dialogue subtitles
            uiLoader.LinkBool(this.checkBoxDialogueSubtitles, IniFile.F76Prefs, "Interface", "bDialogueSubtitles", false);

            // Show damage numbers in nuclear winter
            uiLoader.LinkBool(this.checkBoxShowDamageNumbersNW, IniFile.F76Prefs, "NuclearWinter", "bShowDamageNumbers", true);

            // Show damage numbers in adventure mode
            uiLoader.LinkBool(this.checkBoxShowDamageNumbersA, IniFile.F76Prefs, "Adventure", "bShowDamageNumbers", false);

            // Show compass
            uiLoader.LinkBool(this.checkBoxShowCompass, IniFile.F76Prefs, "Interface", "bShowCompass", true);



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
                () => IniFiles.Instance.GetFloat("Main", "fIronSightsFOVRotateMult", 0f) - 2.14f < 0.1f,
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



            /*
             * Pipboy
             */

            // Radiobuttons, Quickboy or Pipboy
            uiLoader.LinkBool(this.radioButtonQuickboy, this.radioButtonPipboy, IniFile.F76Prefs, "Pipboy", "bQuickboyMode", false);

            // Resolution
            uiLoader.LinkInt(this.numPipboyTargetWidth, IniFile.F76Prefs, "Display", "uPipboyTargetWidth", 876);
            uiLoader.LinkInt(this.numPipboyTargetHeight, IniFile.F76Prefs, "Display", "uPipboyTargetHeight", 700);
        }


        /*
         **************************************************************
         * Event handlers
         **************************************************************
         */

        // "Apply" button:
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Show a messagebox to ask the user, if they want to make a backup.

            System.Media.SystemSounds.Asterisk.Play();
            DialogResult res = MsgBox.Get("backupAndSave").Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Cancel)
                return;
            else if (res == DialogResult.Yes)
                // Make backups
                IniFiles.Instance.BackupAll();

            // Save stuff to INI
            ColorUi2Ini();
            IniFiles.Instance.SaveAll(this.checkBoxReadOnly.Checked);
            MsgBox.Get("changesApplied").Show(MessageBoxButtons.OK, MessageBoxIcon.Information);

            IniFiles.Instance.ResolveNWMode();
        }

        // [ ] "Make *.ini files read-only" checkbox:
        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.SetINIsReadOnly(this.checkBoxReadOnly.Checked);
        }

        // "Launch Game" button:
        private void buttonLaunchGame_Click(object sender, EventArgs e)
        {
            uint uGameEdition = IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uGameEdition", 0);
            switch (uGameEdition)
            {
                case (uint)GameEdition.BethesdaNet:
                    System.Diagnostics.Process.Start("bethesdanet://run/20");
                    return;
                case (uint)GameEdition.Steam:
                    System.Diagnostics.Process.Start("steam://run/1151340"); // "steam://runappid/1151340"
                    return;
                default:
                    MsgBox.Get("chooseGameEdition").Show(MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
        }

        // "Get the latest version from NexusMods" link:
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelDownloadPage.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.nexusmods.com/fallout76/mods/546");
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



        private void buttonManageMods_Click(object sender, EventArgs e)
        {
            if (!formModsBackupCreated)
            {
                IniFiles.Instance.BackupAll("Backup_BeforeManageMods"); // Just to be sure...
                formModsBackupCreated = true;
            }
            Utils.SetFormPosition(this.formMods, this.Location.X + this.Width, this.Location.Y);
            this.formMods.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://felisdiligens.github.io/Fo76ini/index.html");
        }

        private void buttonFixIssuesEarlierVersion_Click(object sender, EventArgs e)
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

            MsgBox.ShowID("oldValuesResetToDefault", MessageBoxIcon.Information);
        }

        /*
         * Game edition
         */

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEditionSteam.Checked)
                this.formMods.ChangeGameEdition(GameEdition.Steam);
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEditionBethesdaNet.Checked)
                this.formMods.ChangeGameEdition(GameEdition.BethesdaNet);
        }

        // Nuclear Winter mode
        private void checkBoxNWMode_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.nuclearWinterMode = checkBoxNWMode.Checked;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/8185747/how-can-i-unmask-password-text-box-and-mask-it-back-to-password
            this.textBoxPassword.UseSystemPasswordChar = !this.checkBoxShowPassword.Checked;
            this.textBoxPassword.PasswordChar = !this.checkBoxShowPassword.Checked ? '\u2022' : '\0';
        }
    }
}
