using IniParser.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Ini
{
    public class IniParsingException : Exception
    {
        public int LineNumber;
        public string LineValue;
        public Version LibVersion;
        public string FilePath;
        public string FileName;

        public static IniParsingException CreateException(ParsingException originalException, string filePath)
        {
            // IniParser.Exceptions.ParsingException makes no sense (to me at least) because it displays stuff like this:
            // "Unknown file format. Couldn't parse the line: 'bMBEnable1'. while parsing line number 0 with value '' - IniParser version: 2.5.2.0 while parsing line number 31 with value 'bMBEnable1' - IniParser version: 2.5.2.0 while parsing line number 0 with value '' - IniParser version: 2.5.2.0"
            // Line Number 0, with value '', huh?
            // So let's just extract actually usable information from it and create a new exception:

            string fileName = Path.GetFileName(filePath);

            int LineNumber = -1;
            string LineValue = "";
            Version LibVersion = null;

            ParsingException innerExc = originalException;
            while (innerExc != null)
            {
                if (innerExc.LineNumber > 0 && innerExc.LineValue != "")
                {
                    LineNumber = innerExc.LineNumber;
                    LineValue = innerExc.LineValue;
                    LibVersion = innerExc.LibVersion;
                }
                try
                {
                    innerExc = (ParsingException)innerExc.InnerException;
                }
                catch
                {
                    break;
                }
            }

            string message = $"Couldn't parse line number {LineNumber}: '{LineValue}' in file '{fileName}'";


            IniParsingException newExc = new IniParsingException(message, originalException);

            newExc.LineNumber = LineNumber;
            newExc.LineValue = LineValue;
            newExc.LibVersion = LibVersion;

            newExc.FilePath = filePath;
            newExc.FileName = fileName;

            return newExc;
        }

        public IniParsingException() { }
        public IniParsingException(string message) : base(message) { }
        public IniParsingException(string message, Exception inner) : base(message, inner) { }
    }
}
