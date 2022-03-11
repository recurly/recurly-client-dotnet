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

        /// <value>Allows up to 2 decimal places. Optionally, override the tiers' default unit amount.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

        /// <value>
        /// Allows up to 9 decimal places.  Optionally, override tiers' default unit amount.
        /// If `unit_amount_decimal` is provided, `unit_amount` cannot be provided.
        /// </value>
        [JsonProperty("unit_amount_decimal")]
        public string UnitAmountDecimal { get; set; }

    }
}
