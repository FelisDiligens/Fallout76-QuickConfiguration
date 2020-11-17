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
    /// Loads, saves, and manages game instances and profiles.
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
                return;
            }

            XDocument xmlDoc = XDocument.Load(XMLPath);

            games.Clear();
            foreach (XElement xmlGame in xmlDoc.Descendants("Game"))
                AddGame(GameInstance.Deserialize(xmlGame));

            SelectedGameIndex = Convert.ToInt32(xmlDoc.Root.Attribute("selected").Value);

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
                    // then convert them.
                    ConvertLegacyFormat();
                }
                else
                {
                    // else create a new game + profile from scratch:
                    Profile defaultProfile = new Profile();
                    defaultProfile.CopyINI();

                    GameInstance defaultGame = new GameInstance();
                    defaultGame.AddProfile(defaultProfile);
                    defaultGame.SelectProfile(defaultProfile);

                    AddGame(defaultGame);
                    SelectGame(defaultGame);
                }
            }
            
            // No game selected?
            if (SelectedGameIndex < 0)
            {
                // Select first game in list:
                SelectedGameIndex = 0;
            }

            Save();
        }

        /// <summary>
        /// Converts legacy profiles from v1.8.4h1 and prior to new format.
        /// </summary>
        private static void ConvertLegacyFormat()
        {
            // sGamePath [ + MSStore / BethesdaNet / BethesdaNetPTS / Steam ]
            // uLaunchOption (1 = OpenURL) (2 = RunExec)
            // uGameEdition

            // Iterate over each possible key:
            List<string> gamePathKeys = new List<string>() { "sGamePathBethesdaNet", "sGamePathSteam", "sGamePathBethesdaNetPTS", "sGamePathMSStore" };
            for (int i = 0; i < gamePathKeys.Count; i++)
            {
                // If key exists:
                if (IniFiles.Config.Exists("Preferences", gamePathKeys[i]))
                {
                    // If the index matches uGameEdition, then this is the default game edition:
                    bool selected = IniFiles.Config.GetUInt("Preferences", "uGameEdition", 0) - 1 == i;

                    // Get the game path. Skip if empty.
                    string gamePath = IniFiles.Config.GetString("Preferences", gamePathKeys[i]);
                    if (gamePath == "")
                        continue;

                    GameInstance game = ConvertLegacyFormat(
                        IniFiles.Config.GetString("Preferences", gamePathKeys[i]),
                        selected,
                        (GameEdition)(i + 1),
                        IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1)
                    );

                    AddGame(game);
                    if (selected)
                        SelectGame(game);
                }
            }
        }

        private static GameInstance ConvertLegacyFormat(string sGamePath, bool selected, GameEdition edition, uint uLaunchOption)
        {
            GameInstance game = new GameInstance();
            game.GamePath = sGamePath;
            if (selected)
                game.PreferredLaunchOption = uLaunchOption == 2 ? LaunchOption.RunExec : LaunchOption.OpenURL;

            game.Edition = edition;
            game.SetDefaultSettings(edition);

            switch (edition)
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

            Profile defaultProfile = new Profile();
            defaultProfile.CopyINI();
            game.AddProfile(defaultProfile);
            game.SelectProfile(defaultProfile);

            return game;
        }

        private static ProfileEventArgs BuildProfileEventArgs()
        {
            ProfileEventArgs args = new ProfileEventArgs();
            args.ActiveGameInstance = SelectedGame;
            args.ActiveProfile = SelectedGame.SelectedProfile;
            args.GameIndex = SelectedGameIndex;
            if (args.ActiveProfile != null)
            {
                args.ProfileIndex = SelectedGame.SelectedProfileIndex;
                args.ProfileGuid = SelectedGame.SelectedProfile.guid;
            }
            return args;
        }
    }

    public delegate void ProfileEventHandler(object sender, ProfileEventArgs e);

    public class ProfileEventArgs : EventArgs
    {
        public GameInstance ActiveGameInstance;
        public Profile ActiveProfile;
        public int GameIndex;
        public int ProfileIndex;
        public Guid ProfileGuid;
    }
}
