using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini_Updater
{
    public class Utils
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

        // https://stackoverflow.com/a/250400
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
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
    }
}
