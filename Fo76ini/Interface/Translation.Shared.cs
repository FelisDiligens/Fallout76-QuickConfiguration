using Fo76ini.Interface;

namespace Fo76ini
{
    public partial class Localization
    {
        private static void AddSharedStrings()
        {
            localizedStrings["newVersionAvailable"] = "There is a newer version available: {0}";
            localizedStrings["updateNowButton"] = "Update now!";
            localizedStrings["unknown"] = "Unknown";
            localizedStrings["modsDeploymentNecessary"] = "Deployment necessary";
            //localizedStrings["modsAllDone"] = "All set";
            localizedStrings["modsFailed"] = "Something went wrong, see log files for details.";
            localizedStrings["modsTablePresetGeneral"] = "General";
            localizedStrings["modsTablePresetTextures"] = "Textures";
            localizedStrings["modsTablePresetSoundFX"] = "Sound FX";
            localizedStrings["modsTableTypeBundled"] = "Bundled";
            localizedStrings["modsTableTypeSeparate"] = "Separate archive";
            localizedStrings["modsTableTypeSeparateFrozen"] = "Separate archive (Frozen)";
            localizedStrings["modsTableTypeLoose"] = "Loose files";
            localizedStrings["modTableFrozenPending"] = "Pending";
            localizedStrings["modTableFrozen"] = "Frozen";
            localizedStrings["modTableFreeze"] = "Freeze";
            localizedStrings["modTableInstallInfoBundledBA2"] = "Bundle into {0}.";
            localizedStrings["modTableInstallInfoSeparateBA2"] = "Pack into {0} with preset {1}.";
            localizedStrings["modTableInstallInfoLooseFiles"] = "Copy files to {0}.";

            localizedStrings["modTablePendingInstallation"] = "Pending for installation";
            localizedStrings["modTablePendingRemoval"] = "Pending for removal";
            localizedStrings["modTablePendingChanges"] = "Pending changes";
            localizedStrings["updateAvailable"] = "Update available";
            localizedStrings["enabled"] = "Enabled";
            localizedStrings["disabled"] = "Disabled";
            localizedStrings["gameEdition"] = "Edition";

            //localizedStrings["modTableThawed"] = "Thawed";
            //localizedStrings["modDetailsTitle"] = "Edit {0}";
            //localizedStrings["modDetailsTitleBulk"] = "Edit {0} mods";
            localizedStrings["modDetailsTitleBulkSelected"] = "{0} mods selected";
            localizedStrings["nmResetTime"] = "in {0} hour(s) and {1} minute(s)";
            //localizedStrings["nmResetTimeNever"] = "Never";
            localizedStrings["nmRateLimitLeft"] = "{0} left";
            localizedStrings["nmBasicAccount"] = "Basic";
            localizedStrings["nmSupporterAccount"] = "Supporter";
            localizedStrings["nmPremiumAccount"] = "Premium";
            localizedStrings["notApplicable"] = "N/A";
            localizedStrings["yes"] = "Yes";
            localizedStrings["no"] = "No";
            localizedStrings["valid"] = "Valid";
            localizedStrings["invalid"] = "Invalid";
            localizedStrings["auto"] = "Auto";
            localizedStrings["unknown"] = "Unknown";
            localizedStrings["selected"] = "selected";
            localizedStrings["nuclearwintermode"] = "Nuclear Winter";
            localizedStrings["adventuremode"] = "Adventure";
            localizedStrings["affectedValues"] = "Affected values";
            localizedStrings["affectedFiles"] = "Affected files";
            localizedStrings["endorsedText"] = "You have endorsed this mod.";
            localizedStrings["notEndorsedText"] = "You have not endorsed this mod yet.";
            localizedStrings["abstainedText"] = "You have abstained from endorsing this mod.";
            localizedStrings["modSidePanel_WarningNoCommonResourceFoldersFound"] = "Warning: Couldn't find common resource folders (meshes, textures, sounds, materials, interface, and so on). The mod might fail to load.";
            localizedStrings["modSidePanel_WarningNoFilesAvailableToPack"] = "Warning: Couldn't find any (valid) files to pack to a *.ba2 archive. Archive2 might fail during deployment.";
            localizedStrings["modSidePanel_HintMixedResourcesFound"] = "Hint: Mixing general, texture, and sound files *might* cause the mod to not load correctly.\nIn case the mod doesn't work, you could try to set it to \"Bundled *.ba2 archive\".";
            localizedStrings["modSidePanel_HintWrongPresetForGeneralFiles"] = "Hint: For mods with general files, select the general preset or leave it on \"Auto-detect\".";
            localizedStrings["modSidePanel_HintWrongPresetForTextures"] = "Hint: For texture replacement mods, select the \"Textures (*.dds files)\" preset or leave it on \"Auto-detect\".";
            localizedStrings["modSidePanel_HintWrongPresetForAudioFiles"] = "Hint: For sound replacement mods, select the \"Sound FX / Music / Voice\" preset or leave it on \"Auto-detect\".";
            localizedStrings["modSidePanel_HintWrongInstallMethodForDLLs"] = "Hint: *.dll files are usually installed as \"Loose files\" into the top directory (\".\").";
            localizedStrings["modSidePanel_HintWrongInstallMethodForStrings"] = "Hint: Strings are usually installed as \"Loose files\" into the \"Data\\Strings\" folder.";
        }

        public static void AddSharedMessageBoxes()
        {
            // General:
            /*MsgBox.Add("onlyOneInstance",
                "Program already runs",
                "An instance of this program already runs. Exiting..."
            );*/

            // Form1:
            /*MsgBox.Add("iniParsingError",
                "Couldn't parse *.ini files",
                "At least one of the game's *.ini files is corrupted or contains a syntax error.\n" +
                "\n" +
                "You might:\n" +
                "    -> read the error message and fix the error or\n" +
                "    -> delete the invalid *.ini file and start Fallout 76 to create a new, valid *.ini file\n" +
                "    -> and then try again.\n" +
                "\n" +
                "ERROR MESSAGE:\n" +
                "{0}"
            );*/

            MsgBox.Add("changesApplied",
                "Changes applied",
                "Changes have been applied. You may start the game now."
            );

            MsgBox.Add("downloadLanguagesFinished",
                "Done",
                "Downloaded language files: {0}"
            );

            MsgBox.Add("iniFilesModified",
                "Files modified",
                "*.ini files have been modified outside of the tool while it's running.\n" +
                "NOTE: Any changes will be overwritten, if clicked on \"Apply\" or if mods are managed.\n" +
                "Please restart the tool to work with the new values."
            );

            MsgBox.Add("cloudFileProviderNotRunning",
                "Cloud file provider not running",
                "{0}\n" +
                "Please make sure OneDrive is running and try again.\n" +
                "The tool will be terminated now."
            );

            MsgBox.Add("iniFailedToLoad",
                "Failed to load *.ini file",
                "{0}\n" +
                "The tool will be terminated now."
            );


            // FormSettings:

            MsgBox.Add("setInisReadOnlyFailed",
                "Access denied",
                "Couldn't set *.ini files to read-only. Try to start the tool with admin rights.\n" +
                "{0}"
            );

            MsgBox.Add("modsGamePathInvalid",
                "Game path invalid",
                "The path you selected doesn't seem to be where Fallout 76 is installed.\n" +
                "Please make sure to select the folder where the *.exe resides, not the Data folder."
            );


            // Profile manager:

            MsgBox.Add("errorAtLeastOneGameOrProfile",
                "Cannot delete last game profile",
                "At least one game profile is required."
            );

            MsgBox.Add("gamePathAutoDetectFailed",
                "Auto-detect failed",
                "Couldn't find any common game path. Please select the path manually."
            );

            MsgBox.Add("gamePathAutoDetectPathFound",
                "Found a path",
                "Do you want to use this path?\nFound: {0}\n\nClick 'Yes' to use this path, 'No' to continue searching, and 'Cancel' to abort searching."
            );


            // Gallery:

            MsgBox.Add("galleryDeleteScreenshot",
                "Delete {0}?",
                "You are about to delete '{0}'. Are you sure?"
            );

            MsgBox.Add("galleryDeleteScreenshots",
                "Delete {0} files?",
                "You are about to delete {0} files. Are you sure?"
            );

            MsgBox.Add("galleryDeleteThumbnails",
                "Are you sure?",
                "Are you sure you want to delete the gallery's thumbnails?\nThe next time you click on 'Refresh gallery', it will take significantly longer as it recreates all thumbnails."
            );


            // Nuclear Winter:

            MsgBox.Add("nwModeDisabled",
                "Nuclear Winter mode disabled",
                "You can now launch into Adventure mode."
            );

            MsgBox.Add("nwModeEnabled",
                "Nuclear Winter mode enabled",
                "You can now launch into Nuclear Winter mode."
            );


            // Mods:

            MsgBox.Add("modsDisabledDone",
                "Done",
                "Mods have been disabled and removed from the game."
            );

            MsgBox.Add("modsDeployedDone",
                "Done",
                "Mods are deployed."
            );

            MsgBox.Add("modsDeploymentFailed",
                "Something went wrong",
                "Mods might not be deployed.\nPlease check the log files."
            );

            MsgBox.Add("modsArchive2Missing",
                "Archive2 is missing",
                ".\\Archive2\\Archive2.exe is missing.\nTry to reinstall this tool, or install Archive2 manually."
            );

            MsgBox.Add("modsGamePathNotSet",
                "Game path not specified or invalid",
                "Please make sure you have set the correct path to the game.\n" +
                "You can do this in the settings."
            );

            MsgBox.Add("7ZipMissing",
                "7-Zip is missing",
                ".\\7z\\7z.exe is missing.\nTry to reinstall this tool, or copy 7-Zip manually."
            );

            MsgBox.Add("modsNoConflictingFiles",
                "Yay!",
                "No conflicting files found."
            );

            MsgBox.Add("modsImportQuestion",
                "Import manually installed mods?",
                "Are you sure you want to add mods installed outside of the mod manager?"
            );

            MsgBox.Add("modsRepackFrozenBundledArchives",
                "Would you like to repack bundled archives?",
                "There are frozen bundled archives available. Would you like to repack bundled archives again?\n\n" +
                "   Yes - I made changes to my mod list and would like to repack my bundled archives again. (slow)\n\n" +
                "   No  - I didn't make changes, please deploy my frozen bundled archives. (quick)"
            );

            MsgBox.Add("archive2Error",
                "Archive2 failed to pack/extract an archive",
                "Archive2 failed for an unknown reason.\nPlease check the log files for details."
            );

            MsgBox.Add("archive2InstallRequirements",
                "Archive2 failed to pack/extract an archive",
                "Please make sure you've installed 'Visual C++ Redistributable for Visual Studio 2012 Update 4'.\n" +
                "You can find a link on the NexusMods page."
            );

            MsgBox.Add("modsArchiveTypeNotSupported",
                "Unsupported file format",
                "{0} files are not supported.\n" +
                "Please uncompress the archive and add the mod as a folder."
            );

            MsgBox.Add("modsLegacyFormatDetected",
                "Legacy version found",
                "It seems like you've managed mods before, but with a version prior to v1.9.0.\n" +
                "How mods are managed and stored has changed significantly.\n" +
                "As a result, they must be converted to the new format.\n\n" +
                "NOTE: This will unfreeze archives. After all mods are converted, they may take up more space, depending on how many mods were frozen. Downgrading will still be possible, but some mods might load incorrectly.\n\n" +
                "Would you like to convert them now? It won't take long."
            );

            MsgBox.Add("modsInvalidManifestEntry",
                "Invalid manifest.xml entry",
                "A mod entry is invalid and was ignored.\nError: {0}"
            );


            // NexusMods:

            MsgBox.Add("nexusModsRemoteInfoRefreshedSuccess",
                "Mod information updated",
                "Mod information updated and thumbnails downloaded."
            );

            MsgBox.Add("nexusModsEndorseAllQuestion",
                "Endorse all mods?",
                "This will endorse all your installed mods. Are you sure?"
            );

            MsgBox.Add("nexusModsNotLoggedIn",
                "Not logged in",
                "Please log in to NexusMods first and try again"
            );


            // TODO: Replace a lot of the message boxes with generic ones for easier translation.
            // Generic questions:

            MsgBox.Add("deleteQuestion",
                "Delete {0}?",
                "You are about to delete '{0}'. Are you sure?"
            );

            MsgBox.Add("deleteMultipleQuestion",
                "Delete {0} files?",
                "You are about to delete {0} files. Are you sure?"
            );

            MsgBox.Add("failed",
                "Failed",
                "{0}"
            );

            MsgBox.Add("done",
                "Done",
                "{0}"
            );

            MsgBox.Add("areYouSure",
                "Are you sure?",
                "{0}"
            );
        }

        public static void AddKnownTextResources()
        {
            knownTextResources.Add("TweaksInfo.html");
            knownTextResources.Add("Login with Bethesda.net.rtf");
        }
    }
}
