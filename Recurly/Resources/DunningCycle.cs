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
    public class DunningCycle : Resource
    {

        /// <value>Whether the dunning settings will be applied to manual trials. Only applies to trial cycles.</value>
        [JsonProperty("applies_to_manual_trial")]
        public bool? AppliesToManualTrial { get; set; }

        /// <value>When the current settings were created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Whether the subscription(s) should be cancelled at the end of the dunning cycle.</value>
        [JsonProperty("expire_subscription")]
        public bool? ExpireSubscription { get; set; }

        /// <value>Whether the invoice should be failed at the end of the dunning cycle.</value>
        [JsonProperty("fail_invoice")]
        public bool? FailInvoice { get; set; }

        /// <value>The number of days after a transaction failure before the first dunning email is sent.</value>
        [JsonProperty("first_communication_interval")]
        public int? FirstCommunicationInterval { get; set; }

        /// <value>Dunning intervals.</value>
        [JsonProperty("intervals")]
        public List<DunningInterval> Intervals { get; set; }

        /// <value>Whether or not to send an extra email immediately to customers whose initial payment attempt fails with either a hard decline or invalid billing info.</value>
        [JsonProperty("send_immediately_on_hard_decline")]
        public bool? SendImmediatelyOnHardDecline { get; set; }

        /// <value>The number of days between the first dunning email being sent and the end of the dunning cycle.</value>
        [JsonProperty("total_dunning_days")]
        public int? TotalDunningDays { get; set; }

        /// <value>The number of days between a transaction failure and the end of the dunning cycle.</value>
        [JsonProperty("total_recycling_days")]
        public int? TotalRecyclingDays { get; set; }

        /// <value>The type of invoice this cycle applies to.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.DunningCycleType? Type { get; set; }

        /// <value>When the current settings were updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>Current campaign version.</value>
        [JsonProperty("version")]
        public int? Version { get; set; }

    }
}
