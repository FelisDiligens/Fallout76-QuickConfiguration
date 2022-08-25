using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    public enum TextureQuality
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Ultra = 3,
        Custom = 4,
    }

    public class TextureQualityPresetTweak : ITweak<TextureQuality>, IEnumTweak, ITweakInfo
    {
        public TextureQuality DefaultValue => TextureQuality.High;

        public bool UIReloadNecessary => true;

        public int Count => Enum.GetNames(typeof(TextureQuality)).Length;

        public string Identifier => this.GetType().FullName;

        public string Description => "Primarily changes the resolution of the textures (= how blurry/sharp textures look)";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(Environment.NewLine, new string[] {
            "",
            "[Texture]",
            "    iLargeTextureArrayMipSkip",
            "    iTextureMipSkipBC1UNormSrgb",
            "    iTextureMipSkipBC3UNormSrgb",
            "    iTextureMipSkipBC1UNorm",
            "    iTextureMipSkipBC5SNorm",
            "    iTextureMipSkipBC4UNorm",
            "    iTextureMipSkipMinDimension",
            "    iLargeTextureArrayDim",
            "    iTextureQualityLevel",
        });

        public WarnLevel WarnLevel => WarnLevel.None;

        public TextureQuality GetValue()
        {
            if (IniFiles.Config.GetBool("Tweaks", "bDontChangeTextureQuality", false))
                return TextureQuality.Custom;

            switch (IniFiles.GetInt("Texture", "iTextureQualityLevel", (int)DefaultValue))
            {
                case 0:
                    return TextureQuality.Low;
                case 1:
                    return TextureQuality.Medium;
                case 2:
                    return TextureQuality.High;
                case 3:
                    return TextureQuality.Ultra;
                default:
                    return TextureQuality.Custom;
            }
        }

        public void SetValue(TextureQuality value)
        {
            IniFiles.Config.Set("Tweaks", "bDontChangeTextureQuality", false);
            switch (value)
            {
                case TextureQuality.Low:
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayMipSkip", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNormSrgb", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC3UNormSrgb", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNorm", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC5SNorm", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC4UNorm", 2);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipMinDimension", 256);
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayDim", 1024);
                    IniFiles.F76Prefs.Set("Texture", "iTextureQualityLevel", 0);
                    break;
                case TextureQuality.Medium:
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayMipSkip", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNormSrgb", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC3UNormSrgb", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC5SNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC4UNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipMinDimension", 256);
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayDim", 1024);
                    IniFiles.F76Prefs.Set("Texture", "iTextureQualityLevel", 1);
                    break;
                case TextureQuality.High:
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayMipSkip", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNormSrgb", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC3UNormSrgb", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC5SNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC4UNorm", 1);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipMinDimension", 1024);
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayDim", 2048);
                    IniFiles.F76Prefs.Set("Texture", "iTextureQualityLevel", 2);
                    break;
                case TextureQuality.Ultra:
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayMipSkip", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNormSrgb", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC3UNormSrgb", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC1UNorm", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC5SNorm", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipBC4UNorm", 0);
                    IniFiles.F76Prefs.Set("Texture", "iTextureMipSkipMinDimension", 1024);
                    IniFiles.F76Prefs.Set("Texture", "iLargeTextureArrayDim", 2048);
                    IniFiles.F76Prefs.Set("Texture", "iTextureQualityLevel", 3);
                    break;
                case TextureQuality.Custom:
                    IniFiles.Config.Set("Tweaks", "bDontChangeTextureQuality", true);
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
            SetValue((TextureQuality)value);
        }
    }
}
