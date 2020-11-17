using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fo76ini;

namespace Fo76ini.Tweaks.Inis
{
    public class INIReadOnlyTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "This option will make all *.ini files read-only immediately.\nEnable this if your settings get reverted.";

        public string AffectedFiles => @"%UserProfile%\Documents\My Games\Fallout 76\*.ini";

        public string AffectedValues => "";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.AreINIsReadOnly();
        }

        public void SetValue(bool value)
        {
            IniFiles.SetINIsReadOnly(value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
