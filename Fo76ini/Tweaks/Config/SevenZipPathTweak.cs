using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class SevenZipPathTweak : ITweak<string>, ITweakInfo
    {
        public string Description => "The tool uses 7z.exe to extract various archives (zip, rar, 7z).\nYou can set the path where the tool looks for 7z.exe.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "sSevenZipPath";

        public string DefaultValue => Utils.DefaultSevenZipPath;

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
