namespace Fo76ini
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelPipboyColor = new System.Windows.Forms.Label();
            this.labelQuickboyColor = new System.Windows.Forms.Label();
            this.radioButtonPipboy = new System.Windows.Forms.RadioButton();
            this.radioButtonQuickboy = new System.Windows.Forms.RadioButton();
            this.numPipboyTargetWidth = new System.Windows.Forms.NumericUpDown();
            this.numPipboyTargetHeight = new System.Windows.Forms.NumericUpDown();
            this.buttonPipboyTargetReset = new System.Windows.Forms.Button();
            this.buttonPipboyTargetSetRecommended = new System.Windows.Forms.Button();
            this.checkBoxFixMouseSensitivity = new System.Windows.Forms.CheckBox();
            this.sliderMouseSensitivity = new MetroFramework.Controls.MetroTrackBar();
            this.checkBoxFixAimSensitivity = new System.Windows.Forms.CheckBox();
            this.checkBoxGamepadRumble = new System.Windows.Forms.CheckBox();
            this.checkBoxGamepadEnabled = new System.Windows.Forms.CheckBox();
            this.labelAntiAliasing = new System.Windows.Forms.Label();
            this.checkBoxVSync = new System.Windows.Forms.CheckBox();
            this.labelAnisotropicFiltering = new System.Windows.Forms.Label();
            this.checkBoxWeatherRainOcclusion = new System.Windows.Forms.CheckBox();
            this.checkBoxWeatherWetnessOcclusion = new System.Windows.Forms.CheckBox();
            this.checkBoxLensFlare = new System.Windows.Forms.CheckBox();
            this.checkBoxRadialBlur = new System.Windows.Forms.CheckBox();
            this.checkBoxMotionBlur = new System.Windows.Forms.CheckBox();
            this.checkBoxDepthOfField = new System.Windows.Forms.CheckBox();
            this.checkBoxAmbientOcclusion = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterDisplacement = new System.Windows.Forms.CheckBox();
            this.labelShadowTextureResolution = new System.Windows.Forms.Label();
            this.sliderShadowDistance = new MetroFramework.Controls.MetroTrackBar();
            this.labelShadowBlurriness = new System.Windows.Forms.Label();
            this.checkBoxGodrays = new System.Windows.Forms.CheckBox();
            this.sliderLODObjects = new MetroFramework.Controls.MetroTrackBar();
            this.sliderLODItems = new MetroFramework.Controls.MetroTrackBar();
            this.sliderLODActors = new MetroFramework.Controls.MetroTrackBar();
            this.checkBoxGrass = new System.Windows.Forms.CheckBox();
            this.sliderGrassFadeDistance = new MetroFramework.Controls.MetroTrackBar();
            this.labelCustomResolution = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.numCustomResW = new System.Windows.Forms.NumericUpDown();
            this.labelDisplayMode = new System.Windows.Forms.Label();
            this.numCustomResH = new System.Windows.Forms.NumericUpDown();
            this.labelFirstPersonFOV = new System.Windows.Forms.Label();
            this.labelWorldFOV = new System.Windows.Forms.Label();
            this.checkBoxTopMostWindow = new System.Windows.Forms.CheckBox();
            this.checkBoxAlwaysActive = new System.Windows.Forms.CheckBox();
            this.checkBoxMainMenuMusic = new System.Windows.Forms.CheckBox();
            this.checkBoxIntroVideos = new System.Windows.Forms.CheckBox();
            this.checkBoxShowSplash = new System.Windows.Forms.CheckBox();
            this.checkBoxDialogueSubtitles = new System.Windows.Forms.CheckBox();
            this.checkBoxGeneralSubtitles = new System.Windows.Forms.CheckBox();
            this.checkBoxShowDamageNumbersA = new System.Windows.Forms.CheckBox();
            this.checkBoxShowDamageNumbersNW = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCompass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sliderTAAPostOverlay = new MetroFramework.Controls.MetroTrackBar();
            this.sliderTAAPostSharpen = new MetroFramework.Controls.MetroTrackBar();
            this.checkBoxMouseAcceleration = new System.Windows.Forms.CheckBox();
            this.checkBoxFogEnabled = new System.Windows.Forms.CheckBox();
            this.buttonLaunchGame = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabPagePipBoy = new System.Windows.Forms.TabPage();
            this.groupBoxPipboyResolution = new System.Windows.Forms.GroupBox();
            this.labelPipboyResolutionSideNote = new System.Windows.Forms.Label();
            this.labelPipboyResolutionSpacer = new System.Windows.Forms.Label();
            this.groupBoxPipboyMode = new System.Windows.Forms.GroupBox();
            this.groupBoxPipboyColors = new System.Windows.Forms.GroupBox();
            this.colorPreviewPAPipboy = new System.Windows.Forms.PictureBox();
            this.buttonColorPickPAPipboy = new System.Windows.Forms.Button();
            this.buttonColorResetPipboy = new System.Windows.Forms.Button();
            this.buttonColorResetPAPipboy = new System.Windows.Forms.Button();
            this.colorPreviewPipboy = new System.Windows.Forms.PictureBox();
            this.colorPreviewQuickboy = new System.Windows.Forms.PictureBox();
            this.buttonColorPickQuickboy = new System.Windows.Forms.Button();
            this.buttonColorResetQuickboy = new System.Windows.Forms.Button();
            this.buttonColorPickPipboy = new System.Windows.Forms.Button();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.groupBoxGamepad = new System.Windows.Forms.GroupBox();
            this.groupBoxMouse = new System.Windows.Forms.GroupBox();
            this.numMouseSensitivity = new System.Windows.Forms.NumericUpDown();
            this.labelMouseSensitivity = new System.Windows.Forms.Label();
            this.tabPageGraphics = new System.Windows.Forms.TabPage();
            this.groupBoxTAASharpening = new System.Windows.Forms.GroupBox();
            this.numTAAPostSharpen = new System.Windows.Forms.NumericUpDown();
            this.labelTAAPostSharpen = new System.Windows.Forms.Label();
            this.numTAAPostOverlay = new System.Windows.Forms.NumericUpDown();
            this.labelTAAPostOverlay = new System.Windows.Forms.Label();
            this.groupBoxGrass = new System.Windows.Forms.GroupBox();
            this.numGrassFadeDistance = new System.Windows.Forms.NumericUpDown();
            this.labelGrassFadeDistance = new System.Windows.Forms.Label();
            this.groupBoxLOD = new System.Windows.Forms.GroupBox();
            this.labelLODFadeDistance = new System.Windows.Forms.Label();
            this.numLODActors = new System.Windows.Forms.NumericUpDown();
            this.numLODItems = new System.Windows.Forms.NumericUpDown();
            this.numLODObjects = new System.Windows.Forms.NumericUpDown();
            this.labelLODActors = new System.Windows.Forms.Label();
            this.labelLODItems = new System.Windows.Forms.Label();
            this.labelLODObjects = new System.Windows.Forms.Label();
            this.groupBoxLighting = new System.Windows.Forms.GroupBox();
            this.groupBoxShadows = new System.Windows.Forms.GroupBox();
            this.comboBoxShadowBlurriness = new System.Windows.Forms.ComboBox();
            this.numShadowDistance = new System.Windows.Forms.NumericUpDown();
            this.labelShadowDistance = new System.Windows.Forms.Label();
            this.comboBoxShadowTextureResolution = new System.Windows.Forms.ComboBox();
            this.groupBoxWater = new System.Windows.Forms.GroupBox();
            this.groupBoxPostProcessing = new System.Windows.Forms.GroupBox();
            this.groupBoxWeather = new System.Windows.Forms.GroupBox();
            this.comboBoxAnisotropicFiltering = new System.Windows.Forms.ComboBox();
            this.comboBoxAntiAliasing = new System.Windows.Forms.ComboBox();
            this.tabPageDisplay = new System.Windows.Forms.TabPage();
            this.groupBoxFieldOfView = new System.Windows.Forms.GroupBox();
            this.numWorldFOV = new System.Windows.Forms.NumericUpDown();
            this.numFirstPersonFOV = new System.Windows.Forms.NumericUpDown();
            this.labelCustomResolutionSpacer = new System.Windows.Forms.Label();
            this.comboBoxDisplayMode = new System.Windows.Forms.ComboBox();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.labelCredentialsExplanation = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.groupBoxInterface = new System.Windows.Forms.GroupBox();
            this.groupBoxMainMenu = new System.Windows.Forms.GroupBox();
            this.groupBoxGameEdition = new System.Windows.Forms.GroupBox();
            this.radioButtonEditionSteam = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionBethesdaNet = new System.Windows.Forms.RadioButton();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.buttonFixIssuesEarlierVersion = new System.Windows.Forms.Button();
            this.labelTranslationAuthor = new System.Windows.Forms.Label();
            this.labelTranslationBy = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelAuthorName = new System.Windows.Forms.Label();
            this.labelConfigVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.linkLabelDownloadPage = new System.Windows.Forms.LinkLabel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonManageMods = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.checkBoxNWMode = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPipboyTargetWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPipboyTargetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResH)).BeginInit();
            this.tabPagePipBoy.SuspendLayout();
            this.groupBoxPipboyResolution.SuspendLayout();
            this.groupBoxPipboyMode.SuspendLayout();
            this.groupBoxPipboyColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewPAPipboy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewPipboy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewQuickboy)).BeginInit();
            this.tabPageControls.SuspendLayout();
            this.groupBoxGamepad.SuspendLayout();
            this.groupBoxMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivity)).BeginInit();
            this.tabPageGraphics.SuspendLayout();
            this.groupBoxTAASharpening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTAAPostSharpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTAAPostOverlay)).BeginInit();
            this.groupBoxGrass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrassFadeDistance)).BeginInit();
            this.groupBoxLOD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLODActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLODItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLODObjects)).BeginInit();
            this.groupBoxLighting.SuspendLayout();
            this.groupBoxShadows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShadowDistance)).BeginInit();
            this.groupBoxWater.SuspendLayout();
            this.groupBoxPostProcessing.SuspendLayout();
            this.groupBoxWeather.SuspendLayout();
            this.tabPageDisplay.SuspendLayout();
            this.groupBoxFieldOfView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorldFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPersonFOV)).BeginInit();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.groupBoxInterface.SuspendLayout();
            this.groupBoxMainMenu.SuspendLayout();
            this.groupBoxGameEdition.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApply.Location = new System.Drawing.Point(276, 526);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(96, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(6, 42);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(140, 17);
            this.checkBoxReadOnly.TabIndex = 4;
            this.checkBoxReadOnly.Text = "Make *.ini files read-only";
            this.toolTip.SetToolTip(this.checkBoxReadOnly, "This option will make all *.ini files read-only immediately.\r\nEnable this if your" +
        " settings get reverted.\r\n\r\nAffected files: %UserProfile%\\Documents\\My Games\\Fall" +
        "out 76\\*.ini");
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            this.checkBoxReadOnly.CheckedChanged += new System.EventHandler(this.checkBoxReadOnly_CheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // labelPipboyColor
            // 
            this.labelPipboyColor.AutoSize = true;
            this.labelPipboyColor.Location = new System.Drawing.Point(39, 24);
            this.labelPipboyColor.Name = "labelPipboyColor";
            this.labelPipboyColor.Size = new System.Drawing.Size(70, 13);
            this.labelPipboyColor.TabIndex = 32;
            this.labelPipboyColor.Text = "Pip-Boy Color";
            this.toolTip.SetToolTip(this.labelPipboyColor, "Affected values: fPipboyEffectColorR, fPipboyEffectColorG, fPipboyEffectColorB\r\nA" +
        "ffected files: Fallout76Prefs.ini");
            // 
            // labelQuickboyColor
            // 
            this.labelQuickboyColor.AutoSize = true;
            this.labelQuickboyColor.Location = new System.Drawing.Point(39, 53);
            this.labelQuickboyColor.Name = "labelQuickboyColor";
            this.labelQuickboyColor.Size = new System.Drawing.Size(83, 13);
            this.labelQuickboyColor.TabIndex = 34;
            this.labelQuickboyColor.Text = "Quick-Boy Color";
            this.toolTip.SetToolTip(this.labelQuickboyColor, "Affected values: fQuickBoyEffectColorR, fQuickBoyEffectColorG, fQuickBoyEffectCol" +
        "orB\r\nAffected files: Fallout76Custom.ini");
            // 
            // radioButtonPipboy
            // 
            this.radioButtonPipboy.AutoSize = true;
            this.radioButtonPipboy.Location = new System.Drawing.Point(11, 19);
            this.radioButtonPipboy.Name = "radioButtonPipboy";
            this.radioButtonPipboy.Size = new System.Drawing.Size(80, 17);
            this.radioButtonPipboy.TabIndex = 36;
            this.radioButtonPipboy.TabStop = true;
            this.radioButtonPipboy.Text = "Use PipBoy";
            this.toolTip.SetToolTip(this.radioButtonPipboy, "Affected values: bQuickboyMode\r\nAffected files: Fallout76Prefs.ini");
            this.radioButtonPipboy.UseVisualStyleBackColor = true;
            // 
            // radioButtonQuickboy
            // 
            this.radioButtonQuickboy.AutoSize = true;
            this.radioButtonQuickboy.Location = new System.Drawing.Point(11, 42);
            this.radioButtonQuickboy.Name = "radioButtonQuickboy";
            this.radioButtonQuickboy.Size = new System.Drawing.Size(93, 17);
            this.radioButtonQuickboy.TabIndex = 37;
            this.radioButtonQuickboy.TabStop = true;
            this.radioButtonQuickboy.Text = "Use QuickBoy";
            this.toolTip.SetToolTip(this.radioButtonQuickboy, "Affected values: bQuickboyMode\r\nAffected files: Fallout76Prefs.ini");
            this.radioButtonQuickboy.UseVisualStyleBackColor = true;
            // 
            // numPipboyTargetWidth
            // 
            this.numPipboyTargetWidth.Location = new System.Drawing.Point(6, 19);
            this.numPipboyTargetWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPipboyTargetWidth.Name = "numPipboyTargetWidth";
            this.numPipboyTargetWidth.Size = new System.Drawing.Size(149, 20);
            this.numPipboyTargetWidth.TabIndex = 1;
            this.toolTip.SetToolTip(this.numPipboyTargetWidth, "Changes the resolution width of the Pipboy/Quickboy.\r\n\r\nAffected values: uPipboyT" +
        "argetWidth\r\nAffected files: Fallout76Prefs.ini");
            // 
            // numPipboyTargetHeight
            // 
            this.numPipboyTargetHeight.Location = new System.Drawing.Point(181, 19);
            this.numPipboyTargetHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPipboyTargetHeight.Name = "numPipboyTargetHeight";
            this.numPipboyTargetHeight.Size = new System.Drawing.Size(153, 20);
            this.numPipboyTargetHeight.TabIndex = 2;
            this.toolTip.SetToolTip(this.numPipboyTargetHeight, "Changes the resolution height of the Pipboy/Quickboy.\r\n\r\nAffected values: uPipboy" +
        "TargetHeight\r\nAffected files: Fallout76Prefs.ini");
            // 
            // buttonPipboyTargetReset
            // 
            this.buttonPipboyTargetReset.Location = new System.Drawing.Point(6, 45);
            this.buttonPipboyTargetReset.Name = "buttonPipboyTargetReset";
            this.buttonPipboyTargetReset.Size = new System.Drawing.Size(149, 23);
            this.buttonPipboyTargetReset.TabIndex = 3;
            this.buttonPipboyTargetReset.Text = "Reset to default";
            this.toolTip.SetToolTip(this.buttonPipboyTargetReset, "Default values: 876x700");
            this.buttonPipboyTargetReset.UseVisualStyleBackColor = true;
            this.buttonPipboyTargetReset.Click += new System.EventHandler(this.buttonPipboyTargetReset_Click);
            // 
            // buttonPipboyTargetSetRecommended
            // 
            this.buttonPipboyTargetSetRecommended.Location = new System.Drawing.Point(164, 45);
            this.buttonPipboyTargetSetRecommended.Name = "buttonPipboyTargetSetRecommended";
            this.buttonPipboyTargetSetRecommended.Size = new System.Drawing.Size(170, 23);
            this.buttonPipboyTargetSetRecommended.TabIndex = 4;
            this.buttonPipboyTargetSetRecommended.Text = "Set recommended resolution";
            this.toolTip.SetToolTip(this.buttonPipboyTargetSetRecommended, "Recommended values: 1752x1400");
            this.buttonPipboyTargetSetRecommended.UseVisualStyleBackColor = true;
            this.buttonPipboyTargetSetRecommended.Click += new System.EventHandler(this.buttonPipboyTargetSetRecommended_Click);
            // 
            // checkBoxFixMouseSensitivity
            // 
            this.checkBoxFixMouseSensitivity.AutoSize = true;
            this.checkBoxFixMouseSensitivity.Location = new System.Drawing.Point(6, 98);
            this.checkBoxFixMouseSensitivity.Name = "checkBoxFixMouseSensitivity";
            this.checkBoxFixMouseSensitivity.Size = new System.Drawing.Size(208, 17);
            this.checkBoxFixMouseSensitivity.TabIndex = 0;
            this.checkBoxFixMouseSensitivity.Text = "Fix mouse horizontal/vertical sensitivity";
            this.toolTip.SetToolTip(this.checkBoxFixMouseSensitivity, resources.GetString("checkBoxFixMouseSensitivity.ToolTip"));
            this.checkBoxFixMouseSensitivity.UseVisualStyleBackColor = true;
            // 
            // sliderMouseSensitivity
            // 
            this.sliderMouseSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderMouseSensitivity.BackColor = System.Drawing.Color.Transparent;
            this.sliderMouseSensitivity.Location = new System.Drawing.Point(9, 37);
            this.sliderMouseSensitivity.Maximum = 900;
            this.sliderMouseSensitivity.Minimum = 1;
            this.sliderMouseSensitivity.Name = "sliderMouseSensitivity";
            this.sliderMouseSensitivity.Size = new System.Drawing.Size(264, 23);
            this.sliderMouseSensitivity.TabIndex = 2;
            this.sliderMouseSensitivity.Text = "metroTrackBar1";
            this.toolTip.SetToolTip(this.sliderMouseSensitivity, "Mouse sensitivity\r\n\r\nAffected values: fMouseHeadingSensitivity, fMouseHeadingSens" +
        "itivityY\r\nAffected files: Fallout76Custom.ini");
            this.sliderMouseSensitivity.Value = 300;
            // 
            // checkBoxFixAimSensitivity
            // 
            this.checkBoxFixAimSensitivity.AutoSize = true;
            this.checkBoxFixAimSensitivity.Location = new System.Drawing.Point(6, 121);
            this.checkBoxFixAimSensitivity.Name = "checkBoxFixAimSensitivity";
            this.checkBoxFixAimSensitivity.Size = new System.Drawing.Size(106, 17);
            this.checkBoxFixAimSensitivity.TabIndex = 5;
            this.checkBoxFixAimSensitivity.Text = "Fix aim sensitivity";
            this.toolTip.SetToolTip(this.checkBoxFixAimSensitivity, resources.GetString("checkBoxFixAimSensitivity.ToolTip"));
            this.checkBoxFixAimSensitivity.UseVisualStyleBackColor = true;
            // 
            // checkBoxGamepadRumble
            // 
            this.checkBoxGamepadRumble.AutoSize = true;
            this.checkBoxGamepadRumble.Checked = true;
            this.checkBoxGamepadRumble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGamepadRumble.Location = new System.Drawing.Point(6, 40);
            this.checkBoxGamepadRumble.Name = "checkBoxGamepadRumble";
            this.checkBoxGamepadRumble.Size = new System.Drawing.Size(227, 17);
            this.checkBoxGamepadRumble.TabIndex = 3;
            this.checkBoxGamepadRumble.Text = "Enable gamepad rumble (Force Feedback)";
            this.toolTip.SetToolTip(this.checkBoxGamepadRumble, "Enables rumbling (force feedback) of your gamepad.\r\n\r\nAffected values: bGamePadRu" +
        "mble\r\nAffected files: Fallout76Custom.ini");
            this.checkBoxGamepadRumble.UseVisualStyleBackColor = true;
            // 
            // checkBoxGamepadEnabled
            // 
            this.checkBoxGamepadEnabled.AutoSize = true;
            this.checkBoxGamepadEnabled.Checked = true;
            this.checkBoxGamepadEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGamepadEnabled.Location = new System.Drawing.Point(6, 19);
            this.checkBoxGamepadEnabled.Name = "checkBoxGamepadEnabled";
            this.checkBoxGamepadEnabled.Size = new System.Drawing.Size(106, 17);
            this.checkBoxGamepadEnabled.TabIndex = 2;
            this.checkBoxGamepadEnabled.Text = "Enable gamepad";
            this.toolTip.SetToolTip(this.checkBoxGamepadEnabled, "Uncheck this, if you have a gamepad plugged in, but want to use your keyboard and" +
        " mouse instead.\r\nLeave this checked otherwise.\r\n\r\nAffected values: bGamepadEnabl" +
        "e\r\nAffected files: Fallout76Custom.ini");
            this.checkBoxGamepadEnabled.UseVisualStyleBackColor = true;
            // 
            // labelAntiAliasing
            // 
            this.labelAntiAliasing.AutoSize = true;
            this.labelAntiAliasing.Location = new System.Drawing.Point(6, 9);
            this.labelAntiAliasing.Name = "labelAntiAliasing";
            this.labelAntiAliasing.Size = new System.Drawing.Size(67, 13);
            this.labelAntiAliasing.TabIndex = 0;
            this.labelAntiAliasing.Text = "Anti-Aliasing:";
            this.toolTip.SetToolTip(this.labelAntiAliasing, resources.GetString("labelAntiAliasing.ToolTip"));
            // 
            // checkBoxVSync
            // 
            this.checkBoxVSync.AutoSize = true;
            this.checkBoxVSync.Checked = true;
            this.checkBoxVSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVSync.Location = new System.Drawing.Point(9, 66);
            this.checkBoxVSync.Name = "checkBoxVSync";
            this.checkBoxVSync.Size = new System.Drawing.Size(137, 17);
            this.checkBoxVSync.TabIndex = 15;
            this.checkBoxVSync.Text = "Frame rate cap (VSync)";
            this.toolTip.SetToolTip(this.checkBoxVSync, resources.GetString("checkBoxVSync.ToolTip"));
            this.checkBoxVSync.UseVisualStyleBackColor = true;
            // 
            // labelAnisotropicFiltering
            // 
            this.labelAnisotropicFiltering.AutoSize = true;
            this.labelAnisotropicFiltering.Location = new System.Drawing.Point(6, 39);
            this.labelAnisotropicFiltering.Name = "labelAnisotropicFiltering";
            this.labelAnisotropicFiltering.Size = new System.Drawing.Size(84, 13);
            this.labelAnisotropicFiltering.TabIndex = 19;
            this.labelAnisotropicFiltering.Text = "Anisotropic filter:";
            this.toolTip.SetToolTip(this.labelAnisotropicFiltering, "Reduces aliasing of textures when viewed from oblique angles.\r\n\r\nDefault: 8\r\nAffe" +
        "cted values: iMaxAnisotropy\r\nAffected files: Fallout76Prefs.ini");
            // 
            // checkBoxWeatherRainOcclusion
            // 
            this.checkBoxWeatherRainOcclusion.AutoSize = true;
            this.checkBoxWeatherRainOcclusion.Checked = true;
            this.checkBoxWeatherRainOcclusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWeatherRainOcclusion.Location = new System.Drawing.Point(6, 39);
            this.checkBoxWeatherRainOcclusion.Name = "checkBoxWeatherRainOcclusion";
            this.checkBoxWeatherRainOcclusion.Size = new System.Drawing.Size(98, 17);
            this.checkBoxWeatherRainOcclusion.TabIndex = 1;
            this.checkBoxWeatherRainOcclusion.Text = "Rain Occlusion";
            this.toolTip.SetToolTip(this.checkBoxWeatherRainOcclusion, resources.GetString("checkBoxWeatherRainOcclusion.ToolTip"));
            this.checkBoxWeatherRainOcclusion.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeatherWetnessOcclusion
            // 
            this.checkBoxWeatherWetnessOcclusion.AutoSize = true;
            this.checkBoxWeatherWetnessOcclusion.Checked = true;
            this.checkBoxWeatherWetnessOcclusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWeatherWetnessOcclusion.Location = new System.Drawing.Point(6, 62);
            this.checkBoxWeatherWetnessOcclusion.Name = "checkBoxWeatherWetnessOcclusion";
            this.checkBoxWeatherWetnessOcclusion.Size = new System.Drawing.Size(118, 17);
            this.checkBoxWeatherWetnessOcclusion.TabIndex = 3;
            this.checkBoxWeatherWetnessOcclusion.Text = "Wetness Occlusion";
            this.toolTip.SetToolTip(this.checkBoxWeatherWetnessOcclusion, "Toggles environmental and clothing wetness occlusion\r\n\r\nAffected values: bWetness" +
        "Occlusion\r\nAffected files: Fallout76.ini");
            this.checkBoxWeatherWetnessOcclusion.UseVisualStyleBackColor = true;
            // 
            // checkBoxLensFlare
            // 
            this.checkBoxLensFlare.AutoSize = true;
            this.checkBoxLensFlare.Checked = true;
            this.checkBoxLensFlare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLensFlare.Location = new System.Drawing.Point(6, 89);
            this.checkBoxLensFlare.Name = "checkBoxLensFlare";
            this.checkBoxLensFlare.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLensFlare.TabIndex = 12;
            this.checkBoxLensFlare.Text = "Lens Flare";
            this.toolTip.SetToolTip(this.checkBoxLensFlare, "Unchecking this will disable Lens Flare.\r\n\r\nAffected values: bLensFlare\r\nAffected" +
        " files: Fallout76Prefs.ini");
            this.checkBoxLensFlare.UseVisualStyleBackColor = true;
            // 
            // checkBoxRadialBlur
            // 
            this.checkBoxRadialBlur.AutoSize = true;
            this.checkBoxRadialBlur.Checked = true;
            this.checkBoxRadialBlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRadialBlur.Location = new System.Drawing.Point(6, 66);
            this.checkBoxRadialBlur.Name = "checkBoxRadialBlur";
            this.checkBoxRadialBlur.Size = new System.Drawing.Size(77, 17);
            this.checkBoxRadialBlur.TabIndex = 9;
            this.checkBoxRadialBlur.Text = "Radial Blur";
            this.toolTip.SetToolTip(this.checkBoxRadialBlur, resources.GetString("checkBoxRadialBlur.ToolTip"));
            this.checkBoxRadialBlur.UseVisualStyleBackColor = true;
            // 
            // checkBoxMotionBlur
            // 
            this.checkBoxMotionBlur.AutoSize = true;
            this.checkBoxMotionBlur.Checked = true;
            this.checkBoxMotionBlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMotionBlur.Location = new System.Drawing.Point(6, 43);
            this.checkBoxMotionBlur.Name = "checkBoxMotionBlur";
            this.checkBoxMotionBlur.Size = new System.Drawing.Size(79, 17);
            this.checkBoxMotionBlur.TabIndex = 11;
            this.checkBoxMotionBlur.Text = "Motion Blur";
            this.toolTip.SetToolTip(this.checkBoxMotionBlur, "Blurs moving objects when turning the camera.\r\n\r\nAffected values: bMBEnable\r\nAffe" +
        "cted files: Fallout76Custom.ini");
            this.checkBoxMotionBlur.UseVisualStyleBackColor = true;
            // 
            // checkBoxDepthOfField
            // 
            this.checkBoxDepthOfField.AutoSize = true;
            this.checkBoxDepthOfField.Checked = true;
            this.checkBoxDepthOfField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDepthOfField.Location = new System.Drawing.Point(6, 20);
            this.checkBoxDepthOfField.Name = "checkBoxDepthOfField";
            this.checkBoxDepthOfField.Size = new System.Drawing.Size(92, 17);
            this.checkBoxDepthOfField.TabIndex = 10;
            this.checkBoxDepthOfField.Text = "Depth of Field";
            this.toolTip.SetToolTip(this.checkBoxDepthOfField, resources.GetString("checkBoxDepthOfField.ToolTip"));
            this.checkBoxDepthOfField.UseVisualStyleBackColor = true;
            // 
            // checkBoxAmbientOcclusion
            // 
            this.checkBoxAmbientOcclusion.AutoSize = true;
            this.checkBoxAmbientOcclusion.Checked = true;
            this.checkBoxAmbientOcclusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAmbientOcclusion.Location = new System.Drawing.Point(6, 112);
            this.checkBoxAmbientOcclusion.Name = "checkBoxAmbientOcclusion";
            this.checkBoxAmbientOcclusion.Size = new System.Drawing.Size(114, 17);
            this.checkBoxAmbientOcclusion.TabIndex = 13;
            this.checkBoxAmbientOcclusion.Text = "Ambient Occlusion";
            this.toolTip.SetToolTip(this.checkBoxAmbientOcclusion, resources.GetString("checkBoxAmbientOcclusion.ToolTip"));
            this.checkBoxAmbientOcclusion.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterDisplacement
            // 
            this.checkBoxWaterDisplacement.AutoSize = true;
            this.checkBoxWaterDisplacement.Checked = true;
            this.checkBoxWaterDisplacement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterDisplacement.Location = new System.Drawing.Point(6, 19);
            this.checkBoxWaterDisplacement.Name = "checkBoxWaterDisplacement";
            this.checkBoxWaterDisplacement.Size = new System.Drawing.Size(90, 17);
            this.checkBoxWaterDisplacement.TabIndex = 1;
            this.checkBoxWaterDisplacement.Text = "Displacement";
            this.toolTip.SetToolTip(this.checkBoxWaterDisplacement, "Enables/disables water displacement (ripples, waves).\r\n\r\nAffected values: bUseWat" +
        "erDisplacements\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxWaterDisplacement.UseVisualStyleBackColor = true;
            // 
            // labelShadowTextureResolution
            // 
            this.labelShadowTextureResolution.AutoSize = true;
            this.labelShadowTextureResolution.Location = new System.Drawing.Point(7, 23);
            this.labelShadowTextureResolution.Name = "labelShadowTextureResolution";
            this.labelShadowTextureResolution.Size = new System.Drawing.Size(117, 13);
            this.labelShadowTextureResolution.TabIndex = 0;
            this.labelShadowTextureResolution.Text = "Texture map resolution:";
            this.toolTip.SetToolTip(this.labelShadowTextureResolution, "Resolution of shadows. Higher settings will make shadows more detailed.\r\n\r\nAffect" +
        "ed values: iShadowMapResolution\r\nAffected files: Fallout76Prefs.ini");
            // 
            // sliderShadowDistance
            // 
            this.sliderShadowDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderShadowDistance.BackColor = System.Drawing.Color.Transparent;
            this.sliderShadowDistance.LargeChange = 10000;
            this.sliderShadowDistance.Location = new System.Drawing.Point(10, 94);
            this.sliderShadowDistance.Maximum = 200000;
            this.sliderShadowDistance.Name = "sliderShadowDistance";
            this.sliderShadowDistance.Size = new System.Drawing.Size(236, 23);
            this.sliderShadowDistance.SmallChange = 1000;
            this.sliderShadowDistance.TabIndex = 27;
            this.sliderShadowDistance.Text = "metroTrackBar1";
            this.toolTip.SetToolTip(this.sliderShadowDistance, resources.GetString("sliderShadowDistance.ToolTip"));
            this.sliderShadowDistance.Value = 120000;
            // 
            // labelShadowBlurriness
            // 
            this.labelShadowBlurriness.AutoSize = true;
            this.labelShadowBlurriness.Location = new System.Drawing.Point(7, 50);
            this.labelShadowBlurriness.Name = "labelShadowBlurriness";
            this.labelShadowBlurriness.Size = new System.Drawing.Size(55, 13);
            this.labelShadowBlurriness.TabIndex = 29;
            this.labelShadowBlurriness.Text = "Blurriness:";
            this.toolTip.SetToolTip(this.labelShadowBlurriness, "Blurs shadows. Especially useful, if you set a lower shadow resolution.\r\n\r\nAffect" +
        "ed values: uiOrthoShadowFilter\r\nAffected files: Fallout76Prefs.ini");
            // 
            // checkBoxGodrays
            // 
            this.checkBoxGodrays.AutoSize = true;
            this.checkBoxGodrays.Checked = true;
            this.checkBoxGodrays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGodrays.Location = new System.Drawing.Point(6, 19);
            this.checkBoxGodrays.Name = "checkBoxGodrays";
            this.checkBoxGodrays.Size = new System.Drawing.Size(115, 17);
            this.checkBoxGodrays.TabIndex = 14;
            this.checkBoxGodrays.Text = "Volumetric Lighting";
            this.toolTip.SetToolTip(this.checkBoxGodrays, "Unchecking this will disable godrays.\r\n\r\nAffected values: bVolumetricLightingEnab" +
        "le\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxGodrays.UseVisualStyleBackColor = true;
            // 
            // sliderLODObjects
            // 
            this.sliderLODObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODObjects.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODObjects.LargeChange = 10;
            this.sliderLODObjects.Location = new System.Drawing.Point(103, 41);
            this.sliderLODObjects.Maximum = 400;
            this.sliderLODObjects.Name = "sliderLODObjects";
            this.sliderLODObjects.Size = new System.Drawing.Size(164, 23);
            this.sliderLODObjects.SmallChange = 5;
            this.sliderLODObjects.TabIndex = 29;
            this.sliderLODObjects.Text = "metroTrackBar1";
            this.toolTip.SetToolTip(this.sliderLODObjects, "Sets the distance objects will begin to fade.\r\n\r\nAffected values: fLODFadeOutMult" +
        "Objects\r\nAffected files: Fallout76Prefs.ini");
            this.sliderLODObjects.Value = 60;
            // 
            // sliderLODItems
            // 
            this.sliderLODItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODItems.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODItems.LargeChange = 10;
            this.sliderLODItems.Location = new System.Drawing.Point(104, 70);
            this.sliderLODItems.Maximum = 400;
            this.sliderLODItems.Name = "sliderLODItems";
            this.sliderLODItems.Size = new System.Drawing.Size(164, 23);
            this.sliderLODItems.SmallChange = 5;
            this.sliderLODItems.TabIndex = 30;
            this.sliderLODItems.Text = "metroTrackBar2";
            this.toolTip.SetToolTip(this.sliderLODItems, "Sets the distance items will begin to fade.\r\n\r\nAffected values: fLODFadeOutMultIt" +
        "ems\r\nAffected files: Fallout76Prefs.ini");
            this.sliderLODItems.Value = 25;
            // 
            // sliderLODActors
            // 
            this.sliderLODActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODActors.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODActors.LargeChange = 10;
            this.sliderLODActors.Location = new System.Drawing.Point(103, 99);
            this.sliderLODActors.Maximum = 400;
            this.sliderLODActors.Name = "sliderLODActors";
            this.sliderLODActors.Size = new System.Drawing.Size(164, 23);
            this.sliderLODActors.SmallChange = 5;
            this.sliderLODActors.TabIndex = 32;
            this.sliderLODActors.Text = "metroTrackBar3";
            this.toolTip.SetToolTip(this.sliderLODActors, "Sets the distance actors (=Players, NPCs) will begin to fade.\r\n\r\nAffected values:" +
        " fLODFadeOutMultActors\r\nAffected files: Fallout76Prefs.ini");
            this.sliderLODActors.Value = 45;
            // 
            // checkBoxGrass
            // 
            this.checkBoxGrass.AutoSize = true;
            this.checkBoxGrass.Checked = true;
            this.checkBoxGrass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrass.Location = new System.Drawing.Point(6, 19);
            this.checkBoxGrass.Name = "checkBoxGrass";
            this.checkBoxGrass.Size = new System.Drawing.Size(87, 17);
            this.checkBoxGrass.TabIndex = 22;
            this.checkBoxGrass.Text = "Enable grass";
            this.toolTip.SetToolTip(this.checkBoxGrass, "Enables/disables the grass ingame.\r\n\r\nAffected values: bAllowCreateGrass\r\nAffecte" +
        "d files: Fallout76Custom.ini");
            this.checkBoxGrass.UseVisualStyleBackColor = true;
            // 
            // sliderGrassFadeDistance
            // 
            this.sliderGrassFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGrassFadeDistance.BackColor = System.Drawing.Color.Transparent;
            this.sliderGrassFadeDistance.LargeChange = 2000;
            this.sliderGrassFadeDistance.Location = new System.Drawing.Point(9, 66);
            this.sliderGrassFadeDistance.Maximum = 14000;
            this.sliderGrassFadeDistance.Name = "sliderGrassFadeDistance";
            this.sliderGrassFadeDistance.Size = new System.Drawing.Size(237, 23);
            this.sliderGrassFadeDistance.SmallChange = 500;
            this.sliderGrassFadeDistance.TabIndex = 24;
            this.sliderGrassFadeDistance.Text = "metroTrackBar1";
            this.toolTip.SetToolTip(this.sliderGrassFadeDistance, resources.GetString("sliderGrassFadeDistance.ToolTip"));
            this.sliderGrassFadeDistance.Value = 3000;
            // 
            // labelCustomResolution
            // 
            this.labelCustomResolution.AutoSize = true;
            this.labelCustomResolution.Location = new System.Drawing.Point(6, 60);
            this.labelCustomResolution.Name = "labelCustomResolution";
            this.labelCustomResolution.Size = new System.Drawing.Size(93, 13);
            this.labelCustomResolution.TabIndex = 2;
            this.labelCustomResolution.Text = "Custom resolution:";
            this.toolTip.SetToolTip(this.labelCustomResolution, "Set resolution to \"Custom\" for this option to become available.");
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(6, 34);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 3;
            this.labelResolution.Text = "Resolution:";
            this.toolTip.SetToolTip(this.labelResolution, "Changes the resolution.\r\nSetting it to \"Custom\" will allow you to set your own va" +
        "lues.\r\n\r\nAffected values: iSize W, iSize H\r\nAffected files: Fallout76Prefsini");
            // 
            // numCustomResW
            // 
            this.numCustomResW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCustomResW.Location = new System.Drawing.Point(150, 58);
            this.numCustomResW.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numCustomResW.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numCustomResW.Name = "numCustomResW";
            this.numCustomResW.Size = new System.Drawing.Size(86, 20);
            this.numCustomResW.TabIndex = 5;
            this.toolTip.SetToolTip(this.numCustomResW, "Changes the horizontal resolution (width).\r\n\r\nAffected values: iSize W");
            this.numCustomResW.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // labelDisplayMode
            // 
            this.labelDisplayMode.AutoSize = true;
            this.labelDisplayMode.Location = new System.Drawing.Point(6, 9);
            this.labelDisplayMode.Name = "labelDisplayMode";
            this.labelDisplayMode.Size = new System.Drawing.Size(73, 13);
            this.labelDisplayMode.TabIndex = 1;
            this.labelDisplayMode.Text = "Display mode:";
            this.toolTip.SetToolTip(this.labelDisplayMode, resources.GetString("labelDisplayMode.ToolTip"));
            // 
            // numCustomResH
            // 
            this.numCustomResH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCustomResH.Location = new System.Drawing.Point(260, 58);
            this.numCustomResH.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numCustomResH.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numCustomResH.Name = "numCustomResH";
            this.numCustomResH.Size = new System.Drawing.Size(86, 20);
            this.numCustomResH.TabIndex = 8;
            this.toolTip.SetToolTip(this.numCustomResH, "Changes the vertical resolution (height).\r\n\r\nAffected values: iSize H");
            this.numCustomResH.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // labelFirstPersonFOV
            // 
            this.labelFirstPersonFOV.AutoSize = true;
            this.labelFirstPersonFOV.Location = new System.Drawing.Point(6, 16);
            this.labelFirstPersonFOV.Name = "labelFirstPersonFOV";
            this.labelFirstPersonFOV.Size = new System.Drawing.Size(83, 13);
            this.labelFirstPersonFOV.TabIndex = 0;
            this.labelFirstPersonFOV.Text = "1st person FOV:";
            this.toolTip.SetToolTip(this.labelFirstPersonFOV, "Changes the field of view of the 1st person perspective.\r\n\r\nDefault: 80\r\nAffected" +
        " values: fDefault1stPersonFOV\r\nAffected files: Fallout76Custom.ini, Fallout76Pre" +
        "fs.ini");
            // 
            // labelWorldFOV
            // 
            this.labelWorldFOV.AutoSize = true;
            this.labelWorldFOV.Location = new System.Drawing.Point(6, 38);
            this.labelWorldFOV.Name = "labelWorldFOV";
            this.labelWorldFOV.Size = new System.Drawing.Size(121, 13);
            this.labelWorldFOV.TabIndex = 1;
            this.labelWorldFOV.Text = "World FOV (3rd person):";
            this.toolTip.SetToolTip(this.labelWorldFOV, "Changes the field of view of the 3rd person perspective.\r\n\r\nDefault: 80\r\nAffected" +
        " values: fDefaultWorldFOV\r\nAffected files: Fallout76Custom.ini, Fallout76Prefs.i" +
        "ni");
            // 
            // checkBoxTopMostWindow
            // 
            this.checkBoxTopMostWindow.AutoSize = true;
            this.checkBoxTopMostWindow.Location = new System.Drawing.Point(9, 94);
            this.checkBoxTopMostWindow.Name = "checkBoxTopMostWindow";
            this.checkBoxTopMostWindow.Size = new System.Drawing.Size(109, 17);
            this.checkBoxTopMostWindow.TabIndex = 21;
            this.checkBoxTopMostWindow.Text = "Top-most window";
            this.toolTip.SetToolTip(this.checkBoxTopMostWindow, resources.GetString("checkBoxTopMostWindow.ToolTip"));
            this.checkBoxTopMostWindow.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlwaysActive
            // 
            this.checkBoxAlwaysActive.AutoSize = true;
            this.checkBoxAlwaysActive.Location = new System.Drawing.Point(9, 117);
            this.checkBoxAlwaysActive.Name = "checkBoxAlwaysActive";
            this.checkBoxAlwaysActive.Size = new System.Drawing.Size(91, 17);
            this.checkBoxAlwaysActive.TabIndex = 22;
            this.checkBoxAlwaysActive.Text = "Always active";
            this.toolTip.SetToolTip(this.checkBoxAlwaysActive, "Disable this if you want the game to pause if another window is in front.\r\n\r\nAffe" +
        "cted values: bAlwaysActive\r\nAffected files: Fallout76Custom.ini");
            this.checkBoxAlwaysActive.UseVisualStyleBackColor = true;
            // 
            // checkBoxMainMenuMusic
            // 
            this.checkBoxMainMenuMusic.AutoSize = true;
            this.checkBoxMainMenuMusic.Checked = true;
            this.checkBoxMainMenuMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMainMenuMusic.Location = new System.Drawing.Point(7, 42);
            this.checkBoxMainMenuMusic.Name = "checkBoxMainMenuMusic";
            this.checkBoxMainMenuMusic.Size = new System.Drawing.Size(141, 17);
            this.checkBoxMainMenuMusic.TabIndex = 1;
            this.checkBoxMainMenuMusic.Text = "Play music in main menu";
            this.toolTip.SetToolTip(this.checkBoxMainMenuMusic, "If unchecked, the game won\'t play background music in the main menu.\r\n\r\nAffected " +
        "values: bPlayMainMenuMusic\r\nAffected files: Fallout76Custom.ini");
            this.checkBoxMainMenuMusic.UseVisualStyleBackColor = true;
            // 
            // checkBoxIntroVideos
            // 
            this.checkBoxIntroVideos.AutoSize = true;
            this.checkBoxIntroVideos.Checked = true;
            this.checkBoxIntroVideos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIntroVideos.Location = new System.Drawing.Point(7, 19);
            this.checkBoxIntroVideos.Name = "checkBoxIntroVideos";
            this.checkBoxIntroVideos.Size = new System.Drawing.Size(103, 17);
            this.checkBoxIntroVideos.TabIndex = 0;
            this.checkBoxIntroVideos.Text = "Play intro videos";
            this.toolTip.SetToolTip(this.checkBoxIntroVideos, "When this option is unchecked, the game will start without displaying the Bethesd" +
        "a logo video.\r\n\r\nAffected values: sIntroSequence, uMainMenuDelayBeforeAllowSkip\r" +
        "\nAffected files: Fallout76Custom.ini");
            this.checkBoxIntroVideos.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSplash
            // 
            this.checkBoxShowSplash.AutoSize = true;
            this.checkBoxShowSplash.Checked = true;
            this.checkBoxShowSplash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSplash.Location = new System.Drawing.Point(7, 65);
            this.checkBoxShowSplash.Name = "checkBoxShowSplash";
            this.checkBoxShowSplash.Size = new System.Drawing.Size(221, 17);
            this.checkBoxShowSplash.TabIndex = 2;
            this.checkBoxShowSplash.Text = "Show splash screen with news on startup";
            this.toolTip.SetToolTip(this.checkBoxShowSplash, "If unchecked, the game won\'t bother you with news on startup.\r\n\r\nAffected values:" +
        " bShowSplash\r\nAffected files: Fallout76Custom.ini");
            this.checkBoxShowSplash.UseVisualStyleBackColor = true;
            // 
            // checkBoxDialogueSubtitles
            // 
            this.checkBoxDialogueSubtitles.AutoSize = true;
            this.checkBoxDialogueSubtitles.Location = new System.Drawing.Point(7, 20);
            this.checkBoxDialogueSubtitles.Name = "checkBoxDialogueSubtitles";
            this.checkBoxDialogueSubtitles.Size = new System.Drawing.Size(137, 17);
            this.checkBoxDialogueSubtitles.TabIndex = 0;
            this.checkBoxDialogueSubtitles.Text = "Show dialogue subtitles";
            this.toolTip.SetToolTip(this.checkBoxDialogueSubtitles, "Affected values: bDialogueSubtitles\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxDialogueSubtitles.UseVisualStyleBackColor = true;
            // 
            // checkBoxGeneralSubtitles
            // 
            this.checkBoxGeneralSubtitles.AutoSize = true;
            this.checkBoxGeneralSubtitles.Location = new System.Drawing.Point(7, 43);
            this.checkBoxGeneralSubtitles.Name = "checkBoxGeneralSubtitles";
            this.checkBoxGeneralSubtitles.Size = new System.Drawing.Size(132, 17);
            this.checkBoxGeneralSubtitles.TabIndex = 1;
            this.checkBoxGeneralSubtitles.Text = "Show general subtitles";
            this.toolTip.SetToolTip(this.checkBoxGeneralSubtitles, "Affected values: bGeneralSubtitles\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxGeneralSubtitles.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDamageNumbersA
            // 
            this.checkBoxShowDamageNumbersA.AutoSize = true;
            this.checkBoxShowDamageNumbersA.Location = new System.Drawing.Point(7, 66);
            this.checkBoxShowDamageNumbersA.Name = "checkBoxShowDamageNumbersA";
            this.checkBoxShowDamageNumbersA.Size = new System.Drawing.Size(266, 17);
            this.checkBoxShowDamageNumbersA.TabIndex = 2;
            this.checkBoxShowDamageNumbersA.Text = "Show floating damage numbers in Adventure mode";
            this.toolTip.SetToolTip(this.checkBoxShowDamageNumbersA, "Affected values: bShowDamageNumbers\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxShowDamageNumbersA.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDamageNumbersNW
            // 
            this.checkBoxShowDamageNumbersNW.AutoSize = true;
            this.checkBoxShowDamageNumbersNW.Location = new System.Drawing.Point(7, 89);
            this.checkBoxShowDamageNumbersNW.Name = "checkBoxShowDamageNumbersNW";
            this.checkBoxShowDamageNumbersNW.Size = new System.Drawing.Size(259, 17);
            this.checkBoxShowDamageNumbersNW.TabIndex = 3;
            this.checkBoxShowDamageNumbersNW.Text = "Show floating damage numbers in Nuclear Winter";
            this.toolTip.SetToolTip(this.checkBoxShowDamageNumbersNW, "Affected values: bShowDamageNumbers\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxShowDamageNumbersNW.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCompass
            // 
            this.checkBoxShowCompass.AutoSize = true;
            this.checkBoxShowCompass.Location = new System.Drawing.Point(7, 112);
            this.checkBoxShowCompass.Name = "checkBoxShowCompass";
            this.checkBoxShowCompass.Size = new System.Drawing.Size(98, 17);
            this.checkBoxShowCompass.TabIndex = 4;
            this.checkBoxShowCompass.Text = "Show compass";
            this.toolTip.SetToolTip(this.checkBoxShowCompass, "Affected values: bShowCompass\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxShowCompass.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Power Armor Color";
            this.toolTip.SetToolTip(this.label1, "Changes the color of the Pip-Boy which is accessed from the Power Armor.\r\n\r\nAffec" +
        "ted values: fPAEffectColorR, fPAEffectColorG, fPAEffectColorB\r\nAffected files: F" +
        "allout76Custom.ini");
            // 
            // sliderTAAPostOverlay
            // 
            this.sliderTAAPostOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderTAAPostOverlay.BackColor = System.Drawing.Color.Transparent;
            this.sliderTAAPostOverlay.LargeChange = 1;
            this.sliderTAAPostOverlay.Location = new System.Drawing.Point(9, 41);
            this.sliderTAAPostOverlay.Name = "sliderTAAPostOverlay";
            this.sliderTAAPostOverlay.Size = new System.Drawing.Size(237, 23);
            this.sliderTAAPostOverlay.TabIndex = 27;
            this.sliderTAAPostOverlay.Text = "metroTrackBar1";
            this.toolTip.SetToolTip(this.sliderTAAPostOverlay, "Sharpens the image.\r\n\r\nRecommended: 0.2\r\nDefault: 0.2\r\n\r\nAffected values: fTAAPos" +
        "tOverlay\r\nAffected files: Fallout76Custom.ini");
            this.sliderTAAPostOverlay.Value = 20;
            // 
            // sliderTAAPostSharpen
            // 
            this.sliderTAAPostSharpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderTAAPostSharpen.BackColor = System.Drawing.Color.Transparent;
            this.sliderTAAPostSharpen.LargeChange = 1;
            this.sliderTAAPostSharpen.Location = new System.Drawing.Point(9, 93);
            this.sliderTAAPostSharpen.Maximum = 200;
            this.sliderTAAPostSharpen.Name = "sliderTAAPostSharpen";
            this.sliderTAAPostSharpen.Size = new System.Drawing.Size(237, 23);
            this.sliderTAAPostSharpen.TabIndex = 30;
            this.sliderTAAPostSharpen.Text = "metroTrackBar2";
            this.toolTip.SetToolTip(this.sliderTAAPostSharpen, "Sharpens the image.\r\n\r\nDefault: 0.2\r\nRecommended: 0.4\r\n\r\nAffected values: fTAAPos" +
        "tSharpen\r\nAffected files: Fallout76Custom.ini");
            this.sliderTAAPostSharpen.Value = 20;
            // 
            // checkBoxMouseAcceleration
            // 
            this.checkBoxMouseAcceleration.AutoSize = true;
            this.checkBoxMouseAcceleration.Location = new System.Drawing.Point(6, 75);
            this.checkBoxMouseAcceleration.Name = "checkBoxMouseAcceleration";
            this.checkBoxMouseAcceleration.Size = new System.Drawing.Size(119, 17);
            this.checkBoxMouseAcceleration.TabIndex = 6;
            this.checkBoxMouseAcceleration.Text = "Mouse acceleration";
            this.toolTip.SetToolTip(this.checkBoxMouseAcceleration, "This option might not have any effect. Placebo?\r\nDoesn\'t hurt to turn it off, tho" +
        "ugh.\r\n\r\nAffected values: bMouseAcceleration\r\nAffected files: Fallout76Custom.ini" +
        "");
            this.checkBoxMouseAcceleration.UseVisualStyleBackColor = true;
            // 
            // checkBoxFogEnabled
            // 
            this.checkBoxFogEnabled.AutoSize = true;
            this.checkBoxFogEnabled.Checked = true;
            this.checkBoxFogEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFogEnabled.Location = new System.Drawing.Point(6, 16);
            this.checkBoxFogEnabled.Name = "checkBoxFogEnabled";
            this.checkBoxFogEnabled.Size = new System.Drawing.Size(44, 17);
            this.checkBoxFogEnabled.TabIndex = 4;
            this.checkBoxFogEnabled.Text = "Fog";
            this.toolTip.SetToolTip(this.checkBoxFogEnabled, "Affected values: bFogEnabled\r\nAffected files: Fallout76Prefs.ini");
            this.checkBoxFogEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonLaunchGame
            // 
            this.buttonLaunchGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLaunchGame.Location = new System.Drawing.Point(164, 526);
            this.buttonLaunchGame.Name = "buttonLaunchGame";
            this.buttonLaunchGame.Size = new System.Drawing.Size(106, 23);
            this.buttonLaunchGame.TabIndex = 8;
            this.buttonLaunchGame.Text = "Launch game";
            this.buttonLaunchGame.UseVisualStyleBackColor = true;
            this.buttonLaunchGame.Click += new System.EventHandler(this.buttonLaunchGame_Click);
            // 
            // tabPagePipBoy
            // 
            this.tabPagePipBoy.Controls.Add(this.groupBoxPipboyResolution);
            this.tabPagePipBoy.Controls.Add(this.groupBoxPipboyMode);
            this.tabPagePipBoy.Controls.Add(this.groupBoxPipboyColors);
            this.tabPagePipBoy.Location = new System.Drawing.Point(4, 22);
            this.tabPagePipBoy.Name = "tabPagePipBoy";
            this.tabPagePipBoy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePipBoy.Size = new System.Drawing.Size(352, 412);
            this.tabPagePipBoy.TabIndex = 5;
            this.tabPagePipBoy.Text = "Pipboy";
            this.tabPagePipBoy.UseVisualStyleBackColor = true;
            // 
            // groupBoxPipboyResolution
            // 
            this.groupBoxPipboyResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPipboyResolution.Controls.Add(this.labelPipboyResolutionSideNote);
            this.groupBoxPipboyResolution.Controls.Add(this.buttonPipboyTargetSetRecommended);
            this.groupBoxPipboyResolution.Controls.Add(this.buttonPipboyTargetReset);
            this.groupBoxPipboyResolution.Controls.Add(this.numPipboyTargetHeight);
            this.groupBoxPipboyResolution.Controls.Add(this.numPipboyTargetWidth);
            this.groupBoxPipboyResolution.Controls.Add(this.labelPipboyResolutionSpacer);
            this.groupBoxPipboyResolution.Location = new System.Drawing.Point(6, 207);
            this.groupBoxPipboyResolution.Name = "groupBoxPipboyResolution";
            this.groupBoxPipboyResolution.Size = new System.Drawing.Size(340, 111);
            this.groupBoxPipboyResolution.TabIndex = 39;
            this.groupBoxPipboyResolution.TabStop = false;
            this.groupBoxPipboyResolution.Text = "Resolution";
            // 
            // labelPipboyResolutionSideNote
            // 
            this.labelPipboyResolutionSideNote.AutoSize = true;
            this.labelPipboyResolutionSideNote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPipboyResolutionSideNote.Location = new System.Drawing.Point(29, 80);
            this.labelPipboyResolutionSideNote.Name = "labelPipboyResolutionSideNote";
            this.labelPipboyResolutionSideNote.Size = new System.Drawing.Size(273, 13);
            this.labelPipboyResolutionSideNote.TabIndex = 5;
            this.labelPipboyResolutionSideNote.Text = "These settings affect both the Pipboy and the Quickboy.";
            // 
            // labelPipboyResolutionSpacer
            // 
            this.labelPipboyResolutionSpacer.AutoSize = true;
            this.labelPipboyResolutionSpacer.Location = new System.Drawing.Point(161, 21);
            this.labelPipboyResolutionSpacer.Name = "labelPipboyResolutionSpacer";
            this.labelPipboyResolutionSpacer.Size = new System.Drawing.Size(14, 13);
            this.labelPipboyResolutionSpacer.TabIndex = 0;
            this.labelPipboyResolutionSpacer.Text = "X";
            // 
            // groupBoxPipboyMode
            // 
            this.groupBoxPipboyMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPipboyMode.Controls.Add(this.radioButtonQuickboy);
            this.groupBoxPipboyMode.Controls.Add(this.radioButtonPipboy);
            this.groupBoxPipboyMode.Location = new System.Drawing.Point(6, 129);
            this.groupBoxPipboyMode.Name = "groupBoxPipboyMode";
            this.groupBoxPipboyMode.Size = new System.Drawing.Size(340, 72);
            this.groupBoxPipboyMode.TabIndex = 38;
            this.groupBoxPipboyMode.TabStop = false;
            this.groupBoxPipboyMode.Text = "Mode";
            // 
            // groupBoxPipboyColors
            // 
            this.groupBoxPipboyColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPipboyColors.Controls.Add(this.colorPreviewPAPipboy);
            this.groupBoxPipboyColors.Controls.Add(this.label1);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorPickPAPipboy);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorResetPipboy);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorResetPAPipboy);
            this.groupBoxPipboyColors.Controls.Add(this.colorPreviewPipboy);
            this.groupBoxPipboyColors.Controls.Add(this.colorPreviewQuickboy);
            this.groupBoxPipboyColors.Controls.Add(this.labelQuickboyColor);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorPickQuickboy);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorResetQuickboy);
            this.groupBoxPipboyColors.Controls.Add(this.labelPipboyColor);
            this.groupBoxPipboyColors.Controls.Add(this.buttonColorPickPipboy);
            this.groupBoxPipboyColors.Location = new System.Drawing.Point(6, 6);
            this.groupBoxPipboyColors.Name = "groupBoxPipboyColors";
            this.groupBoxPipboyColors.Size = new System.Drawing.Size(340, 117);
            this.groupBoxPipboyColors.TabIndex = 35;
            this.groupBoxPipboyColors.TabStop = false;
            this.groupBoxPipboyColors.Text = "Colors";
            // 
            // colorPreviewPAPipboy
            // 
            this.colorPreviewPAPipboy.BackColor = System.Drawing.Color.Red;
            this.colorPreviewPAPipboy.Location = new System.Drawing.Point(12, 78);
            this.colorPreviewPAPipboy.Name = "colorPreviewPAPipboy";
            this.colorPreviewPAPipboy.Size = new System.Drawing.Size(20, 20);
            this.colorPreviewPAPipboy.TabIndex = 35;
            this.colorPreviewPAPipboy.TabStop = false;
            // 
            // buttonColorPickPAPipboy
            // 
            this.buttonColorPickPAPipboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorPickPAPipboy.Location = new System.Drawing.Point(164, 77);
            this.buttonColorPickPAPipboy.Name = "buttonColorPickPAPipboy";
            this.buttonColorPickPAPipboy.Size = new System.Drawing.Size(84, 23);
            this.buttonColorPickPAPipboy.TabIndex = 36;
            this.buttonColorPickPAPipboy.Text = "Pick color";
            this.buttonColorPickPAPipboy.UseVisualStyleBackColor = true;
            this.buttonColorPickPAPipboy.Click += new System.EventHandler(this.buttonColorPickPAPipboy_Click);
            // 
            // buttonColorResetPipboy
            // 
            this.buttonColorResetPipboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorResetPipboy.Location = new System.Drawing.Point(249, 19);
            this.buttonColorResetPipboy.Name = "buttonColorResetPipboy";
            this.buttonColorResetPipboy.Size = new System.Drawing.Size(83, 23);
            this.buttonColorResetPipboy.TabIndex = 3;
            this.buttonColorResetPipboy.Text = "Reset";
            this.buttonColorResetPipboy.UseVisualStyleBackColor = true;
            this.buttonColorResetPipboy.Click += new System.EventHandler(this.buttonColorResetPipboy_Click);
            // 
            // buttonColorResetPAPipboy
            // 
            this.buttonColorResetPAPipboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorResetPAPipboy.Location = new System.Drawing.Point(249, 77);
            this.buttonColorResetPAPipboy.Name = "buttonColorResetPAPipboy";
            this.buttonColorResetPAPipboy.Size = new System.Drawing.Size(83, 23);
            this.buttonColorResetPAPipboy.TabIndex = 35;
            this.buttonColorResetPAPipboy.Text = "Reset";
            this.buttonColorResetPAPipboy.UseVisualStyleBackColor = true;
            this.buttonColorResetPAPipboy.Click += new System.EventHandler(this.buttonColorResetPAPipboy_Click);
            // 
            // colorPreviewPipboy
            // 
            this.colorPreviewPipboy.BackColor = System.Drawing.Color.Red;
            this.colorPreviewPipboy.Location = new System.Drawing.Point(12, 20);
            this.colorPreviewPipboy.Name = "colorPreviewPipboy";
            this.colorPreviewPipboy.Size = new System.Drawing.Size(20, 20);
            this.colorPreviewPipboy.TabIndex = 0;
            this.colorPreviewPipboy.TabStop = false;
            // 
            // colorPreviewQuickboy
            // 
            this.colorPreviewQuickboy.BackColor = System.Drawing.Color.Red;
            this.colorPreviewQuickboy.Location = new System.Drawing.Point(12, 49);
            this.colorPreviewQuickboy.Name = "colorPreviewQuickboy";
            this.colorPreviewQuickboy.Size = new System.Drawing.Size(20, 20);
            this.colorPreviewQuickboy.TabIndex = 5;
            this.colorPreviewQuickboy.TabStop = false;
            // 
            // buttonColorPickQuickboy
            // 
            this.buttonColorPickQuickboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorPickQuickboy.Location = new System.Drawing.Point(164, 48);
            this.buttonColorPickQuickboy.Name = "buttonColorPickQuickboy";
            this.buttonColorPickQuickboy.Size = new System.Drawing.Size(84, 23);
            this.buttonColorPickQuickboy.TabIndex = 7;
            this.buttonColorPickQuickboy.Text = "Pick color";
            this.buttonColorPickQuickboy.UseVisualStyleBackColor = true;
            this.buttonColorPickQuickboy.Click += new System.EventHandler(this.buttonColorPickQuickboy_Click);
            // 
            // buttonColorResetQuickboy
            // 
            this.buttonColorResetQuickboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorResetQuickboy.Location = new System.Drawing.Point(249, 48);
            this.buttonColorResetQuickboy.Name = "buttonColorResetQuickboy";
            this.buttonColorResetQuickboy.Size = new System.Drawing.Size(83, 23);
            this.buttonColorResetQuickboy.TabIndex = 8;
            this.buttonColorResetQuickboy.Text = "Reset";
            this.buttonColorResetQuickboy.UseVisualStyleBackColor = true;
            this.buttonColorResetQuickboy.Click += new System.EventHandler(this.buttonColorResetQuickboy_Click);
            // 
            // buttonColorPickPipboy
            // 
            this.buttonColorPickPipboy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorPickPipboy.Location = new System.Drawing.Point(164, 19);
            this.buttonColorPickPipboy.Name = "buttonColorPickPipboy";
            this.buttonColorPickPipboy.Size = new System.Drawing.Size(84, 23);
            this.buttonColorPickPipboy.TabIndex = 2;
            this.buttonColorPickPipboy.Text = "Pick color";
            this.buttonColorPickPipboy.UseVisualStyleBackColor = true;
            this.buttonColorPickPipboy.Click += new System.EventHandler(this.buttonColorPickPipboy_Click);
            // 
            // tabPageControls
            // 
            this.tabPageControls.Controls.Add(this.groupBoxGamepad);
            this.tabPageControls.Controls.Add(this.groupBoxMouse);
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControls.Size = new System.Drawing.Size(352, 412);
            this.tabPageControls.TabIndex = 2;
            this.tabPageControls.Text = "Controls";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // groupBoxGamepad
            // 
            this.groupBoxGamepad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGamepad.Controls.Add(this.checkBoxGamepadEnabled);
            this.groupBoxGamepad.Controls.Add(this.checkBoxGamepadRumble);
            this.groupBoxGamepad.Location = new System.Drawing.Point(7, 167);
            this.groupBoxGamepad.Name = "groupBoxGamepad";
            this.groupBoxGamepad.Size = new System.Drawing.Size(339, 71);
            this.groupBoxGamepad.TabIndex = 5;
            this.groupBoxGamepad.TabStop = false;
            this.groupBoxGamepad.Text = "Gamepad";
            // 
            // groupBoxMouse
            // 
            this.groupBoxMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMouse.Controls.Add(this.checkBoxMouseAcceleration);
            this.groupBoxMouse.Controls.Add(this.checkBoxFixAimSensitivity);
            this.groupBoxMouse.Controls.Add(this.numMouseSensitivity);
            this.groupBoxMouse.Controls.Add(this.labelMouseSensitivity);
            this.groupBoxMouse.Controls.Add(this.sliderMouseSensitivity);
            this.groupBoxMouse.Controls.Add(this.checkBoxFixMouseSensitivity);
            this.groupBoxMouse.Location = new System.Drawing.Point(7, 7);
            this.groupBoxMouse.Name = "groupBoxMouse";
            this.groupBoxMouse.Size = new System.Drawing.Size(339, 154);
            this.groupBoxMouse.TabIndex = 4;
            this.groupBoxMouse.TabStop = false;
            this.groupBoxMouse.Text = "Mouse";
            // 
            // numMouseSensitivity
            // 
            this.numMouseSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMouseSensitivity.DecimalPlaces = 4;
            this.numMouseSensitivity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            this.numMouseSensitivity.Location = new System.Drawing.Point(279, 37);
            this.numMouseSensitivity.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            131072});
            this.numMouseSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numMouseSensitivity.Name = "numMouseSensitivity";
            this.numMouseSensitivity.Size = new System.Drawing.Size(54, 20);
            this.numMouseSensitivity.TabIndex = 4;
            this.numMouseSensitivity.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            // 
            // labelMouseSensitivity
            // 
            this.labelMouseSensitivity.AutoSize = true;
            this.labelMouseSensitivity.Location = new System.Drawing.Point(6, 19);
            this.labelMouseSensitivity.Name = "labelMouseSensitivity";
            this.labelMouseSensitivity.Size = new System.Drawing.Size(54, 13);
            this.labelMouseSensitivity.TabIndex = 3;
            this.labelMouseSensitivity.Text = "Sensitivity";
            // 
            // tabPageGraphics
            // 
            this.tabPageGraphics.AutoScroll = true;
            this.tabPageGraphics.Controls.Add(this.groupBoxTAASharpening);
            this.tabPageGraphics.Controls.Add(this.groupBoxGrass);
            this.tabPageGraphics.Controls.Add(this.groupBoxLOD);
            this.tabPageGraphics.Controls.Add(this.groupBoxLighting);
            this.tabPageGraphics.Controls.Add(this.groupBoxShadows);
            this.tabPageGraphics.Controls.Add(this.groupBoxWater);
            this.tabPageGraphics.Controls.Add(this.groupBoxPostProcessing);
            this.tabPageGraphics.Controls.Add(this.groupBoxWeather);
            this.tabPageGraphics.Controls.Add(this.comboBoxAnisotropicFiltering);
            this.tabPageGraphics.Controls.Add(this.labelAnisotropicFiltering);
            this.tabPageGraphics.Controls.Add(this.checkBoxVSync);
            this.tabPageGraphics.Controls.Add(this.comboBoxAntiAliasing);
            this.tabPageGraphics.Controls.Add(this.labelAntiAliasing);
            this.tabPageGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraphics.Name = "tabPageGraphics";
            this.tabPageGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphics.Size = new System.Drawing.Size(352, 412);
            this.tabPageGraphics.TabIndex = 1;
            this.tabPageGraphics.Text = "Graphics";
            this.tabPageGraphics.UseVisualStyleBackColor = true;
            // 
            // groupBoxTAASharpening
            // 
            this.groupBoxTAASharpening.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTAASharpening.Controls.Add(this.numTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.labelTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.sliderTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.numTAAPostOverlay);
            this.groupBoxTAASharpening.Controls.Add(this.labelTAAPostOverlay);
            this.groupBoxTAASharpening.Controls.Add(this.sliderTAAPostOverlay);
            this.groupBoxTAASharpening.Location = new System.Drawing.Point(9, 655);
            this.groupBoxTAASharpening.Name = "groupBoxTAASharpening";
            this.groupBoxTAASharpening.Size = new System.Drawing.Size(332, 134);
            this.groupBoxTAASharpening.TabIndex = 25;
            this.groupBoxTAASharpening.TabStop = false;
            this.groupBoxTAASharpening.Text = "TAA Sharpening";
            // 
            // numTAAPostSharpen
            // 
            this.numTAAPostSharpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTAAPostSharpen.DecimalPlaces = 2;
            this.numTAAPostSharpen.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numTAAPostSharpen.Location = new System.Drawing.Point(252, 93);
            this.numTAAPostSharpen.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTAAPostSharpen.Name = "numTAAPostSharpen";
            this.numTAAPostSharpen.Size = new System.Drawing.Size(74, 20);
            this.numTAAPostSharpen.TabIndex = 31;
            this.numTAAPostSharpen.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // labelTAAPostSharpen
            // 
            this.labelTAAPostSharpen.AutoSize = true;
            this.labelTAAPostSharpen.Location = new System.Drawing.Point(6, 77);
            this.labelTAAPostSharpen.Name = "labelTAAPostSharpen";
            this.labelTAAPostSharpen.Size = new System.Drawing.Size(69, 13);
            this.labelTAAPostSharpen.TabIndex = 29;
            this.labelTAAPostSharpen.Text = "Post sharpen";
            // 
            // numTAAPostOverlay
            // 
            this.numTAAPostOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTAAPostOverlay.DecimalPlaces = 2;
            this.numTAAPostOverlay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numTAAPostOverlay.Location = new System.Drawing.Point(252, 41);
            this.numTAAPostOverlay.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTAAPostOverlay.Name = "numTAAPostOverlay";
            this.numTAAPostOverlay.Size = new System.Drawing.Size(74, 20);
            this.numTAAPostOverlay.TabIndex = 28;
            this.numTAAPostOverlay.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // labelTAAPostOverlay
            // 
            this.labelTAAPostOverlay.AutoSize = true;
            this.labelTAAPostOverlay.Location = new System.Drawing.Point(6, 25);
            this.labelTAAPostOverlay.Name = "labelTAAPostOverlay";
            this.labelTAAPostOverlay.Size = new System.Drawing.Size(65, 13);
            this.labelTAAPostOverlay.TabIndex = 26;
            this.labelTAAPostOverlay.Text = "Post overlay";
            // 
            // groupBoxGrass
            // 
            this.groupBoxGrass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGrass.Controls.Add(this.numGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.sliderGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.labelGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.checkBoxGrass);
            this.groupBoxGrass.Location = new System.Drawing.Point(9, 555);
            this.groupBoxGrass.Name = "groupBoxGrass";
            this.groupBoxGrass.Size = new System.Drawing.Size(332, 94);
            this.groupBoxGrass.TabIndex = 23;
            this.groupBoxGrass.TabStop = false;
            this.groupBoxGrass.Text = "Grass";
            // 
            // numGrassFadeDistance
            // 
            this.numGrassFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGrassFadeDistance.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGrassFadeDistance.Location = new System.Drawing.Point(252, 68);
            this.numGrassFadeDistance.Maximum = new decimal(new int[] {
            14000,
            0,
            0,
            0});
            this.numGrassFadeDistance.Name = "numGrassFadeDistance";
            this.numGrassFadeDistance.Size = new System.Drawing.Size(74, 20);
            this.numGrassFadeDistance.TabIndex = 25;
            this.numGrassFadeDistance.Value = new decimal(new int[] {
            3500,
            0,
            0,
            0});
            // 
            // labelGrassFadeDistance
            // 
            this.labelGrassFadeDistance.AutoSize = true;
            this.labelGrassFadeDistance.Location = new System.Drawing.Point(6, 50);
            this.labelGrassFadeDistance.Name = "labelGrassFadeDistance";
            this.labelGrassFadeDistance.Size = new System.Drawing.Size(74, 13);
            this.labelGrassFadeDistance.TabIndex = 23;
            this.labelGrassFadeDistance.Text = "Fade distance";
            // 
            // groupBoxLOD
            // 
            this.groupBoxLOD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLOD.Controls.Add(this.labelLODFadeDistance);
            this.groupBoxLOD.Controls.Add(this.numLODActors);
            this.groupBoxLOD.Controls.Add(this.sliderLODActors);
            this.groupBoxLOD.Controls.Add(this.numLODItems);
            this.groupBoxLOD.Controls.Add(this.sliderLODItems);
            this.groupBoxLOD.Controls.Add(this.numLODObjects);
            this.groupBoxLOD.Controls.Add(this.sliderLODObjects);
            this.groupBoxLOD.Controls.Add(this.labelLODActors);
            this.groupBoxLOD.Controls.Add(this.labelLODItems);
            this.groupBoxLOD.Controls.Add(this.labelLODObjects);
            this.groupBoxLOD.Location = new System.Drawing.Point(9, 419);
            this.groupBoxLOD.Name = "groupBoxLOD";
            this.groupBoxLOD.Size = new System.Drawing.Size(332, 130);
            this.groupBoxLOD.TabIndex = 24;
            this.groupBoxLOD.TabStop = false;
            this.groupBoxLOD.Text = "LOD";
            // 
            // labelLODFadeDistance
            // 
            this.labelLODFadeDistance.AutoSize = true;
            this.labelLODFadeDistance.Location = new System.Drawing.Point(7, 20);
            this.labelLODFadeDistance.Name = "labelLODFadeDistance";
            this.labelLODFadeDistance.Size = new System.Drawing.Size(74, 13);
            this.labelLODFadeDistance.TabIndex = 34;
            this.labelLODFadeDistance.Text = "Fade distance";
            // 
            // numLODActors
            // 
            this.numLODActors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLODActors.DecimalPlaces = 1;
            this.numLODActors.Location = new System.Drawing.Point(273, 100);
            this.numLODActors.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numLODActors.Name = "numLODActors";
            this.numLODActors.Size = new System.Drawing.Size(53, 20);
            this.numLODActors.TabIndex = 33;
            this.numLODActors.Value = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            // 
            // numLODItems
            // 
            this.numLODItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLODItems.DecimalPlaces = 1;
            this.numLODItems.Location = new System.Drawing.Point(273, 71);
            this.numLODItems.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numLODItems.Name = "numLODItems";
            this.numLODItems.Size = new System.Drawing.Size(53, 20);
            this.numLODItems.TabIndex = 31;
            this.numLODItems.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // numLODObjects
            // 
            this.numLODObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLODObjects.DecimalPlaces = 1;
            this.numLODObjects.Location = new System.Drawing.Point(273, 41);
            this.numLODObjects.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numLODObjects.Name = "numLODObjects";
            this.numLODObjects.Size = new System.Drawing.Size(53, 20);
            this.numLODObjects.TabIndex = 29;
            this.numLODObjects.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // labelLODActors
            // 
            this.labelLODActors.AutoSize = true;
            this.labelLODActors.Location = new System.Drawing.Point(19, 103);
            this.labelLODActors.Name = "labelLODActors";
            this.labelLODActors.Size = new System.Drawing.Size(37, 13);
            this.labelLODActors.TabIndex = 2;
            this.labelLODActors.Text = "Actors";
            // 
            // labelLODItems
            // 
            this.labelLODItems.AutoSize = true;
            this.labelLODItems.Location = new System.Drawing.Point(19, 74);
            this.labelLODItems.Name = "labelLODItems";
            this.labelLODItems.Size = new System.Drawing.Size(32, 13);
            this.labelLODItems.TabIndex = 1;
            this.labelLODItems.Text = "Items";
            // 
            // labelLODObjects
            // 
            this.labelLODObjects.AutoSize = true;
            this.labelLODObjects.Location = new System.Drawing.Point(19, 44);
            this.labelLODObjects.Name = "labelLODObjects";
            this.labelLODObjects.Size = new System.Drawing.Size(43, 13);
            this.labelLODObjects.TabIndex = 0;
            this.labelLODObjects.Text = "Objects";
            // 
            // groupBoxLighting
            // 
            this.groupBoxLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLighting.Controls.Add(this.checkBoxGodrays);
            this.groupBoxLighting.Location = new System.Drawing.Point(9, 233);
            this.groupBoxLighting.Name = "groupBoxLighting";
            this.groupBoxLighting.Size = new System.Drawing.Size(332, 46);
            this.groupBoxLighting.TabIndex = 15;
            this.groupBoxLighting.TabStop = false;
            this.groupBoxLighting.Text = "Lighting";
            // 
            // groupBoxShadows
            // 
            this.groupBoxShadows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShadows.Controls.Add(this.comboBoxShadowBlurriness);
            this.groupBoxShadows.Controls.Add(this.labelShadowBlurriness);
            this.groupBoxShadows.Controls.Add(this.numShadowDistance);
            this.groupBoxShadows.Controls.Add(this.sliderShadowDistance);
            this.groupBoxShadows.Controls.Add(this.labelShadowDistance);
            this.groupBoxShadows.Controls.Add(this.comboBoxShadowTextureResolution);
            this.groupBoxShadows.Controls.Add(this.labelShadowTextureResolution);
            this.groupBoxShadows.Location = new System.Drawing.Point(9, 285);
            this.groupBoxShadows.Name = "groupBoxShadows";
            this.groupBoxShadows.Size = new System.Drawing.Size(332, 128);
            this.groupBoxShadows.TabIndex = 16;
            this.groupBoxShadows.TabStop = false;
            this.groupBoxShadows.Text = "Shadows";
            // 
            // comboBoxShadowBlurriness
            // 
            this.comboBoxShadowBlurriness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShadowBlurriness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShadowBlurriness.FormattingEnabled = true;
            this.comboBoxShadowBlurriness.Location = new System.Drawing.Point(134, 47);
            this.comboBoxShadowBlurriness.Name = "comboBoxShadowBlurriness";
            this.comboBoxShadowBlurriness.Size = new System.Drawing.Size(192, 21);
            this.comboBoxShadowBlurriness.TabIndex = 30;
            // 
            // numShadowDistance
            // 
            this.numShadowDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numShadowDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numShadowDistance.Location = new System.Drawing.Point(252, 97);
            this.numShadowDistance.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numShadowDistance.Name = "numShadowDistance";
            this.numShadowDistance.Size = new System.Drawing.Size(74, 20);
            this.numShadowDistance.TabIndex = 28;
            this.numShadowDistance.Value = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            // 
            // labelShadowDistance
            // 
            this.labelShadowDistance.AutoSize = true;
            this.labelShadowDistance.Location = new System.Drawing.Point(7, 77);
            this.labelShadowDistance.Name = "labelShadowDistance";
            this.labelShadowDistance.Size = new System.Drawing.Size(49, 13);
            this.labelShadowDistance.TabIndex = 26;
            this.labelShadowDistance.Text = "Distance";
            // 
            // comboBoxShadowTextureResolution
            // 
            this.comboBoxShadowTextureResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShadowTextureResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShadowTextureResolution.FormattingEnabled = true;
            this.comboBoxShadowTextureResolution.Location = new System.Drawing.Point(134, 20);
            this.comboBoxShadowTextureResolution.Name = "comboBoxShadowTextureResolution";
            this.comboBoxShadowTextureResolution.Size = new System.Drawing.Size(192, 21);
            this.comboBoxShadowTextureResolution.TabIndex = 1;
            // 
            // groupBoxWater
            // 
            this.groupBoxWater.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWater.Controls.Add(this.checkBoxWaterDisplacement);
            this.groupBoxWater.Location = new System.Drawing.Point(182, 89);
            this.groupBoxWater.Name = "groupBoxWater";
            this.groupBoxWater.Size = new System.Drawing.Size(159, 44);
            this.groupBoxWater.TabIndex = 17;
            this.groupBoxWater.TabStop = false;
            this.groupBoxWater.Text = "Water";
            // 
            // groupBoxPostProcessing
            // 
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxAmbientOcclusion);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxDepthOfField);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxMotionBlur);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxRadialBlur);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxLensFlare);
            this.groupBoxPostProcessing.Location = new System.Drawing.Point(9, 89);
            this.groupBoxPostProcessing.Name = "groupBoxPostProcessing";
            this.groupBoxPostProcessing.Size = new System.Drawing.Size(167, 138);
            this.groupBoxPostProcessing.TabIndex = 22;
            this.groupBoxPostProcessing.TabStop = false;
            this.groupBoxPostProcessing.Text = "Post-processing";
            // 
            // groupBoxWeather
            // 
            this.groupBoxWeather.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeather.Controls.Add(this.checkBoxFogEnabled);
            this.groupBoxWeather.Controls.Add(this.checkBoxWeatherWetnessOcclusion);
            this.groupBoxWeather.Controls.Add(this.checkBoxWeatherRainOcclusion);
            this.groupBoxWeather.Location = new System.Drawing.Point(182, 139);
            this.groupBoxWeather.Name = "groupBoxWeather";
            this.groupBoxWeather.Size = new System.Drawing.Size(159, 88);
            this.groupBoxWeather.TabIndex = 18;
            this.groupBoxWeather.TabStop = false;
            this.groupBoxWeather.Text = "Weather";
            // 
            // comboBoxAnisotropicFiltering
            // 
            this.comboBoxAnisotropicFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAnisotropicFiltering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnisotropicFiltering.FormattingEnabled = true;
            this.comboBoxAnisotropicFiltering.Location = new System.Drawing.Point(139, 33);
            this.comboBoxAnisotropicFiltering.Name = "comboBoxAnisotropicFiltering";
            this.comboBoxAnisotropicFiltering.Size = new System.Drawing.Size(202, 21);
            this.comboBoxAnisotropicFiltering.TabIndex = 23;
            // 
            // comboBoxAntiAliasing
            // 
            this.comboBoxAntiAliasing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAntiAliasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAntiAliasing.FormattingEnabled = true;
            this.comboBoxAntiAliasing.Location = new System.Drawing.Point(139, 6);
            this.comboBoxAntiAliasing.Name = "comboBoxAntiAliasing";
            this.comboBoxAntiAliasing.Size = new System.Drawing.Size(202, 21);
            this.comboBoxAntiAliasing.TabIndex = 8;
            // 
            // tabPageDisplay
            // 
            this.tabPageDisplay.Controls.Add(this.checkBoxAlwaysActive);
            this.tabPageDisplay.Controls.Add(this.checkBoxTopMostWindow);
            this.tabPageDisplay.Controls.Add(this.groupBoxFieldOfView);
            this.tabPageDisplay.Controls.Add(this.numCustomResH);
            this.tabPageDisplay.Controls.Add(this.labelCustomResolutionSpacer);
            this.tabPageDisplay.Controls.Add(this.comboBoxDisplayMode);
            this.tabPageDisplay.Controls.Add(this.labelDisplayMode);
            this.tabPageDisplay.Controls.Add(this.numCustomResW);
            this.tabPageDisplay.Controls.Add(this.labelResolution);
            this.tabPageDisplay.Controls.Add(this.labelCustomResolution);
            this.tabPageDisplay.Controls.Add(this.comboBoxResolution);
            this.tabPageDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisplay.Name = "tabPageDisplay";
            this.tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisplay.Size = new System.Drawing.Size(352, 412);
            this.tabPageDisplay.TabIndex = 0;
            this.tabPageDisplay.Text = "Display";
            this.tabPageDisplay.UseVisualStyleBackColor = true;
            // 
            // groupBoxFieldOfView
            // 
            this.groupBoxFieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFieldOfView.Controls.Add(this.numWorldFOV);
            this.groupBoxFieldOfView.Controls.Add(this.numFirstPersonFOV);
            this.groupBoxFieldOfView.Controls.Add(this.labelWorldFOV);
            this.groupBoxFieldOfView.Controls.Add(this.labelFirstPersonFOV);
            this.groupBoxFieldOfView.Location = new System.Drawing.Point(6, 336);
            this.groupBoxFieldOfView.Name = "groupBoxFieldOfView";
            this.groupBoxFieldOfView.Size = new System.Drawing.Size(340, 70);
            this.groupBoxFieldOfView.TabIndex = 20;
            this.groupBoxFieldOfView.TabStop = false;
            this.groupBoxFieldOfView.Text = "Field of View";
            // 
            // numWorldFOV
            // 
            this.numWorldFOV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWorldFOV.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numWorldFOV.Location = new System.Drawing.Point(199, 36);
            this.numWorldFOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numWorldFOV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWorldFOV.Name = "numWorldFOV";
            this.numWorldFOV.Size = new System.Drawing.Size(135, 20);
            this.numWorldFOV.TabIndex = 3;
            this.numWorldFOV.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // numFirstPersonFOV
            // 
            this.numFirstPersonFOV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFirstPersonFOV.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFirstPersonFOV.Location = new System.Drawing.Point(199, 14);
            this.numFirstPersonFOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numFirstPersonFOV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFirstPersonFOV.Name = "numFirstPersonFOV";
            this.numFirstPersonFOV.Size = new System.Drawing.Size(135, 20);
            this.numFirstPersonFOV.TabIndex = 2;
            this.numFirstPersonFOV.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // labelCustomResolutionSpacer
            // 
            this.labelCustomResolutionSpacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCustomResolutionSpacer.AutoSize = true;
            this.labelCustomResolutionSpacer.Location = new System.Drawing.Point(242, 62);
            this.labelCustomResolutionSpacer.Name = "labelCustomResolutionSpacer";
            this.labelCustomResolutionSpacer.Size = new System.Drawing.Size(14, 13);
            this.labelCustomResolutionSpacer.TabIndex = 7;
            this.labelCustomResolutionSpacer.Text = "X";
            // 
            // comboBoxDisplayMode
            // 
            this.comboBoxDisplayMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayMode.FormattingEnabled = true;
            this.comboBoxDisplayMode.Location = new System.Drawing.Point(150, 6);
            this.comboBoxDisplayMode.Name = "comboBoxDisplayMode";
            this.comboBoxDisplayMode.Size = new System.Drawing.Size(196, 21);
            this.comboBoxDisplayMode.TabIndex = 0;
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(150, 31);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(196, 21);
            this.comboBoxResolution.TabIndex = 4;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBoxLogin);
            this.tabPageGeneral.Controls.Add(this.groupBoxInterface);
            this.tabPageGeneral.Controls.Add(this.groupBoxMainMenu);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(352, 412);
            this.tabPageGeneral.TabIndex = 3;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLogin.Controls.Add(this.labelCredentialsExplanation);
            this.groupBoxLogin.Controls.Add(this.textBoxPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxUserName);
            this.groupBoxLogin.Controls.Add(this.checkBoxShowPassword);
            this.groupBoxLogin.Controls.Add(this.labelPassword);
            this.groupBoxLogin.Controls.Add(this.labelUserName);
            this.groupBoxLogin.Location = new System.Drawing.Point(10, 7);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(333, 142);
            this.groupBoxLogin.TabIndex = 14;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // labelCredentialsExplanation
            // 
            this.labelCredentialsExplanation.AutoSize = true;
            this.labelCredentialsExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredentialsExplanation.ForeColor = System.Drawing.Color.DimGray;
            this.labelCredentialsExplanation.Location = new System.Drawing.Point(6, 93);
            this.labelCredentialsExplanation.Name = "labelCredentialsExplanation";
            this.labelCredentialsExplanation.Size = new System.Drawing.Size(262, 39);
            this.labelCredentialsExplanation.TabIndex = 5;
            this.labelCredentialsExplanation.Text = "Your credentials are saved into Fallout76Custom.ini\r\nThis way, you don\'t have to " +
    "login if you start Fallout 76\r\nwithout the launcher.";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(92, 47);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(235, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(92, 22);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(235, 20);
            this.textBoxUserName.TabIndex = 3;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(92, 73);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(101, 17);
            this.checkBoxShowPassword.TabIndex = 2;
            this.checkBoxShowPassword.Text = "Show password";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 50);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(6, 25);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(61, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User name:";
            // 
            // groupBoxInterface
            // 
            this.groupBoxInterface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInterface.Controls.Add(this.checkBoxShowCompass);
            this.groupBoxInterface.Controls.Add(this.checkBoxShowDamageNumbersNW);
            this.groupBoxInterface.Controls.Add(this.checkBoxShowDamageNumbersA);
            this.groupBoxInterface.Controls.Add(this.checkBoxGeneralSubtitles);
            this.groupBoxInterface.Controls.Add(this.checkBoxDialogueSubtitles);
            this.groupBoxInterface.Location = new System.Drawing.Point(10, 252);
            this.groupBoxInterface.Name = "groupBoxInterface";
            this.groupBoxInterface.Size = new System.Drawing.Size(333, 141);
            this.groupBoxInterface.TabIndex = 13;
            this.groupBoxInterface.TabStop = false;
            this.groupBoxInterface.Text = "Interface";
            // 
            // groupBoxMainMenu
            // 
            this.groupBoxMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMainMenu.Controls.Add(this.checkBoxShowSplash);
            this.groupBoxMainMenu.Controls.Add(this.checkBoxIntroVideos);
            this.groupBoxMainMenu.Controls.Add(this.checkBoxMainMenuMusic);
            this.groupBoxMainMenu.Location = new System.Drawing.Point(10, 155);
            this.groupBoxMainMenu.Name = "groupBoxMainMenu";
            this.groupBoxMainMenu.Size = new System.Drawing.Size(333, 91);
            this.groupBoxMainMenu.TabIndex = 5;
            this.groupBoxMainMenu.TabStop = false;
            this.groupBoxMainMenu.Text = "Main Menu";
            // 
            // groupBoxGameEdition
            // 
            this.groupBoxGameEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionSteam);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionBethesdaNet);
            this.groupBoxGameEdition.Location = new System.Drawing.Point(219, 456);
            this.groupBoxGameEdition.Name = "groupBoxGameEdition";
            this.groupBoxGameEdition.Size = new System.Drawing.Size(153, 64);
            this.groupBoxGameEdition.TabIndex = 12;
            this.groupBoxGameEdition.TabStop = false;
            this.groupBoxGameEdition.Text = "Game edition";
            // 
            // radioButtonEditionSteam
            // 
            this.radioButtonEditionSteam.AutoSize = true;
            this.radioButtonEditionSteam.Location = new System.Drawing.Point(10, 41);
            this.radioButtonEditionSteam.Name = "radioButtonEditionSteam";
            this.radioButtonEditionSteam.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEditionSteam.TabIndex = 1;
            this.radioButtonEditionSteam.Text = "Steam";
            this.radioButtonEditionSteam.UseVisualStyleBackColor = true;
            this.radioButtonEditionSteam.CheckedChanged += new System.EventHandler(this.radioButtonEditionSteam_CheckedChanged);
            // 
            // radioButtonEditionBethesdaNet
            // 
            this.radioButtonEditionBethesdaNet.AutoSize = true;
            this.radioButtonEditionBethesdaNet.Location = new System.Drawing.Point(10, 18);
            this.radioButtonEditionBethesdaNet.Name = "radioButtonEditionBethesdaNet";
            this.radioButtonEditionBethesdaNet.Size = new System.Drawing.Size(88, 17);
            this.radioButtonEditionBethesdaNet.TabIndex = 0;
            this.radioButtonEditionBethesdaNet.Text = "Bethesda.net";
            this.radioButtonEditionBethesdaNet.UseVisualStyleBackColor = true;
            this.radioButtonEditionBethesdaNet.CheckedChanged += new System.EventHandler(this.radioButtonEditionBethesdaNet_CheckedChanged);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.labelNewVersion);
            this.tabPageInfo.Controls.Add(this.buttonFixIssuesEarlierVersion);
            this.tabPageInfo.Controls.Add(this.labelTranslationAuthor);
            this.tabPageInfo.Controls.Add(this.labelTranslationBy);
            this.tabPageInfo.Controls.Add(this.linkLabel1);
            this.tabPageInfo.Controls.Add(this.labelAuthorName);
            this.tabPageInfo.Controls.Add(this.labelConfigVersion);
            this.tabPageInfo.Controls.Add(this.labelAuthor);
            this.tabPageInfo.Controls.Add(this.labelLanguage);
            this.tabPageInfo.Controls.Add(this.labelVersion);
            this.tabPageInfo.Controls.Add(this.comboBoxLanguage);
            this.tabPageInfo.Controls.Add(this.labelDescription);
            this.tabPageInfo.Controls.Add(this.linkLabelDownloadPage);
            this.tabPageInfo.Controls.Add(this.labelTitle);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(352, 412);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // labelNewVersion
            // 
            this.labelNewVersion.AutoSize = true;
            this.labelNewVersion.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewVersion.ForeColor = System.Drawing.Color.Crimson;
            this.labelNewVersion.Location = new System.Drawing.Point(18, 194);
            this.labelNewVersion.Name = "labelNewVersion";
            this.labelNewVersion.Size = new System.Drawing.Size(216, 16);
            this.labelNewVersion.TabIndex = 16;
            this.labelNewVersion.Text = "There is a newer version available: {0}";
            // 
            // buttonFixIssuesEarlierVersion
            // 
            this.buttonFixIssuesEarlierVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFixIssuesEarlierVersion.Location = new System.Drawing.Point(18, 346);
            this.buttonFixIssuesEarlierVersion.Name = "buttonFixIssuesEarlierVersion";
            this.buttonFixIssuesEarlierVersion.Size = new System.Drawing.Size(316, 23);
            this.buttonFixIssuesEarlierVersion.TabIndex = 15;
            this.buttonFixIssuesEarlierVersion.Text = "Fix settings from v1.3.1 and earlier";
            this.buttonFixIssuesEarlierVersion.UseVisualStyleBackColor = true;
            this.buttonFixIssuesEarlierVersion.Click += new System.EventHandler(this.buttonFixIssuesEarlierVersion_Click);
            // 
            // labelTranslationAuthor
            // 
            this.labelTranslationAuthor.AutoSize = true;
            this.labelTranslationAuthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationAuthor.Location = new System.Drawing.Point(106, 158);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(57, 13);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "datasnake";
            // 
            // labelTranslationBy
            // 
            this.labelTranslationBy.AutoSize = true;
            this.labelTranslationBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationBy.Location = new System.Drawing.Point(18, 158);
            this.labelTranslationBy.Name = "labelTranslationBy";
            this.labelTranslationBy.Size = new System.Drawing.Size(76, 13);
            this.labelTranslationBy.TabIndex = 11;
            this.labelTranslationBy.Text = "Translation by:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(18, 330);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open README";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Location = new System.Drawing.Point(106, 140);
            this.labelAuthorName.Name = "labelAuthorName";
            this.labelAuthorName.Size = new System.Drawing.Size(57, 13);
            this.labelAuthorName.TabIndex = 10;
            this.labelAuthorName.Text = "datasnake";
            // 
            // labelConfigVersion
            // 
            this.labelConfigVersion.AutoSize = true;
            this.labelConfigVersion.Location = new System.Drawing.Point(106, 122);
            this.labelConfigVersion.Name = "labelConfigVersion";
            this.labelConfigVersion.Size = new System.Drawing.Size(13, 13);
            this.labelConfigVersion.TabIndex = 9;
            this.labelConfigVersion.Text = "?";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(18, 140);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author:";
            // 
            // labelLanguage
            // 
            this.labelLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(15, 382);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 4;
            this.labelLanguage.Text = "Language:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(18, 123);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 13);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(94, 379);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(240, 21);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(18, 69);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(268, 26);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "This tool allows you to quickly tweak INI settings.\r\nTip: Hover over an option, i" +
    "f you\'re unsure what it does.";
            // 
            // linkLabelDownloadPage
            // 
            this.linkLabelDownloadPage.AutoSize = true;
            this.linkLabelDownloadPage.Location = new System.Drawing.Point(18, 212);
            this.linkLabelDownloadPage.Name = "linkLabelDownloadPage";
            this.linkLabelDownloadPage.Size = new System.Drawing.Size(189, 13);
            this.linkLabelDownloadPage.TabIndex = 2;
            this.linkLabelDownloadPage.TabStop = true;
            this.linkLabelDownloadPage.Text = "Get the latest version from NexusMods";
            this.linkLabelDownloadPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTitle.Location = new System.Drawing.Point(17, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(222, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Fallout 76 Quick Configuration";
            // 
            // buttonManageMods
            // 
            this.buttonManageMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonManageMods.Location = new System.Drawing.Point(12, 526);
            this.buttonManageMods.Name = "buttonManageMods";
            this.buttonManageMods.Size = new System.Drawing.Size(146, 23);
            this.buttonManageMods.TabIndex = 13;
            this.buttonManageMods.Text = "Manage mods";
            this.buttonManageMods.UseVisualStyleBackColor = true;
            this.buttonManageMods.Click += new System.EventHandler(this.buttonManageMods_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageInfo);
            this.tabControl1.Controls.Add(this.tabPageGeneral);
            this.tabControl1.Controls.Add(this.tabPageDisplay);
            this.tabControl1.Controls.Add(this.tabPageGraphics);
            this.tabControl1.Controls.Add(this.tabPageControls);
            this.tabControl1.Controls.Add(this.tabPagePipBoy);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 438);
            this.tabControl1.TabIndex = 7;
            // 
            // checkBoxNWMode
            // 
            this.checkBoxNWMode.AutoSize = true;
            this.checkBoxNWMode.Location = new System.Drawing.Point(6, 19);
            this.checkBoxNWMode.Name = "checkBoxNWMode";
            this.checkBoxNWMode.Size = new System.Drawing.Size(127, 17);
            this.checkBoxNWMode.TabIndex = 17;
            this.checkBoxNWMode.Text = "Nuclear Winter Mode";
            this.checkBoxNWMode.UseVisualStyleBackColor = true;
            this.checkBoxNWMode.CheckedChanged += new System.EventHandler(this.checkBoxNWMode_CheckedChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxOptions.Controls.Add(this.checkBoxNWMode);
            this.groupBoxOptions.Controls.Add(this.checkBoxReadOnly);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 456);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(203, 64);
            this.groupBoxOptions.TabIndex = 15;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxGameEdition);
            this.Controls.Add(this.buttonManageMods);
            this.Controls.Add(this.buttonLaunchGame);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonApply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "Form1";
            this.Text = "Fallout 76 Quick Configuration";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPipboyTargetWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPipboyTargetHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResH)).EndInit();
            this.tabPagePipBoy.ResumeLayout(false);
            this.groupBoxPipboyResolution.ResumeLayout(false);
            this.groupBoxPipboyResolution.PerformLayout();
            this.groupBoxPipboyMode.ResumeLayout(false);
            this.groupBoxPipboyMode.PerformLayout();
            this.groupBoxPipboyColors.ResumeLayout(false);
            this.groupBoxPipboyColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewPAPipboy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewPipboy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreviewQuickboy)).EndInit();
            this.tabPageControls.ResumeLayout(false);
            this.groupBoxGamepad.ResumeLayout(false);
            this.groupBoxGamepad.PerformLayout();
            this.groupBoxMouse.ResumeLayout(false);
            this.groupBoxMouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivity)).EndInit();
            this.tabPageGraphics.ResumeLayout(false);
            this.tabPageGraphics.PerformLayout();
            this.groupBoxTAASharpening.ResumeLayout(false);
            this.groupBoxTAASharpening.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTAAPostSharpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTAAPostOverlay)).EndInit();
            this.groupBoxGrass.ResumeLayout(false);
            this.groupBoxGrass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrassFadeDistance)).EndInit();
            this.groupBoxLOD.ResumeLayout(false);
            this.groupBoxLOD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLODActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLODItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLODObjects)).EndInit();
            this.groupBoxLighting.ResumeLayout(false);
            this.groupBoxLighting.PerformLayout();
            this.groupBoxShadows.ResumeLayout(false);
            this.groupBoxShadows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShadowDistance)).EndInit();
            this.groupBoxWater.ResumeLayout(false);
            this.groupBoxWater.PerformLayout();
            this.groupBoxPostProcessing.ResumeLayout(false);
            this.groupBoxPostProcessing.PerformLayout();
            this.groupBoxWeather.ResumeLayout(false);
            this.groupBoxWeather.PerformLayout();
            this.tabPageDisplay.ResumeLayout(false);
            this.tabPageDisplay.PerformLayout();
            this.groupBoxFieldOfView.ResumeLayout(false);
            this.groupBoxFieldOfView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorldFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPersonFOV)).EndInit();
            this.tabPageGeneral.ResumeLayout(false);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBoxInterface.ResumeLayout(false);
            this.groupBoxInterface.PerformLayout();
            this.groupBoxMainMenu.ResumeLayout(false);
            this.groupBoxMainMenu.PerformLayout();
            this.groupBoxGameEdition.ResumeLayout(false);
            this.groupBoxGameEdition.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkBoxReadOnly;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonLaunchGame;
        private System.Windows.Forms.TabPage tabPagePipBoy;
        private System.Windows.Forms.GroupBox groupBoxPipboyResolution;
        private System.Windows.Forms.Label labelPipboyResolutionSideNote;
        private System.Windows.Forms.Button buttonPipboyTargetSetRecommended;
        private System.Windows.Forms.Button buttonPipboyTargetReset;
        private System.Windows.Forms.NumericUpDown numPipboyTargetHeight;
        private System.Windows.Forms.NumericUpDown numPipboyTargetWidth;
        private System.Windows.Forms.Label labelPipboyResolutionSpacer;
        private System.Windows.Forms.GroupBox groupBoxPipboyMode;
        private System.Windows.Forms.RadioButton radioButtonQuickboy;
        private System.Windows.Forms.RadioButton radioButtonPipboy;
        private System.Windows.Forms.GroupBox groupBoxPipboyColors;
        private System.Windows.Forms.PictureBox colorPreviewPipboy;
        private System.Windows.Forms.PictureBox colorPreviewQuickboy;
        private System.Windows.Forms.Label labelQuickboyColor;
        private System.Windows.Forms.Button buttonColorResetPipboy;
        private System.Windows.Forms.Button buttonColorPickQuickboy;
        private System.Windows.Forms.Button buttonColorResetQuickboy;
        private System.Windows.Forms.Label labelPipboyColor;
        private System.Windows.Forms.Button buttonColorPickPipboy;
        private System.Windows.Forms.TabPage tabPageControls;
        private System.Windows.Forms.GroupBox groupBoxGamepad;
        private System.Windows.Forms.CheckBox checkBoxGamepadEnabled;
        private System.Windows.Forms.CheckBox checkBoxGamepadRumble;
        private System.Windows.Forms.GroupBox groupBoxMouse;
        private System.Windows.Forms.CheckBox checkBoxFixAimSensitivity;
        private System.Windows.Forms.NumericUpDown numMouseSensitivity;
        private System.Windows.Forms.Label labelMouseSensitivity;
        private MetroFramework.Controls.MetroTrackBar sliderMouseSensitivity;
        private System.Windows.Forms.CheckBox checkBoxFixMouseSensitivity;
        private System.Windows.Forms.TabPage tabPageGraphics;
        private System.Windows.Forms.GroupBox groupBoxGrass;
        private System.Windows.Forms.NumericUpDown numGrassFadeDistance;
        private MetroFramework.Controls.MetroTrackBar sliderGrassFadeDistance;
        private System.Windows.Forms.Label labelGrassFadeDistance;
        private System.Windows.Forms.CheckBox checkBoxGrass;
        private System.Windows.Forms.GroupBox groupBoxLOD;
        private System.Windows.Forms.Label labelLODFadeDistance;
        private System.Windows.Forms.NumericUpDown numLODActors;
        private MetroFramework.Controls.MetroTrackBar sliderLODActors;
        private System.Windows.Forms.NumericUpDown numLODItems;
        private MetroFramework.Controls.MetroTrackBar sliderLODItems;
        private System.Windows.Forms.NumericUpDown numLODObjects;
        private MetroFramework.Controls.MetroTrackBar sliderLODObjects;
        private System.Windows.Forms.Label labelLODActors;
        private System.Windows.Forms.Label labelLODItems;
        private System.Windows.Forms.Label labelLODObjects;
        private System.Windows.Forms.GroupBox groupBoxLighting;
        private System.Windows.Forms.CheckBox checkBoxGodrays;
        private System.Windows.Forms.GroupBox groupBoxShadows;
        private System.Windows.Forms.ComboBox comboBoxShadowBlurriness;
        private System.Windows.Forms.Label labelShadowBlurriness;
        private System.Windows.Forms.NumericUpDown numShadowDistance;
        private MetroFramework.Controls.MetroTrackBar sliderShadowDistance;
        private System.Windows.Forms.Label labelShadowDistance;
        private System.Windows.Forms.ComboBox comboBoxShadowTextureResolution;
        private System.Windows.Forms.Label labelShadowTextureResolution;
        private System.Windows.Forms.GroupBox groupBoxWater;
        private System.Windows.Forms.CheckBox checkBoxWaterDisplacement;
        private System.Windows.Forms.GroupBox groupBoxPostProcessing;
        private System.Windows.Forms.CheckBox checkBoxAmbientOcclusion;
        private System.Windows.Forms.CheckBox checkBoxDepthOfField;
        private System.Windows.Forms.CheckBox checkBoxMotionBlur;
        private System.Windows.Forms.CheckBox checkBoxRadialBlur;
        private System.Windows.Forms.CheckBox checkBoxLensFlare;
        private System.Windows.Forms.GroupBox groupBoxWeather;
        private System.Windows.Forms.CheckBox checkBoxWeatherWetnessOcclusion;
        private System.Windows.Forms.CheckBox checkBoxWeatherRainOcclusion;
        private System.Windows.Forms.ComboBox comboBoxAnisotropicFiltering;
        private System.Windows.Forms.Label labelAnisotropicFiltering;
        private System.Windows.Forms.CheckBox checkBoxVSync;
        private System.Windows.Forms.ComboBox comboBoxAntiAliasing;
        private System.Windows.Forms.Label labelAntiAliasing;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private System.Windows.Forms.CheckBox checkBoxAlwaysActive;
        private System.Windows.Forms.CheckBox checkBoxTopMostWindow;
        private System.Windows.Forms.GroupBox groupBoxFieldOfView;
        private System.Windows.Forms.NumericUpDown numWorldFOV;
        private System.Windows.Forms.NumericUpDown numFirstPersonFOV;
        private System.Windows.Forms.Label labelWorldFOV;
        private System.Windows.Forms.Label labelFirstPersonFOV;
        private System.Windows.Forms.NumericUpDown numCustomResH;
        private System.Windows.Forms.Label labelCustomResolutionSpacer;
        private System.Windows.Forms.ComboBox comboBoxDisplayMode;
        private System.Windows.Forms.Label labelDisplayMode;
        private System.Windows.Forms.NumericUpDown numCustomResW;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelCustomResolution;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.GroupBox groupBoxInterface;
        private System.Windows.Forms.CheckBox checkBoxShowCompass;
        private System.Windows.Forms.CheckBox checkBoxShowDamageNumbersNW;
        private System.Windows.Forms.CheckBox checkBoxShowDamageNumbersA;
        private System.Windows.Forms.CheckBox checkBoxGeneralSubtitles;
        private System.Windows.Forms.CheckBox checkBoxDialogueSubtitles;
        private System.Windows.Forms.GroupBox groupBoxGameEdition;
        private System.Windows.Forms.RadioButton radioButtonEditionSteam;
        private System.Windows.Forms.RadioButton radioButtonEditionBethesdaNet;
        private System.Windows.Forms.GroupBox groupBoxMainMenu;
        private System.Windows.Forms.CheckBox checkBoxShowSplash;
        private System.Windows.Forms.CheckBox checkBoxIntroVideos;
        private System.Windows.Forms.CheckBox checkBoxMainMenuMusic;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonManageMods;
        private System.Windows.Forms.Label labelTranslationAuthor;
        private System.Windows.Forms.Label labelTranslationBy;
        private System.Windows.Forms.Label labelAuthorName;
        private System.Windows.Forms.Label labelConfigVersion;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.LinkLabel linkLabelDownloadPage;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonFixIssuesEarlierVersion;
        private System.Windows.Forms.Label labelNewVersion;
        private System.Windows.Forms.PictureBox colorPreviewPAPipboy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonColorPickPAPipboy;
        private System.Windows.Forms.Button buttonColorResetPAPipboy;
        private System.Windows.Forms.GroupBox groupBoxTAASharpening;
        private System.Windows.Forms.NumericUpDown numTAAPostSharpen;
        private System.Windows.Forms.Label labelTAAPostSharpen;
        private MetroFramework.Controls.MetroTrackBar sliderTAAPostSharpen;
        private System.Windows.Forms.NumericUpDown numTAAPostOverlay;
        private System.Windows.Forms.Label labelTAAPostOverlay;
        private MetroFramework.Controls.MetroTrackBar sliderTAAPostOverlay;
        private System.Windows.Forms.CheckBox checkBoxNWMode;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxMouseAcceleration;
        private System.Windows.Forms.CheckBox checkBoxFogEnabled;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelCredentialsExplanation;
    }
}

