using System;

namespace Recurly {
    public class ApiError : Exception {
        public ApiError(string message) : base(message) {}

        public ApiError(string message, Exception inner) : base(message, inner)
        {
        }
    }
}