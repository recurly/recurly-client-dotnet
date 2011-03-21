using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Recurly.Configuration
{
    /// <summary>
    /// Defines username, password, and subdomain properties for web.config/app.config files.
    /// </summary>
    public class RecurlySection : ConfigurationSection
    {
        public static RecurlySection Current
        {
            get { return (RecurlySection)ConfigurationManager.GetSection("recurly"); }
        }

        #region Properties
        
        /// <summary>
        /// API Username
        /// </summary>
        [ConfigurationProperty("username", IsRequired=true)]
        public string Username
        {
            get { return (string)base["username"]; }
            set { base["username"] = value; }
        }

        /// <summary>
        /// API Password
        /// </summary>
        [ConfigurationProperty("password", IsRequired=true)]
        //[StringValidator(MinLength=32, MaxLength=32)]
        public string Password
        {
            get { return (string)base["password"]; }
            set { base["password"] = value; }
        }

        /// <summary>
        /// API Private Key for Transparent Post API
        /// </summary>
        [ConfigurationProperty("private_key", IsRequired=false)]
        //[StringValidator(MinLength=32, MaxLength=32)]
        public string PrivateKey
        {
            get { return (string)base["private_key"]; }
            set { base["private_key"] = value; }
        }

        /// <summary>
        /// Recurly Subdomain
        /// </summary>
        [ConfigurationProperty("subdomain", IsRequired=true)]
        public string Subdomain
        {
            get { return (string)base["subdomain"]; }
            set { base["subdomain"] = value; }
        }

        /// <summary>
        /// Recurly account type
        /// </summary>
        public enum EnvironmentType
        {
            /// <summary>
            /// Production Recurly account for live transactions
            /// </summary>
            Production,
            /// <summary>
            /// Sandbox Recurly account for test transctions
            /// </summary>
            Sandbox,
            /// <summary>
            /// Local development by Recurly developers
            /// </summary>
            Development
        }

        /// <summary>
        /// Recurly environment. Use "Production" for live transactions and "Sandbox" for testing transactions.
        /// </summary>
        [ConfigurationProperty("environment", DefaultValue=EnvironmentType.Production, IsRequired=false)]
        public EnvironmentType Environment
        {
            get { return (EnvironmentType)base["environment"]; }
            set { base["environment"] = value; }
        }

        #endregion
    }
}
