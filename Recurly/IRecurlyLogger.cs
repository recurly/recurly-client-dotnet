namespace Recurly {
    public enum RecurlyLogLevel {
        Information,
        Debug,
    }

    internal class NullLogger : IRecurlyLogger
    {
        public void Log(RecurlyLogLevel level, string message, float? duration = null)
        {
            // Does nothing
        }
    }

    public interface IRecurlyLogger
    {
        void Log(RecurlyLogLevel level, string message, float? duration = null);
    }
}