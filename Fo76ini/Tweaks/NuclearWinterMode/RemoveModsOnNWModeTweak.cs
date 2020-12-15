using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.NuclearWinterMode
{
    class RemoveModsOnNWModeTweak : ITweak<bool>, ITweakInfo
    {
        public string Identifier => this.GetType().FullName;

        public string Description => "If checked, mods will be removed when the Nuclear Winter mode is enabled.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "[NuclearWinter]bAutoDisableMods";

        public bool DefaultValue => true;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("NuclearWinter", "bAutoDisableMods", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("NuclearWinter", "bAutoDisableMods", value);
        }

        public void ResetValue()
        {
            IniFiles.Config.Set("NuclearWinter", "bAutoDisableMods", DefaultValue);
        }
    }
}
