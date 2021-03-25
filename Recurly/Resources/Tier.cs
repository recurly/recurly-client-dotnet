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
    public class Tier : Request
    {

        /// <value>Tier pricing</value>
        [JsonProperty("currencies")]
        public List<TierPricing> Currencies { get; set; }

        /// <value>Ending quantity for the tier.  This represents a unit amount for unit-priced add ons, but for percentage type usage add ons, represents the site default currency in its minimum divisible unit.</value>
        [JsonProperty("ending_quantity")]
        public int? EndingQuantity { get; set; }

        /// <value>Decimal usage percentage.</value>
        [JsonProperty("usage_percentage")]
        public string UsagePercentage { get; set; }

    }
}
