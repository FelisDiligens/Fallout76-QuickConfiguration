using Fo76ini.Interface;

namespace Fo76ini
{
    public partial class Localization
    {
        private static void AddSharedStrings()
        {
            localizedStrings["newVersionAvailable"] = "There is a newer version available: {0}";
            localizedStrings["updateNowButton"] = "Update now!";
            localizedStrings["modsDeploymentNecessary"] = "Deployment necessary";
            localizedStrings["modsAllDone"] = "All set";
            localizedStrings["modsFailed"] = "Something went wrong, see log files for details.";
            localizedStrings["modsTableFormatGeneral"] = "General";
            localizedStrings["modsTableFormatTextures"] = "Textures";
            localizedStrings["modsTableFormatAutoDetect"] = "Auto";
            localizedStrings["modsTableTypeBundled"] = "Bundled";
            localizedStrings["modsTableTypeSeparate"] = "Separate";
            localizedStrings["modsTableTypeSeparateFrozen"] = "Separate (Frozen)";
            localizedStrings["modsTableTypeLoose"] = "Loose";
            localizedStrings["modTableFrozenPending"] = "Pending";
            //localizedStrings["modDetailsTitle"] = "Edit {0}";
            //localizedStrings["modDetailsTitleBulk"] = "Edit {0} mods";
            localizedStrings["modDetailsTitleBulkSelected"] = "{0} mods selected";
            localizedStrings["nmResetTime"] = "in {0} hour(s) and {1} minute(s)";
            localizedStrings["nmResetTimeNever"] = "Never";
            localizedStrings["nmRateLimitLeft"] = "{0} left";
            localizedStrings["nmBasicAccount"] = "Basic";
            localizedStrings["nmSupporterAccount"] = "Supporter";
            localizedStrings["nmPremiumAccount"] = "Premium";
            localizedStrings["notApplicable"] = "N/A";
            localizedStrings["yes"] = "Yes";
            localizedStrings["no"] = "No";
            localizedStrings["valid"] = "Valid";
            localizedStrings["invalid"] = "Invalid";
            localizedStrings["nuclearwintermode"] = "Nuclear Winter";
            localizedStrings["adventuremode"] = "Adventure";
            localizedStrings["affectedValues"] = "Affected values";
            localizedStrings["affectedFiles"] = "Affected files";
        }

        public static void AddSharedMessageBoxes()
        {
            // Form1:
            MsgBox.Add("iniParsingError",
                "Couldn't parse *.ini files",
                "At least one of the game's *.ini files is corrupted or contains a syntax error.\n\nYou might:\n    -> read the error message and fix the error or\n    -> delete the invalid *.ini file and start Fallout 76 to create a new, valid *.ini file\n    -> and then try again.\n\nERROR MESSAGE:\n{0}"
            );

            MsgBox.Add("backupAndSave",
                "Backup and save",
                "Do you want to create a backup before applying all changes?\n\n" +
                "    Press \"Yes\" to create a backup and save.\n" +
                "    Press \"No\" to save without backup.\n" +
                "    Press \"Cancel\" to abort."
            );

            MsgBox.Add("changesApplied",
                "Changes applied",
                "Changes have been applied. You may start the game now."
            );

            MsgBox.Add("chooseGameEdition",
                "Choose Game Edition",
                "Please pick your game edition under the Settings tab."
            );

            MsgBox.Add("runGameToGenerateINI",
                "{0} and {1} not found",
                "Please run the game first before using this tool.\n" +
                "The game will generate those files on first start-up."
            );

            MsgBox.Add("oldValuesResetToDefault",
                "Done",
                "Some values have been reset to default.\n" +
                "Only unstable values from previous versions are affected.\n" +
                "Don't forget to click 'Apply'."
            );

            MsgBox.Add("iniFilesModified",
                "Files modified",
                "*.ini files have been modified outside of the tool while it's running.\n" +
                "NOTE: Any changes will be overwritten, if clicked on \"Apply\" or if mods are managed.\n" +
                "Please restart the tool to work with the new values."
            );

            MsgBox.Add("onLoadFuncException",
                "Error while loading UI",
                "{0} exception(s) occured while the UI was loaded.\n" +
                "This might be caused by corrupted ini files.\n" +
                "Some UI elements might not be functioning correctly.\n\n" +
                "{1}"
            );

            MsgBox.Add("iniValuesInvalid",
                "Invalid *.ini values found",
                "{0} *.ini value(s) are invalid:\n\n" +
                "{1}"
            );

            MsgBox.Add("downloadLanguagesFinished",
                "Done",
                "Downloaded language files: {0}"
            );

            MsgBox.Add("downloadLanguagesFailed",
                "Failed",
                "Downloading languages failed.\n{0}"
            );

            MsgBox.Add("msstoreRestartRequired",
                "Do you want to switch?",
                "Switching to or from the Microsoft Store edition requires a restart of the tool."
            );

            MsgBox.Add("msstoreRunExecutableFailed",
                "Couldn't launch game: {0}",
                "Unfortunately, it's not possible to launch the executable directly due to \"security\" restrictions. Thanks Microsoft, we hate it. :("
            );

            MsgBox.Add("customIniFilesParsingError",
                "Couldn't add your custom *.ini tweaks",
                "At least one of your custom *.ini files contains an error.\n{0}"
            );

            MsgBox.Add("displayResolutionTooLow",
                "Display resolution might be too low",
                "Your display resolution is not supported.\nThe windows might be to big to fit on screen.\nYour display size: {0}\nMinimum display size: {1}\nRecommended display size: 1920 x 1080"
            );

            MsgBox.Add("restartRequired",
                "Restart required.",
                "A restart of the tool is required for changes to take effect.\nAre you sure, you want to change this option now?"
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
                "NW mode disabled",
                "You can now launch into Adventure mode."
            );

            MsgBox.Add("nwModeEnabled",
                "NW mode enabled",
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
                ".\\Archive2\\Archive2.exe is missing.\nPlease download this tool again, or install Archive2 manually."
            );

            MsgBox.Add("modsGamePathNotSet",
                "Game path not set",
                "Please set the path to the game (where Fallout76.exe resides)."
            );

            MsgBox.Add("modsGamePathInvalid",
                "Wrong path",
                "Wrong game folder path."
            );

            MsgBox.Add("modsDeployErrorModDirNotFound",
                "Mod {0} couldn't be deployed.",
                "Directory {0} does not exist.\n" +
                "Please restart the mod manager and add the mod again."
            );

            MsgBox.Add("modsDeployErrorBA2RootIsNotData",
                "Mod {0} couldn't be deployed.",
                "The root folder has to be set to \".\\Data\" for mods, that are to be installed as a *.ba2 archive.\n" +
                "Please fix the \"Install into\" setting and try again."
            );

            MsgBox.Add("modsDeleteBtn",
                "Are you sure?",
                "Are you sure you want to delete the mod {0}?"
            );

            MsgBox.Add("modsDeleteBulkBtn",
                "Are you sure?",
                "Are you sure you want to delete {0} mods?"
            );

            MsgBox.Add("modsExtractUnknownError",
                "Archive couldn't be uncompressed",
                "{0}"
            );

            MsgBox.Add("modsExtractUnknownErrorText",
                "Archive couldn't be uncompressed",
                "Please uncompress the archive and add the mod as a folder."
            );

            MsgBox.Add("modsArchiveTypeNotSupported",
                "Unsupported file format",
                "{0} files are not supported.\n" +
                "Please uncompress the archive and add the mod as a folder."
            );

            MsgBox.Add("modsNoConflictingFiles",
                "Yay!",
                "No conflicting files found."
            );

            MsgBox.Add("modsDeploymentNecessary",
                "Deployment necessary",
                "For this action, you have to deploy all mods first."
            );

            MsgBox.Add("modsOnCloseDeploymentNecessary",
                "Are you sure?",
                "You haven't deployed the changes you made.\n" +
                "Are you sure you want to close the mod manager?"
            );

            MsgBox.Add("modDirNotExist",
                "Mod folder does not exist.",
                "The path {0} does not exist.\nThe mod folder was removed without removing the entry in the manifest."
            );

            MsgBox.Add("modsInvalidManifestEntry",
                "Invalid manifest.xml entry",
                "A mod entry is invalid and was ignored.\nError: {0}"
            );

            MsgBox.Add("modsInvalidManifestRoot",
                "Invalid manifest.xml entry",
                "The <Mods> tag has invalid attributes.\nError: {0}"
            );

            MsgBox.Add("modsImportQuestion",
                "Import manually installed mods?",
                "Are you sure you want to add mods installed outside of the mod manager?"
            );

            MsgBox.Add("modsSameArchiveName",
                "Conflicting mods",
                "Some mods have the same archive name: \"{0}\".\nConflicting mod name: {1}"
            );

            MsgBox.Add("modDetailsMoveManagedFolderFailed",
                "Failed to rename folder",
                "Managed mod folder couldn't be renamed.\nError message: \"{0}\"."
            );

            MsgBox.Add("modsRepairDDSQuestion",
                "Are you sure?",
                "This will attempt to repair all *.dds files.\nIt can take a long time, depending on file size and number of files.\nAre you sure you want to continue?"
            );

            MsgBox.Add("modsRepairDDSDone",
                "Done",
                "*.dds files have been repaired."
            );

            MsgBox.Add("modsAccessDenied",
                "Access denied",
                "{0}\nPlease start the tool as admin and try again."
            );

            MsgBox.Add("modsRepackFrozenBundledArchives",
                "Would you like to repack bundled archives?",
                "There are frozen bundled archives available. Would you like to repack bundled archives again?\n\n" +
                "   Yes - I made changes to my mod list and would like to repack my bundled archives again. (slow)\n\n" +
                "   No  - I didn't make changes, please deploy my frozen bundled archives. (quick)"
            );

            MsgBox.Add("archive2Error",
                "Archive2 failed to pack/extract an archive",
                "Please check the log files."
            );

            MsgBox.Add("archive2InstallRequirements",
                "Archive2 failed to pack/extract an archive",
                "Please make sure you've installed 'Visual C++ Redistributable for Visual Studio 2012 Update 4'.\n" +
                "You can find a link on the NexusMods page."
            );

            MsgBox.Add("nwModeEnabledButModsAreDeployed",
                "Mods are still deployed",
                "You've enabled the Nuclear Winter mode, but your mods are still deployed.\n" +
                "Do you want to disable them now?"
            );

            MsgBox.Add("nwModeDisabledAndModsAreStillDisabled",
                "Do you want to re-enable your mods again?",
                "You've disabled the Nuclear Winter mode, but your mods are still disabled.\n" +
                "Do you want to deploy them now?"
            );


            // NexusMods

            MsgBox.Add("nexusModsRemoteInfoRefreshedSuccess",
                "Mod information updated",
                "Mod information updated and thumbnails downloaded."
            );

            MsgBox.Add("nexusModsProfileRefreshFailed",
                "Failed",
                "Couldn't update your profile:\n{0}"
            );

            MsgBox.Add("nexusModsDeleteThumbnails",
                "Are you sure?",
                "Do you really want to delete all thumbnails?"
            );

            MsgBox.Add("nexusModsDeleteThumbnailsSuccess",
                "Done",
                "Thumbnails deleted."
            );

            MsgBox.Add("nexusModsDeleteThumbnailsFailed",
                "Something went wrong",
                "Thumbnails couldn't be deleted.\nTry again later."
            );

            MsgBox.Add("nexusModsRemoveProfile",
                "Are you sure?",
                "Do you really want to remove your profile from the mod manager?"
            );

            MsgBox.Add("nexusModsRemoveProfileSuccess",
                "Done",
                "Profile removed."
            );

            MsgBox.Add("nexusModsRemoveRemoteInfo",
                "Are you sure?",
                "Do you really want to remove mod information?"
            );

            MsgBox.Add("nexusModsRemoveRemoteInfoSuccess",
                "Done",
                "Mod information removed."
            );

            // TODO: Replace a lot of the message boxes with generic ones for easier translation.
            // Generic questions:
            MsgBox.Add("deleteQuestion",
                "Are you sure?",
                "Do you want to delete \"{0}\"?"
            );

            // Profile manager:
            MsgBox.Add("errorAtLeastOneGameOrProfile",
                "Cannot delete game or profile",
                "At least one game or profile is needed."
            );

            MsgBox.Add("gamePathAutoDetectFailed",
                "Auto-detect failed",
                "Couldn't find any common game path. If you haven't selected a game edition, select the right one and try again."
            );
        }
    }
}
