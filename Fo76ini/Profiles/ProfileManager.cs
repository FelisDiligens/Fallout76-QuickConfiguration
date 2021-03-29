using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fo76ini.Profiles
{
    /// <summary>
    /// Loads, saves, and manages game profiles.
    /// </summary>
    public static class ProfileManager
    {
        public static event ProfileEventHandler ProfileChanged;
        private static List<GameInstance> games = new List<GameInstance>();
        private static int selectedGameIndex;

        public static IEnumerable<GameInstance> Games
        {
            get { return games.Select(x => x); }
        }

        public static int Count
        {
            get { return games.Count; }
        }

        public static int SelectedGameIndex
        {
            get { return selectedGameIndex; }
            set
            {
                selectedGameIndex = value;
                Feedback();
            }
        }

        public static void Feedback()
        {
            if (ProfileChanged != null)
                ProfileChanged(null, BuildProfileEventArgs());

            // Backwards-compatibility:
            IniFiles.Config.Set("Preferences", "uGameEdition", (int)SelectedGame.Edition);
            IniFiles.Config.Set("Preferences", "sGamePath", SelectedGame.GamePath);
            IniFiles.Config.Set("Preferences", $"sGamePath{SelectedGame.Edition}", SelectedGame.GamePath);
        }

        public static string XMLPath = Path.Combine(Shared.AppConfigFolder, "profiles.xml");

        public static void AddGame(GameInstance game)
        {
            games.Add(game);
        }

        public static void RemoveGame(GameInstance game)
        {
            games.Remove(game);
        }

        public static int FindIndex(GameInstance game)
        {
            return games.FindIndex((GameInstance search) => search == game);
        }

        public static void SelectGame(GameInstance game)
        {
            SelectedGameIndex = FindIndex(game);
        }

        public static GameInstance SelectedGame
        {
            get
            {
                if (SelectedGameIndex < 0 || SelectedGameIndex >= games.Count)
                    return null;
                return games[SelectedGameIndex];
            }
        }

        public static bool IsSelected(GameInstance game)
        {
            return SelectedGameIndex >= 0 && SelectedGameIndex == FindIndex(game);
        }

        /*public Profile SelectedProfile
        {
            get { return games[selectedGameGuid].SelectedProfile; }
        }*/

        public static void Save()
        {
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Games",
                new XAttribute("selected", SelectedGameIndex)
            );

            foreach (GameInstance game in games)
                xmlRoot.Add(game.Serialize());

            xmlDoc.Add(xmlRoot);
            xmlDoc.Save(XMLPath);
        }

        public static void Load()
        {
            if (!File.Exists(XMLPath))
            {
                Init();
                Feedback(); // This is important.
                return;
            }

            XDocument xmlDoc = XDocument.Load(XMLPath);

            games.Clear();
            foreach (XElement xmlGame in xmlDoc.Descendants("Game"))
                AddGame(GameInstance.Deserialize(xmlGame));

            if (games.Count > 0)
            {
                int index = Convert.ToInt32(xmlDoc.Root.Attribute("selected").Value);
                if (index < 0 || index >= games.Count)
                    SelectedGameIndex = 0;
                else
                    SelectedGameIndex = index;
            }
            else
            {
                CreateNewDefaultProfile();
            }

            // Call event handler:
            Feedback();
        }

        private static void Init()
        {
            // If tool has been started for the first time, no profiles are available.
            // Create profiles and save the xml.

            // No games?
            if (games.Count == 0)
            {
                // Do we have legacy profiles?
                if (IniFiles.Config != null && IniFiles.Config.Exists("Preferences", "uGameEdition"))
                {
                    // then convert them:
                    ConvertLegacyFormat();
                }
                else
                {
                    // else create a new game profile from scratch:
                    CreateNewDefaultProfile();
                }
            }
            
            // No game selected?
            if (SelectedGameIndex < 0 || SelectedGameIndex >= games.Count)
            {
                // Select first game in list:
                SelectedGameIndex = 0;
            }

            Save();
        }

        private static void CreateNewDefaultProfile()
        {
            GameInstance defaultGame = new GameInstance();
            if (File.Exists(Path.Combine(IniFiles.ParentPath, "Project76.ini")))
            {
                // "Project76.ini" exists, which means the user has it from the Microsoft Store
                defaultGame.Edition = GameEdition.MSStore;
                defaultGame.SetDefaultSettings(GameEdition.MSStore);
            }
            AddGame(defaultGame);
            SelectGame(defaultGame);
        }

        /// <summary>
        /// Converts legacy profiles from v1.8.4h1 and prior to new format.
        /// </summary>
        private static void ConvertLegacyFormat()
        {
            // Some people might have denied NTFS write permission. Give permission back:
            IniFiles.SetNTFSWritePermission(true);
            IniFiles.Config.Remove("Preferences", "bDenyNTFSWritePermission");

            // If NWMode was active, then the Fallout76Custom.ini might have been renamed to Fallout76Custom.ini.nwmodebak
            // Rename it back:
            string f76C_NW = Path.Combine(IniFiles.ParentPath, "Fallout76Custom.ini.nwmodebak");
            string f76C = Path.Combine(IniFiles.ParentPath, "Fallout76Custom.ini");
            string p76C_NW = Path.Combine(IniFiles.ParentPath, "Project76Custom.ini.nwmodebak");
            string p76C = Path.Combine(IniFiles.ParentPath, "Project76Custom.ini");
            if (File.Exists(f76C_NW) && !File.Exists(f76C))
                File.Move(f76C_NW, f76C);
            if (File.Exists(p76C_NW) && !File.Exists(p76C))
                File.Move(p76C_NW, p76C);

            // sGamePath [ + MSStore / BethesdaNet / BethesdaNetPTS / Steam ]
            // uLaunchOption (1 = OpenURL) (2 = RunExec)
            // uGameEdition

            // Iterate over each possible key:
            List<GameEdition> editions = new List<GameEdition> { GameEdition.BethesdaNet, GameEdition.Steam, GameEdition.BethesdaNetPTS, GameEdition.MSStore };
            List<string> gamePathKeys = new List<string>() { "sGamePathBethesdaNet", "sGamePathSteam", "sGamePathBethesdaNetPTS", "sGamePathMSStore" };
            for (int i = 0; i < gamePathKeys.Count; i++)
            {
                // Get the game path. Skip if empty.
                string gamePath = IniFiles.Config.GetString("Preferences", gamePathKeys[i], "");
                if (gamePath == "")
                    continue;

                GameInstance game = new GameInstance();
                game.GamePath = gamePath;
                game.Edition = editions[i]; // (GameEdition)(i + 1)
                game.SetDefaultSettings(game.Edition);

                // If the index matches uGameEdition, then this is the default game edition:
                bool selected = IniFiles.Config.GetUInt("Preferences", "uGameEdition", 0) - 1 == i;

                if (selected)
                {
                    uint uLaunchOption = IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1);
                    game.PreferredLaunchOption = uLaunchOption == 2 ? LaunchOption.RunExec : LaunchOption.OpenURL;
                }

                switch (game.Edition)
                {
                    case GameEdition.BethesdaNet:
                        game.Title = "Bethesda.net";
                        break;
                    case GameEdition.BethesdaNetPTS:
                        game.Title = "Bethesda.net (PTS)";
                        break;
                    case GameEdition.Steam:
                        game.Title = "Steam";
                        break;
                    case GameEdition.MSStore:
                        game.Title = "Microsoft Store";
                        break;
                }

                AddGame(game);
                if (selected)
                    SelectGame(game);
            }

            // No previous game edition found?
            // Create a new one:
            // CreateNewDefaultProfile();
            // EDIT: Creating a new profile is no longer necessary.
            //       At least, that's what I believe. I'll keep this comment here until I'm certain.
        }

        private static ProfileEventArgs BuildProfileEventArgs()
        {
            ProfileEventArgs args = new ProfileEventArgs();
            args.ActiveGameInstance = SelectedGame;
            args.GameIndex = SelectedGameIndex;
            return args;
        }
    }

    public delegate void ProfileEventHandler(object sender, ProfileEventArgs e);

    public class ProfileEventArgs : EventArgs
    {
        public GameInstance ActiveGameInstance;
        public int GameIndex;
    }
}
