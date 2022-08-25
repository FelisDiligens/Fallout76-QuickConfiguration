using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class ShadowBlurrinessTweak : ITweak<int>, ITweakInfo
    {
        public string Description => "Blurs shadows. Especially useful, if you set a lower shadow resolution.\n\n" +
                                     "3x recommended for low texture map resolution\n" +
                                     "2x recommended for high texture map resolution";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]uiShadowFilter, uiOrthoShadowFilter";

        public int DefaultValue => 3;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => true;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "uiOrthoShadowFilter", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "uiShadowFilter", value);
            IniFiles.F76Prefs.Set("Display", "uiOrthoShadowFilter", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
