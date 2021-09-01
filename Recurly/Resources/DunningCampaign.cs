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
    public class DunningCampaign : Resource
    {

        /// <value>Campaign code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>When the current campaign was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Whether or not this is the default campaign for accounts or plans without an assigned dunning campaign.</value>
        [JsonProperty("default_campaign")]
        public bool? DefaultCampaign { get; set; }

        /// <value>When the current campaign was deleted in Recurly.</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>Campaign description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Dunning Cycle settings.</value>
        [JsonProperty("dunning_cycles")]
        public List<DunningCycle> DunningCycles { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Campaign name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>When the current campaign was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
