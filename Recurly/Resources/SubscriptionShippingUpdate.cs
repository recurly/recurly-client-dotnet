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
    public class SubscriptionShippingUpdate : Request
    {


        [JsonProperty("address")]
        public ShippingAddressCreate Address { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses.</value>
        [JsonProperty("address_id")]
        public string AddressId { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
