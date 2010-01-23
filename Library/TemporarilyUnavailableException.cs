using System;
using System.Text;

namespace Recurly
{
    public class TemporarilyUnavailableException : RecurlyServerException
    {
        internal TemporarilyUnavailableException()
            : base("Recurly is temporarily unavailable. Please try again.")
        { }
    }
}
