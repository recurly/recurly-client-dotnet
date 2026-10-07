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
    public class DunningCampaignUpdate : Request
    {

        /// <value>Campaign code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Set to `true` to make this the default campaign for accounts or plans without an assigned dunning campaign. Cannot be set on an inactive campaign, and cannot be unset directly—assign a different campaign as the default instead.</value>
        [JsonProperty("default_campaign")]
        public bool? DefaultCampaign { get; set; }

        /// <value>Campaign description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Dunning Cycle settings. One entry per collection method (`automatic`, `manual`, `trial`); each type may appear at most once. Each cycle write fully replaces that cycle's current settings version.</value>
        [JsonProperty("dunning_cycles")]
        public List<DunningCycleCreate> DunningCycles { get; set; }

        /// <value>Campaign name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
