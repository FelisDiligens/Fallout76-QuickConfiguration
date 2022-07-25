using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class LODFadeOutMultObjectsTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[LOD]fLODFadeOutMultObjects";

        public float DefaultValue => 6.0f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("LOD", "fLODFadeOutMultObjects", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("LOD", "fLODFadeOutMultObjects", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
