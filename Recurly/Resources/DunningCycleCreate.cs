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
    public class DunningCycleCreate : Request
    {

        /// <value>Only meaningful on the `trial` cycle, where sending `false` removes it. Other cycle types cannot be deactivated.</value>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <value>Whether the dunning settings will be applied to manual trials. Only applies to trial cycles.</value>
        [JsonProperty("applies_to_manual_trial")]
        public bool? AppliesToManualTrial { get; set; }

        /// <value>Whether the subscription(s) should be cancelled at the end of the dunning cycle.</value>
        [JsonProperty("expire_subscription")]
        public bool? ExpireSubscription { get; set; }

        /// <value>Number of days to extend external payment recovery. Only available when the site has external payment retries enabled.</value>
        [JsonProperty("external_payment_recovery_extension_days")]
        public int? ExternalPaymentRecoveryExtensionDays { get; set; }

        /// <value>Whether the invoice should be failed at the end of the dunning cycle.</value>
        [JsonProperty("fail_invoice")]
        public bool? FailInvoice { get; set; }

        /// <value>Dunning intervals. Required unless `active` is `false`.</value>
        [JsonProperty("intervals")]
        public List<DunningIntervalCreate> Intervals { get; set; }

        /// <value>Whether or not to send an extra email immediately to customers whose initial payment attempt fails with either a hard decline or invalid billing info.</value>
        [JsonProperty("send_immediately_on_hard_decline")]
        public bool? SendImmediatelyOnHardDecline { get; set; }

        /// <value>The type of invoice this cycle applies to.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.DunningCycleType? Type { get; set; }

    }
}
