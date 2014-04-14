using System;

namespace Recurly
{
    /// <summary>
    /// Base class for exceptions thrown by Recurly's API.
    /// </summary>
    public class RecurlyException : System.Exception
    {
        /// <summary>
        /// Error details from Recurly
        /// </summary>
        public Error[] Errors { get; private set; }

        internal RecurlyException(Error[] errors)
        {
            Errors = errors;
        }

        internal RecurlyException(string message)
            : base(message)
        { }

        internal RecurlyException(string message, RecurlyException innerException)
            : base(message, innerException)
        { }

        internal RecurlyException(string message, Error[] errors)
            : base(message)
        {
            Errors = errors;
        }
    }
}
