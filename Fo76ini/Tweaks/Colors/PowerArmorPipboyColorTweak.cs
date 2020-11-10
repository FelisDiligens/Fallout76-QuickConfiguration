using Fo76ini.Utilities;
using System;
using System.Drawing;

namespace Fo76ini.Tweaks.Colors
{
    public class PowerArmorPipboyColorTweak : ITweak<Color>, ITweakInfo
    {
        public Color DefaultValue => Color.FromArgb(255, 209, 105);

        public string Identifier => this.GetType().FullName;

        public string Description => "Changes the color of the Power Armor Quickboy";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "fPAEffectColorR, fPAEffectColorG, fPAEffectColorB";

        public Color GetValue()
        {
            float r = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPAEffectColorR", 1.0f), 0f, 1f);
            float g = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPAEffectColorG", 0.82f), 0f, 1f);
            float b = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPAEffectColorB", 0.41f), 0f, 1f);
            return Color.FromArgb(
                Convert.ToInt32(r * 255),
                Convert.ToInt32(g * 255),
                Convert.ToInt32(b * 255)
            );
        }

        public void SetValue(Color value)
        {
            float r = Convert.ToSingle(value.R) / 255f;
            float g = Convert.ToSingle(value.G) / 255f;
            float b = Convert.ToSingle(value.B) / 255f;
            IniFiles.F76Custom.Set("Pipboy", "fPAEffectColorR", r);
            IniFiles.F76Custom.Set("Pipboy", "fPAEffectColorG", g);
            IniFiles.F76Custom.Set("Pipboy", "fPAEffectColorB", b);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Pipboy", "fPAEffectColorR");
            IniFiles.F76Custom.Remove("Pipboy", "fPAEffectColorG");
            IniFiles.F76Custom.Remove("Pipboy", "fPAEffectColorB");
        }
    }
}
