/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources
{
    [ExcludeFromCodeCoverage]
    public class ExternalAccount : Resource
    {

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Represents the account code for the external account.</value>
        [JsonProperty("external_account_code")]
        public string ExternalAccountCode { get; set; }

        /// <value>Represents the connection type. `AppleAppStore` or `GooglePlayStore`</value>
        [JsonProperty("external_connection_type")]
        public string ExternalConnectionType { get; set; }

        /// <value>UUID of the external_account .</value>
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
