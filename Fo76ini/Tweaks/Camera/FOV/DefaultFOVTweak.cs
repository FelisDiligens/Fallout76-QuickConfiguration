using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class DefaultFOVTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "⚠️ Causes issues with the GUI.";

        public WarnLevel WarnLevel => WarnLevel.Unsafe;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fDefaultFOV";

        public float DefaultValue => 80;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fDefaultFOV", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fDefaultFOV", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fDefaultFOV");
            //SetValue(DefaultValue);
        }
    }
}
