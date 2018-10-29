namespace Recurly
{
    /// <summary>
    /// The requested object is not defined in Recurly.
    /// </summary>
    public class NotFoundException : RecurlyException
    {
        public NotFoundException() { }

        internal NotFoundException(string message, Errors errors)
            : base(message, errors)
        { }
    }
}
