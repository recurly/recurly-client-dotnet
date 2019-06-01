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
    public class PlanHostedPages : Request
    {

        /// <value>If `true`, the customer will be sent directly to your `success_url` after a successful signup, bypassing Recurly's hosted confirmation page.</value>
        [JsonProperty("bypass_confirmation")]
        public bool? BypassConfirmation { get; set; }

        /// <value>URL to redirect to on canceled signup on the hosted payment pages.</value>
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }

        /// <value>Determines if the quantity field is displayed on the hosted pages for the plan.</value>
        [JsonProperty("display_quantity")]
        public bool? DisplayQuantity { get; set; }

        /// <value>URL to redirect to after signup on the hosted payment pages.</value>
        [JsonProperty("success_url")]
        public string SuccessUrl { get; set; }

    }
}
