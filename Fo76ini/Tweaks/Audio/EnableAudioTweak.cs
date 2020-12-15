using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Audio
{
    class EnableAudioTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "If disabled, the game will be completely silent.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Audio]bEnableAudio";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Audio", "bEnableAudio", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Audio", "bEnableAudio", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
