using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class AutoSigninTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Enabling this, will skip the login prompt if you provide your login credentials.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Login]bAutoSignin";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Custom.GetBool("Login", "bAutoSignin", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Login", "bAutoSignin", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}