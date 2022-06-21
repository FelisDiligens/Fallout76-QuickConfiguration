using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class ShowWhatsNewTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Requires a restart.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "bShowWhatsNew";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("Preferences", "bShowWhatsNew", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Preferences", "bShowWhatsNew", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
