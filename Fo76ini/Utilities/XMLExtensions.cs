using System.Xml;
using System.Xml.Linq;

namespace Fo76ini.Utilities
{
    public static class XMLExtensions
    {
        public static bool TryParseBool(this XElement element, out bool result)
        {
            try
            {
                result = XmlConvert.ToBoolean(element.Value);
                return true;
            }
            catch
            {
                result = false;
                return false;
            }
        }

        public static bool TryParseBool(this XAttribute element, out bool result)
        {
            try
            {
                result = XmlConvert.ToBoolean(element.Value);
                return true;
            }
            catch
            {
                result = false;
                return false;
            }
        }

        public static bool TryParseInt(this XAttribute element, out int result)
        {
            try
            {
                result = XmlConvert.ToInt32(element.Value);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }

        public static bool TryParseInt(this XElement element, out int result)
        {
            try
            {
                result = XmlConvert.ToInt32(element.Value);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }

        public static bool TryParseLong(this XAttribute element, out long result)
        {
            try
            {
                result = XmlConvert.ToInt64(element.Value);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }

        public static bool TryParseLong(this XElement element, out long result)
        {
            try
            {
                result = XmlConvert.ToInt64(element.Value);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }
}
