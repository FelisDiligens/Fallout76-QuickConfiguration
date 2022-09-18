using Fo76ini.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fo76ini.Interface
{
    public enum ThemeType
    {
        Dark,
        Light,
        System
    }

    public class Theming
    {
        public static String ThemesPath = Path.Combine(Shared.AppConfigFolder, "themes");

        public static Theme DarkTheme
        {
            get { return Theme.ReadTheme(Path.Combine(ThemesPath, "dark.yml")); }
        }

        public static Theme LightTheme
        {
            get { return Theme.ReadTheme(Path.Combine(ThemesPath, "light.yml")); }
        }

        public static Theme SystemTheme
        {
            get { return DetectSystemTheme() == ThemeType.Dark ? DarkTheme : LightTheme; }
        }

        public static ThemeType DetectSystemTheme ()
        {
            RegistryKey registry =
                Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");

            if ((int)registry.GetValue("AppsUseLightTheme") == 1) // SystemUsesLightTheme
                return ThemeType.Light;
            else
                return ThemeType.Dark;
        }

        public static void ApplyTheme(ThemeType theme, Control control)
        {
            try
            {
                switch (theme)
                {
                    case ThemeType.Dark:
                        Theming.ApplyTheme(Theming.DarkTheme, control);
                        break;
                    case ThemeType.Light:
                        Theming.ApplyTheme(Theming.LightTheme, control);
                        break;
                    case ThemeType.System:
                        Theming.ApplyTheme(Theming.SystemTheme, control);
                        break;
                }
                Configuration.Appearance.AppTheme = theme;
            }
            catch
            {
                MsgBox.Show("Error", $"Couldn't apply '{theme}' theme.", MessageBoxIcon.Error);
            }
        }

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
