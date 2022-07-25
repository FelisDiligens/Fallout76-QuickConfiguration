using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class EnableGrassTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Grass]bAllowCreateGrass";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Grass", "bAllowCreateGrass", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Grass", "bAllowCreateGrass", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
