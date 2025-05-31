using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    /** Min: 1f, Default: 3f, Max: 5f */
    class WorkshopFreeCameraRotationSpeedTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Default: 3";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Workshop]fWorkshopFreeCameraRotationSpeed";

        public float DefaultValue => 3f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.F76Prefs.GetFloat("Workshop", "fWorkshopFreeCameraRotationSpeed", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Workshop", "fWorkshopFreeCameraRotationSpeed", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
