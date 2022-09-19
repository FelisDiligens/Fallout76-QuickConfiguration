using FastColoredTextBoxNS;
using Fo76ini.Controls;
using Fo76ini.Properties;
using Fo76ini.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        private static ThemeType _currentTheme;
        public static ThemeType CurrentTheme { get { return _currentTheme; } }

        private static Dictionary<string, string> _vars = new Dictionary<string, string>();

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

        public static string Get(string key)
        {
            return _vars[key];
        }

        public static string Get(string key, string defaultValue)
        {
            if (_vars.ContainsKey(key))
                return _vars[key];
            return defaultValue;
        }

        public static Color GetColor(string key)
        {
            return Utils.ParseColor(Get(key));
        }

        public static Color GetColor(string key, string defaultValue)
        {
            return Utils.ParseColor(Get(key, defaultValue));
        }

        public static Color GetColor(string key, Color defaultValue)
        {
            if (_vars.ContainsKey(key))
                return Utils.ParseColor(_vars[key]);
            return defaultValue;
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
            _currentTheme = theme.Type;
            _vars = theme.Vars;

            String controlType = control.GetType().Name;
            String controlName = control.Name;
            String tag = "Default";
            if (control.Tag != null)
                tag = control.Tag.ToString();

            foreach (VisualStyle style in theme.Styles)
            {
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (Regex.IsMatch(controlType, controlRegex))
                {
                    string styleRegex = Utils.WildCardToRegular(style.StyleName);
                    if (style.StyleName == "Default")
                        ApplyStyle(style, control);

                    else if (tag != controlName &&
                        tag != "Default" &&
                        tag != null &&
                        Regex.IsMatch(tag, styleRegex))
                        ApplyStyle(style, control);

                    else if (Regex.IsMatch(controlName, styleRegex))
                        ApplyStyle(style, control);
                }
            }

            //control.Refresh();

            ApplyTheme(theme, control.Controls);
        }

        private static void ApplyStyle(VisualStyle style, Control control)
        {
            if (style == null || control == null)
                return;

            foreach (KeyValuePair<String, object> rule in style.Rules)
            {
                PropertyInfo property = control.GetType().GetProperty(rule.Key);
                if (property != null)
                {
                    String value = rule.Value.ToString();
                    if (value.StartsWith("var"))
                    {
                        int left = value.IndexOf('(');
                        int right = value.IndexOf(')');

                        if (left >= 0 && right >= 0)
                        {
                            string varName = value.Substring(left + 1, right - left - 1);
                            value = Get(varName, value);
                        }
                    }

                    if (property.PropertyType == typeof(string))
                        property.SetValue(control, value, null);
                    else if (property.PropertyType == typeof(int))
                        property.SetValue(control, Convert.ToInt32(value), null);
                    else if (property.PropertyType == typeof(Color))
                        property.SetValue(control, Utils.ParseColor(value), null);
                    else if (property.PropertyType == typeof(Image))
                    {
                        Image img = (Image)Resources.ResourceManager.GetObject(value);
                        property.SetValue(control, img, null);
                    }
                }
            }
        }
    }
}
