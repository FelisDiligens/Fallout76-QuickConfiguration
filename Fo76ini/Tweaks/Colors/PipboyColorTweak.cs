using Fo76ini.Utilities;
using System;
using System.Drawing;

namespace Fo76ini.Tweaks.Colors
{
    public class PipboyColorTweak : ITweak<Color>, ITweakInfo
    {
        public Color DefaultValue => Color.FromArgb(26, 255, 128);

        public string Identifier => this.GetType().FullName;

        public string Description => "Changes the color of the Pipboy";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [Pipboy]fPipboyEffectColorR",
            "  [Pipboy]fPipboyEffectColorG",
            "  [Pipboy]fPipboyEffectColorB",
            "");

        public Color GetValue()
        {
            float r = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPipboyEffectColorR", 0.1f), 0f, 1f);
            float g = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPipboyEffectColorG", 1.0f), 0f, 1f);
            float b = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fPipboyEffectColorB", 0.5f), 0f, 1f);
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
            IniFiles.F76Prefs.Set("Pipboy", "fPipboyEffectColorR", r);
            IniFiles.F76Prefs.Set("Pipboy", "fPipboyEffectColorG", g);
            IniFiles.F76Prefs.Set("Pipboy", "fPipboyEffectColorB", b);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
