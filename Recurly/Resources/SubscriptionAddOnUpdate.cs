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
    public class SubscriptionAddOnUpdate : Request
    {

        /// <value>Add-on code</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Set this to include or modify an existing subscription add-on.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Quantity</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        public string RevenueScheduleType { get; set; }

        /// <value>If the plan add-on's `tier_type` is `flat`, then `tiers` must be absent.</value>
        [JsonProperty("tiers")]
        public List<SubscriptionAddOnTier> Tiers { get; set; }

        /// <value>Optionally, override the add-on's default unit amount.</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

    }
}
