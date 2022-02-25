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
    public class PercentageTier : Resource
    {

        /// <value>Ending amount for the tier. Allows up to 2 decimal places. The last tier ending_amount is null.</value>
        [JsonProperty("ending_amount")]
        public decimal? EndingAmount { get; set; }

        /// <value>Decimal usage percentage.</value>
        [JsonProperty("usage_percentage")]
        public string UsagePercentage { get; set; }

    }
}
