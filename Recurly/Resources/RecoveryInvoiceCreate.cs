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
    public class RecoveryInvoiceCreate : Request
    {


        [JsonProperty("account")]
        public RecoveryAccountCreate Account { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Date invoice was originally due. Must be in the past.</value>
        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        /// <value>Must be set to `true` to acknowledge that the invoice is eligible for external recovery. Requests with `false`, omitted, or non-boolean values will be rejected.</value>
        [JsonProperty("external_recovery_eligible")]
        public bool? ExternalRecoveryEligible { get; set; }

        /// <value>Line items to include on the invoice. Currency is specified at the root level and must not be included in individual line items.</value>
        [JsonProperty("line_items")]
        public List<RecoveryLineItemCreate> LineItems { get; set; }

        /// <value>This identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Optionally overrides the suffix component of the composed transaction descriptor. If omitted, the suffix is derived from the subscription's plan name or the invoice description, with a Trial prefix on Visa trial conversions. Subject to gateway availability and payment method support.</value>
        [JsonProperty("transaction_descriptor_suffix")]
        public string TransactionDescriptorSuffix { get; set; }

    }
}
