using Fo76ini.Utilities;
using System;
using System.Drawing;

namespace Fo76ini.Tweaks.Colors
{
    public class AlternativeNoteViewTextColorTweak : ITweak<Color>, ITweakInfo
    {
        /*
         * fEasyReadTextColorB=0.7200       --> 183.60
         * fEasyReadTextColorUniqueG=0.9500 --> 242.25
         * fEasyReadTextColorR=0.9700       --> 247.35
        */
        public Color DefaultValue => Color.FromArgb(247, 242, 183);

        public string Identifier => this.GetType().FullName;

        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [Interface]fEasyReadTextColorR",
            "  [Interface]fEasyReadTextColorUniqueG",
            "  [Interface]fEasyReadTextColorB",
            "");
        
        public bool UIReloadNecessary => false;

        public Color GetValue()
        {
            float r = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadTextColorR", 0.97f), 0f, 1f);
            float g = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadTextColorUniqueG", 0.95f), 0f, 1f);
            float b = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadTextColorB", 0.72f), 0f, 1f);
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
            IniFiles.F76Prefs.Set("Interface", "fEasyReadTextColorR", r);
            IniFiles.F76Prefs.Set("Interface", "fEasyReadTextColorUniqueG", g);
            IniFiles.F76Prefs.Set("Interface", "fEasyReadTextColorB", b);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
