using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class BackpackVisibleTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]bShowBackpack";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("MAIN", "bShowBackpack", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("MAIN", "bShowBackpack", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
