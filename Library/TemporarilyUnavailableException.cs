namespace Recurly
{
    public class TemporarilyUnavailableException : ServerException
    {
        public TemporarilyUnavailableException()
            : base("Recurly is temporarily unavailable. Please try again.")
        { }
    }
}
