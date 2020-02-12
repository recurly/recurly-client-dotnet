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
    public class SubscriptionShipping : Resource
    {


        [JsonProperty("address")]
        public ShippingAddress Address { get; set; }

        /// <value>Subscription's shipping cost</value>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }


        [JsonProperty("method")]
        public ShippingMethodMini Method { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
