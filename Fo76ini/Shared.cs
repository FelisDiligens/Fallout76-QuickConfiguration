using System;
using System.IO;
using System.Windows.Forms;
using Fo76ini.Profiles;

namespace Fo76ini
{
    public class Shared
    {
        public const string VERSION = "1.9.0";
        public static string LatestVersion = null;

        public static string AppInstallationFolder = Directory.GetParent(Application.ExecutablePath).ToString();
        public static string AppConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fallout 76 Quick Configuration");

        public static readonly System.Globalization.CultureInfo en_US = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        public static bool NuclearWinterMode = false;
    }
}
