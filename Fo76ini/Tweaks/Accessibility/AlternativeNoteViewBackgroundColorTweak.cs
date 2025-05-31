using Fo76ini.Utilities;
using System;
using System.Drawing;

namespace Fo76ini.Tweaks.Colors
{
    public class AlternativeNoteViewBackgroundColorTweak : ITweak<Color>, ITweakInfo
    {
        /*
         * fEasyReadBackgroundColorB=0.0780 --> 19.89
         * fEasyReadBackgroundColorG=0.0780 --> 19.89
         * fEasyReadBackgroundColorR=0.0660 --> 16.83
        */
        public Color DefaultValue => Color.FromArgb(16, 19, 19);

        public string Identifier => this.GetType().FullName;

        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [Interface]fEasyReadBackgroundColorR",
            "  [Interface]fEasyReadBackgroundColorG",
            "  [Interface]fEasyReadBackgroundColorB",
            "");
        
        public bool UIReloadNecessary => false;

        public Color GetValue()
        {
            float r = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadBackgroundColorR", 0.066f), 0f, 1f);
            float g = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadBackgroundColorG", 0.078f), 0f, 1f);
            float b = Utils.Clamp(IniFiles.F76Prefs.GetFloat("Interface", "fEasyReadBackgroundColorB", 0.078f), 0f, 1f);
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
            IniFiles.F76Prefs.Set("Interface", "fEasyReadBackgroundColorR", r);
            IniFiles.F76Prefs.Set("Interface", "fEasyReadBackgroundColorG", g);
            IniFiles.F76Prefs.Set("Interface", "fEasyReadBackgroundColorB", b);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
