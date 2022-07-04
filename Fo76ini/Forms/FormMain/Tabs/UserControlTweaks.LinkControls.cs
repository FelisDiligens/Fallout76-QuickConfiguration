using Fo76ini.Tweaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fo76ini.Tweaks.Audio;
using Fo76ini.Tweaks.Camera;
using Fo76ini.Tweaks.Colors;
using Fo76ini.Tweaks.Controls;
using Fo76ini.Tweaks.General;
using Fo76ini.Tweaks.Graphics;
using Fo76ini.Tweaks.Interface;
using Fo76ini.Tweaks.Pipboy;
using Fo76ini.Tweaks.Video;
using Fo76ini.Tweaks.Volume;

namespace Fo76ini.Forms.FormMain
{
    /*
     * A bit similar to the *.Designer.cs, adds event handlers to (almost) all controls.
     * That is, instantiate classes that implement ITweak, and link the controls to it's value (among other things).
     */
    public partial class UserControlTweaks : UserControl
    {
        /// <summary>
        /// Adds tooltip information (ITweakInfo)
        /// </summary>
        public void LinkInfo()
        {
            // Info tab
            /*LinkedTweaks.LinkInfo(checkBoxReadOnly, iniReadOnlyTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoApply, autoApplyTweak);
            LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, ignoreUpdatesTweak);
            LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, playNotificationSoundsTweak);
            LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolQuitOnLaunchTweak);*/

            // General tab
            LinkedTweaks.LinkInfo(checkBoxEnableSteam, toolTip, enableSteamTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoSignin, toolTip, autoSigninTweak);
            LinkedTweaks.LinkInfo(checkBoxSkipIntroVideos, toolTip, introVideoTweak);
            LinkedTweaks.LinkInfo(checkBoxSkipSplash, toolTip, skipStartupSplash);

            LinkedTweaks.LinkInfo(checkBoxFasterFadeIn, toolTip, fasterFadeInTweak);

            LinkedTweaks.LinkInfo(checkBoxShowDamageNumbersNW, toolTip, showDamageNumbersNuclearWinterTweak);
            LinkedTweaks.LinkInfo(checkBoxShowDamageNumbersA, toolTip, showDamageNumbersAdventureTweak);
            LinkedTweaks.LinkInfo(checkBoxItemRarityColorsNW, toolTip, enableItemRarityColorsTweak);
            LinkedTweaks.LinkInfo(checkBoxShowPublicTeamNotifications, toolTip, showPublicTeamNotificationsTweak);
            LinkedTweaks.LinkInfo(checkBoxShowFloatingQuestMarkers, toolTip, showFloatingQuestMarkersTweak);
            LinkedTweaks.LinkInfo(checkBoxShowFloatingQuestText, toolTip, showFloatingQuestTextTweak);
            LinkedTweaks.LinkInfo(checkBoxShowCrosshair, toolTip, showCrosshairTweak);
            LinkedTweaks.LinkInfo(checkBoxEnablePowerArmorHUD, toolTip, enablePowerArmorHUDTweak);
            LinkedTweaks.LinkInfo(checkBoxShowCompass, toolTip, showCompassTweak);
            LinkedTweaks.LinkInfo(checkBoxShowOtherPlayersNames, toolTip, showOtherPlayersNamesTweak);
            LinkedTweaks.LinkInfo(comboBoxShowActiveEffectsOnHUD, toolTip, activeEffectsOnHUDTweak);
            LinkedTweaks.LinkInfo(labelShowActiveEffectsOnHUD, toolTip, activeEffectsOnHUDTweak);
            LinkedTweaks.LinkInfo(numFloatingQuestMarkersDistance, toolTip, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(sliderFloatingQuestMarkersDistance, toolTip, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(labelFloatingQuestMarkersDistance, toolTip, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(numHUDOpacity, toolTip, hudOpacityTweak);
            LinkedTweaks.LinkInfo(sliderHUDOpacity, toolTip, hudOpacityTweak);
            LinkedTweaks.LinkInfo(labelHUDOpacity, toolTip, hudOpacityTweak);

            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackMain, toolTip, autoTrackMainQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackSide, toolTip, autoTrackSideQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackMisc, toolTip, autoTrackMiscQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackEvent, toolTip, autoTrackEventQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackDaily, toolTip, autoTrackOtherQuestWhenStartedTweak);

            // Video tab
            LinkedTweaks.LinkInfo(numCustomResW, toolTip, displaySizeTweak);
            LinkedTweaks.LinkInfo(numCustomResH, toolTip, displaySizeTweak);
            LinkedTweaks.LinkInfo(labelResolution, toolTip, displaySizeTweak);
            LinkedTweaks.LinkInfo(labelCustomResolution, toolTip, displaySizeTweak);
            LinkedTweaks.LinkInfo(comboBoxResolution, toolTip, displaySizeTweak);
            LinkedTweaks.LinkInfo(comboBoxDisplayMode, toolTip, displayModeTweak);
            LinkedTweaks.LinkInfo(labelDisplayMode, toolTip, displayModeTweak);
            LinkedTweaks.LinkInfo(checkBoxVSync, toolTip, presentIntervalTweak);
            LinkedTweaks.LinkInfo(checkBoxAlwaysActive, toolTip, windowAlwaysActiveTweak);
            LinkedTweaks.LinkInfo(checkBoxTopMostWindow, toolTip, topMostWindowTweak);
            LinkedTweaks.LinkInfo(checkBoxFixHUDFor5_4and4_3, toolTip, fixHUD4to3RatioTweak);

            // Graphics:
            LinkedTweaks.LinkInfo(labelAntiAliasing, toolTip, antiAliasingTweak);
            LinkedTweaks.LinkInfo(comboBoxAntiAliasing, toolTip, antiAliasingTweak);
            LinkedTweaks.LinkInfo(labelAnisotropicFiltering, toolTip, anisotropicFilteringTweak);
            LinkedTweaks.LinkInfo(comboBoxAnisotropicFiltering, toolTip, anisotropicFilteringTweak);
            LinkedTweaks.LinkInfo(checkBoxDepthOfField, toolTip, enableDepthOfFieldTweak);
            LinkedTweaks.LinkInfo(checkBoxMotionBlur, toolTip, motionBlurTweak);
            LinkedTweaks.LinkInfo(checkBoxRadialBlur, toolTip, radialBlurTweak);
            LinkedTweaks.LinkInfo(checkBoxLensFlare, toolTip, lensFlareTweak);
            LinkedTweaks.LinkInfo(checkBoxAmbientOcclusion, toolTip, ambientOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxWaterDisplacement, toolTip, waterDisplacementsTweak);
            LinkedTweaks.LinkInfo(checkBoxFogEnabled, toolTip, fogTweak);
            LinkedTweaks.LinkInfo(checkBoxWeatherRainOcclusion, toolTip, rainOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxWeatherWetnessOcclusion, toolTip, wetnessOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxGodrays, toolTip, volumetricLightingTweak);
            LinkedTweaks.LinkInfo(checkBoxDisableGore, toolTip, disableAllGoreTweak);
            LinkedTweaks.LinkInfo(labelShadowTextureResolution, toolTip, shadowMapResolutionTweak);
            LinkedTweaks.LinkInfo(comboBoxShadowTextureResolution, toolTip, shadowMapResolutionTweak);
            LinkedTweaks.LinkInfo(comboBoxShadowBlurriness, toolTip, shadowBlurrinessTweak);
            LinkedTweaks.LinkInfo(labelShadowBlurriness, toolTip, shadowBlurrinessTweak);
            LinkedTweaks.LinkInfo(numShadowDistance, toolTip, shadowDistanceTweak);
            LinkedTweaks.LinkInfo(sliderShadowDistance, toolTip, shadowDistanceTweak);
            LinkedTweaks.LinkInfo(numLODObjects, toolTip, lodFadeOutMultObjectsTweak);
            LinkedTweaks.LinkInfo(numLODItems, toolTip, lodFadeOutMultItemsTweak);
            LinkedTweaks.LinkInfo(numLODActors, toolTip, lodFadeOutMultActorsTweak);
            LinkedTweaks.LinkInfo(sliderLODObjects, toolTip, lodFadeOutMultObjectsTweak);
            LinkedTweaks.LinkInfo(sliderLODItems, toolTip, lodFadeOutMultItemsTweak);
            LinkedTweaks.LinkInfo(sliderLODActors, toolTip, lodFadeOutMultActorsTweak);
            LinkedTweaks.LinkInfo(checkBoxGrass, toolTip, enableGrassTweak);
            LinkedTweaks.LinkInfo(numTAAPostOverlay, toolTip, taaPostOverlayTweak);
            LinkedTweaks.LinkInfo(numTAAPostSharpen, toolTip, taaPostSharpenTweak);
            LinkedTweaks.LinkInfo(sliderTAAPostOverlay, toolTip, taaPostOverlayTweak);
            LinkedTweaks.LinkInfo(sliderTAAPostSharpen, toolTip, taaPostSharpenTweak);
            LinkedTweaks.LinkInfo(numGrassFadeDistance, toolTip, grassFadeDistanceTweak);

            // Audio tab
            LinkedTweaks.LinkInfo(checkBoxEnableAudio, toolTip, enableAudioTweak);
            LinkedTweaks.LinkInfo(checkBoxMainMenuMusic, toolTip, playMainMenuMusicTweak);
            LinkedTweaks.LinkInfo(comboBoxVoiceChatMode, toolTip, voiceChatModeTweak);
            LinkedTweaks.LinkInfo(labelVoiceChatMode, toolTip, voiceChatModeTweak);
            LinkedTweaks.LinkInfo(checkBoxGeneralSubtitles, toolTip, generalSubtitlesTweak);
            LinkedTweaks.LinkInfo(checkBoxDialogueSubtitles, toolTip, dialogueSubtitlesTweak);
            LinkedTweaks.LinkInfo(checkBoxDialogueHistory, toolTip, showDialogueHistoryTweak);
            LinkedTweaks.LinkInfo(checkBoxPushToTalk, toolTip, voicePushToTalkEnabledTweak);
            LinkedTweaks.LinkInfo(numConversationHistorySize, toolTip, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(sliderConversationHistorySize, toolTip, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(labelConversationHistorySize, toolTip, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(numVolumeMaster, toolTip, masterVolumeTweak);
            LinkedTweaks.LinkInfo(numAudioChat, toolTip, vivoxVoiceVolumeTweak);
            LinkedTweaks.LinkInfo(sliderVolumeMaster, toolTip, masterVolumeTweak);
            LinkedTweaks.LinkInfo(sliderAudioChat, toolTip, vivoxVoiceVolumeTweak);

            // Volume:
            LinkedTweaks.LinkInfo(labelVolumeMaster, toolTip, masterVolumeTweak);
            LinkedTweaks.LinkInfo(labelAudioChat, toolTip, vivoxVoiceVolumeTweak);

            LinkedTweaks.LinkInfo(numAudiofVal0, toolTip, val0Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal1, toolTip, val1Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal2, toolTip, val2Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal3, toolTip, val3Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal4, toolTip, val4Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal5, toolTip, val5Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal6, toolTip, val6Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal0, toolTip, val0Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal1, toolTip, val1Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal2, toolTip, val2Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal3, toolTip, val3Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal4, toolTip, val4Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal5, toolTip, val5Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal6, toolTip, val6Tweak);

            // Controls tab
            LinkedTweaks.LinkInfo(numMouseSensitivity, toolTip, mouseSensitivityTweak);
            LinkedTweaks.LinkInfo(sliderMouseSensitivity, toolTip, mouseSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxFixMouseSensitivity, toolTip, fixMouseSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxFixAimSensitivity, toolTip, fixAimSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseAcceleration, toolTip, mouseAccelerationTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseInvertX, toolTip, mouseInvertXTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseInvertY, toolTip, mouseInvertYTweak);
            LinkedTweaks.LinkInfo(checkBoxGamepadEnabled, toolTip, gamepadEnableTweak);
            LinkedTweaks.LinkInfo(checkBoxGamepadRumble, toolTip, enableGamepadRumbleTweak);

            // Camera tab
            LinkedTweaks.LinkInfo(this.checkBoxbApplyCameraNodeAnimations, toolTip, applyCameraNodeAnimationsTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderPosX, toolTip, cameraOverShoulderPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderPosZ, toolTip, cameraOverShoulderPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatPosX, toolTip, cameraOverShoulderCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatPosZ, toolTip, cameraOverShoulderCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatAddY, toolTip, cameraOverShoulderCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatPosX, toolTip, cameraOverShoulderMeleeCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatPosZ, toolTip, cameraOverShoulderMeleeCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatAddY, toolTip, cameraOverShoulderMeleeCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderPosX, toolTip, cameraOverShoulderPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderPosZ, toolTip, cameraOverShoulderPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatPosX, toolTip, cameraOverShoulderCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatPosZ, toolTip, cameraOverShoulderCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatAddY, toolTip, cameraOverShoulderCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatPosX, toolTip, cameraOverShoulderMeleeCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatPosZ, toolTip, cameraOverShoulderMeleeCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatAddY, toolTip, cameraOverShoulderMeleeCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeRange, toolTip, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeTranslationSpeed, toolTip, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeRotationSpeed, toolTip, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeRange, toolTip, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeTranslationSpeed, toolTip, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeRotationSpeed, toolTip, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeRange, toolTip, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeTranslationSpeed, toolTip, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeRotationSpeed, toolTip, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.checkBoxVanityMode, toolTip, disableAutoVanityModeTweak);
            LinkedTweaks.LinkInfo(this.checkBoxForceVanityMode, toolTip, forceAutoVanityModeTweak);
            LinkedTweaks.LinkInfo(this.numCameraSwitchDelay, toolTip, firstThirdPerspectiveSwitchDelayTweak);
            LinkedTweaks.LinkInfo(this.labelSwitchDelay, toolTip, firstThirdPerspectiveSwitchDelayTweak);
            LinkedTweaks.LinkInfo(numFirstPersonFOV, toolTip, fov1stPersonTweak);
            LinkedTweaks.LinkInfo(numADSFOV, toolTip, fov3rdADSTweak);
            LinkedTweaks.LinkInfo(numfDefaultFOV, toolTip, defaultFOVTweak);
            LinkedTweaks.LinkInfo(labelFirstPersonFOV, toolTip, fov1stPersonTweak);
            LinkedTweaks.LinkInfo(numFOV, toolTip, fovTweak);
            LinkedTweaks.LinkInfo(sliderFOV, toolTip, fovTweak);
            LinkedTweaks.LinkInfo(labelADSFOV, toolTip, fov3rdADSTweak);
            LinkedTweaks.LinkInfo(labelfDefaultFOV, toolTip, defaultFOVTweak);
            LinkedTweaks.LinkInfo(numCameraDistanceMinimum, toolTip, vanityModeMinDistTweak);
            LinkedTweaks.LinkInfo(numCameraDistanceMaximum, toolTip, vanityModeMaxDistTweak);
            LinkedTweaks.LinkInfo(numfPitchZoomOutMaxDist, toolTip, pitchZoomOutMaxDistTweak);
            LinkedTweaks.LinkInfo(labelCameraDistanceMinimum, toolTip, vanityModeMinDistTweak);
            LinkedTweaks.LinkInfo(labelCameraDistanceMaximum, toolTip, vanityModeMaxDistTweak);
            LinkedTweaks.LinkInfo(labelPitchZoomOutMaxDist, toolTip, pitchZoomOutMaxDistTweak);
        }

        /// <summary>
        /// Links trackbars to numericupdowns (and vice-versa)
        /// </summary>
        public void LinkSliders()
        {
            // Link numericUpDown and sliders:
            LinkedTweaks.LinkSlider(this.sliderGrassFadeDistance, this.numGrassFadeDistance, 1);
            //LinkSlider(this.sliderGrassDensity, this.numGrassDensity, 1, true);
            LinkedTweaks.LinkSlider(this.sliderLODObjects, this.numLODObjects, 10);
            LinkedTweaks.LinkSlider(this.sliderLODItems, this.numLODItems, 10);
            LinkedTweaks.LinkSlider(this.sliderLODActors, this.numLODActors, 10);
            LinkedTweaks.LinkSlider(this.sliderShadowDistance, this.numShadowDistance, 1);
            LinkedTweaks.LinkSlider(this.sliderMouseSensitivity, this.numMouseSensitivity, 10000.0);
            LinkedTweaks.LinkSlider(this.sliderTAAPostOverlay, this.numTAAPostOverlay, 100);
            LinkedTweaks.LinkSlider(this.sliderTAAPostSharpen, this.numTAAPostSharpen, 100);

            LinkedTweaks.LinkSlider(this.sliderVolumeMaster, this.numVolumeMaster, 100);
            LinkedTweaks.LinkSlider(this.sliderAudioChat, this.numAudioChat, 1);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal0, this.numAudiofVal0, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal1, this.numAudiofVal1, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal2, this.numAudiofVal2, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal3, this.numAudiofVal3, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal4, this.numAudiofVal4, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal5, this.numAudiofVal5, 100);
            LinkedTweaks.LinkSlider(this.sliderAudiofVal6, this.numAudiofVal6, 100);

            LinkedTweaks.LinkSlider(this.sliderFloatingQuestMarkersDistance, this.numFloatingQuestMarkersDistance, 10);
            LinkedTweaks.LinkSlider(this.sliderConversationHistorySize, this.numConversationHistorySize, 1);
            LinkedTweaks.LinkSlider(this.sliderHUDOpacity, this.numHUDOpacity, 100);

            LinkedTweaks.LinkSlider(this.sliderCameraDistanceMinimum, this.numCameraDistanceMinimum, 1);
            LinkedTweaks.LinkSlider(this.sliderCameraDistanceMaximum, this.numCameraDistanceMaximum, 1);
            LinkedTweaks.LinkSlider(this.sliderfPitchZoomOutMaxDist, this.numfPitchZoomOutMaxDist, 1);

            LinkedTweaks.LinkSlider(this.trackBarPhotomodeTranslationSpeed, this.numericUpDownPhotomodeTranslationSpeed, 10);
            LinkedTweaks.LinkSlider(this.trackBarPhotomodeRotationSpeed, this.numericUpDownPhotomodeRotationSpeed, 10);
            LinkedTweaks.LinkSlider(this.trackBarPhotomodeRange, this.numericUpDownPhotomodeRange, 1);


            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderPosX, this.numfOverShoulderPosX, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderPosZ, this.numfOverShoulderPosZ, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderCombatPosX, this.numfOverShoulderCombatPosX, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderCombatPosZ, this.numfOverShoulderCombatPosZ, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderCombatAddY, this.numfOverShoulderCombatAddY, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderMeleeCombatPosX, this.numfOverShoulderMeleeCombatPosX, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderMeleeCombatPosZ, this.numfOverShoulderMeleeCombatPosZ, 1);
            LinkedTweaks.LinkSlider(this.trackBarfOverShoulderMeleeCombatAddY, this.numfOverShoulderMeleeCombatAddY, 1);
        }

        /// <summary>
        /// Link controls to tweaks, that means:
        /// -> If a control's value changes, change the value of a tweak.
        /// -> If the UI is being (re)loaded, set each value according to that of the linked tweak.
        /// </summary>
        public void LinkControlsToTweaks()
        {
            /*
             * Info tab
             */

            // Make *.ini files read-only
            /*LinkedTweaks.LinkTweak(checkBoxReadOnly, iniReadOnlyTweak);

            // Automatically apply changes when tool is closed or game is launched
            LinkedTweaks.LinkTweak(checkBoxAutoApply, autoApplyTweak);

            // Don't check for updates on startup.
            LinkedTweaks.LinkTweak(checkBoxIgnoreUpdates, ignoreUpdatesTweak);

            // Play notification sounds
            LinkedTweaks.LinkTweak(checkBoxPlayNotificationSound, playNotificationSoundsTweak);

            // Close the tool when the game is launched.
            LinkedTweaks.LinkTweak(checkBoxQuitOnGameLaunch, toolQuitOnLaunchTweak);*/



            /*
             * General tab
             */

            // Enable Steam
            LinkedTweaks.LinkTweak(checkBoxEnableSteam, enableSteamTweak);

            // Automatically sign-in
            LinkedTweaks.LinkTweak(checkBoxAutoSignin, autoSigninTweak);

            // Skip intro videos
            LinkedTweaks.LinkTweakNegated(checkBoxSkipIntroVideos, introVideoTweak);


            // Faster fade in
            LinkedTweaks.LinkTweak(checkBoxFasterFadeIn, fasterFadeInTweak);


            // Show splash screen with news on startup
            LinkedTweaks.LinkTweak(checkBoxSkipSplash, skipStartupSplash);

            // Show damage numbers in Nuclear Winter
            LinkedTweaks.LinkTweak(checkBoxShowDamageNumbersNW, showDamageNumbersNuclearWinterTweak);

            // Show damage numbers in Adventure mode
            LinkedTweaks.LinkTweak(checkBoxShowDamageNumbersA, showDamageNumbersAdventureTweak);

            // Show item rarity colors
            LinkedTweaks.LinkTweak(checkBoxItemRarityColorsNW, enableItemRarityColorsTweak);

            // Show Public Team Notifications
            LinkedTweaks.LinkTweak(checkBoxShowPublicTeamNotifications, showPublicTeamNotificationsTweak);

            // Show Floating Quest Markers
            LinkedTweaks.LinkTweak(checkBoxShowFloatingQuestMarkers, showFloatingQuestMarkersTweak);

            // Show Floating Quest Text
            LinkedTweaks.LinkTweak(checkBoxShowFloatingQuestText, showFloatingQuestTextTweak);

            // Show crosshair
            LinkedTweaks.LinkTweak(checkBoxShowCrosshair, showCrosshairTweak);

            // Enable Power Armor HUD
            LinkedTweaks.LinkTweak(checkBoxEnablePowerArmorHUD, enablePowerArmorHUDTweak);

            // Show compass
            LinkedTweaks.LinkTweak(checkBoxShowCompass, showCompassTweak);

            // Show Other Players' Names
            LinkedTweaks.LinkTweak(checkBoxShowOtherPlayersNames, showOtherPlayersNamesTweak);

            // Show active effects on HUD
            LinkedTweaks.LinkTweak(comboBoxShowActiveEffectsOnHUD, activeEffectsOnHUDTweak);

            // Floating Quest Markers Draw Distance
            LinkedTweaks.LinkTweak(numFloatingQuestMarkersDistance, floatingQuestMarkersDistanceTweak);

            // HUD Opacity
            LinkedTweaks.LinkTweak(numHUDOpacity, hudOpacityTweak);


            // XYZ Quest Active when started
            LinkedTweaks.LinkTweak(checkBoxEnableQuestAutoTrackMain, autoTrackMainQuestWhenStartedTweak);
            LinkedTweaks.LinkTweak(checkBoxEnableQuestAutoTrackSide, autoTrackSideQuestWhenStartedTweak);
            LinkedTweaks.LinkTweak(checkBoxEnableQuestAutoTrackMisc, autoTrackMiscQuestWhenStartedTweak);
            LinkedTweaks.LinkTweak(checkBoxEnableQuestAutoTrackEvent, autoTrackEventQuestWhenStartedTweak);
            LinkedTweaks.LinkTweak(checkBoxEnableQuestAutoTrackDaily, autoTrackOtherQuestWhenStartedTweak);



            /*
             * Video tab
             */

            // Custom resolution
            LinkedTweaks.LinkSize(numCustomResW, numCustomResH, displaySizeTweak);

            // Display mode
            LinkedTweaks.LinkTweak(comboBoxDisplayMode, displayModeTweak);

            // iPresentInterval
            LinkedTweaks.LinkTweak(checkBoxVSync, presentIntervalTweak);

            // Always active
            LinkedTweaks.LinkTweak(checkBoxAlwaysActive, windowAlwaysActiveTweak);

            // Top most window
            LinkedTweaks.LinkTweak(checkBoxTopMostWindow, topMostWindowTweak);

            // Fix HUD for 5:4 and 4:3 screens
            LinkedTweaks.LinkTweak(checkBoxFixHUDFor5_4and4_3, fixHUD4to3RatioTweak);



            /*
             * Graphics
             */

            // Anti aliasing
            LinkedTweaks.LinkTweak(comboBoxAntiAliasing, antiAliasingTweak);

            // Anisotropic filtering
            LinkedTweaks.LinkTweak(
                comboBoxAnisotropicFiltering,
                new int[] { 0, 2, 4, 8, 16 },
                anisotropicFilteringTweak);

            // Depth of Field
            LinkedTweaks.LinkTweak(checkBoxDepthOfField, enableDepthOfFieldTweak);

            // Motion Blur
            LinkedTweaks.LinkTweak(checkBoxMotionBlur, motionBlurTweak);

            // Radial Blur
            LinkedTweaks.LinkTweak(checkBoxRadialBlur, radialBlurTweak);

            // Lens Flare
            LinkedTweaks.LinkTweak(checkBoxLensFlare, lensFlareTweak);

            // Ambient Occlusion
            LinkedTweaks.LinkTweak(checkBoxAmbientOcclusion, ambientOcclusionTweak);

            // Water / Displacement
            LinkedTweaks.LinkTweak(checkBoxWaterDisplacement, waterDisplacementsTweak);

            // Weather / Fog
            LinkedTweaks.LinkTweak(checkBoxFogEnabled, fogTweak);

            // Weather / Rain Occlusion
            LinkedTweaks.LinkTweak(checkBoxWeatherRainOcclusion, rainOcclusionTweak);

            // Weather / Wetness Occlusion
            LinkedTweaks.LinkTweak(checkBoxWeatherWetnessOcclusion, wetnessOcclusionTweak);

            // Lighting / Volumetric Lighting
            LinkedTweaks.LinkTweak(checkBoxGodrays, volumetricLightingTweak);

            // Effects / Disable gore
            LinkedTweaks.LinkTweak(checkBoxDisableGore, disableAllGoreTweak);

            // Shadow texture map resolution
            LinkedTweaks.LinkTweak(
                comboBoxShadowTextureResolution,
                new int[] { 512, 1024, 2048, 4096 },
                shadowMapResolutionTweak);

            // Shadows / Blurriness
            LinkedTweaks.LinkTweak(
                comboBoxShadowBlurriness,
                new int[] { 1, 2, 3 },
                shadowBlurrinessTweak);

            // Shadow distance
            LinkedTweaks.LinkTweak(numShadowDistance, shadowDistanceTweak);

            // Enable grass
            LinkedTweaks.LinkTweak(checkBoxGrass, enableGrassTweak);

            // Grass fade distance
            LinkedTweaks.LinkTweak(numGrassFadeDistance, grassFadeDistanceTweak);

            // LOD Fade Distances
            LinkedTweaks.LinkTweak(numLODObjects, lodFadeOutMultObjectsTweak);
            LinkedTweaks.LinkTweak(numLODItems, lodFadeOutMultItemsTweak);
            LinkedTweaks.LinkTweak(numLODActors, lodFadeOutMultActorsTweak);

            // TAA Sharpening
            LinkedTweaks.LinkTweak(numTAAPostOverlay, taaPostOverlayTweak);
            LinkedTweaks.LinkTweak(numTAAPostSharpen, taaPostSharpenTweak);



            /*
             * Audio tab
             */

            // Enable audio
            LinkedTweaks.LinkTweak(checkBoxEnableAudio, enableAudioTweak);

            // Play music in main menu
            LinkedTweaks.LinkTweak(checkBoxMainMenuMusic, playMainMenuMusicTweak);


            // Voice Chat Mode
            LinkedTweaks.LinkTweak(comboBoxVoiceChatMode, voiceChatModeTweak);

            // Push-To-Talk
            LinkedTweaks.LinkTweak(checkBoxPushToTalk, voicePushToTalkEnabledTweak);


            // General subtitles
            LinkedTweaks.LinkTweak(checkBoxGeneralSubtitles, generalSubtitlesTweak);

            // Dialogue subtitles
            LinkedTweaks.LinkTweak(checkBoxDialogueSubtitles, dialogueSubtitlesTweak);

            // Dialogue history
            LinkedTweaks.LinkTweak(checkBoxDialogueHistory, showDialogueHistoryTweak);

            // Conversation History Size
            LinkedTweaks.LinkTweak(numConversationHistorySize, conversationHistorySizeTweak);


            // Master volume
            LinkedTweaks.LinkTweak(numVolumeMaster, masterVolumeTweak);

            // Voice chat volume
            LinkedTweaks.LinkTweak(numAudioChat, vivoxVoiceVolumeTweak);

            // Audio menu:
            LinkedTweaks.LinkTweak(numAudiofVal0, val0Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal1, val1Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal2, val2Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal3, val3Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal4, val4Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal5, val5Tweak);
            LinkedTweaks.LinkTweak(numAudiofVal6, val6Tweak);



            /*
             * Controls tab
             */

            // Mouse sensitivity
            LinkedTweaks.LinkTweak(numMouseSensitivity, mouseSensitivityTweak);

            // Fix mouse sensitivity
            LinkedTweaks.LinkTweak(checkBoxFixMouseSensitivity, fixMouseSensitivityTweak);

            // Fix aim sensitivity
            LinkedTweaks.LinkTweak(checkBoxFixAimSensitivity, fixAimSensitivityTweak);

            // Mouse acceleration
            LinkedTweaks.LinkTweak(checkBoxMouseAcceleration, mouseAccelerationTweak);

            // Invert mouse:
            LinkedTweaks.LinkTweak(checkBoxMouseInvertX, mouseInvertXTweak);
            LinkedTweaks.LinkTweak(checkBoxMouseInvertY, mouseInvertYTweak);

            // Gamepad enabled
            LinkedTweaks.LinkTweak(checkBoxGamepadEnabled, gamepadEnableTweak);

            // Vibration
            LinkedTweaks.LinkTweak(checkBoxGamepadRumble, enableGamepadRumbleTweak);



            /*
             * Camera tab
             */

            // 1st person FOV
            LinkedTweaks.LinkTweak(numFirstPersonFOV, fov1stPersonTweak);

            // Field of View
            LinkedTweaks.LinkSlider(sliderFOV, numFOV, 0.2f);
            LinkedTweaks.LinkTweak(numFOV, fovTweak);

            // 3rd person ADS FOV
            LinkedTweaks.LinkTweak(numADSFOV, fov3rdADSTweak);

            // fDefaultFOV
            LinkedTweaks.LinkTweak(numfDefaultFOV, defaultFOVTweak);

            // Camera distance
            LinkedTweaks.LinkTweak(numCameraDistanceMinimum, vanityModeMinDistTweak);
            LinkedTweaks.LinkTweak(numCameraDistanceMaximum, vanityModeMaxDistTweak);

            // fPitchZoomOutMaxDist
            LinkedTweaks.LinkTweak(numfPitchZoomOutMaxDist, pitchZoomOutMaxDistTweak);

            // Switch delay
            LinkedTweaks.LinkTweak(this.numCameraSwitchDelay, firstThirdPerspectiveSwitchDelayTweak);

            // Photomode options:
            LinkedTweaks.LinkTweak(this.numericUpDownPhotomodeRange, selfieModeRangeTweak);
            LinkedTweaks.LinkTweak(this.numericUpDownPhotomodeTranslationSpeed, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkTweak(this.numericUpDownPhotomodeRotationSpeed, selfieCameraRotationSpeedTweak);

            // Vanity mode
            LinkedTweaks.LinkTweakNegated(this.checkBoxVanityMode, disableAutoVanityModeTweak);
            LinkedTweaks.LinkTweak(this.checkBoxForceVanityMode, forceAutoVanityModeTweak);

            // bApplyCameraNodeAnimations
            LinkedTweaks.LinkTweak(this.checkBoxbApplyCameraNodeAnimations, applyCameraNodeAnimationsTweak);

            // OverShoulder sliders:
            LinkedTweaks.LinkTweak(this.numfOverShoulderPosX, cameraOverShoulderPosXTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderPosZ, cameraOverShoulderPosZTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderCombatPosX, cameraOverShoulderCombatPosXTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderCombatPosZ, cameraOverShoulderCombatPosZTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderCombatAddY, cameraOverShoulderCombatAddYTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderMeleeCombatPosX, cameraOverShoulderMeleeCombatPosXTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderMeleeCombatPosZ, cameraOverShoulderMeleeCombatPosZTweak);
            LinkedTweaks.LinkTweak(this.numfOverShoulderMeleeCombatAddY, cameraOverShoulderMeleeCombatAddYTweak);
        }


        /*
         * Define and instantiate all tweaks:
         */

        // Info tab
        /*private INIReadOnlyTweak iniReadOnlyTweak = new INIReadOnlyTweak();
        private AutoApplyTweak autoApplyTweak = new AutoApplyTweak();
        private IgnoreUpdatesTweak ignoreUpdatesTweak = new IgnoreUpdatesTweak();
        private PlayNotificationSoundsTweak playNotificationSoundsTweak = new PlayNotificationSoundsTweak();
        private ToolQuitOnLaunchTweak toolQuitOnLaunchTweak = new ToolQuitOnLaunchTweak();*/

        // General tab
        private EnableSteamTweak enableSteamTweak = new EnableSteamTweak();
        private AutoSigninTweak autoSigninTweak = new AutoSigninTweak();
        private IntroVideoTweak introVideoTweak = new IntroVideoTweak();
        private SkipStartupSplash skipStartupSplash = new SkipStartupSplash();

        private FasterFadeInTweak fasterFadeInTweak = new FasterFadeInTweak();

        private ShowDamageNumbersNuclearWinterTweak showDamageNumbersNuclearWinterTweak = new ShowDamageNumbersNuclearWinterTweak();
        private ShowDamageNumbersAdventureTweak showDamageNumbersAdventureTweak = new ShowDamageNumbersAdventureTweak();
        private EnableItemRarityColorsTweak enableItemRarityColorsTweak = new EnableItemRarityColorsTweak();
        private ShowPublicTeamNotificationsTweak showPublicTeamNotificationsTweak = new ShowPublicTeamNotificationsTweak();
        private ShowFloatingQuestMarkersTweak showFloatingQuestMarkersTweak = new ShowFloatingQuestMarkersTweak();
        private ShowFloatingQuestTextTweak showFloatingQuestTextTweak = new ShowFloatingQuestTextTweak();
        private ShowCompassTweak showCompassTweak = new ShowCompassTweak();
        private EnablePowerArmorHUDTweak enablePowerArmorHUDTweak = new EnablePowerArmorHUDTweak();
        private ShowCrosshairTweak showCrosshairTweak = new ShowCrosshairTweak();
        private ShowOtherPlayersNamesTweak showOtherPlayersNamesTweak = new ShowOtherPlayersNamesTweak();
        private ActiveEffectsOnHUDTweak activeEffectsOnHUDTweak = new ActiveEffectsOnHUDTweak();
        private FloatingQuestMarkersDistanceTweak floatingQuestMarkersDistanceTweak = new FloatingQuestMarkersDistanceTweak();
        private HUDOpacityTweak hudOpacityTweak = new HUDOpacityTweak();

        private AutoTrackQuestWhenStartedTweak autoTrackMainQuestWhenStartedTweak = new AutoTrackQuestWhenStartedTweak("Main", "Main");
        private AutoTrackQuestWhenStartedTweak autoTrackSideQuestWhenStartedTweak = new AutoTrackQuestWhenStartedTweak("Side", "Side");
        private AutoTrackQuestWhenStartedTweak autoTrackMiscQuestWhenStartedTweak = new AutoTrackQuestWhenStartedTweak("Misc", "Miscellaneous");
        private AutoTrackQuestWhenStartedTweak autoTrackEventQuestWhenStartedTweak = new AutoTrackQuestWhenStartedTweak("Event", "Event");
        private AutoTrackQuestWhenStartedTweak autoTrackOtherQuestWhenStartedTweak = new AutoTrackQuestWhenStartedTweak("Other", "Daily");

        // Video tab
        private DisplaySizeTweak displaySizeTweak = new DisplaySizeTweak();
        private DisplayModeTweak displayModeTweak = new DisplayModeTweak();
        private PresentIntervalTweak presentIntervalTweak = new PresentIntervalTweak();
        private WindowAlwaysActiveTweak windowAlwaysActiveTweak = new WindowAlwaysActiveTweak();
        private TopMostWindowTweak topMostWindowTweak = new TopMostWindowTweak();
        private FixHUD4to3RatioTweak fixHUD4to3RatioTweak = new FixHUD4to3RatioTweak();

        // Graphics
        private AntiAliasingTweak antiAliasingTweak = new AntiAliasingTweak();
        private AnisotropicFilteringTweak anisotropicFilteringTweak = new AnisotropicFilteringTweak();
        private EnableDepthOfFieldTweak enableDepthOfFieldTweak = new EnableDepthOfFieldTweak();
        private MotionBlurTweak motionBlurTweak = new MotionBlurTweak();
        private RadialBlurTweak radialBlurTweak = new RadialBlurTweak();
        private LensFlareTweak lensFlareTweak = new LensFlareTweak();
        private AmbientOcclusionTweak ambientOcclusionTweak = new AmbientOcclusionTweak();
        private WaterDisplacementsTweak waterDisplacementsTweak = new WaterDisplacementsTweak();
        private FogTweak fogTweak = new FogTweak();
        private RainOcclusionTweak rainOcclusionTweak = new RainOcclusionTweak();
        private WetnessOcclusionTweak wetnessOcclusionTweak = new WetnessOcclusionTweak();
        private VolumetricLightingTweak volumetricLightingTweak = new VolumetricLightingTweak();
        private DisableAllGoreTweak disableAllGoreTweak = new DisableAllGoreTweak();
        private ShadowMapResolutionTweak shadowMapResolutionTweak = new ShadowMapResolutionTweak();
        private ShadowBlurrinessTweak shadowBlurrinessTweak = new ShadowBlurrinessTweak();
        private ShadowDistanceTweak shadowDistanceTweak = new ShadowDistanceTweak();
        private DirShadowSplitsTweak dirShadowSplitsTweak = new DirShadowSplitsTweak();
        private LODFadeOutMultObjectsTweak lodFadeOutMultObjectsTweak = new LODFadeOutMultObjectsTweak();
        private LODFadeOutMultItemsTweak lodFadeOutMultItemsTweak = new LODFadeOutMultItemsTweak();
        private LODFadeOutMultActorsTweak lodFadeOutMultActorsTweak = new LODFadeOutMultActorsTweak();
        private EnableGrassTweak enableGrassTweak = new EnableGrassTweak();
        private GrassFadeDistanceTweak grassFadeDistanceTweak = new GrassFadeDistanceTweak();
        private BlendSplitDirShadowTweak blendSplitDirShadowTweak = new BlendSplitDirShadowTweak();
        private TAAPostOverlayTweak taaPostOverlayTweak = new TAAPostOverlayTweak();
        private TAAPostSharpenTweak taaPostSharpenTweak = new TAAPostSharpenTweak();
        private ScreenSpaceReflectionsTweak screenSpaceReflectionsTweak = new ScreenSpaceReflectionsTweak();

        // Audio tab
        private EnableAudioTweak enableAudioTweak = new EnableAudioTweak();
        private PlayMainMenuMusicTweak playMainMenuMusicTweak = new PlayMainMenuMusicTweak();

        private VoiceChatModeTweak voiceChatModeTweak = new VoiceChatModeTweak();
        private VoicePushToTalkEnabledTweak voicePushToTalkEnabledTweak = new VoicePushToTalkEnabledTweak();

        private GeneralSubtitlesTweak generalSubtitlesTweak = new GeneralSubtitlesTweak();
        private DialogueSubtitlesTweak dialogueSubtitlesTweak = new DialogueSubtitlesTweak();
        private ShowDialogueHistoryTweak showDialogueHistoryTweak = new ShowDialogueHistoryTweak();
        private ConversationHistorySizeTweak conversationHistorySizeTweak = new ConversationHistorySizeTweak();

        private MasterVolumeTweak masterVolumeTweak = new MasterVolumeTweak();
        private VivoxVoiceVolumeTweak vivoxVoiceVolumeTweak = new VivoxVoiceVolumeTweak();

        private AudioMenuValTweak val0Tweak = new AudioMenuValTweak("0", "Menu Music");
        private AudioMenuValTweak val1Tweak = new AudioMenuValTweak("1", "World Radios");
        private AudioMenuValTweak val2Tweak = new AudioMenuValTweak("2", "Voice");
        private AudioMenuValTweak val3Tweak = new AudioMenuValTweak("3", "Music");
        private AudioMenuValTweak val4Tweak = new AudioMenuValTweak("4", "Effects");
        private AudioMenuValTweak val5Tweak = new AudioMenuValTweak("5", "Footsteps");
        private AudioMenuValTweak val6Tweak = new AudioMenuValTweak("6", "Pip-Boy Radio");

        // Controls tab
        private MouseSensitivityTweak mouseSensitivityTweak = new MouseSensitivityTweak();
        private FixMouseSensitivityTweak fixMouseSensitivityTweak = new FixMouseSensitivityTweak();
        private FixAimSensitivityTweak fixAimSensitivityTweak = new FixAimSensitivityTweak();
        private MouseAccelerationTweak mouseAccelerationTweak = new MouseAccelerationTweak();
        private MouseInvertXTweak mouseInvertXTweak = new MouseInvertXTweak();
        private MouseInvertYTweak mouseInvertYTweak = new MouseInvertYTweak();
        private GamepadEnableTweak gamepadEnableTweak = new GamepadEnableTweak();
        private EnableGamepadRumbleTweak enableGamepadRumbleTweak = new EnableGamepadRumbleTweak();

        // Camera 
        private FOV1stPersonTweak fov1stPersonTweak = new FOV1stPersonTweak();
        private FieldOfViewTweak fovTweak = new FieldOfViewTweak();
        private FOV3rdADSTweak fov3rdADSTweak = new FOV3rdADSTweak();
        private DefaultFOVTweak defaultFOVTweak = new DefaultFOVTweak();

        private VanityModeMinDistTweak vanityModeMinDistTweak = new VanityModeMinDistTweak();
        private VanityModeMaxDistTweak vanityModeMaxDistTweak = new VanityModeMaxDistTweak();
        private PitchZoomOutMaxDistTweak pitchZoomOutMaxDistTweak = new PitchZoomOutMaxDistTweak();

        private FirstThirdPerspectiveSwitchDelayTweak firstThirdPerspectiveSwitchDelayTweak = new FirstThirdPerspectiveSwitchDelayTweak();

        private DisableAutoVanityModeTweak disableAutoVanityModeTweak = new DisableAutoVanityModeTweak();
        private ForceAutoVanityModeTweak forceAutoVanityModeTweak = new ForceAutoVanityModeTweak();

        private SelfieModeRangeTweak selfieModeRangeTweak = new SelfieModeRangeTweak();
        private SelfieCameraTranslationSpeedTweak selfieCameraTranslationSpeedTweak = new SelfieCameraTranslationSpeedTweak();
        private SelfieCameraRotationSpeedTweak selfieCameraRotationSpeedTweak = new SelfieCameraRotationSpeedTweak();

        private ApplyCameraNodeAnimationsTweak applyCameraNodeAnimationsTweak = new ApplyCameraNodeAnimationsTweak();
        private CameraOverShoulderPosXTweak cameraOverShoulderPosXTweak = new CameraOverShoulderPosXTweak();
        private CameraOverShoulderPosZTweak cameraOverShoulderPosZTweak = new CameraOverShoulderPosZTweak();
        private CameraOverShoulderCombatPosXTweak cameraOverShoulderCombatPosXTweak = new CameraOverShoulderCombatPosXTweak();
        private CameraOverShoulderCombatPosZTweak cameraOverShoulderCombatPosZTweak = new CameraOverShoulderCombatPosZTweak();
        private CameraOverShoulderCombatAddYTweak cameraOverShoulderCombatAddYTweak = new CameraOverShoulderCombatAddYTweak();
        private CameraOverShoulderMeleeCombatPosXTweak cameraOverShoulderMeleeCombatPosXTweak = new CameraOverShoulderMeleeCombatPosXTweak();
        private CameraOverShoulderMeleeCombatPosZTweak cameraOverShoulderMeleeCombatPosZTweak = new CameraOverShoulderMeleeCombatPosZTweak();
        private CameraOverShoulderMeleeCombatAddYTweak cameraOverShoulderMeleeCombatAddYTweak = new CameraOverShoulderMeleeCombatAddYTweak();
    }
}
