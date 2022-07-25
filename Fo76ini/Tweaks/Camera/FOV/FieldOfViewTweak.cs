using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class FieldOfViewTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Changes the Field of View of the 1st and 3rd person perspective.\n" +
                                     "This is the same value from the in-game FOV setting.\n" +
                                     "Default: 80";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "fDefaultWorldFOV";

        public float DefaultValue => 80;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fDefaultWorldFOV", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Display", "fDefaultWorldFOV", value);
            IniFiles.F76Prefs.Set("Interface", "fDefaultWorldFOV", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
