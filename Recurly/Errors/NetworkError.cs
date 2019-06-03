using System;
using System.Net;

namespace Recurly.Errors
{
    public class NetworkError : RecurlyError
    {
        public WebExceptionStatus ExceptionStatus { get; internal set; }

        public NetworkError() { }
        public NetworkError(string message) : base(message) { }
        public NetworkError(string message, Exception inner) : base(message, inner) { }
    }
}
