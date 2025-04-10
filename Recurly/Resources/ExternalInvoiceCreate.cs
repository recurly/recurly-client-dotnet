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
    public class ExternalInvoiceCreate : Request
    {

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>An identifier which associates the external invoice to a corresponding object in an external platform.</value>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }


        [JsonProperty("external_payment_phase")]
        public ExternalPaymentPhaseBase ExternalPaymentPhase { get; set; }

        /// <value>External payment phase ID, e.g. `a34ypb2ef9w1`.</value>
        [JsonProperty("external_payment_phase_id")]
        public string ExternalPaymentPhaseId { get; set; }


        [JsonProperty("line_items")]
        public List<ExternalChargeCreate> LineItems { get; set; }

        /// <value>When the invoice was created in the external platform.</value>
        [JsonProperty("purchased_at")]
        public DateTime? PurchasedAt { get; set; }


        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ExternalInvoiceState? State { get; set; }


        [JsonProperty("total")]
        public string Total { get; set; }

    }
}
