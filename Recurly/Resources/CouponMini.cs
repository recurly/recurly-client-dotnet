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
    public class CouponMini : Resource
    {

        /// <value>The code the customer enters to redeem the coupon.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Whether the coupon is "single_code" or "bulk". Bulk coupons will require a `unique_code_template` and will generate unique codes through the `/generate` endpoint.</value>
        [JsonProperty("coupon_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponType? CouponType { get; set; }

        /// <value>
        /// Details of the discount a coupon applies. Will contain a `type`
        /// property and one of the following properties: `percent`, `fixed`, `trial`.
        /// </value>
        [JsonProperty("discount")]
        public CouponDiscount Discount { get; set; }

        /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
        [JsonProperty("expired_at")]
        public DateTime? ExpiredAt { get; set; }

        /// <value>Coupon ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>The internal name for the coupon.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Indicates if the coupon is redeemable, and if it is not, why.</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponState? State { get; set; }

    }
}
