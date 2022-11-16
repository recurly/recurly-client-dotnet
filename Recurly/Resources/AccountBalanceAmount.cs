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
    public class AccountBalanceAmount : Resource
    {

        /// <value>Total amount the account is past due.</value>
        [JsonProperty("amount")]
        public float? Amount { get; set; }

        /// <value>Total amount of the open balances on credit invoices for the account.</value>
        [JsonProperty("available_credit_amount")]
        public float? AvailableCreditAmount { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Total amount for the prepayment credit invoices in a `processing` state on the account.</value>
        [JsonProperty("processing_prepayment_amount")]
        public float? ProcessingPrepaymentAmount { get; set; }

    }
}
