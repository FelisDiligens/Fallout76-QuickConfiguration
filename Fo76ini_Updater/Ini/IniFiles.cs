using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Fo76ini
{
    public static class IniFiles
    {
        public static IniFile Config;

        /// <summary>
        /// "%LOCALAPPDATA%\Fallout 76 Quick Configuration\config.ini"
        /// </summary>
        public static readonly string ConfigPath;

        static IniFiles()
        {
            ConfigPath = Path.Combine(Shared.AppConfigFolder, "config.ini");
        }

        /// <summary>
        /// (Re)Loads config.ini.
        /// </summary>
        public static void LoadConfig()
        {
            Config = new IniFile(ConfigPath);
            Config.Load(ignoreErrors: true);
        }

        /// <summary>
        /// Makes a backup, then saves xyz.ini, xyzPrefs.ini, xyzCustom.ini, and config.ini.
        /// </summary>
        public static void SaveConfig()
        {
            Config.Save();
        }
    }
}
