using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Mods
{
    public class Archive2
    {
        public static Log logFile;
        private static String archive2Path = ".\\Archive2\\Archive2.exe";

        public static String Archive2Path
        {
            get { return Archive2.archive2Path; }
        }

        static Archive2()
        {
            logFile = new Log(Log.GetFilePath("archive2.log.txt"));
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

        public static Archive2.Compression GetCompression(String compressionStr)
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

        public static Archive2.Format GetFormat(String formatStr)
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

        private static void Call(String arguments)
        {
            if (!Archive2.ValidatePath())
                throw new Archive2Exception("Path to Archive2.exe not specified or Archive2.exe not found.");

            using (Process proc = new Process())
            {
                logFile.WriteTimeStamp();
                logFile.WriteLine($">> Archive2.exe {arguments}");
                proc.StartInfo.UseShellExecute = false; // = true
                proc.StartInfo.RedirectStandardOutput = true; // // ...
                proc.StartInfo.RedirectStandardError = true; // // ...
                proc.StartInfo.FileName = Archive2.archive2Path;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true; // // ...
                proc.Start();

                //MessageBox.Show(/*proc.StandardOutput.ReadToEnd(), */$"Archive2.exe {arguments}");
                logFile.WriteLine(proc.StandardOutput.ReadToEnd());
                logFile.WriteLine(proc.StandardError.ReadToEnd());
                proc.WaitForExit();
            }
        }

        private static void CallParallel(String arguments)
        {
            if (!Archive2.ValidatePath())
                throw new Archive2Exception("Path to Archive2.exe not specified or Archive2.exe not found.");

            using (Process proc = new Process())
            {
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = Archive2.archive2Path;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
            }
        }

        public static void Extract(String ba2Archive, String outputFolder)
        {
            Archive2.Call($"\"{ba2Archive}\" -extract=\"{outputFolder}\" -quiet");

            if (!Directory.Exists(outputFolder))
                throw new Archive2Exception("Extraction failed, folder has not been created.");
            else if (Utils.IsDirectoryEmpty(outputFolder))
                throw new Archive2Exception("Extraction failed, folder is empty.");
        }

        public static void Explore(String ba2Archive)
        {
            Archive2.CallParallel($"\"{ba2Archive}\"");
        }

        public static void Explore()
        {
            Archive2.CallParallel("");
        }

        public static void Create(String ba2Archive, String folder)
        {
            Archive2.Create(ba2Archive, folder, Archive2.Compression.Default, Archive2.Format.General);
        }

        public static void Create(String ba2Archive, String folder, Archive2.Preset preset)
        {
            Archive2.Create(ba2Archive, folder, preset.compression, preset.format);
        }

        public static void Create(String ba2Archive, String folder, Archive2.Compression compression, Archive2.Format format)
        {
            if (!Directory.Exists(folder) || Utils.IsDirectoryEmpty(folder))
                throw new DirectoryNotFoundException($"The specified folder \"{folder}\" does not exist or is empty.");

            String compressionStr = Enum.GetName(typeof(Archive2.Compression), (int)compression);
            String formatStr = Enum.GetName(typeof(Archive2.Format), (int)format);
            folder = Path.GetFullPath(folder);
            Archive2.Call($"\"{folder}\" -create=\"{ba2Archive}\" -compression={compressionStr} -format={formatStr} -root=\"{folder}\" -tempFiles -quiet");

            if (!File.Exists(ba2Archive))
                throw new Archive2Exception("Packing failed, archive has not been created.");
        }

        public static bool ValidatePath(String path)
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
}
