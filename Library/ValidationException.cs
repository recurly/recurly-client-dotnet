using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// Exception when a validation error prevents an object from being created, updated, or deleted.
    /// See the Errors collection for more information.
    /// </summary>
    public class ValidationException : RecurlyException
    {
        /// <summary>
        /// HTTP Status Code 422 is "Unprocessable Entity"
        /// </summary>
        internal const int HttpStatusCode = 422;

        internal ValidationException(RecurlyError[] errors)
            : base("The information being saved is not valid.", errors)
        { }

        internal ValidationException(string message, RecurlyError[] errors)
            : base(message, errors)
        { }
    }
}
