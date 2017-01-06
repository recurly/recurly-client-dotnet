namespace Recurly
{
    /// <summary>
    /// The API credentials for Recurly are invalid.
    /// </summary>
    public class InvalidCredentialsException : RecurlyException
    {
        internal InvalidCredentialsException(Errors errors)
            : base("The API credentials for Recurly are invalid. Please check the credentials and try again.", errors)
        { }
    }
}
