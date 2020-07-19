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
using System.Drawing;
using System.Drawing.Imaging;
using ImageMagick;
using Tulpep.NotificationWindow;

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
            IniFiles.Instance.SetNTFSWritePermission(true);
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

        public static void DeleteFile(string targetFile)
        {
            File.SetAttributes(targetFile, FileAttributes.Normal);
            File.Delete(targetFile);
        }

        public static String GetValidFileName(string value, string extension = "")
        {
            String newName = "";
            if (value.Trim().Length < 0)
            {
                newName = "untitled";
            }
            else
            {
                char[] invalidChars = Path.GetInvalidPathChars();
                for (int i = 0; i < value.Length; i++)
                    if (invalidChars.Contains(value[i]))
                        newName += '_';
                    else
                        newName += value[i];
                newName = newName.Trim();
            }
            if (extension.Length > 0 && !newName.EndsWith(extension))
                newName += extension;
            return newName;
        }

        /// <summary>
        /// Returns "File (1).txt" if "File.txt" already exists.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static String GetUniquePath(string fullPath)
        {
            // https://stackoverflow.com/a/13049909
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath);
            string path = Path.GetDirectoryName(fullPath);
            string newFullPath = fullPath;

            while (File.Exists(newFullPath) || Directory.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0} ({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }

            return newFullPath;
        }

        public static long GetSizeInBytes(string path)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                return info.Length;
            }

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(path);

            long totalFolderSize = 0;

            IEnumerable<String> files = Directory.GetFiles(path);
            foreach (String filePath in files)
            {
                FileInfo info = new FileInfo(filePath);
                totalFolderSize += info.Length;
            }

            IEnumerable<String> folders = Directory.GetDirectories(path);
            foreach (String folderPath in folders)
            {
                totalFolderSize += GetSizeInBytes(folderPath);
            }

            return totalFolderSize;
        }

        // https://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
        // Copy-paste because, I'm lazy. Don't jugde me! :P
        public static String GetFormatedSize(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = (double)size;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.#} {1}", len, sizes[order]);
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

        public static void OpenNotepad(String path)
        {
            if (File.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = path
                };
                Process.Start(startInfo);
            }
            else
            {
                throw new FileNotFoundException($"File \"{path}\" does not exist!");
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

        public static int[] GetDisplayResolution()
        {
            DEVMODE vDevMode = Utils.GetDisplayInfo();
            return new int[] { vDevMode.dmPelsWidth, vDevMode.dmPelsHeight };
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

        public static void SetFormPosition(Form form, int x, int y)
        {
            // https://stackoverflow.com/questions/31401568/how-can-i-set-the-windows-form-position-manually
            var myScreen = Screen.FromControl(form);

            form.Left = myScreen.Bounds.Left;
            form.Top = myScreen.Bounds.Top;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(x, y);
        }


        public static bool RepairDDS(String filePath)
        {
            String fileName = Path.GetFileName(filePath);
            try
            {
                MagickImage image = new MagickImage(filePath);
                image.Write(filePath);
                return true;
            }
            catch (ImageMagick.MagickCorruptImageErrorException exc)
            {
                Console.WriteLine("MagickCorruptImageErrorException: " + exc.Message);
            }

            Pfim.IImage pfimImage = Pfim.Pfim.FromFile(filePath);
            PixelFormat format;
            switch (pfimImage.Format)
            {
                case Pfim.ImageFormat.Rgb24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case Pfim.ImageFormat.Rgba32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                case Pfim.ImageFormat.R5g5b5:
                    format = PixelFormat.Format16bppRgb555;
                    break;

                case Pfim.ImageFormat.R5g6b5:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case Pfim.ImageFormat.R5g5b5a1:
                    format = PixelFormat.Format16bppArgb1555;
                    break;

                case Pfim.ImageFormat.Rgb8:
                    format = PixelFormat.Format8bppIndexed;
                    break;

                default:
                    Console.WriteLine("Failed: Image format not supported.");
                    /*var msg = $"{image.Format} is not recognized for Bitmap on Windows Forms. " +
                               "You'd need to write a conversion function to convert the data to known format";
                    var caption = "Unrecognized format";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK);*/
                    return false;
            }
            Console.WriteLine("Writing " + fileName);
            var data = System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pfimImage.Data, 0);
            Bitmap bitmap = new Bitmap(pfimImage.Width, pfimImage.Height, pfimImage.Stride, format, data);
            MagickImage magickImage = new MagickImage(bitmap);
            File.Delete(filePath);
            magickImage.Write(filePath);
            return true;
        }


        public static bool IsValidDDS(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path)) // Check for existence.
                return false;

            uint magicNumber = 0; byte[] headerLength = new byte[sizeof(byte)];
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] magic = new byte[sizeof(uint)];

                // I'm still pretty used to C and fread, so here you go :^)
                if (fs.Read(magic, 0, sizeof(uint)) != sizeof(uint))
                    return false; // Not even a valid file.

                if (fs.Read(headerLength, 0, sizeof(byte)) != sizeof(byte))
                    return false; // Not enough bytes, even if the first 4 bytes were checked.

                // Convert to a big endian integer.
                magicNumber = (uint)((magic[0] << 24) | (magic[1] << 16) | (magic[2] << 8) | magic[3]);
            }
            return (headerLength[0] == 0x7C) && (magicNumber == 0x44445320);
        }


        public static List<int> ParseVersion(String versionString)
        {
            List<int> version = new List<int>();
            foreach (String chunk in versionString.Trim().Split(new char[] { 'v', '.', 'h', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                bool isNumeric = int.TryParse(chunk.Trim(), out int n);
                if (isNumeric)
                    version.Add(Convert.ToInt32(n));
                else
                    version.Add(0);
            }
            while (version.Count < 4)
                version.Add(0);
            return version; // "1.3.1h2" => { 1, 3, 1, 2 }
        }

        public static int CompareVersions(String ver1Str, String ver2Str)
        {
            var ver1 = ParseVersion(ver1Str);
            var ver2 = ParseVersion(ver2Str);
            return (ver1[0] * 1000000 + ver1[1] * 10000 + ver1[2] * 100 + ver1[3]) - (ver2[0] * 1000000 + ver2[1] * 10000 + ver2[2] * 100 + ver2[3]);
            /*for (int i = 0; i < 4; i++)
            {
                if (ver1[i] != ver2[i])
                    return ver1[i] - ver2[i];
            }
            return 0;*/
        }


        public static PopupNotifier CreatePopup (String title, String text)
        {
            // https://www.c-sharpcorner.com/article/working-with-popup-notification-in-windows-forms/
            // https://github.com/Tulpep/Notification-Popup-Window

            PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            popup.AnimationDuration = 400;
            popup.Delay = 5000;
            popup.TitleText = "Quick Configuration: " + title;
            popup.ContentText = text;

            popup.Size = new Size(500, 200);

            // https://docs.microsoft.com/de-de/dotnet/api/system.drawing.font?view=dotnet-plat-ext-3.1
            popup.ContentFont = new Font(
                popup.ContentFont.Name,
                12f,
                popup.ContentFont.Style,
                GraphicsUnit.Pixel
            );
            popup.ContentPadding = new Padding(8);

            popup.TitleFont = new Font(
                popup.ContentFont.Name,
                16f,
                FontStyle.Bold,
                GraphicsUnit.Pixel
            );
            popup.TitlePadding = new Padding(4);
            return popup;
        }

        public static PopupNotifier CreatePopup(String title, String text, MessageBoxIcon icon)
        {
            var popup = Utils.CreatePopup(title, text);
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    popup.Image = Properties.Resources.info;
                    break;
                case MessageBoxIcon.Warning:
                    popup.Image = Properties.Resources.warning;
                    break;
                case MessageBoxIcon.Error:
                    popup.Image = Properties.Resources.error;
                    break;
            }
            popup.ImagePadding = new Padding(10);
            return popup;
        }

        // https://stackoverflow.com/a/4722300
        public static bool IsProcessRunning(string name)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

        // https://stackoverflow.com/questions/3387690/how-to-create-a-hardlink-in-c
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            IntPtr lpSecurityAttributes
        );

        public static bool CreateHardLink(String originalFilePath, String newLinkPath)
        {
            return Utils.CreateHardLink(newLinkPath, originalFilePath, IntPtr.Zero);
        }

        public static bool CreateHardLink(String originalFilePath, String newLinkPath, bool overwrite)
        {
            if (File.Exists(newLinkPath))
            {
                if (overwrite)
                    File.Delete(newLinkPath);
                else
                    throw new Exception($"Trying to create a hardlink in \"{newLinkPath}\" but this file already exists.");
            }
            return Utils.CreateHardLink(newLinkPath, originalFilePath, IntPtr.Zero);
        }
    }
}
