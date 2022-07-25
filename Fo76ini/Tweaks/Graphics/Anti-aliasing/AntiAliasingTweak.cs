using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    public enum AntiAliasing
    {
        TAA,
        Disabled
        // Some more AA methods afaik unsupported by the game:
        // FXAA (also called FSAA), SMAA, MSAA
    }

    class AntiAliasingTweak : ITweak<AntiAliasing>, ITweakInfo, IEnumTweak
    {
        /*public string Description => String.Join(
            Environment.NewLine,
            "Smoothes edges of objects.",
            "",
            "• TAA - Temporal Anti-Aliasing: Relatively expensive, can introduce artefacts, default",
            "• FXAA - Fast Approximate Anti-Aliasing: Slightly improves performance",
            "• Off - Improves performance, degrades visual quality",
            "",
            "⚠️ FXAA might not work. The game might just disable AA instead.");*/

        public string Description => 
            "Smoothes (pixelated) edges of objects.\n" +
            "Disable to improve performance at the cost of degraded visual quality.\n\n" +
            "ℹ️ \"FXAA\" does not work.\n" +
            "Setting the value to \"FXAA\" simply disables anti aliasing.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]sAntiAliasing";

        public AntiAliasing DefaultValue => AntiAliasing.TAA;

        public string Identifier => this.GetType().FullName;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(AntiAliasing)).Length;

        public bool UIReloadNecessary => false;

        public AntiAliasing GetValue()
        {
            switch (IniFiles.GetString("Display", "sAntiAliasing", DefaultValue.ToString()))
            {
                case "TAA":
                    return AntiAliasing.TAA;
                case "FXAA":
                case "Disabled":
                case "0":
                case "":
                    return AntiAliasing.Disabled;
                default:
                    return DefaultValue;
            }
        }

        public void SetValue(AntiAliasing value)
        {
            switch (value)
            {
                case AntiAliasing.TAA:
                    IniFiles.F76Prefs.Set("Display", "sAntiAliasing", "TAA");
                    break;
                /*case AntiAliasing.FXAA:
                    IniFiles.F76Prefs.Set("Display", "sAntiAliasing", "FXAA");
                    break;*/
                case AntiAliasing.Disabled:
                    IniFiles.F76Prefs.Set("Display", "sAntiAliasing", "");
                    break;
                default:
                    IniFiles.F76Prefs.Set("Display", "sAntiAliasing", "TAA");
                    break;
            }
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
