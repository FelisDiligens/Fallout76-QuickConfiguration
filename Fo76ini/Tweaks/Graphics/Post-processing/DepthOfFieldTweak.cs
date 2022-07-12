using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    // TODO: More DoF tweaks instead of just on/off.
    class DepthOfFieldTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Disabling this will disable all Depth of Field effects.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "  [ImageSpace]bDynamicDepthOfField",
            "  [Display]fDOFBlendRatio",
            "  [Display]fDOFMinFocalCoefDist",
            "  [Display]fDOFMaxFocalCoefDist",
            "  [Display]fDOFDynamicFarRange",
            "  [Display]fDOFCenterWeightInt",
            "  [Display]fDOFFarDistance",
            "");

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("ImageSpace", "bDynamicDepthOfField", true);
        }

        public void SetValue(bool value)
        {
            if (value)
            {
                IniFiles.F76Custom.Remove("ImageSpace", "bDynamicDepthOfField");
                IniFiles.F76Custom.Remove("Display", "fDOFBlendRatio");
                IniFiles.F76Custom.Remove("Display", "fDOFMinFocalCoefDist");
                IniFiles.F76Custom.Remove("Display", "fDOFMaxFocalCoefDist");
                IniFiles.F76Custom.Remove("Display", "fDOFDynamicFarRange");
                IniFiles.F76Custom.Remove("Display", "fDOFCenterWeightInt");
                IniFiles.F76Custom.Remove("Display", "fDOFFarDistance");
            }
            else
            {
                IniFiles.F76Custom.Set("ImageSpace", "bDynamicDepthOfField", false);
                IniFiles.F76Custom.Set("Display", "fDOFBlendRatio", 0);
                IniFiles.F76Custom.Set("Display", "fDOFMinFocalCoefDist", 999999);
                IniFiles.F76Custom.Set("Display", "fDOFMaxFocalCoefDist", 99999999);
                IniFiles.F76Custom.Set("Display", "fDOFDynamicFarRange", 99999999);
                IniFiles.F76Custom.Set("Display", "fDOFCenterWeightInt", 0);
                IniFiles.F76Custom.Set("Display", "fDOFFarDistance", 99999999);

                /*
                    Things I wanted to add:

                    bDoDepthOfField    - DO NOT set this to 0. It will cause underwater effects to disappear.
                    bScreenSpaceBokeh  - Apparently some blur effect. Is it related to DOF?
                    bUseBlurShader     - ?
                */
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
