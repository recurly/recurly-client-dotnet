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
    public class ExternalPaymentPhaseBase : Request
    {

        /// <value>Allows up to 9 decimal places</value>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Ending Billing Period Index</value>
        [JsonProperty("ending_billing_period_index")]
        public int? EndingBillingPeriodIndex { get; set; }

        /// <value>Ends At</value>
        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

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

    }
}
