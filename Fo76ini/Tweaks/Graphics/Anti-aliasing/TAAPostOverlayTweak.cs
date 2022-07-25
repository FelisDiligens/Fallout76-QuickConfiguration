using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class TAAPostOverlayTweak : ITweak<float>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Opacity of the sharpened overlay post-TAA. Increasing this value increases the visibility of the sharpened image on top of the blurry one.\n" +
            "ℹ️ Increasing this value too much causes flickering on screen.",
            "Default: 0.21");

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Display]fTAAPostOverlay";

        public float DefaultValue => 0.21f;

        public string Identifier => this.GetType().FullName + "Rev1";

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fTAAPostOverlay", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Display", "fTAAPostOverlay", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
