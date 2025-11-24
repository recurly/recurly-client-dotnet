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
    public class ReferenceOnlyCurrencyConversion : Resource
    {

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>The date of the conversion rate.</value>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <value>The conversion rate to the currency.</value>
        [JsonProperty("rate")]
        public string Rate { get; set; }

        /// <value>The source of the conversion rate.</value>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <value>The subtotal converted to the currency.</value>
        [JsonProperty("subtotal_in_cents")]
        public decimal? SubtotalInCents { get; set; }

        /// <value>The tax converted to the currency.</value>
        [JsonProperty("tax_in_cents")]
        public decimal? TaxInCents { get; set; }

    }
}
