using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class FOV1stPersonTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Viewmodel FOV: affects your hands, gun, Pip-Boy etc.\n" +
                                     "ℹ️ Doesn't work";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "fDefault1stPersonFOV";

        public float DefaultValue => 80;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fDefault1stPersonFOV", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Display", "fDefault1stPersonFOV", value);
            IniFiles.F76Prefs.Set("Interface", "fDefault1stPersonFOV", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
