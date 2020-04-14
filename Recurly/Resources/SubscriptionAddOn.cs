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

        /// <value>Subscription ID</value>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <value>The type of tiering used by the Add-on.</value>
        [JsonProperty("tier_type")]
        public string TierType { get; set; }

        /// <value>Empty unless `tier_type` is `tiered`, `volume`, or `stairstep`.</value>
        [JsonProperty("tiers")]
        public List<SubscriptionAddOnTier> Tiers { get; set; }

        /// <value>This is priced in the subscription's currency.</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

        /// <value>Updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
