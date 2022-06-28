using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Fo76ini.Utilities
{
    public static class Utils
    {
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
                return string.Concat(Enumerable.Repeat("..\\", baseDirs.Length - fileDirs.Length));
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

        /*public static void DeleteDirectory(string targetDir)
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
        }*/

        /// <summary>
        /// Recursively deletes directory if it exists, but sets file attributes to normal before it deletes them.
        /// Workaround for "System.UnauthorizedAccessException" when trying to delete a folder.
        /// </summary>
        /// <param name="targetDir"></param>
        public static void DeleteDirectory(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                Utils.SetAttributesNormal(folder);
                folder.Delete(true);
            }
        }

        /// <summary>
        /// Delete file if it exists, but sets file attributes to normal before it deletes it.
        /// Workaround for "System.UnauthorizedAccessException" when trying to delete a file.
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                Utils.SetAttributesNormal(file);
                file.Delete();
            }
        }

        /// <summary>
        /// Workaround for "System.UnauthorizedAccessException" when trying to delete a folder.
        /// https://stackoverflow.com/questions/1701457/directory-delete-doesnt-work-access-denied-error-but-under-windows-explorer-it
        /// </summary>
        /// <param name="dir"></param>
        public static void SetAttributesNormal(DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                Utils.SetAttributesNormal(subDir);
                subDir.Attributes = FileAttributes.Normal;
            }
            foreach (var file in dir.GetFiles())
            {
                Utils.SetAttributesNormal(file);
            }
        }

        /// <summary>
        /// Workaround for "System.UnauthorizedAccessException" when trying to delete a file.
        /// https://stackoverflow.com/questions/1701457/directory-delete-doesnt-work-access-denied-error-but-under-windows-explorer-it
        /// </summary>
        /// <param name="file"></param>
        public static void SetAttributesNormal(FileInfo file)
        {
            file.Attributes = FileAttributes.Normal;
        }

        public static bool IsFileNameValid(string name)
        {
            List<char> invalidChars = new List<char>();
            invalidChars.AddRange(Path.GetInvalidPathChars());
            invalidChars.AddRange(Path.GetInvalidFileNameChars());
            return !invalidChars.Any(c => name.Contains(c));
        }

        public static string GetValidFileName(string value, string extension = "")
        {
            string newName = "";
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
        public static string GetUniquePath(string fullPath)
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

            IEnumerable<string> files = Directory.GetFiles(path);
            foreach (string filePath in files)
            {
                FileInfo info = new FileInfo(filePath);
                totalFolderSize += info.Length;
            }

            IEnumerable<string> folders = Directory.GetDirectories(path);
            foreach (string folderPath in folders)
            {
                totalFolderSize += GetSizeInBytes(folderPath);
            }

            return totalFolderSize;
        }

        // https://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
        /// <summary>
        /// Formats size in bytes into a string.
        /// </summary>
        public static string GetFormatedSize(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = (double)size;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return string.Format("{0:0.#} {1}", len, sizes[order]);
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

        public static void OpenExplorer(string path)
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

        public static void OpenNotepad(string path)
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

        public static void OpenFile(string path)
        {
            if (File.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            else
            {
                throw new FileNotFoundException($"File \"{path}\" does not exist!");
            }
        }

        public static void OpenURL(string url)
        {
            Process.Start(url);
        }

        public static bool IsDirectoryEmpty(string path)
        {
            // https://stackoverflow.com/questions/755574/how-to-quickly-check-if-folder-is-empty-net
            // https://stackoverflow.com/a/954837
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

        public static Size GetDisplayResolution()
        {
            DEVMODE vDevMode = Utils.GetDisplayInfo();
            return new Size(vDevMode.dmPelsWidth, vDevMode.dmPelsHeight);
        }



        public static float ToFloat(string num)
        {
            return Convert.ToSingle(Convert.ToDecimal(num, Shared.en_US));
        }

        public static uint ToUInt(string num)
        {
            return Convert.ToUInt32(Convert.ToDecimal(num, Shared.en_US));
        }

        public static int ToInt(string num)
        {
            //return Convert.ToInt32(num, Shared.en_US); // "0.0" => String.FormatException
            return Convert.ToInt32(Convert.ToDecimal(num, Shared.en_US)); // "0.0" => (int)0
        }

        public static long ToLong(string num)
        {
            return Convert.ToInt64(Convert.ToDecimal(num, Shared.en_US)); // "0.0" => (int)0
        }

        public static string ToString(float num)
        {
            Thread.CurrentThread.CurrentCulture = Shared.en_US;
            return num.ToString("F99").TrimEnd('0').TrimEnd('.');
        }

        public static string ToString(double num)
        {
            Thread.CurrentThread.CurrentCulture = Shared.en_US;
            return num.ToString("F99").TrimEnd('0').TrimEnd('.');
        }

        public static string ToString(long num)
        {
            Thread.CurrentThread.CurrentCulture = Shared.en_US;
            return num.ToString("D");
        }

        public static string ToString(int num)
        {
            Thread.CurrentThread.CurrentCulture = Shared.en_US;
            return num.ToString("D");
        }

        public static string ToString(uint num)
        {
            Thread.CurrentThread.CurrentCulture = Shared.en_US;
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

        public static List<int> ParseVersion(string versionString)
        {
            List<int> version = new List<int>();
            foreach (string chunk in versionString.Trim().Split(new char[] { 'v', '.', 'h', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries))
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

        public static int CompareVersions(string ver1Str, string ver2Str)
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


        public static PopupNotifier CreatePopup(string title, string text)
        {
            // https://www.c-sharpcorner.com/article/working-with-popup-notification-in-windows-forms/
            // https://github.com/Tulpep/Notification-Popup-Window

            PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            popup.AnimationDuration = 400;
            popup.Delay = 5000;
            popup.TitleText = title;
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

            popup.Click += Popup_Click;
            return popup;
        }

        public static PopupNotifier CreatePopup(string title, string text, MessageBoxIcon icon)
        {
            var popup = Utils.CreatePopup(title, text);
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    popup.Image = Properties.Resources.info_64;
                    break;
                case MessageBoxIcon.Warning:
                    popup.Image = Properties.Resources.warning_64;
                    break;
                case MessageBoxIcon.Error:
                    popup.Image = Properties.Resources.error_64;
                    break;
            }
            popup.ImagePadding = new Padding(10);
            return popup;
        }

        // Copy text:
        private static void Popup_Click(object sender, EventArgs e)
        {
            if (sender is PopupNotifier)
            {
                string text =
                    ((PopupNotifier)sender).TitleText + "\n\n" +
                    ((PopupNotifier)sender).ContentText;
                Clipboard.SetText(text);
            }
        }

        // https://stackoverflow.com/a/4722300
        public static bool IsProcessRunning(string name)
        {
            foreach (Process process in Process.GetProcesses())
            {
                // Check if a process with that name is already running, but ignore this process:
                if (process.ProcessName.ToLower().Contains(name.ToLower()) &&
                    process.Id != Process.GetCurrentProcess().Id)
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

        public static bool CreateHardLink(string originalFilePath, string newLinkPath)
        {
            return Utils.CreateHardLink(newLinkPath, originalFilePath, IntPtr.Zero);
        }

        public static bool CreateHardLink(string originalFilePath, string newLinkPath, bool overwrite)
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

        public static ImageCodecInfo GetImageEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        // https://stackoverflow.com/questions/2808887/create-thumbnail-image
        // https://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
        // https://stackoverflow.com/questions/1484759/quality-of-a-saved-jpg-in-c-sharp
        /// <summary>
        /// Creates an thumbnail as *.jpg with a given width and height.
        /// Instead of stretching the image, it'll resize it while maintaining the aspect ratio.
        /// A black padding can be drawn if the aspect ratios don't match.
        /// </summary>
        /// <param name="image">Input image</param>
        /// <param name="thumbnailPath">Path to *.jpg thumbnail (output)</param>
        /// <param name="drawBorders">Whether or not to draw a black border if the aspect ratios don't match</param>
        /// <param name="canvasWidth">Max thumbnail width</param>
        /// <param name="canvasHeight">Max thumbnail height</param>
        /// <param name="quality">JPG Quality (percentage) between 0 and 100</param>
        /// <returns>The thumbnail as Image object</returns>
        public static Image MakeThumbnail(Image image, string thumbnailPath, bool drawBorders = false, int canvasWidth = 160, int canvasHeight = 90, long quality = 70L)
        {
            // Figure out the ratio
            double ratioX = (double)canvasWidth / (double)image.Width;
            double ratioY = (double)canvasHeight / (double)image.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            // Create new image:
            Image thumbnail;
            if (drawBorders)
                thumbnail = new Bitmap(canvasWidth, canvasHeight);
            else
                thumbnail = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            if (drawBorders)
            {
                // Now calculate the X,Y position of the upper-left corner 
                // (one of these will always be zero)
                int posX = Convert.ToInt32((canvasWidth - (image.Width * ratio)) / 2);
                int posY = Convert.ToInt32((canvasHeight - (image.Height * ratio)) / 2);

                graphic.Clear(Color.Black); // background color, padding
                graphic.DrawImage(image, posX, posY, newWidth, newHeight);
            }
            else
            {
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Save the thumbnails as JPEG:
            ImageCodecInfo jgpEncoder = Utils.GetImageEncoder(ImageFormat.Jpeg);
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
            thumbnail.Save(thumbnailPath, jgpEncoder, encoderParameters);

            return thumbnail;
        }

        /// <summary>
        /// Creates an thumbnail as *.jpg with a given width and height.
        /// Instead of stretching the image, it'll resize it while maintaining the aspect ratio.
        /// A black padding can be drawn if the aspect ratios don't match.
        /// </summary>
        /// <param name="filePath">Path to image (input)</param>
        /// <param name="thumbnailPath">Path to *.jpg thumbnail (output)</param>
        /// <param name="drawBorders">Whether or not to draw a black border if the aspect ratios don't match</param>
        /// <param name="canvasWidth">Max thumbnail width</param>
        /// <param name="canvasHeight">Max thumbnail height</param>
        /// <param name="quality">JPG Quality (percentage) between 0 and 100</param>
        /// <returns>The thumbnail as Image object</returns>
        public static Image MakeThumbnail(string filePath, string thumbnailPath, bool drawBorders = false, int canvasWidth = 160, int canvasHeight = 90, long quality = 70L)
        {
            Image image = Image.FromFile(filePath);
            return Utils.MakeThumbnail(image, thumbnailPath, drawBorders, canvasWidth, canvasHeight, quality);
        }

        // https://stackoverflow.com/a/336729
        public static string GetOSArchitecture()
        {
            if (Environment.Is64BitOperatingSystem ||
                Environment.Is64BitProcess)
                return "64-bit";
            return "32-bit";
        }

        // https://stackoverflow.com/questions/2819934/detect-windows-version-in-net
        // https://andrewensley.com/2009/06/c-detect-windows-os-part-1/
        // https://docs.microsoft.com/en-us/windows/win32/sysinfo/operating-system-version
        // https://www.prugg.at/2019/09/09/properly-detect-windows-version-in-c-net-even-windows-10/
        public static string GetOSName()
        {
            // Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            // Get version information about the os.
            Version vs = os.Version;

            // Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                // This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else if (vs.Minor == 1)
                            operatingSystem = "XP";
                        else if (vs.Minor == 2)
                            operatingSystem = "Server 2003"; // Or "Windows XP 64-Bit Edition"
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista"; // Or "Windows Server 2008"
                        else if (vs.Minor == 1)
                            operatingSystem = "7"; // Or "Windows Server 2008 R2"
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else if (vs.Minor == 3)
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        if (vs.Build >= 22000)
                            operatingSystem = "11";
                        else
                            operatingSystem = "10";

                        // Or "Windows Server 2019"
                        // Or "Windows Server 2016"
                        break;
                    default:
                        break;
                }
            }

            // Make sure we actually got something in our OS check
            // We don't want to just return " Service Pack 2" or " 32-bit"
            // That information is useless without the OS version.
            if (operatingSystem != "")
            {
                // Got something. Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                // See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    // Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                // Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                // operatingSystem += " " + GetOSArchitecture();
            }
            else
            {
                return "Unknown Windows Version";
            }

            // Return the information we've gathered.
            return operatingSystem;
        }

        // https://stackoverflow.com/a/2016557
        /*public static string GetOSNameWMI()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString().Trim() : "";
        }*/

        public static long GetUnixTimeStamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        // https://stackoverflow.com/a/250400
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }



        /// <summary>
        /// Disable scroll wheel on UI elements (NumericUpDown and ComboBox) to prevent the user from accidentally changing values
        /// </summary>
        public static void PreventChangeOnMouseWheelForAllElements(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                // NumericUpDown and ComboBox:
                if (subControl is NumericUpDown ||
                    subControl is ComboBox ||
                    subControl is TrackBar ||
                    subControl.Name.StartsWith("num") ||
                    subControl.Name.StartsWith("comboBox") ||
                    subControl.Name.StartsWith("slider"))
                    subControl.MouseWheel += (object sender, MouseEventArgs e) => ((HandledMouseEventArgs)e).Handled = true;

                // TabControl, TabPage, and GroupBox:
                if (subControl is TabControl ||
                    subControl is TabPage ||
                    subControl is GroupBox ||
                    subControl.Name.StartsWith("tab") ||
                    subControl.Name.StartsWith("groupBox") ||
                    subControl.Name.StartsWith("panel"))
                    PreventChangeOnMouseWheelForAllElements(subControl);
            }
        }

        /// <summary>
        /// Checks whether the user has administrator rights.
        /// </summary>
        public static bool HasAdminRights()
        {
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
