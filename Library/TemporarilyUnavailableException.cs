namespace Recurly
{
    public class TemporarilyUnavailableException : ServerException
    {
        internal TemporarilyUnavailableException()
            : base("Recurly is temporarily unavailable. Please try again.")
        { }
    }
}
