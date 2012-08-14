using System;
using System.Collections.Generic;
using System.Text;

namespace Recurly
{
    public class ForgedQueryStringException : RecurlyException
    {
        internal ForgedQueryStringException(string message)
            : base(message)
        { }
    }
}
