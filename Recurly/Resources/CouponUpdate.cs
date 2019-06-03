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
    public class CouponUpdate : Request
    {

        /// <value>This description will show up when a customer redeems a coupon on your Hosted Payment Pages, or if you choose to show the description on your own checkout page.</value>
        [JsonProperty("hosted_description")]
        public string HostedDescription { get; set; }

        /// <value>Description of the coupon on the invoice.</value>
        [JsonProperty("invoice_description")]
        public string InvoiceDescription { get; set; }

        /// <value>A maximum number of redemptions for the coupon. The coupon will expire when it hits its maximum redemptions.</value>
        [JsonProperty("max_redemptions")]
        public int? MaxRedemptions { get; set; }

        /// <value>Redemptions per account is the number of times a specific account can redeem the coupon. Set redemptions per account to `1` if you want to keep customers from gaming the system and getting more than one discount from the coupon campaign.</value>
        [JsonProperty("max_redemptions_per_account")]
        public int? MaxRedemptionsPerAccount { get; set; }

        /// <value>The internal name for the coupon.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>The date and time the coupon will expire and can no longer be redeemed. Time is always 11:59:59, the end-of-day Pacific time.</value>
        [JsonProperty("redeem_by_date")]
        public string RedeemByDate { get; set; }

    }
}
