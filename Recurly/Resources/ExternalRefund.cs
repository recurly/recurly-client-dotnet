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
    public class ExternalRefund : Request
    {

        /// <value>Used as the refund transactions' description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Payment method used for external refund transaction.</value>
        [JsonProperty("payment_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ExternalPaymentMethod? PaymentMethod { get; set; }

        /// <value>Date the external refund payment was made. Defaults to the current date-time.</value>
        [JsonProperty("refunded_at")]
        public DateTime? RefundedAt { get; set; }

    }
}
