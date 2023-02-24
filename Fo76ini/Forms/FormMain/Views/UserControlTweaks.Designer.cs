namespace Fo76ini.Forms.FormMain
{
    partial class UserControlTweaks
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlTweaks = new Fo76ini.Controls.StyledTabControl();
            this.tabPageTweaksInfo = new System.Windows.Forms.TabPage();
            this.webBrowserTweaksInfo = new CefSharp.WinForms.ChromiumWebBrowser();
            this.labelTweaksInfoWin7 = new System.Windows.Forms.Label();
            this.buttonOpenTweaksInfoInBrowser = new System.Windows.Forms.Button();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxGameplay = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxBackpackVisible = new System.Windows.Forms.CheckBox();
            this.labelHighlightCorpses = new System.Windows.Forms.Label();
            this.comboBoxHighlightCorpses = new System.Windows.Forms.ComboBox();
            this.groupBoxDialogue = new Fo76ini.Controls.StyledGroupBox();
            this.sliderConversationHistorySize = new ColorSlider.ColorSlider();
            this.numConversationHistorySize = new System.Windows.Forms.NumericUpDown();
            this.labelConversationHistorySize = new System.Windows.Forms.Label();
            this.checkBoxDialogueHistory = new System.Windows.Forms.CheckBox();
            this.checkBoxDialogueSubtitles = new System.Windows.Forms.CheckBox();
            this.checkBoxGeneralSubtitles = new System.Windows.Forms.CheckBox();
            this.groupBoxHUD = new Fo76ini.Controls.StyledGroupBox();
            this.groupBoxFloatingQuestMarkers = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxShowFloatingQuestMarkers = new System.Windows.Forms.CheckBox();
            this.sliderFloatingQuestMarkersDistance = new ColorSlider.ColorSlider();
            this.checkBoxShowFloatingQuestText = new System.Windows.Forms.CheckBox();
            this.labelFloatingQuestMarkersDistance = new System.Windows.Forms.Label();
            this.numFloatingQuestMarkersDistance = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowOtherPlayersNames = new System.Windows.Forms.CheckBox();
            this.checkBoxShowPublicTeamNotifications = new System.Windows.Forms.CheckBox();
            this.checkBoxEnablePowerArmorHUD = new System.Windows.Forms.CheckBox();
            this.checkBoxShowDamageNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCrosshair = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCompass = new System.Windows.Forms.CheckBox();
            this.labelShowActiveEffectsOnHUD = new System.Windows.Forms.Label();
            this.labelHUDOpacity = new System.Windows.Forms.Label();
            this.comboBoxShowActiveEffectsOnHUD = new System.Windows.Forms.ComboBox();
            this.sliderHUDOpacity = new ColorSlider.ColorSlider();
            this.numHUDOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBoxLoading = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxFasterFadeIn = new System.Windows.Forms.CheckBox();
            this.groupBoxQuests = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxEnableQuestAutoTrackDaily = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableQuestAutoTrackEvent = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableQuestAutoTrackMisc = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableQuestAutoTrackSide = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableQuestAutoTrackMain = new System.Windows.Forms.CheckBox();
            this.groupBoxMainMenu = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxSkipSplash = new System.Windows.Forms.CheckBox();
            this.checkBoxSkipIntroVideos = new System.Windows.Forms.CheckBox();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.groupBoxGraphics = new Fo76ini.Controls.StyledGroupBox();
            this.groupBoxDOF = new Fo76ini.Controls.StyledGroupBox();
            this.numDOFStrength = new System.Windows.Forms.NumericUpDown();
            this.labelDOFStrength = new System.Windows.Forms.Label();
            this.checkBoxDepthOfField = new System.Windows.Forms.CheckBox();
            this.sliderDOFStrength = new ColorSlider.ColorSlider();
            this.labelSelectedQualityPreset = new System.Windows.Forms.Label();
            this.buttonSelectOverallQualityPreset = new System.Windows.Forms.Button();
            this.contextMenuStripOverallQualityPresets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOverallQualityPreset = new System.Windows.Forms.Label();
            this.groupBoxTextures = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxTextureQuality = new System.Windows.Forms.ComboBox();
            this.labelTextureQuality = new System.Windows.Forms.Label();
            this.groupBoxGraphicEffects = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxBloodSplatter = new System.Windows.Forms.CheckBox();
            this.checkBoxDisableGore = new System.Windows.Forms.CheckBox();
            this.groupBoxTAASharpening = new Fo76ini.Controls.StyledGroupBox();
            this.sliderTAAPostSharpen = new ColorSlider.ColorSlider();
            this.labelTAAPostSharpen = new System.Windows.Forms.Label();
            this.numTAAPostSharpen = new System.Windows.Forms.NumericUpDown();
            this.sliderTAAPostOverlay = new ColorSlider.ColorSlider();
            this.numTAAPostOverlay = new System.Windows.Forms.NumericUpDown();
            this.labelTAAPostOverlay = new System.Windows.Forms.Label();
            this.labelAntiAliasing = new System.Windows.Forms.Label();
            this.groupBoxGrass = new Fo76ini.Controls.StyledGroupBox();
            this.sliderGrassFadeDistance = new ColorSlider.ColorSlider();
            this.numGrassFadeDistance = new System.Windows.Forms.NumericUpDown();
            this.labelGrassFadeDistance = new System.Windows.Forms.Label();
            this.checkBoxGrass = new System.Windows.Forms.CheckBox();
            this.comboBoxAntiAliasing = new System.Windows.Forms.ComboBox();
            this.groupBoxLOD = new Fo76ini.Controls.StyledGroupBox();
            this.sliderLODActors = new ColorSlider.ColorSlider();
            this.labelLODFadeDistance = new System.Windows.Forms.Label();
            this.sliderLODItems = new ColorSlider.ColorSlider();
            this.numLODActors = new System.Windows.Forms.NumericUpDown();
            this.numLODItems = new System.Windows.Forms.NumericUpDown();
            this.sliderLODObjects = new ColorSlider.ColorSlider();
            this.numLODObjects = new System.Windows.Forms.NumericUpDown();
            this.labelLODActors = new System.Windows.Forms.Label();
            this.labelLODItems = new System.Windows.Forms.Label();
            this.labelLODObjects = new System.Windows.Forms.Label();
            this.checkBoxVSync = new System.Windows.Forms.CheckBox();
            this.groupBoxLighting = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxGodrayQuality = new System.Windows.Forms.ComboBox();
            this.labelGodrayQuality = new System.Windows.Forms.Label();
            this.checkBoxGodrays = new System.Windows.Forms.CheckBox();
            this.labelAnisotropicFiltering = new System.Windows.Forms.Label();
            this.groupBoxShadows = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxShadowQuality = new System.Windows.Forms.ComboBox();
            this.labelShadowQuality = new System.Windows.Forms.Label();
            this.sliderShadowDistance = new ColorSlider.ColorSlider();
            this.comboBoxShadowBlurriness = new System.Windows.Forms.ComboBox();
            this.labelShadowBlurriness = new System.Windows.Forms.Label();
            this.numShadowDistance = new System.Windows.Forms.NumericUpDown();
            this.labelShadowDistance = new System.Windows.Forms.Label();
            this.comboBoxShadowTextureResolution = new System.Windows.Forms.ComboBox();
            this.labelShadowTextureResolution = new System.Windows.Forms.Label();
            this.comboBoxAnisotropicFiltering = new System.Windows.Forms.ComboBox();
            this.groupBoxWater = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxWaterShadowFilter = new System.Windows.Forms.ComboBox();
            this.labelWaterShadowFilter = new System.Windows.Forms.Label();
            this.checkBoxWaterFixSSRGlitch = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterHiRes = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterRefractions = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterReflections = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterDisplacement = new System.Windows.Forms.CheckBox();
            this.groupBoxPostProcessing = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxSSReflections = new System.Windows.Forms.CheckBox();
            this.checkBoxAmbientOcclusion = new System.Windows.Forms.CheckBox();
            this.checkBoxMotionBlur = new System.Windows.Forms.CheckBox();
            this.checkBoxRadialBlur = new System.Windows.Forms.CheckBox();
            this.checkBoxLensFlare = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxDisplayMode = new System.Windows.Forms.ComboBox();
            this.checkBoxFixHUDFor5_4and4_3 = new System.Windows.Forms.CheckBox();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.buttonDetectResolution = new System.Windows.Forms.Button();
            this.labelCustomResolution = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.checkBoxTopMostWindow = new System.Windows.Forms.CheckBox();
            this.numCustomResW = new System.Windows.Forms.NumericUpDown();
            this.numCustomResH = new System.Windows.Forms.NumericUpDown();
            this.labelDisplayMode = new System.Windows.Forms.Label();
            this.labelCustomResolutionSpacer = new System.Windows.Forms.Label();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.groupBoxAudio = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxEnableAudio = new System.Windows.Forms.CheckBox();
            this.checkBoxMainMenuMusic = new System.Windows.Forms.CheckBox();
            this.groupBoxVoice = new Fo76ini.Controls.StyledGroupBox();
            this.comboBoxVoiceChatMode = new System.Windows.Forms.ComboBox();
            this.labelVoiceChatMode = new System.Windows.Forms.Label();
            this.checkBoxPushToTalk = new System.Windows.Forms.CheckBox();
            this.groupBoxAudioVolume = new Fo76ini.Controls.StyledGroupBox();
            this.sliderAudioChat = new ColorSlider.ColorSlider();
            this.sliderAudiofVal6 = new ColorSlider.ColorSlider();
            this.sliderAudiofVal5 = new ColorSlider.ColorSlider();
            this.sliderAudiofVal4 = new ColorSlider.ColorSlider();
            this.sliderAudiofVal3 = new ColorSlider.ColorSlider();
            this.sliderAudiofVal2 = new ColorSlider.ColorSlider();
            this.sliderAudiofVal1 = new ColorSlider.ColorSlider();
            this.labelVolumeMaster = new System.Windows.Forms.Label();
            this.sliderVolumeMaster = new ColorSlider.ColorSlider();
            this.numVolumeMaster = new System.Windows.Forms.NumericUpDown();
            this.numAudioChat = new System.Windows.Forms.NumericUpDown();
            this.sliderAudiofVal0 = new ColorSlider.ColorSlider();
            this.labelAudioChat = new System.Windows.Forms.Label();
            this.labelAudiofVal0 = new System.Windows.Forms.Label();
            this.numAudiofVal0 = new System.Windows.Forms.NumericUpDown();
            this.numAudiofVal6 = new System.Windows.Forms.NumericUpDown();
            this.labelAudiofVal6 = new System.Windows.Forms.Label();
            this.labelAudiofVal1 = new System.Windows.Forms.Label();
            this.numAudiofVal1 = new System.Windows.Forms.NumericUpDown();
            this.numAudiofVal5 = new System.Windows.Forms.NumericUpDown();
            this.labelAudiofVal5 = new System.Windows.Forms.Label();
            this.labelAudiofVal2 = new System.Windows.Forms.Label();
            this.numAudiofVal2 = new System.Windows.Forms.NumericUpDown();
            this.numAudiofVal4 = new System.Windows.Forms.NumericUpDown();
            this.labelAudiofVal4 = new System.Windows.Forms.Label();
            this.labelAudiofVal3 = new System.Windows.Forms.Label();
            this.numAudiofVal3 = new System.Windows.Forms.NumericUpDown();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.groupBoxGamepad = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxAimAssist = new System.Windows.Forms.CheckBox();
            this.checkBoxGamepadRumble = new System.Windows.Forms.CheckBox();
            this.checkBoxGamepadEnabled = new System.Windows.Forms.CheckBox();
            this.sliderGamepadSensitivityY = new ColorSlider.ColorSlider();
            this.numGamepadSensitivityY = new System.Windows.Forms.NumericUpDown();
            this.labelGamepadSensitivityY = new System.Windows.Forms.Label();
            this.sliderGamepadSensitivityX = new ColorSlider.ColorSlider();
            this.numGamepadSensitivityX = new System.Windows.Forms.NumericUpDown();
            this.labelGamepadSensitivityX = new System.Windows.Forms.Label();
            this.groupBoxMouse = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxMouseInvertX = new System.Windows.Forms.CheckBox();
            this.checkBoxMouseInvertY = new System.Windows.Forms.CheckBox();
            this.checkBoxFixAimSensitivity = new System.Windows.Forms.CheckBox();
            this.checkBoxFixMouseSensitivity = new System.Windows.Forms.CheckBox();
            this.sliderMouseSensitivityY = new ColorSlider.ColorSlider();
            this.numMouseSensitivityY = new System.Windows.Forms.NumericUpDown();
            this.labelMouseSensitivityY = new System.Windows.Forms.Label();
            this.sliderMouseSensitivityX = new ColorSlider.ColorSlider();
            this.numMouseSensitivityX = new System.Windows.Forms.NumericUpDown();
            this.labelMouseSensitivityX = new System.Windows.Forms.Label();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.groupBoxCameraPosition = new Fo76ini.Controls.StyledGroupBox();
            this.groupBoxMeleeCombatCameraPosition = new Fo76ini.Controls.StyledGroupBox();
            this.numfOverShoulderMeleeCombatAddY = new System.Windows.Forms.NumericUpDown();
            this.labelfOverShoulderMeleeCombatAddY = new System.Windows.Forms.Label();
            this.numfOverShoulderMeleeCombatPosX = new System.Windows.Forms.NumericUpDown();
            this.numfOverShoulderMeleeCombatPosZ = new System.Windows.Forms.NumericUpDown();
            this.trackBarfOverShoulderMeleeCombatAddY = new ColorSlider.ColorSlider();
            this.labelfOverShoulderMeleeCombatPosX = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderMeleeCombatPosX = new ColorSlider.ColorSlider();
            this.labelfOverShoulderMeleeCombatPosZ = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderMeleeCombatPosZ = new ColorSlider.ColorSlider();
            this.groupBoxCombatCameraPosition = new Fo76ini.Controls.StyledGroupBox();
            this.numfOverShoulderCombatAddY = new System.Windows.Forms.NumericUpDown();
            this.numfOverShoulderCombatPosX = new System.Windows.Forms.NumericUpDown();
            this.numfOverShoulderCombatPosZ = new System.Windows.Forms.NumericUpDown();
            this.labelfOverShoulderCombatAddY = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderCombatAddY = new ColorSlider.ColorSlider();
            this.labelfOverShoulderCombatPosX = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderCombatPosX = new ColorSlider.ColorSlider();
            this.labelfOverShoulderCombatPosZ = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderCombatPosZ = new ColorSlider.ColorSlider();
            this.buttonCameraPositionReset = new System.Windows.Forms.Button();
            this.checkBoxbApplyCameraNodeAnimations = new System.Windows.Forms.CheckBox();
            this.groupBoxUnarmedCameraPosition = new Fo76ini.Controls.StyledGroupBox();
            this.numfOverShoulderPosX = new System.Windows.Forms.NumericUpDown();
            this.numfOverShoulderPosZ = new System.Windows.Forms.NumericUpDown();
            this.labelfOverShoulderPosX = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderPosX = new ColorSlider.ColorSlider();
            this.labelfOverShoulderPosZ = new System.Windows.Forms.Label();
            this.trackBarfOverShoulderPosZ = new ColorSlider.ColorSlider();
            this.groupBoxFOVMore = new Fo76ini.Controls.StyledGroupBox();
            this.labelADSFOV = new System.Windows.Forms.Label();
            this.numADSFOV = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSelfieCamera = new Fo76ini.Controls.StyledGroupBox();
            this.trackBarPhotomodeRange = new ColorSlider.ColorSlider();
            this.numericUpDownPhotomodeRotationSpeed = new System.Windows.Forms.NumericUpDown();
            this.trackBarPhotomodeRotationSpeed = new ColorSlider.ColorSlider();
            this.labelPhotomodeRotationSpeed = new System.Windows.Forms.Label();
            this.numericUpDownPhotomodeRange = new System.Windows.Forms.NumericUpDown();
            this.labelPhotomodeRange = new System.Windows.Forms.Label();
            this.numericUpDownPhotomodeTranslationSpeed = new System.Windows.Forms.NumericUpDown();
            this.trackBarPhotomodeTranslationSpeed = new ColorSlider.ColorSlider();
            this.labelPhotomodeTranslationSpeed = new System.Windows.Forms.Label();
            this.groupBoxIdleCamera = new Fo76ini.Controls.StyledGroupBox();
            this.checkBoxForceVanityMode = new System.Windows.Forms.CheckBox();
            this.checkBoxVanityMode = new System.Windows.Forms.CheckBox();
            this.groupBoxCameraDistance = new Fo76ini.Controls.StyledGroupBox();
            this.numfPitchZoomOutMaxDist = new System.Windows.Forms.NumericUpDown();
            this.sliderfPitchZoomOutMaxDist = new ColorSlider.ColorSlider();
            this.labelPitchZoomOutMaxDist = new System.Windows.Forms.Label();
            this.numCameraDistanceMaximum = new System.Windows.Forms.NumericUpDown();
            this.numCameraDistanceMinimum = new System.Windows.Forms.NumericUpDown();
            this.sliderCameraDistanceMaximum = new ColorSlider.ColorSlider();
            this.labelCameraDistanceMaximum = new System.Windows.Forms.Label();
            this.labelCameraDistanceMinimum = new System.Windows.Forms.Label();
            this.sliderCameraDistanceMinimum = new ColorSlider.ColorSlider();
            this.groupBoxFieldOfView = new Fo76ini.Controls.StyledGroupBox();
            this.pictureBoxFOVPreview = new System.Windows.Forms.PictureBox();
            this.sliderFOV = new ColorSlider.ColorSlider();
            this.numFOV = new System.Windows.Forms.NumericUpDown();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.groupBoxLoginProfiles = new Fo76ini.Controls.StyledGroupBox();
            this.radioButtonAccountNone = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount1 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount16 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount2 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount15 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount3 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount14 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount4 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount13 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount5 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount12 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount6 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount11 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount7 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount10 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount8 = new System.Windows.Forms.RadioButton();
            this.radioButtonAccount9 = new System.Windows.Forms.RadioButton();
            this.groupBoxLogin = new Fo76ini.Controls.StyledGroupBox();
            this.richTextBoxCredentialsExplanation = new System.Windows.Forms.RichTextBox();
            this.checkBoxAutoSignin = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSteam = new System.Windows.Forms.CheckBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelTweaksDesc = new System.Windows.Forms.Label();
            this.labelTweaksTitle = new System.Windows.Forms.Label();
            this.toolTip = new Fo76ini.Controls.CustomToolTip(this.components);
            this.tabControlTweaks.SuspendLayout();
            this.tabPageTweaksInfo.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxGameplay.SuspendLayout();
            this.groupBoxDialogue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConversationHistorySize)).BeginInit();
            this.groupBoxHUD.SuspendLayout();
            this.groupBoxFloatingQuestMarkers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloatingQuestMarkersDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHUDOpacity)).BeginInit();
            this.groupBoxLoading.SuspendLayout();
            this.groupBoxQuests.SuspendLayout();
            this.groupBoxMainMenu.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.groupBoxGraphics.SuspendLayout();
            this.groupBoxDOF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDOFStrength)).BeginInit();
            this.contextMenuStripOverallQualityPresets.SuspendLayout();
            this.groupBoxTextures.SuspendLayout();
            this.groupBoxGraphicEffects.SuspendLayout();
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
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResH)).BeginInit();
            this.tabPageAudio.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.groupBoxVoice.SuspendLayout();
            this.groupBoxAudioVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolumeMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudioChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal3)).BeginInit();
            this.tabPageControls.SuspendLayout();
            this.groupBoxGamepad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamepadSensitivityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamepadSensitivityX)).BeginInit();
            this.groupBoxMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivityX)).BeginInit();
            this.tabPageCamera.SuspendLayout();
            this.groupBoxCameraPosition.SuspendLayout();
            this.groupBoxMeleeCombatCameraPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatAddY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatPosZ)).BeginInit();
            this.groupBoxCombatCameraPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatAddY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatPosZ)).BeginInit();
            this.groupBoxUnarmedCameraPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderPosZ)).BeginInit();
            this.groupBoxFOVMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numADSFOV)).BeginInit();
            this.groupBoxSelfieCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeRotationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeTranslationSpeed)).BeginInit();
            this.groupBoxIdleCamera.SuspendLayout();
            this.groupBoxCameraDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfPitchZoomOutMaxDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraDistanceMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraDistanceMinimum)).BeginInit();
            this.groupBoxFieldOfView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFOVPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFOV)).BeginInit();
            this.tabPageLogin.SuspendLayout();
            this.groupBoxLoginProfiles.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTweaks
            // 
            this.tabControlTweaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTweaks.BorderColor = System.Drawing.Color.Gray;
            this.tabControlTweaks.BorderWidth = 1;
            this.tabControlTweaks.Controls.Add(this.tabPageTweaksInfo);
            this.tabControlTweaks.Controls.Add(this.tabPageGeneral);
            this.tabControlTweaks.Controls.Add(this.tabPageVideo);
            this.tabControlTweaks.Controls.Add(this.tabPageAudio);
            this.tabControlTweaks.Controls.Add(this.tabPageControls);
            this.tabControlTweaks.Controls.Add(this.tabPageCamera);
            this.tabControlTweaks.Controls.Add(this.tabPageLogin);
            this.tabControlTweaks.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabControlTweaks.Location = new System.Drawing.Point(15, 75);
            this.tabControlTweaks.MouseOverTabButtonBackColor = System.Drawing.Color.LightGray;
            this.tabControlTweaks.Name = "tabControlTweaks";
            this.tabControlTweaks.SelectedIndex = 0;
            this.tabControlTweaks.SelectedTabButtonBackColor = System.Drawing.Color.Silver;
            this.tabControlTweaks.Size = new System.Drawing.Size(662, 502);
            this.tabControlTweaks.TabButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabControlTweaks.TabButtonForeColor = System.Drawing.Color.Black;
            this.tabControlTweaks.TabIndex = 0;
            // 
            // tabPageTweaksInfo
            // 
            this.tabPageTweaksInfo.BackColor = System.Drawing.Color.White;
            this.tabPageTweaksInfo.Controls.Add(this.webBrowserTweaksInfo);
            this.tabPageTweaksInfo.Controls.Add(this.labelTweaksInfoWin7);
            this.tabPageTweaksInfo.Controls.Add(this.buttonOpenTweaksInfoInBrowser);
            this.tabPageTweaksInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageTweaksInfo.Name = "tabPageTweaksInfo";
            this.tabPageTweaksInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTweaksInfo.Size = new System.Drawing.Size(654, 473);
            this.tabPageTweaksInfo.TabIndex = 6;
            this.tabPageTweaksInfo.Text = "Info";
            // 
            // webBrowserTweaksInfo
            // 
            this.webBrowserTweaksInfo.ActivateBrowserOnCreation = false;
            this.webBrowserTweaksInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserTweaksInfo.Location = new System.Drawing.Point(0, 0);
            this.webBrowserTweaksInfo.Name = "webBrowserTweaksInfo";
            this.webBrowserTweaksInfo.Size = new System.Drawing.Size(654, 473);
            this.webBrowserTweaksInfo.TabIndex = 4;
            // 
            // labelTweaksInfoWin7
            // 
            this.labelTweaksInfoWin7.Location = new System.Drawing.Point(6, 6);
            this.labelTweaksInfoWin7.Name = "labelTweaksInfoWin7";
            this.labelTweaksInfoWin7.Size = new System.Drawing.Size(642, 39);
            this.labelTweaksInfoWin7.TabIndex = 3;
            this.labelTweaksInfoWin7.Text = "The web browser control doesn\'t work properly under Windows 7 (and probably 8.1)\r" +
    "\nClick the button below to read the info.";
            // 
            // buttonOpenTweaksInfoInBrowser
            // 
            this.buttonOpenTweaksInfoInBrowser.Location = new System.Drawing.Point(6, 48);
            this.buttonOpenTweaksInfoInBrowser.Name = "buttonOpenTweaksInfoInBrowser";
            this.buttonOpenTweaksInfoInBrowser.Size = new System.Drawing.Size(176, 23);
            this.buttonOpenTweaksInfoInBrowser.TabIndex = 2;
            this.buttonOpenTweaksInfoInBrowser.Text = "Open in browser";
            this.buttonOpenTweaksInfoInBrowser.UseVisualStyleBackColor = true;
            this.buttonOpenTweaksInfoInBrowser.Click += new System.EventHandler(this.buttonOpenTweakInfoInBrowser_Click);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.AutoScroll = true;
            this.tabPageGeneral.BackColor = System.Drawing.Color.White;
            this.tabPageGeneral.Controls.Add(this.groupBoxGameplay);
            this.tabPageGeneral.Controls.Add(this.groupBoxDialogue);
            this.tabPageGeneral.Controls.Add(this.groupBoxHUD);
            this.tabPageGeneral.Controls.Add(this.groupBoxLoading);
            this.tabPageGeneral.Controls.Add(this.groupBoxQuests);
            this.tabPageGeneral.Controls.Add(this.groupBoxMainMenu);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(654, 473);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            // 
            // groupBoxGameplay
            // 
            this.groupBoxGameplay.BackColor = System.Drawing.Color.White;
            this.groupBoxGameplay.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxGameplay.BorderWidth = 1;
            this.groupBoxGameplay.Controls.Add(this.checkBoxBackpackVisible);
            this.groupBoxGameplay.Controls.Add(this.labelHighlightCorpses);
            this.groupBoxGameplay.Controls.Add(this.comboBoxHighlightCorpses);
            this.groupBoxGameplay.Location = new System.Drawing.Point(9, 144);
            this.groupBoxGameplay.Name = "groupBoxGameplay";
            this.groupBoxGameplay.Size = new System.Drawing.Size(400, 77);
            this.groupBoxGameplay.TabIndex = 2;
            this.groupBoxGameplay.TabStop = false;
            this.groupBoxGameplay.Text = "Gameplay";
            this.groupBoxGameplay.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxGameplay.TitleBorderMargin = 6;
            this.groupBoxGameplay.TitleBorderPadding = 4;
            this.groupBoxGameplay.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxBackpackVisible
            // 
            this.checkBoxBackpackVisible.AutoSize = true;
            this.checkBoxBackpackVisible.Location = new System.Drawing.Point(10, 46);
            this.checkBoxBackpackVisible.Name = "checkBoxBackpackVisible";
            this.checkBoxBackpackVisible.Size = new System.Drawing.Size(108, 17);
            this.checkBoxBackpackVisible.TabIndex = 5;
            this.checkBoxBackpackVisible.Text = "Backpack Visible";
            this.checkBoxBackpackVisible.UseVisualStyleBackColor = true;
            // 
            // labelHighlightCorpses
            // 
            this.labelHighlightCorpses.AutoSize = true;
            this.labelHighlightCorpses.Location = new System.Drawing.Point(6, 21);
            this.labelHighlightCorpses.Name = "labelHighlightCorpses";
            this.labelHighlightCorpses.Size = new System.Drawing.Size(91, 13);
            this.labelHighlightCorpses.TabIndex = 3;
            this.labelHighlightCorpses.Text = "Highlight corpses:";
            // 
            // comboBoxHighlightCorpses
            // 
            this.comboBoxHighlightCorpses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHighlightCorpses.FormattingEnabled = true;
            this.comboBoxHighlightCorpses.Location = new System.Drawing.Point(198, 18);
            this.comboBoxHighlightCorpses.Name = "comboBoxHighlightCorpses";
            this.comboBoxHighlightCorpses.Size = new System.Drawing.Size(196, 21);
            this.comboBoxHighlightCorpses.TabIndex = 4;
            // 
            // groupBoxDialogue
            // 
            this.groupBoxDialogue.BackColor = System.Drawing.Color.White;
            this.groupBoxDialogue.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxDialogue.BorderWidth = 1;
            this.groupBoxDialogue.Controls.Add(this.sliderConversationHistorySize);
            this.groupBoxDialogue.Controls.Add(this.numConversationHistorySize);
            this.groupBoxDialogue.Controls.Add(this.labelConversationHistorySize);
            this.groupBoxDialogue.Controls.Add(this.checkBoxDialogueHistory);
            this.groupBoxDialogue.Controls.Add(this.checkBoxDialogueSubtitles);
            this.groupBoxDialogue.Controls.Add(this.checkBoxGeneralSubtitles);
            this.groupBoxDialogue.Location = new System.Drawing.Point(9, 230);
            this.groupBoxDialogue.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxDialogue.Name = "groupBoxDialogue";
            this.groupBoxDialogue.Size = new System.Drawing.Size(400, 143);
            this.groupBoxDialogue.TabIndex = 3;
            this.groupBoxDialogue.TabStop = false;
            this.groupBoxDialogue.Text = "Dialogue";
            this.groupBoxDialogue.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxDialogue.TitleBorderMargin = 6;
            this.groupBoxDialogue.TitleBorderPadding = 4;
            this.groupBoxDialogue.TitleForeColor = System.Drawing.Color.Black;
            // 
            // sliderConversationHistorySize
            // 
            this.sliderConversationHistorySize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderConversationHistorySize.BackColor = System.Drawing.Color.Transparent;
            this.sliderConversationHistorySize.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderConversationHistorySize.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderConversationHistorySize.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderConversationHistorySize.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderConversationHistorySize.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderConversationHistorySize.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderConversationHistorySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderConversationHistorySize.ForeColor = System.Drawing.Color.White;
            this.sliderConversationHistorySize.LargeChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderConversationHistorySize.Location = new System.Drawing.Point(6, 112);
            this.sliderConversationHistorySize.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.sliderConversationHistorySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderConversationHistorySize.Name = "sliderConversationHistorySize";
            this.sliderConversationHistorySize.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderConversationHistorySize.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderConversationHistorySize.ShowDivisionsText = false;
            this.sliderConversationHistorySize.ShowSmallScale = false;
            this.sliderConversationHistorySize.Size = new System.Drawing.Size(308, 20);
            this.sliderConversationHistorySize.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderConversationHistorySize.TabIndex = 10;
            this.sliderConversationHistorySize.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderConversationHistorySize.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderConversationHistorySize.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderConversationHistorySize.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderConversationHistorySize.TickAdd = 0F;
            this.sliderConversationHistorySize.TickColor = System.Drawing.Color.White;
            this.sliderConversationHistorySize.TickDivide = 0F;
            this.sliderConversationHistorySize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderConversationHistorySize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numConversationHistorySize
            // 
            this.numConversationHistorySize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numConversationHistorySize.Location = new System.Drawing.Point(320, 112);
            this.numConversationHistorySize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numConversationHistorySize.Name = "numConversationHistorySize";
            this.numConversationHistorySize.Size = new System.Drawing.Size(74, 20);
            this.numConversationHistorySize.TabIndex = 11;
            this.numConversationHistorySize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelConversationHistorySize
            // 
            this.labelConversationHistorySize.AutoSize = true;
            this.labelConversationHistorySize.Location = new System.Drawing.Point(7, 96);
            this.labelConversationHistorySize.Name = "labelConversationHistorySize";
            this.labelConversationHistorySize.Size = new System.Drawing.Size(207, 13);
            this.labelConversationHistorySize.TabIndex = 9;
            this.labelConversationHistorySize.Text = "Conversation history size (number of rows):";
            // 
            // checkBoxDialogueHistory
            // 
            this.checkBoxDialogueHistory.AutoSize = true;
            this.checkBoxDialogueHistory.Location = new System.Drawing.Point(10, 65);
            this.checkBoxDialogueHistory.Name = "checkBoxDialogueHistory";
            this.checkBoxDialogueHistory.Size = new System.Drawing.Size(129, 17);
            this.checkBoxDialogueHistory.TabIndex = 8;
            this.checkBoxDialogueHistory.Text = "Show dialogue history";
            this.checkBoxDialogueHistory.UseVisualStyleBackColor = true;
            // 
            // checkBoxDialogueSubtitles
            // 
            this.checkBoxDialogueSubtitles.AutoSize = true;
            this.checkBoxDialogueSubtitles.Location = new System.Drawing.Point(10, 42);
            this.checkBoxDialogueSubtitles.Name = "checkBoxDialogueSubtitles";
            this.checkBoxDialogueSubtitles.Size = new System.Drawing.Size(137, 17);
            this.checkBoxDialogueSubtitles.TabIndex = 7;
            this.checkBoxDialogueSubtitles.Text = "Show dialogue subtitles";
            this.checkBoxDialogueSubtitles.UseVisualStyleBackColor = true;
            // 
            // checkBoxGeneralSubtitles
            // 
            this.checkBoxGeneralSubtitles.AutoSize = true;
            this.checkBoxGeneralSubtitles.Location = new System.Drawing.Point(10, 19);
            this.checkBoxGeneralSubtitles.Name = "checkBoxGeneralSubtitles";
            this.checkBoxGeneralSubtitles.Size = new System.Drawing.Size(132, 17);
            this.checkBoxGeneralSubtitles.TabIndex = 6;
            this.checkBoxGeneralSubtitles.Text = "Show general subtitles";
            this.checkBoxGeneralSubtitles.UseVisualStyleBackColor = true;
            // 
            // groupBoxHUD
            // 
            this.groupBoxHUD.BackColor = System.Drawing.Color.White;
            this.groupBoxHUD.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxHUD.BorderWidth = 1;
            this.groupBoxHUD.Controls.Add(this.groupBoxFloatingQuestMarkers);
            this.groupBoxHUD.Controls.Add(this.checkBoxShowOtherPlayersNames);
            this.groupBoxHUD.Controls.Add(this.checkBoxShowPublicTeamNotifications);
            this.groupBoxHUD.Controls.Add(this.checkBoxEnablePowerArmorHUD);
            this.groupBoxHUD.Controls.Add(this.checkBoxShowDamageNumbers);
            this.groupBoxHUD.Controls.Add(this.checkBoxShowCrosshair);
            this.groupBoxHUD.Controls.Add(this.checkBoxShowCompass);
            this.groupBoxHUD.Controls.Add(this.labelShowActiveEffectsOnHUD);
            this.groupBoxHUD.Controls.Add(this.labelHUDOpacity);
            this.groupBoxHUD.Controls.Add(this.comboBoxShowActiveEffectsOnHUD);
            this.groupBoxHUD.Controls.Add(this.sliderHUDOpacity);
            this.groupBoxHUD.Controls.Add(this.numHUDOpacity);
            this.groupBoxHUD.Location = new System.Drawing.Point(9, 382);
            this.groupBoxHUD.Name = "groupBoxHUD";
            this.groupBoxHUD.Size = new System.Drawing.Size(400, 387);
            this.groupBoxHUD.TabIndex = 4;
            this.groupBoxHUD.TabStop = false;
            this.groupBoxHUD.Text = "HUD";
            this.groupBoxHUD.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxHUD.TitleBorderMargin = 6;
            this.groupBoxHUD.TitleBorderPadding = 4;
            this.groupBoxHUD.TitleForeColor = System.Drawing.Color.Black;
            // 
            // groupBoxFloatingQuestMarkers
            // 
            this.groupBoxFloatingQuestMarkers.BackColor = System.Drawing.Color.White;
            this.groupBoxFloatingQuestMarkers.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxFloatingQuestMarkers.BorderWidth = 1;
            this.groupBoxFloatingQuestMarkers.Controls.Add(this.checkBoxShowFloatingQuestMarkers);
            this.groupBoxFloatingQuestMarkers.Controls.Add(this.sliderFloatingQuestMarkersDistance);
            this.groupBoxFloatingQuestMarkers.Controls.Add(this.checkBoxShowFloatingQuestText);
            this.groupBoxFloatingQuestMarkers.Controls.Add(this.labelFloatingQuestMarkersDistance);
            this.groupBoxFloatingQuestMarkers.Controls.Add(this.numFloatingQuestMarkersDistance);
            this.groupBoxFloatingQuestMarkers.Location = new System.Drawing.Point(6, 111);
            this.groupBoxFloatingQuestMarkers.Name = "groupBoxFloatingQuestMarkers";
            this.groupBoxFloatingQuestMarkers.Size = new System.Drawing.Size(388, 127);
            this.groupBoxFloatingQuestMarkers.TabIndex = 17;
            this.groupBoxFloatingQuestMarkers.TabStop = false;
            this.groupBoxFloatingQuestMarkers.Text = "Floating quest markers on HUD";
            this.groupBoxFloatingQuestMarkers.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxFloatingQuestMarkers.TitleBorderMargin = 6;
            this.groupBoxFloatingQuestMarkers.TitleBorderPadding = 4;
            this.groupBoxFloatingQuestMarkers.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxShowFloatingQuestMarkers
            // 
            this.checkBoxShowFloatingQuestMarkers.AutoSize = true;
            this.checkBoxShowFloatingQuestMarkers.Location = new System.Drawing.Point(9, 69);
            this.checkBoxShowFloatingQuestMarkers.Name = "checkBoxShowFloatingQuestMarkers";
            this.checkBoxShowFloatingQuestMarkers.Size = new System.Drawing.Size(159, 17);
            this.checkBoxShowFloatingQuestMarkers.TabIndex = 21;
            this.checkBoxShowFloatingQuestMarkers.Text = "Show floating quest markers\r\n";
            this.checkBoxShowFloatingQuestMarkers.UseVisualStyleBackColor = true;
            // 
            // sliderFloatingQuestMarkersDistance
            // 
            this.sliderFloatingQuestMarkersDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderFloatingQuestMarkersDistance.BackColor = System.Drawing.Color.Transparent;
            this.sliderFloatingQuestMarkersDistance.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderFloatingQuestMarkersDistance.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderFloatingQuestMarkersDistance.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderFloatingQuestMarkersDistance.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFloatingQuestMarkersDistance.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderFloatingQuestMarkersDistance.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderFloatingQuestMarkersDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderFloatingQuestMarkersDistance.ForeColor = System.Drawing.Color.White;
            this.sliderFloatingQuestMarkersDistance.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.Location = new System.Drawing.Point(9, 38);
            this.sliderFloatingQuestMarkersDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.Name = "sliderFloatingQuestMarkersDistance";
            this.sliderFloatingQuestMarkersDistance.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.ShowDivisionsText = false;
            this.sliderFloatingQuestMarkersDistance.ShowSmallScale = false;
            this.sliderFloatingQuestMarkersDistance.Size = new System.Drawing.Size(293, 20);
            this.sliderFloatingQuestMarkersDistance.SmallChange = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderFloatingQuestMarkersDistance.TabIndex = 19;
            this.sliderFloatingQuestMarkersDistance.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFloatingQuestMarkersDistance.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFloatingQuestMarkersDistance.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderFloatingQuestMarkersDistance.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderFloatingQuestMarkersDistance.TickAdd = 0F;
            this.sliderFloatingQuestMarkersDistance.TickColor = System.Drawing.Color.White;
            this.sliderFloatingQuestMarkersDistance.TickDivide = 0F;
            this.sliderFloatingQuestMarkersDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderFloatingQuestMarkersDistance.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // checkBoxShowFloatingQuestText
            // 
            this.checkBoxShowFloatingQuestText.AutoSize = true;
            this.checkBoxShowFloatingQuestText.Location = new System.Drawing.Point(9, 92);
            this.checkBoxShowFloatingQuestText.Name = "checkBoxShowFloatingQuestText";
            this.checkBoxShowFloatingQuestText.Size = new System.Drawing.Size(139, 17);
            this.checkBoxShowFloatingQuestText.TabIndex = 22;
            this.checkBoxShowFloatingQuestText.Text = "Show floating quest text";
            this.checkBoxShowFloatingQuestText.UseVisualStyleBackColor = true;
            // 
            // labelFloatingQuestMarkersDistance
            // 
            this.labelFloatingQuestMarkersDistance.AutoSize = true;
            this.labelFloatingQuestMarkersDistance.Location = new System.Drawing.Point(6, 22);
            this.labelFloatingQuestMarkersDistance.Name = "labelFloatingQuestMarkersDistance";
            this.labelFloatingQuestMarkersDistance.Size = new System.Drawing.Size(75, 13);
            this.labelFloatingQuestMarkersDistance.TabIndex = 18;
            this.labelFloatingQuestMarkersDistance.Text = "Draw distance";
            // 
            // numFloatingQuestMarkersDistance
            // 
            this.numFloatingQuestMarkersDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFloatingQuestMarkersDistance.DecimalPlaces = 1;
            this.numFloatingQuestMarkersDistance.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFloatingQuestMarkersDistance.Location = new System.Drawing.Point(308, 38);
            this.numFloatingQuestMarkersDistance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numFloatingQuestMarkersDistance.Name = "numFloatingQuestMarkersDistance";
            this.numFloatingQuestMarkersDistance.Size = new System.Drawing.Size(74, 20);
            this.numFloatingQuestMarkersDistance.TabIndex = 20;
            this.numFloatingQuestMarkersDistance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // checkBoxShowOtherPlayersNames
            // 
            this.checkBoxShowOtherPlayersNames.AutoSize = true;
            this.checkBoxShowOtherPlayersNames.Location = new System.Drawing.Point(10, 339);
            this.checkBoxShowOtherPlayersNames.Name = "checkBoxShowOtherPlayersNames";
            this.checkBoxShowOtherPlayersNames.Size = new System.Drawing.Size(152, 17);
            this.checkBoxShowOtherPlayersNames.TabIndex = 27;
            this.checkBoxShowOtherPlayersNames.Text = "Show other players\' names";
            this.checkBoxShowOtherPlayersNames.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowPublicTeamNotifications
            // 
            this.checkBoxShowPublicTeamNotifications.AutoSize = true;
            this.checkBoxShowPublicTeamNotifications.Location = new System.Drawing.Point(10, 293);
            this.checkBoxShowPublicTeamNotifications.Name = "checkBoxShowPublicTeamNotifications";
            this.checkBoxShowPublicTeamNotifications.Size = new System.Drawing.Size(175, 17);
            this.checkBoxShowPublicTeamNotifications.TabIndex = 25;
            this.checkBoxShowPublicTeamNotifications.Text = "Enable public team notifications\r\n";
            this.checkBoxShowPublicTeamNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnablePowerArmorHUD
            // 
            this.checkBoxEnablePowerArmorHUD.AutoSize = true;
            this.checkBoxEnablePowerArmorHUD.Location = new System.Drawing.Point(10, 270);
            this.checkBoxEnablePowerArmorHUD.Name = "checkBoxEnablePowerArmorHUD";
            this.checkBoxEnablePowerArmorHUD.Size = new System.Drawing.Size(149, 17);
            this.checkBoxEnablePowerArmorHUD.TabIndex = 24;
            this.checkBoxEnablePowerArmorHUD.Text = "Enable Power Armor HUD";
            this.checkBoxEnablePowerArmorHUD.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowDamageNumbers
            // 
            this.checkBoxShowDamageNumbers.AutoSize = true;
            this.checkBoxShowDamageNumbers.Location = new System.Drawing.Point(10, 316);
            this.checkBoxShowDamageNumbers.Name = "checkBoxShowDamageNumbers";
            this.checkBoxShowDamageNumbers.Size = new System.Drawing.Size(174, 17);
            this.checkBoxShowDamageNumbers.TabIndex = 26;
            this.checkBoxShowDamageNumbers.Text = "Show floating damage numbers";
            this.checkBoxShowDamageNumbers.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCrosshair
            // 
            this.checkBoxShowCrosshair.AutoSize = true;
            this.checkBoxShowCrosshair.Location = new System.Drawing.Point(10, 247);
            this.checkBoxShowCrosshair.Name = "checkBoxShowCrosshair";
            this.checkBoxShowCrosshair.Size = new System.Drawing.Size(98, 17);
            this.checkBoxShowCrosshair.TabIndex = 23;
            this.checkBoxShowCrosshair.Text = "Show crosshair";
            this.checkBoxShowCrosshair.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCompass
            // 
            this.checkBoxShowCompass.AutoSize = true;
            this.checkBoxShowCompass.Location = new System.Drawing.Point(10, 362);
            this.checkBoxShowCompass.Name = "checkBoxShowCompass";
            this.checkBoxShowCompass.Size = new System.Drawing.Size(98, 17);
            this.checkBoxShowCompass.TabIndex = 28;
            this.checkBoxShowCompass.Text = "Show compass";
            this.checkBoxShowCompass.UseVisualStyleBackColor = true;
            // 
            // labelShowActiveEffectsOnHUD
            // 
            this.labelShowActiveEffectsOnHUD.AutoSize = true;
            this.labelShowActiveEffectsOnHUD.Location = new System.Drawing.Point(6, 75);
            this.labelShowActiveEffectsOnHUD.Name = "labelShowActiveEffectsOnHUD";
            this.labelShowActiveEffectsOnHUD.Size = new System.Drawing.Size(146, 13);
            this.labelShowActiveEffectsOnHUD.TabIndex = 15;
            this.labelShowActiveEffectsOnHUD.Text = "Show active effects on HUD:";
            // 
            // labelHUDOpacity
            // 
            this.labelHUDOpacity.AutoSize = true;
            this.labelHUDOpacity.Location = new System.Drawing.Point(6, 20);
            this.labelHUDOpacity.Name = "labelHUDOpacity";
            this.labelHUDOpacity.Size = new System.Drawing.Size(70, 13);
            this.labelHUDOpacity.TabIndex = 12;
            this.labelHUDOpacity.Text = "HUD Opacity";
            // 
            // comboBoxShowActiveEffectsOnHUD
            // 
            this.comboBoxShowActiveEffectsOnHUD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowActiveEffectsOnHUD.FormattingEnabled = true;
            this.comboBoxShowActiveEffectsOnHUD.Location = new System.Drawing.Point(198, 72);
            this.comboBoxShowActiveEffectsOnHUD.Name = "comboBoxShowActiveEffectsOnHUD";
            this.comboBoxShowActiveEffectsOnHUD.Size = new System.Drawing.Size(196, 21);
            this.comboBoxShowActiveEffectsOnHUD.TabIndex = 16;
            // 
            // sliderHUDOpacity
            // 
            this.sliderHUDOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderHUDOpacity.BackColor = System.Drawing.Color.Transparent;
            this.sliderHUDOpacity.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderHUDOpacity.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderHUDOpacity.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderHUDOpacity.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderHUDOpacity.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderHUDOpacity.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderHUDOpacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderHUDOpacity.ForeColor = System.Drawing.Color.White;
            this.sliderHUDOpacity.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderHUDOpacity.Location = new System.Drawing.Point(6, 36);
            this.sliderHUDOpacity.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderHUDOpacity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderHUDOpacity.Name = "sliderHUDOpacity";
            this.sliderHUDOpacity.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderHUDOpacity.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderHUDOpacity.ShowDivisionsText = false;
            this.sliderHUDOpacity.ShowSmallScale = false;
            this.sliderHUDOpacity.Size = new System.Drawing.Size(308, 20);
            this.sliderHUDOpacity.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderHUDOpacity.TabIndex = 13;
            this.sliderHUDOpacity.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderHUDOpacity.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderHUDOpacity.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderHUDOpacity.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderHUDOpacity.TickAdd = 0F;
            this.sliderHUDOpacity.TickColor = System.Drawing.Color.White;
            this.sliderHUDOpacity.TickDivide = 0F;
            this.sliderHUDOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderHUDOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numHUDOpacity
            // 
            this.numHUDOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numHUDOpacity.DecimalPlaces = 2;
            this.numHUDOpacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHUDOpacity.Location = new System.Drawing.Point(320, 36);
            this.numHUDOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHUDOpacity.Name = "numHUDOpacity";
            this.numHUDOpacity.Size = new System.Drawing.Size(74, 20);
            this.numHUDOpacity.TabIndex = 14;
            this.numHUDOpacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxLoading
            // 
            this.groupBoxLoading.BackColor = System.Drawing.Color.White;
            this.groupBoxLoading.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxLoading.BorderWidth = 1;
            this.groupBoxLoading.Controls.Add(this.checkBoxFasterFadeIn);
            this.groupBoxLoading.Location = new System.Drawing.Point(9, 89);
            this.groupBoxLoading.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxLoading.Name = "groupBoxLoading";
            this.groupBoxLoading.Size = new System.Drawing.Size(400, 46);
            this.groupBoxLoading.TabIndex = 1;
            this.groupBoxLoading.TabStop = false;
            this.groupBoxLoading.Text = "Loading";
            this.groupBoxLoading.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxLoading.TitleBorderMargin = 6;
            this.groupBoxLoading.TitleBorderPadding = 4;
            this.groupBoxLoading.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxFasterFadeIn
            // 
            this.checkBoxFasterFadeIn.AutoSize = true;
            this.checkBoxFasterFadeIn.Location = new System.Drawing.Point(10, 19);
            this.checkBoxFasterFadeIn.Name = "checkBoxFasterFadeIn";
            this.checkBoxFasterFadeIn.Size = new System.Drawing.Size(168, 17);
            this.checkBoxFasterFadeIn.TabIndex = 2;
            this.checkBoxFasterFadeIn.Text = "Speed up fade in after loading";
            this.checkBoxFasterFadeIn.UseVisualStyleBackColor = true;
            // 
            // groupBoxQuests
            // 
            this.groupBoxQuests.BackColor = System.Drawing.Color.White;
            this.groupBoxQuests.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxQuests.BorderWidth = 1;
            this.groupBoxQuests.Controls.Add(this.checkBoxEnableQuestAutoTrackDaily);
            this.groupBoxQuests.Controls.Add(this.checkBoxEnableQuestAutoTrackEvent);
            this.groupBoxQuests.Controls.Add(this.checkBoxEnableQuestAutoTrackMisc);
            this.groupBoxQuests.Controls.Add(this.checkBoxEnableQuestAutoTrackSide);
            this.groupBoxQuests.Controls.Add(this.checkBoxEnableQuestAutoTrackMain);
            this.groupBoxQuests.Location = new System.Drawing.Point(9, 778);
            this.groupBoxQuests.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxQuests.Name = "groupBoxQuests";
            this.groupBoxQuests.Size = new System.Drawing.Size(400, 142);
            this.groupBoxQuests.TabIndex = 5;
            this.groupBoxQuests.TabStop = false;
            this.groupBoxQuests.Text = "Quests";
            this.groupBoxQuests.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxQuests.TitleBorderMargin = 6;
            this.groupBoxQuests.TitleBorderPadding = 4;
            this.groupBoxQuests.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxEnableQuestAutoTrackDaily
            // 
            this.checkBoxEnableQuestAutoTrackDaily.AutoSize = true;
            this.checkBoxEnableQuestAutoTrackDaily.Location = new System.Drawing.Point(10, 111);
            this.checkBoxEnableQuestAutoTrackDaily.Name = "checkBoxEnableQuestAutoTrackDaily";
            this.checkBoxEnableQuestAutoTrackDaily.Size = new System.Drawing.Size(182, 17);
            this.checkBoxEnableQuestAutoTrackDaily.TabIndex = 33;
            this.checkBoxEnableQuestAutoTrackDaily.Text = "Daily Quests Active when started";
            this.checkBoxEnableQuestAutoTrackDaily.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableQuestAutoTrackEvent
            // 
            this.checkBoxEnableQuestAutoTrackEvent.AutoSize = true;
            this.checkBoxEnableQuestAutoTrackEvent.Location = new System.Drawing.Point(10, 88);
            this.checkBoxEnableQuestAutoTrackEvent.Name = "checkBoxEnableQuestAutoTrackEvent";
            this.checkBoxEnableQuestAutoTrackEvent.Size = new System.Drawing.Size(187, 17);
            this.checkBoxEnableQuestAutoTrackEvent.TabIndex = 32;
            this.checkBoxEnableQuestAutoTrackEvent.Text = "Event Quests Active when started";
            this.checkBoxEnableQuestAutoTrackEvent.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableQuestAutoTrackMisc
            // 
            this.checkBoxEnableQuestAutoTrackMisc.AutoSize = true;
            this.checkBoxEnableQuestAutoTrackMisc.Location = new System.Drawing.Point(10, 65);
            this.checkBoxEnableQuestAutoTrackMisc.Name = "checkBoxEnableQuestAutoTrackMisc";
            this.checkBoxEnableQuestAutoTrackMisc.Size = new System.Drawing.Size(226, 17);
            this.checkBoxEnableQuestAutoTrackMisc.TabIndex = 31;
            this.checkBoxEnableQuestAutoTrackMisc.Text = "Miscellaneous Quests Active when started";
            this.checkBoxEnableQuestAutoTrackMisc.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableQuestAutoTrackSide
            // 
            this.checkBoxEnableQuestAutoTrackSide.AutoSize = true;
            this.checkBoxEnableQuestAutoTrackSide.Location = new System.Drawing.Point(10, 42);
            this.checkBoxEnableQuestAutoTrackSide.Name = "checkBoxEnableQuestAutoTrackSide";
            this.checkBoxEnableQuestAutoTrackSide.Size = new System.Drawing.Size(180, 17);
            this.checkBoxEnableQuestAutoTrackSide.TabIndex = 30;
            this.checkBoxEnableQuestAutoTrackSide.Text = "Side Quests Active when started";
            this.checkBoxEnableQuestAutoTrackSide.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableQuestAutoTrackMain
            // 
            this.checkBoxEnableQuestAutoTrackMain.AutoSize = true;
            this.checkBoxEnableQuestAutoTrackMain.Location = new System.Drawing.Point(10, 19);
            this.checkBoxEnableQuestAutoTrackMain.Name = "checkBoxEnableQuestAutoTrackMain";
            this.checkBoxEnableQuestAutoTrackMain.Size = new System.Drawing.Size(182, 17);
            this.checkBoxEnableQuestAutoTrackMain.TabIndex = 29;
            this.checkBoxEnableQuestAutoTrackMain.Text = "Main Quests Active when started";
            this.checkBoxEnableQuestAutoTrackMain.UseVisualStyleBackColor = true;
            // 
            // groupBoxMainMenu
            // 
            this.groupBoxMainMenu.BackColor = System.Drawing.Color.White;
            this.groupBoxMainMenu.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxMainMenu.BorderWidth = 1;
            this.groupBoxMainMenu.Controls.Add(this.checkBoxSkipSplash);
            this.groupBoxMainMenu.Controls.Add(this.checkBoxSkipIntroVideos);
            this.groupBoxMainMenu.Location = new System.Drawing.Point(9, 9);
            this.groupBoxMainMenu.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxMainMenu.Name = "groupBoxMainMenu";
            this.groupBoxMainMenu.Size = new System.Drawing.Size(400, 68);
            this.groupBoxMainMenu.TabIndex = 0;
            this.groupBoxMainMenu.TabStop = false;
            this.groupBoxMainMenu.Text = "Main Menu";
            this.groupBoxMainMenu.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxMainMenu.TitleBorderMargin = 6;
            this.groupBoxMainMenu.TitleBorderPadding = 4;
            this.groupBoxMainMenu.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxSkipSplash
            // 
            this.checkBoxSkipSplash.AutoSize = true;
            this.checkBoxSkipSplash.Location = new System.Drawing.Point(10, 42);
            this.checkBoxSkipSplash.Name = "checkBoxSkipSplash";
            this.checkBoxSkipSplash.Size = new System.Drawing.Size(215, 17);
            this.checkBoxSkipSplash.TabIndex = 1;
            this.checkBoxSkipSplash.Text = "Skip splash screen with news on startup";
            this.checkBoxSkipSplash.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipIntroVideos
            // 
            this.checkBoxSkipIntroVideos.AutoSize = true;
            this.checkBoxSkipIntroVideos.Location = new System.Drawing.Point(10, 19);
            this.checkBoxSkipIntroVideos.Name = "checkBoxSkipIntroVideos";
            this.checkBoxSkipIntroVideos.Size = new System.Drawing.Size(104, 17);
            this.checkBoxSkipIntroVideos.TabIndex = 0;
            this.checkBoxSkipIntroVideos.Text = "Skip intro videos";
            this.checkBoxSkipIntroVideos.UseVisualStyleBackColor = true;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.AutoScroll = true;
            this.tabPageVideo.BackColor = System.Drawing.Color.White;
            this.tabPageVideo.Controls.Add(this.groupBoxGraphics);
            this.tabPageVideo.Controls.Add(this.groupBoxDisplay);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 25);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(654, 473);
            this.tabPageVideo.TabIndex = 1;
            this.tabPageVideo.Text = "Video";
            // 
            // groupBoxGraphics
            // 
            this.groupBoxGraphics.BackColor = System.Drawing.Color.White;
            this.groupBoxGraphics.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxGraphics.BorderWidth = 1;
            this.groupBoxGraphics.Controls.Add(this.groupBoxDOF);
            this.groupBoxGraphics.Controls.Add(this.labelSelectedQualityPreset);
            this.groupBoxGraphics.Controls.Add(this.buttonSelectOverallQualityPreset);
            this.groupBoxGraphics.Controls.Add(this.labelOverallQualityPreset);
            this.groupBoxGraphics.Controls.Add(this.groupBoxTextures);
            this.groupBoxGraphics.Controls.Add(this.groupBoxGraphicEffects);
            this.groupBoxGraphics.Controls.Add(this.groupBoxTAASharpening);
            this.groupBoxGraphics.Controls.Add(this.labelAntiAliasing);
            this.groupBoxGraphics.Controls.Add(this.groupBoxGrass);
            this.groupBoxGraphics.Controls.Add(this.comboBoxAntiAliasing);
            this.groupBoxGraphics.Controls.Add(this.groupBoxLOD);
            this.groupBoxGraphics.Controls.Add(this.checkBoxVSync);
            this.groupBoxGraphics.Controls.Add(this.groupBoxLighting);
            this.groupBoxGraphics.Controls.Add(this.labelAnisotropicFiltering);
            this.groupBoxGraphics.Controls.Add(this.groupBoxShadows);
            this.groupBoxGraphics.Controls.Add(this.comboBoxAnisotropicFiltering);
            this.groupBoxGraphics.Controls.Add(this.groupBoxWater);
            this.groupBoxGraphics.Controls.Add(this.groupBoxPostProcessing);
            this.groupBoxGraphics.Location = new System.Drawing.Point(9, 206);
            this.groupBoxGraphics.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxGraphics.Name = "groupBoxGraphics";
            this.groupBoxGraphics.Size = new System.Drawing.Size(400, 1320);
            this.groupBoxGraphics.TabIndex = 1;
            this.groupBoxGraphics.TabStop = false;
            this.groupBoxGraphics.Text = "Graphics";
            this.groupBoxGraphics.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxGraphics.TitleBorderMargin = 6;
            this.groupBoxGraphics.TitleBorderPadding = 4;
            this.groupBoxGraphics.TitleForeColor = System.Drawing.Color.Black;
            // 
            // groupBoxDOF
            // 
            this.groupBoxDOF.BackColor = System.Drawing.Color.White;
            this.groupBoxDOF.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxDOF.BorderWidth = 1;
            this.groupBoxDOF.Controls.Add(this.numDOFStrength);
            this.groupBoxDOF.Controls.Add(this.labelDOFStrength);
            this.groupBoxDOF.Controls.Add(this.checkBoxDepthOfField);
            this.groupBoxDOF.Controls.Add(this.sliderDOFStrength);
            this.groupBoxDOF.Location = new System.Drawing.Point(9, 505);
            this.groupBoxDOF.Name = "groupBoxDOF";
            this.groupBoxDOF.Size = new System.Drawing.Size(381, 93);
            this.groupBoxDOF.TabIndex = 2;
            this.groupBoxDOF.TabStop = false;
            this.groupBoxDOF.Text = "Depth of Field";
            this.groupBoxDOF.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxDOF.TitleBorderMargin = 6;
            this.groupBoxDOF.TitleBorderPadding = 4;
            this.groupBoxDOF.TitleForeColor = System.Drawing.Color.Black;
            // 
            // numDOFStrength
            // 
            this.numDOFStrength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDOFStrength.DecimalPlaces = 1;
            this.numDOFStrength.Location = new System.Drawing.Point(297, 61);
            this.numDOFStrength.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numDOFStrength.Name = "numDOFStrength";
            this.numDOFStrength.Size = new System.Drawing.Size(74, 20);
            this.numDOFStrength.TabIndex = 9;
            // 
            // labelDOFStrength
            // 
            this.labelDOFStrength.AutoSize = true;
            this.labelDOFStrength.Location = new System.Drawing.Point(7, 42);
            this.labelDOFStrength.Name = "labelDOFStrength";
            this.labelDOFStrength.Size = new System.Drawing.Size(47, 13);
            this.labelDOFStrength.TabIndex = 7;
            this.labelDOFStrength.Text = "Strength";
            // 
            // checkBoxDepthOfField
            // 
            this.checkBoxDepthOfField.AutoSize = true;
            this.checkBoxDepthOfField.Checked = true;
            this.checkBoxDepthOfField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDepthOfField.Location = new System.Drawing.Point(10, 19);
            this.checkBoxDepthOfField.Name = "checkBoxDepthOfField";
            this.checkBoxDepthOfField.Size = new System.Drawing.Size(128, 17);
            this.checkBoxDepthOfField.TabIndex = 0;
            this.checkBoxDepthOfField.Text = "Enable Depth of Field";
            this.checkBoxDepthOfField.UseVisualStyleBackColor = true;
            // 
            // sliderDOFStrength
            // 
            this.sliderDOFStrength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderDOFStrength.BackColor = System.Drawing.Color.Transparent;
            this.sliderDOFStrength.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderDOFStrength.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderDOFStrength.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderDOFStrength.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderDOFStrength.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderDOFStrength.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderDOFStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderDOFStrength.ForeColor = System.Drawing.Color.White;
            this.sliderDOFStrength.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderDOFStrength.Location = new System.Drawing.Point(10, 61);
            this.sliderDOFStrength.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderDOFStrength.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderDOFStrength.Name = "sliderDOFStrength";
            this.sliderDOFStrength.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderDOFStrength.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderDOFStrength.ShowDivisionsText = false;
            this.sliderDOFStrength.ShowSmallScale = false;
            this.sliderDOFStrength.Size = new System.Drawing.Size(281, 20);
            this.sliderDOFStrength.SmallChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderDOFStrength.TabIndex = 8;
            this.sliderDOFStrength.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderDOFStrength.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderDOFStrength.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderDOFStrength.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderDOFStrength.TickAdd = 0F;
            this.sliderDOFStrength.TickColor = System.Drawing.Color.White;
            this.sliderDOFStrength.TickDivide = 0F;
            this.sliderDOFStrength.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderDOFStrength.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelSelectedQualityPreset
            // 
            this.labelSelectedQualityPreset.AutoSize = true;
            this.labelSelectedQualityPreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedQualityPreset.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSelectedQualityPreset.Location = new System.Drawing.Point(164, 49);
            this.labelSelectedQualityPreset.Name = "labelSelectedQualityPreset";
            this.labelSelectedQualityPreset.Size = new System.Drawing.Size(125, 13);
            this.labelSelectedQualityPreset.TabIndex = 22;
            this.labelSelectedQualityPreset.Text = "Current preset: Unknown";
            // 
            // buttonSelectOverallQualityPreset
            // 
            this.buttonSelectOverallQualityPreset.ContextMenuStrip = this.contextMenuStripOverallQualityPresets;
            this.buttonSelectOverallQualityPreset.Location = new System.Drawing.Point(164, 21);
            this.buttonSelectOverallQualityPreset.Name = "buttonSelectOverallQualityPreset";
            this.buttonSelectOverallQualityPreset.Size = new System.Drawing.Size(227, 23);
            this.buttonSelectOverallQualityPreset.TabIndex = 21;
            this.buttonSelectOverallQualityPreset.Text = "Select quality preset";
            this.buttonSelectOverallQualityPreset.UseVisualStyleBackColor = true;
            this.buttonSelectOverallQualityPreset.Click += new System.EventHandler(this.buttonSelectOverallQualityPreset_Click);
            // 
            // contextMenuStripOverallQualityPresets
            // 
            this.contextMenuStripOverallQualityPresets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.lowToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.highToolStripMenuItem,
            this.ultraToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelToolStripMenuItem});
            this.contextMenuStripOverallQualityPresets.Name = "contextMenuStripOverallQualityPresets";
            this.contextMenuStripOverallQualityPresets.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripOverallQualityPresets.Size = new System.Drawing.Size(161, 148);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "Graphics presets";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.lowToolStripMenuItem.Text = "Low";
            this.lowToolStripMenuItem.Click += new System.EventHandler(this.lowToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.highToolStripMenuItem.Text = "High";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // ultraToolStripMenuItem
            // 
            this.ultraToolStripMenuItem.Name = "ultraToolStripMenuItem";
            this.ultraToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ultraToolStripMenuItem.Text = "Ultra";
            this.ultraToolStripMenuItem.Click += new System.EventHandler(this.ultraToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // labelOverallQualityPreset
            // 
            this.labelOverallQualityPreset.AutoSize = true;
            this.labelOverallQualityPreset.Location = new System.Drawing.Point(6, 26);
            this.labelOverallQualityPreset.Name = "labelOverallQualityPreset";
            this.labelOverallQualityPreset.Size = new System.Drawing.Size(76, 13);
            this.labelOverallQualityPreset.TabIndex = 20;
            this.labelOverallQualityPreset.Text = "Overall quality:";
            // 
            // groupBoxTextures
            // 
            this.groupBoxTextures.BackColor = System.Drawing.Color.White;
            this.groupBoxTextures.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxTextures.BorderWidth = 1;
            this.groupBoxTextures.Controls.Add(this.comboBoxTextureQuality);
            this.groupBoxTextures.Controls.Add(this.labelTextureQuality);
            this.groupBoxTextures.Location = new System.Drawing.Point(9, 183);
            this.groupBoxTextures.Name = "groupBoxTextures";
            this.groupBoxTextures.Size = new System.Drawing.Size(381, 55);
            this.groupBoxTextures.TabIndex = 19;
            this.groupBoxTextures.TabStop = false;
            this.groupBoxTextures.Text = "Textures";
            this.groupBoxTextures.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxTextures.TitleBorderMargin = 6;
            this.groupBoxTextures.TitleBorderPadding = 4;
            this.groupBoxTextures.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxTextureQuality
            // 
            this.comboBoxTextureQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTextureQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTextureQuality.FormattingEnabled = true;
            this.comboBoxTextureQuality.Location = new System.Drawing.Point(156, 19);
            this.comboBoxTextureQuality.Name = "comboBoxTextureQuality";
            this.comboBoxTextureQuality.Size = new System.Drawing.Size(219, 21);
            this.comboBoxTextureQuality.TabIndex = 3;
            // 
            // labelTextureQuality
            // 
            this.labelTextureQuality.AutoSize = true;
            this.labelTextureQuality.Location = new System.Drawing.Point(7, 22);
            this.labelTextureQuality.Name = "labelTextureQuality";
            this.labelTextureQuality.Size = new System.Drawing.Size(111, 13);
            this.labelTextureQuality.TabIndex = 2;
            this.labelTextureQuality.Text = "Texture quality preset:";
            // 
            // groupBoxGraphicEffects
            // 
            this.groupBoxGraphicEffects.BackColor = System.Drawing.Color.White;
            this.groupBoxGraphicEffects.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxGraphicEffects.BorderWidth = 1;
            this.groupBoxGraphicEffects.Controls.Add(this.checkBoxBloodSplatter);
            this.groupBoxGraphicEffects.Controls.Add(this.checkBoxDisableGore);
            this.groupBoxGraphicEffects.Location = new System.Drawing.Point(218, 604);
            this.groupBoxGraphicEffects.Name = "groupBoxGraphicEffects";
            this.groupBoxGraphicEffects.Size = new System.Drawing.Size(172, 149);
            this.groupBoxGraphicEffects.TabIndex = 11;
            this.groupBoxGraphicEffects.TabStop = false;
            this.groupBoxGraphicEffects.Text = "Effects";
            this.groupBoxGraphicEffects.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxGraphicEffects.TitleBorderMargin = 6;
            this.groupBoxGraphicEffects.TitleBorderPadding = 4;
            this.groupBoxGraphicEffects.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxBloodSplatter
            // 
            this.checkBoxBloodSplatter.AutoSize = true;
            this.checkBoxBloodSplatter.Checked = true;
            this.checkBoxBloodSplatter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBloodSplatter.Location = new System.Drawing.Point(9, 42);
            this.checkBoxBloodSplatter.Name = "checkBoxBloodSplatter";
            this.checkBoxBloodSplatter.Size = new System.Drawing.Size(90, 17);
            this.checkBoxBloodSplatter.TabIndex = 1;
            this.checkBoxBloodSplatter.Text = "Blood splatter";
            this.checkBoxBloodSplatter.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisableGore
            // 
            this.checkBoxDisableGore.AutoSize = true;
            this.checkBoxDisableGore.Location = new System.Drawing.Point(9, 19);
            this.checkBoxDisableGore.Name = "checkBoxDisableGore";
            this.checkBoxDisableGore.Size = new System.Drawing.Size(85, 17);
            this.checkBoxDisableGore.TabIndex = 0;
            this.checkBoxDisableGore.Text = "Disable gore";
            this.checkBoxDisableGore.UseVisualStyleBackColor = true;
            // 
            // groupBoxTAASharpening
            // 
            this.groupBoxTAASharpening.BackColor = System.Drawing.Color.White;
            this.groupBoxTAASharpening.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxTAASharpening.BorderWidth = 1;
            this.groupBoxTAASharpening.Controls.Add(this.sliderTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.labelTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.numTAAPostSharpen);
            this.groupBoxTAASharpening.Controls.Add(this.sliderTAAPostOverlay);
            this.groupBoxTAASharpening.Controls.Add(this.numTAAPostOverlay);
            this.groupBoxTAASharpening.Controls.Add(this.labelTAAPostOverlay);
            this.groupBoxTAASharpening.Location = new System.Drawing.Point(9, 1187);
            this.groupBoxTAASharpening.Name = "groupBoxTAASharpening";
            this.groupBoxTAASharpening.Size = new System.Drawing.Size(381, 123);
            this.groupBoxTAASharpening.TabIndex = 18;
            this.groupBoxTAASharpening.TabStop = false;
            this.groupBoxTAASharpening.Text = "TAA Sharpening";
            this.groupBoxTAASharpening.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxTAASharpening.TitleBorderMargin = 6;
            this.groupBoxTAASharpening.TitleBorderPadding = 4;
            this.groupBoxTAASharpening.TitleForeColor = System.Drawing.Color.Black;
            // 
            // sliderTAAPostSharpen
            // 
            this.sliderTAAPostSharpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderTAAPostSharpen.BackColor = System.Drawing.Color.Transparent;
            this.sliderTAAPostSharpen.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderTAAPostSharpen.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderTAAPostSharpen.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderTAAPostSharpen.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostSharpen.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderTAAPostSharpen.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderTAAPostSharpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderTAAPostSharpen.ForeColor = System.Drawing.Color.White;
            this.sliderTAAPostSharpen.LargeChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.Location = new System.Drawing.Point(9, 93);
            this.sliderTAAPostSharpen.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.Name = "sliderTAAPostSharpen";
            this.sliderTAAPostSharpen.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.ShowDivisionsText = false;
            this.sliderTAAPostSharpen.ShowSmallScale = false;
            this.sliderTAAPostSharpen.Size = new System.Drawing.Size(286, 20);
            this.sliderTAAPostSharpen.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderTAAPostSharpen.TabIndex = 4;
            this.sliderTAAPostSharpen.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostSharpen.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostSharpen.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderTAAPostSharpen.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderTAAPostSharpen.TickAdd = 0F;
            this.sliderTAAPostSharpen.TickColor = System.Drawing.Color.White;
            this.sliderTAAPostSharpen.TickDivide = 0F;
            this.sliderTAAPostSharpen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderTAAPostSharpen.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelTAAPostSharpen
            // 
            this.labelTAAPostSharpen.AutoSize = true;
            this.labelTAAPostSharpen.Location = new System.Drawing.Point(6, 77);
            this.labelTAAPostSharpen.Name = "labelTAAPostSharpen";
            this.labelTAAPostSharpen.Size = new System.Drawing.Size(69, 13);
            this.labelTAAPostSharpen.TabIndex = 3;
            this.labelTAAPostSharpen.Text = "Post sharpen";
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
            this.numTAAPostSharpen.Location = new System.Drawing.Point(301, 93);
            this.numTAAPostSharpen.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numTAAPostSharpen.Name = "numTAAPostSharpen";
            this.numTAAPostSharpen.Size = new System.Drawing.Size(74, 20);
            this.numTAAPostSharpen.TabIndex = 5;
            this.numTAAPostSharpen.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // sliderTAAPostOverlay
            // 
            this.sliderTAAPostOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderTAAPostOverlay.BackColor = System.Drawing.Color.Transparent;
            this.sliderTAAPostOverlay.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderTAAPostOverlay.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderTAAPostOverlay.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderTAAPostOverlay.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostOverlay.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderTAAPostOverlay.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderTAAPostOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderTAAPostOverlay.ForeColor = System.Drawing.Color.White;
            this.sliderTAAPostOverlay.LargeChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.Location = new System.Drawing.Point(6, 41);
            this.sliderTAAPostOverlay.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.Name = "sliderTAAPostOverlay";
            this.sliderTAAPostOverlay.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.ShowDivisionsText = false;
            this.sliderTAAPostOverlay.ShowSmallScale = false;
            this.sliderTAAPostOverlay.Size = new System.Drawing.Size(289, 20);
            this.sliderTAAPostOverlay.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderTAAPostOverlay.TabIndex = 1;
            this.sliderTAAPostOverlay.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostOverlay.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderTAAPostOverlay.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderTAAPostOverlay.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderTAAPostOverlay.TickAdd = 0F;
            this.sliderTAAPostOverlay.TickColor = System.Drawing.Color.White;
            this.sliderTAAPostOverlay.TickDivide = 0F;
            this.sliderTAAPostOverlay.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderTAAPostOverlay.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
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
            this.numTAAPostOverlay.Location = new System.Drawing.Point(301, 41);
            this.numTAAPostOverlay.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numTAAPostOverlay.Name = "numTAAPostOverlay";
            this.numTAAPostOverlay.Size = new System.Drawing.Size(74, 20);
            this.numTAAPostOverlay.TabIndex = 2;
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
            this.labelTAAPostOverlay.TabIndex = 0;
            this.labelTAAPostOverlay.Text = "Post overlay";
            // 
            // labelAntiAliasing
            // 
            this.labelAntiAliasing.AutoSize = true;
            this.labelAntiAliasing.Location = new System.Drawing.Point(6, 88);
            this.labelAntiAliasing.Name = "labelAntiAliasing";
            this.labelAntiAliasing.Size = new System.Drawing.Size(67, 13);
            this.labelAntiAliasing.TabIndex = 0;
            this.labelAntiAliasing.Text = "Anti-Aliasing:";
            // 
            // groupBoxGrass
            // 
            this.groupBoxGrass.BackColor = System.Drawing.Color.White;
            this.groupBoxGrass.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxGrass.BorderWidth = 1;
            this.groupBoxGrass.Controls.Add(this.sliderGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.numGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.labelGrassFadeDistance);
            this.groupBoxGrass.Controls.Add(this.checkBoxGrass);
            this.groupBoxGrass.Location = new System.Drawing.Point(9, 1076);
            this.groupBoxGrass.Name = "groupBoxGrass";
            this.groupBoxGrass.Size = new System.Drawing.Size(381, 99);
            this.groupBoxGrass.TabIndex = 17;
            this.groupBoxGrass.TabStop = false;
            this.groupBoxGrass.Text = "Grass";
            this.groupBoxGrass.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxGrass.TitleBorderMargin = 6;
            this.groupBoxGrass.TitleBorderPadding = 4;
            this.groupBoxGrass.TitleForeColor = System.Drawing.Color.Black;
            // 
            // sliderGrassFadeDistance
            // 
            this.sliderGrassFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGrassFadeDistance.BackColor = System.Drawing.Color.Transparent;
            this.sliderGrassFadeDistance.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderGrassFadeDistance.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderGrassFadeDistance.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderGrassFadeDistance.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGrassFadeDistance.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderGrassFadeDistance.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderGrassFadeDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderGrassFadeDistance.ForeColor = System.Drawing.Color.White;
            this.sliderGrassFadeDistance.LargeChange = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.Location = new System.Drawing.Point(6, 68);
            this.sliderGrassFadeDistance.Maximum = new decimal(new int[] {
            14000,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.Name = "sliderGrassFadeDistance";
            this.sliderGrassFadeDistance.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.ShowDivisionsText = false;
            this.sliderGrassFadeDistance.ShowSmallScale = false;
            this.sliderGrassFadeDistance.Size = new System.Drawing.Size(289, 20);
            this.sliderGrassFadeDistance.SmallChange = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sliderGrassFadeDistance.TabIndex = 2;
            this.sliderGrassFadeDistance.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGrassFadeDistance.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGrassFadeDistance.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderGrassFadeDistance.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderGrassFadeDistance.TickAdd = 0F;
            this.sliderGrassFadeDistance.TickColor = System.Drawing.Color.White;
            this.sliderGrassFadeDistance.TickDivide = 0F;
            this.sliderGrassFadeDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderGrassFadeDistance.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // numGrassFadeDistance
            // 
            this.numGrassFadeDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGrassFadeDistance.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGrassFadeDistance.Location = new System.Drawing.Point(301, 68);
            this.numGrassFadeDistance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numGrassFadeDistance.Name = "numGrassFadeDistance";
            this.numGrassFadeDistance.Size = new System.Drawing.Size(74, 20);
            this.numGrassFadeDistance.TabIndex = 3;
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
            this.labelGrassFadeDistance.TabIndex = 1;
            this.labelGrassFadeDistance.Text = "Fade distance";
            // 
            // checkBoxGrass
            // 
            this.checkBoxGrass.AutoSize = true;
            this.checkBoxGrass.Checked = true;
            this.checkBoxGrass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrass.Location = new System.Drawing.Point(9, 21);
            this.checkBoxGrass.Name = "checkBoxGrass";
            this.checkBoxGrass.Size = new System.Drawing.Size(87, 17);
            this.checkBoxGrass.TabIndex = 0;
            this.checkBoxGrass.Text = "Enable grass";
            this.checkBoxGrass.UseVisualStyleBackColor = true;
            // 
            // comboBoxAntiAliasing
            // 
            this.comboBoxAntiAliasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAntiAliasing.FormattingEnabled = true;
            this.comboBoxAntiAliasing.Location = new System.Drawing.Point(165, 85);
            this.comboBoxAntiAliasing.Name = "comboBoxAntiAliasing";
            this.comboBoxAntiAliasing.Size = new System.Drawing.Size(225, 21);
            this.comboBoxAntiAliasing.TabIndex = 1;
            // 
            // groupBoxLOD
            // 
            this.groupBoxLOD.BackColor = System.Drawing.Color.White;
            this.groupBoxLOD.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxLOD.BorderWidth = 1;
            this.groupBoxLOD.Controls.Add(this.sliderLODActors);
            this.groupBoxLOD.Controls.Add(this.labelLODFadeDistance);
            this.groupBoxLOD.Controls.Add(this.sliderLODItems);
            this.groupBoxLOD.Controls.Add(this.numLODActors);
            this.groupBoxLOD.Controls.Add(this.numLODItems);
            this.groupBoxLOD.Controls.Add(this.sliderLODObjects);
            this.groupBoxLOD.Controls.Add(this.numLODObjects);
            this.groupBoxLOD.Controls.Add(this.labelLODActors);
            this.groupBoxLOD.Controls.Add(this.labelLODItems);
            this.groupBoxLOD.Controls.Add(this.labelLODObjects);
            this.groupBoxLOD.Location = new System.Drawing.Point(9, 928);
            this.groupBoxLOD.Name = "groupBoxLOD";
            this.groupBoxLOD.Size = new System.Drawing.Size(381, 136);
            this.groupBoxLOD.TabIndex = 16;
            this.groupBoxLOD.TabStop = false;
            this.groupBoxLOD.Text = "LOD";
            this.groupBoxLOD.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxLOD.TitleBorderMargin = 6;
            this.groupBoxLOD.TitleBorderPadding = 4;
            this.groupBoxLOD.TitleForeColor = System.Drawing.Color.Black;
            // 
            // sliderLODActors
            // 
            this.sliderLODActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODActors.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODActors.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderLODActors.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderLODActors.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderLODActors.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODActors.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderLODActors.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderLODActors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderLODActors.ForeColor = System.Drawing.Color.White;
            this.sliderLODActors.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODActors.Location = new System.Drawing.Point(92, 104);
            this.sliderLODActors.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sliderLODActors.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderLODActors.Name = "sliderLODActors";
            this.sliderLODActors.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODActors.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODActors.ShowDivisionsText = false;
            this.sliderLODActors.ShowSmallScale = false;
            this.sliderLODActors.Size = new System.Drawing.Size(224, 20);
            this.sliderLODActors.SmallChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODActors.TabIndex = 8;
            this.sliderLODActors.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODActors.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODActors.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderLODActors.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderLODActors.TickAdd = 0F;
            this.sliderLODActors.TickColor = System.Drawing.Color.White;
            this.sliderLODActors.TickDivide = 0F;
            this.sliderLODActors.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderLODActors.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // labelLODFadeDistance
            // 
            this.labelLODFadeDistance.AutoSize = true;
            this.labelLODFadeDistance.Location = new System.Drawing.Point(7, 20);
            this.labelLODFadeDistance.Name = "labelLODFadeDistance";
            this.labelLODFadeDistance.Size = new System.Drawing.Size(74, 13);
            this.labelLODFadeDistance.TabIndex = 0;
            this.labelLODFadeDistance.Text = "Fade distance";
            // 
            // sliderLODItems
            // 
            this.sliderLODItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODItems.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODItems.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderLODItems.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderLODItems.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderLODItems.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODItems.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderLODItems.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderLODItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderLODItems.ForeColor = System.Drawing.Color.White;
            this.sliderLODItems.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODItems.Location = new System.Drawing.Point(92, 75);
            this.sliderLODItems.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sliderLODItems.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderLODItems.Name = "sliderLODItems";
            this.sliderLODItems.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODItems.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODItems.ShowDivisionsText = false;
            this.sliderLODItems.ShowSmallScale = false;
            this.sliderLODItems.Size = new System.Drawing.Size(224, 20);
            this.sliderLODItems.SmallChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODItems.TabIndex = 5;
            this.sliderLODItems.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODItems.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODItems.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderLODItems.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderLODItems.TickAdd = 0F;
            this.sliderLODItems.TickColor = System.Drawing.Color.White;
            this.sliderLODItems.TickDivide = 0F;
            this.sliderLODItems.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderLODItems.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numLODActors
            // 
            this.numLODActors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLODActors.DecimalPlaces = 1;
            this.numLODActors.Location = new System.Drawing.Point(322, 104);
            this.numLODActors.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numLODActors.Name = "numLODActors";
            this.numLODActors.Size = new System.Drawing.Size(53, 20);
            this.numLODActors.TabIndex = 9;
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
            this.numLODItems.Location = new System.Drawing.Point(322, 75);
            this.numLODItems.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numLODItems.Name = "numLODItems";
            this.numLODItems.Size = new System.Drawing.Size(53, 20);
            this.numLODItems.TabIndex = 6;
            this.numLODItems.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // sliderLODObjects
            // 
            this.sliderLODObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderLODObjects.BackColor = System.Drawing.Color.Transparent;
            this.sliderLODObjects.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderLODObjects.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderLODObjects.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderLODObjects.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODObjects.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderLODObjects.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderLODObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderLODObjects.ForeColor = System.Drawing.Color.White;
            this.sliderLODObjects.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODObjects.Location = new System.Drawing.Point(92, 45);
            this.sliderLODObjects.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sliderLODObjects.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderLODObjects.Name = "sliderLODObjects";
            this.sliderLODObjects.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderLODObjects.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODObjects.ShowDivisionsText = false;
            this.sliderLODObjects.ShowSmallScale = false;
            this.sliderLODObjects.Size = new System.Drawing.Size(224, 20);
            this.sliderLODObjects.SmallChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderLODObjects.TabIndex = 2;
            this.sliderLODObjects.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODObjects.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderLODObjects.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderLODObjects.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderLODObjects.TickAdd = 0F;
            this.sliderLODObjects.TickColor = System.Drawing.Color.White;
            this.sliderLODObjects.TickDivide = 0F;
            this.sliderLODObjects.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderLODObjects.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numLODObjects
            // 
            this.numLODObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLODObjects.DecimalPlaces = 1;
            this.numLODObjects.Location = new System.Drawing.Point(322, 45);
            this.numLODObjects.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numLODObjects.Name = "numLODObjects";
            this.numLODObjects.Size = new System.Drawing.Size(53, 20);
            this.numLODObjects.TabIndex = 3;
            this.numLODObjects.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // labelLODActors
            // 
            this.labelLODActors.AutoSize = true;
            this.labelLODActors.Location = new System.Drawing.Point(19, 107);
            this.labelLODActors.Name = "labelLODActors";
            this.labelLODActors.Size = new System.Drawing.Size(37, 13);
            this.labelLODActors.TabIndex = 7;
            this.labelLODActors.Text = "Actors";
            // 
            // labelLODItems
            // 
            this.labelLODItems.AutoSize = true;
            this.labelLODItems.Location = new System.Drawing.Point(19, 78);
            this.labelLODItems.Name = "labelLODItems";
            this.labelLODItems.Size = new System.Drawing.Size(32, 13);
            this.labelLODItems.TabIndex = 4;
            this.labelLODItems.Text = "Items";
            // 
            // labelLODObjects
            // 
            this.labelLODObjects.AutoSize = true;
            this.labelLODObjects.Location = new System.Drawing.Point(19, 48);
            this.labelLODObjects.Name = "labelLODObjects";
            this.labelLODObjects.Size = new System.Drawing.Size(43, 13);
            this.labelLODObjects.TabIndex = 1;
            this.labelLODObjects.Text = "Objects";
            // 
            // checkBoxVSync
            // 
            this.checkBoxVSync.AutoSize = true;
            this.checkBoxVSync.Checked = true;
            this.checkBoxVSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVSync.Location = new System.Drawing.Point(9, 150);
            this.checkBoxVSync.Name = "checkBoxVSync";
            this.checkBoxVSync.Size = new System.Drawing.Size(214, 17);
            this.checkBoxVSync.TabIndex = 4;
            this.checkBoxVSync.Text = "Vertical synchronization (frame rate cap)";
            this.checkBoxVSync.UseVisualStyleBackColor = true;
            // 
            // groupBoxLighting
            // 
            this.groupBoxLighting.BackColor = System.Drawing.Color.White;
            this.groupBoxLighting.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxLighting.BorderWidth = 1;
            this.groupBoxLighting.Controls.Add(this.comboBoxGodrayQuality);
            this.groupBoxLighting.Controls.Add(this.labelGodrayQuality);
            this.groupBoxLighting.Controls.Add(this.checkBoxGodrays);
            this.groupBoxLighting.Location = new System.Drawing.Point(9, 429);
            this.groupBoxLighting.Name = "groupBoxLighting";
            this.groupBoxLighting.Size = new System.Drawing.Size(381, 70);
            this.groupBoxLighting.TabIndex = 14;
            this.groupBoxLighting.TabStop = false;
            this.groupBoxLighting.Text = "Lighting";
            this.groupBoxLighting.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxLighting.TitleBorderMargin = 6;
            this.groupBoxLighting.TitleBorderPadding = 4;
            this.groupBoxLighting.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxGodrayQuality
            // 
            this.comboBoxGodrayQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGodrayQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGodrayQuality.FormattingEnabled = true;
            this.comboBoxGodrayQuality.Location = new System.Drawing.Point(156, 41);
            this.comboBoxGodrayQuality.Name = "comboBoxGodrayQuality";
            this.comboBoxGodrayQuality.Size = new System.Drawing.Size(219, 21);
            this.comboBoxGodrayQuality.TabIndex = 5;
            // 
            // labelGodrayQuality
            // 
            this.labelGodrayQuality.AutoSize = true;
            this.labelGodrayQuality.Location = new System.Drawing.Point(7, 44);
            this.labelGodrayQuality.Name = "labelGodrayQuality";
            this.labelGodrayQuality.Size = new System.Drawing.Size(134, 13);
            this.labelGodrayQuality.TabIndex = 4;
            this.labelGodrayQuality.Text = "Volumetric Lighting Quality:";
            // 
            // checkBoxGodrays
            // 
            this.checkBoxGodrays.AutoSize = true;
            this.checkBoxGodrays.Checked = true;
            this.checkBoxGodrays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGodrays.Location = new System.Drawing.Point(10, 19);
            this.checkBoxGodrays.Name = "checkBoxGodrays";
            this.checkBoxGodrays.Size = new System.Drawing.Size(151, 17);
            this.checkBoxGodrays.TabIndex = 0;
            this.checkBoxGodrays.Text = "Enable Volumetric Lighting";
            this.checkBoxGodrays.UseVisualStyleBackColor = true;
            // 
            // labelAnisotropicFiltering
            // 
            this.labelAnisotropicFiltering.AutoSize = true;
            this.labelAnisotropicFiltering.Location = new System.Drawing.Point(6, 115);
            this.labelAnisotropicFiltering.Name = "labelAnisotropicFiltering";
            this.labelAnisotropicFiltering.Size = new System.Drawing.Size(84, 13);
            this.labelAnisotropicFiltering.TabIndex = 2;
            this.labelAnisotropicFiltering.Text = "Anisotropic filter:";
            // 
            // groupBoxShadows
            // 
            this.groupBoxShadows.BackColor = System.Drawing.Color.White;
            this.groupBoxShadows.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxShadows.BorderWidth = 1;
            this.groupBoxShadows.Controls.Add(this.comboBoxShadowQuality);
            this.groupBoxShadows.Controls.Add(this.labelShadowQuality);
            this.groupBoxShadows.Controls.Add(this.sliderShadowDistance);
            this.groupBoxShadows.Controls.Add(this.comboBoxShadowBlurriness);
            this.groupBoxShadows.Controls.Add(this.labelShadowBlurriness);
            this.groupBoxShadows.Controls.Add(this.numShadowDistance);
            this.groupBoxShadows.Controls.Add(this.labelShadowDistance);
            this.groupBoxShadows.Controls.Add(this.comboBoxShadowTextureResolution);
            this.groupBoxShadows.Controls.Add(this.labelShadowTextureResolution);
            this.groupBoxShadows.Location = new System.Drawing.Point(9, 760);
            this.groupBoxShadows.Name = "groupBoxShadows";
            this.groupBoxShadows.Size = new System.Drawing.Size(381, 159);
            this.groupBoxShadows.TabIndex = 15;
            this.groupBoxShadows.TabStop = false;
            this.groupBoxShadows.Text = "Shadows";
            this.groupBoxShadows.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxShadows.TitleBorderMargin = 6;
            this.groupBoxShadows.TitleBorderPadding = 4;
            this.groupBoxShadows.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxShadowQuality
            // 
            this.comboBoxShadowQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShadowQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShadowQuality.FormattingEnabled = true;
            this.comboBoxShadowQuality.Location = new System.Drawing.Point(156, 21);
            this.comboBoxShadowQuality.Name = "comboBoxShadowQuality";
            this.comboBoxShadowQuality.Size = new System.Drawing.Size(219, 21);
            this.comboBoxShadowQuality.TabIndex = 8;
            // 
            // labelShadowQuality
            // 
            this.labelShadowQuality.AutoSize = true;
            this.labelShadowQuality.Location = new System.Drawing.Point(7, 24);
            this.labelShadowQuality.Name = "labelShadowQuality";
            this.labelShadowQuality.Size = new System.Drawing.Size(114, 13);
            this.labelShadowQuality.TabIndex = 7;
            this.labelShadowQuality.Text = "Shadow quality preset:";
            // 
            // sliderShadowDistance
            // 
            this.sliderShadowDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderShadowDistance.BackColor = System.Drawing.Color.Transparent;
            this.sliderShadowDistance.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderShadowDistance.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderShadowDistance.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderShadowDistance.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderShadowDistance.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderShadowDistance.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderShadowDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderShadowDistance.ForeColor = System.Drawing.Color.White;
            this.sliderShadowDistance.LargeChange = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sliderShadowDistance.Location = new System.Drawing.Point(10, 127);
            this.sliderShadowDistance.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.sliderShadowDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderShadowDistance.Name = "sliderShadowDistance";
            this.sliderShadowDistance.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderShadowDistance.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderShadowDistance.ShowDivisionsText = false;
            this.sliderShadowDistance.ShowSmallScale = false;
            this.sliderShadowDistance.Size = new System.Drawing.Size(285, 20);
            this.sliderShadowDistance.SmallChange = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sliderShadowDistance.TabIndex = 5;
            this.sliderShadowDistance.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderShadowDistance.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderShadowDistance.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderShadowDistance.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderShadowDistance.TickAdd = 0F;
            this.sliderShadowDistance.TickColor = System.Drawing.Color.White;
            this.sliderShadowDistance.TickDivide = 0F;
            this.sliderShadowDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderShadowDistance.Value = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            // 
            // comboBoxShadowBlurriness
            // 
            this.comboBoxShadowBlurriness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShadowBlurriness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShadowBlurriness.FormattingEnabled = true;
            this.comboBoxShadowBlurriness.Location = new System.Drawing.Point(156, 75);
            this.comboBoxShadowBlurriness.Name = "comboBoxShadowBlurriness";
            this.comboBoxShadowBlurriness.Size = new System.Drawing.Size(219, 21);
            this.comboBoxShadowBlurriness.TabIndex = 2;
            // 
            // labelShadowBlurriness
            // 
            this.labelShadowBlurriness.AutoSize = true;
            this.labelShadowBlurriness.Location = new System.Drawing.Point(7, 78);
            this.labelShadowBlurriness.Name = "labelShadowBlurriness";
            this.labelShadowBlurriness.Size = new System.Drawing.Size(55, 13);
            this.labelShadowBlurriness.TabIndex = 2;
            this.labelShadowBlurriness.Text = "Blurriness:";
            // 
            // numShadowDistance
            // 
            this.numShadowDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numShadowDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numShadowDistance.Location = new System.Drawing.Point(301, 127);
            this.numShadowDistance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numShadowDistance.Name = "numShadowDistance";
            this.numShadowDistance.Size = new System.Drawing.Size(74, 20);
            this.numShadowDistance.TabIndex = 6;
            this.numShadowDistance.Value = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            // 
            // labelShadowDistance
            // 
            this.labelShadowDistance.AutoSize = true;
            this.labelShadowDistance.Location = new System.Drawing.Point(7, 107);
            this.labelShadowDistance.Name = "labelShadowDistance";
            this.labelShadowDistance.Size = new System.Drawing.Size(74, 13);
            this.labelShadowDistance.TabIndex = 4;
            this.labelShadowDistance.Text = "Fade distance";
            // 
            // comboBoxShadowTextureResolution
            // 
            this.comboBoxShadowTextureResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShadowTextureResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShadowTextureResolution.FormattingEnabled = true;
            this.comboBoxShadowTextureResolution.Location = new System.Drawing.Point(156, 48);
            this.comboBoxShadowTextureResolution.Name = "comboBoxShadowTextureResolution";
            this.comboBoxShadowTextureResolution.Size = new System.Drawing.Size(219, 21);
            this.comboBoxShadowTextureResolution.TabIndex = 1;
            // 
            // labelShadowTextureResolution
            // 
            this.labelShadowTextureResolution.AutoSize = true;
            this.labelShadowTextureResolution.Location = new System.Drawing.Point(7, 51);
            this.labelShadowTextureResolution.Name = "labelShadowTextureResolution";
            this.labelShadowTextureResolution.Size = new System.Drawing.Size(117, 13);
            this.labelShadowTextureResolution.TabIndex = 0;
            this.labelShadowTextureResolution.Text = "Texture map resolution:";
            // 
            // comboBoxAnisotropicFiltering
            // 
            this.comboBoxAnisotropicFiltering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnisotropicFiltering.FormattingEnabled = true;
            this.comboBoxAnisotropicFiltering.Location = new System.Drawing.Point(165, 112);
            this.comboBoxAnisotropicFiltering.Name = "comboBoxAnisotropicFiltering";
            this.comboBoxAnisotropicFiltering.Size = new System.Drawing.Size(225, 21);
            this.comboBoxAnisotropicFiltering.TabIndex = 3;
            // 
            // groupBoxWater
            // 
            this.groupBoxWater.BackColor = System.Drawing.Color.White;
            this.groupBoxWater.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxWater.BorderWidth = 1;
            this.groupBoxWater.Controls.Add(this.comboBoxWaterShadowFilter);
            this.groupBoxWater.Controls.Add(this.labelWaterShadowFilter);
            this.groupBoxWater.Controls.Add(this.checkBoxWaterFixSSRGlitch);
            this.groupBoxWater.Controls.Add(this.checkBoxWaterHiRes);
            this.groupBoxWater.Controls.Add(this.checkBoxWaterRefractions);
            this.groupBoxWater.Controls.Add(this.checkBoxWaterReflections);
            this.groupBoxWater.Controls.Add(this.checkBoxWaterDisplacement);
            this.groupBoxWater.Location = new System.Drawing.Point(9, 244);
            this.groupBoxWater.Name = "groupBoxWater";
            this.groupBoxWater.Size = new System.Drawing.Size(381, 179);
            this.groupBoxWater.TabIndex = 12;
            this.groupBoxWater.TabStop = false;
            this.groupBoxWater.Text = "Water";
            this.groupBoxWater.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxWater.TitleBorderMargin = 6;
            this.groupBoxWater.TitleBorderPadding = 4;
            this.groupBoxWater.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxWaterShadowFilter
            // 
            this.comboBoxWaterShadowFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWaterShadowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWaterShadowFilter.FormattingEnabled = true;
            this.comboBoxWaterShadowFilter.Location = new System.Drawing.Point(156, 111);
            this.comboBoxWaterShadowFilter.Name = "comboBoxWaterShadowFilter";
            this.comboBoxWaterShadowFilter.Size = new System.Drawing.Size(219, 21);
            this.comboBoxWaterShadowFilter.TabIndex = 6;
            // 
            // labelWaterShadowFilter
            // 
            this.labelWaterShadowFilter.AutoSize = true;
            this.labelWaterShadowFilter.Location = new System.Drawing.Point(7, 114);
            this.labelWaterShadowFilter.Name = "labelWaterShadowFilter";
            this.labelWaterShadowFilter.Size = new System.Drawing.Size(71, 13);
            this.labelWaterShadowFilter.TabIndex = 5;
            this.labelWaterShadowFilter.Text = "Shadow filter:";
            // 
            // checkBoxWaterFixSSRGlitch
            // 
            this.checkBoxWaterFixSSRGlitch.AutoSize = true;
            this.checkBoxWaterFixSSRGlitch.Checked = true;
            this.checkBoxWaterFixSSRGlitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterFixSSRGlitch.Location = new System.Drawing.Point(9, 150);
            this.checkBoxWaterFixSSRGlitch.Name = "checkBoxWaterFixSSRGlitch";
            this.checkBoxWaterFixSSRGlitch.Size = new System.Drawing.Size(139, 17);
            this.checkBoxWaterFixSSRGlitch.TabIndex = 4;
            this.checkBoxWaterFixSSRGlitch.Text = "Fix black/invisible water";
            this.checkBoxWaterFixSSRGlitch.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterHiRes
            // 
            this.checkBoxWaterHiRes.AutoSize = true;
            this.checkBoxWaterHiRes.Checked = true;
            this.checkBoxWaterHiRes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterHiRes.Location = new System.Drawing.Point(9, 88);
            this.checkBoxWaterHiRes.Name = "checkBoxWaterHiRes";
            this.checkBoxWaterHiRes.Size = new System.Drawing.Size(123, 17);
            this.checkBoxWaterHiRes.TabIndex = 3;
            this.checkBoxWaterHiRes.Text = "Use High Resolution";
            this.checkBoxWaterHiRes.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterRefractions
            // 
            this.checkBoxWaterRefractions.AutoSize = true;
            this.checkBoxWaterRefractions.Checked = true;
            this.checkBoxWaterRefractions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterRefractions.Location = new System.Drawing.Point(9, 65);
            this.checkBoxWaterRefractions.Name = "checkBoxWaterRefractions";
            this.checkBoxWaterRefractions.Size = new System.Drawing.Size(80, 17);
            this.checkBoxWaterRefractions.TabIndex = 2;
            this.checkBoxWaterRefractions.Text = "Refractions";
            this.checkBoxWaterRefractions.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterReflections
            // 
            this.checkBoxWaterReflections.AutoSize = true;
            this.checkBoxWaterReflections.Checked = true;
            this.checkBoxWaterReflections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterReflections.Location = new System.Drawing.Point(9, 42);
            this.checkBoxWaterReflections.Name = "checkBoxWaterReflections";
            this.checkBoxWaterReflections.Size = new System.Drawing.Size(79, 17);
            this.checkBoxWaterReflections.TabIndex = 1;
            this.checkBoxWaterReflections.Text = "Reflections";
            this.checkBoxWaterReflections.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterDisplacement
            // 
            this.checkBoxWaterDisplacement.AutoSize = true;
            this.checkBoxWaterDisplacement.Checked = true;
            this.checkBoxWaterDisplacement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWaterDisplacement.Location = new System.Drawing.Point(9, 19);
            this.checkBoxWaterDisplacement.Name = "checkBoxWaterDisplacement";
            this.checkBoxWaterDisplacement.Size = new System.Drawing.Size(90, 17);
            this.checkBoxWaterDisplacement.TabIndex = 0;
            this.checkBoxWaterDisplacement.Text = "Displacement";
            this.checkBoxWaterDisplacement.UseVisualStyleBackColor = true;
            // 
            // groupBoxPostProcessing
            // 
            this.groupBoxPostProcessing.BackColor = System.Drawing.Color.White;
            this.groupBoxPostProcessing.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxPostProcessing.BorderWidth = 1;
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxSSReflections);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxAmbientOcclusion);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxMotionBlur);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxRadialBlur);
            this.groupBoxPostProcessing.Controls.Add(this.checkBoxLensFlare);
            this.groupBoxPostProcessing.Location = new System.Drawing.Point(9, 604);
            this.groupBoxPostProcessing.Name = "groupBoxPostProcessing";
            this.groupBoxPostProcessing.Size = new System.Drawing.Size(204, 149);
            this.groupBoxPostProcessing.TabIndex = 10;
            this.groupBoxPostProcessing.TabStop = false;
            this.groupBoxPostProcessing.Text = "Post-processing";
            this.groupBoxPostProcessing.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxPostProcessing.TitleBorderMargin = 6;
            this.groupBoxPostProcessing.TitleBorderPadding = 4;
            this.groupBoxPostProcessing.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxSSReflections
            // 
            this.checkBoxSSReflections.AutoSize = true;
            this.checkBoxSSReflections.Checked = true;
            this.checkBoxSSReflections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSSReflections.Location = new System.Drawing.Point(10, 111);
            this.checkBoxSSReflections.Name = "checkBoxSSReflections";
            this.checkBoxSSReflections.Size = new System.Drawing.Size(110, 17);
            this.checkBoxSSReflections.TabIndex = 6;
            this.checkBoxSSReflections.Text = "Reflections (SSR)";
            this.checkBoxSSReflections.UseVisualStyleBackColor = true;
            // 
            // checkBoxAmbientOcclusion
            // 
            this.checkBoxAmbientOcclusion.AutoSize = true;
            this.checkBoxAmbientOcclusion.Checked = true;
            this.checkBoxAmbientOcclusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAmbientOcclusion.Location = new System.Drawing.Point(10, 88);
            this.checkBoxAmbientOcclusion.Name = "checkBoxAmbientOcclusion";
            this.checkBoxAmbientOcclusion.Size = new System.Drawing.Size(152, 17);
            this.checkBoxAmbientOcclusion.TabIndex = 4;
            this.checkBoxAmbientOcclusion.Text = "Ambient Occlusion (SSAO)";
            this.checkBoxAmbientOcclusion.UseVisualStyleBackColor = true;
            // 
            // checkBoxMotionBlur
            // 
            this.checkBoxMotionBlur.AutoSize = true;
            this.checkBoxMotionBlur.Checked = true;
            this.checkBoxMotionBlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMotionBlur.Location = new System.Drawing.Point(10, 19);
            this.checkBoxMotionBlur.Name = "checkBoxMotionBlur";
            this.checkBoxMotionBlur.Size = new System.Drawing.Size(79, 17);
            this.checkBoxMotionBlur.TabIndex = 1;
            this.checkBoxMotionBlur.Text = "Motion Blur";
            this.checkBoxMotionBlur.UseVisualStyleBackColor = true;
            // 
            // checkBoxRadialBlur
            // 
            this.checkBoxRadialBlur.AutoSize = true;
            this.checkBoxRadialBlur.Checked = true;
            this.checkBoxRadialBlur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRadialBlur.Location = new System.Drawing.Point(10, 42);
            this.checkBoxRadialBlur.Name = "checkBoxRadialBlur";
            this.checkBoxRadialBlur.Size = new System.Drawing.Size(77, 17);
            this.checkBoxRadialBlur.TabIndex = 2;
            this.checkBoxRadialBlur.Text = "Radial Blur";
            this.checkBoxRadialBlur.UseVisualStyleBackColor = true;
            // 
            // checkBoxLensFlare
            // 
            this.checkBoxLensFlare.AutoSize = true;
            this.checkBoxLensFlare.Checked = true;
            this.checkBoxLensFlare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLensFlare.Location = new System.Drawing.Point(10, 65);
            this.checkBoxLensFlare.Name = "checkBoxLensFlare";
            this.checkBoxLensFlare.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLensFlare.TabIndex = 3;
            this.checkBoxLensFlare.Text = "Lens Flare";
            this.checkBoxLensFlare.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.BackColor = System.Drawing.Color.White;
            this.groupBoxDisplay.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxDisplay.BorderWidth = 1;
            this.groupBoxDisplay.Controls.Add(this.comboBoxDisplayMode);
            this.groupBoxDisplay.Controls.Add(this.checkBoxFixHUDFor5_4and4_3);
            this.groupBoxDisplay.Controls.Add(this.comboBoxResolution);
            this.groupBoxDisplay.Controls.Add(this.buttonDetectResolution);
            this.groupBoxDisplay.Controls.Add(this.labelCustomResolution);
            this.groupBoxDisplay.Controls.Add(this.labelResolution);
            this.groupBoxDisplay.Controls.Add(this.checkBoxTopMostWindow);
            this.groupBoxDisplay.Controls.Add(this.numCustomResW);
            this.groupBoxDisplay.Controls.Add(this.numCustomResH);
            this.groupBoxDisplay.Controls.Add(this.labelDisplayMode);
            this.groupBoxDisplay.Controls.Add(this.labelCustomResolutionSpacer);
            this.groupBoxDisplay.Location = new System.Drawing.Point(9, 9);
            this.groupBoxDisplay.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(400, 185);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display";
            this.groupBoxDisplay.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxDisplay.TitleBorderMargin = 6;
            this.groupBoxDisplay.TitleBorderPadding = 4;
            this.groupBoxDisplay.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxDisplayMode
            // 
            this.comboBoxDisplayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayMode.FormattingEnabled = true;
            this.comboBoxDisplayMode.Location = new System.Drawing.Point(138, 20);
            this.comboBoxDisplayMode.Name = "comboBoxDisplayMode";
            this.comboBoxDisplayMode.Size = new System.Drawing.Size(253, 21);
            this.comboBoxDisplayMode.TabIndex = 1;
            // 
            // checkBoxFixHUDFor5_4and4_3
            // 
            this.checkBoxFixHUDFor5_4and4_3.AutoSize = true;
            this.checkBoxFixHUDFor5_4and4_3.Location = new System.Drawing.Point(9, 152);
            this.checkBoxFixHUDFor5_4and4_3.Name = "checkBoxFixHUDFor5_4and4_3";
            this.checkBoxFixHUDFor5_4and4_3.Size = new System.Drawing.Size(225, 17);
            this.checkBoxFixHUDFor5_4and4_3.TabIndex = 10;
            this.checkBoxFixHUDFor5_4and4_3.Text = "Fix HUD for 5:4 and 4:3 resolutions (partly)";
            this.checkBoxFixHUDFor5_4and4_3.UseVisualStyleBackColor = true;
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(138, 45);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(253, 20);
            this.comboBoxResolution.TabIndex = 3;
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolution_SelectedIndexChanged);
            // 
            // buttonDetectResolution
            // 
            this.buttonDetectResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDetectResolution.Location = new System.Drawing.Point(138, 97);
            this.buttonDetectResolution.Name = "buttonDetectResolution";
            this.buttonDetectResolution.Size = new System.Drawing.Size(253, 23);
            this.buttonDetectResolution.TabIndex = 8;
            this.buttonDetectResolution.Text = "Detect resolution";
            this.buttonDetectResolution.UseVisualStyleBackColor = true;
            this.buttonDetectResolution.Click += new System.EventHandler(this.buttonDetectResolution_Click);
            // 
            // labelCustomResolution
            // 
            this.labelCustomResolution.AutoSize = true;
            this.labelCustomResolution.Location = new System.Drawing.Point(6, 74);
            this.labelCustomResolution.Name = "labelCustomResolution";
            this.labelCustomResolution.Size = new System.Drawing.Size(93, 13);
            this.labelCustomResolution.TabIndex = 4;
            this.labelCustomResolution.Text = "Custom resolution:";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(6, 48);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 2;
            this.labelResolution.Text = "Resolution:";
            // 
            // checkBoxTopMostWindow
            // 
            this.checkBoxTopMostWindow.AutoSize = true;
            this.checkBoxTopMostWindow.Location = new System.Drawing.Point(9, 129);
            this.checkBoxTopMostWindow.Name = "checkBoxTopMostWindow";
            this.checkBoxTopMostWindow.Size = new System.Drawing.Size(109, 17);
            this.checkBoxTopMostWindow.TabIndex = 9;
            this.checkBoxTopMostWindow.Text = "Top-most window";
            this.checkBoxTopMostWindow.UseVisualStyleBackColor = true;
            // 
            // numCustomResW
            // 
            this.numCustomResW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCustomResW.Location = new System.Drawing.Point(138, 71);
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
            this.numCustomResW.Size = new System.Drawing.Size(116, 20);
            this.numCustomResW.TabIndex = 5;
            this.numCustomResW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCustomResW.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numCustomResW.ValueChanged += new System.EventHandler(this.numCustomRes_ValueChanged);
            // 
            // numCustomResH
            // 
            this.numCustomResH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCustomResH.Location = new System.Drawing.Point(275, 71);
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
            this.numCustomResH.Size = new System.Drawing.Size(116, 20);
            this.numCustomResH.TabIndex = 7;
            this.numCustomResH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCustomResH.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numCustomResH.ValueChanged += new System.EventHandler(this.numCustomRes_ValueChanged);
            // 
            // labelDisplayMode
            // 
            this.labelDisplayMode.AutoSize = true;
            this.labelDisplayMode.Location = new System.Drawing.Point(6, 23);
            this.labelDisplayMode.Name = "labelDisplayMode";
            this.labelDisplayMode.Size = new System.Drawing.Size(73, 13);
            this.labelDisplayMode.TabIndex = 0;
            this.labelDisplayMode.Text = "Display mode:";
            // 
            // labelCustomResolutionSpacer
            // 
            this.labelCustomResolutionSpacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCustomResolutionSpacer.AutoSize = true;
            this.labelCustomResolutionSpacer.Location = new System.Drawing.Point(257, 74);
            this.labelCustomResolutionSpacer.Name = "labelCustomResolutionSpacer";
            this.labelCustomResolutionSpacer.Size = new System.Drawing.Size(14, 13);
            this.labelCustomResolutionSpacer.TabIndex = 6;
            this.labelCustomResolutionSpacer.Text = "X";
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.AutoScroll = true;
            this.tabPageAudio.BackColor = System.Drawing.Color.White;
            this.tabPageAudio.Controls.Add(this.groupBoxAudio);
            this.tabPageAudio.Controls.Add(this.groupBoxVoice);
            this.tabPageAudio.Controls.Add(this.groupBoxAudioVolume);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 25);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Size = new System.Drawing.Size(654, 473);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Audio";
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.BackColor = System.Drawing.Color.White;
            this.groupBoxAudio.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxAudio.BorderWidth = 1;
            this.groupBoxAudio.Controls.Add(this.checkBoxEnableAudio);
            this.groupBoxAudio.Controls.Add(this.checkBoxMainMenuMusic);
            this.groupBoxAudio.Location = new System.Drawing.Point(9, 305);
            this.groupBoxAudio.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(400, 81);
            this.groupBoxAudio.TabIndex = 1;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "Audio";
            this.groupBoxAudio.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxAudio.TitleBorderMargin = 6;
            this.groupBoxAudio.TitleBorderPadding = 4;
            this.groupBoxAudio.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxEnableAudio
            // 
            this.checkBoxEnableAudio.AutoSize = true;
            this.checkBoxEnableAudio.Location = new System.Drawing.Point(10, 23);
            this.checkBoxEnableAudio.Name = "checkBoxEnableAudio";
            this.checkBoxEnableAudio.Size = new System.Drawing.Size(88, 17);
            this.checkBoxEnableAudio.TabIndex = 30;
            this.checkBoxEnableAudio.Text = "Enable audio";
            this.checkBoxEnableAudio.UseVisualStyleBackColor = true;
            // 
            // checkBoxMainMenuMusic
            // 
            this.checkBoxMainMenuMusic.AutoSize = true;
            this.checkBoxMainMenuMusic.Checked = true;
            this.checkBoxMainMenuMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMainMenuMusic.Location = new System.Drawing.Point(10, 46);
            this.checkBoxMainMenuMusic.Name = "checkBoxMainMenuMusic";
            this.checkBoxMainMenuMusic.Size = new System.Drawing.Size(141, 17);
            this.checkBoxMainMenuMusic.TabIndex = 55;
            this.checkBoxMainMenuMusic.Text = "Play music in main menu";
            this.checkBoxMainMenuMusic.UseVisualStyleBackColor = true;
            // 
            // groupBoxVoice
            // 
            this.groupBoxVoice.BackColor = System.Drawing.Color.White;
            this.groupBoxVoice.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxVoice.BorderWidth = 1;
            this.groupBoxVoice.Controls.Add(this.comboBoxVoiceChatMode);
            this.groupBoxVoice.Controls.Add(this.labelVoiceChatMode);
            this.groupBoxVoice.Controls.Add(this.checkBoxPushToTalk);
            this.groupBoxVoice.Location = new System.Drawing.Point(9, 398);
            this.groupBoxVoice.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxVoice.Name = "groupBoxVoice";
            this.groupBoxVoice.Size = new System.Drawing.Size(400, 89);
            this.groupBoxVoice.TabIndex = 2;
            this.groupBoxVoice.TabStop = false;
            this.groupBoxVoice.Text = "Voice";
            this.groupBoxVoice.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxVoice.TitleBorderMargin = 6;
            this.groupBoxVoice.TitleBorderPadding = 4;
            this.groupBoxVoice.TitleForeColor = System.Drawing.Color.Black;
            // 
            // comboBoxVoiceChatMode
            // 
            this.comboBoxVoiceChatMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoiceChatMode.FormattingEnabled = true;
            this.comboBoxVoiceChatMode.Location = new System.Drawing.Point(167, 19);
            this.comboBoxVoiceChatMode.Name = "comboBoxVoiceChatMode";
            this.comboBoxVoiceChatMode.Size = new System.Drawing.Size(227, 21);
            this.comboBoxVoiceChatMode.TabIndex = 2;
            // 
            // labelVoiceChatMode
            // 
            this.labelVoiceChatMode.AutoSize = true;
            this.labelVoiceChatMode.Location = new System.Drawing.Point(7, 22);
            this.labelVoiceChatMode.Name = "labelVoiceChatMode";
            this.labelVoiceChatMode.Size = new System.Drawing.Size(92, 13);
            this.labelVoiceChatMode.TabIndex = 1;
            this.labelVoiceChatMode.Text = "Voice Chat Mode:";
            // 
            // checkBoxPushToTalk
            // 
            this.checkBoxPushToTalk.AutoSize = true;
            this.checkBoxPushToTalk.Location = new System.Drawing.Point(10, 53);
            this.checkBoxPushToTalk.Name = "checkBoxPushToTalk";
            this.checkBoxPushToTalk.Size = new System.Drawing.Size(126, 17);
            this.checkBoxPushToTalk.TabIndex = 3;
            this.checkBoxPushToTalk.Text = "Enable Push-To-Talk";
            this.checkBoxPushToTalk.UseVisualStyleBackColor = true;
            // 
            // groupBoxAudioVolume
            // 
            this.groupBoxAudioVolume.BackColor = System.Drawing.Color.White;
            this.groupBoxAudioVolume.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxAudioVolume.BorderWidth = 1;
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudioChat);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal6);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal5);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal4);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal3);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal2);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal1);
            this.groupBoxAudioVolume.Controls.Add(this.labelVolumeMaster);
            this.groupBoxAudioVolume.Controls.Add(this.sliderVolumeMaster);
            this.groupBoxAudioVolume.Controls.Add(this.numVolumeMaster);
            this.groupBoxAudioVolume.Controls.Add(this.numAudioChat);
            this.groupBoxAudioVolume.Controls.Add(this.sliderAudiofVal0);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudioChat);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal0);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal0);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal6);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal6);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal1);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal1);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal5);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal5);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal2);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal2);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal4);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal4);
            this.groupBoxAudioVolume.Controls.Add(this.labelAudiofVal3);
            this.groupBoxAudioVolume.Controls.Add(this.numAudiofVal3);
            this.groupBoxAudioVolume.Location = new System.Drawing.Point(9, 9);
            this.groupBoxAudioVolume.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxAudioVolume.Name = "groupBoxAudioVolume";
            this.groupBoxAudioVolume.Size = new System.Drawing.Size(400, 284);
            this.groupBoxAudioVolume.TabIndex = 0;
            this.groupBoxAudioVolume.TabStop = false;
            this.groupBoxAudioVolume.Text = "Volume";
            this.groupBoxAudioVolume.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxAudioVolume.TitleBorderMargin = 6;
            this.groupBoxAudioVolume.TitleBorderPadding = 4;
            this.groupBoxAudioVolume.TitleForeColor = System.Drawing.Color.Black;
            // 
            // sliderAudioChat
            // 
            this.sliderAudioChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudioChat.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudioChat.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudioChat.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudioChat.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudioChat.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudioChat.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudioChat.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudioChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudioChat.ForeColor = System.Drawing.Color.White;
            this.sliderAudioChat.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudioChat.Location = new System.Drawing.Point(99, 51);
            this.sliderAudioChat.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudioChat.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudioChat.Name = "sliderAudioChat";
            this.sliderAudioChat.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudioChat.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudioChat.ShowDivisionsText = false;
            this.sliderAudioChat.ShowSmallScale = false;
            this.sliderAudioChat.Size = new System.Drawing.Size(215, 20);
            this.sliderAudioChat.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudioChat.TabIndex = 4;
            this.sliderAudioChat.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudioChat.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudioChat.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudioChat.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudioChat.TickAdd = 0F;
            this.sliderAudioChat.TickColor = System.Drawing.Color.White;
            this.sliderAudioChat.TickDivide = 0F;
            this.sliderAudioChat.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudioChat.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal6
            // 
            this.sliderAudiofVal6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal6.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal6.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal6.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal6.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal6.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal6.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal6.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal6.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal6.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal6.Location = new System.Drawing.Point(99, 249);
            this.sliderAudiofVal6.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal6.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal6.Name = "sliderAudiofVal6";
            this.sliderAudiofVal6.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal6.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal6.ShowDivisionsText = false;
            this.sliderAudiofVal6.ShowSmallScale = false;
            this.sliderAudiofVal6.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal6.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal6.TabIndex = 25;
            this.sliderAudiofVal6.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal6.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal6.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal6.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal6.TickAdd = 0F;
            this.sliderAudiofVal6.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal6.TickDivide = 0F;
            this.sliderAudiofVal6.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal5
            // 
            this.sliderAudiofVal5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal5.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal5.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal5.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal5.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal5.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal5.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal5.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal5.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal5.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal5.Location = new System.Drawing.Point(99, 223);
            this.sliderAudiofVal5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal5.Name = "sliderAudiofVal5";
            this.sliderAudiofVal5.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal5.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal5.ShowDivisionsText = false;
            this.sliderAudiofVal5.ShowSmallScale = false;
            this.sliderAudiofVal5.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal5.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal5.TabIndex = 22;
            this.sliderAudiofVal5.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal5.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal5.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal5.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal5.TickAdd = 0F;
            this.sliderAudiofVal5.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal5.TickDivide = 0F;
            this.sliderAudiofVal5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal5.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal4
            // 
            this.sliderAudiofVal4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal4.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal4.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal4.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal4.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal4.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal4.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal4.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal4.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal4.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal4.Location = new System.Drawing.Point(99, 197);
            this.sliderAudiofVal4.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal4.Name = "sliderAudiofVal4";
            this.sliderAudiofVal4.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal4.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal4.ShowDivisionsText = false;
            this.sliderAudiofVal4.ShowSmallScale = false;
            this.sliderAudiofVal4.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal4.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal4.TabIndex = 19;
            this.sliderAudiofVal4.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal4.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal4.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal4.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal4.TickAdd = 0F;
            this.sliderAudiofVal4.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal4.TickDivide = 0F;
            this.sliderAudiofVal4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal4.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal3
            // 
            this.sliderAudiofVal3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal3.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal3.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal3.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal3.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal3.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal3.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal3.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal3.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal3.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal3.Location = new System.Drawing.Point(99, 171);
            this.sliderAudiofVal3.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal3.Name = "sliderAudiofVal3";
            this.sliderAudiofVal3.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal3.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal3.ShowDivisionsText = false;
            this.sliderAudiofVal3.ShowSmallScale = false;
            this.sliderAudiofVal3.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal3.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal3.TabIndex = 16;
            this.sliderAudiofVal3.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal3.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal3.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal3.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal3.TickAdd = 0F;
            this.sliderAudiofVal3.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal3.TickDivide = 0F;
            this.sliderAudiofVal3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal2
            // 
            this.sliderAudiofVal2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal2.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal2.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal2.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal2.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal2.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal2.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal2.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal2.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal2.Location = new System.Drawing.Point(99, 145);
            this.sliderAudiofVal2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal2.Name = "sliderAudiofVal2";
            this.sliderAudiofVal2.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal2.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal2.ShowDivisionsText = false;
            this.sliderAudiofVal2.ShowSmallScale = false;
            this.sliderAudiofVal2.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal2.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal2.TabIndex = 13;
            this.sliderAudiofVal2.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal2.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal2.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal2.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal2.TickAdd = 0F;
            this.sliderAudiofVal2.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal2.TickDivide = 0F;
            this.sliderAudiofVal2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal1
            // 
            this.sliderAudiofVal1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal1.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal1.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal1.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal1.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal1.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal1.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal1.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal1.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal1.Location = new System.Drawing.Point(99, 119);
            this.sliderAudiofVal1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal1.Name = "sliderAudiofVal1";
            this.sliderAudiofVal1.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal1.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal1.ShowDivisionsText = false;
            this.sliderAudiofVal1.ShowSmallScale = false;
            this.sliderAudiofVal1.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal1.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal1.TabIndex = 10;
            this.sliderAudiofVal1.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal1.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal1.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal1.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal1.TickAdd = 0F;
            this.sliderAudiofVal1.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal1.TickDivide = 0F;
            this.sliderAudiofVal1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelVolumeMaster
            // 
            this.labelVolumeMaster.AutoSize = true;
            this.labelVolumeMaster.Location = new System.Drawing.Point(6, 25);
            this.labelVolumeMaster.Name = "labelVolumeMaster";
            this.labelVolumeMaster.Size = new System.Drawing.Size(76, 13);
            this.labelVolumeMaster.TabIndex = 0;
            this.labelVolumeMaster.Text = "Master volume";
            // 
            // sliderVolumeMaster
            // 
            this.sliderVolumeMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderVolumeMaster.BackColor = System.Drawing.Color.Transparent;
            this.sliderVolumeMaster.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderVolumeMaster.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderVolumeMaster.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderVolumeMaster.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderVolumeMaster.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderVolumeMaster.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderVolumeMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderVolumeMaster.ForeColor = System.Drawing.Color.White;
            this.sliderVolumeMaster.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderVolumeMaster.Location = new System.Drawing.Point(99, 25);
            this.sliderVolumeMaster.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderVolumeMaster.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderVolumeMaster.Name = "sliderVolumeMaster";
            this.sliderVolumeMaster.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderVolumeMaster.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderVolumeMaster.ShowDivisionsText = false;
            this.sliderVolumeMaster.ShowSmallScale = false;
            this.sliderVolumeMaster.Size = new System.Drawing.Size(215, 20);
            this.sliderVolumeMaster.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderVolumeMaster.TabIndex = 1;
            this.sliderVolumeMaster.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderVolumeMaster.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderVolumeMaster.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderVolumeMaster.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderVolumeMaster.TickAdd = 0F;
            this.sliderVolumeMaster.TickColor = System.Drawing.Color.White;
            this.sliderVolumeMaster.TickDivide = 0F;
            this.sliderVolumeMaster.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderVolumeMaster.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numVolumeMaster
            // 
            this.numVolumeMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numVolumeMaster.DecimalPlaces = 2;
            this.numVolumeMaster.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numVolumeMaster.Location = new System.Drawing.Point(320, 25);
            this.numVolumeMaster.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVolumeMaster.Name = "numVolumeMaster";
            this.numVolumeMaster.Size = new System.Drawing.Size(74, 20);
            this.numVolumeMaster.TabIndex = 2;
            this.numVolumeMaster.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAudioChat
            // 
            this.numAudioChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudioChat.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAudioChat.Location = new System.Drawing.Point(320, 51);
            this.numAudioChat.Name = "numAudioChat";
            this.numAudioChat.Size = new System.Drawing.Size(74, 20);
            this.numAudioChat.TabIndex = 5;
            this.numAudioChat.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderAudiofVal0
            // 
            this.sliderAudiofVal0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderAudiofVal0.BackColor = System.Drawing.Color.Transparent;
            this.sliderAudiofVal0.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAudiofVal0.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAudiofVal0.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAudiofVal0.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal0.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderAudiofVal0.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderAudiofVal0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAudiofVal0.ForeColor = System.Drawing.Color.White;
            this.sliderAudiofVal0.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderAudiofVal0.Location = new System.Drawing.Point(99, 93);
            this.sliderAudiofVal0.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderAudiofVal0.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderAudiofVal0.Name = "sliderAudiofVal0";
            this.sliderAudiofVal0.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal0.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAudiofVal0.ShowDivisionsText = false;
            this.sliderAudiofVal0.ShowSmallScale = false;
            this.sliderAudiofVal0.Size = new System.Drawing.Size(215, 20);
            this.sliderAudiofVal0.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAudiofVal0.TabIndex = 7;
            this.sliderAudiofVal0.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal0.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderAudiofVal0.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal0.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderAudiofVal0.TickAdd = 0F;
            this.sliderAudiofVal0.TickColor = System.Drawing.Color.White;
            this.sliderAudiofVal0.TickDivide = 0F;
            this.sliderAudiofVal0.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAudiofVal0.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelAudioChat
            // 
            this.labelAudioChat.AutoSize = true;
            this.labelAudioChat.Location = new System.Drawing.Point(6, 53);
            this.labelAudioChat.Name = "labelAudioChat";
            this.labelAudioChat.Size = new System.Drawing.Size(66, 13);
            this.labelAudioChat.TabIndex = 3;
            this.labelAudioChat.Text = "Chat volume";
            // 
            // labelAudiofVal0
            // 
            this.labelAudiofVal0.AutoSize = true;
            this.labelAudiofVal0.Location = new System.Drawing.Point(6, 95);
            this.labelAudiofVal0.Name = "labelAudiofVal0";
            this.labelAudiofVal0.Size = new System.Drawing.Size(65, 13);
            this.labelAudiofVal0.TabIndex = 6;
            this.labelAudiofVal0.Text = "Menu Music";
            // 
            // numAudiofVal0
            // 
            this.numAudiofVal0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal0.DecimalPlaces = 2;
            this.numAudiofVal0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal0.Location = new System.Drawing.Point(320, 93);
            this.numAudiofVal0.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal0.Name = "numAudiofVal0";
            this.numAudiofVal0.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal0.TabIndex = 8;
            this.numAudiofVal0.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAudiofVal6
            // 
            this.numAudiofVal6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal6.DecimalPlaces = 2;
            this.numAudiofVal6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal6.Location = new System.Drawing.Point(320, 249);
            this.numAudiofVal6.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal6.Name = "numAudiofVal6";
            this.numAudiofVal6.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal6.TabIndex = 26;
            this.numAudiofVal6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAudiofVal6
            // 
            this.labelAudiofVal6.AutoSize = true;
            this.labelAudiofVal6.Location = new System.Drawing.Point(6, 251);
            this.labelAudiofVal6.Name = "labelAudiofVal6";
            this.labelAudiofVal6.Size = new System.Drawing.Size(74, 13);
            this.labelAudiofVal6.TabIndex = 24;
            this.labelAudiofVal6.Text = "Pip-Boy Radio";
            // 
            // labelAudiofVal1
            // 
            this.labelAudiofVal1.AutoSize = true;
            this.labelAudiofVal1.Location = new System.Drawing.Point(6, 121);
            this.labelAudiofVal1.Name = "labelAudiofVal1";
            this.labelAudiofVal1.Size = new System.Drawing.Size(71, 13);
            this.labelAudiofVal1.TabIndex = 9;
            this.labelAudiofVal1.Text = "World Radios";
            // 
            // numAudiofVal1
            // 
            this.numAudiofVal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal1.DecimalPlaces = 2;
            this.numAudiofVal1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal1.Location = new System.Drawing.Point(320, 119);
            this.numAudiofVal1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal1.Name = "numAudiofVal1";
            this.numAudiofVal1.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal1.TabIndex = 11;
            this.numAudiofVal1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAudiofVal5
            // 
            this.numAudiofVal5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal5.DecimalPlaces = 2;
            this.numAudiofVal5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal5.Location = new System.Drawing.Point(320, 223);
            this.numAudiofVal5.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal5.Name = "numAudiofVal5";
            this.numAudiofVal5.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal5.TabIndex = 23;
            this.numAudiofVal5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAudiofVal5
            // 
            this.labelAudiofVal5.AutoSize = true;
            this.labelAudiofVal5.Location = new System.Drawing.Point(6, 225);
            this.labelAudiofVal5.Name = "labelAudiofVal5";
            this.labelAudiofVal5.Size = new System.Drawing.Size(53, 13);
            this.labelAudiofVal5.TabIndex = 21;
            this.labelAudiofVal5.Text = "Footsteps";
            // 
            // labelAudiofVal2
            // 
            this.labelAudiofVal2.AutoSize = true;
            this.labelAudiofVal2.Location = new System.Drawing.Point(6, 147);
            this.labelAudiofVal2.Name = "labelAudiofVal2";
            this.labelAudiofVal2.Size = new System.Drawing.Size(34, 13);
            this.labelAudiofVal2.TabIndex = 12;
            this.labelAudiofVal2.Text = "Voice";
            // 
            // numAudiofVal2
            // 
            this.numAudiofVal2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal2.DecimalPlaces = 2;
            this.numAudiofVal2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal2.Location = new System.Drawing.Point(320, 145);
            this.numAudiofVal2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal2.Name = "numAudiofVal2";
            this.numAudiofVal2.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal2.TabIndex = 14;
            this.numAudiofVal2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAudiofVal4
            // 
            this.numAudiofVal4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal4.DecimalPlaces = 2;
            this.numAudiofVal4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal4.Location = new System.Drawing.Point(320, 197);
            this.numAudiofVal4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal4.Name = "numAudiofVal4";
            this.numAudiofVal4.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal4.TabIndex = 20;
            this.numAudiofVal4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAudiofVal4
            // 
            this.labelAudiofVal4.AutoSize = true;
            this.labelAudiofVal4.Location = new System.Drawing.Point(6, 199);
            this.labelAudiofVal4.Name = "labelAudiofVal4";
            this.labelAudiofVal4.Size = new System.Drawing.Size(40, 13);
            this.labelAudiofVal4.TabIndex = 18;
            this.labelAudiofVal4.Text = "Effects";
            // 
            // labelAudiofVal3
            // 
            this.labelAudiofVal3.AutoSize = true;
            this.labelAudiofVal3.Location = new System.Drawing.Point(6, 173);
            this.labelAudiofVal3.Name = "labelAudiofVal3";
            this.labelAudiofVal3.Size = new System.Drawing.Size(35, 13);
            this.labelAudiofVal3.TabIndex = 15;
            this.labelAudiofVal3.Text = "Music";
            // 
            // numAudiofVal3
            // 
            this.numAudiofVal3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAudiofVal3.DecimalPlaces = 2;
            this.numAudiofVal3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAudiofVal3.Location = new System.Drawing.Point(320, 171);
            this.numAudiofVal3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAudiofVal3.Name = "numAudiofVal3";
            this.numAudiofVal3.Size = new System.Drawing.Size(74, 20);
            this.numAudiofVal3.TabIndex = 17;
            this.numAudiofVal3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPageControls
            // 
            this.tabPageControls.BackColor = System.Drawing.Color.White;
            this.tabPageControls.Controls.Add(this.groupBoxGamepad);
            this.tabPageControls.Controls.Add(this.groupBoxMouse);
            this.tabPageControls.Location = new System.Drawing.Point(4, 25);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Size = new System.Drawing.Size(654, 473);
            this.tabPageControls.TabIndex = 3;
            this.tabPageControls.Text = "Controls";
            // 
            // groupBoxGamepad
            // 
            this.groupBoxGamepad.BackColor = System.Drawing.Color.White;
            this.groupBoxGamepad.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxGamepad.BorderWidth = 1;
            this.groupBoxGamepad.Controls.Add(this.checkBoxAimAssist);
            this.groupBoxGamepad.Controls.Add(this.checkBoxGamepadRumble);
            this.groupBoxGamepad.Controls.Add(this.checkBoxGamepadEnabled);
            this.groupBoxGamepad.Controls.Add(this.sliderGamepadSensitivityY);
            this.groupBoxGamepad.Controls.Add(this.numGamepadSensitivityY);
            this.groupBoxGamepad.Controls.Add(this.labelGamepadSensitivityY);
            this.groupBoxGamepad.Controls.Add(this.sliderGamepadSensitivityX);
            this.groupBoxGamepad.Controls.Add(this.numGamepadSensitivityX);
            this.groupBoxGamepad.Controls.Add(this.labelGamepadSensitivityX);
            this.groupBoxGamepad.Location = new System.Drawing.Point(9, 250);
            this.groupBoxGamepad.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxGamepad.Name = "groupBoxGamepad";
            this.groupBoxGamepad.Size = new System.Drawing.Size(400, 204);
            this.groupBoxGamepad.TabIndex = 1;
            this.groupBoxGamepad.TabStop = false;
            this.groupBoxGamepad.Text = "Gamepad";
            this.groupBoxGamepad.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxGamepad.TitleBorderMargin = 6;
            this.groupBoxGamepad.TitleBorderPadding = 4;
            this.groupBoxGamepad.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxAimAssist
            // 
            this.checkBoxAimAssist.AutoSize = true;
            this.checkBoxAimAssist.Checked = true;
            this.checkBoxAimAssist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAimAssist.Location = new System.Drawing.Point(9, 177);
            this.checkBoxAimAssist.Name = "checkBoxAimAssist";
            this.checkBoxAimAssist.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAimAssist.TabIndex = 2;
            this.checkBoxAimAssist.Text = "Aim Assist";
            this.checkBoxAimAssist.UseVisualStyleBackColor = true;
            // 
            // checkBoxGamepadRumble
            // 
            this.checkBoxGamepadRumble.AutoSize = true;
            this.checkBoxGamepadRumble.Checked = true;
            this.checkBoxGamepadRumble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGamepadRumble.Location = new System.Drawing.Point(9, 154);
            this.checkBoxGamepadRumble.Name = "checkBoxGamepadRumble";
            this.checkBoxGamepadRumble.Size = new System.Drawing.Size(149, 17);
            this.checkBoxGamepadRumble.TabIndex = 1;
            this.checkBoxGamepadRumble.Text = "Enable gamepad vibration";
            this.checkBoxGamepadRumble.UseVisualStyleBackColor = true;
            // 
            // checkBoxGamepadEnabled
            // 
            this.checkBoxGamepadEnabled.AutoSize = true;
            this.checkBoxGamepadEnabled.Checked = true;
            this.checkBoxGamepadEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGamepadEnabled.Location = new System.Drawing.Point(9, 131);
            this.checkBoxGamepadEnabled.Name = "checkBoxGamepadEnabled";
            this.checkBoxGamepadEnabled.Size = new System.Drawing.Size(106, 17);
            this.checkBoxGamepadEnabled.TabIndex = 0;
            this.checkBoxGamepadEnabled.Text = "Enable gamepad";
            this.checkBoxGamepadEnabled.UseVisualStyleBackColor = true;
            // 
            // sliderGamepadSensitivityY
            // 
            this.sliderGamepadSensitivityY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGamepadSensitivityY.BackColor = System.Drawing.Color.Transparent;
            this.sliderGamepadSensitivityY.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderGamepadSensitivityY.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderGamepadSensitivityY.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderGamepadSensitivityY.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityY.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderGamepadSensitivityY.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderGamepadSensitivityY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderGamepadSensitivityY.ForeColor = System.Drawing.Color.White;
            this.sliderGamepadSensitivityY.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.Location = new System.Drawing.Point(9, 85);
            this.sliderGamepadSensitivityY.Maximum = new decimal(new int[] {
            15556,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.Minimum = new decimal(new int[] {
            4445,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.Name = "sliderGamepadSensitivityY";
            this.sliderGamepadSensitivityY.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.ShowDivisionsText = false;
            this.sliderGamepadSensitivityY.ShowSmallScale = false;
            this.sliderGamepadSensitivityY.Size = new System.Drawing.Size(325, 20);
            this.sliderGamepadSensitivityY.SmallChange = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.sliderGamepadSensitivityY.TabIndex = 10;
            this.sliderGamepadSensitivityY.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityY.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityY.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderGamepadSensitivityY.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderGamepadSensitivityY.TickAdd = 0F;
            this.sliderGamepadSensitivityY.TickColor = System.Drawing.Color.White;
            this.sliderGamepadSensitivityY.TickDivide = 0F;
            this.sliderGamepadSensitivityY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderGamepadSensitivityY.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // numGamepadSensitivityY
            // 
            this.numGamepadSensitivityY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGamepadSensitivityY.DecimalPlaces = 4;
            this.numGamepadSensitivityY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            this.numGamepadSensitivityY.Location = new System.Drawing.Point(340, 85);
            this.numGamepadSensitivityY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numGamepadSensitivityY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.numGamepadSensitivityY.Name = "numGamepadSensitivityY";
            this.numGamepadSensitivityY.Size = new System.Drawing.Size(54, 20);
            this.numGamepadSensitivityY.TabIndex = 11;
            this.numGamepadSensitivityY.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // labelGamepadSensitivityY
            // 
            this.labelGamepadSensitivityY.AutoSize = true;
            this.labelGamepadSensitivityY.Location = new System.Drawing.Point(6, 69);
            this.labelGamepadSensitivityY.Name = "labelGamepadSensitivityY";
            this.labelGamepadSensitivityY.Size = new System.Drawing.Size(90, 13);
            this.labelGamepadSensitivityY.TabIndex = 9;
            this.labelGamepadSensitivityY.Text = "Vertical sensitivity";
            // 
            // sliderGamepadSensitivityX
            // 
            this.sliderGamepadSensitivityX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGamepadSensitivityX.BackColor = System.Drawing.Color.Transparent;
            this.sliderGamepadSensitivityX.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderGamepadSensitivityX.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderGamepadSensitivityX.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderGamepadSensitivityX.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityX.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderGamepadSensitivityX.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderGamepadSensitivityX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderGamepadSensitivityX.ForeColor = System.Drawing.Color.White;
            this.sliderGamepadSensitivityX.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.Location = new System.Drawing.Point(9, 38);
            this.sliderGamepadSensitivityX.Maximum = new decimal(new int[] {
            15556,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.Minimum = new decimal(new int[] {
            4445,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.Name = "sliderGamepadSensitivityX";
            this.sliderGamepadSensitivityX.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.ShowDivisionsText = false;
            this.sliderGamepadSensitivityX.ShowSmallScale = false;
            this.sliderGamepadSensitivityX.Size = new System.Drawing.Size(325, 20);
            this.sliderGamepadSensitivityX.SmallChange = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.sliderGamepadSensitivityX.TabIndex = 7;
            this.sliderGamepadSensitivityX.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityX.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGamepadSensitivityX.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderGamepadSensitivityX.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderGamepadSensitivityX.TickAdd = 0F;
            this.sliderGamepadSensitivityX.TickColor = System.Drawing.Color.White;
            this.sliderGamepadSensitivityX.TickDivide = 0F;
            this.sliderGamepadSensitivityX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderGamepadSensitivityX.Value = new decimal(new int[] {
            6667,
            0,
            0,
            0});
            // 
            // numGamepadSensitivityX
            // 
            this.numGamepadSensitivityX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGamepadSensitivityX.DecimalPlaces = 4;
            this.numGamepadSensitivityX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            this.numGamepadSensitivityX.Location = new System.Drawing.Point(340, 38);
            this.numGamepadSensitivityX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numGamepadSensitivityX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.numGamepadSensitivityX.Name = "numGamepadSensitivityX";
            this.numGamepadSensitivityX.Size = new System.Drawing.Size(54, 20);
            this.numGamepadSensitivityX.TabIndex = 8;
            this.numGamepadSensitivityX.Value = new decimal(new int[] {
            6667,
            0,
            0,
            262144});
            // 
            // labelGamepadSensitivityX
            // 
            this.labelGamepadSensitivityX.AutoSize = true;
            this.labelGamepadSensitivityX.Location = new System.Drawing.Point(6, 22);
            this.labelGamepadSensitivityX.Name = "labelGamepadSensitivityX";
            this.labelGamepadSensitivityX.Size = new System.Drawing.Size(102, 13);
            this.labelGamepadSensitivityX.TabIndex = 6;
            this.labelGamepadSensitivityX.Text = "Horizontal sensitivity";
            // 
            // groupBoxMouse
            // 
            this.groupBoxMouse.BackColor = System.Drawing.Color.White;
            this.groupBoxMouse.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxMouse.BorderWidth = 1;
            this.groupBoxMouse.Controls.Add(this.checkBoxMouseInvertX);
            this.groupBoxMouse.Controls.Add(this.checkBoxMouseInvertY);
            this.groupBoxMouse.Controls.Add(this.checkBoxFixAimSensitivity);
            this.groupBoxMouse.Controls.Add(this.checkBoxFixMouseSensitivity);
            this.groupBoxMouse.Controls.Add(this.sliderMouseSensitivityY);
            this.groupBoxMouse.Controls.Add(this.numMouseSensitivityY);
            this.groupBoxMouse.Controls.Add(this.labelMouseSensitivityY);
            this.groupBoxMouse.Controls.Add(this.sliderMouseSensitivityX);
            this.groupBoxMouse.Controls.Add(this.numMouseSensitivityX);
            this.groupBoxMouse.Controls.Add(this.labelMouseSensitivityX);
            this.groupBoxMouse.Location = new System.Drawing.Point(9, 9);
            this.groupBoxMouse.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxMouse.Name = "groupBoxMouse";
            this.groupBoxMouse.Size = new System.Drawing.Size(400, 229);
            this.groupBoxMouse.TabIndex = 0;
            this.groupBoxMouse.TabStop = false;
            this.groupBoxMouse.Text = "Mouse";
            this.groupBoxMouse.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxMouse.TitleBorderMargin = 6;
            this.groupBoxMouse.TitleBorderPadding = 4;
            this.groupBoxMouse.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxMouseInvertX
            // 
            this.checkBoxMouseInvertX.AutoSize = true;
            this.checkBoxMouseInvertX.Location = new System.Drawing.Point(9, 202);
            this.checkBoxMouseInvertX.Name = "checkBoxMouseInvertX";
            this.checkBoxMouseInvertX.Size = new System.Drawing.Size(63, 17);
            this.checkBoxMouseInvertX.TabIndex = 9;
            this.checkBoxMouseInvertX.Text = "Invert X";
            this.checkBoxMouseInvertX.UseVisualStyleBackColor = true;
            // 
            // checkBoxMouseInvertY
            // 
            this.checkBoxMouseInvertY.AutoSize = true;
            this.checkBoxMouseInvertY.Location = new System.Drawing.Point(9, 179);
            this.checkBoxMouseInvertY.Name = "checkBoxMouseInvertY";
            this.checkBoxMouseInvertY.Size = new System.Drawing.Size(63, 17);
            this.checkBoxMouseInvertY.TabIndex = 8;
            this.checkBoxMouseInvertY.Text = "Invert Y";
            this.checkBoxMouseInvertY.UseVisualStyleBackColor = true;
            // 
            // checkBoxFixAimSensitivity
            // 
            this.checkBoxFixAimSensitivity.AutoSize = true;
            this.checkBoxFixAimSensitivity.Location = new System.Drawing.Point(9, 145);
            this.checkBoxFixAimSensitivity.Name = "checkBoxFixAimSensitivity";
            this.checkBoxFixAimSensitivity.Size = new System.Drawing.Size(106, 17);
            this.checkBoxFixAimSensitivity.TabIndex = 7;
            this.checkBoxFixAimSensitivity.Text = "Fix aim sensitivity";
            this.checkBoxFixAimSensitivity.UseVisualStyleBackColor = true;
            // 
            // checkBoxFixMouseSensitivity
            // 
            this.checkBoxFixMouseSensitivity.AutoSize = true;
            this.checkBoxFixMouseSensitivity.Location = new System.Drawing.Point(9, 122);
            this.checkBoxFixMouseSensitivity.Name = "checkBoxFixMouseSensitivity";
            this.checkBoxFixMouseSensitivity.Size = new System.Drawing.Size(225, 17);
            this.checkBoxFixMouseSensitivity.TabIndex = 6;
            this.checkBoxFixMouseSensitivity.Text = "Match mouse horizontal/vertical sensitivity";
            this.checkBoxFixMouseSensitivity.UseVisualStyleBackColor = true;
            // 
            // sliderMouseSensitivityY
            // 
            this.sliderMouseSensitivityY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderMouseSensitivityY.BackColor = System.Drawing.Color.Transparent;
            this.sliderMouseSensitivityY.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderMouseSensitivityY.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderMouseSensitivityY.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderMouseSensitivityY.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityY.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderMouseSensitivityY.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderMouseSensitivityY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderMouseSensitivityY.ForeColor = System.Drawing.Color.White;
            this.sliderMouseSensitivityY.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.Location = new System.Drawing.Point(9, 82);
            this.sliderMouseSensitivityY.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.Name = "sliderMouseSensitivityY";
            this.sliderMouseSensitivityY.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.ShowDivisionsText = false;
            this.sliderMouseSensitivityY.ShowSmallScale = false;
            this.sliderMouseSensitivityY.Size = new System.Drawing.Size(325, 20);
            this.sliderMouseSensitivityY.SmallChange = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.sliderMouseSensitivityY.TabIndex = 4;
            this.sliderMouseSensitivityY.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityY.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityY.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderMouseSensitivityY.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderMouseSensitivityY.TickAdd = 0F;
            this.sliderMouseSensitivityY.TickColor = System.Drawing.Color.White;
            this.sliderMouseSensitivityY.TickDivide = 0F;
            this.sliderMouseSensitivityY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderMouseSensitivityY.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numMouseSensitivityY
            // 
            this.numMouseSensitivityY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMouseSensitivityY.DecimalPlaces = 4;
            this.numMouseSensitivityY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            this.numMouseSensitivityY.Location = new System.Drawing.Point(340, 82);
            this.numMouseSensitivityY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMouseSensitivityY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.numMouseSensitivityY.Name = "numMouseSensitivityY";
            this.numMouseSensitivityY.Size = new System.Drawing.Size(54, 20);
            this.numMouseSensitivityY.TabIndex = 5;
            this.numMouseSensitivityY.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            // 
            // labelMouseSensitivityY
            // 
            this.labelMouseSensitivityY.AutoSize = true;
            this.labelMouseSensitivityY.Location = new System.Drawing.Point(6, 66);
            this.labelMouseSensitivityY.Name = "labelMouseSensitivityY";
            this.labelMouseSensitivityY.Size = new System.Drawing.Size(90, 13);
            this.labelMouseSensitivityY.TabIndex = 3;
            this.labelMouseSensitivityY.Text = "Vertical sensitivity";
            // 
            // sliderMouseSensitivityX
            // 
            this.sliderMouseSensitivityX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderMouseSensitivityX.BackColor = System.Drawing.Color.Transparent;
            this.sliderMouseSensitivityX.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderMouseSensitivityX.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderMouseSensitivityX.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderMouseSensitivityX.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityX.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderMouseSensitivityX.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderMouseSensitivityX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderMouseSensitivityX.ForeColor = System.Drawing.Color.White;
            this.sliderMouseSensitivityX.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.Location = new System.Drawing.Point(9, 35);
            this.sliderMouseSensitivityX.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.Name = "sliderMouseSensitivityX";
            this.sliderMouseSensitivityX.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.ShowDivisionsText = false;
            this.sliderMouseSensitivityX.ShowSmallScale = false;
            this.sliderMouseSensitivityX.Size = new System.Drawing.Size(325, 20);
            this.sliderMouseSensitivityX.SmallChange = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.sliderMouseSensitivityX.TabIndex = 1;
            this.sliderMouseSensitivityX.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityX.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderMouseSensitivityX.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderMouseSensitivityX.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderMouseSensitivityX.TickAdd = 0F;
            this.sliderMouseSensitivityX.TickColor = System.Drawing.Color.White;
            this.sliderMouseSensitivityX.TickDivide = 0F;
            this.sliderMouseSensitivityX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderMouseSensitivityX.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numMouseSensitivityX
            // 
            this.numMouseSensitivityX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMouseSensitivityX.DecimalPlaces = 4;
            this.numMouseSensitivityX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            this.numMouseSensitivityX.Location = new System.Drawing.Point(340, 35);
            this.numMouseSensitivityX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMouseSensitivityX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.numMouseSensitivityX.Name = "numMouseSensitivityX";
            this.numMouseSensitivityX.Size = new System.Drawing.Size(54, 20);
            this.numMouseSensitivityX.TabIndex = 2;
            this.numMouseSensitivityX.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            // 
            // labelMouseSensitivityX
            // 
            this.labelMouseSensitivityX.AutoSize = true;
            this.labelMouseSensitivityX.Location = new System.Drawing.Point(6, 19);
            this.labelMouseSensitivityX.Name = "labelMouseSensitivityX";
            this.labelMouseSensitivityX.Size = new System.Drawing.Size(102, 13);
            this.labelMouseSensitivityX.TabIndex = 0;
            this.labelMouseSensitivityX.Text = "Horizontal sensitivity";
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.AutoScroll = true;
            this.tabPageCamera.BackColor = System.Drawing.Color.White;
            this.tabPageCamera.Controls.Add(this.groupBoxCameraPosition);
            this.tabPageCamera.Controls.Add(this.groupBoxFOVMore);
            this.tabPageCamera.Controls.Add(this.groupBoxSelfieCamera);
            this.tabPageCamera.Controls.Add(this.groupBoxIdleCamera);
            this.tabPageCamera.Controls.Add(this.groupBoxCameraDistance);
            this.tabPageCamera.Controls.Add(this.groupBoxFieldOfView);
            this.tabPageCamera.Location = new System.Drawing.Point(4, 25);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Size = new System.Drawing.Size(654, 473);
            this.tabPageCamera.TabIndex = 4;
            this.tabPageCamera.Text = "Camera";
            // 
            // groupBoxCameraPosition
            // 
            this.groupBoxCameraPosition.BackColor = System.Drawing.Color.White;
            this.groupBoxCameraPosition.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxCameraPosition.BorderWidth = 1;
            this.groupBoxCameraPosition.Controls.Add(this.groupBoxMeleeCombatCameraPosition);
            this.groupBoxCameraPosition.Controls.Add(this.groupBoxCombatCameraPosition);
            this.groupBoxCameraPosition.Controls.Add(this.buttonCameraPositionReset);
            this.groupBoxCameraPosition.Controls.Add(this.checkBoxbApplyCameraNodeAnimations);
            this.groupBoxCameraPosition.Controls.Add(this.groupBoxUnarmedCameraPosition);
            this.groupBoxCameraPosition.Location = new System.Drawing.Point(9, 811);
            this.groupBoxCameraPosition.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxCameraPosition.Name = "groupBoxCameraPosition";
            this.groupBoxCameraPosition.Size = new System.Drawing.Size(400, 512);
            this.groupBoxCameraPosition.TabIndex = 5;
            this.groupBoxCameraPosition.TabStop = false;
            this.groupBoxCameraPosition.Text = "Camera position (Experimental)";
            this.groupBoxCameraPosition.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxCameraPosition.TitleBorderMargin = 6;
            this.groupBoxCameraPosition.TitleBorderPadding = 4;
            this.groupBoxCameraPosition.TitleForeColor = System.Drawing.Color.Black;
            // 
            // groupBoxMeleeCombatCameraPosition
            // 
            this.groupBoxMeleeCombatCameraPosition.BackColor = System.Drawing.Color.White;
            this.groupBoxMeleeCombatCameraPosition.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxMeleeCombatCameraPosition.BorderWidth = 1;
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.numfOverShoulderMeleeCombatAddY);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.labelfOverShoulderMeleeCombatAddY);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.numfOverShoulderMeleeCombatPosX);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.numfOverShoulderMeleeCombatPosZ);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderMeleeCombatAddY);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.labelfOverShoulderMeleeCombatPosX);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderMeleeCombatPosX);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.labelfOverShoulderMeleeCombatPosZ);
            this.groupBoxMeleeCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderMeleeCombatPosZ);
            this.groupBoxMeleeCombatCameraPosition.Location = new System.Drawing.Point(6, 343);
            this.groupBoxMeleeCombatCameraPosition.Name = "groupBoxMeleeCombatCameraPosition";
            this.groupBoxMeleeCombatCameraPosition.Size = new System.Drawing.Size(388, 162);
            this.groupBoxMeleeCombatCameraPosition.TabIndex = 12;
            this.groupBoxMeleeCombatCameraPosition.TabStop = false;
            this.groupBoxMeleeCombatCameraPosition.Text = "Melee combat camera position";
            this.groupBoxMeleeCombatCameraPosition.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxMeleeCombatCameraPosition.TitleBorderMargin = 6;
            this.groupBoxMeleeCombatCameraPosition.TitleBorderPadding = 4;
            this.groupBoxMeleeCombatCameraPosition.TitleForeColor = System.Drawing.Color.Black;
            // 
            // numfOverShoulderMeleeCombatAddY
            // 
            this.numfOverShoulderMeleeCombatAddY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderMeleeCombatAddY.DecimalPlaces = 1;
            this.numfOverShoulderMeleeCombatAddY.Location = new System.Drawing.Point(308, 134);
            this.numfOverShoulderMeleeCombatAddY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderMeleeCombatAddY.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderMeleeCombatAddY.Name = "numfOverShoulderMeleeCombatAddY";
            this.numfOverShoulderMeleeCombatAddY.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderMeleeCombatAddY.TabIndex = 8;
            // 
            // labelfOverShoulderMeleeCombatAddY
            // 
            this.labelfOverShoulderMeleeCombatAddY.AutoSize = true;
            this.labelfOverShoulderMeleeCombatAddY.Location = new System.Drawing.Point(6, 118);
            this.labelfOverShoulderMeleeCombatAddY.Name = "labelfOverShoulderMeleeCombatAddY";
            this.labelfOverShoulderMeleeCombatAddY.Size = new System.Drawing.Size(242, 13);
            this.labelfOverShoulderMeleeCombatAddY.TabIndex = 6;
            this.labelfOverShoulderMeleeCombatAddY.Text = "Further/Closer (fOverShoulderMeleeCombatAddY)";
            // 
            // numfOverShoulderMeleeCombatPosX
            // 
            this.numfOverShoulderMeleeCombatPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderMeleeCombatPosX.DecimalPlaces = 1;
            this.numfOverShoulderMeleeCombatPosX.Location = new System.Drawing.Point(308, 84);
            this.numfOverShoulderMeleeCombatPosX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderMeleeCombatPosX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderMeleeCombatPosX.Name = "numfOverShoulderMeleeCombatPosX";
            this.numfOverShoulderMeleeCombatPosX.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderMeleeCombatPosX.TabIndex = 5;
            // 
            // numfOverShoulderMeleeCombatPosZ
            // 
            this.numfOverShoulderMeleeCombatPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderMeleeCombatPosZ.DecimalPlaces = 1;
            this.numfOverShoulderMeleeCombatPosZ.Location = new System.Drawing.Point(308, 36);
            this.numfOverShoulderMeleeCombatPosZ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderMeleeCombatPosZ.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderMeleeCombatPosZ.Name = "numfOverShoulderMeleeCombatPosZ";
            this.numfOverShoulderMeleeCombatPosZ.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderMeleeCombatPosZ.TabIndex = 2;
            // 
            // trackBarfOverShoulderMeleeCombatAddY
            // 
            this.trackBarfOverShoulderMeleeCombatAddY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderMeleeCombatAddY.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderMeleeCombatAddY.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderMeleeCombatAddY.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderMeleeCombatAddY.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderMeleeCombatAddY.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatAddY.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderMeleeCombatAddY.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderMeleeCombatAddY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderMeleeCombatAddY.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatAddY.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatAddY.Location = new System.Drawing.Point(6, 134);
            this.trackBarfOverShoulderMeleeCombatAddY.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatAddY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderMeleeCombatAddY.Name = "trackBarfOverShoulderMeleeCombatAddY";
            this.trackBarfOverShoulderMeleeCombatAddY.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatAddY.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatAddY.ShowDivisionsText = false;
            this.trackBarfOverShoulderMeleeCombatAddY.ShowSmallScale = false;
            this.trackBarfOverShoulderMeleeCombatAddY.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderMeleeCombatAddY.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatAddY.TabIndex = 7;
            this.trackBarfOverShoulderMeleeCombatAddY.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatAddY.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatAddY.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatAddY.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatAddY.TickAdd = 0F;
            this.trackBarfOverShoulderMeleeCombatAddY.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatAddY.TickDivide = 0F;
            this.trackBarfOverShoulderMeleeCombatAddY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderMeleeCombatAddY.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelfOverShoulderMeleeCombatPosX
            // 
            this.labelfOverShoulderMeleeCombatPosX.AutoSize = true;
            this.labelfOverShoulderMeleeCombatPosX.Location = new System.Drawing.Point(6, 68);
            this.labelfOverShoulderMeleeCombatPosX.Name = "labelfOverShoulderMeleeCombatPosX";
            this.labelfOverShoulderMeleeCombatPosX.Size = new System.Drawing.Size(222, 13);
            this.labelfOverShoulderMeleeCombatPosX.TabIndex = 3;
            this.labelfOverShoulderMeleeCombatPosX.Text = "Left/Right (fOverShoulderMeleeCombatPosX)";
            // 
            // trackBarfOverShoulderMeleeCombatPosX
            // 
            this.trackBarfOverShoulderMeleeCombatPosX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderMeleeCombatPosX.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderMeleeCombatPosX.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderMeleeCombatPosX.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderMeleeCombatPosX.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderMeleeCombatPosX.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosX.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderMeleeCombatPosX.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderMeleeCombatPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderMeleeCombatPosX.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatPosX.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosX.Location = new System.Drawing.Point(6, 84);
            this.trackBarfOverShoulderMeleeCombatPosX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderMeleeCombatPosX.Name = "trackBarfOverShoulderMeleeCombatPosX";
            this.trackBarfOverShoulderMeleeCombatPosX.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosX.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosX.ShowDivisionsText = false;
            this.trackBarfOverShoulderMeleeCombatPosX.ShowSmallScale = false;
            this.trackBarfOverShoulderMeleeCombatPosX.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderMeleeCombatPosX.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosX.TabIndex = 4;
            this.trackBarfOverShoulderMeleeCombatPosX.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosX.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosX.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatPosX.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatPosX.TickAdd = 0F;
            this.trackBarfOverShoulderMeleeCombatPosX.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatPosX.TickDivide = 0F;
            this.trackBarfOverShoulderMeleeCombatPosX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderMeleeCombatPosX.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelfOverShoulderMeleeCombatPosZ
            // 
            this.labelfOverShoulderMeleeCombatPosZ.AutoSize = true;
            this.labelfOverShoulderMeleeCombatPosZ.Location = new System.Drawing.Point(6, 20);
            this.labelfOverShoulderMeleeCombatPosZ.Name = "labelfOverShoulderMeleeCombatPosZ";
            this.labelfOverShoulderMeleeCombatPosZ.Size = new System.Drawing.Size(221, 13);
            this.labelfOverShoulderMeleeCombatPosZ.TabIndex = 0;
            this.labelfOverShoulderMeleeCombatPosZ.Text = "Down/Up (fOverShoulderMeleeCombatPosZ)";
            // 
            // trackBarfOverShoulderMeleeCombatPosZ
            // 
            this.trackBarfOverShoulderMeleeCombatPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderMeleeCombatPosZ.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderMeleeCombatPosZ.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderMeleeCombatPosZ.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderMeleeCombatPosZ.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatPosZ.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosZ.Location = new System.Drawing.Point(6, 36);
            this.trackBarfOverShoulderMeleeCombatPosZ.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderMeleeCombatPosZ.Name = "trackBarfOverShoulderMeleeCombatPosZ";
            this.trackBarfOverShoulderMeleeCombatPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarfOverShoulderMeleeCombatPosZ.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosZ.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosZ.ShowDivisionsText = false;
            this.trackBarfOverShoulderMeleeCombatPosZ.ShowSmallScale = false;
            this.trackBarfOverShoulderMeleeCombatPosZ.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderMeleeCombatPosZ.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderMeleeCombatPosZ.TabIndex = 1;
            this.trackBarfOverShoulderMeleeCombatPosZ.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderMeleeCombatPosZ.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatPosZ.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderMeleeCombatPosZ.TickAdd = 0F;
            this.trackBarfOverShoulderMeleeCombatPosZ.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderMeleeCombatPosZ.TickDivide = 0F;
            this.trackBarfOverShoulderMeleeCombatPosZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderMeleeCombatPosZ.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // groupBoxCombatCameraPosition
            // 
            this.groupBoxCombatCameraPosition.BackColor = System.Drawing.Color.White;
            this.groupBoxCombatCameraPosition.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxCombatCameraPosition.BorderWidth = 1;
            this.groupBoxCombatCameraPosition.Controls.Add(this.numfOverShoulderCombatAddY);
            this.groupBoxCombatCameraPosition.Controls.Add(this.numfOverShoulderCombatPosX);
            this.groupBoxCombatCameraPosition.Controls.Add(this.numfOverShoulderCombatPosZ);
            this.groupBoxCombatCameraPosition.Controls.Add(this.labelfOverShoulderCombatAddY);
            this.groupBoxCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderCombatAddY);
            this.groupBoxCombatCameraPosition.Controls.Add(this.labelfOverShoulderCombatPosX);
            this.groupBoxCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderCombatPosX);
            this.groupBoxCombatCameraPosition.Controls.Add(this.labelfOverShoulderCombatPosZ);
            this.groupBoxCombatCameraPosition.Controls.Add(this.trackBarfOverShoulderCombatPosZ);
            this.groupBoxCombatCameraPosition.Location = new System.Drawing.Point(6, 175);
            this.groupBoxCombatCameraPosition.Name = "groupBoxCombatCameraPosition";
            this.groupBoxCombatCameraPosition.Size = new System.Drawing.Size(388, 162);
            this.groupBoxCombatCameraPosition.TabIndex = 11;
            this.groupBoxCombatCameraPosition.TabStop = false;
            this.groupBoxCombatCameraPosition.Text = "Combat camera position";
            this.groupBoxCombatCameraPosition.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxCombatCameraPosition.TitleBorderMargin = 6;
            this.groupBoxCombatCameraPosition.TitleBorderPadding = 4;
            this.groupBoxCombatCameraPosition.TitleForeColor = System.Drawing.Color.Black;
            // 
            // numfOverShoulderCombatAddY
            // 
            this.numfOverShoulderCombatAddY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderCombatAddY.DecimalPlaces = 1;
            this.numfOverShoulderCombatAddY.Location = new System.Drawing.Point(308, 134);
            this.numfOverShoulderCombatAddY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderCombatAddY.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderCombatAddY.Name = "numfOverShoulderCombatAddY";
            this.numfOverShoulderCombatAddY.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderCombatAddY.TabIndex = 8;
            // 
            // numfOverShoulderCombatPosX
            // 
            this.numfOverShoulderCombatPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderCombatPosX.DecimalPlaces = 1;
            this.numfOverShoulderCombatPosX.Location = new System.Drawing.Point(308, 84);
            this.numfOverShoulderCombatPosX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderCombatPosX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderCombatPosX.Name = "numfOverShoulderCombatPosX";
            this.numfOverShoulderCombatPosX.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderCombatPosX.TabIndex = 5;
            // 
            // numfOverShoulderCombatPosZ
            // 
            this.numfOverShoulderCombatPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderCombatPosZ.DecimalPlaces = 1;
            this.numfOverShoulderCombatPosZ.Location = new System.Drawing.Point(308, 36);
            this.numfOverShoulderCombatPosZ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderCombatPosZ.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderCombatPosZ.Name = "numfOverShoulderCombatPosZ";
            this.numfOverShoulderCombatPosZ.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderCombatPosZ.TabIndex = 2;
            // 
            // labelfOverShoulderCombatAddY
            // 
            this.labelfOverShoulderCombatAddY.AutoSize = true;
            this.labelfOverShoulderCombatAddY.Location = new System.Drawing.Point(6, 118);
            this.labelfOverShoulderCombatAddY.Name = "labelfOverShoulderCombatAddY";
            this.labelfOverShoulderCombatAddY.Size = new System.Drawing.Size(213, 13);
            this.labelfOverShoulderCombatAddY.TabIndex = 6;
            this.labelfOverShoulderCombatAddY.Text = "Further/Closer (fOverShoulderCombatAddY)";
            // 
            // trackBarfOverShoulderCombatAddY
            // 
            this.trackBarfOverShoulderCombatAddY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderCombatAddY.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderCombatAddY.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderCombatAddY.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderCombatAddY.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderCombatAddY.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatAddY.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderCombatAddY.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderCombatAddY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderCombatAddY.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatAddY.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatAddY.Location = new System.Drawing.Point(6, 134);
            this.trackBarfOverShoulderCombatAddY.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatAddY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderCombatAddY.Name = "trackBarfOverShoulderCombatAddY";
            this.trackBarfOverShoulderCombatAddY.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatAddY.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatAddY.ShowDivisionsText = false;
            this.trackBarfOverShoulderCombatAddY.ShowSmallScale = false;
            this.trackBarfOverShoulderCombatAddY.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderCombatAddY.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatAddY.TabIndex = 7;
            this.trackBarfOverShoulderCombatAddY.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatAddY.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatAddY.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatAddY.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatAddY.TickAdd = 0F;
            this.trackBarfOverShoulderCombatAddY.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatAddY.TickDivide = 0F;
            this.trackBarfOverShoulderCombatAddY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderCombatAddY.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelfOverShoulderCombatPosX
            // 
            this.labelfOverShoulderCombatPosX.AutoSize = true;
            this.labelfOverShoulderCombatPosX.Location = new System.Drawing.Point(6, 68);
            this.labelfOverShoulderCombatPosX.Name = "labelfOverShoulderCombatPosX";
            this.labelfOverShoulderCombatPosX.Size = new System.Drawing.Size(193, 13);
            this.labelfOverShoulderCombatPosX.TabIndex = 3;
            this.labelfOverShoulderCombatPosX.Text = "Left/Right (fOverShoulderCombatPosX)";
            // 
            // trackBarfOverShoulderCombatPosX
            // 
            this.trackBarfOverShoulderCombatPosX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderCombatPosX.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderCombatPosX.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderCombatPosX.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderCombatPosX.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderCombatPosX.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosX.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderCombatPosX.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderCombatPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderCombatPosX.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatPosX.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosX.Location = new System.Drawing.Point(6, 84);
            this.trackBarfOverShoulderCombatPosX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderCombatPosX.Name = "trackBarfOverShoulderCombatPosX";
            this.trackBarfOverShoulderCombatPosX.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosX.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosX.ShowDivisionsText = false;
            this.trackBarfOverShoulderCombatPosX.ShowSmallScale = false;
            this.trackBarfOverShoulderCombatPosX.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderCombatPosX.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosX.TabIndex = 4;
            this.trackBarfOverShoulderCombatPosX.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosX.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosX.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatPosX.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatPosX.TickAdd = 0F;
            this.trackBarfOverShoulderCombatPosX.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatPosX.TickDivide = 0F;
            this.trackBarfOverShoulderCombatPosX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderCombatPosX.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelfOverShoulderCombatPosZ
            // 
            this.labelfOverShoulderCombatPosZ.AutoSize = true;
            this.labelfOverShoulderCombatPosZ.Location = new System.Drawing.Point(6, 20);
            this.labelfOverShoulderCombatPosZ.Name = "labelfOverShoulderCombatPosZ";
            this.labelfOverShoulderCombatPosZ.Size = new System.Drawing.Size(192, 13);
            this.labelfOverShoulderCombatPosZ.TabIndex = 0;
            this.labelfOverShoulderCombatPosZ.Text = "Down/Up (fOverShoulderCombatPosZ)";
            // 
            // trackBarfOverShoulderCombatPosZ
            // 
            this.trackBarfOverShoulderCombatPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderCombatPosZ.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderCombatPosZ.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderCombatPosZ.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderCombatPosZ.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderCombatPosZ.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosZ.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderCombatPosZ.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderCombatPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderCombatPosZ.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatPosZ.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosZ.Location = new System.Drawing.Point(6, 36);
            this.trackBarfOverShoulderCombatPosZ.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderCombatPosZ.Name = "trackBarfOverShoulderCombatPosZ";
            this.trackBarfOverShoulderCombatPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarfOverShoulderCombatPosZ.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosZ.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosZ.ShowDivisionsText = false;
            this.trackBarfOverShoulderCombatPosZ.ShowSmallScale = false;
            this.trackBarfOverShoulderCombatPosZ.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderCombatPosZ.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderCombatPosZ.TabIndex = 1;
            this.trackBarfOverShoulderCombatPosZ.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosZ.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderCombatPosZ.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatPosZ.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderCombatPosZ.TickAdd = 0F;
            this.trackBarfOverShoulderCombatPosZ.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderCombatPosZ.TickDivide = 0F;
            this.trackBarfOverShoulderCombatPosZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderCombatPosZ.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // buttonCameraPositionReset
            // 
            this.buttonCameraPositionReset.Location = new System.Drawing.Point(242, 18);
            this.buttonCameraPositionReset.Name = "buttonCameraPositionReset";
            this.buttonCameraPositionReset.Size = new System.Drawing.Size(149, 23);
            this.buttonCameraPositionReset.TabIndex = 1;
            this.buttonCameraPositionReset.Text = "Reset";
            this.buttonCameraPositionReset.UseVisualStyleBackColor = true;
            this.buttonCameraPositionReset.Click += new System.EventHandler(this.buttonCameraPositionReset_Click);
            // 
            // checkBoxbApplyCameraNodeAnimations
            // 
            this.checkBoxbApplyCameraNodeAnimations.AutoSize = true;
            this.checkBoxbApplyCameraNodeAnimations.Location = new System.Drawing.Point(9, 22);
            this.checkBoxbApplyCameraNodeAnimations.Name = "checkBoxbApplyCameraNodeAnimations";
            this.checkBoxbApplyCameraNodeAnimations.Size = new System.Drawing.Size(171, 17);
            this.checkBoxbApplyCameraNodeAnimations.TabIndex = 0;
            this.checkBoxbApplyCameraNodeAnimations.Text = "bApplyCameraNodeAnimations";
            this.checkBoxbApplyCameraNodeAnimations.UseVisualStyleBackColor = true;
            // 
            // groupBoxUnarmedCameraPosition
            // 
            this.groupBoxUnarmedCameraPosition.BackColor = System.Drawing.Color.White;
            this.groupBoxUnarmedCameraPosition.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxUnarmedCameraPosition.BorderWidth = 1;
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.numfOverShoulderPosX);
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.numfOverShoulderPosZ);
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.labelfOverShoulderPosX);
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.trackBarfOverShoulderPosX);
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.labelfOverShoulderPosZ);
            this.groupBoxUnarmedCameraPosition.Controls.Add(this.trackBarfOverShoulderPosZ);
            this.groupBoxUnarmedCameraPosition.Location = new System.Drawing.Point(6, 55);
            this.groupBoxUnarmedCameraPosition.Name = "groupBoxUnarmedCameraPosition";
            this.groupBoxUnarmedCameraPosition.Size = new System.Drawing.Size(388, 114);
            this.groupBoxUnarmedCameraPosition.TabIndex = 10;
            this.groupBoxUnarmedCameraPosition.TabStop = false;
            this.groupBoxUnarmedCameraPosition.Text = "Unarmed camera position";
            this.groupBoxUnarmedCameraPosition.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxUnarmedCameraPosition.TitleBorderMargin = 6;
            this.groupBoxUnarmedCameraPosition.TitleBorderPadding = 4;
            this.groupBoxUnarmedCameraPosition.TitleForeColor = System.Drawing.Color.Black;
            // 
            // numfOverShoulderPosX
            // 
            this.numfOverShoulderPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderPosX.DecimalPlaces = 1;
            this.numfOverShoulderPosX.Location = new System.Drawing.Point(308, 84);
            this.numfOverShoulderPosX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderPosX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderPosX.Name = "numfOverShoulderPosX";
            this.numfOverShoulderPosX.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderPosX.TabIndex = 5;
            // 
            // numfOverShoulderPosZ
            // 
            this.numfOverShoulderPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfOverShoulderPosZ.DecimalPlaces = 1;
            this.numfOverShoulderPosZ.Location = new System.Drawing.Point(308, 36);
            this.numfOverShoulderPosZ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numfOverShoulderPosZ.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numfOverShoulderPosZ.Name = "numfOverShoulderPosZ";
            this.numfOverShoulderPosZ.Size = new System.Drawing.Size(74, 20);
            this.numfOverShoulderPosZ.TabIndex = 2;
            // 
            // labelfOverShoulderPosX
            // 
            this.labelfOverShoulderPosX.AutoSize = true;
            this.labelfOverShoulderPosX.Location = new System.Drawing.Point(6, 68);
            this.labelfOverShoulderPosX.Name = "labelfOverShoulderPosX";
            this.labelfOverShoulderPosX.Size = new System.Drawing.Size(157, 13);
            this.labelfOverShoulderPosX.TabIndex = 3;
            this.labelfOverShoulderPosX.Text = "Left/Right (fOverShoulderPosX)";
            // 
            // trackBarfOverShoulderPosX
            // 
            this.trackBarfOverShoulderPosX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderPosX.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderPosX.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderPosX.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderPosX.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderPosX.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosX.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderPosX.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderPosX.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderPosX.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosX.Location = new System.Drawing.Point(6, 84);
            this.trackBarfOverShoulderPosX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderPosX.Name = "trackBarfOverShoulderPosX";
            this.trackBarfOverShoulderPosX.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosX.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosX.ShowDivisionsText = false;
            this.trackBarfOverShoulderPosX.ShowSmallScale = false;
            this.trackBarfOverShoulderPosX.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderPosX.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosX.TabIndex = 4;
            this.trackBarfOverShoulderPosX.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosX.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosX.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderPosX.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderPosX.TickAdd = 0F;
            this.trackBarfOverShoulderPosX.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderPosX.TickDivide = 0F;
            this.trackBarfOverShoulderPosX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderPosX.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelfOverShoulderPosZ
            // 
            this.labelfOverShoulderPosZ.AutoSize = true;
            this.labelfOverShoulderPosZ.Location = new System.Drawing.Point(6, 20);
            this.labelfOverShoulderPosZ.Name = "labelfOverShoulderPosZ";
            this.labelfOverShoulderPosZ.Size = new System.Drawing.Size(156, 13);
            this.labelfOverShoulderPosZ.TabIndex = 0;
            this.labelfOverShoulderPosZ.Text = "Down/Up (fOverShoulderPosZ)";
            // 
            // trackBarfOverShoulderPosZ
            // 
            this.trackBarfOverShoulderPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarfOverShoulderPosZ.BackColor = System.Drawing.Color.Transparent;
            this.trackBarfOverShoulderPosZ.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarfOverShoulderPosZ.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarfOverShoulderPosZ.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarfOverShoulderPosZ.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosZ.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarfOverShoulderPosZ.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarfOverShoulderPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarfOverShoulderPosZ.ForeColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderPosZ.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosZ.Location = new System.Drawing.Point(6, 36);
            this.trackBarfOverShoulderPosZ.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.trackBarfOverShoulderPosZ.Name = "trackBarfOverShoulderPosZ";
            this.trackBarfOverShoulderPosZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarfOverShoulderPosZ.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosZ.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosZ.ShowDivisionsText = false;
            this.trackBarfOverShoulderPosZ.ShowSmallScale = false;
            this.trackBarfOverShoulderPosZ.Size = new System.Drawing.Size(296, 20);
            this.trackBarfOverShoulderPosZ.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trackBarfOverShoulderPosZ.TabIndex = 1;
            this.trackBarfOverShoulderPosZ.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosZ.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarfOverShoulderPosZ.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderPosZ.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarfOverShoulderPosZ.TickAdd = 0F;
            this.trackBarfOverShoulderPosZ.TickColor = System.Drawing.Color.White;
            this.trackBarfOverShoulderPosZ.TickDivide = 0F;
            this.trackBarfOverShoulderPosZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarfOverShoulderPosZ.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // groupBoxFOVMore
            // 
            this.groupBoxFOVMore.BackColor = System.Drawing.Color.White;
            this.groupBoxFOVMore.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxFOVMore.BorderWidth = 1;
            this.groupBoxFOVMore.Controls.Add(this.labelADSFOV);
            this.groupBoxFOVMore.Controls.Add(this.numADSFOV);
            this.groupBoxFOVMore.Location = new System.Drawing.Point(9, 418);
            this.groupBoxFOVMore.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxFOVMore.Name = "groupBoxFOVMore";
            this.groupBoxFOVMore.Size = new System.Drawing.Size(400, 52);
            this.groupBoxFOVMore.TabIndex = 1;
            this.groupBoxFOVMore.TabStop = false;
            this.groupBoxFOVMore.Text = "More Field of View tweaks";
            this.groupBoxFOVMore.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxFOVMore.TitleBorderMargin = 6;
            this.groupBoxFOVMore.TitleBorderPadding = 4;
            this.groupBoxFOVMore.TitleForeColor = System.Drawing.Color.Black;
            // 
            // labelADSFOV
            // 
            this.labelADSFOV.AutoSize = true;
            this.labelADSFOV.Location = new System.Drawing.Point(6, 21);
            this.labelADSFOV.Name = "labelADSFOV";
            this.labelADSFOV.Size = new System.Drawing.Size(103, 13);
            this.labelADSFOV.TabIndex = 2;
            this.labelADSFOV.Text = "3rd person aim FOV:";
            // 
            // numADSFOV
            // 
            this.numADSFOV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numADSFOV.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numADSFOV.Location = new System.Drawing.Point(318, 19);
            this.numADSFOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numADSFOV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numADSFOV.Name = "numADSFOV";
            this.numADSFOV.Size = new System.Drawing.Size(74, 20);
            this.numADSFOV.TabIndex = 3;
            this.numADSFOV.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBoxSelfieCamera
            // 
            this.groupBoxSelfieCamera.BackColor = System.Drawing.Color.White;
            this.groupBoxSelfieCamera.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxSelfieCamera.BorderWidth = 1;
            this.groupBoxSelfieCamera.Controls.Add(this.trackBarPhotomodeRange);
            this.groupBoxSelfieCamera.Controls.Add(this.numericUpDownPhotomodeRotationSpeed);
            this.groupBoxSelfieCamera.Controls.Add(this.trackBarPhotomodeRotationSpeed);
            this.groupBoxSelfieCamera.Controls.Add(this.labelPhotomodeRotationSpeed);
            this.groupBoxSelfieCamera.Controls.Add(this.numericUpDownPhotomodeRange);
            this.groupBoxSelfieCamera.Controls.Add(this.labelPhotomodeRange);
            this.groupBoxSelfieCamera.Controls.Add(this.numericUpDownPhotomodeTranslationSpeed);
            this.groupBoxSelfieCamera.Controls.Add(this.trackBarPhotomodeTranslationSpeed);
            this.groupBoxSelfieCamera.Controls.Add(this.labelPhotomodeTranslationSpeed);
            this.groupBoxSelfieCamera.Location = new System.Drawing.Point(9, 605);
            this.groupBoxSelfieCamera.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxSelfieCamera.Name = "groupBoxSelfieCamera";
            this.groupBoxSelfieCamera.Size = new System.Drawing.Size(400, 116);
            this.groupBoxSelfieCamera.TabIndex = 4;
            this.groupBoxSelfieCamera.TabStop = false;
            this.groupBoxSelfieCamera.Text = "Photomode options";
            this.groupBoxSelfieCamera.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxSelfieCamera.TitleBorderMargin = 6;
            this.groupBoxSelfieCamera.TitleBorderPadding = 4;
            this.groupBoxSelfieCamera.TitleForeColor = System.Drawing.Color.Black;
            // 
            // trackBarPhotomodeRange
            // 
            this.trackBarPhotomodeRange.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPhotomodeRange.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarPhotomodeRange.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarPhotomodeRange.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarPhotomodeRange.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRange.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarPhotomodeRange.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarPhotomodeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarPhotomodeRange.ForeColor = System.Drawing.Color.White;
            this.trackBarPhotomodeRange.LargeChange = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.Location = new System.Drawing.Point(131, 85);
            this.trackBarPhotomodeRange.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.Name = "trackBarPhotomodeRange";
            this.trackBarPhotomodeRange.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.ShowDivisionsText = false;
            this.trackBarPhotomodeRange.ShowSmallScale = false;
            this.trackBarPhotomodeRange.Size = new System.Drawing.Size(175, 20);
            this.trackBarPhotomodeRange.SmallChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.trackBarPhotomodeRange.TabIndex = 7;
            this.trackBarPhotomodeRange.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRange.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRange.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeRange.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeRange.TickAdd = 0F;
            this.trackBarPhotomodeRange.TickColor = System.Drawing.Color.White;
            this.trackBarPhotomodeRange.TickDivide = 0F;
            this.trackBarPhotomodeRange.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPhotomodeRange.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownPhotomodeRotationSpeed
            // 
            this.numericUpDownPhotomodeRotationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPhotomodeRotationSpeed.DecimalPlaces = 1;
            this.numericUpDownPhotomodeRotationSpeed.Location = new System.Drawing.Point(317, 51);
            this.numericUpDownPhotomodeRotationSpeed.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownPhotomodeRotationSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPhotomodeRotationSpeed.Name = "numericUpDownPhotomodeRotationSpeed";
            this.numericUpDownPhotomodeRotationSpeed.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownPhotomodeRotationSpeed.TabIndex = 5;
            this.numericUpDownPhotomodeRotationSpeed.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // trackBarPhotomodeRotationSpeed
            // 
            this.trackBarPhotomodeRotationSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPhotomodeRotationSpeed.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarPhotomodeRotationSpeed.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarPhotomodeRotationSpeed.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarPhotomodeRotationSpeed.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRotationSpeed.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarPhotomodeRotationSpeed.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarPhotomodeRotationSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarPhotomodeRotationSpeed.ForeColor = System.Drawing.Color.White;
            this.trackBarPhotomodeRotationSpeed.LargeChange = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.Location = new System.Drawing.Point(131, 51);
            this.trackBarPhotomodeRotationSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.Name = "trackBarPhotomodeRotationSpeed";
            this.trackBarPhotomodeRotationSpeed.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.ShowDivisionsText = false;
            this.trackBarPhotomodeRotationSpeed.ShowSmallScale = false;
            this.trackBarPhotomodeRotationSpeed.Size = new System.Drawing.Size(175, 20);
            this.trackBarPhotomodeRotationSpeed.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarPhotomodeRotationSpeed.TabIndex = 4;
            this.trackBarPhotomodeRotationSpeed.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRotationSpeed.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeRotationSpeed.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeRotationSpeed.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeRotationSpeed.TickAdd = 0F;
            this.trackBarPhotomodeRotationSpeed.TickColor = System.Drawing.Color.White;
            this.trackBarPhotomodeRotationSpeed.TickDivide = 0F;
            this.trackBarPhotomodeRotationSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPhotomodeRotationSpeed.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // labelPhotomodeRotationSpeed
            // 
            this.labelPhotomodeRotationSpeed.AutoSize = true;
            this.labelPhotomodeRotationSpeed.Location = new System.Drawing.Point(6, 53);
            this.labelPhotomodeRotationSpeed.Name = "labelPhotomodeRotationSpeed";
            this.labelPhotomodeRotationSpeed.Size = new System.Drawing.Size(82, 13);
            this.labelPhotomodeRotationSpeed.TabIndex = 3;
            this.labelPhotomodeRotationSpeed.Text = "Rotation speed:";
            // 
            // numericUpDownPhotomodeRange
            // 
            this.numericUpDownPhotomodeRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPhotomodeRange.Location = new System.Drawing.Point(317, 85);
            this.numericUpDownPhotomodeRange.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownPhotomodeRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPhotomodeRange.Name = "numericUpDownPhotomodeRange";
            this.numericUpDownPhotomodeRange.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownPhotomodeRange.TabIndex = 8;
            this.numericUpDownPhotomodeRange.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // labelPhotomodeRange
            // 
            this.labelPhotomodeRange.AutoSize = true;
            this.labelPhotomodeRange.Location = new System.Drawing.Point(6, 87);
            this.labelPhotomodeRange.Name = "labelPhotomodeRange";
            this.labelPhotomodeRange.Size = new System.Drawing.Size(62, 13);
            this.labelPhotomodeRange.TabIndex = 6;
            this.labelPhotomodeRange.Text = "Range limit:";
            // 
            // numericUpDownPhotomodeTranslationSpeed
            // 
            this.numericUpDownPhotomodeTranslationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPhotomodeTranslationSpeed.DecimalPlaces = 1;
            this.numericUpDownPhotomodeTranslationSpeed.Location = new System.Drawing.Point(317, 21);
            this.numericUpDownPhotomodeTranslationSpeed.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownPhotomodeTranslationSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPhotomodeTranslationSpeed.Name = "numericUpDownPhotomodeTranslationSpeed";
            this.numericUpDownPhotomodeTranslationSpeed.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownPhotomodeTranslationSpeed.TabIndex = 2;
            this.numericUpDownPhotomodeTranslationSpeed.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            // 
            // trackBarPhotomodeTranslationSpeed
            // 
            this.trackBarPhotomodeTranslationSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPhotomodeTranslationSpeed.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarPhotomodeTranslationSpeed.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarPhotomodeTranslationSpeed.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarPhotomodeTranslationSpeed.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeTranslationSpeed.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarPhotomodeTranslationSpeed.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarPhotomodeTranslationSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarPhotomodeTranslationSpeed.ForeColor = System.Drawing.Color.White;
            this.trackBarPhotomodeTranslationSpeed.LargeChange = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.Location = new System.Drawing.Point(131, 21);
            this.trackBarPhotomodeTranslationSpeed.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.Name = "trackBarPhotomodeTranslationSpeed";
            this.trackBarPhotomodeTranslationSpeed.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.ShowDivisionsText = false;
            this.trackBarPhotomodeTranslationSpeed.ShowSmallScale = false;
            this.trackBarPhotomodeTranslationSpeed.Size = new System.Drawing.Size(175, 20);
            this.trackBarPhotomodeTranslationSpeed.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trackBarPhotomodeTranslationSpeed.TabIndex = 1;
            this.trackBarPhotomodeTranslationSpeed.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeTranslationSpeed.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarPhotomodeTranslationSpeed.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeTranslationSpeed.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarPhotomodeTranslationSpeed.TickAdd = 0F;
            this.trackBarPhotomodeTranslationSpeed.TickColor = System.Drawing.Color.White;
            this.trackBarPhotomodeTranslationSpeed.TickDivide = 0F;
            this.trackBarPhotomodeTranslationSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPhotomodeTranslationSpeed.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // labelPhotomodeTranslationSpeed
            // 
            this.labelPhotomodeTranslationSpeed.AutoSize = true;
            this.labelPhotomodeTranslationSpeed.Location = new System.Drawing.Point(6, 23);
            this.labelPhotomodeTranslationSpeed.Name = "labelPhotomodeTranslationSpeed";
            this.labelPhotomodeTranslationSpeed.Size = new System.Drawing.Size(94, 13);
            this.labelPhotomodeTranslationSpeed.TabIndex = 0;
            this.labelPhotomodeTranslationSpeed.Text = "Translation speed:";
            // 
            // groupBoxIdleCamera
            // 
            this.groupBoxIdleCamera.BackColor = System.Drawing.Color.White;
            this.groupBoxIdleCamera.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxIdleCamera.BorderWidth = 1;
            this.groupBoxIdleCamera.Controls.Add(this.checkBoxForceVanityMode);
            this.groupBoxIdleCamera.Controls.Add(this.checkBoxVanityMode);
            this.groupBoxIdleCamera.Location = new System.Drawing.Point(9, 733);
            this.groupBoxIdleCamera.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxIdleCamera.Name = "groupBoxIdleCamera";
            this.groupBoxIdleCamera.Size = new System.Drawing.Size(400, 66);
            this.groupBoxIdleCamera.TabIndex = 2;
            this.groupBoxIdleCamera.TabStop = false;
            this.groupBoxIdleCamera.Text = "Idle camera (Experimental)";
            this.groupBoxIdleCamera.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxIdleCamera.TitleBorderMargin = 6;
            this.groupBoxIdleCamera.TitleBorderPadding = 4;
            this.groupBoxIdleCamera.TitleForeColor = System.Drawing.Color.Black;
            // 
            // checkBoxForceVanityMode
            // 
            this.checkBoxForceVanityMode.AutoSize = true;
            this.checkBoxForceVanityMode.Checked = true;
            this.checkBoxForceVanityMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxForceVanityMode.Location = new System.Drawing.Point(9, 42);
            this.checkBoxForceVanityMode.Name = "checkBoxForceVanityMode";
            this.checkBoxForceVanityMode.Size = new System.Drawing.Size(137, 17);
            this.checkBoxForceVanityMode.TabIndex = 3;
            this.checkBoxForceVanityMode.Text = "Force auto vanity mode";
            this.checkBoxForceVanityMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxVanityMode
            // 
            this.checkBoxVanityMode.AutoSize = true;
            this.checkBoxVanityMode.Checked = true;
            this.checkBoxVanityMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVanityMode.Location = new System.Drawing.Point(9, 19);
            this.checkBoxVanityMode.Name = "checkBoxVanityMode";
            this.checkBoxVanityMode.Size = new System.Drawing.Size(208, 17);
            this.checkBoxVanityMode.TabIndex = 2;
            this.checkBoxVanityMode.Text = "Enable spinning camera when inactive";
            this.checkBoxVanityMode.UseVisualStyleBackColor = true;
            // 
            // groupBoxCameraDistance
            // 
            this.groupBoxCameraDistance.BackColor = System.Drawing.Color.White;
            this.groupBoxCameraDistance.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxCameraDistance.BorderWidth = 1;
            this.groupBoxCameraDistance.Controls.Add(this.numfPitchZoomOutMaxDist);
            this.groupBoxCameraDistance.Controls.Add(this.sliderfPitchZoomOutMaxDist);
            this.groupBoxCameraDistance.Controls.Add(this.labelPitchZoomOutMaxDist);
            this.groupBoxCameraDistance.Controls.Add(this.numCameraDistanceMaximum);
            this.groupBoxCameraDistance.Controls.Add(this.numCameraDistanceMinimum);
            this.groupBoxCameraDistance.Controls.Add(this.sliderCameraDistanceMaximum);
            this.groupBoxCameraDistance.Controls.Add(this.labelCameraDistanceMaximum);
            this.groupBoxCameraDistance.Controls.Add(this.labelCameraDistanceMinimum);
            this.groupBoxCameraDistance.Controls.Add(this.sliderCameraDistanceMinimum);
            this.groupBoxCameraDistance.Location = new System.Drawing.Point(9, 482);
            this.groupBoxCameraDistance.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxCameraDistance.Name = "groupBoxCameraDistance";
            this.groupBoxCameraDistance.Size = new System.Drawing.Size(400, 111);
            this.groupBoxCameraDistance.TabIndex = 3;
            this.groupBoxCameraDistance.TabStop = false;
            this.groupBoxCameraDistance.Text = "Camera distance in 3rd person";
            this.groupBoxCameraDistance.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxCameraDistance.TitleBorderMargin = 6;
            this.groupBoxCameraDistance.TitleBorderPadding = 4;
            this.groupBoxCameraDistance.TitleForeColor = System.Drawing.Color.Black;
            // 
            // numfPitchZoomOutMaxDist
            // 
            this.numfPitchZoomOutMaxDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numfPitchZoomOutMaxDist.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numfPitchZoomOutMaxDist.Location = new System.Drawing.Point(317, 78);
            this.numfPitchZoomOutMaxDist.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numfPitchZoomOutMaxDist.Name = "numfPitchZoomOutMaxDist";
            this.numfPitchZoomOutMaxDist.Size = new System.Drawing.Size(74, 20);
            this.numfPitchZoomOutMaxDist.TabIndex = 9;
            this.numfPitchZoomOutMaxDist.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // sliderfPitchZoomOutMaxDist
            // 
            this.sliderfPitchZoomOutMaxDist.BackColor = System.Drawing.Color.Transparent;
            this.sliderfPitchZoomOutMaxDist.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderfPitchZoomOutMaxDist.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderfPitchZoomOutMaxDist.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderfPitchZoomOutMaxDist.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderfPitchZoomOutMaxDist.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderfPitchZoomOutMaxDist.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderfPitchZoomOutMaxDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderfPitchZoomOutMaxDist.ForeColor = System.Drawing.Color.White;
            this.sliderfPitchZoomOutMaxDist.LargeChange = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.Location = new System.Drawing.Point(131, 78);
            this.sliderfPitchZoomOutMaxDist.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.Name = "sliderfPitchZoomOutMaxDist";
            this.sliderfPitchZoomOutMaxDist.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.ShowDivisionsText = false;
            this.sliderfPitchZoomOutMaxDist.ShowSmallScale = false;
            this.sliderfPitchZoomOutMaxDist.Size = new System.Drawing.Size(175, 20);
            this.sliderfPitchZoomOutMaxDist.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderfPitchZoomOutMaxDist.TabIndex = 8;
            this.sliderfPitchZoomOutMaxDist.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderfPitchZoomOutMaxDist.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderfPitchZoomOutMaxDist.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderfPitchZoomOutMaxDist.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderfPitchZoomOutMaxDist.TickAdd = 0F;
            this.sliderfPitchZoomOutMaxDist.TickColor = System.Drawing.Color.White;
            this.sliderfPitchZoomOutMaxDist.TickDivide = 0F;
            this.sliderfPitchZoomOutMaxDist.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderfPitchZoomOutMaxDist.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelPitchZoomOutMaxDist
            // 
            this.labelPitchZoomOutMaxDist.AutoSize = true;
            this.labelPitchZoomOutMaxDist.Location = new System.Drawing.Point(6, 85);
            this.labelPitchZoomOutMaxDist.Name = "labelPitchZoomOutMaxDist";
            this.labelPitchZoomOutMaxDist.Size = new System.Drawing.Size(98, 13);
            this.labelPitchZoomOutMaxDist.TabIndex = 7;
            this.labelPitchZoomOutMaxDist.Text = "Zoom out distance:";
            // 
            // numCameraDistanceMaximum
            // 
            this.numCameraDistanceMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCameraDistanceMaximum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCameraDistanceMaximum.Location = new System.Drawing.Point(317, 49);
            this.numCameraDistanceMaximum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCameraDistanceMaximum.Name = "numCameraDistanceMaximum";
            this.numCameraDistanceMaximum.Size = new System.Drawing.Size(74, 20);
            this.numCameraDistanceMaximum.TabIndex = 6;
            this.numCameraDistanceMaximum.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numCameraDistanceMinimum
            // 
            this.numCameraDistanceMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCameraDistanceMinimum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCameraDistanceMinimum.Location = new System.Drawing.Point(317, 20);
            this.numCameraDistanceMinimum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCameraDistanceMinimum.Name = "numCameraDistanceMinimum";
            this.numCameraDistanceMinimum.Size = new System.Drawing.Size(74, 20);
            this.numCameraDistanceMinimum.TabIndex = 2;
            // 
            // sliderCameraDistanceMaximum
            // 
            this.sliderCameraDistanceMaximum.BackColor = System.Drawing.Color.Transparent;
            this.sliderCameraDistanceMaximum.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderCameraDistanceMaximum.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderCameraDistanceMaximum.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderCameraDistanceMaximum.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMaximum.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderCameraDistanceMaximum.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderCameraDistanceMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderCameraDistanceMaximum.ForeColor = System.Drawing.Color.White;
            this.sliderCameraDistanceMaximum.LargeChange = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.Location = new System.Drawing.Point(131, 49);
            this.sliderCameraDistanceMaximum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.Name = "sliderCameraDistanceMaximum";
            this.sliderCameraDistanceMaximum.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.ShowDivisionsText = false;
            this.sliderCameraDistanceMaximum.ShowSmallScale = false;
            this.sliderCameraDistanceMaximum.Size = new System.Drawing.Size(175, 20);
            this.sliderCameraDistanceMaximum.SmallChange = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sliderCameraDistanceMaximum.TabIndex = 4;
            this.sliderCameraDistanceMaximum.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMaximum.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMaximum.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderCameraDistanceMaximum.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderCameraDistanceMaximum.TickAdd = 0F;
            this.sliderCameraDistanceMaximum.TickColor = System.Drawing.Color.White;
            this.sliderCameraDistanceMaximum.TickDivide = 0F;
            this.sliderCameraDistanceMaximum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderCameraDistanceMaximum.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // labelCameraDistanceMaximum
            // 
            this.labelCameraDistanceMaximum.AutoSize = true;
            this.labelCameraDistanceMaximum.Location = new System.Drawing.Point(6, 56);
            this.labelCameraDistanceMaximum.Name = "labelCameraDistanceMaximum";
            this.labelCameraDistanceMaximum.Size = new System.Drawing.Size(54, 13);
            this.labelCameraDistanceMaximum.TabIndex = 3;
            this.labelCameraDistanceMaximum.Text = "Maximum:";
            // 
            // labelCameraDistanceMinimum
            // 
            this.labelCameraDistanceMinimum.AutoSize = true;
            this.labelCameraDistanceMinimum.Location = new System.Drawing.Point(6, 27);
            this.labelCameraDistanceMinimum.Name = "labelCameraDistanceMinimum";
            this.labelCameraDistanceMinimum.Size = new System.Drawing.Size(51, 13);
            this.labelCameraDistanceMinimum.TabIndex = 0;
            this.labelCameraDistanceMinimum.Text = "Minimum:";
            // 
            // sliderCameraDistanceMinimum
            // 
            this.sliderCameraDistanceMinimum.BackColor = System.Drawing.Color.Transparent;
            this.sliderCameraDistanceMinimum.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderCameraDistanceMinimum.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderCameraDistanceMinimum.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderCameraDistanceMinimum.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMinimum.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderCameraDistanceMinimum.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderCameraDistanceMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderCameraDistanceMinimum.ForeColor = System.Drawing.Color.White;
            this.sliderCameraDistanceMinimum.LargeChange = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.Location = new System.Drawing.Point(131, 20);
            this.sliderCameraDistanceMinimum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.Name = "sliderCameraDistanceMinimum";
            this.sliderCameraDistanceMinimum.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.ShowDivisionsText = false;
            this.sliderCameraDistanceMinimum.ShowSmallScale = false;
            this.sliderCameraDistanceMinimum.Size = new System.Drawing.Size(175, 20);
            this.sliderCameraDistanceMinimum.SmallChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCameraDistanceMinimum.TabIndex = 1;
            this.sliderCameraDistanceMinimum.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMinimum.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderCameraDistanceMinimum.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderCameraDistanceMinimum.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderCameraDistanceMinimum.TickAdd = 0F;
            this.sliderCameraDistanceMinimum.TickColor = System.Drawing.Color.White;
            this.sliderCameraDistanceMinimum.TickDivide = 0F;
            this.sliderCameraDistanceMinimum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderCameraDistanceMinimum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // groupBoxFieldOfView
            // 
            this.groupBoxFieldOfView.BackColor = System.Drawing.Color.White;
            this.groupBoxFieldOfView.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxFieldOfView.BorderWidth = 1;
            this.groupBoxFieldOfView.Controls.Add(this.pictureBoxFOVPreview);
            this.groupBoxFieldOfView.Controls.Add(this.sliderFOV);
            this.groupBoxFieldOfView.Controls.Add(this.numFOV);
            this.groupBoxFieldOfView.Location = new System.Drawing.Point(9, 9);
            this.groupBoxFieldOfView.Margin = new System.Windows.Forms.Padding(9);
            this.groupBoxFieldOfView.Name = "groupBoxFieldOfView";
            this.groupBoxFieldOfView.Size = new System.Drawing.Size(619, 394);
            this.groupBoxFieldOfView.TabIndex = 0;
            this.groupBoxFieldOfView.TabStop = false;
            this.groupBoxFieldOfView.Text = "Field of View";
            this.groupBoxFieldOfView.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxFieldOfView.TitleBorderMargin = 6;
            this.groupBoxFieldOfView.TitleBorderPadding = 4;
            this.groupBoxFieldOfView.TitleForeColor = System.Drawing.Color.Black;
            // 
            // pictureBoxFOVPreview
            // 
            this.pictureBoxFOVPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFOVPreview.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxFOVPreview.Location = new System.Drawing.Point(0, 45);
            this.pictureBoxFOVPreview.Name = "pictureBoxFOVPreview";
            this.pictureBoxFOVPreview.Size = new System.Drawing.Size(619, 349);
            this.pictureBoxFOVPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFOVPreview.TabIndex = 53;
            this.pictureBoxFOVPreview.TabStop = false;
            // 
            // sliderFOV
            // 
            this.sliderFOV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderFOV.BackColor = System.Drawing.Color.Transparent;
            this.sliderFOV.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderFOV.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderFOV.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderFOV.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFOV.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderFOV.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderFOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderFOV.ForeColor = System.Drawing.Color.White;
            this.sliderFOV.LargeChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderFOV.Location = new System.Drawing.Point(6, 19);
            this.sliderFOV.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.sliderFOV.Minimum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.sliderFOV.Name = "sliderFOV";
            this.sliderFOV.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderFOV.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderFOV.ShowDivisionsText = false;
            this.sliderFOV.ShowSmallScale = false;
            this.sliderFOV.Size = new System.Drawing.Size(533, 20);
            this.sliderFOV.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderFOV.TabIndex = 0;
            this.sliderFOV.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFOV.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderFOV.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderFOV.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderFOV.TickAdd = 0F;
            this.sliderFOV.TickColor = System.Drawing.Color.White;
            this.sliderFOV.TickDivide = 0F;
            this.sliderFOV.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderFOV.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // numFOV
            // 
            this.numFOV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFOV.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFOV.Location = new System.Drawing.Point(545, 19);
            this.numFOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numFOV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFOV.Name = "numFOV";
            this.numFOV.Size = new System.Drawing.Size(68, 20);
            this.numFOV.TabIndex = 1;
            this.numFOV.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFOV.ValueChanged += new System.EventHandler(this.numFOV_ValueChanged);
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.AutoScroll = true;
            this.tabPageLogin.BackColor = System.Drawing.Color.White;
            this.tabPageLogin.Controls.Add(this.groupBoxLoginProfiles);
            this.tabPageLogin.Controls.Add(this.groupBoxLogin);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(654, 473);
            this.tabPageLogin.TabIndex = 5;
            this.tabPageLogin.Text = "Bethesda.net";
            // 
            // groupBoxLoginProfiles
            // 
            this.groupBoxLoginProfiles.BackColor = System.Drawing.Color.White;
            this.groupBoxLoginProfiles.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxLoginProfiles.BorderWidth = 1;
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccountNone);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount1);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount16);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount2);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount15);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount3);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount14);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount4);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount13);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount5);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount12);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount6);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount11);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount7);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount10);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount8);
            this.groupBoxLoginProfiles.Controls.Add(this.radioButtonAccount9);
            this.groupBoxLoginProfiles.Location = new System.Drawing.Point(9, 356);
            this.groupBoxLoginProfiles.Name = "groupBoxLoginProfiles";
            this.groupBoxLoginProfiles.Size = new System.Drawing.Size(400, 143);
            this.groupBoxLoginProfiles.TabIndex = 1;
            this.groupBoxLoginProfiles.TabStop = false;
            this.groupBoxLoginProfiles.Text = "Profiles";
            this.groupBoxLoginProfiles.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxLoginProfiles.TitleBorderMargin = 6;
            this.groupBoxLoginProfiles.TitleBorderPadding = 4;
            this.groupBoxLoginProfiles.TitleForeColor = System.Drawing.Color.Black;
            // 
            // radioButtonAccountNone
            // 
            this.radioButtonAccountNone.AutoSize = true;
            this.radioButtonAccountNone.Location = new System.Drawing.Point(8, 20);
            this.radioButtonAccountNone.Name = "radioButtonAccountNone";
            this.radioButtonAccountNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonAccountNone.TabIndex = 0;
            this.radioButtonAccountNone.TabStop = true;
            this.radioButtonAccountNone.Text = "None";
            this.radioButtonAccountNone.UseVisualStyleBackColor = true;
            this.radioButtonAccountNone.CheckedChanged += new System.EventHandler(this.radioButtonAccountNone_CheckedChanged);
            // 
            // radioButtonAccount1
            // 
            this.radioButtonAccount1.AutoSize = true;
            this.radioButtonAccount1.Location = new System.Drawing.Point(8, 46);
            this.radioButtonAccount1.Name = "radioButtonAccount1";
            this.radioButtonAccount1.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount1.TabIndex = 1;
            this.radioButtonAccount1.TabStop = true;
            this.radioButtonAccount1.Text = "Account #1";
            this.radioButtonAccount1.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount16
            // 
            this.radioButtonAccount16.AutoSize = true;
            this.radioButtonAccount16.Location = new System.Drawing.Point(305, 115);
            this.radioButtonAccount16.Name = "radioButtonAccount16";
            this.radioButtonAccount16.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount16.TabIndex = 16;
            this.radioButtonAccount16.TabStop = true;
            this.radioButtonAccount16.Text = "Account #16";
            this.radioButtonAccount16.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount2
            // 
            this.radioButtonAccount2.AutoSize = true;
            this.radioButtonAccount2.Location = new System.Drawing.Point(107, 46);
            this.radioButtonAccount2.Name = "radioButtonAccount2";
            this.radioButtonAccount2.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount2.TabIndex = 2;
            this.radioButtonAccount2.TabStop = true;
            this.radioButtonAccount2.Text = "Account #2";
            this.radioButtonAccount2.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount15
            // 
            this.radioButtonAccount15.AutoSize = true;
            this.radioButtonAccount15.Location = new System.Drawing.Point(206, 115);
            this.radioButtonAccount15.Name = "radioButtonAccount15";
            this.radioButtonAccount15.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount15.TabIndex = 15;
            this.radioButtonAccount15.TabStop = true;
            this.radioButtonAccount15.Text = "Account #15";
            this.radioButtonAccount15.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount3
            // 
            this.radioButtonAccount3.AutoSize = true;
            this.radioButtonAccount3.Location = new System.Drawing.Point(206, 46);
            this.radioButtonAccount3.Name = "radioButtonAccount3";
            this.radioButtonAccount3.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount3.TabIndex = 3;
            this.radioButtonAccount3.TabStop = true;
            this.radioButtonAccount3.Text = "Account #3";
            this.radioButtonAccount3.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount14
            // 
            this.radioButtonAccount14.AutoSize = true;
            this.radioButtonAccount14.Location = new System.Drawing.Point(107, 115);
            this.radioButtonAccount14.Name = "radioButtonAccount14";
            this.radioButtonAccount14.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount14.TabIndex = 14;
            this.radioButtonAccount14.TabStop = true;
            this.radioButtonAccount14.Text = "Account #14";
            this.radioButtonAccount14.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount4
            // 
            this.radioButtonAccount4.AutoSize = true;
            this.radioButtonAccount4.Location = new System.Drawing.Point(305, 46);
            this.radioButtonAccount4.Name = "radioButtonAccount4";
            this.radioButtonAccount4.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount4.TabIndex = 4;
            this.radioButtonAccount4.TabStop = true;
            this.radioButtonAccount4.Text = "Account #4";
            this.radioButtonAccount4.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount13
            // 
            this.radioButtonAccount13.AutoSize = true;
            this.radioButtonAccount13.Location = new System.Drawing.Point(8, 115);
            this.radioButtonAccount13.Name = "radioButtonAccount13";
            this.radioButtonAccount13.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount13.TabIndex = 13;
            this.radioButtonAccount13.TabStop = true;
            this.radioButtonAccount13.Text = "Account #13";
            this.radioButtonAccount13.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount5
            // 
            this.radioButtonAccount5.AutoSize = true;
            this.radioButtonAccount5.Location = new System.Drawing.Point(8, 69);
            this.radioButtonAccount5.Name = "radioButtonAccount5";
            this.radioButtonAccount5.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount5.TabIndex = 5;
            this.radioButtonAccount5.TabStop = true;
            this.radioButtonAccount5.Text = "Account #5";
            this.radioButtonAccount5.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount12
            // 
            this.radioButtonAccount12.AutoSize = true;
            this.radioButtonAccount12.Location = new System.Drawing.Point(305, 92);
            this.radioButtonAccount12.Name = "radioButtonAccount12";
            this.radioButtonAccount12.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount12.TabIndex = 12;
            this.radioButtonAccount12.TabStop = true;
            this.radioButtonAccount12.Text = "Account #12";
            this.radioButtonAccount12.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount6
            // 
            this.radioButtonAccount6.AutoSize = true;
            this.radioButtonAccount6.Location = new System.Drawing.Point(107, 69);
            this.radioButtonAccount6.Name = "radioButtonAccount6";
            this.radioButtonAccount6.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount6.TabIndex = 6;
            this.radioButtonAccount6.TabStop = true;
            this.radioButtonAccount6.Text = "Account #6";
            this.radioButtonAccount6.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount11
            // 
            this.radioButtonAccount11.AutoSize = true;
            this.radioButtonAccount11.Location = new System.Drawing.Point(206, 92);
            this.radioButtonAccount11.Name = "radioButtonAccount11";
            this.radioButtonAccount11.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount11.TabIndex = 11;
            this.radioButtonAccount11.TabStop = true;
            this.radioButtonAccount11.Text = "Account #11";
            this.radioButtonAccount11.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount7
            // 
            this.radioButtonAccount7.AutoSize = true;
            this.radioButtonAccount7.Location = new System.Drawing.Point(206, 69);
            this.radioButtonAccount7.Name = "radioButtonAccount7";
            this.radioButtonAccount7.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount7.TabIndex = 7;
            this.radioButtonAccount7.TabStop = true;
            this.radioButtonAccount7.Text = "Account #7";
            this.radioButtonAccount7.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount10
            // 
            this.radioButtonAccount10.AutoSize = true;
            this.radioButtonAccount10.Location = new System.Drawing.Point(107, 92);
            this.radioButtonAccount10.Name = "radioButtonAccount10";
            this.radioButtonAccount10.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAccount10.TabIndex = 10;
            this.radioButtonAccount10.TabStop = true;
            this.radioButtonAccount10.Text = "Account #10";
            this.radioButtonAccount10.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount8
            // 
            this.radioButtonAccount8.AutoSize = true;
            this.radioButtonAccount8.Location = new System.Drawing.Point(305, 69);
            this.radioButtonAccount8.Name = "radioButtonAccount8";
            this.radioButtonAccount8.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount8.TabIndex = 8;
            this.radioButtonAccount8.TabStop = true;
            this.radioButtonAccount8.Text = "Account #8";
            this.radioButtonAccount8.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount9
            // 
            this.radioButtonAccount9.AutoSize = true;
            this.radioButtonAccount9.Location = new System.Drawing.Point(8, 92);
            this.radioButtonAccount9.Name = "radioButtonAccount9";
            this.radioButtonAccount9.Size = new System.Drawing.Size(81, 17);
            this.radioButtonAccount9.TabIndex = 9;
            this.radioButtonAccount9.TabStop = true;
            this.radioButtonAccount9.Text = "Account #9";
            this.radioButtonAccount9.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.Color.White;
            this.groupBoxLogin.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxLogin.BorderWidth = 1;
            this.groupBoxLogin.Controls.Add(this.richTextBoxCredentialsExplanation);
            this.groupBoxLogin.Controls.Add(this.checkBoxAutoSignin);
            this.groupBoxLogin.Controls.Add(this.checkBoxEnableSteam);
            this.groupBoxLogin.Controls.Add(this.textBoxPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxUserName);
            this.groupBoxLogin.Controls.Add(this.checkBoxShowPassword);
            this.groupBoxLogin.Controls.Add(this.labelPassword);
            this.groupBoxLogin.Controls.Add(this.labelUserName);
            this.groupBoxLogin.Location = new System.Drawing.Point(9, 9);
            this.groupBoxLogin.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(400, 338);
            this.groupBoxLogin.TabIndex = 0;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login with Bethesda.net";
            this.groupBoxLogin.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxLogin.TitleBorderMargin = 6;
            this.groupBoxLogin.TitleBorderPadding = 4;
            this.groupBoxLogin.TitleForeColor = System.Drawing.Color.Black;
            // 
            // richTextBoxCredentialsExplanation
            // 
            this.richTextBoxCredentialsExplanation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCredentialsExplanation.Location = new System.Drawing.Point(6, 164);
            this.richTextBoxCredentialsExplanation.Name = "richTextBoxCredentialsExplanation";
            this.richTextBoxCredentialsExplanation.Size = new System.Drawing.Size(393, 172);
            this.richTextBoxCredentialsExplanation.TabIndex = 7;
            this.richTextBoxCredentialsExplanation.Text = "Placeholder";
            // 
            // checkBoxAutoSignin
            // 
            this.checkBoxAutoSignin.AutoSize = true;
            this.checkBoxAutoSignin.Location = new System.Drawing.Point(12, 103);
            this.checkBoxAutoSignin.Name = "checkBoxAutoSignin";
            this.checkBoxAutoSignin.Size = new System.Drawing.Size(121, 17);
            this.checkBoxAutoSignin.TabIndex = 5;
            this.checkBoxAutoSignin.Text = "Automatically sign-in";
            this.checkBoxAutoSignin.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableSteam
            // 
            this.checkBoxEnableSteam.AutoSize = true;
            this.checkBoxEnableSteam.Location = new System.Drawing.Point(12, 126);
            this.checkBoxEnableSteam.Name = "checkBoxEnableSteam";
            this.checkBoxEnableSteam.Size = new System.Drawing.Size(92, 17);
            this.checkBoxEnableSteam.TabIndex = 6;
            this.checkBoxEnableSteam.Text = "Enable Steam";
            this.checkBoxEnableSteam.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(92, 44);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(294, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(92, 19);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(294, 20);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(92, 70);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(101, 17);
            this.checkBoxShowPassword.TabIndex = 4;
            this.checkBoxShowPassword.Text = "Show password";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(9, 47);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(9, 22);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(61, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User name:";
            // 
            // labelTweaksDesc
            // 
            this.labelTweaksDesc.AutoSize = true;
            this.labelTweaksDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTweaksDesc.Location = new System.Drawing.Point(12, 45);
            this.labelTweaksDesc.Name = "labelTweaksDesc";
            this.labelTweaksDesc.Size = new System.Drawing.Size(333, 17);
            this.labelTweaksDesc.TabIndex = 72;
            this.labelTweaksDesc.Text = "Tip: Hover over an option, if you\'re unsure what it does.";
            // 
            // labelTweaksTitle
            // 
            this.labelTweaksTitle.AutoSize = true;
            this.labelTweaksTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTweaksTitle.Location = new System.Drawing.Point(10, 15);
            this.labelTweaksTitle.Name = "labelTweaksTitle";
            this.labelTweaksTitle.Size = new System.Drawing.Size(82, 30);
            this.labelTweaksTitle.TabIndex = 71;
            this.labelTweaksTitle.Text = "Tweaks";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.BackColor = System.Drawing.Color.White;
            this.toolTip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolTip.ForeColor = System.Drawing.Color.Black;
            this.toolTip.InitialDelay = 500;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Padding = new System.Drawing.Size(6, 6);
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // UserControlTweaks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTweaksDesc);
            this.Controls.Add(this.labelTweaksTitle);
            this.Controls.Add(this.tabControlTweaks);
            this.Name = "UserControlTweaks";
            this.Size = new System.Drawing.Size(680, 580);
            this.Load += new System.EventHandler(this.UserControlTweaks_Load);
            this.tabControlTweaks.ResumeLayout(false);
            this.tabPageTweaksInfo.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.groupBoxGameplay.ResumeLayout(false);
            this.groupBoxGameplay.PerformLayout();
            this.groupBoxDialogue.ResumeLayout(false);
            this.groupBoxDialogue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConversationHistorySize)).EndInit();
            this.groupBoxHUD.ResumeLayout(false);
            this.groupBoxHUD.PerformLayout();
            this.groupBoxFloatingQuestMarkers.ResumeLayout(false);
            this.groupBoxFloatingQuestMarkers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloatingQuestMarkersDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHUDOpacity)).EndInit();
            this.groupBoxLoading.ResumeLayout(false);
            this.groupBoxLoading.PerformLayout();
            this.groupBoxQuests.ResumeLayout(false);
            this.groupBoxQuests.PerformLayout();
            this.groupBoxMainMenu.ResumeLayout(false);
            this.groupBoxMainMenu.PerformLayout();
            this.tabPageVideo.ResumeLayout(false);
            this.groupBoxGraphics.ResumeLayout(false);
            this.groupBoxGraphics.PerformLayout();
            this.groupBoxDOF.ResumeLayout(false);
            this.groupBoxDOF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDOFStrength)).EndInit();
            this.contextMenuStripOverallQualityPresets.ResumeLayout(false);
            this.groupBoxTextures.ResumeLayout(false);
            this.groupBoxTextures.PerformLayout();
            this.groupBoxGraphicEffects.ResumeLayout(false);
            this.groupBoxGraphicEffects.PerformLayout();
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
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomResH)).EndInit();
            this.tabPageAudio.ResumeLayout(false);
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.groupBoxVoice.ResumeLayout(false);
            this.groupBoxVoice.PerformLayout();
            this.groupBoxAudioVolume.ResumeLayout(false);
            this.groupBoxAudioVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolumeMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudioChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAudiofVal3)).EndInit();
            this.tabPageControls.ResumeLayout(false);
            this.groupBoxGamepad.ResumeLayout(false);
            this.groupBoxGamepad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamepadSensitivityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamepadSensitivityX)).EndInit();
            this.groupBoxMouse.ResumeLayout(false);
            this.groupBoxMouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseSensitivityX)).EndInit();
            this.tabPageCamera.ResumeLayout(false);
            this.groupBoxCameraPosition.ResumeLayout(false);
            this.groupBoxCameraPosition.PerformLayout();
            this.groupBoxMeleeCombatCameraPosition.ResumeLayout(false);
            this.groupBoxMeleeCombatCameraPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatAddY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderMeleeCombatPosZ)).EndInit();
            this.groupBoxCombatCameraPosition.ResumeLayout(false);
            this.groupBoxCombatCameraPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatAddY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderCombatPosZ)).EndInit();
            this.groupBoxUnarmedCameraPosition.ResumeLayout(false);
            this.groupBoxUnarmedCameraPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numfOverShoulderPosZ)).EndInit();
            this.groupBoxFOVMore.ResumeLayout(false);
            this.groupBoxFOVMore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numADSFOV)).EndInit();
            this.groupBoxSelfieCamera.ResumeLayout(false);
            this.groupBoxSelfieCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeRotationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhotomodeTranslationSpeed)).EndInit();
            this.groupBoxIdleCamera.ResumeLayout(false);
            this.groupBoxIdleCamera.PerformLayout();
            this.groupBoxCameraDistance.ResumeLayout(false);
            this.groupBoxCameraDistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numfPitchZoomOutMaxDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraDistanceMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraDistanceMinimum)).EndInit();
            this.groupBoxFieldOfView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFOVPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFOV)).EndInit();
            this.tabPageLogin.ResumeLayout(false);
            this.groupBoxLoginProfiles.ResumeLayout(false);
            this.groupBoxLoginProfiles.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fo76ini.Controls.StyledTabControl tabControlTweaks;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.TabPage tabPageControls;
        private System.Windows.Forms.TabPage tabPageCamera;
        private Fo76ini.Controls.StyledGroupBox groupBoxGamepad;
        private System.Windows.Forms.CheckBox checkBoxGamepadEnabled;
        private System.Windows.Forms.CheckBox checkBoxGamepadRumble;
        private Fo76ini.Controls.StyledGroupBox groupBoxMouse;
        private System.Windows.Forms.CheckBox checkBoxMouseInvertX;
        private System.Windows.Forms.CheckBox checkBoxMouseInvertY;
        private ColorSlider.ColorSlider sliderMouseSensitivityX;
        private System.Windows.Forms.CheckBox checkBoxFixAimSensitivity;
        private System.Windows.Forms.NumericUpDown numMouseSensitivityX;
        private System.Windows.Forms.Label labelMouseSensitivityX;
        private System.Windows.Forms.CheckBox checkBoxFixMouseSensitivity;
        private System.Windows.Forms.Label labelTweaksDesc;
        private System.Windows.Forms.Label labelTweaksTitle;
        private System.Windows.Forms.TabPage tabPageLogin;
        private Fo76ini.Controls.StyledGroupBox groupBoxLogin;
        private Fo76ini.Controls.StyledGroupBox groupBoxLoginProfiles;
        private System.Windows.Forms.RadioButton radioButtonAccountNone;
        private System.Windows.Forms.RadioButton radioButtonAccount1;
        private System.Windows.Forms.RadioButton radioButtonAccount16;
        private System.Windows.Forms.RadioButton radioButtonAccount2;
        private System.Windows.Forms.RadioButton radioButtonAccount15;
        private System.Windows.Forms.RadioButton radioButtonAccount3;
        private System.Windows.Forms.RadioButton radioButtonAccount14;
        private System.Windows.Forms.RadioButton radioButtonAccount4;
        private System.Windows.Forms.RadioButton radioButtonAccount13;
        private System.Windows.Forms.RadioButton radioButtonAccount5;
        private System.Windows.Forms.RadioButton radioButtonAccount12;
        private System.Windows.Forms.RadioButton radioButtonAccount6;
        private System.Windows.Forms.RadioButton radioButtonAccount11;
        private System.Windows.Forms.RadioButton radioButtonAccount7;
        private System.Windows.Forms.RadioButton radioButtonAccount10;
        private System.Windows.Forms.RadioButton radioButtonAccount8;
        private System.Windows.Forms.RadioButton radioButtonAccount9;
        private System.Windows.Forms.CheckBox checkBoxAutoSignin;
        private System.Windows.Forms.CheckBox checkBoxEnableSteam;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private Fo76ini.Controls.StyledGroupBox groupBoxLoading;
        private System.Windows.Forms.CheckBox checkBoxFasterFadeIn;
        private System.Windows.Forms.CheckBox checkBoxShowFloatingQuestText;
        private System.Windows.Forms.CheckBox checkBoxShowDamageNumbers;
        private System.Windows.Forms.CheckBox checkBoxShowPublicTeamNotifications;
        private System.Windows.Forms.CheckBox checkBoxShowOtherPlayersNames;
        private System.Windows.Forms.CheckBox checkBoxShowFloatingQuestMarkers;
        private System.Windows.Forms.CheckBox checkBoxEnablePowerArmorHUD;
        private System.Windows.Forms.NumericUpDown numFloatingQuestMarkersDistance;
        private System.Windows.Forms.Label labelFloatingQuestMarkersDistance;
        private System.Windows.Forms.Label labelShowActiveEffectsOnHUD;
        private ColorSlider.ColorSlider sliderFloatingQuestMarkersDistance;
        private System.Windows.Forms.CheckBox checkBoxShowCrosshair;
        private System.Windows.Forms.CheckBox checkBoxShowCompass;
        private System.Windows.Forms.NumericUpDown numHUDOpacity;
        private ColorSlider.ColorSlider sliderHUDOpacity;
        private System.Windows.Forms.Label labelHUDOpacity;
        private System.Windows.Forms.ComboBox comboBoxShowActiveEffectsOnHUD;
        private Fo76ini.Controls.StyledGroupBox groupBoxQuests;
        private System.Windows.Forms.CheckBox checkBoxEnableQuestAutoTrackDaily;
        private System.Windows.Forms.CheckBox checkBoxEnableQuestAutoTrackEvent;
        private System.Windows.Forms.CheckBox checkBoxEnableQuestAutoTrackMisc;
        private System.Windows.Forms.CheckBox checkBoxEnableQuestAutoTrackSide;
        private System.Windows.Forms.CheckBox checkBoxEnableQuestAutoTrackMain;
        private Fo76ini.Controls.StyledGroupBox groupBoxMainMenu;
        private System.Windows.Forms.CheckBox checkBoxSkipSplash;
        private System.Windows.Forms.CheckBox checkBoxSkipIntroVideos;
        private Fo76ini.Controls.StyledGroupBox groupBoxDisplay;
        private System.Windows.Forms.ComboBox comboBoxDisplayMode;
        private System.Windows.Forms.CheckBox checkBoxFixHUDFor5_4and4_3;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Button buttonDetectResolution;
        private System.Windows.Forms.Label labelCustomResolution;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.CheckBox checkBoxTopMostWindow;
        private System.Windows.Forms.NumericUpDown numCustomResW;
        private System.Windows.Forms.NumericUpDown numCustomResH;
        private System.Windows.Forms.Label labelDisplayMode;
        private System.Windows.Forms.Label labelCustomResolutionSpacer;
        private Fo76ini.Controls.StyledGroupBox groupBoxAudioVolume;
        private ColorSlider.ColorSlider sliderAudioChat;
        private ColorSlider.ColorSlider sliderAudiofVal6;
        private ColorSlider.ColorSlider sliderAudiofVal5;
        private ColorSlider.ColorSlider sliderAudiofVal4;
        private ColorSlider.ColorSlider sliderAudiofVal3;
        private ColorSlider.ColorSlider sliderAudiofVal2;
        private ColorSlider.ColorSlider sliderAudiofVal1;
        private System.Windows.Forms.Label labelVolumeMaster;
        private ColorSlider.ColorSlider sliderVolumeMaster;
        private System.Windows.Forms.NumericUpDown numVolumeMaster;
        private System.Windows.Forms.NumericUpDown numAudioChat;
        private ColorSlider.ColorSlider sliderAudiofVal0;
        private System.Windows.Forms.Label labelAudioChat;
        private System.Windows.Forms.Label labelAudiofVal0;
        private System.Windows.Forms.NumericUpDown numAudiofVal0;
        private System.Windows.Forms.NumericUpDown numAudiofVal6;
        private System.Windows.Forms.Label labelAudiofVal6;
        private System.Windows.Forms.Label labelAudiofVal1;
        private System.Windows.Forms.NumericUpDown numAudiofVal1;
        private System.Windows.Forms.NumericUpDown numAudiofVal5;
        private System.Windows.Forms.Label labelAudiofVal5;
        private System.Windows.Forms.Label labelAudiofVal2;
        private System.Windows.Forms.NumericUpDown numAudiofVal2;
        private System.Windows.Forms.NumericUpDown numAudiofVal4;
        private System.Windows.Forms.Label labelAudiofVal4;
        private System.Windows.Forms.Label labelAudiofVal3;
        private System.Windows.Forms.NumericUpDown numAudiofVal3;
        private Fo76ini.Controls.StyledGroupBox groupBoxAudio;
        private System.Windows.Forms.CheckBox checkBoxEnableAudio;
        private System.Windows.Forms.CheckBox checkBoxMainMenuMusic;
        private Fo76ini.Controls.StyledGroupBox groupBoxVoice;
        private System.Windows.Forms.ComboBox comboBoxVoiceChatMode;
        private System.Windows.Forms.Label labelVoiceChatMode;
        private System.Windows.Forms.CheckBox checkBoxPushToTalk;
        private Fo76ini.Controls.StyledGroupBox groupBoxGraphics;
        private Fo76ini.Controls.StyledGroupBox groupBoxGraphicEffects;
        private System.Windows.Forms.CheckBox checkBoxDisableGore;
        private Fo76ini.Controls.StyledGroupBox groupBoxTAASharpening;
        private ColorSlider.ColorSlider sliderTAAPostSharpen;
        private System.Windows.Forms.Label labelTAAPostSharpen;
        private System.Windows.Forms.NumericUpDown numTAAPostSharpen;
        private ColorSlider.ColorSlider sliderTAAPostOverlay;
        private System.Windows.Forms.NumericUpDown numTAAPostOverlay;
        private System.Windows.Forms.Label labelTAAPostOverlay;
        private System.Windows.Forms.Label labelAntiAliasing;
        private Fo76ini.Controls.StyledGroupBox groupBoxGrass;
        private ColorSlider.ColorSlider sliderGrassFadeDistance;
        private System.Windows.Forms.NumericUpDown numGrassFadeDistance;
        private System.Windows.Forms.Label labelGrassFadeDistance;
        private System.Windows.Forms.CheckBox checkBoxGrass;
        private System.Windows.Forms.ComboBox comboBoxAntiAliasing;
        private Fo76ini.Controls.StyledGroupBox groupBoxLOD;
        private ColorSlider.ColorSlider sliderLODActors;
        private System.Windows.Forms.Label labelLODFadeDistance;
        private ColorSlider.ColorSlider sliderLODItems;
        private System.Windows.Forms.NumericUpDown numLODActors;
        private System.Windows.Forms.NumericUpDown numLODItems;
        private ColorSlider.ColorSlider sliderLODObjects;
        private System.Windows.Forms.NumericUpDown numLODObjects;
        private System.Windows.Forms.Label labelLODActors;
        private System.Windows.Forms.Label labelLODItems;
        private System.Windows.Forms.Label labelLODObjects;
        private System.Windows.Forms.CheckBox checkBoxVSync;
        private Fo76ini.Controls.StyledGroupBox groupBoxLighting;
        private System.Windows.Forms.CheckBox checkBoxGodrays;
        private System.Windows.Forms.Label labelAnisotropicFiltering;
        private Fo76ini.Controls.StyledGroupBox groupBoxShadows;
        private ColorSlider.ColorSlider sliderShadowDistance;
        private System.Windows.Forms.ComboBox comboBoxShadowBlurriness;
        private System.Windows.Forms.Label labelShadowBlurriness;
        private System.Windows.Forms.NumericUpDown numShadowDistance;
        private System.Windows.Forms.Label labelShadowDistance;
        private System.Windows.Forms.ComboBox comboBoxShadowTextureResolution;
        private System.Windows.Forms.Label labelShadowTextureResolution;
        private System.Windows.Forms.ComboBox comboBoxAnisotropicFiltering;
        private Fo76ini.Controls.StyledGroupBox groupBoxWater;
        private System.Windows.Forms.CheckBox checkBoxWaterDisplacement;
        private Fo76ini.Controls.StyledGroupBox groupBoxPostProcessing;
        private System.Windows.Forms.CheckBox checkBoxAmbientOcclusion;
        private System.Windows.Forms.CheckBox checkBoxDepthOfField;
        private System.Windows.Forms.CheckBox checkBoxRadialBlur;
        private System.Windows.Forms.CheckBox checkBoxLensFlare;
        private Fo76ini.Controls.StyledGroupBox groupBoxFieldOfView;
        private System.Windows.Forms.PictureBox pictureBoxFOVPreview;
        private ColorSlider.ColorSlider sliderFOV;
        private System.Windows.Forms.NumericUpDown numFOV;
        private Fo76ini.Controls.StyledGroupBox groupBoxFOVMore;
        private System.Windows.Forms.Label labelADSFOV;
        private System.Windows.Forms.NumericUpDown numADSFOV;
        private Fo76ini.Controls.StyledGroupBox groupBoxSelfieCamera;
        private ColorSlider.ColorSlider trackBarPhotomodeRange;
        private System.Windows.Forms.NumericUpDown numericUpDownPhotomodeRotationSpeed;
        private ColorSlider.ColorSlider trackBarPhotomodeRotationSpeed;
        private System.Windows.Forms.Label labelPhotomodeRotationSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownPhotomodeRange;
        private System.Windows.Forms.Label labelPhotomodeRange;
        private System.Windows.Forms.NumericUpDown numericUpDownPhotomodeTranslationSpeed;
        private ColorSlider.ColorSlider trackBarPhotomodeTranslationSpeed;
        private System.Windows.Forms.Label labelPhotomodeTranslationSpeed;
        private Fo76ini.Controls.StyledGroupBox groupBoxCameraDistance;
        private System.Windows.Forms.NumericUpDown numfPitchZoomOutMaxDist;
        private ColorSlider.ColorSlider sliderfPitchZoomOutMaxDist;
        private System.Windows.Forms.Label labelPitchZoomOutMaxDist;
        private System.Windows.Forms.NumericUpDown numCameraDistanceMaximum;
        private System.Windows.Forms.NumericUpDown numCameraDistanceMinimum;
        private ColorSlider.ColorSlider sliderCameraDistanceMaximum;
        private System.Windows.Forms.Label labelCameraDistanceMaximum;
        private System.Windows.Forms.Label labelCameraDistanceMinimum;
        private ColorSlider.ColorSlider sliderCameraDistanceMinimum;
        private Fo76ini.Controls.StyledGroupBox groupBoxCameraPosition;
        private Fo76ini.Controls.StyledGroupBox groupBoxMeleeCombatCameraPosition;
        private System.Windows.Forms.NumericUpDown numfOverShoulderMeleeCombatAddY;
        private System.Windows.Forms.Label labelfOverShoulderMeleeCombatAddY;
        private System.Windows.Forms.NumericUpDown numfOverShoulderMeleeCombatPosX;
        private System.Windows.Forms.NumericUpDown numfOverShoulderMeleeCombatPosZ;
        private ColorSlider.ColorSlider trackBarfOverShoulderMeleeCombatAddY;
        private System.Windows.Forms.Label labelfOverShoulderMeleeCombatPosX;
        private ColorSlider.ColorSlider trackBarfOverShoulderMeleeCombatPosX;
        private System.Windows.Forms.Label labelfOverShoulderMeleeCombatPosZ;
        private ColorSlider.ColorSlider trackBarfOverShoulderMeleeCombatPosZ;
        private Fo76ini.Controls.StyledGroupBox groupBoxCombatCameraPosition;
        private System.Windows.Forms.NumericUpDown numfOverShoulderCombatAddY;
        private System.Windows.Forms.NumericUpDown numfOverShoulderCombatPosX;
        private System.Windows.Forms.NumericUpDown numfOverShoulderCombatPosZ;
        private System.Windows.Forms.Label labelfOverShoulderCombatAddY;
        private ColorSlider.ColorSlider trackBarfOverShoulderCombatAddY;
        private System.Windows.Forms.Label labelfOverShoulderCombatPosX;
        private ColorSlider.ColorSlider trackBarfOverShoulderCombatPosX;
        private System.Windows.Forms.Label labelfOverShoulderCombatPosZ;
        private ColorSlider.ColorSlider trackBarfOverShoulderCombatPosZ;
        private System.Windows.Forms.Button buttonCameraPositionReset;
        private System.Windows.Forms.CheckBox checkBoxbApplyCameraNodeAnimations;
        private Fo76ini.Controls.StyledGroupBox groupBoxUnarmedCameraPosition;
        private System.Windows.Forms.NumericUpDown numfOverShoulderPosX;
        private System.Windows.Forms.NumericUpDown numfOverShoulderPosZ;
        private System.Windows.Forms.Label labelfOverShoulderPosX;
        private ColorSlider.ColorSlider trackBarfOverShoulderPosX;
        private System.Windows.Forms.Label labelfOverShoulderPosZ;
        private ColorSlider.ColorSlider trackBarfOverShoulderPosZ;
        private Controls.CustomToolTip toolTip;
        private System.Windows.Forms.TabPage tabPageTweaksInfo;
        private System.Windows.Forms.CheckBox checkBoxSSReflections;
        private System.Windows.Forms.CheckBox checkBoxBloodSplatter;
        private ColorSlider.ColorSlider sliderMouseSensitivityY;
        private System.Windows.Forms.NumericUpDown numMouseSensitivityY;
        private System.Windows.Forms.Label labelMouseSensitivityY;
        private Fo76ini.Controls.StyledGroupBox groupBoxDialogue;
        private ColorSlider.ColorSlider sliderConversationHistorySize;
        private System.Windows.Forms.NumericUpDown numConversationHistorySize;
        private System.Windows.Forms.Label labelConversationHistorySize;
        private System.Windows.Forms.CheckBox checkBoxDialogueHistory;
        private System.Windows.Forms.CheckBox checkBoxDialogueSubtitles;
        private System.Windows.Forms.CheckBox checkBoxGeneralSubtitles;
        private Fo76ini.Controls.StyledGroupBox groupBoxHUD;
        private Fo76ini.Controls.StyledGroupBox groupBoxGameplay;
        private System.Windows.Forms.CheckBox checkBoxBackpackVisible;
        private System.Windows.Forms.Label labelHighlightCorpses;
        private System.Windows.Forms.ComboBox comboBoxHighlightCorpses;
        private Fo76ini.Controls.StyledGroupBox groupBoxFloatingQuestMarkers;
        private System.Windows.Forms.CheckBox checkBoxAimAssist;
        private System.Windows.Forms.RichTextBox richTextBoxCredentialsExplanation;
        private Fo76ini.Controls.StyledGroupBox groupBoxIdleCamera;
        private System.Windows.Forms.CheckBox checkBoxForceVanityMode;
        private System.Windows.Forms.CheckBox checkBoxVanityMode;
        private System.Windows.Forms.CheckBox checkBoxMotionBlur;
        private System.Windows.Forms.CheckBox checkBoxWaterReflections;
        private System.Windows.Forms.CheckBox checkBoxWaterHiRes;
        private System.Windows.Forms.CheckBox checkBoxWaterRefractions;
        private System.Windows.Forms.CheckBox checkBoxWaterFixSSRGlitch;
        private System.Windows.Forms.Button buttonOpenTweaksInfoInBrowser;
        private System.Windows.Forms.Label labelTweaksInfoWin7;
        private ColorSlider.ColorSlider sliderGamepadSensitivityY;
        private System.Windows.Forms.NumericUpDown numGamepadSensitivityY;
        private System.Windows.Forms.Label labelGamepadSensitivityY;
        private ColorSlider.ColorSlider sliderGamepadSensitivityX;
        private System.Windows.Forms.NumericUpDown numGamepadSensitivityX;
        private System.Windows.Forms.Label labelGamepadSensitivityX;
        private Fo76ini.Controls.StyledGroupBox groupBoxTextures;
        private System.Windows.Forms.ComboBox comboBoxTextureQuality;
        private System.Windows.Forms.Label labelTextureQuality;
        private System.Windows.Forms.ComboBox comboBoxShadowQuality;
        private System.Windows.Forms.Label labelShadowQuality;
        private System.Windows.Forms.ComboBox comboBoxGodrayQuality;
        private System.Windows.Forms.Label labelGodrayQuality;
        private System.Windows.Forms.ComboBox comboBoxWaterShadowFilter;
        private System.Windows.Forms.Label labelWaterShadowFilter;
        private System.Windows.Forms.Button buttonSelectOverallQualityPreset;
        private System.Windows.Forms.Label labelOverallQualityPreset;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripOverallQualityPresets;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Label labelSelectedQualityPreset;
        private Fo76ini.Controls.StyledGroupBox groupBoxDOF;
        private System.Windows.Forms.NumericUpDown numDOFStrength;
        private System.Windows.Forms.Label labelDOFStrength;
        private ColorSlider.ColorSlider sliderDOFStrength;
        private CefSharp.WinForms.ChromiumWebBrowser webBrowserTweaksInfo;
    }
}
