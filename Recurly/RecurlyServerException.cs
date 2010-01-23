using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// An Internal Server Error occurred on Recurly's side.
    /// </summary>
    public class RecurlyServerException : System.Net.WebException
    {
        public RecurlyServerException(string message, System.Net.WebException innerException)
            : base(message, innerException)
        { }
    }
}
