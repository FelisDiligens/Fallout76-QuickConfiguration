using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class SevenZipPathTweak : ITweak<string>, ITweakInfo
    {
        public string Description => "Saves the path where it will load 7-zip from.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "sSevenZipPath";

        public string DefaultValue => "./7z/7z.exe";

        public string Identifier => this.GetType().FullName;

        public string GetValue()
        {
            return IniFiles.Config.GetString("Preferences", "sSevenZipPath", DefaultValue);
        }

        public void SetValue(string value)
        {
            IniFiles.Config.Set("Preferences", "sSevenZipPath", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
