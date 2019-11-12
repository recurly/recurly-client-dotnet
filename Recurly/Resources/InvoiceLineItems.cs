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
    public class InvoiceLineItems : Resource
    {

        /// <value>Previous credits applied to this invoice. See their `original_line_item_id` to determine where the credit first originated.</value>
        [JsonProperty("applied_credits")]
        public List<LineItem> AppliedCredits { get; set; }

        /// <value>These charges can be ignored. They exist to consume any remaining credit balance. A new credit with the same amount will be created and placed back on the account.</value>
        [JsonProperty("carryforwards")]
        public List<LineItem> Carryforwards { get; set; }

        /// <value>New charges being billed for on this invoice.</value>
        [JsonProperty("charges")]
        public List<LineItem> Charges { get; set; }

        /// <value>Refund or proration credits. This portion of the invoice can be considered a credit memo.</value>
        [JsonProperty("credits")]
        public List<LineItem> Credits { get; set; }

    }
}
