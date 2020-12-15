using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class DisableAllGoreTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]bDisableAllGore, bBloodSpatterEnabled";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("General", "bDisableAllGore", DefaultValue);
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Set("General", "bDisableAllGore", true);
                IniFiles.F76Custom.Set("General", "bBloodSpatterEnabled", false);
            }
            else
            {
                IniFiles.F76Custom.Remove("General", "bDisableAllGore");
                IniFiles.F76Custom.Remove("General", "bBloodSpatterEnabled");
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
