using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        /// <summary>
        /// Raises the ProfileChanged event.
        /// </summary>
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
                // then create a new game profile from scratch:
                CreateNewDefaultProfile();
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
            if (File.Exists(Path.Combine(IniFiles.DefaultParentPath, "Project76.ini")))
            {
                // "Project76.ini" exists, which means the user has it from the Microsoft Store
                defaultGame.Edition = GameEdition.Xbox;
                defaultGame.SetDefaultSettings(GameEdition.Xbox);
            }
            AddGame(defaultGame);
            SelectGame(defaultGame);
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
