using System;

namespace Recurly
{
    public class RecurlyError : Exception
    {
        public RecurlyError() { }
        public RecurlyError(string message) : base(message) { }
        public RecurlyError(string message, Exception inner) : base(message, inner) { }
    }
}
