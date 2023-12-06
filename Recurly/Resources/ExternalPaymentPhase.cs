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
    public class ExternalPaymentPhase : Resource
    {

        /// <value>Allows up to 9 decimal places</value>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <value>When the external subscription was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Ending Billing Period Index</value>
        [JsonProperty("ending_billing_period_index")]
        public int? EndingBillingPeriodIndex { get; set; }

        /// <value>Ends At</value>
        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

        /// <value>Subscription from an external resource such as Apple App Store or Google Play Store.</value>
        [JsonProperty("external_subscription")]
        public ExternalSubscription ExternalSubscription { get; set; }

        /// <value>System-generated unique identifier for an external payment phase ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Name of the discount offer given, e.g. "introductory"</value>
        [JsonProperty("offer_name")]
        public string OfferName { get; set; }

        /// <value>Type of discount offer given, e.g. "FREE_TRIAL"</value>
        [JsonProperty("offer_type")]
        public string OfferType { get; set; }

        /// <value>Number of billing periods</value>
        [JsonProperty("period_count")]
        public int? PeriodCount { get; set; }

        /// <value>Billing cycle length</value>
        [JsonProperty("period_length")]
        public string PeriodLength { get; set; }

        /// <value>Started At</value>
        [JsonProperty("started_at")]
        public DateTime? StartedAt { get; set; }

        /// <value>Starting Billing Period Index</value>
        [JsonProperty("starting_billing_period_index")]
        public int? StartingBillingPeriodIndex { get; set; }

        /// <value>When the external subscription was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
