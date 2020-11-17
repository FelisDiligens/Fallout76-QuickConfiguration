using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Volume
{
    class VivoxVoiceVolumeTweak : ITweak<int>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Voice]uVivoxVoiceVolume";

        public int DefaultValue => 100;

        public string Identifier => this.GetType().FullName;

        public int GetValue()
        {
            return IniFiles.GetInt("Voice", "uVivoxVoiceVolume", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Voice", "uVivoxVoiceVolume", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
