using System;

namespace BL.InnerException
{
    public class ConfigureXmlException : BaseInnerException
    {
        public ConfigureXmlException(string message) : base(message) { }

        public ConfigureXmlException(string message, Exception exception) : base(message, exception) { }
    }
}
