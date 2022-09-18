using FastColoredTextBoxNS;
using Fo76ini.Controls;
using Fo76ini.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core;
using static System.Net.Mime.MediaTypeNames;
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
            catch (Exception e)
            {
                MsgBox.Show($"Error: Couldn't apply '{theme}' theme.", e.ToString(), MessageBoxIcon.Error);
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

            //Console.WriteLine("({2}) {0}.{1}", controlType, styleName, controlName);

            foreach (VisualStyle style in theme.Styles)
            {
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (style.ControlType.Contains("*"))
                    Console.WriteLine(controlRegex);
                if (Regex.IsMatch(controlType, controlRegex))
                {
                    string styleRegex = Utils.WildCardToRegular(style.StyleName);
                    if (style.StyleName == "Default")
                        ApplyStyle(style, control);

                    else if (styleName != controlName &&
                        styleName != "Default" &&
                        styleName != null &&
                        Regex.IsMatch(styleName, styleRegex))
                        ApplyStyle(style, control);

                    else if (Regex.IsMatch(controlName, styleRegex))
                        ApplyStyle(style, control);
                }
            }

            if (control is IThemable)
                ((IThemable)control).ApplyTheme(theme.Type);

            ApplyTheme(theme, control.Controls);
        }

        private static void ApplyStyle(VisualStyle style, Control control)
        {
            if (style == null || control == null)
                return;

            //Console.WriteLine(" - Applying theme: {0}.{1}", style.ControlType, style.StyleName);

            foreach (KeyValuePair<String, object> rule in style.Rules)
            {
                //Console.WriteLine("   - Applying rule: {0} = {1}", rule.Key, rule.Value.ToString());
                PropertyInfo property = control.GetType().GetProperty(rule.Key);
                if (property != null)
                {
                    if (property.PropertyType == typeof(string))
                        property.SetValue(control, rule.Value.ToString(), null);
                    else if (property.PropertyType == typeof(int))
                        property.SetValue(control, Convert.ToInt32(rule.Value.ToString()), null);
                    else if (property.PropertyType == typeof(Color))
                        property.SetValue(control, Utils.ParseColor(rule.Value.ToString()), null);
                    //else
                        //Console.WriteLine("     Failed to apply rule.");
                }
                else
                {
                    //Console.WriteLine("     Failed to apply rule.");
                }
            }
        }
    }
}
