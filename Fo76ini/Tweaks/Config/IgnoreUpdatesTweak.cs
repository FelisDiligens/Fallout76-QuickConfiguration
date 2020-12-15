using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class IgnoreUpdatesTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Won't check for updates on startup and hides the big update button.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "bIgnoreUpdates";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("Preferences", "bIgnoreUpdates", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Preferences", "bIgnoreUpdates", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
