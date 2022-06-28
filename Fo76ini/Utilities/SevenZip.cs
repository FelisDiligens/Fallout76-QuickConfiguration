using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Fo76ini.Utilities
{
    /// <summary>
    /// Interface for 7z.exe
    /// </summary>
    public class SevenZip
    {
        public static readonly string DefaultExecPath = ".\\7z\\7z.exe";

        public static string ExecPath
        {
            get
            {
                string path = Path.GetFullPath(Configuration.SevenZipPath);
                if (File.Exists(path))
                    return path;
                else
                    return Path.Combine(Shared.AppInstallationFolder, "7z\\7z.exe");
            }
        }

        public static readonly string[] SupportedFileTypes = new string[] {
            ".7z",
            ".zip",
            ".rar",
            ".tar",
            ".xz",
            ".gz",
            ".bz2"
        };

        public static void ExtractArchive(string sourceArchive, string destination)
        {
            if (!File.Exists(ExecPath))
                throw new FileNotFoundException("7z.exe could not be found.");

            if (!SupportedFileTypes.Contains(Path.GetExtension(sourceArchive).ToLower()))
                throw new NotSupportedException($"{Path.GetExtension(sourceArchive)} archives are not supported.");

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.FileName = ExecPath;
            proc.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", sourceArchive, destination);
            Process x = Process.Start(proc);
            x.WaitForExit();

            if (!Directory.Exists(destination) || Directory.EnumerateFileSystemEntries(destination).Count() == 0)
                throw new FileNotFoundException($"Something went wrong:\n{x.StandardOutput.ReadToEnd()}");
        }
    }
}
