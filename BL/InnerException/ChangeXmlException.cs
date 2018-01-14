using System;

namespace BL.InnerException
{
    public class ChangeXmlException : Exception
    {
        public ChangeXmlException(string message) : base(message) { }

        public ChangeXmlException(string message, Exception ex) : base(message, ex) { }
    }
}
