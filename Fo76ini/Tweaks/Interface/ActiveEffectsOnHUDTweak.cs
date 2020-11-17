using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    public enum ActiveEffectsOnHUD
    {
        Disabled = 0,
        Detrimental = 1,
        All = 2
    }

    class ActiveEffectsOnHUDTweak : ITweak<ActiveEffectsOnHUD>, ITweakInfo, IEnumTweak
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Interface]uHUDActiveEffectWidget";

        public ActiveEffectsOnHUD DefaultValue => ActiveEffectsOnHUD.All;

        public string Identifier => this.GetType().FullName;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(ActiveEffectsOnHUD)).Length;

        public ActiveEffectsOnHUD GetValue()
        {
            int val = IniFiles.GetInt("Interface", "uHUDActiveEffectWidget", (int)DefaultValue);
            return (ActiveEffectsOnHUD)(Utils.Clamp(val, 0, 2));
        }

        public void SetValue(ActiveEffectsOnHUD value)
        {
            IniFiles.F76Prefs.Set("Interface", "uHUDActiveEffectWidget", (int)value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }

        public int GetInt()
        {
            return (int)GetValue();
        }

        public void SetInt(int value)
        {
            SetValue((ActiveEffectsOnHUD)value);
        }
    }
}
