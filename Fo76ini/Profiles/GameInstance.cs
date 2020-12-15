using Fo76ini.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace Fo76ini.Profiles
{
    public enum GameEdition
    {
        Unknown = 0,
        BethesdaNet = 1,
        Steam = 2,
        BethesdaNetPTS = 3,
        MSStore = 4
    }

    public enum LaunchOption
    {
        OpenURL = 0, // Launch through Steam or Bethesda.net
        RunExec = 1  // Run executable directly
    }

    /// <summary>
    /// Represents a game installation. Contains information such as path and executable name.
    /// </summary>
    public class GameInstance
    {
        public string Title = "Untitled";
        public GameEdition Edition = GameEdition.Unknown;
        public string GamePath = "";
        public string ExecutableName = "Fallout76.exe";
        public string IniPrefix = "Fallout76";
        public string ExecParameters = "";
        public string LauncherURL;
        public LaunchOption PreferredLaunchOption = LaunchOption.OpenURL;

        /// <summary>
        /// Sets the default settings (such as executable name, ini prefix, and launcher url) for the game edition.
        /// </summary>
        public void SetDefaultSettings(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.Steam:
                    this.ExecutableName = "Fallout76.exe";
                    this.IniPrefix = "Fallout76";
                    this.LauncherURL = "steam://run/1151340";
                    this.PreferredLaunchOption = LaunchOption.OpenURL;
                    break;
                case GameEdition.BethesdaNet:
                    this.ExecutableName = "Fallout76.exe";
                    this.IniPrefix = "Fallout76";
                    this.LauncherURL = "bethesdanet://run/20";
                    this.PreferredLaunchOption = LaunchOption.OpenURL;
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.ExecutableName = "Fallout76.exe";
                    this.IniPrefix = "Fallout76";
                    this.LauncherURL = "bethesdanet://run/57";
                    this.PreferredLaunchOption = LaunchOption.OpenURL;
                    break;
                case GameEdition.MSStore:
                    this.ExecutableName = "Project76_GamePass.exe";
                    this.IniPrefix = "Project76";
                    this.LauncherURL = "ms-windows-store://pdp/?ProductId=9nkgnmnk3k3z";
                    this.PreferredLaunchOption = LaunchOption.OpenURL;
                    break;
                default:
                    this.ExecutableName = "Fallout76.exe";
                    this.IniPrefix = "Fallout76";
                    this.LauncherURL = "";
                    this.PreferredLaunchOption = LaunchOption.RunExec;
                    break;
            }
        }

        public XElement Serialize ()
        {
            XElement xmlGameInstance = new XElement("Game",
                new XElement("Title", Title),
                new XElement("InstallationPath", GamePath),
                new XElement("ExecutableName", ExecutableName),
                new XElement("ExecParameters", ExecParameters),
                new XElement("LauncherURL", LauncherURL),
                new XElement("IniPrefix", IniPrefix),
                new XElement("GameEdition", Edition.ToString()),
                new XElement("LaunchOption", PreferredLaunchOption.ToString())
            );

            return xmlGameInstance;
        }

        public static GameInstance Deserialize (XElement xmlGameInstance)
        {
            GameInstance game = new GameInstance();

            game.Title = xmlGameInstance.Element("Title").Value;
            game.GamePath = xmlGameInstance.Element("InstallationPath").Value;
            game.ExecutableName = xmlGameInstance.Element("ExecutableName").Value;
            game.ExecParameters = xmlGameInstance.Element("ExecParameters").Value;
            game.LauncherURL = xmlGameInstance.Element("LauncherURL").Value;
            game.IniPrefix = xmlGameInstance.Element("IniPrefix").Value;

            if (Enum.TryParse(xmlGameInstance.Element("GameEdition").Value, out GameEdition edition))
                game.Edition = edition;

            if (Enum.TryParse(xmlGameInstance.Element("LaunchOption").Value, out LaunchOption launchOption))
                game.PreferredLaunchOption = launchOption;

            return game;
        }

        /// <summary>
        /// Starts the game using the preferred launch option.
        /// </summary>
        public void LaunchGame()
        {
            LaunchGame(this.PreferredLaunchOption);
        }

        /// <summary>
        /// Starts the game using the passed on launch option.
        /// </summary>
        /// <param name="option">Whether to run the executable or open the launcher url.</param>
        public void LaunchGame(LaunchOption option)
        {
            switch (option)
            {
                case LaunchOption.OpenURL:
                    try
                    {
                        Process.Start(this.LauncherURL);
                    }
                    catch
                    {
                        MsgBox.Show("Couldn't start game", "Please make sure to provide a valid 'Launcher URL'.", System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    break;
                case LaunchOption.RunExec:
                    try
                    {
                        Process pr = new Process();
                        pr.StartInfo.FileName = Path.Combine(this.GamePath, this.ExecutableName);
                        pr.StartInfo.WorkingDirectory = this.GamePath;
                        pr.StartInfo.Arguments = this.ExecParameters;
                        pr.StartInfo.UseShellExecute = false;
                        pr.Start();
                    }
                    catch
                    {
                        MsgBox.Show("Couldn't start game", "Please make sure that the game path and executable name are correct.", System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        /// <summary>
        /// Checks whether the passed on game path is valid.
        /// </summary>
        public static bool ValidateGamePath(string path)
        {
            return path != null && path.Trim().Length > 0 && Directory.Exists(path) && Directory.Exists(Path.Combine(path, "Data"));
        }

        /// <summary>
        /// Checks whether the current game path is valid.
        /// </summary>
        public bool ValidateGamePath()
        {
            return ValidateGamePath(GamePath);
        }
    }
}
