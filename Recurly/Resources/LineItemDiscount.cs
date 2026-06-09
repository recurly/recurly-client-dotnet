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
    public class LineItemDiscount : Resource
    {

        /// <value>The ID of the coupon that generated this discount.</value>
        [JsonProperty("coupon_id")]
        public string CouponId { get; set; }

        /// <value>The ID of the coupon redemption that generated this discount.</value>
        [JsonProperty("coupon_redemption_id")]
        public string CouponRedemptionId { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>The amount discounted on this line item by this coupon redemption.</value>
        [JsonProperty("discount_amount")]
        public decimal? DiscountAmount { get; set; }

        /// <value>Will always be `line_item_discount`.</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>The order in which this discount was applied when multiple coupons were redeemed.</value>
        [JsonProperty("order_applied")]
        public int? OrderApplied { get; set; }

    }
}
