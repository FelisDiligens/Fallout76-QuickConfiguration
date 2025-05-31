using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class EnableMuzzleFlashesTweaks : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]bEnableMuzzleFlashes";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("MAIN", "bEnableMuzzleFlashes", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("MAIN", "bEnableMuzzleFlashes", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
