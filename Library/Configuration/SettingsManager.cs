namespace Recurly.Configuration
{
    public static class SettingsManager
    {
        public static void InitializeFromConfig()
        {
            Settings.Instance.InitializeFromConfig();
        }

        public static void Initialize(string apiKey, string subdomain, string privateKey = "", int pageSize = 200)
        {
            Settings.Instance.Initialize(apiKey, subdomain, privateKey, pageSize);
        }
    }
}