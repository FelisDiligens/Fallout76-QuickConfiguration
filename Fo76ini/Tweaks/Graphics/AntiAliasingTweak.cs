using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    public enum AntiAliasing
    {
        TAA = 0,
        FXAA = 1,
        Disabled = 2
    }

    class AntiAliasingTweak : ITweak<AntiAliasing>, ITweakInfo, IEnumTweak
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Smoothes edges of objects.",
            "",
            "• TAA - Temporal Anti-Aliasing: Relatively expensive, can introduce artefacts, default",
            "• FXAA - Fast Approximate Anti-Aliasing: Slightly improves performance",
            "• Off - Improves performance, degrades visual quality",
            "",
            "⚠️ FXAA might not work. The game might just disable AA instead.");

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]sAntiAliasing";

        public AntiAliasing DefaultValue => AntiAliasing.TAA;

        public string Identifier => this.GetType().FullName;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(AntiAliasing)).Length;

        public AntiAliasing GetValue()
        {
            switch (IniFiles.GetString("Display", "sAntiAliasing", DefaultValue.ToString()))
            {
                case "TAA":
                    return AntiAliasing.TAA;
                case "FXAA":
                    return AntiAliasing.FXAA;
                case "":
                    return AntiAliasing.Disabled;
                default:
                    return DefaultValue;
            }
        }

        public void SetValue(AntiAliasing value)
        {
            IniFiles.F76Prefs.Set("Display", "sAntiAliasing", value.ToString());
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
            SetValue((AntiAliasing)value);
        }
    }
}
