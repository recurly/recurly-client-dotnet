using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    public class ValidationException : ApplicationException
    {
        internal const int HttpStatusCode = 422; // Unprocessable Entity

        public ValidationException()
            : base()
        { }

        public ValidationException(string message)
            : base(message)
        { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
