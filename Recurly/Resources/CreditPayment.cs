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
    public class CreditPayment : Resource
    {


        [JsonProperty("account")]
        public AccountMini Account { get; set; }

        /// <value>The action for which the credit was created.</value>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <value>Total credit payment amount applied to the charge invoice.</value>
        [JsonProperty("amount")]
        public float? Amount { get; set; }


        [JsonProperty("applied_to_invoice")]
        public InvoiceMini AppliedToInvoice { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Credit Payment ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("original_invoice")]
        public InvoiceMini OriginalInvoice { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        /// <value>Voided at</value>
        [JsonProperty("voided_at")]
        public DateTime? VoidedAt { get; set; }

    }
}
