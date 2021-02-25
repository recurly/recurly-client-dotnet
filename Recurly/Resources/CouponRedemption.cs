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
    public class CouponRedemption : Resource
    {

        /// <value>The Account on which the coupon was applied.</value>
        [JsonProperty("account")]
        public AccountMini Account { get; set; }


        [JsonProperty("coupon")]
        public Coupon Coupon { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
        [JsonProperty("discounted")]
        public decimal? Discounted { get; set; }

        /// <value>Coupon Redemption ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Will always be `coupon`.</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>The date and time the redemption was removed from the account (un-redeemed).</value>
        [JsonProperty("removed_at")]
        public DateTime? RemovedAt { get; set; }

        /// <value>Coupon Redemption state</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ActiveState? State { get; set; }

        /// <value>Subscription ID</value>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
