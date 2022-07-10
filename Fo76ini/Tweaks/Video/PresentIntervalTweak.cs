using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Video
{
    // From what I've read on the interwebzz, this might not actually be VSync but a fps cap, which is determined this way: Monitor refresh rate divided by iPresentInterval
    // A 120 Hz monitor and iPresentInterval set to 2 will result in a 60fps cap: 120Hz / 2 = 60 fps
    //
    // For some reason though, setting it to 2 or 3 causes a black screen or the game just flat out crashes to desktop.
    // The majority links iPresentInterval directly to vertical synchronization.
    //
    // My question is this: If VSync is more like an on/off setting (like a boolean), why is iPresentInterval a signed integer then? Wouldn't "bPresentInterval" or "bVSync" be more reasonable?
    // Just my two cents...

    class PresentIntervalTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Disabling this will uncap the frame rate.",
            "",
            "• Enable this if you experience screen tearing.",
            "• Disable this if you experience input lag.",
            "",
            "⚠️ Enabling this might NOT get rid of screen tearing.",
            "⚠️ If you disable this, it is recommended to cap the game to 60 FPS manually. (e.g. using NVIDIA's Control Panel)",
            "",
            "ℹ️ Uncapped frame rate shouldn't make the physics go haywire like in older titles,",
            "as this has been fixed by Bethesda quite a while ago (in 2018).",
            "Capping it to 60 is recommended nonetheless.");

        public WarnLevel WarnLevel => WarnLevel.Notice;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iPresentInterval";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            int val = IniFiles.GetInt("Display", "iPresentInterval", DefaultValue ? 1 : 0);
            return val > 0;
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Display", "iPresentInterval", value ? 1 : 0);
            // TODO: IniFiles.F76Custom.Remove("Display", "iPresentInterval");
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
