// Source:   https://www.reddit.com/r/fo76/comments/nlap2c/disable_bloom_ini_tweaks/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class BloomTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't work. Causes weird lighting in dialogues.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "[Display]",
            "fAdaptativeLightEvMax",
            "fAdaptativeLightEvMin",
            "fAdaptativeLightMinDistanceThreshold",
            "fAdaptativeLightOffset");

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public WarnLevel WarnLevel => WarnLevel.Unsafe;

        public bool GetValue()
        {
            return IniFiles.GetFloat("Display", "fAdaptativeLightEvMax", 6f) > 0f;
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Remove("Display", "fAdaptativeLightEvMax");
                IniFiles.F76Custom.Remove("Display", "fAdaptativeLightEvMin");
                IniFiles.F76Custom.Remove("Display", "fAdaptativeLightMinDistanceThreshold");
                IniFiles.F76Custom.Remove("Display", "fAdaptativeLightOffset");
            }
            else
            {
                IniFiles.F76Custom.Set("Display", "fAdaptativeLightEvMax", 0f);
                IniFiles.F76Custom.Set("Display", "fAdaptativeLightEvMin", 0f);
                IniFiles.F76Custom.Set("Display", "fAdaptativeLightMinDistanceThreshold", 0f);
                IniFiles.F76Custom.Set("Display", "fAdaptativeLightOffset", 0f);
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
