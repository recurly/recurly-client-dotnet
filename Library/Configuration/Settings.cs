using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;
using Microsoft.Win32;

[assembly: InternalsVisibleTo("Recurly.Test")]

namespace Recurly.Configuration
{
    internal class Settings
    {
        // non-static, as these change per instance, likely
        public string ApiKey
        {
            get
            {
                if (_hasLoaded == false)
                {
                    throw new Exception("The Recurly client has has no configuration initialized, please add your settings to web/app.config or call Recurly.Configuration.SettingsManager.Initialize(args)");
                }
                return _apiKey;
            }
            private set { _apiKey = value; }
        }

        public string PrivateKey
        {
            get
            {
                if (_hasLoaded == false)
                {
                    throw new Exception("The Recurly client has has no configuration initialized, please add your settings to web/app.config or call Recurly.Configuration.SettingsManager.Initialize(args)");
                }
                return _privateKey;
            }
            private set { _privateKey = value; }
        }

        public string Subdomain
        {
            get
            {
                if (_hasLoaded == false)
                {
                    throw new Exception("The Recurly client has has no configuration initialized, please add your settings to web/app.config or call Recurly.Configuration.SettingsManager.Initialize(args)");
                }
                return _subdomain;
            }
            private set { _subdomain = value; }
        }

        public int PageSize
        {
            get
            {
                if (_hasLoaded == false)
                {
                    throw new Exception("The Recurly client has has no configuration initialized, please add your settings to web/app.config or call Recurly.Configuration.SettingsManager.Initialize(args)");
                }
                return _pageSize;
            }
            private set { _pageSize = value; }
        }

        public int? RequestTimeoutMilliseconds
        {
            get
            {
                if (_hasLoaded == false)
                {
                    throw new Exception("The Recurly client has has no configuration initialized, please add your settings to web/app.config or call Recurly.Configuration.SettingsManager.Initialize(args)");
                }
                return _requestTimeoutMilliseconds;
            }
            private set { _requestTimeoutMilliseconds = value; }
        }

        protected const string RecurlyServerUri = "https://{0}.recurly.com/v2{1}";
        public const string RecurlyApiVersion = "2.26";
        public const string ValidDomain = ".recurly.com";

        // static, unlikely to change
        public string UserAgent
        {
            get
            {
                return GetUserAgent();
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
        private string _apiKey;
        private string _privateKey;
        private int _pageSize;
        private bool _hasLoaded;
        private string _subdomain;
        private int? _requestTimeoutMilliseconds;

        public static Settings Instance
        {
            get { return _instance ?? (_instance = new Settings()); }
        }


        public void InitializeFromConfig()
        {
            ApiKey = Section.Current.ApiKey;
            Subdomain = Section.Current.Subdomain;
            PrivateKey = Section.Current.PrivateKey;
            PageSize = Section.Current.PageSize;
            RequestTimeoutMilliseconds = Section.Current.TimeoutMilliseconds;
            _hasLoaded = true;
        }

        public void Initialize(string apiKey, string subdomain, string privateKey = "", int pageSize = 50, int? requestTimeoutMilliseconds = null)
        {
            ApiKey = apiKey;
            Subdomain = subdomain;
            PrivateKey = privateKey;
            PageSize = pageSize;
            RequestTimeoutMilliseconds = requestTimeoutMilliseconds;
            _hasLoaded = true;
        }

        public Settings()
        {
            _hasLoaded = false;
            try
            {
                // Will try and load the settings from the config file by default so not to break existing integrations.
                InitializeFromConfig();
            }
            catch
            {
                // We can't find the settings, silently fail.
                System.Diagnostics.Debug.WriteLine("Recurly is unable to load settings from web/app.config.");
            }
        }

        private string GetUserAgent()
        {
            var clientVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var recurlyString = $"Recurly C# Client v{clientVersion}";

            var osVersion = GetOSVersion();
            if (osVersion != null) recurlyString = $"{recurlyString}; {osVersion}";

            var oldVersion = GetOldFrameworkVersion();
            if (oldVersion != null) return $"{recurlyString}; {oldVersion}";

            var newVersion = Get45or451FromRegistry();
            if (newVersion != null) return $"{recurlyString}; {newVersion}";

            return recurlyString;
        }

        private string GetOSVersion()
        {
            try
            {
                var os = Environment.OSVersion;
                return os.VersionString;
            }
            catch
            {
                return null;
            }
        }

        // For .NET 1-4
        private static string GetOldFrameworkVersion()
        {
            try
            {
                RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                string[] version_names = installed_versions.GetSubKeyNames();
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1), CultureInfo.InvariantCulture);
                int SP = Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1]).GetValue("SP", 0));
                return $"Framework {Framework} SP {SP}";
            }
            catch
            {
                return null;
            }
        }

        // For .NET 4.5+
        private static string Get45or451FromRegistry()
        {
            try
            {
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\")) {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    string version = CheckFor45DotVersion(releaseKey);
                    return $"Framework {version}";
                }
            }
            catch
            {
                return null;
            }
        }

        // Checking the version using >= will enable forward compatibility,
        // however you should always compile your code on newer versions of
        // the framework to ensure your app works the same.
        private static string CheckFor45DotVersion(int releaseKey)
        {
            if (releaseKey >= 461808) {
                return "4.7.2 or later";
            }
            if (releaseKey >= 461308) {
                return "4.7.1 or later";
            }
            if (releaseKey >= 460798) {
                return "4.7 or later";
            }
            if (releaseKey >= 394802) {
                return "4.6.2 or later";
            }
            if (releaseKey >= 394254) {
                return "4.6.1 or later";
            }
            if (releaseKey >= 393295) {
                return "4.6 or later";
            }
            if (releaseKey >= 393273) {
                return "4.6 RC or later";
            }
            if ((releaseKey >= 379893)) {
                return "4.5.2 or later";
            }
            if ((releaseKey >= 378675)) {
                return "4.5.1 or later";
            }
            if ((releaseKey >= 378389)) {
                return "4.5 or later";
            }
            // This line should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
    }
}
