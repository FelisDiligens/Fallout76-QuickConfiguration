using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class GrassFadeDistanceTweak : ITweak<float>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Sets the distance grass will begin to fade.",
            "  ⇨ Ultra is 7000",
            "  ⇨ High is 5500",
            "  ⇨ Medium is 4500");

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Grass]fGrassStartFadeDistance, fGrassMinStartFadeDistance, fGrassMaxStartFadeDistance";

        public float DefaultValue => 3000f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Grass", "fGrassStartFadeDistance", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Grass", "fGrassStartFadeDistance", value);
            IniFiles.F76Prefs.Set("Grass", "fGrassMinStartFadeDistance", 0);
            IniFiles.F76Prefs.Set("Grass", "fGrassMaxStartFadeDistance", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
