using System;

namespace Util.InnerException
{
    public class UpdateDBException : BaseInnerException
    {
        public UpdateDBException(String message) : base(message) { }

        public UpdateDBException(String message, Exception exception) : base(message, exception) { }
    }
}
