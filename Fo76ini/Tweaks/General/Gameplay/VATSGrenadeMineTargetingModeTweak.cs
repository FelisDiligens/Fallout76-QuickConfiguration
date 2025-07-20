using Fo76ini.Tweaks.Graphics;
using Fo76ini.Tweaks.Interface;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    public enum VATSGrenadeMineTargetingMode
    {
        None = 0,
        OnlyMyOwn = 1,
        All = 2,
    }

    class VATSGrenadeMineTargetingModeTweak : ITweak<VATSGrenadeMineTargetingMode>, ITweakInfo, IEnumTweak
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[GamePlay]uVATSGrenadeMineTargetingMode";

        public VATSGrenadeMineTargetingMode DefaultValue => VATSGrenadeMineTargetingMode.All;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public int Count => Enum.GetNames(typeof(VATSGrenadeMineTargetingMode)).Length;

        public VATSGrenadeMineTargetingMode GetValue()
        {
            uint val = IniFiles.F76Prefs.GetUInt("GamePlay", "uVATSGrenadeMineTargetingMode", (uint)DefaultValue);
            return (VATSGrenadeMineTargetingMode)(Utils.Clamp<uint>(val, 0, (uint)Count));
        }

        public void SetValue(VATSGrenadeMineTargetingMode value)
        {
            IniFiles.F76Prefs.Set("GamePlay", "uVATSGrenadeMineTargetingMode", (uint)value);
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
            SetValue((VATSGrenadeMineTargetingMode)value);
        }
    }
}