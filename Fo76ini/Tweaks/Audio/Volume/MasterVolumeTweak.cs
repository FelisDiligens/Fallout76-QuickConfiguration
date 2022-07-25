using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Volume
{
    class MasterVolumeTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[AudioMenu]fAudioMasterVolume";

        public float DefaultValue => 1.0f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("AudioMenu", "fAudioMasterVolume", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("AudioMenu", "fAudioMasterVolume", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
