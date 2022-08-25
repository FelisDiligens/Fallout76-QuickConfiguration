using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterShadowFilterTweak : ITweak<int>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]uWaterShadowFilter";

        public int DefaultValue => 1;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => true;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "uWaterShadowFilter", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "uWaterShadowFilter", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
