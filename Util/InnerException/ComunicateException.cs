using System;

namespace Util.InnerException
{
    public class ComunicateException : BaseInnerException
    {
        public ComunicateException(string message) : base(message) { }

        public ComunicateException(string message, Exception exception) : base(message, exception) { }
    }
}
