using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class ArchiveTwoPathTweak : ITweak<string>, ITweakInfo
    {
        public string Description => "Saves the path where it will load Archive2 from.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "sArchiveTwoPath";

        public string DefaultValue => Archive2.DefaultArchive2Path;

        public string Identifier => this.GetType().FullName;

        public string GetValue()
        {
            return IniFiles.Config.GetString("Preferences", "sArchiveTwoPath", DefaultValue);
        }

        public void SetValue(string value)
        {
            IniFiles.Config.Set("Preferences", "sArchiveTwoPath", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
