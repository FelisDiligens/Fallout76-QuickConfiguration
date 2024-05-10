using System;
using System.IO;
using System.Windows.Forms;
using Syroot.Windows.IO;

namespace Fo76ini
{
    /// <summary>
    /// This class holds application-wide constants, such as paths, URLs, version, and so on.
    /// </summary>
    public class Shared
    {
        public const string VERSION = "1.12.7";
        public static string LatestVersion = null;

        public static readonly string AppInstallationFolder = Directory.GetParent(Application.ExecutablePath).ToString();
        public static readonly string AppConfigFolder = Path.Combine(KnownFolders.LocalAppData.Path, "Fallout 76 Quick Configuration");
        public static readonly string AppTranslationsFolder = Path.Combine(Shared.AppConfigFolder, "languages");

        public static readonly System.Globalization.CultureInfo en_US = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        // https://stackoverflow.com/a/49754978
        public static readonly string DotNetFrameworkVersion;

        /// <summary>
        /// Used when communicating with the NexusMods API.
        /// Example: "Fo76QuickConfiguration/1.9.6 (Windows NT 10.0.19042.0; x64) .NETFramework/4.7.2"
        /// </summary>
        public static readonly string AppUserAgent;

        /// <summary>
        /// URLs used across the app are (mostly) stored here.
        /// </summary>
        public class URLs
        {
            // "Official" websites of Quick Configuration:
            public const string AppNexusModsURL = "https://www.nexusmods.com/fallout76/mods/546";
            public const string AppNexusModsDownloadURL = "https://www.nexusmods.com/fallout76/mods/546?tab=files";
            public const string AppGithubURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration";
            public const string AppGithubDownloadURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/releases/latest";

            // Help and Troubleshooting:
            public const string AppGithubWikiURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki";
            public const string AppModManagerHelpURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Mod-Manager-Guide";
            public const string AppNexusLoginFailedHelpURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Troubleshooting:-Login-with-NexusMods-failed";
            public const string AppINIErrorHelpURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Troubleshooting:-*.ini-files";
            public const string AppGameProfilesHelpURL = "https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Game-Profiles";

            // Remote files:
            // (These files are downloaded by the tool)
            public const string RemoteWhatsNewURL = "https://felisdiligens.github.io/Fo76ini/whatsnew";
            public const string RemoteWhatsNewDarkURL = "https://felisdiligens.github.io/Fo76ini/whatsnewdark";
            public const string RemoteLanguageFolderURL = "https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/";
        }

        static Shared ()
        {
            // Find DotNetFrameworkVersion:
            string DotNetTargetFrameworkName = AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
            int i = DotNetTargetFrameworkName.IndexOf("v");
            if (i >= 0)
                DotNetFrameworkVersion = DotNetTargetFrameworkName.Substring(i + 1);
            else
                DotNetFrameworkVersion = DotNetTargetFrameworkName;

            // Build user-agent:
            string os = "";
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                os = $"Windows NT {Environment.OSVersion.Version}; ";
            else
                os = $"{Environment.OSVersion.Platform} {Environment.OSVersion.Version}; ";

            if (Environment.Is64BitOperatingSystem)
                os += "x64";
            else
                os += "x86";

            AppUserAgent = $"Fo76QuickConfiguration/{Shared.VERSION} ({os}) .NETFramework/{Shared.DotNetFrameworkVersion}";
        }
    }
}
