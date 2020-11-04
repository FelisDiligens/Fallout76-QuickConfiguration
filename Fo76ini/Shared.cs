using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini
{
    public enum GameEdition
    {
        Unknown = 0,
        BethesdaNet = 1,
        Steam = 2,
        BethesdaNetPTS = 3,
        MSStore = 4
    }

    public class Shared
    {
        public const String VERSION = "1.8.5";
        public static String LatestVersion = null;

        public static String OldAppConfigFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration");
        public static String AppConfigFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Fallout 76 Quick Configuration");

        public static System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        private static String gamePath = null;

        public static GameEdition GameEdition = GameEdition.Unknown;

        public static bool NuclearWinterMode = false;

        public static void LoadGameEdition()
        {
            Shared.GameEdition = (GameEdition)(IniFiles.Instance.GetInt(IniFile.Config, "Preferences", "uGameEdition", 0));
            Form1.logFile.WriteLine($"[Shared] Loaded game edition setting ({Shared.GameEdition})");
        }

        public static void SaveGameEdition()
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "uGameEdition", (uint)Shared.GameEdition);
            Form1.logFile.WriteLine($"[Shared] Saved game edition setting ({Shared.GameEdition})");
        }

        public static void ChangeGameEdition(GameEdition gameEdition)
        {
            Form1.logFile.WriteLine($"[Shared] Changing game edition to {gameEdition}");

            Shared.GameEdition = gameEdition;

            // ManagedMods:
            ManagedMods.Instance.CopyINILists();
            ManagedMods.Instance.Unload();

            // IniFiles:
            IniFiles.Instance.ChangeGameEdition(Shared.GameEdition);
            SaveGameEdition();

            // ManagedMods:
            Shared.LoadGamePath();
            ManagedMods.Instance.Load();

            // FormMods:
            // formMods.UpdateUI();
        }

        public static void LoadGamePath ()
        {
            String gamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", Shared.GamePathKey, "");
            if (gamePath.Length > 0)
                Shared.GamePath = gamePath;
            Form1.logFile.WriteLine($"[Shared] Loaded game path: {Shared.GamePath}");
        }

        public static void SaveGamePath ()
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", Shared.GamePathKey, Shared.GamePath);
            IniFiles.Instance.SaveConfig();
            Form1.logFile.WriteLine($"[Shared] Saved game path: {Shared.GamePathKey} = {Shared.GamePath}");
        }

        public static void ClearGamePath()
        {
            Shared.gamePath = "";
        }

        public static String GamePath
        {
            get { return Shared.gamePath; }
            set
            {
                if (value != null && Directory.Exists(value))
                    Shared.gamePath = Path.GetFullPath(value);
            }
        }

        public static String GameEditionSuffix
        {
            get { return Shared.GetEditionSuffix(Shared.GameEdition); }
        }

        public static String GamePathKey
        {
            get { return Shared.GetGamePathKey(Shared.GameEdition); }
        }

        public static String GetGamePathKey(int gameEdition)
        {
            return Shared.GetGamePathKey((GameEdition)gameEdition);
        }

        public static String GetGamePathKey(GameEdition gameEdition)
        {
            return "sGamePath" + GetEditionSuffix(gameEdition);
        }

        public static String GetEditionSuffix(int gameEdition)
        {
            return Shared.GetEditionSuffix((GameEdition)gameEdition);
        }

        public static String GetEditionSuffix(GameEdition gameEdition)
        {
            switch (gameEdition)
            {
                case GameEdition.Steam:
                    return "Steam";
                case GameEdition.BethesdaNet:
                    return "BethesdaNet";
                case GameEdition.BethesdaNetPTS:
                    return "BethesdaNetPTS";
                case GameEdition.MSStore:
                    return "MSStore";
                default:
                    return "";
            }
        }
    }
}
