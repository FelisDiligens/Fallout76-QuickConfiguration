using Fo76ini.Interface;
using Fo76ini.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini.Profiles
{
    public enum GameEdition
    {
        Unknown = 0,
        Steam = 2,
        SteamPTS = 5,
        Xbox = 4,
        MSStore = 4,
        BethesdaNet = 1,
        BethesdaNetPTS = 3
    }

    public enum LaunchOption
    {
        OpenURL = 0, // Launch through Steam or Xbox
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
        public string ModsPath = "";
        public string ExecutableName = "Fallout76.exe";
        public string IniPrefix = "Fallout76";
        public string IniParentPath = IniFiles.DefaultParentPath;
        public string ExecParameters = "";
        public string LauncherURL = "";
        public LaunchOption PreferredLaunchOption = LaunchOption.OpenURL;

        /// <summary>
        /// Sets the default settings (such as executable name, ini prefix, and launcher url) for the game edition.
        /// </summary>
        public void SetDefaultSettings(GameEdition edition)
        {
            this.IniParentPath = IniFiles.DefaultParentPath;
            this.IniPrefix = "Fallout76";
            this.ExecutableName = "Fallout76.exe";
            this.PreferredLaunchOption = LaunchOption.OpenURL;

            switch (edition)
            {
                case GameEdition.Steam:
                    this.LauncherURL = "steam://run/1151340";
                    break;
                case GameEdition.SteamPTS:
                    this.LauncherURL = "steam://run/1836200";
                    break;
                case GameEdition.Xbox:
                    this.ExecutableName = "Project76_GamePass.exe";
                    this.IniPrefix = "Project76";
                    /*
                     * Store link: @"ms-windows-store://pdp/?ProductId=9nkgnmnk3k3z"
                     * Launch URL: @"shell:appsfolder\BethesdaSoftworks.Fallout76-PC_3275kfvn8vcwc!Fallout76"
                     * 
                     * Found a solution to launch the Xbox version of Fallout 76:
                     * https://stackoverflow.com/questions/32074404/launching-windows-10-store-apps
                     * https://stackoverflow.com/a/67156442
                     * 
                     * Enter in PowerShell:
                     *    PS C:\> Get-StartApps
                     *            ^ The above will return a list:
                     *            
                     *    Name                                                 AppID
                     *    ----                                                 -----
                     *    ...
                     *    Fallout 76                                           BethesdaSoftworks.Fallout76-PC_3275kfvn8vcwc!Fallout76
                     *    
                     * To start the app, enter in CMD:
                     *    C:\> explorer shell:appsfolder\BethesdaSoftworks.Fallout76-PC_3275kfvn8vcwc!Fallout76
                     *    
                     * This also works with Process.Start(@"shell:appsfolder\BethesdaSoftworks.Fallout76-PC_3275kfvn8vcwc!Fallout76");
                     */
                    this.LauncherURL = @"shell:appsfolder\BethesdaSoftworks.Fallout76-PC_3275kfvn8vcwc!Fallout76";
                    break;
                case GameEdition.BethesdaNet:
                    this.LauncherURL = "bethesdanet://run/20";
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.LauncherURL = "bethesdanet://run/57";
                    break;
                default:
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
                new XElement("ModsPath", ModsPath),
                new XElement("ExecutableName", ExecutableName),
                new XElement("ExecParameters", ExecParameters),
                new XElement("LauncherURL", LauncherURL),
                new XElement("IniPrefix", IniPrefix),
                new XElement("IniPath", IniParentPath),
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

            if (xmlGameInstance.Element("ModsPath") != null)
                game.ModsPath = xmlGameInstance.Element("ModsPath").Value;

            if (xmlGameInstance.Element("IniPath") != null)
                game.IniParentPath = xmlGameInstance.Element("IniPath").Value;

            if (!game.ValidateIniPath())
                game.IniParentPath = IniFiles.DefaultParentPath;

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
                    catch (Exception ex)
                    {
                        MsgBox.Show("Couldn't start game", $"Please make sure to provide a valid 'Launcher URL'.\n\n{ex.GetType()}: {ex.Message}", MessageBoxIcon.Error);
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
                    catch (Exception ex)
                    {
                        MsgBox.Show("Couldn't start game", $"Please make sure that the game path and executable name are correct.\n\n{ex.GetType()}: {ex.Message}", MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        public static bool ValidateIniPath(string path)
        {
            return
                path != null &&
                path.Trim().Length > 0 &&
                Directory.Exists(path);
        }

        public bool ValidateIniPath()
        {
            return ValidateIniPath(IniParentPath);
        }

        /// <summary>
        /// Checks whether the passed on game path is valid.
        /// </summary>
        public static bool ValidateGamePath(string path)
        {
            return
                path != null &&
                path.Trim().Length > 0 &&
                Directory.Exists(path) &&
                Directory.Exists(Path.Combine(path, "Data")) &&
                File.Exists(Path.Combine(path, "Data", "SeventySix.esm"));
        }

        /// <summary>
        /// Checks whether the current game path is valid.
        /// </summary>
        public bool ValidateGamePath()
        {
            return ValidateGamePath(GamePath);
        }

        /// <summary>
        /// Checks whether the passed on mods path is valid.
        /// </summary>
        public static bool ValidateModsPath(string path)
        {
            // TODO!
            return
                path != null &&
                path.Trim().Length > 0 &&
                Directory.Exists(path);
        }

        /// <summary>
        /// Checks whether the current mods path is valid.
        /// </summary>
        public bool ValidateModsPath()
        {
            return ValidateModsPath(ModsPath);
        }

        public static string AutoDetectGamePath()
        {
            /*
             * I could totally search through every single folder on a user's computer, but that would take way too long. So, I'll take shortcuts.
             * This is not about to find a path for every user 100% of the time, but an attempt to find a path for MOST users in the shortest amount of time.
             * If it can't find the path, the user likely knows enough about their computer to find it themselves. Even if it's a bit inconvenient.
             */

            // Search every drive:
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                // Only search fixed drives:
                if (d.DriveType != DriveType.Fixed)
                    continue;

                // Search for "default" paths that are the most common:
                string steamDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Steam\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Bethesda.net launcher - no longer in use
                /*
                string bethNetDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Bethesda.net Launcher\games\Fallout76");
                if (GameInstance.ValidateGamePath(bethNetDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(bethNetDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return bethNetDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }
                */

                // Old Xbox default path
                string xboxModifiablePath = Path.Combine(d.Name, @"Program Files\ModifiableWindowsApps\Fallout 76");
                if (GameInstance.ValidateGamePath(xboxModifiablePath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxModifiablePath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxModifiablePath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // New Xbox default path
                string xboxDefaultPath = Path.Combine(d.Name, @"XboxGames\Fallout 76\Content");
                if (GameInstance.ValidateGamePath(xboxDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // When you create a library on a drive through Steam's 
                string steamLibraryPath = Path.Combine(d.Name, @"SteamLibrary\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamLibraryPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamLibraryPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamLibraryPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Search every top-level folder on the drive:
                foreach (string path in Directory.EnumerateDirectories(d.Name))
                {
                    if (GameInstance.ValidateGamePath(path))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(path).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return path;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // Search for a steamapps folder:
                    string steamSubDirPath = Path.Combine(path, @"steamapps\common\Fallout76");
                    if (GameInstance.ValidateGamePath(steamSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return steamSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // New Xbox path:
                    string xboxSubDirPath = Path.Combine(d.Name, @"Fallout 76\Content");
                    if (GameInstance.ValidateGamePath(xboxSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return xboxSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }
                }
            }

            return null;
        }

        public Bitmap Get24pxBitmap()
        {
            return Get24pxBitmap(this.Edition);
        }

        public static Bitmap Get24pxBitmap(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.Steam:
                case GameEdition.SteamPTS:
                    return Resources.steam_24px;
                case GameEdition.BethesdaNet:
                case GameEdition.BethesdaNetPTS:
                    return Resources.bethesda_24;
                case GameEdition.Xbox:
                    return Resources.xbox_24;
                default:
                    return Resources.help_24;
            }
        }

        public Bitmap Get128pxBitmap()
        {
            return Get128pxBitmap(this.Edition);
        }

        public static Bitmap Get128pxBitmap(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.Steam:
                case GameEdition.SteamPTS:
                    return Resources.steam;
                case GameEdition.BethesdaNet:
                    return Resources.bethesda;
                case GameEdition.BethesdaNetPTS:
                    return Resources.bethesda_pts;
                case GameEdition.Xbox:
                    //return Resources.msstore;
                    return Resources.xbox;
                default:
                    return Resources.help_128;
            }
        }

        public Bitmap Get128pxHoverBitmap()
        {
            return Get128pxHoverBitmap(this.Edition);
        }

        public static Bitmap Get128pxHoverBitmap(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.Steam:
                    return Resources.steam_hover;
                case GameEdition.SteamPTS:
                    return Resources.steam_hover;
                case GameEdition.BethesdaNet:
                    return Resources.bethesda_hover;
                case GameEdition.BethesdaNetPTS:
                    return Resources.bethesda_pts_hover;
                case GameEdition.Xbox:
                    //return Resources.msstore_hover;
                    return Resources.xbox_hover;
                default:
                    return Resources.help_128_hover;
            }
        }

        public string GetCaption()
        {
            return GetCaption(this.Edition);
        }

        public static string GetCaption(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.Steam:
                    return "Steam";
                case GameEdition.SteamPTS:
                    return "Steam (PTS)";
                case GameEdition.BethesdaNet:
                    return "Bethesda.net";
                case GameEdition.BethesdaNetPTS:
                    return "Bethesda.net (PTS)";
                case GameEdition.Xbox:
                    return "Xbox";
                default:
                    return Localization.GetString("unknown");
            }
        }
    }
}
