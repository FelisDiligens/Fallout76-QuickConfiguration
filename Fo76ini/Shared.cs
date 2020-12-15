using System;
using System.IO;
using System.Windows.Forms;
using Fo76ini.Profiles;

namespace Fo76ini
{
    public class Shared
    {
        public const string VERSION = "1.9.0h1";
        public static string LatestVersion = null;

        public static readonly string AppInstallationFolder = Directory.GetParent(Application.ExecutablePath).ToString();
        public static readonly string AppConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fallout 76 Quick Configuration");

        public static readonly System.Globalization.CultureInfo en_US = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        public static bool NuclearWinterMode = false;

        // https://stackoverflow.com/a/49754978
        public static readonly string DotNetFrameworkVersion;

        // Example: "Fo76QConf/1.9.0 (Windows NT 10.0.19042.0; x64) .NETFramework/4.7.2"
        public static readonly string AppUserAgent;

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
