using System;
using System.Runtime.Serialization;

namespace Fo76ini.Interface
{
    [Serializable]
    internal class InvalidXmlException : Exception
    {
        public InvalidXmlException()
        {
        }

        public InvalidXmlException(string message) : base(message)
        {
        }

        public InvalidXmlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidXmlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}