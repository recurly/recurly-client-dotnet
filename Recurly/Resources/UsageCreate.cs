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
    public class UsageCreate : Request
    {

        /// <value>The amount of usage. Can be positive, negative, or 0. No decimals allowed, we will strip them. If the usage-based add-on is billed with a percentage, your usage will be a monetary amount you will want to format in cents. (e.g., $5.00 is "500").</value>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <value>Custom field for recording the id in your own system associated with the usage, so you can provide auditable usage displays to your customers using a GET on this endpoint.</value>
        [JsonProperty("merchant_tag")]
        public string MerchantTag { get; set; }

        /// <value>When the usage was recorded in your system.</value>
        [JsonProperty("recording_timestamp")]
        public DateTime? RecordingTimestamp { get; set; }

        /// <value>When the usage actually happened. This will define the line item dates this usage is billed under and is important for revenue recognition.</value>
        [JsonProperty("usage_timestamp")]
        public DateTime? UsageTimestamp { get; set; }

    }
}
