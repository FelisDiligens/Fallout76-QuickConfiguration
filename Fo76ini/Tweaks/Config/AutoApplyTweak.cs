using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class AutoApplyTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "No need to press apply anymore.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "bAutoApply";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("Preferences", "bAutoApply", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Preferences", "bAutoApply", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
