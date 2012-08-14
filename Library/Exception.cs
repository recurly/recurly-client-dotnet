using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// Base class for exceptions thrown by Recurly's API.
    /// </summary>
    public class Exception : ApplicationException
    {
        /// <summary>
        /// Error details from Recurly
        /// </summary>
        public Error[] Errors { get; private set; }

        internal Exception(Error[] errors)
            : base()
        {
            this.Errors = errors;
        }

        internal Exception(string message)
            : base(message)
        { }

        internal Exception(string message, Exception innerException)
            : base(message, innerException)
        { }

        internal Exception(string message, Error[] errors)
            : base(message)
        {
            this.Errors = errors;
        }
    }
}
