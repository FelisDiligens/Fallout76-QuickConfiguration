using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class IntroVideoTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "When this option is enabled, the game will start without displaying the Bethesda logo video.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]sIntroSequence, [General]uMainMenuDelayBeforeAllowSkip";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            string sIntroSequence = IniFiles.GetString("General", "sIntroSequence", "BGSLogo4k.bk2").Trim();
            return sIntroSequence.Length > 0 && sIntroSequence != "0";
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Remove("General", "sIntroSequence");
                IniFiles.F76Custom.Remove("General", "uMainMenuDelayBeforeAllowSkip");
            }
            else
            {
                IniFiles.F76Custom.Set("General", "sIntroSequence", "");
                IniFiles.F76Custom.Set("General", "uMainMenuDelayBeforeAllowSkip", "0");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
