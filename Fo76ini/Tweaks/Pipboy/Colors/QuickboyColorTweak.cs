using System;
using System.Drawing;
using Fo76ini.Utilities;

namespace Fo76ini.Tweaks.Colors
{
    public class QuickboyColorTweak : ITweak<Color>, ITweakInfo
    {
        public Color DefaultValue => Color.FromArgb(247, 242, 184);

        public string Identifier => this.GetType().FullName;

        public string Description => "Changes the color of the Quickboy";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
             Environment.NewLine,
             "",
             "  [Pipboy]fQuickBoyEffectColorR",
             "  [Pipboy]fQuickBoyEffectColorG",
             "  [Pipboy]fQuickBoyEffectColorB",
             "");

        public Color GetValue()
        {
            float r = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fQuickBoyEffectColorR", 0.97f), 0f, 1f);
            float g = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fQuickBoyEffectColorG", 0.95f), 0f, 1f);
            float b = Utils.Clamp(IniFiles.GetFloat("Pipboy", "fQuickBoyEffectColorB", 0.72f), 0f, 1f);
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
            IniFiles.F76Prefs.Set("Pipboy", "fQuickBoyEffectColorR", r);
            IniFiles.F76Prefs.Set("Pipboy", "fQuickBoyEffectColorG", g);
            IniFiles.F76Prefs.Set("Pipboy", "fQuickBoyEffectColorB", b);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
