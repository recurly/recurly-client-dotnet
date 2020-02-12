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
    public class CouponRedemptionMini : Resource
    {


        [JsonProperty("coupon")]
        public CouponMini Coupon { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
        [JsonProperty("discounted")]
        public decimal? Discounted { get; set; }

        /// <value>Coupon Redemption ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Will always be `coupon`.</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Invoice state</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ActiveState? State { get; set; }

    }
}
