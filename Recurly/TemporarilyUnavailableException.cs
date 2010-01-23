using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    public class TemporarilyUnavailableException : RecurlyServerException
    {
        public TemporarilyUnavailableException(string message, System.Net.WebException innerException)
            : base(message, innerException)
        { }
    }
}
