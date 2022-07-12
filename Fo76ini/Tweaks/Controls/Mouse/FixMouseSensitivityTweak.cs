using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class FixMouseSensitivityTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "If enabled, the sensitivity for looking up/down and left/right will be equal.",
            "If disabled (default), the sensitivity for looking left/right will likely be higher than up/down.",
            "",
            "• Enable this if you're using Mouse & Keyboard.",
            "• Disable this if you're using a Gamepad.",
            "",
            "⚠️ When enabled, your mouse sensitivity might increase. Decrease your cursor speed or mouse DPI.",
            "",
            "ℹ️ The vertical sensitivity depends on your display's aspect ratio:",
            "      ⇨ For 4:3, the value of Y is 0.028",
            "      ⇨ For 16:9, the value of Y is 0.03738",
            "      ⇨ For 16:10, the value of Y is 0.0336",
            "      ⇨ For 21:9, the value of Y is 0.042",
            "      ⇨ For all other aspect ratios, the value of Y is equals to 0.021 times the aspect ratio. (YScale = 0.021 * Width / Height)");

        public WarnLevel WarnLevel => WarnLevel.Notice;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [Controls]fMouseHeadingXScale",
            "  [Controls]fMouseHeadingYScale",
            "  [Controls]fPitchSpeedRatio",
            "  [Controls]fIronSightsPitchSpeedRatio",
            "");

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetFloat("Controls", "fMouseHeadingXScale", 0.021f) != IniFiles.GetFloat("Controls", "fMouseHeadingYScale", 0.021f);
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                int width = IniFiles.GetInt("Display", "iSize W", 1920);
                int height = IniFiles.GetInt("Display", "iSize H", 1080);
                float aspectRatio = width / height;
                float YScale;

                // 16:9
                if (Math.Abs(aspectRatio - 16 / 9) < 0.01)
                    YScale = 0.03738f;

                // 16:10
                else if (Math.Abs(aspectRatio - 16 / 10) < 0.01)
                    YScale = 0.0336f;

                // 21:9
                else if (Math.Abs(aspectRatio - 21 / 9) < 0.01)
                    YScale = 0.042f;

                // 4:3
                else if (Math.Abs(aspectRatio - 4 / 3) < 0.01)
                    YScale = 0.028f;

                // Unknown aspect ratio
                else
                    YScale = aspectRatio * 0.021f;

                IniFiles.F76Custom.Set("Controls", "fMouseHeadingXScale", 0.021f);
                IniFiles.F76Custom.Set("Controls", "fMouseHeadingYScale", YScale);

                IniFiles.F76Custom.Set("Controls", "fPitchSpeedRatio", 1.0f);
                IniFiles.F76Custom.Set("Controls", "fIronSightsPitchSpeedRatio", 1.0f);
            }
            else
            {
                IniFiles.F76Custom.Remove("Controls", "fMouseHeadingXScale");
                IniFiles.F76Custom.Remove("Controls", "fMouseHeadingYScale");
                IniFiles.F76Custom.Remove("Controls", "fPitchSpeedRatio");
                IniFiles.F76Custom.Remove("Controls", "fIronSightsPitchSpeedRatio");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
