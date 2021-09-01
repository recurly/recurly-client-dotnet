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
    public class DunningCampaignsBulkUpdate : Request
    {

        /// <value>List of `plan_codes` associated with the Plans for which the dunning campaign should be updated. Required unless `plan_ids` is present.</value>
        [JsonProperty("plan_codes")]
        public List<string> PlanCodes { get; set; }

        /// <value>List of `plan_ids` associated with the Plans for which the dunning campaign should be updated. Required unless `plan_codes` is present.</value>
        [JsonProperty("plan_ids")]
        public List<string> PlanIds { get; set; }

    }
}
