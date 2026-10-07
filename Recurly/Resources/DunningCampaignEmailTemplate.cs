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
    public class DunningCampaignEmailTemplate : Resource
    {

        /// <value>The id to assign under `intervals[].email_template_id`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Template name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>The root template this custom template replaces, e.g. `payment_declined`, `invoice_past_due`, `post_trial_payment_declined`, `subscription_canceled_nonpayment`.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
