using System;
using System.Diagnostics;
using System.IO;

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

        public static Archive2.Format GetFormat(string formatStr)
        {
            switch (formatStr)
            {
                case "General":
                    return Archive2.Format.General;
                case "DDS":
                    return Archive2.Format.DDS;
                case "XBoxDDS":
                    return Archive2.Format.XBoxDDS;
                case "GNF":
                    return Archive2.Format.GNF;
                default:
                    throw new ArgumentException($"Invalid ba2 format type: {formatStr}");
            }
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
