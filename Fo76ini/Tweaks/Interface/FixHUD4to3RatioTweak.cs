using System;

namespace Fo76ini.Tweaks.Interface
{
    class FixHUD4to3RatioTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Fixes hidden / borked",
            "  • Quick-Boy screen,",
            "  • lock picking screen, and",
            "  • Power Armor HUD",
            "for 5:4 and 4:3 screens.",
            "",
            "⚠️ Mostly untested.");

        public WarnLevel WarnLevel => WarnLevel.Notice;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [Interface]fLockPositionY",
            "  [Interface]fUIPowerArmorGeometry_TranslateZ",
            "  [Interface]fUIPowerArmorGeometry_TranslateY",
            "");

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return
                Math.Abs(IniFiles.GetFloat("Interface", "fLockPositionY", 0f) - 100f) < 0.1 &&
                Math.Abs(IniFiles.GetFloat("Interface", "fUIPowerArmorGeometry_TranslateZ", 0f) - -18.5f) < 0.1 &&
                Math.Abs(IniFiles.GetFloat("Interface", "fUIPowerArmorGeometry_TranslateY", 0f) - 460f) < 0.1;
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Set("Interface", "fLockPositionY", 100f);
                IniFiles.F76Custom.Set("Interface", "fUIPowerArmorGeometry_TranslateZ", -18.5f);
                IniFiles.F76Custom.Set("Interface", "fUIPowerArmorGeometry_TranslateY", 460f);
            }
            else
            {
                IniFiles.F76Custom.Remove("Interface", "fLockPositionY");
                IniFiles.F76Custom.Remove("Interface", "fUIPowerArmorGeometry_TranslateZ");
                IniFiles.F76Custom.Remove("Interface", "fUIPowerArmorGeometry_TranslateY");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
