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
    public class GiftCardCreate : Request
    {

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>The delivery details for the gift card.</value>
        [JsonProperty("delivery")]
        public GiftCardDeliveryCreate Delivery { get; set; }

        /// <value>Block of account details for the gifter. This references an existing account_code.</value>
        [JsonProperty("gifter_account")]
        public AccountPurchase GifterAccount { get; set; }

        /// <value>The product code or SKU of the gift card product.</value>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <value>The amount of the gift card, which is the amount of the charge to the gifter account and the amount of credit that is applied to the recipient account upon successful redemption.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

    }
}
