using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini
{
    public class Log
    {
        private String path;

        public Log(String path)
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

        public void WriteFormat(String line, params String[] values)
        {
            using (StreamWriter sw = Open())
                sw.Write(String.Format(line, values));
        }

        public void WriteLineFormat(String line, params String[] values)
        {
            using (StreamWriter sw = Open())
                sw.WriteLine(String.Format(line, values));
        }

        public void WriteTimeStamp(String suffix = "")
        {
            using (StreamWriter sw = Open())
                sw.WriteLine($"{ DateTime.Now.ToLongDateString()}, { DateTime.Now.ToLongTimeString()} {suffix}");
        }

        public static String GetFilePath(String fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration", fileName);
        }
    }
}
