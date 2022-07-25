using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class FasterFadeInTweak : ITweak<bool>, ITweakInfo
    {
        public string Description =>
            "After loading into a world or fast traveling, the game plays an animation / fades in from black\n" +
            "which also prevents you from moving for a while. This tweak speeds up said animation.\n" +
            "Credit goes to u/LinuxVersion from reddit.\n" +
            "\n" +
            "⚠️ If the values are set too low or 0, the game will be stuck in a black screen after loading.\n" +
            "(Values used by the tweak: fFadeToBlackFadeSeconds=0.2000 and fMinSecondsForLoadFadeIn=0.3000)";

        public WarnLevel WarnLevel => WarnLevel.Warning;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Interface]fFadeToBlackFadeSeconds, [Interface]fMinSecondsForLoadFadeIn";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Custom.Exists("Interface", "fFadeToBlackFadeSeconds");
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Set("Interface", "fFadeToBlackFadeSeconds", 0.2f);
                IniFiles.F76Custom.Set("Interface", "fMinSecondsForLoadFadeIn", 0.3f);
            }
            else
            {
                IniFiles.F76Custom.Remove("Interface", "fFadeToBlackFadeSeconds");
                IniFiles.F76Custom.Remove("Interface", "fMinSecondsForLoadFadeIn");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}