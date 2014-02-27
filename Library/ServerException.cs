namespace Recurly
{
    /// <summary>
    /// An Internal Server Error occurred on Recurly's side.
    /// </summary>
    public class ServerException : Exception
    {
        internal ServerException(Error[] errors)
            : base("Recurly experienced an internal server error.", errors)
        { }

        internal ServerException(string message)
            : base(message)
        { }
    }
}
