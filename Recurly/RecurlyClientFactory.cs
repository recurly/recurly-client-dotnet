namespace Recurly
{
    public class RecurlyClientFactory
    {
        public static IRecurlyClient Build(string apiKey, string siteId)
        {
            return (IRecurlyClient)new RecurlyClient(apiKey, siteId);
        }
    }
}