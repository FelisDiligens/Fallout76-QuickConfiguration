using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class FloatingQuestMarkersDistanceTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[GamePlay]fFloatingQuestMarkersDistance";

        public float DefaultValue => 100.0f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("GamePlay", "fFloatingQuestMarkersDistance", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("GamePlay", "fFloatingQuestMarkersDistance", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
