using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    public class DownloadPathTweak : ITweak<string>, ITweakInfo
    {
        public string Description => "When you download mods using the 'Vortex' / 'Mod Manager Download' button on NexusMods,\nthe tool will download the file to this folder.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "sDownloadPath";

        public string DefaultValue => KnownFolders.Downloads.Path;

        public string Identifier => this.GetType().FullName;

        public string GetValue()
        {
            return IniFiles.Config.GetString("Preferences", "sDownloadPath", DefaultValue);
        }

        public void SetValue(string value)
        {
            IniFiles.Config.Set("Preferences", "sDownloadPath", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
