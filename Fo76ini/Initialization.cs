using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fo76ini.Forms.FormIniError;
using Fo76ini.Ini;
using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.API;
using Fo76ini.Profiles;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;

namespace Fo76ini
{
    public class Initialization
    {
        public static bool FirstStart = false;

        public static void InitApp()
        {
            // Determine whether this is the very first start of the tool on the system:
            Initialization.FirstStart = !File.Exists(IniFiles.ConfigPath) && !File.Exists(ProfileManager.XMLPath);

            // Create folders, if not present:
            Directory.CreateDirectory(Shared.AppConfigFolder);
            Directory.CreateDirectory(Shared.AppTranslationsFolder);
            Directory.CreateDirectory(IniFiles.DefaultParentPath);

            /*
             * Load app configuration:
             */

            Localization.Init();

            // Load config.ini:
            IniFiles.LoadConfig();

            // Load NexusMods Integration:
            NexusMods.Load();

            // Load profiles:
            ProfileManager.ProfileChanged += OnProfileChanged; // Make sure, that the FIRST event handler is ours.
            ProfileManager.Load();

            // Load custom fonts:
            CustomFonts.Register();
        }

        private static void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            Initialization.LoadINIFiles();
            //Initialization.LoadMods();
            LinkedTweaks.LoadValues();
            LinkedTweaks.LoadColors();
        }

        public static void LoadINIFiles()
        {
            while (true)
            {
                try
                {
                    IniFiles.Load(ProfileManager.SelectedGame);
                    break;
                }
                catch (IniParsingException exc)
                {
                    // Check if it failed due to IOException:
                    if (exc.InnerException.InnerException is IOException)
                    {
                        IOException ioexc = (IOException)exc.InnerException.InnerException;

                        // Is OneDrive the culprit?
                        // (I could not find any better way than to check the message itself. It probably won't work for languages other than English and German.)
                        if (ioexc.Message.Trim() == "The cloud file provider is not running." ||
                            ioexc.Message.Trim() == "Der Clouddateianbieter wird nicht ausgeführt.")
                        {
                            MsgBox.Get("cloudFileProviderNotRunning").FormatText(ioexc.Message).Show(MessageBoxIcon.Error);
                        }

                        // Otherwise show generic error message:
                        else
                        {
                            MsgBox.Get("iniFailedToLoad").FormatText(ioexc.GetType().ToString() + ": " + ioexc.Message).Show(MessageBoxIcon.Error);
                        }
                        Environment.Exit(-1);
                        return;
                    }

                    // Otherwise it's probably an parsing error.
                    // Open the INI error dialog:
                    else
                    {
                        DialogResult result = FormIniError.OpenDialog(exc);
                        if (result == DialogResult.Retry)
                        {
                            continue;
                        }
                        else if (result == DialogResult.Ignore)
                        {
                            continue;
                        }
                        else if (result == DialogResult.Abort)
                        {
                            Environment.Exit(-1);
                            return;
                        }
                    }
                }
            }
        }

        /*public static void LoadMods()
        {
            GameInstance game = ProfileManager.SelectedGame;

            // Check:
            if (!IniFiles.IsLoaded())
                return;
            if (!game.ValidateGamePath())
                return;

            // Create 'Mods' folder, if not present:
            if (!Directory.Exists(Path.Combine(game.GamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(game.GamePath, "Mods"));

            // Load managed mods:
            ManagedMods Mods = new ManagedMods(game.GamePath);
            Mods.Load();

            Mods.SaveResources();
        }*/
    }
}
