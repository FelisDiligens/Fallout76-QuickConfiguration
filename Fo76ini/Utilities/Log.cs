using System;
using System.IO;

namespace Fo76ini.Utilities
{
    public static class Log
    {
        public static StreamWriter Open(string path)
        {
            if (File.Exists(path))
                return File.AppendText(path);
            else
                return File.CreateText(path);
        }

        public static string GetTimeStamp()
        {
            return $"{ DateTime.Now.ToLongDateString()}, { DateTime.Now.ToLongTimeString()}";
        }

        public static string GetFilePath(string fileName)
        {
            return Path.Combine(Shared.AppConfigFolder, fileName);
        }
    }
}
