using System;

namespace BL.InnerException
{
    public class SelectDBException : BaseInnerException
    {
        public SelectDBException(string message) : base(message) { }

        public SelectDBException(string message, Exception exception) : base(message, exception) { }
    }
}
