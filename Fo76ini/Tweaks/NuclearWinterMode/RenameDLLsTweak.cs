using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.NuclearWinterMode
{
    class RenameDLLsTweak : ITweak<bool>, ITweakInfo
    {
        public string Identifier => this.GetType().FullName;

        public string Description => "If checked, any *.dll files that don't belong to the game will be renamed.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "[NuclearWinter]bRenameDLLs";

        public bool DefaultValue => true;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("NuclearWinter", "bRenameDLLs", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("NuclearWinter", "bRenameDLLs", value);
        }

        public void ResetValue()
        {
            IniFiles.Config.Set("NuclearWinter", "bRenameDLLs", DefaultValue);
        }
    }
}
