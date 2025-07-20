using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    /** Min: 2f, Default: 15f, Max: 50f */
    class WorkshopFreeCameraTranslationSpeedTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Default: 15";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Workshop]fWorkshopFreeCameraTranslationSpeed";

        public float DefaultValue => 15f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.F76Prefs.GetFloat("Workshop", "fWorkshopFreeCameraTranslationSpeed", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Workshop", "fWorkshopFreeCameraTranslationSpeed", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
