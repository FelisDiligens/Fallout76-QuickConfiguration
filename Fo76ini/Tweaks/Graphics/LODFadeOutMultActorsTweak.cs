using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class LODFadeOutMultActorsTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[LOD]fLODFadeOutMultActors";

        public float DefaultValue => 4.5f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("LOD", "fLODFadeOutMultActors", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("LOD", "fLODFadeOutMultActors", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
