using Fo76ini.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Fo76ini.Utilities
{
    /// <summary>
    /// This class holds all custom fonts.
    /// </summary>
    /// <remarks>
    /// These are at the moment: Resources/overseer.ttf
    /// </remarks>
    public static class CustomFonts
    {
        /// <summary>
        /// Call this function before using any custom fonts.
        /// </summary>
        public static void Register()
        {
            InitCustomLabelFont(Resources.overseer);
            InitCustomLabelFont(Resources.RobotoCondensed_Bold);
        }

        /// <summary>
        /// Get header font depending on which language is selected.
        /// </summary>
        public static Font GetHeaderFont()
        {
            return GetHeaderFont(Localization.Locale);
        }

        /// <summary>
        /// Get header font depending on which language is given.
        /// </summary>
        public static Font GetHeaderFont(string ISO)
        {
            switch (ISO)
            {
                case "ru-RU":
                case "ja-JP":
                    return new Font(RobotoCondensed, 16, FontStyle.Bold);
                case "zh-CN":
                case "zh-TW":
                    return new Font("Microsoft JhengHei", 18, FontStyle.Bold);
                default:
                    return new Font(Overseer, 20, FontStyle.Regular);
            }
        }

        public static FontFamily Overseer
        {
            get
            {
                if (pfc.Families.Length < 2)
                    return FallbackFont;
                return pfc.Families[0];
            }
        }

        public static FontFamily RobotoCondensed
        {
            get
            {
                if (pfc.Families.Length < 2)
                    return FallbackFont;
                return pfc.Families[1];
            }
        }

        private static FontFamily FallbackFont
        {
            get { return FontFamily.GenericSansSerif; }
        }

        #region Code for registering fonts

        // Create your private font collection object.
        private static PrivateFontCollection pfc = new PrivateFontCollection();

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        // https://stackoverflow.com/a/23520042
        // https://stackoverflow.com/questions/1955629/c-sharp-using-an-embedded-font-on-a-textbox/1956043#1956043
        private static void InitCustomLabelFont(byte[] fontData)
        {
            // create a buffer to read in to
            //byte[] fontData = Resources.overseer;
            int fontLength = fontData.Length;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, fontLength);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            // free the unsafe memory
            // Marshal.FreeCoTaskMem(data);
        }

        #endregion
    }
}
