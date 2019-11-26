using System;
using Newtonsoft.Json;

namespace Recurly.Errors
{
    public class ApiError : RecurlyError
    {
        public Recurly.Resources.ErrorMayHaveTransaction Error { get; set; }

        public ApiError() { }
        public ApiError(string message) : base(message) { }
        public ApiError(string message, Exception inner) : base(message, inner) { }
    }

    public class ApiErrorWrapper
    {
        public Recurly.Resources.ErrorMayHaveTransaction Error { get; set; }
    }
}
