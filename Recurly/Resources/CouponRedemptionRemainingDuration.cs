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
    public class CouponRedemptionRemainingDuration : Resource
    {

        /// <value>Present when `type` is `temporal`. The datetime after which this redemption will no longer apply.</value>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <value>The number of redemption periods remaining for which this coupon will still apply.</value>
        [JsonProperty("redemptions_remaining")]
        public int? RedemptionsRemaining { get; set; }

        /// <value>The coupon's duration type. `temporal` includes an `expires_at` timestamp. `billing_periods` includes a `redemptions_remaining` count of billing cycles. `forever` and `single_use` have no additional fields.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponDuration? Type { get; set; }

    }
}
