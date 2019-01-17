using System;

namespace Recurly
{
    /// <summary>
    /// Base class for exceptions thrown by Recurly's API.
    /// </summary>
    public class RecurlyException : System.Exception
    {
        /// <summary>
        /// Error details from Recurly
        /// </summary>
        public Error[] Errors { get; private set; }

        /// <summary>
        /// A transaction error (if there is one present)
        /// </summary>
        public TransactionError TransactionError { get; private set; }

        public RecurlyException() { }

        internal RecurlyException(Errors errors)
        {
            Errors = errors.ValidationErrors;
            TransactionError = errors.TransactionError;
        }

        internal RecurlyException(Error[] errors)
        {
            Errors = errors;
        }

        public RecurlyException(string message)
            : base(message)
        { }

        internal RecurlyException(string message, RecurlyException innerException)
            : base(message, innerException)
        { }

        internal RecurlyException(string message, Errors errors)
            : base(message)
        {
            Errors = errors.ValidationErrors;
            TransactionError = errors.TransactionError;
        }

        internal RecurlyException(string message, Error[] errors)
            : base(message)
        {
            Errors = errors;
        }

        public override string ToString()
        {
            var details = "";
            foreach (Error e in Errors)
                details += e.ToString() + "\n";
            if (TransactionError != null)
                details += TransactionError.ToString() + "\n";
            return string.Format("{0} {1}", details, base.ToString());
        }
    }
}
