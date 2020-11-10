using System;
using System.IO;

namespace Fo76ini.Utilities
{
    public class Log
    {
        private string path;

        public Log(string path)
        {
            this.path = Path.GetFullPath(path);
        }

        private StreamWriter Open()
        {
            if (File.Exists(this.path))
                return File.AppendText(this.path);
            else
                return File.CreateText(this.path);
        }

        public void Write<T>(T line)
        {
            using (StreamWriter sw = Open())
                sw.Write(line);
        }

        public void WriteLine<T>(T line)
        {
            using (StreamWriter sw = Open())
                sw.WriteLine(line);
        }

        public void WriteFormat(string line, params string[] values)
        {
            using (StreamWriter sw = Open())
                sw.Write(string.Format(line, values));
        }

        public void WriteLineFormat(string line, params string[] values)
        {
            using (StreamWriter sw = Open())
                sw.WriteLine(string.Format(line, values));
        }

        public void WriteTimeStamp(string suffix = "")
        {
            using (StreamWriter sw = Open())
                sw.WriteLine($"{ DateTime.Now.ToLongDateString()}, { DateTime.Now.ToLongTimeString()} {suffix}");
        }

        public string GetFilePath()
        {
            return path;
        }

        public static string GetFilePath(string fileName)
        {
            // return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration", fileName);
            return Path.Combine(Shared.AppConfigFolder, fileName);
        }
    }
}
