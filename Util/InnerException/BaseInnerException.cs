using System;

namespace Util.InnerException
{
    public class BaseInnerException : Exception
    {
        public BaseInnerException(string message) : base(message) { }

        public BaseInnerException(string message, Exception ex) : base(message, ex) { }
    }
}
