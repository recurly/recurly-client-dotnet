namespace Recurly
{
    /// <summary>
    /// The requested object is not defined in Recurly.
    /// </summary>
    public class NotFoundException : RecurlyException
    {
        internal NotFoundException(string message, Errors errors)
            : base(message, errors)
        { }
    }
}
