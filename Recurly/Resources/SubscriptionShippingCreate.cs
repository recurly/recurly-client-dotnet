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
    public class SubscriptionShippingCreate : Request
    {


        [JsonProperty("address")]
        public ShippingAddressCreate Address { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses. If `address_id` and `address` are both present, `address` will be used.</value>
        [JsonProperty("address_id")]
        public string AddressId { get; set; }

        /// <value>Assigns the subscription's shipping cost. If this is greater than zero then a `method_id` or `method_code` is required.</value>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <value>The code of the shipping method used to deliver the subscription. If `method_id` and `method_code` are both present, `method_id` will be used.</value>
        [JsonProperty("method_code")]
        public string MethodCode { get; set; }

        /// <value>The id of the shipping method used to deliver the subscription. If `method_id` and `method_code` are both present, `method_id` will be used.</value>
        [JsonProperty("method_id")]
        public string MethodId { get; set; }

    }
}
