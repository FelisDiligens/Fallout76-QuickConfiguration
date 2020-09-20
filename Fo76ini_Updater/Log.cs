using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini_Updater
{
    public class Log
    {
        public String Path;

        public Log(String path)
        {
            this.Path = System.IO.Path.GetFullPath(path);
        }

        private StreamWriter Open()
        {
            if (File.Exists(this.Path))
                return File.AppendText(this.Path);
            else
                return File.CreateText(this.Path);
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
            return System.IO.Path.Combine(Updater.AppConfigFolder, fileName);
        }
    }
}
