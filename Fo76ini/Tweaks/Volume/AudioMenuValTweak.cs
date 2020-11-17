using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Volume
{
    class AudioMenuValTweak : ITweak<float>, ITweakInfo
    {
        public AudioMenuValTweak(string keySuffix, string soundFxName)
        {
            Suffix = keySuffix;
            SoundFX = soundFxName;
        }

        private string Suffix;
        private string SoundFX;

        public string Description => $"Changes the volume of '{SoundFX}'";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => $"[AudioMenu]fVal{Suffix}";

        public float DefaultValue => 1.0f;

        public string Identifier => this.GetType().FullName + $"+fVal{Suffix}";

        public float GetValue()
        {
            return IniFiles.GetFloat("AudioMenu", $"fVal{Suffix}", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("AudioMenu", $"fVal{Suffix}", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
