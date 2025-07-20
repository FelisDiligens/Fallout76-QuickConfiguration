using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class FOV1stPersonTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Viewmodel FOV: affects your hands, gun, Pip-Boy, etc.\n" +
                                     "Also affects aim down sight zoom amount.";

        public WarnLevel WarnLevel => WarnLevel.Notice;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "fDefault1stPersonFOV";

        public float DefaultValue => 80;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fDefault1stPersonFOV", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Display", "fDefault1stPersonFOV", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
