using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Recurly.Test")]

namespace Recurly.Configuration
{
    internal class Settings
    {
        // non-static, as these change per instance, likely
        public string ApiKey { get; private set; }
        public string PrivateKey { get; private set; }
        public string Subdomain { get; private set; }
        public int PageSize { get; private set; }

        protected const string RecurlyServerUri = "https://{0}.recurly.com/v2{1}";

        // static, unlikely to change
        public string UserAgent
        {
            get
            {
                return "Recurly C# Client v" + Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        public string AuthorizationHeaderValue
        {
            get
            {
                if (!ApiKey.IsNullOrEmpty())
                    return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey));
                return string.Empty;
            }
        }

        public string GetServerUri(string givenPath)
        {
            if (givenPath.Contains("://"))
                return givenPath;

            return string.Format(RecurlyServerUri, Subdomain, givenPath);
        }

        private static Settings _instance;

        public static Settings Instance
        {
            get { return _instance ?? (_instance = new Settings()); }
        }

        private Settings()
        {
            ApiKey = Section.Current.ApiKey;
            Subdomain = Section.Current.Subdomain;
            PrivateKey = Section.Current.PrivateKey;
            PageSize = Section.Current.PageSize;
        }

        internal Settings(string apiKey, string subdomain, string privateKey, int pageSize)
        {
            ApiKey = apiKey;
            Subdomain = subdomain;
            PrivateKey = privateKey;
            PageSize = pageSize;
        }
    }
}
