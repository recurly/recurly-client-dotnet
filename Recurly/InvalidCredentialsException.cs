using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// The API credentials for Recurly are invalid.
    /// </summary>
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException()
            : base()
        { }
    }
}
