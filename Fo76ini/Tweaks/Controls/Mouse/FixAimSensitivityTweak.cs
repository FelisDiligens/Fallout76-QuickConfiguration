using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class FixAimSensitivityTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "If enabled, the sensitivity won't change when aiming.",
            "If disabled (default), the sensitivity will be lowered when aiming down sights.",
            "",
            "⚠️ This might only work on 16:9 monitors.",
            "⚠️ This might not work in-game while crouching.");

        public WarnLevel WarnLevel => WarnLevel.Notice;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "fIronSightsFOVRotateMult";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return Math.Abs(IniFiles.GetFloat("MAIN", "fIronSightsFOVRotateMult", 1.0f) - 2.14f) < 0.1f;
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Set("Controls", "fIronSightsFOVRotateMult", 2.136363636f);
                IniFiles.F76Custom.Set("MAIN", "fIronSightsFOVRotateMult", 2.136363636f);
            }
            else
            {
                IniFiles.F76Custom.Remove("Controls", "fIronSightsFOVRotateMult");
                IniFiles.F76Custom.Remove("MAIN", "fIronSightsFOVRotateMult");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
