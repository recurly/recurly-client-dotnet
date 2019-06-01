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
    public class LineItemRefund : Request
    {

        /// <value>Line item ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>
        /// Set to `true` if the line item should be prorated; set to `false` if not.
        /// This can only be used on line items that have a start and end date.
        /// </value>
        [JsonProperty("prorate")]
        public bool? Prorate { get; set; }

        /// <value>Line item quantity to be refunded.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

    }
}
