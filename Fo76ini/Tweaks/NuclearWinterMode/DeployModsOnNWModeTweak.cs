using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.NuclearWinterMode
{
    class DeployModsOnNWModeTweak : ITweak<bool>, ITweakInfo
    {
        public string Identifier => this.GetType().FullName;

        public string Description => "If checked, mods will be deployed when the Nuclear Winter mode is disabled.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "[NuclearWinter]bAutoDeployMods";

        public bool DefaultValue => true;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("NuclearWinter", "bAutoDeployMods", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("NuclearWinter", "bAutoDeployMods", value);
        }

        public void ResetValue()
        {
            IniFiles.Config.Set("NuclearWinter", "bAutoDeployMods", DefaultValue);
        }
    }
}
