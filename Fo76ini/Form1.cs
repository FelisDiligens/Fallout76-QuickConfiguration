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
    public enum GameEdition
    {
        Unknown = 0,
        BethesdaNet = 1,
        Steam = 2
    }

    public struct ComboBoxContainer
    {
        public ComboBox comboBox;
        private List<String> items;

        public ComboBoxContainer(ComboBox comboBox)
        {
            this.comboBox = comboBox;
            this.items = new List<String>();
            foreach (object item in comboBox.Items)
                this.items.Add((String)item);
        }

        public ComboBoxContainer(ComboBox comboBox, List<String> items)
        {
            this.comboBox = comboBox;
            this.items = items;
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public ComboBoxContainer(ComboBox comboBox, String[] items)
        {
            this.comboBox = comboBox;
            this.items = new List<String>();
            foreach (String item in items)
                this.items.Add(item);
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public void Add(String item)
        {
            this.comboBox.Items.Add(item);
            this.items.Add(item);
        }

        public void AddRange(String[] items)
        {
            this.comboBox.Items.AddRange(items);
            foreach (String item in items)
                this.items.Add(item);
        }

        public void Clear()
        {
            this.comboBox.Items.Clear();
            this.items.Clear();
        }

        public void SetRange(String[] items)
        {
            this.Clear();
            this.comboBox.Items.AddRange(items);
            foreach (String item in items)
                this.items.Add(item);
        }

        public List<String> Items
        {
            get { return this.items; }
            set
            {
                this.items = value;
                this.comboBox.Items.Clear();
                this.comboBox.Items.AddRange(value.ToArray());
            }
        }

        public int SelectedIndex
        {
            get { return this.comboBox.SelectedIndex; }
            set { this.comboBox.SelectedIndex = value; }
        }

        public String SelectedItem
        {
            get { return this.items[this.comboBox.SelectedIndex]; }
        }
    }

    public partial class Form1 : Form
    {
        public const String VERSION = "1.4.2";

        protected System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        delegate void OnLoadUIFunction();
        private List<OnLoadUIFunction> OnLoadUI = new List<OnLoadUIFunction>();

        private FormMods formMods;
        private bool formModsBackupCreated = false;

        private void LoadUI()
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (OnLoadUIFunction func in OnLoadUI)
            {
                try
                {
                    func();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
                MsgBox.Get("onLoadFuncException").FormatText(exceptions.Count.ToString(), exceptions[0].ToString()).Show(MessageBoxIcon.Error);
        }

        private Dictionary<String, ComboBoxContainer> comboBoxes = new Dictionary<String, ComboBoxContainer>();

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
            comboBoxes["Resolution"] = new ComboBoxContainer(
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
            );

            comboBoxes["DisplayMode"] = new ComboBoxContainer(
                this.comboBoxDisplayMode,
                new String[] {
                    "Fullscreen",
                    "Windowed",
                    "Borderless windowed",
                    "Borderless windowed (Fullscreen)"
                }
            );

            comboBoxes["AntiAliasing"] = new ComboBoxContainer(
                this.comboBoxAntiAliasing,
                new String[] {
                    "TAA (default)",
                    "FXAA",
                    "Disabled"
                }
            );

            comboBoxes["AnisotropicFiltering"] = new ComboBoxContainer(
                this.comboBoxAnisotropicFiltering,
                new String[] {
                    "None",
                    "2x",
                    "4x",
                    "8x (default)",
                    "16x"
                }
            );
            
            comboBoxes["ShadowTextureResolution"] = new ComboBoxContainer(
                this.comboBoxShadowTextureResolution,
                new String[] {
                    "1024 = Low",
                    "2048 = High (default)",
                    "4096 = Ultra"
                }
            );

            comboBoxes["ShadowBlurriness"] = new ComboBoxContainer(
                this.comboBoxShadowBlurriness,
                new String[] {
                    "1x",
                    "2x",
                    "3x = Default, recommended"
                }
            );


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

            this.formMods.UpdateModsUI();

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
            LoadUI();

            CheckVersion();
        }

        private void CheckVersion()
        {
            this.labelConfigVersion.Text = VERSION;
            using (StreamWriter f = new StreamWriter("VERSION"))
                f.Write(VERSION);

            string latestVersion = VERSION;
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/VERSION");
                latestVersion = Encoding.UTF8.GetString(raw).Trim();
            }
            catch (System.Net.WebException exc)
            {
                Console.WriteLine(exc.Message);
            }
            if (latestVersion != VERSION)
            {
                //MessageBox.Show("There is a newer version available on NexusMods! Check it out! :P", "New version");
                linkLabelDownloadPage.Visible = true;
                labelNewVersion.Text = String.Format(Translation.localizedStrings["newVersionAvailable"], latestVersion);
                this.labelConfigVersion.ForeColor = Color.Red;
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
            LinkSlider(this.sliderGrassFadeDistance, this.numGrassFadeDistance, 1);
            //LinkSlider(this.sliderGrassDensity, this.numGrassDensity, 1, true);
            LinkSlider(this.sliderLODObjects, this.numLODObjects, 10);
            LinkSlider(this.sliderLODItems, this.numLODItems, 10);
            LinkSlider(this.sliderLODActors, this.numLODActors, 10);
            LinkSlider(this.sliderShadowDistance, this.numShadowDistance, 1);
            LinkSlider(this.sliderMouseSensitivity, this.numMouseSensitivity, 10000.0);
            LinkSlider(this.sliderTAAPostOverlay, this.numTAAPostOverlay, 100);
            LinkSlider(this.sliderTAAPostSharpen, this.numTAAPostSharpen, 100);


            /*
             ********************************************
             * Link control elements:
             ********************************************
             */

            // Make *.ini files read-only
            LinkCustom(this.checkBoxReadOnly,
                IniFiles.Instance.AreINIsReadOnly,
                IniFiles.Instance.SetINIsReadOnly
            );


            /*
             * General
             */

            // Play intro videos
            LinkCustom(this.checkBoxIntroVideos,
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
            LinkBool(this.checkBoxMainMenuMusic, IniFile.F76Custom, "General", "bPlayMainMenuMusic", true);
            
            // Show splash screen with news on startup
            LinkBoolNegated(this.checkBoxShowSplash, IniFile.F76Custom, "General", "bSkipSplash", false);

            // General subtitles
            LinkBool(this.checkBoxGeneralSubtitles, IniFile.F76Prefs, "Interface", "bGeneralSubtitles", false);

            // Dialogue subtitles
            LinkBool(this.checkBoxDialogueSubtitles, IniFile.F76Prefs, "Interface", "bDialogueSubtitles", false);

            // Show damage numbers in nuclear winter
            LinkBool(this.checkBoxShowDamageNumbersNW, IniFile.F76Custom, "NuclearWinter", "bShowDamageNumbers", true);

            // Show damage numbers in adventure mode
            LinkBool(this.checkBoxShowDamageNumbersA, IniFile.F76Custom, "Adventure", "bShowDamageNumbers", false);

            // Show compass
            LinkBool(this.checkBoxShowCompass, IniFile.F76Prefs, "Interface", "bShowCompass", true);

            // Game Edition
            LinkList(
                new RadioButton[] { this.radioButtonEditionBethesdaNet, this.radioButtonEditionSteam },
                new String[] { "1", "2" },
                IniFile.Config, "Preferences", "uGameEdition",
                "0"
            );



            /*
             * Display
             */

            // Display mode
            LinkCustom(this.comboBoxDisplayMode,
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
            LinkCustom(this.comboBoxResolution,
                () => {
                    int width = IniFiles.Instance.GetInt("Display", "iSize W", 1920);
                    int height = IniFiles.Instance.GetInt("Display", "iSize H", 1080);
                    int resIndex = Array.IndexOf(this.comboBoxes["Resolution"].Items.ToArray(), $"{width}x{height}");
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
            LinkInt(this.numCustomResW, IniFile.F76Prefs, "Display", "iSize W", 1920);
            LinkInt(this.numCustomResH, IniFile.F76Prefs, "Display", "iSize H", 1080);

            // Hide (or show) custom resolution on load:
            OnLoadUI.Add(() =>
            {
                bool isCustomSelected = this.comboBoxResolution.SelectedIndex == 0;
                this.numCustomResW.Enabled = isCustomSelected;
                this.numCustomResH.Enabled = isCustomSelected;
            });

                // Top most window
                LinkBool(this.checkBoxTopMostWindow, IniFile.F76Prefs, "Display", "bTopMostWindow", false);

            // Always active
            LinkBool(this.checkBoxAlwaysActive, IniFile.F76Custom, "General", "bAlwaysActive", true);

            // 1st person FOV
            LinkCustom(this.numFirstPersonFOV,
                () => IniFiles.Instance.GetFloat("Display", "fDefault1stPersonFOV", 80),
                (value) => {
                    IniFiles.Instance.Set(IniFile.F76Custom, "Display", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Custom, "Interface", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Display", "fDefault1stPersonFOV", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Interface", "fDefault1stPersonFOV", value);
                }
            );

            // World FOV
            LinkCustom(this.numWorldFOV,
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
            LinkList(this.comboBoxAntiAliasing,
                new String[] { "TAA", "FXAA", "" },
                IniFile.F76Prefs, "Display", "sAntiAliasing",
                "TAA", 2);

            // Anisotropic filtering
            LinkList(this.comboBoxAnisotropicFiltering,
                new String[] { "0", "2", "4", "8", "16" },
                IniFile.F76Prefs, "Display", "iMaxAnisotropy",
                "8", 3);

            // iPresentInterval
            // I'm not so sure about this anymore:
            //    Actually, it's not VSync but a fps cap, which is determined this way: Monitor refresh rate divided by iPresentInterval
            //    A 120 Hz monitor and iPresentInterval set to 2 will result in a 60fps cap.
            //LinkBool(this.checkBoxVSync, IniFile.F76Prefs, "Display", "iPresentInterval", true);
            LinkCustom(this.checkBoxVSync,
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
            LinkCustom(this.checkBoxDepthOfField,
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
            LinkBool(this.checkBoxMotionBlur, IniFile.F76Custom, "ImageSpace", "bMBEnable", true);

            // Radial Blur
            LinkBool(this.checkBoxRadialBlur, IniFile.F76Custom, "ImageSpace", "bDoRadialBlur", true);

            // Lens Flare
            LinkBool(this.checkBoxLensFlare, IniFile.F76Prefs, "ImageSpace", "bLensFlare", true);

            // Ambient Occlusion
            LinkBool(this.checkBoxAmbientOcclusion, IniFile.F76Prefs, "Display", "bSAOEnable", true);

            // Water / Displacement
            LinkBool(this.checkBoxWaterDisplacement, IniFile.F76Prefs, "Water", "bUseWaterDisplacements", true);

            // Weather / Rain Occlusion
            LinkBool(this.checkBoxWeatherRainOcclusion, IniFile.F76, "Weather", "bRainOcclusion", true);

            // Weather / Wetness Occlusion
            LinkBool(this.checkBoxWeatherWetnessOcclusion, IniFile.F76, "Weather", "bWetnessOcclusion", true);

            // Lighting / Volumetric Lighting
            LinkBool(this.checkBoxGodrays, IniFile.F76Prefs, "Display", "bVolumetricLightingEnable", true);

            // Shadows / Texture map resolution
            LinkList(this.comboBoxShadowTextureResolution,
                new String[] { "1024", "2048", "4096" },
                IniFile.F76Prefs, "Display", "iShadowMapResolution",
                "2048", 1);

            // Shadows / Blurriness
            LinkList(this.comboBoxShadowBlurriness,
                new String[] { "1", "2", "3" },
                IniFile.F76Prefs, "Display", "uiOrthoShadowFilter",
                "3", 2);

            // Shadow / Shadow distance
            // fShadowDistance was replaced by fDirShadowDistance in Fallout 4
            LinkInt(this.numShadowDistance, IniFile.F76Prefs, "Display", "fDirShadowDistance", 3000);

            // LOD Fade Distances
            LinkFloat(this.numLODObjects, IniFile.F76Prefs, "LOD", "fLODFadeOutMultObjects", 6.0f);
            LinkFloat(this.numLODItems, IniFile.F76Prefs, "LOD", "fLODFadeOutMultItems", 2.5f);
            LinkFloat(this.numLODActors, IniFile.F76Prefs, "LOD", "fLODFadeOutMultActors", 4.5f);

            // Grass / Enable grass
            LinkBool(this.checkBoxGrass, IniFile.F76Custom, "Grass", "bAllowCreateGrass", true);

            // Grass / Fade distance
            LinkCustom(this.numGrassFadeDistance,
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

            LinkFloat(this.numTAAPostOverlay, IniFile.F76Custom, "Display", "fTAAPostOverlay", 0.21f);
            LinkFloat(this.numTAAPostSharpen, IniFile.F76Custom, "Display", "fTAAPostSharpen", 0.21f);


            /*
             * Controls
             */

            // Fix mouse sensitivity
            LinkCustom(this.checkBoxFixMouseSensitivity,
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
            LinkCustom(this.checkBoxFixAimSensitivity,
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
            LinkCustom(this.numMouseSensitivity,
                () => IniFiles.Instance.GetFloat("Controls", "fMouseHeadingSensitivity", 0.03f),
                (value) => {
                    // Fallout76Custom.ini had no effect. I hope Fallout76Prefs.ini will have an effect this time:
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Controls", "fMouseHeadingSensitivity", value);
                    IniFiles.Instance.Set(IniFile.F76Prefs, "Controls", "fMouseHeadingSensitivityY", value);
                }
            );

            // Gamepad
            LinkBool(this.checkBoxGamepadEnabled, IniFile.F76Prefs, "General", "bGamepadEnable", true);
            LinkBool(this.checkBoxGamepadRumble, IniFile.F76Custom, "Controls", "bGamePadRumble", true);



            /*
             * Pipboy
             */

            // Radiobuttons, Quickboy or Pipboy
            LinkBool(this.radioButtonQuickboy, this.radioButtonPipboy, IniFile.F76Prefs, "Pipboy", "bQuickboyMode", false);

            // Resolution
            LinkInt(this.numPipboyTargetWidth, IniFile.F76Prefs, "Display", "uPipboyTargetWidth", 876);
            LinkInt(this.numPipboyTargetHeight, IniFile.F76Prefs, "Display", "uPipboyTargetHeight", 700);
        }



        /*
         **************************************************************
         * Link control elements together
         **************************************************************
         */

        // Link slider to num and vice-versa

        private void LinkSlider(MetroFramework.Controls.MetroTrackBar slider, NumericUpDown num, double numToSliderRatio)
        {
            LinkSlider(slider, num, numToSliderRatio, false);
        }

        private void LinkSlider(MetroFramework.Controls.MetroTrackBar slider, NumericUpDown num, double numToSliderRatio, bool reversed)
        {
            if (!reversed)
            {
                slider.Scroll += (object sender, ScrollEventArgs e) => num.Value = Convert.ToDecimal(slider.Value / numToSliderRatio);
                num.ValueChanged += (object sender, EventArgs e) => slider.Value = Convert.ToInt32(Convert.ToDouble(num.Value) * numToSliderRatio);
            }
            else
            {
                slider.Scroll += (object sender, ScrollEventArgs e) => num.Value = Convert.ToDecimal((slider.Maximum - slider.Value) / numToSliderRatio);
                num.ValueChanged += (object sender, EventArgs e) => slider.Value = Convert.ToInt32(slider.Maximum - Convert.ToDouble(num.Value) * numToSliderRatio);
            }
        }



        /*
         **************************************************************
         * Link *.ini states to control elements
         **************************************************************
         */

        // comboBox.SelectedIndexChanged => comboBox.SelectionChangeCommitted
        // checkBox.CheckedChanged       => checkBox.MouseClick
        // radioButton.CheckedChanged    => radioButton.MouseClick

        private void LinkCustom(CheckBox checkBox, Func<bool> getState, Action<bool> setState)
        {
            OnLoadUI.Add(() => checkBox.Checked = getState());
            checkBox.MouseClick += (object sender, MouseEventArgs e) => setState(checkBox.Checked);
        }

        private void LinkCustom(ComboBox comboBox, Func<int> getState, Action<int> setState)
        {
            OnLoadUI.Add(() => comboBox.SelectedIndex = getState());
            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => setState(comboBox.SelectedIndex);
        }

        private void LinkCustom(NumericUpDown num, Func<int> getState, Action<int> setState)
        {
            OnLoadUI.Add(() => num.Value = Utils.Clamp(getState(), Convert.ToInt32(num.Minimum), Convert.ToInt32(num.Maximum)));
            num.ValueChanged += (object sender, EventArgs e) => setState(Convert.ToInt32(num.Value));
        }

        private void LinkCustom(NumericUpDown num, Func<float> getState, Action<float> setState)
        {
            OnLoadUI.Add(() => num.Value = Convert.ToDecimal(Utils.Clamp(getState(), Convert.ToSingle(num.Minimum), Convert.ToSingle(num.Maximum)), enUS));
            num.ValueChanged += (object sender, EventArgs e) => setState(Convert.ToSingle(num.Value));
        }

        private void LinkBoolNegated(CheckBox checkBox, IniFile f, String section, String key, bool defaultValue)
        {
            LinkBool(checkBox, f, section, key, defaultValue, true);
        }

        private void LinkBool(CheckBox checkBox, IniFile f, String section, String key, bool defaultValue, bool negated = false)
        {
            OnLoadUI.Add(() => {
                bool val = IniFiles.Instance.GetBool(f, section, key, defaultValue);
                checkBox.Checked = negated ? !val : val;
            });
            checkBox.MouseClick += (object sender, MouseEventArgs e) => {
                if (f == IniFile.F76Custom && (negated ? !checkBox.Checked : checkBox.Checked) == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, negated ? !checkBox.Checked : checkBox.Checked);
            };
        }

        private void LinkBool(RadioButton radioButtonTrue, RadioButton radioButtonFalse, IniFile f, String section, String key, bool defaultValue)
        {
            OnLoadUI.Add(() => {
                bool val = IniFiles.Instance.GetBool(f, section, key, defaultValue);
                if (val)
                    radioButtonTrue.Checked = true;
                else
                    radioButtonFalse.Checked = true;
            });
            radioButtonTrue.MouseClick += (object sender, MouseEventArgs e) => {
                if (radioButtonTrue.Checked)
                    IniFiles.Instance.Set(f, section, key, true);
            };
            radioButtonFalse.MouseClick += (object sender, MouseEventArgs e) => {
                if (radioButtonFalse.Checked)
                    IniFiles.Instance.Set(f, section, key, false);
            };
        }

        private void LinkInt(NumericUpDown num, IniFile f, String section, String key, int defaultValue)
        {
            OnLoadUI.Add(() => {
                num.Value = Utils.Clamp(IniFiles.Instance.GetInt(f, section, key, defaultValue), Convert.ToInt32(num.Minimum), Convert.ToInt32(num.Maximum));
            });
            num.ValueChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && num.Value == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, Convert.ToInt32(num.Value));
            };
        }

        private void LinkFloat(NumericUpDown num, IniFile f, String section, String key, float defaultValue)
        {
            OnLoadUI.Add(() => {
                num.Value = Convert.ToDecimal(Utils.Clamp(IniFiles.Instance.GetFloat(f, section, key, defaultValue), Convert.ToSingle(num.Minimum), Convert.ToSingle(num.Maximum)));
            });
            num.ValueChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && Convert.ToSingle(num.Value) == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, Convert.ToSingle(num.Value));
            };
        }

        private void LinkString(TextBox textBox, IniFile f, String section, String key, String defaultValue)
        {
            OnLoadUI.Add(() => textBox.Text = IniFiles.Instance.GetString(section, key, defaultValue));
            textBox.TextChanged += (object sender, EventArgs e) => IniFiles.Instance.Set(f, section, key, textBox.Text);
        }

        private void LinkList(RadioButton[] radioButtons, String[] associatedValues, IniFile f, String section, String key, String defaultValue)
        {
            if (radioButtons.Length != associatedValues.Length)
                throw new ArgumentException("LinkList: radioButtons and associatedValues have to have the same length!");

            OnLoadUI.Add(() => {
                String value = IniFiles.Instance.GetString(f, section, key, defaultValue);
                int index = Array.IndexOf(associatedValues, value);
                if (index > -1)
                {
                    radioButtons[index].Checked = true;
                }
            });

            // I have a really bad feeling about this:
            for (int i = 0; i < radioButtons.Length; i++)
            {
                RadioButton radioButton = radioButtons[i];
                String associatedValue = associatedValues[i];
                radioButton.MouseClick += (object sender, MouseEventArgs e) => {
                    if (radioButton.Checked)
                        IniFiles.Instance.Set(f, section, key, associatedValue);
                };
            }
        }

        private void LinkList(ComboBox comboBox, String[] associatedValues, IniFile f, String section, String key, String defaultValue, int defaultComboBoxIndex)
        {
            if (comboBox.Items.Count != associatedValues.Length)
                throw new ArgumentException("LinkList: comboBox has to have as many items as associatedValues has!");

            OnLoadUI.Add(() => {
                String value = IniFiles.Instance.GetString(f, section, key, defaultValue);
                int index = Array.IndexOf(associatedValues, value);
                if (index > -1)
                    comboBox.SelectedIndex = index;
                else
                    comboBox.SelectedIndex = defaultComboBoxIndex;
            });
            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => {
                IniFiles.Instance.Set(f, section, key, associatedValues[comboBox.SelectedIndex]);
            };
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

            IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterDisplacements", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterRefractions", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Water", "bUseWaterReflections", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bFogEnabled", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bRainOcclusion", true);
            IniFiles.Instance.Set(IniFile.F76Prefs, "Weather", "bWetnessOcclusion", true);

            IniFiles.Instance.Set(IniFile.F76, "Display", "fSunUpdateThreshold", 0.5f);
            IniFiles.Instance.Set(IniFile.F76, "Display", "fSunShadowUpdateTime", 1.0f);

            IniFiles.Instance.Remove(IniFile.F76Custom, "Controls", "bMouseAcceleration");

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
    }
}
