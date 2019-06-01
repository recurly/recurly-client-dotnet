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
    public class BillingInfoUpdatedBy : Resource
    {

        /// <value>Country of IP address, if known by Recurly.</value>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <value>Customer's IP address when updating their billing information.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }

    }
}
