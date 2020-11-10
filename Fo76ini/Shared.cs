using System.IO;
using System.Windows.Forms;
using Fo76ini.Profiles;

namespace Fo76ini
{
    public class Shared
    {
        public const string VERSION = "2.0.0";
        public static string LatestVersion = null;

        public static string AppInstallationFolder = Directory.GetParent(Application.ExecutablePath).ToString();
        public static string AppConfigFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Fallout 76 Quick Configuration");

        public static readonly System.Globalization.CultureInfo en_US = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        private static string gamePath = null;

        public static GameEdition GameEdition = GameEdition.Unknown;

        public static bool NuclearWinterMode = false;

        public static void LoadGameEdition()
        {
            Shared.GameEdition = (GameEdition)(IniFiles.Config.GetInt("Preferences", "uGameEdition", 0));
        }

        public static void SaveGameEdition()
        {
            IniFiles.Config.Set("Preferences", "uGameEdition", (uint)Shared.GameEdition);
        }

        public static void ChangeGameEdition(GameEdition gameEdition)
        {
            Shared.GameEdition = gameEdition;

            // ManagedMods:
            // ManagedMods.Instance.CopyINILists();

            // IniFiles:
            // TODO: ChangeGameEdition
            //IniFiles.ChangeGameEdition(Shared.GameEdition);
            SaveGameEdition();

            // ManagedMods:
            Shared.LoadGamePath();
            //ManagedMods.Instance.Load();

            // FormMods:
            // formMods.UpdateUI();
        }

        public static void LoadGamePath()
        {
            string gamePath = IniFiles.Config.GetString("Preferences", Shared.GamePathKey, "");
            if (gamePath.Length > 0)
                Shared.GamePath = gamePath;
        }

        public static void SaveGamePath()
        {
            IniFiles.Config.Set("Preferences", Shared.GamePathKey, Shared.GamePath);
            IniFiles.Config.Save();
        }

        public static void ClearGamePath()
        {
            Shared.gamePath = "";
        }

        public static bool ValidateGamePath(string path)
        {
            return path != null && path.Trim().Length > 0 && Directory.Exists(path) && Directory.Exists(Path.Combine(path, "Data"));
        }

        public static bool ValidateGamePath()
        {
            return ValidateGamePath(Shared.GamePath);
        }

        public static string GamePath
        {
            get { return Shared.gamePath; }
            set
            {
                if (value != null && Directory.Exists(value))
                    Shared.gamePath = Path.GetFullPath(value);
            }
        }

        public static string GameEditionSuffix
        {
            get { return Shared.GetEditionSuffix(Shared.GameEdition); }
        }

        public static string GamePathKey
        {
            get { return Shared.GetGamePathKey(Shared.GameEdition); }
        }

        public static string GetGamePathKey(int gameEdition)
        {
            return Shared.GetGamePathKey((GameEdition)gameEdition);
        }

        public static string GetGamePathKey(GameEdition gameEdition)
        {
            return "sGamePath" + GetEditionSuffix(gameEdition);
        }

        public static string GetEditionSuffix(int gameEdition)
        {
            return Shared.GetEditionSuffix((GameEdition)gameEdition);
        }

        public static string GetEditionSuffix(GameEdition gameEdition)
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
