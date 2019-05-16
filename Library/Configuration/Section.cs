using System.Configuration;

namespace Recurly.Configuration
{
    /// <summary>
    /// Defines apiKey, privateKey, and subdomain properties for web.config/app.config files.
    /// </summary>
    public class Section : ConfigurationSection
    {
        public static Section Current
        {
            get { return (Section)ConfigurationManager.GetSection("recurly"); }
        }

        #region Properties

        /// <summary>
        /// API Key
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = true)]
        //[StringValidator(MinLength=32, MaxLength=32)]
        public string ApiKey
        {
            get { return (string)base["apiKey"]; }
            set { base["apiKey"] = value; }
        }

        /// <summary>
        /// API Private Key for Recurly.js and Transparent Post API
        /// </summary>
        [ConfigurationProperty("privateKey", IsRequired = false)]
        //[StringValidator(MinLength=32, MaxLength=32)]
        public string PrivateKey
        {
            get { return (string)base["privateKey"]; }
            set { base["privateKey"] = value; }
        }

        /// <summary>
        /// Recurly Subdomain
        /// </summary>
        [ConfigurationProperty("subdomain", IsRequired = true)]
        public string Subdomain
        {
            get { return (string)base["subdomain"]; }
            set { base["subdomain"] = value; }
        }

        /// <summary>
        /// Default Page Size or limit to the number of results returned at a time
        /// </summary>
        [ConfigurationProperty("pageSize", IsRequired = false, DefaultValue=200)]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }

        /// <summary>
        /// Default request timeout
        /// </summary>
        [ConfigurationProperty("timeoutMilliseconds", IsRequired = false, DefaultValue=null)]
        public int? TimeoutMilliseconds
        {
            get { return (int)base["requestTimeoutMilliseconds"]; }
            set { base["requestTimeoutMilliseconds"] = value; }
        }
      
        #endregion
    }
}
