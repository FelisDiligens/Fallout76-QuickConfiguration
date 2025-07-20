using Fo76ini.Tweaks.Graphics;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General.Gameplay
{
    public enum QuickHealStimpakPriority
    {
        UseWeakestFirst = 0,
        UseStrongestFirst = 1,
    }

    class QuickHealStimpakPriorityTweak : ITweak<QuickHealStimpakPriority>, IEnumTweak, ITweakInfo
    {
        public string Description => "Determines if Quick Heal will use your weakest or strongest Stimpaks first.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]uiQuickHealPriority";

        public QuickHealStimpakPriority DefaultValue => QuickHealStimpakPriority.UseStrongestFirst;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public int Count => Enum.GetNames(typeof(QuickHealStimpakPriority)).Length;

        public QuickHealStimpakPriority GetValue()
        {
            uint val = IniFiles.F76Prefs.GetUInt("MAIN", "uiQuickHealPriority", (uint)DefaultValue);
            return (QuickHealStimpakPriority)(Utils.Clamp<uint>(val, 0, (uint)Count));
        }

        public void SetValue(QuickHealStimpakPriority value)
        {
            IniFiles.F76Prefs.Set("MAIN", "uiQuickHealPriority", (uint)value);
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
            SetValue((QuickHealStimpakPriority)value);
        }
    }
}
