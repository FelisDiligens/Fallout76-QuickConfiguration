using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class LODFadeOutMultItemsTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[LOD]fLODFadeOutMultItems";

        public float DefaultValue => 2.5f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("LOD", "fLODFadeOutMultItems", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("LOD", "fLODFadeOutMultItems", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
