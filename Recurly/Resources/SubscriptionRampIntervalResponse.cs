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
    public class SubscriptionRampIntervalResponse : Resource
    {

        /// <value>Represents how many billing cycles are left in a ramp interval.</value>
        [JsonProperty("remaining_billing_cycles")]
        public int? RemainingBillingCycles { get; set; }

        /// <value>Represents the billing cycle where a ramp interval starts.</value>
        [JsonProperty("starting_billing_cycle")]
        public int? StartingBillingCycle { get; set; }

        /// <value>Represents the price for the ramp interval.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

    }
}
