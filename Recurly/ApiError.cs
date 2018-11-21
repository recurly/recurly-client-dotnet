using System;
using Newtonsoft.Json;

namespace Recurly {

    public class ApiError : Exception {
        public Recurly.Resources.Error Error { get; set; }

        public ApiError()
        {
        }

        public ApiError(string message) : base(message)
        {
        }

        public ApiError(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class ApiErrorWrapper {
        public Recurly.Resources.Error Error { get; set; }
    }
}
