using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using static Fo76ini.Mods.ManagedMod;

namespace Fo76ini.Utilities
{
    /// <summary>
    /// Interface for the Archive2.exe
    /// Create, extract, and explore *.BA2 archvies.
    /// </summary>
    public class Archive2
    {
        public static TextWriter LogFile;
        public static string LogFilePath;

        public static readonly string DefaultArchive2Path = ".\\Archive2\\Archive2.exe";

        public static string Archive2Path
        {
            get
            {
                string path = Path.GetFullPath(Configuration.Archive2Path);
                if (File.Exists(path))
                    return path;
                else
                    return Path.Combine(Shared.AppInstallationFolder, "Archive2\\Archive2.exe");
            }
        }

        static Archive2()
        {
            Archive2.LogFilePath = Log.GetFilePath("archive2.log.txt");
            Archive2.LogFile = Log.Open(LogFilePath);

#if DEBUG
            Archive2.LogFile = Console.Out;
#endif
        }

        public enum Compression
        {
            None,
            Default,
            XBox
        }

        public enum Format
        {
            General,
            DDS,
            XBoxDDS,
            GNF
        }

        public struct Preset
        {
            public Archive2.Compression compression;
            public Archive2.Format format;
        }

        public struct Info
        {
            public Archive2.Compression compression;
            public Archive2.Format format;
            public int numOfFiles;
        }

        public static Archive2.Compression GetCompression(string compressionStr)
        {
            switch (compressionStr)
            {
                case "None":
                    return Archive2.Compression.None;
                case "Default":
                    return Archive2.Compression.Default;
                case "XBox":
                    return Archive2.Compression.XBox;
                default:
                    throw new InvalidDataException($"Invalid ba2 compression type: {compressionStr}");
            }
        }


        /// <summary>
        /// Convert Archive2.Compression enum to string.
        /// </summary>
        public static string GetCompressionName(Archive2.Compression compression)
        {
            return Enum.GetName(typeof(Archive2.Compression), (int)compression);
        }

        public static Archive2.Format GetFormat(string formatStr)
        {
            switch (formatStr)
            {
                case "General":
                case "GNRL":
                    return Archive2.Format.General;
                case "DDS":
                case "DX10":
                    return Archive2.Format.DDS;
                case "XBoxDDS":
                    return Archive2.Format.XBoxDDS;
                case "GNF":
                    return Archive2.Format.GNF;
                default:
                    throw new ArgumentException($"Invalid ba2 format type: {formatStr}");
            }
        }

        /// <summary>
        /// Convert Archive2.Format enum to string.
        /// </summary>
        public static string GetFormatName(Archive2.Format format)
        {
            return Enum.GetName(typeof(Archive2.Format), (int)format);
        }

        private static void Call(string arguments)
        {
            if (!Archive2.ValidatePath())
                throw new Archive2Exception("Path to Archive2.exe not specified or Archive2.exe not found.");

            using (Process proc = new Process())
            {
                LogFile.WriteLine(Log.GetTimeStamp());
                LogFile.WriteLine($">> Archive2.exe {arguments}");
                proc.StartInfo.UseShellExecute = false; // = true
                proc.StartInfo.RedirectStandardOutput = true; // // ...
                proc.StartInfo.RedirectStandardError = true; // // ...
                proc.StartInfo.FileName = Archive2Path;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true; // // ...
                proc.Start();

                //MessageBox.Show(/*proc.StandardOutput.ReadToEnd(), */$"Archive2.exe {arguments}");
                /*logFile.WriteLine(proc.StandardOutput.ReadToEnd());
                logFile.WriteLine(proc.StandardError.ReadToEnd());*/

                string output = proc.StandardOutput.ReadToEnd() + "\n" + proc.StandardError.ReadToEnd();
                LogFile.WriteLine(output);
                proc.WaitForExit();

                // System.IO.FileNotFoundException: Could not load file or assembly 'Archive2Interop.dll'
                if (output.Contains("System.IO.FileNotFoundException:") && output.Contains("'Archive2Interop.dll'"))
                    throw new Archive2RequirementsException("System.IO.FileNotFoundException: Could not load file or assembly 'Archive2Interop.dll'. 'Visual C++ Redistributable for Visual Studio 2012 Update 4' is likely not installed.");
            }
        }

        private static void CallParallel(string arguments)
        {
            if (!Archive2.ValidatePath())
                throw new Archive2Exception("Path to Archive2.exe not specified or Archive2.exe not found.");

            using (Process proc = new Process())
            {
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = Archive2Path;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
            }
        }

        public static void Extract(string ba2Archive, string outputFolder)
        {
            Archive2.Call($"\"{ba2Archive}\" -extract=\"{outputFolder}\" -quiet");

            if (!Directory.Exists(outputFolder))
                throw new Archive2Exception("Extraction failed, folder has not been created.");
            else if (Utils.IsDirectoryEmpty(outputFolder))
                throw new Archive2Exception("Extraction failed, folder is empty.");
        }

        public static void Explore(string ba2Archive)
        {
            Archive2.CallParallel($"\"{ba2Archive}\"");
        }

        public static void Explore()
        {
            Archive2.CallParallel("");
        }

        public static void Create(string ba2Archive, string folder)
        {
            Archive2.Create(ba2Archive, folder, Archive2.Compression.Default, Archive2.Format.General);
        }

        public static void Create(string ba2Archive, string folder, Archive2.Preset preset)
        {
            Archive2.Create(ba2Archive, folder, preset.compression, preset.format);
        }

        public static void Create(string ba2Archive, string folder, Archive2.Compression compression, Archive2.Format format)
        {
            if (!Directory.Exists(folder) || Utils.IsDirectoryEmpty(folder))
                throw new DirectoryNotFoundException($"The specified folder \"{folder}\" does not exist or is empty.");

            string compressionStr = Enum.GetName(typeof(Archive2.Compression), (int)compression);
            string formatStr = Enum.GetName(typeof(Archive2.Format), (int)format);
            folder = Path.GetFullPath(folder);
            Archive2.Call($"\"{folder}\" -create=\"{ba2Archive}\" -compression={compressionStr} -format={formatStr} -root=\"{folder}\" -tempFiles -quiet");

            if (!File.Exists(ba2Archive))
                throw new Archive2Exception("Packing failed, archive has not been created.");
        }

        public static bool ValidatePath(string path)
        {
            return path != null && File.Exists(path) && path.EndsWith(".exe");
        }

        public static bool ValidatePath()
        {
            return ValidatePath(Archive2.Archive2Path);
        }

        /// <summary>
        /// Reads an Archive2 file (*.ba2) and tries to determine Format and Compression.
        /// This method is not perfect!
        /// </summary>
        /// <param name="path">Path to *.ba2 file</param>
        /// <returns></returns>
        /// <exception cref="Archive2Exception"></exception>
        public static Archive2.Info ReadFile(string path)
        {
            Archive2.Format format;
            Archive2.Compression compression = Archive2.Compression.None;
            int numOfFiles;

            // Open byte stream:
            FileStream fs = new FileStream(path, FileMode.Open);

            // Checking magic number:
            byte[] bMagicNum = new byte[4];
            fs.Seek(0x00, SeekOrigin.Begin);
            fs.Read(bMagicNum, 0, 4);
            string sMagicNum = Encoding.UTF8.GetString(bMagicNum).TrimEnd('\0');
            if (sMagicNum != "BTDX")
                throw new Archive2Exception($"Invalid Archive2 file: Expected 'BTDX' magic number, got '{sMagicNum}'.");

            // Reading format ("GNRL" or "DX10"):
            byte[] bFormat = new byte[4];
            fs.Seek(0x08, SeekOrigin.Begin);
            fs.Read(bFormat, 0, 4);
            string sFormat = Encoding.UTF8.GetString(bFormat).TrimEnd('\0');
            if (sFormat.ToUpper() == "GNRL")
                format = Archive2.Format.General;
            else if (sFormat.ToUpper() == "DX10")
                format = Archive2.Format.DDS;
            else
                throw new Archive2Exception($"Couldn't read Archive2 file: Unknown format '{sFormat}', expected GNRL or DX10.");

            // Reading number of files:
            byte[] bNumOfFiles = new byte[4];
            fs.Seek(0x0C, SeekOrigin.Begin);
            fs.Read(bNumOfFiles, 0, 4);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bNumOfFiles);
            numOfFiles = BitConverter.ToInt32(bNumOfFiles, 0); // Little endian.
            if (numOfFiles <= 0)
                throw new Archive2Exception($"Couldn't read Archive2 file: Number of files is 0 or less. Empty archive?");

            // Reading pack and full size of the first file in the archive.
            // Trying to detect compression by looking at pack and full size:
            if (format == Archive2.Format.General) // "GNRL"
            {
                byte[] bPackSize = new byte[4];
                fs.Seek(0x18 + 0x18, SeekOrigin.Begin);
                fs.Read(bPackSize, 0, 4);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(bPackSize);
                int packSize = BitConverter.ToInt32(bPackSize, 0); // Little endian.

                byte[] bFullSize = new byte[4];
                fs.Seek(0x18 + 0x1C, SeekOrigin.Begin);
                fs.Read(bFullSize, 0, 4);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(bFullSize);
                int fullSize = BitConverter.ToInt32(bPackSize, 0); // Little endian.

                if (packSize > 0)
                    compression = Archive2.Compression.Default;
            }
            else if (format == Archive2.Format.DDS) // "DX10"
            {
                byte[] bPackSize = new byte[4];
                fs.Seek(0x18 + 0x18 + 0x08, SeekOrigin.Begin);
                fs.Read(bPackSize, 0, 4);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(bPackSize);
                int packSize = BitConverter.ToInt32(bPackSize, 0); // Little endian.

                byte[] bFullSize = new byte[4];
                fs.Seek(0x18 + 0x18 + 0x0C, SeekOrigin.Begin);
                fs.Read(bFullSize, 0, 4);
                if (!BitConverter.IsLittleEndian)
                    Array.Reverse(bFullSize);
                int fullSize = BitConverter.ToInt32(bPackSize, 0); // Little endian.

                if (packSize != 0 || fullSize != 0)
                    compression = Archive2.Compression.Default;
            }

            // Returning preset:
            Archive2.Info info = new Archive2.Info();
            info.format = format;
            info.compression = compression;
            info.numOfFiles = numOfFiles;
            return info;
        }
    }

    public class Archive2Exception : Exception
    {
        public Archive2Exception() { }
        public Archive2Exception(string message) : base(message) { }
        public Archive2Exception(string message, Exception inner) : base(message, inner) { }
    }

    public class Archive2RequirementsException : Archive2Exception
    {
        public Archive2RequirementsException() { }
        public Archive2RequirementsException(string message) : base(message) { }
        public Archive2RequirementsException(string message, Exception inner) : base(message, inner) { }
    }
}
