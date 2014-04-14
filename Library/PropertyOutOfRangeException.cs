namespace Recurly
{
    public class PropertyOutOfRangeException : RecurlyException
    {
        public string PropertyName { get; protected set; }

        internal PropertyOutOfRangeException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
