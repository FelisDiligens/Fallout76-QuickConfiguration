using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class MouseSensitivityTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Controls]fMouseHeadingSensitivity(Y)";

        public float DefaultValue => 0.03f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Controls", "fMouseHeadingSensitivity", DefaultValue);
        }

        public void SetValue(float value)
        {
            // TODO: Fallout76Custom.ini had no effect. I hope Fallout76Prefs.ini will have an effect this time:
            IniFiles.F76Prefs.Set("Controls", "fMouseHeadingSensitivity", value);
            IniFiles.F76Prefs.Set("Controls", "fMouseHeadingSensitivityY", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
