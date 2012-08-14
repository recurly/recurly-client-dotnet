using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// The requested object is not defined in Recurly.
    /// </summary>
    public class NotFoundException : Exception
    {
        internal NotFoundException(string message, Error[] errors)
            : base(message, errors)
        { }
    }
}
