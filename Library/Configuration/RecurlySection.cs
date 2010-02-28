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
        /// Recurly Subdomain
        /// </summary>
        [ConfigurationProperty("subdomain", IsRequired=true)]
        public string Subdomain
        {
            get { return (string)base["subdomain"]; }
            set { base["subdomain"] = value; }
        }

        #endregion
    }
}
