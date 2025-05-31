using Fo76ini.Tweaks.Graphics;
using Fo76ini.Tweaks.Interface;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Accessibility
{
    public enum ScreenNarrationVoiceType
    {
        VoiceType1 = 0,
        VoiceType2 = 1,
    }

    class ScreenNarrationVoiceTypeTweak : ITweak<ScreenNarrationVoiceType>, ITweakInfo, IEnumTweak
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Accessibility]uiScreenNarrationVoice";

        public ScreenNarrationVoiceType DefaultValue => ScreenNarrationVoiceType.VoiceType1;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public int Count => Enum.GetNames(typeof(AntiAliasing)).Length;

        public ScreenNarrationVoiceType GetValue()
        {
            uint val = IniFiles.F76Prefs.GetUInt("Accessibility", "uiScreenNarrationVoice", (uint)DefaultValue);
            return (ScreenNarrationVoiceType)(Utils.Clamp<uint>(val, 0, (uint)Count));
        }

        public void SetValue(ScreenNarrationVoiceType value)
        {
            IniFiles.F76Prefs.Set("Accessibility", "uiScreenNarrationVoice", (uint)value);
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
            SetValue((ScreenNarrationVoiceType)value);
        }
    }
}