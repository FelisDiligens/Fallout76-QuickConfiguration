using Fo76ini.Tweaks;
using Fo76ini.Tweaks.Audio;
using Fo76ini.Tweaks.Camera;
using Fo76ini.Tweaks.Colors;
using Fo76ini.Tweaks.Config;
using Fo76ini.Tweaks.Controls;
using Fo76ini.Tweaks.General;
using Fo76ini.Tweaks.Graphics;
using Fo76ini.Tweaks.Inis;
using Fo76ini.Tweaks.Interface;
using Fo76ini.Tweaks.Pipboy;
using Fo76ini.Tweaks.Video;
using Fo76ini.Tweaks.Volume;

namespace Fo76ini
{
    /*
     * A bit similar to the *.Designer.cs, adds event handlers to (almost) all controls.
     * That is, instantiate classes that implement ITweak, and link the controls to it's value (among other things).
     */
    partial class Form1
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
            LinkedTweaks.LinkInfo(checkBoxEnableSteam, enableSteamTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoSignin, autoSigninTweak);
            LinkedTweaks.LinkInfo(checkBoxIntroVideos, introVideoTweak);
            LinkedTweaks.LinkInfo(checkBoxSkipSplash, skipStartupSplash);

            LinkedTweaks.LinkInfo(checkBoxShowDamageNumbersNW, showDamageNumbersNuclearWinterTweak);
            LinkedTweaks.LinkInfo(checkBoxShowDamageNumbersA, showDamageNumbersAdventureTweak);
            LinkedTweaks.LinkInfo(checkBoxItemRarityColorsNW, enableItemRarityColorsTweak);
            LinkedTweaks.LinkInfo(checkBoxShowPublicTeamNotifications, showPublicTeamNotificationsTweak);
            LinkedTweaks.LinkInfo(checkBoxShowFloatingQuestMarkers, showFloatingQuestMarkersTweak);
            LinkedTweaks.LinkInfo(checkBoxShowFloatingQuestText, showFloatingQuestTextTweak);
            LinkedTweaks.LinkInfo(checkBoxShowCrosshair, showCrosshairTweak);
            LinkedTweaks.LinkInfo(checkBoxEnablePowerArmorHUD, enablePowerArmorHUDTweak);
            LinkedTweaks.LinkInfo(checkBoxShowCompass, showCompassTweak);
            LinkedTweaks.LinkInfo(checkBoxShowOtherPlayersNames, showOtherPlayersNamesTweak);
            LinkedTweaks.LinkInfo(comboBoxShowActiveEffectsOnHUD, activeEffectsOnHUDTweak);
            LinkedTweaks.LinkInfo(labelShowActiveEffectsOnHUD, activeEffectsOnHUDTweak);
            LinkedTweaks.LinkInfo(numFloatingQuestMarkersDistance, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(sliderFloatingQuestMarkersDistance, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(labelFloatingQuestMarkersDistance, floatingQuestMarkersDistanceTweak);
            LinkedTweaks.LinkInfo(numHUDOpacity, hudOpacityTweak);
            LinkedTweaks.LinkInfo(sliderHUDOpacity, hudOpacityTweak);
            LinkedTweaks.LinkInfo(labelHUDOpacity, hudOpacityTweak);

            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackMain, autoTrackMainQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackSide, autoTrackSideQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackMisc, autoTrackMiscQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackEvent, autoTrackEventQuestWhenStartedTweak);
            LinkedTweaks.LinkInfo(checkBoxEnableQuestAutoTrackDaily, autoTrackOtherQuestWhenStartedTweak);

            // Video tab
            LinkedTweaks.LinkInfo(numCustomResW, displaySizeTweak);
            LinkedTweaks.LinkInfo(numCustomResH, displaySizeTweak);
            LinkedTweaks.LinkInfo(labelResolution, displaySizeTweak);
            LinkedTweaks.LinkInfo(labelCustomResolution, displaySizeTweak);
            LinkedTweaks.LinkInfo(comboBoxResolution, displaySizeTweak);
            LinkedTweaks.LinkInfo(comboBoxDisplayMode, displayModeTweak);
            LinkedTweaks.LinkInfo(labelDisplayMode, displayModeTweak);
            LinkedTweaks.LinkInfo(checkBoxVSync, presentIntervalTweak);
            LinkedTweaks.LinkInfo(checkBoxAlwaysActive, windowAlwaysActiveTweak);
            LinkedTweaks.LinkInfo(checkBoxTopMostWindow, topMostWindowTweak);
            LinkedTweaks.LinkInfo(checkBoxFixHUDFor5_4and4_3, fixHUD4to3RatioTweak);

            // Graphics:
            LinkedTweaks.LinkInfo(labelAntiAliasing, antiAliasingTweak);
            LinkedTweaks.LinkInfo(comboBoxAntiAliasing, antiAliasingTweak);
            LinkedTweaks.LinkInfo(labelAnisotropicFiltering, anisotropicFilteringTweak);
            LinkedTweaks.LinkInfo(comboBoxAnisotropicFiltering, anisotropicFilteringTweak);
            LinkedTweaks.LinkInfo(checkBoxDepthOfField, enableDepthOfFieldTweak);
            LinkedTweaks.LinkInfo(checkBoxMotionBlur, motionBlurTweak);
            LinkedTweaks.LinkInfo(checkBoxRadialBlur, radialBlurTweak);
            LinkedTweaks.LinkInfo(checkBoxLensFlare, lensFlareTweak);
            LinkedTweaks.LinkInfo(checkBoxAmbientOcclusion, ambientOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxWaterDisplacement, waterDisplacementsTweak);
            LinkedTweaks.LinkInfo(checkBoxFogEnabled, fogTweak);
            LinkedTweaks.LinkInfo(checkBoxWeatherRainOcclusion, rainOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxWeatherWetnessOcclusion, wetnessOcclusionTweak);
            LinkedTweaks.LinkInfo(checkBoxGodrays, volumetricLightingTweak);
            LinkedTweaks.LinkInfo(checkBoxDisableGore, disableAllGoreTweak);
            LinkedTweaks.LinkInfo(labelShadowTextureResolution, shadowMapResolutionTweak);
            LinkedTweaks.LinkInfo(comboBoxShadowTextureResolution, shadowMapResolutionTweak);
            LinkedTweaks.LinkInfo(comboBoxShadowBlurriness, shadowBlurrinessTweak);
            LinkedTweaks.LinkInfo(numShadowDistance, shadowDistanceTweak);
            LinkedTweaks.LinkInfo(sliderShadowDistance, shadowDistanceTweak);
            LinkedTweaks.LinkInfo(numLODObjects, lodFadeOutMultObjectsTweak);
            LinkedTweaks.LinkInfo(numLODItems, lodFadeOutMultItemsTweak);
            LinkedTweaks.LinkInfo(numLODActors, lodFadeOutMultActorsTweak);
            LinkedTweaks.LinkInfo(sliderLODObjects, lodFadeOutMultObjectsTweak);
            LinkedTweaks.LinkInfo(sliderLODItems, lodFadeOutMultItemsTweak);
            LinkedTweaks.LinkInfo(sliderLODActors, lodFadeOutMultActorsTweak);
            LinkedTweaks.LinkInfo(checkBoxGrass, enableGrassTweak);
            LinkedTweaks.LinkInfo(comboBoxiDirShadowSplits, dirShadowSplitsTweak);
            LinkedTweaks.LinkInfo(labeliDirShadowSplits, dirShadowSplitsTweak);
            LinkedTweaks.LinkInfo(numfBlendSplitDirShadow, blendSplitDirShadowTweak);
            LinkedTweaks.LinkInfo(sliderfBlendSplitDirShadow, blendSplitDirShadowTweak);
            LinkedTweaks.LinkInfo(numTAAPostOverlay, taaPostOverlayTweak);
            LinkedTweaks.LinkInfo(numTAAPostSharpen, taaPostSharpenTweak);
            LinkedTweaks.LinkInfo(sliderTAAPostOverlay, taaPostOverlayTweak);
            LinkedTweaks.LinkInfo(sliderTAAPostSharpen, taaPostSharpenTweak);

            // Audio tab
            LinkedTweaks.LinkInfo(checkBoxEnableAudio, enableAudioTweak);
            LinkedTweaks.LinkInfo(checkBoxMainMenuMusic, playMainMenuMusicTweak);
            LinkedTweaks.LinkInfo(comboBoxVoiceChatMode, voiceChatModeTweak);
            LinkedTweaks.LinkInfo(labelVoiceChatMode, voiceChatModeTweak);
            LinkedTweaks.LinkInfo(checkBoxGeneralSubtitles, generalSubtitlesTweak);
            LinkedTweaks.LinkInfo(checkBoxDialogueSubtitles, dialogueSubtitlesTweak);
            LinkedTweaks.LinkInfo(checkBoxDialogueHistory, showDialogueHistoryTweak);
            LinkedTweaks.LinkInfo(checkBoxPushToTalk, voicePushToTalkEnabledTweak);
            LinkedTweaks.LinkInfo(numConversationHistorySize, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(sliderConversationHistorySize, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(labelConversationHistorySize, conversationHistorySizeTweak);
            LinkedTweaks.LinkInfo(numVolumeMaster, masterVolumeTweak);
            LinkedTweaks.LinkInfo(numAudioChat, vivoxVoiceVolumeTweak);
            LinkedTweaks.LinkInfo(sliderVolumeMaster, masterVolumeTweak);
            LinkedTweaks.LinkInfo(sliderAudioChat, vivoxVoiceVolumeTweak);

            // Volume:
            LinkedTweaks.LinkInfo(labelVolumeMaster, masterVolumeTweak);
            LinkedTweaks.LinkInfo(labelAudioChat, vivoxVoiceVolumeTweak);

            LinkedTweaks.LinkInfo(numAudiofVal0, val0Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal1, val1Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal2, val2Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal3, val3Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal4, val4Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal5, val5Tweak);
            LinkedTweaks.LinkInfo(numAudiofVal6, val6Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal0, val0Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal1, val1Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal2, val2Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal3, val3Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal4, val4Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal5, val5Tweak);
            LinkedTweaks.LinkInfo(sliderAudiofVal6, val6Tweak);

            // Controls tab
            LinkedTweaks.LinkInfo(numMouseSensitivity, mouseSensitivityTweak);
            LinkedTweaks.LinkInfo(sliderMouseSensitivity, mouseSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxFixMouseSensitivity, fixMouseSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxFixAimSensitivity, fixAimSensitivityTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseAcceleration, mouseAccelerationTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseInvertX, mouseInvertXTweak);
            LinkedTweaks.LinkInfo(checkBoxMouseInvertY, mouseInvertYTweak);
            LinkedTweaks.LinkInfo(checkBoxGamepadEnabled, gamepadEnableTweak);
            LinkedTweaks.LinkInfo(checkBoxGamepadRumble, enableGamepadRumbleTweak);

            // Camera tab
            LinkedTweaks.LinkInfo(this.checkBoxbApplyCameraNodeAnimations, applyCameraNodeAnimationsTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderPosX, cameraOverShoulderPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderPosZ, cameraOverShoulderPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatPosX, cameraOverShoulderCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatPosZ, cameraOverShoulderCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderCombatAddY, cameraOverShoulderCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatPosX, cameraOverShoulderMeleeCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatPosZ, cameraOverShoulderMeleeCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.numfOverShoulderMeleeCombatAddY, cameraOverShoulderMeleeCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderPosX, cameraOverShoulderPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderPosZ, cameraOverShoulderPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatPosX, cameraOverShoulderCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatPosZ, cameraOverShoulderCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderCombatAddY, cameraOverShoulderCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatPosX, cameraOverShoulderMeleeCombatPosXTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatPosZ, cameraOverShoulderMeleeCombatPosZTweak);
            LinkedTweaks.LinkInfo(this.trackBarfOverShoulderMeleeCombatAddY, cameraOverShoulderMeleeCombatAddYTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeRange, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeTranslationSpeed, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.numericUpDownPhotomodeRotationSpeed, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeRange, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeTranslationSpeed, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.labelPhotomodeRotationSpeed, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeRange, selfieModeRangeTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeTranslationSpeed, selfieCameraTranslationSpeedTweak);
            LinkedTweaks.LinkInfo(this.trackBarPhotomodeRotationSpeed, selfieCameraRotationSpeedTweak);
            LinkedTweaks.LinkInfo(this.checkBoxVanityMode, disableAutoVanityModeTweak);
            LinkedTweaks.LinkInfo(this.checkBoxForceVanityMode, forceAutoVanityModeTweak);
            LinkedTweaks.LinkInfo(this.numCameraSwitchDelay, firstThirdPerspectiveSwitchDelayTweak);
            LinkedTweaks.LinkInfo(this.labelSwitchDelay, firstThirdPerspectiveSwitchDelayTweak);
            LinkedTweaks.LinkInfo(numFirstPersonFOV, fov1stPersonTweak);
            LinkedTweaks.LinkInfo(numWorldFOV, fov3rdPersonTweak);
            LinkedTweaks.LinkInfo(numADSFOV, fov3rdADSTweak);
            LinkedTweaks.LinkInfo(numfDefaultFOV, defaultFOVTweak);
            LinkedTweaks.LinkInfo(labelFirstPersonFOV, fov1stPersonTweak);
            LinkedTweaks.LinkInfo(labelWorldFOV, fov3rdPersonTweak);
            LinkedTweaks.LinkInfo(labelADSFOV, fov3rdADSTweak);
            LinkedTweaks.LinkInfo(labelfDefaultFOV, defaultFOVTweak);
            LinkedTweaks.LinkInfo(numCameraDistanceMinimum, vanityModeMinDistTweak);
            LinkedTweaks.LinkInfo(numCameraDistanceMaximum, vanityModeMaxDistTweak);
            LinkedTweaks.LinkInfo(numfPitchZoomOutMaxDist, pitchZoomOutMaxDistTweak);
            LinkedTweaks.LinkInfo(labelCameraDistanceMinimum, vanityModeMinDistTweak);
            LinkedTweaks.LinkInfo(labelCameraDistanceMaximum, vanityModeMaxDistTweak);
            LinkedTweaks.LinkInfo(labelPitchZoomOutMaxDist, pitchZoomOutMaxDistTweak);

            // Pipboy tab
            LinkedTweaks.LinkInfo(buttonColorPickPipboy, pipboyColorTweak);
            LinkedTweaks.LinkInfo(buttonColorPickQuickboy, quickboyColorTweak);
            LinkedTweaks.LinkInfo(buttonColorPickPAPipboy, powerArmorPipboyColorTweak);
            LinkedTweaks.LinkInfo(labelPipboyColor, pipboyColorTweak);
            LinkedTweaks.LinkInfo(labelQuickboyColor, quickboyColorTweak);
            LinkedTweaks.LinkInfo(labelPowerArmorColor, powerArmorPipboyColorTweak);

            // Gallery tab
            LinkedTweaks.LinkInfo(numScreenshotIndex, screenshotIndexTweak);
            LinkedTweaks.LinkInfo(labelScreenshotIndex, screenshotIndexTweak);
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
            LinkedTweaks.LinkSlider(this.sliderfBlendSplitDirShadow, this.numfBlendSplitDirShadow, 0.0833333);
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

            // Play intro videos
            LinkedTweaks.LinkTweak(checkBoxIntroVideos, introVideoTweak);


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

            // Amount of shadow "segments": iDirShadowSplits
            LinkedTweaks.LinkTweak(
                comboBoxiDirShadowSplits,
                new int[] { 1, 2, 3 },
                dirShadowSplitsTweak);

            // BlendSplitDirShadowTweak / Shadow "segment" transition distance
            LinkedTweaks.LinkTweak(numfBlendSplitDirShadow, blendSplitDirShadowTweak);

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
             * Pipboy tab
             */

            // Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPipboy,  // "Pick color" button
                buttonColorResetPipboy, // "Reset" button
                colorDialog,            // The color picking dialog that should open when clicking on "Pick color"
                colorPreviewPipboy,     // The little, colored square that is left to the label.
                pipboyColorTweak);

            // Quickboy color
            LinkedTweaks.LinkColor(
                buttonColorPickQuickboy,
                buttonColorResetQuickboy,
                colorDialog,
                colorPreviewQuickboy,
                quickboyColorTweak);

            // Power Armor Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPAPipboy,
                buttonColorResetPAPipboy,
                colorDialog,
                colorPreviewPAPipboy,
                powerArmorPipboyColorTweak);

            // Radiobuttons, Quickboy or Pipboy mode
            LinkedTweaks.LinkTweak(this.radioButtonQuickboy, this.radioButtonPipboy, quickboyModeEnabledTweak);
            
            // Pipboy resolution
            LinkedTweaks.LinkSize(numPipboyTargetWidth, numPipboyTargetHeight, pipboyTargetResolution);



            /*
             * Camera tab
             */

            // 1st person FOV
            LinkedTweaks.LinkTweak(numFirstPersonFOV, fov1stPersonTweak);

            // World FOV
            LinkedTweaks.LinkTweak(numWorldFOV, fov3rdPersonTweak);

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



            /*
             * Gallery tab
             */

            // Screenshot index
            LinkedTweaks.LinkTweak(numScreenshotIndex, screenshotIndexTweak);
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

        // Pipboy tab
        private PipboyColorTweak pipboyColorTweak = new PipboyColorTweak();
        private QuickboyColorTweak quickboyColorTweak = new QuickboyColorTweak();
        private PowerArmorPipboyColorTweak powerArmorPipboyColorTweak = new PowerArmorPipboyColorTweak();

        private QuickboyModeEnabledTweak quickboyModeEnabledTweak = new QuickboyModeEnabledTweak();
        private PipboyTargetResolution pipboyTargetResolution = new PipboyTargetResolution();

        // Camera 
        private FOV1stPersonTweak fov1stPersonTweak = new FOV1stPersonTweak();
        private FOV3rdPersonTweak fov3rdPersonTweak = new FOV3rdPersonTweak();
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

        // Gallery tab
        private ScreenshotIndexTweak screenshotIndexTweak = new ScreenshotIndexTweak();
    }
}
