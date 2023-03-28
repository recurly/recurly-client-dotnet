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
    public class ExternalInvoice : Resource
    {

        /// <value>Account mini details</value>
        [JsonProperty("account")]
        public AccountMini Account { get; set; }

        /// <value>When the external invoice was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>An identifier which associates the external invoice to a corresponding object in an external platform.</value>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <value>Subscription from an external resource such as Apple App Store or Google Play Store.</value>
        [JsonProperty("external_subscription")]
        public ExternalSubscription ExternalSubscription { get; set; }

        /// <value>System-generated unique identifier for an external invoice ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("line_items")]
        public List<ExternalCharge> LineItems { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>When the invoice was created in the external platform.</value>
        [JsonProperty("purchased_at")]
        public DateTime? PurchasedAt { get; set; }


        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ExternalInvoiceState? State { get; set; }

        /// <value>Total</value>
        [JsonProperty("total")]
        public decimal? Total { get; set; }

        /// <value>When the external invoice was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
