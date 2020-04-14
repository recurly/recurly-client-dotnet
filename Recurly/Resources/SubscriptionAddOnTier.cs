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
    public class SubscriptionAddOnTier : Request
    {

        /// <value>Ending quantity</value>
        [JsonProperty("ending_quantity")]
        public int? EndingQuantity { get; set; }

        /// <value>Unit amount</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

    }
}
