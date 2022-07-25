using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class ApplyCameraNodeAnimationsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "When disabled, sets the camera's position into the characters head.",
            "You'll need to zoom out in third person.",
            "If enabled, sets the camera's position behind the right shoulder.",
            "",
            "⚠️ Might cause issues if disabled.");

        public WarnLevel WarnLevel => WarnLevel.Warning;

        public string AffectedFiles => "\n - Fallout76Prefs.ini\n - Fallout76Custom.ini";

        public string AffectedValues => "[Camera]bApplyCameraNodeAnimations";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Camera", "bApplyCameraNodeAnimations", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Camera", "bApplyCameraNodeAnimations", value);
            IniFiles.F76Custom.Set("Camera", "bApplyCameraNodeAnimations", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
