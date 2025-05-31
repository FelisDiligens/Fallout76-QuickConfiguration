using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class WorkshopFreeCameraControlsHoldToggleTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Workshop]bWorkshopFreeCameraControlsHoldToggle";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("Workshop", "bWorkshopFreeCameraControlsHoldToggle", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Workshop", "bWorkshopFreeCameraControlsHoldToggle", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}