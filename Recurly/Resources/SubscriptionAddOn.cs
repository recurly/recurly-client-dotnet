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
    public class SubscriptionAddOn : Resource
    {

        /// <value>Just the important parts.</value>
        [JsonProperty("add_on")]
        public AddOnMini AddOn { get; set; }

        /// <value>
        /// Used to determine where the associated add-on data is pulled from. If this value is set to
        /// `plan_add_on` or left blank, then add-on data will be pulled from the plan's add-ons. If the associated
        /// `plan` has `allow_any_item_on_subscriptions` set to `true` and this field is set to `item`, then
        /// the associated add-on data will be pulled from the site's item catalog.
        /// </value>
        [JsonProperty("add_on_source")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.AddOnSource? AddOnSource { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Expired at</value>
        [JsonProperty("expired_at")]
        public DateTime? ExpiredAt { get; set; }

        /// <value>Subscription Add-on ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Add-on quantity</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Subscription ID</value>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <value>
        /// The pricing model for the add-on.  For more information,
        /// [click here](https://docs.recurly.com/docs/billing-models#section-quantity-based). See our
        /// [Guide](https://developers.recurly.com/guides/item-addon-guide.html) for an overview of how
        /// to configure quantity-based pricing models.
        /// </value>
        [JsonProperty("tier_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.TierType? TierType { get; set; }

        /// <value>
        /// If tiers are provided in the request, all existing tiers on the Subscription Add-on will be
        /// removed and replaced by the tiers in the request.
        /// </value>
        [JsonProperty("tiers")]
        public List<SubscriptionAddOnTier> Tiers { get; set; }

        /// <value>Supports up to 2 decimal places.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

        /// <value>Supports up to 9 decimal places.</value>
        [JsonProperty("unit_amount_decimal")]
        public string UnitAmountDecimal { get; set; }

        /// <value>Updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>The percentage taken of the monetary amount of usage tracked. This can be up to 4 decimal places. A value between 0.0 and 100.0. Required if add_on_type is usage and usage_type is percentage.</value>
        [JsonProperty("usage_percentage")]
        public decimal? UsagePercentage { get; set; }

    }
}
