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
    public class ShippingPurchase : Request
    {


        [JsonProperty("address")]
        public ShippingAddressCreate Address { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses. If this and `address` are both present, `address` will take precedence.</value>
        [JsonProperty("address_id")]
        public string AddressId { get; set; }

        /// <value>A list of shipping fees to be created as charges with the purchase.</value>
        [JsonProperty("fees")]
        public List<ShippingFeeCreate> Fees { get; set; }

    }
}
