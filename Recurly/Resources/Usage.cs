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
    public class Usage : Resource
    {

        /// <value>The amount of usage. Can be positive, negative, or 0. If the Decimal Quantity feature is enabled, this value will be rounded to nine decimal places.  Otherwise, all digits after the decimal will be stripped. If the usage-based add-on is billed with a percentage, your usage should be a monetary amount formatted in cents (e.g., $5.00 is "500").</value>
        [JsonProperty("amount")]
        public float? Amount { get; set; }

        /// <value>When the usage record was billed on an invoice.</value>
        [JsonProperty("billed_at")]
        public DateTime? BilledAt { get; set; }

        /// <value>When the usage record was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>The ID of the measured unit associated with the add-on the usage record is for.</value>
        [JsonProperty("measured_unit_id")]
        public string MeasuredUnitId { get; set; }

        /// <value>Custom field for recording the id in your own system associated with the usage, so you can provide auditable usage displays to your customers using a GET on this endpoint.</value>
        [JsonProperty("merchant_tag")]
        public string MerchantTag { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>When the usage was recorded in your system.</value>
        [JsonProperty("recording_timestamp")]
        public DateTime? RecordingTimestamp { get; set; }

        /// <value>
        /// The pricing model for the add-on.  For more information,
        /// [click here](https://docs.recurly.com/docs/billing-models#section-quantity-based).
        /// </value>
        [JsonProperty("tier_type")]
        public string TierType { get; set; }

        /// <value>The tiers and prices of the subscription based on the usage_timestamp. If tier_type = flat, tiers = null</value>
        [JsonProperty("tiers")]
        public List<SubscriptionAddOnTier> Tiers { get; set; }

        /// <value>Unit price</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

        /// <value>When the usage record was billed on an invoice.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>The percentage taken of the monetary amount of usage tracked. This can be up to 4 decimal places. A value between 0.0 and 100.0.</value>
        [JsonProperty("usage_percentage")]
        public float? UsagePercentage { get; set; }

        /// <value>When the usage actually happened. This will define the line item dates this usage is billed under and is important for revenue recognition.</value>
        [JsonProperty("usage_timestamp")]
        public DateTime? UsageTimestamp { get; set; }

        /// <value>Type of usage, returns usage type if `add_on_type` is `usage`.</value>
        [JsonProperty("usage_type")]
        public string UsageType { get; set; }

    }
}
