using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    public enum CorpseHighlighting
    {
        Disabled = 0,
        ClearOnInspect = 1,
        ClearOnRemove = 2
    }

    class CorpseHighlightingTweak : ITweak<CorpseHighlighting>, ITweakInfo, IEnumTweak
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]uiShowCorpseHighlighting";

        public CorpseHighlighting DefaultValue => CorpseHighlighting.ClearOnRemove;

        public string Identifier => this.GetType().FullName;

        // https://stackoverflow.com/a/16946496
        public int Count => Enum.GetNames(typeof(ActiveEffectsOnHUD)).Length;

        public CorpseHighlighting GetValue()
        {
            uint val = IniFiles.GetUInt("Display", "uiShowCorpseHighlighting", (uint)DefaultValue);
            return (CorpseHighlighting)(Utils.Clamp<uint>(val, 0, 2));
        }

        public void SetValue(CorpseHighlighting value)
        {
            IniFiles.F76Prefs.Set("Display", "uiShowCorpseHighlighting", (uint)value);
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
            SetValue((CorpseHighlighting)value);
        }
    }
}
