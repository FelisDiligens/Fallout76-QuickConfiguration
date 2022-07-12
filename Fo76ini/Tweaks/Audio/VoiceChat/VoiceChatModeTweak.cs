using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Audio
{
    public enum VoiceChatMode
    {
        Auto = 0,
        Area = 1,
        Team = 2,
        None = 3
    }

    class VoiceChatModeTweak : ITweak<VoiceChatMode>, ITweakInfo, IEnumTweak
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Voice]uTransmitPreference";

        public VoiceChatMode DefaultValue => VoiceChatMode.Auto;

        public string Identifier => this.GetType().FullName;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(VoiceChatMode)).Length;

        public VoiceChatMode GetValue()
        {
            return (VoiceChatMode)IniFiles.GetInt("Voice", "uTransmitPreference", (int)DefaultValue);
        }

        public void SetValue(VoiceChatMode value)
        {
            IniFiles.F76Prefs.Set("Voice", "uTransmitPreference", (int)value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }

        public int GetInt()
        {
            return (int)GetValue();
        }

        public void SetInt(int value)
        {
            SetValue((VoiceChatMode)value);
        }
    }
}
