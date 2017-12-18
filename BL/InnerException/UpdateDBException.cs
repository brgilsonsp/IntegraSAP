using System;

namespace BL.InnerException
{
    public class UpdateDBException : BaseInnerException
    {
        public UpdateDBException(String message) : base(message) { }

        public UpdateDBException(String message, Exception exception) : base(message, exception) { }
    }
}
