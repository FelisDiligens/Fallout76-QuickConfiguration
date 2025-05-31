using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class AdvancedModDescriptionsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Show detailed numerical breakdown of stat changes when choosing weapon and armor mods";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]bAdvancedModDescriptions";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("MAIN", "bAdvancedModDescriptions", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("MAIN", "bAdvancedModDescriptions", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}