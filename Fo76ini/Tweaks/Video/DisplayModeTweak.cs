using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Video
{
    public enum DisplayMode
    {
        Fullscreen = 0,
        Windowed = 1,
        BorderlessWindowed = 2,
        BorderlessFullscreen = 3
    }

    class DisplayModeTweak : ITweak<DisplayMode>, ITweakInfo, IEnumTweak
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Changes the display mode.",
            "",
            "• Fullscreen: Real fullscreen mode (Best Performance)",
            "• Windowed: Starts the game in a window with border (aka. window decoration).",
            "• Borderless windowed: Allows you to painlessly Alt+Tab, but make sure the resolution matches your display's resolution. (Default)",
            "• Borderless windowed (Fullscreen): Same as \"Borderless windowed\", but window will be maximized to fit your screen.",
            "  This will look pixelated, if the resolution is lower than your display, as it uses Nearest Neighbor to upscale it.");

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "[Display]",
            "bFull Screen",
            "bBorderless",
            "bMaximizeWindow");

        public DisplayMode DefaultValue => DisplayMode.BorderlessWindowed;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(DisplayMode)).Length;

        public DisplayMode GetValue()
        {
            bool bFullScreen = IniFiles.GetBool("Display", "bFull Screen", false);
            bool bBorderless = IniFiles.GetBool("Display", "bBorderless", true);
            bool bMaximizeWindow = IniFiles.GetBool("Display", "bMaximizeWindow", false);

            if (bFullScreen)
                return DisplayMode.Fullscreen;
            else if (!bBorderless)
                return DisplayMode.Windowed;
            else if (bBorderless && !bMaximizeWindow)
                return DisplayMode.BorderlessWindowed;
            else
                return DisplayMode.BorderlessFullscreen;
        }

        public void SetValue(DisplayMode value)
        {
            bool bFullScreen, bBorderless, bMaximizeWindow;
            switch (value)
            {
                case DisplayMode.Fullscreen:
                    bBorderless = true;
                    bFullScreen = true;
                    bMaximizeWindow = false;
                    break;
                case DisplayMode.Windowed:
                    bBorderless = false;
                    bFullScreen = false;
                    bMaximizeWindow = false;
                    break;
                case DisplayMode.BorderlessFullscreen:
                    bBorderless = true;
                    bFullScreen = false;
                    bMaximizeWindow = true;
                    break;
                case DisplayMode.BorderlessWindowed:
                default:
                    bBorderless = true;
                    bFullScreen = false;
                    bMaximizeWindow = false;
                    break;
            }
            IniFiles.F76Prefs.Set("Display", "bFull Screen", bFullScreen);
            IniFiles.F76Prefs.Set("Display", "bBorderless", bBorderless);
            IniFiles.F76Prefs.Set("Display", "bMaximizeWindow", bMaximizeWindow);
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
            SetValue((DisplayMode)value);
        }
    }
}
