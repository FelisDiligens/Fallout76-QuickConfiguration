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
    public class ProfileManager
    {
        public List<GameInstance> Games = new List<GameInstance>();
        public int SelectedGameIndex;

        public static string XMLPath = Path.Combine(Shared.AppConfigFolder, "profiles.xml");

        public void AddGame(GameInstance game)
        {
            this.Games.Add(game);
        }

        public void RemoveGame(GameInstance game)
        {
            this.Games.Remove(game);
        }

        public int FindIndex(GameInstance game)
        {
            return Games.FindIndex((GameInstance search) => search == game);
        }

        public void SelectGame(GameInstance game)
        {
            this.SelectedGameIndex = FindIndex(game);
        }

        public GameInstance SelectedGame
        {
            get
            {
                if (SelectedGameIndex < 0 || SelectedGameIndex >= Games.Count)
                    return null;
                return Games[SelectedGameIndex];
            }
        }

        public bool IsSelected(GameInstance game)
        {
            return SelectedGameIndex >= 0 && SelectedGameIndex == FindIndex(game);
        }

        /*public Profile SelectedProfile
        {
            get { return games[selectedGameGuid].SelectedProfile; }
        }*/

        public void Save()
        {
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Games",
                new XAttribute("selected", SelectedGameIndex)
            );

            foreach (GameInstance game in Games)
                xmlRoot.Add(game.Serialize());

            xmlDoc.Add(xmlRoot);
            xmlDoc.Save(XMLPath);
        }

        public void Load()
        {
            if (!File.Exists(XMLPath))
            {
                Init();
                return;
            }

            XDocument xmlDoc = XDocument.Load(XMLPath);

            this.Games.Clear();
            foreach (XElement xmlGame in xmlDoc.Descendants("Game"))
                this.AddGame(GameInstance.Deserialize(xmlGame));

            this.SelectedGameIndex = Convert.ToInt32(xmlDoc.Root.Attribute("selected").Value);
        }

        private void Init()
        {
            // If tool has been started for the first time, no profiles are available.
            // Create profiles and save the xml.

            // No games?
            if (Games.Count == 0)
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

                    this.AddGame(defaultGame);
                    this.SelectGame(defaultGame);
                }
            }
            
            // No game selected?
            if (this.SelectedGameIndex < 0)
            {
                // Select first game in list:
                this.SelectedGameIndex = 0;
            }

            this.Save();
        }

        /// <summary>
        /// Converts legacy profiles from v1.8.4h1 and prior to new format.
        /// </summary>
        private void ConvertLegacyFormat()
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

                    this.AddGame(game);
                    if (selected)
                        this.SelectGame(game);
                }
            }
        }

        private GameInstance ConvertLegacyFormat(string sGamePath, bool selected, GameEdition edition, uint uLaunchOption)
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
    }
}
