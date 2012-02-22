using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Recurly.Configuration
{
    public class RecurlyApplication : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name { get { return this["name"] as string; } }

        [ConfigurationProperty("apikey", IsRequired = true)]
        public string ApiKey { get { return this["apikey"] as string; } }

        [ConfigurationProperty("privatekey", IsRequired = true)]
        public string PrivateKey { get { return this["privatekey"] as string; } }

        [ConfigurationProperty("subdomain", IsRequired = true)]
        public string Subdomain { get { return this["subdomain"] as string; } }
    }
}
