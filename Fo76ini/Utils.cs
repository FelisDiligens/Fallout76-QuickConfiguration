using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Fo76ini
{
    class Utils
    {
        public static CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");

        public static String SevenZipPath = Path.GetFullPath(".\\7z\\7za.exe");

        /// <summary>
        /// Returns a path relative to "workingDirectory".
        /// 
        /// MakeRelativePath("c:\\dev\\foo\\bar", "c:\\dev\\junk\\readme.txt")
        /// -> returns: "..\\..\\junk\\readme.txt"
        /// MakeRelativePath("c:\\dev\\foo\\bar", "c:\\dev\\foo\\bar\\docs\\readme.txt")
        /// ->  returns: "docs\\readme.txt"
        /// </summary>
        /// <param name="workingDirectory">Reference path</param>
        /// <param name="fullPath">Full path</param>
        /// <returns>Relative path</returns>
        public static string MakeRelativePath(string workingDirectory, string fullPath)
        {
            // https://stackoverflow.com/questions/703281/getting-path-relative-to-the-current-working-directory/703290
            // https://stackoverflow.com/a/19453551

            string result = string.Empty;
            int offset;

            // Smae path:
            if (fullPath == workingDirectory)
                return ".";

            // this is the easy case.  The file is inside of the working directory.
            if (fullPath.StartsWith(workingDirectory))
            {
                return fullPath.Substring(workingDirectory.Length + 1);
            }

            // the hard case has to back out of the working directory
            string[] baseDirs = workingDirectory.Split(new char[] { ':', '\\', '/' });
            string[] fileDirs = fullPath.Split(new char[] { ':', '\\', '/' });

            // if we failed to split (empty strings?) or the drive letter does not match
            if (baseDirs.Length <= 0 || fileDirs.Length <= 0 || baseDirs[0] != fileDirs[0])
            {
                // can't create a relative path between separate harddrives/partitions.
                return fullPath;
            }

            // we go a few levels back:
            if (workingDirectory.StartsWith(fullPath))
            {
                return String.Concat(Enumerable.Repeat("..\\", baseDirs.Length - fileDirs.Length));
            }

            // skip all leading directories that match
            for (offset = 1; offset < baseDirs.Length; offset++)
            {
                if (baseDirs[offset] != fileDirs[offset])
                    break;
            }

            // back out of the working directory
            for (int i = 0; i < (baseDirs.Length - offset); i++)
            {
                result += "..\\";
            }

            // step into the file path
            for (int i = offset; i < fileDirs.Length - 1; i++)
            {
                result += fileDirs[i] + "\\";
            }

            // append the file
            result += fileDirs[fileDirs.Length - 1];

            return result;
        }

        /// <summary>
        /// Recursively deletes directory, but sets file attributes to normal before it deletes them.
        /// </summary>
        /// <param name="targetDir"></param>
        public static void DeleteDirectory(string targetDir)
        {
            // https://stackoverflow.com/questions/1157246/unauthorizedaccessexception-trying-to-delete-a-file-in-a-folder-where-i-can-dele
            File.SetAttributes(targetDir, FileAttributes.Normal);

            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                Utils.DeleteDirectory(dir);
            }

            Directory.Delete(targetDir, false);
        }

        /// <summary>
        /// Clamps the value between min and max.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            // https://stackoverflow.com/questions/2683442/where-can-i-find-the-clamp-function-in-net

            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static void OpenExplorer(String path)
        {
            // https://www.codeproject.com/Questions/852563/How-to-open-file-explorer-at-given-location-in-csh

            if (Directory.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = path
                };
                // Process.Start(path);
                Process.Start(startInfo);
            }
            else
            {
                throw new FileNotFoundException($"Directory \"{path}\" does not exist!");
            }
        }

        public static void ExtractArchive(string sourceArchive, string destination)
        {
            if (!File.Exists(Utils.SevenZipPath))
                throw new FileNotFoundException("7z\\7za.exe could not be found.");

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.FileName = Utils.SevenZipPath;
            proc.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", sourceArchive, destination);
            Process x = Process.Start(proc);
            x.WaitForExit();
        }

        public static bool IsDirectoryEmpty(string path)
        {
            // https://stackoverflow.com/questions/755574/how-to-quickly-check-if-folder-is-empty-net
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        /*
         * EnumDisplaySettings
         * https://www.reddit.com/r/csharp/comments/31yw0t/how_can_i_get_the_main_monitors_refresh_rate/
         * https://stackoverflow.com/questions/744541/how-to-list-available-video-modes-using-c/744609#744609
         * https://docs.microsoft.com/de-de/windows/win32/api/winuser/nf-winuser-enumdisplaysettingsa?redirectedfrom=MSDN
         */

        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(
              string deviceName, int modeNum, ref DEVMODE devMode);
        private const int ENUM_CURRENT_SETTINGS = -1;

        private const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        private struct DEVMODE
        {

            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;

        }

        private static DEVMODE GetDisplayInfo()
        {
            DEVMODE vDevMode = new DEVMODE();
            EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref vDevMode);
            return vDevMode;
        }

        public static int GetDisplayRefreshRate()
        {
            DEVMODE vDevMode = Utils.GetDisplayInfo();
            return vDevMode.dmDisplayFrequency;
        }



        public static float ToFloat(string num)
        {
            return Convert.ToSingle(Convert.ToDecimal(num, enUS));
        }

        public static uint ToUInt(string num)
        {
            return Convert.ToUInt32(Convert.ToDecimal(num, enUS));
        }

        public static int ToInt(string num)
        {
            //return Convert.ToInt32(num, enUS); // "0.0" => String.FormatException
            return Convert.ToInt32(Convert.ToDecimal(num, enUS)); // "0.0" => (int)0
        }

        public static String ToString(float num)
        {
            Thread.CurrentThread.CurrentCulture = enUS;
            return num.ToString("F99").TrimEnd('0').TrimEnd('.');
        }

        public static String ToString(double num)
        {
            Thread.CurrentThread.CurrentCulture = enUS;
            return num.ToString("F99").TrimEnd('0').TrimEnd('.');
        }

        public static String ToString(int num)
        {
            Thread.CurrentThread.CurrentCulture = enUS;
            return num.ToString("D");
        }

        public static String ToString(uint num)
        {
            Thread.CurrentThread.CurrentCulture = enUS;
            return num.ToString("D");
        }
    }
}
