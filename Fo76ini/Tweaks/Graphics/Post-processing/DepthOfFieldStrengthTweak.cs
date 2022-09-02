using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class DepthOfFieldStrengthTweak : ITweak<float>, ITweakInfo
    {
        public float DefaultValue => 0f;

        public bool UIReloadNecessary => false;

        public string Identifier => this.GetType().FullName;

        public string Description => "Strength of the Depth of Field effect.";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]fDepthOfFieldWST";

        public WarnLevel WarnLevel => WarnLevel.None;

        public float GetValue()
        {
            return IniFiles.F76Prefs.GetFloat("Display", "fDepthOfFieldWST", DefaultValue);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Display", "fDepthOfFieldWST", value);
        }
    }
}
