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
    public class SubscriptionAddOnCreate : Request
    {

        /// <value>
        /// Used to determine where the associated add-on data is pulled from. If this value is set to
        /// `plan_add_on` or left blank, then add-on data will be pulled from the plan's add-ons. If the associated
        /// `plan` has `allow_any_item_on_subscriptions` set to `true` and this field is set to `item`, then
        /// the associated add-on data will be pulled from the site's item catalog.
        /// </value>
        [JsonProperty("add_on_source")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.AddOnSource? AddOnSource { get; set; }

        /// <value>
        /// If `add_on_source` is set to `plan_add_on` or left blank, then plan's add-on `code` should be used.
        /// If `add_on_source` is set to `item`, then the `code` from the associated item should be used.
        /// </value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Quantity</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>
        /// If the plan add-on's `tier_type` is `flat`, then `tiers` must be absent. The `tiers` object
        /// must include one to many tiers with `ending_quantity` and `unit_amount`.
        /// There must be one tier with an `ending_quantity` of 999999999 which is the
        /// default if not provided. See our [Guide](https://developers.recurly.com/guides/item-addon-guide.html)
        /// for an overview of how to configure quantity-based pricing models.
        /// </value>
        [JsonProperty("tiers")]
        public List<SubscriptionAddOnTier> Tiers { get; set; }

        /// <value>
        /// Allows up to 2 decimal places. Optionally, override the add-on's default unit amount.
        /// If the plan add-on's `tier_type` is `tiered`, `volume`, or `stairstep`, then `unit_amount` cannot be provided.
        /// </value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

        /// <value>
        /// Allows up to 9 decimal places.  Optionally, override the add-on's default unit amount.
        /// If the plan add-on's `tier_type` is `tiered`, `volume`, or `stairstep`, then `unit_amount_decimal` cannot be provided.
        /// Only supported when the plan add-on's `add_on_type` = `usage`.
        /// If `unit_amount_decimal` is provided, `unit_amount` cannot be provided.
        /// </value>
        [JsonProperty("unit_amount_decimal")]
        public string UnitAmountDecimal { get; set; }

        /// <value>The percentage taken of the monetary amount of usage tracked. This can be up to 4 decimal places. A value between 0.0 and 100.0. Required if `add_on_type` is usage and `usage_type` is percentage. Must be omitted otherwise. `usage_percentage` does not support tiers. See our [Guide](https://developers.recurly.com/guides/usage-based-billing-guide.html) for an overview of how to configure usage add-ons.</value>
        [JsonProperty("usage_percentage")]
        public decimal? UsagePercentage { get; set; }

    }
}
