using Fo76ini.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core;

namespace Fo76ini.Interface
{
    public class Theming
    {
        public static void ApplyTheme(Theme theme, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
                ApplyTheme(theme, control);
        }

        public static void ApplyTheme(Theme theme, Control control)
        {
            String controlType = control.GetType().Name;
            String controlName = control.Name;
            String styleName = "Default";
            if (control is IThemable)
                styleName = ((IThemable)control).VisualStyle;

            Console.WriteLine("Control: {2} ({0}.{1})", controlType, styleName, controlName);

            ApplyStyle(theme.GetDefaultStyleForControl(controlType), control);
            if (styleName != controlName &&
                styleName != "Default" &&
                styleName != null)
                ApplyStyle(theme.GetStyle(controlType, styleName), control);
            ApplyStyle(theme.GetStyle(controlType, controlName), control);

            ApplyTheme(theme, control.Controls);
        }

        private static void ApplyStyle(VisualStyle style, Control control)
        {
            if (style == null || control == null)
                return;

            Console.WriteLine(" - Applying theme: {0}.{1}", style.ControlType, style.StyleName);

            foreach (KeyValuePair<String, object> rule in style.Rules)
            {
                Console.WriteLine("   - Applying rule: {0} = {1}", rule.Key, rule.Value.ToString());
                PropertyInfo property = control.GetType().GetProperty(rule.Key);
                if (property != null)
                {
                    if (property.PropertyType == typeof(string))
                        property.SetValue(control, rule.Value.ToString(), null);
                    else if (property.PropertyType == typeof(int))
                        property.SetValue(control, Convert.ToInt32(rule.Value.ToString()), null);
                    else if (property.PropertyType == typeof(Color))
                        property.SetValue(control, ColorTranslator.FromHtml(rule.Value.ToString()), null);
                    else
                        Console.WriteLine("     Failed to apply rule.");
                }
                else
                {
                    Console.WriteLine("     Failed to apply rule.");
                }
            }
        }
    }
}
