using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    public enum ShadowQuality
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Ultra = 3,
        Custom = 4,
    }

    public class ShadowQualityPresetTweak : ITweak<ShadowQuality>, IEnumTweak, ITweakInfo
    {
        public ShadowQuality DefaultValue => ShadowQuality.Ultra;

        public bool UIReloadNecessary => true;

        public int Count => Enum.GetNames(typeof(ShadowQuality)).Length;

        public string Identifier => this.GetType().FullName;

        public string Description => "The in-game shadow quality setting.";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(Environment.NewLine, new string[] {
            "",
            "[Display]",
            "    iShadowMapResolution",
            "    uiShadowFilter",
            "    uiOrthoShadowFilter",
            "    fBlendSplitDirShadow",
            "    iMaxFocusShadows",
        });

        public WarnLevel WarnLevel => WarnLevel.None;

        public ShadowQuality GetValue()
        {
            int iShadowMapResolution = IniFiles.GetInt("Display", "iShadowMapResolution", 2048);
            uint uiOrthoShadowFilter = IniFiles.GetUInt("Display", "uiOrthoShadowFilter", 3);
            float fBlendSplitDirShadow = IniFiles.GetFloat("Display", "fBlendSplitDirShadow", 48f);
            int iMaxFocusShadows = IniFiles.GetInt("Display", "iMaxFocusShadows", 4);

            if (iShadowMapResolution == 2048 &&
                uiOrthoShadowFilter == 3 &&
                fBlendSplitDirShadow == 48f &&
                iMaxFocusShadows == 4)
                return ShadowQuality.Ultra;

            else if (iShadowMapResolution == 2048 &&
                uiOrthoShadowFilter == 2 &&
                fBlendSplitDirShadow == 48f &&
                iMaxFocusShadows == 4)
                return ShadowQuality.High;

            else if (iShadowMapResolution == 2048 &&
                uiOrthoShadowFilter == 1 &&
                fBlendSplitDirShadow == 48f &&
                iMaxFocusShadows == 1)
                return ShadowQuality.Medium;

            else if (iShadowMapResolution == 1024 &&
                uiOrthoShadowFilter == 0 &&
                fBlendSplitDirShadow == 0f &&
                iMaxFocusShadows == 0)
                return ShadowQuality.Low;

            else
                return ShadowQuality.Custom;
        }

        public void SetValue(ShadowQuality value)
        {
            switch (value)
            {
                case ShadowQuality.Ultra:
                    IniFiles.F76Prefs.Set("Display", "iShadowMapResolution", 2048);
                    IniFiles.F76Prefs.Set("Display", "uiShadowFilter", 3);
                    IniFiles.F76Prefs.Set("Display", "uiOrthoShadowFilter", 3);
                    IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", 48f);
                    IniFiles.F76Prefs.Set("Display", "iMaxFocusShadows", 4);
                    break;
                case ShadowQuality.High:
                    IniFiles.F76Prefs.Set("Display", "iShadowMapResolution", 2048);
                    IniFiles.F76Prefs.Set("Display", "uiShadowFilter", 2);
                    IniFiles.F76Prefs.Set("Display", "uiOrthoShadowFilter", 2);
                    IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", 48f);
                    IniFiles.F76Prefs.Set("Display", "iMaxFocusShadows", 4);
                    break;
                case ShadowQuality.Medium:
                    IniFiles.F76Prefs.Set("Display", "iShadowMapResolution", 2048);
                    IniFiles.F76Prefs.Set("Display", "uiShadowFilter", 1);
                    IniFiles.F76Prefs.Set("Display", "uiOrthoShadowFilter", 1);
                    IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", 48f);
                    IniFiles.F76Prefs.Set("Display", "iMaxFocusShadows", 1);
                    break;
                case ShadowQuality.Low:
                    IniFiles.F76Prefs.Set("Display", "iShadowMapResolution", 1024);
                    IniFiles.F76Prefs.Set("Display", "uiShadowFilter", 0);
                    IniFiles.F76Prefs.Set("Display", "uiOrthoShadowFilter", 0);
                    IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", 0f);
                    IniFiles.F76Prefs.Set("Display", "iMaxFocusShadows", 0f);
                    break;
                default:
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
            SetValue((ShadowQuality)value);
        }
    }
}
