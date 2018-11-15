using System;

namespace Recurly {
    public class RecurlyError : Exception
    {
        public ApiError Error { get; set; }

        public RecurlyError()  {}

        public RecurlyError(string message, ApiError error) : base(message) {
            Error = error;
            message = Error.Message;
        }

        public RecurlyError(string message) : base(message) { }
        public RecurlyError(string message, Exception inner) : base(message, inner) { }
        protected RecurlyError(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}