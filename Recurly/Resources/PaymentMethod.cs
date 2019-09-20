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
    public class PaymentMethod : Resource
    {

        /// <value>The bank account type. Only present for ACH payment methods.</value>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <value>Billing Agreement identifier. Only present for Amazon or Paypal payment methods.</value>
        [JsonProperty("billing_agreement_id")]
        public string BillingAgreementId { get; set; }

        /// <value>Visa, MasterCard, American Express, Discover, JCB, etc.</value>
        [JsonProperty("card_type")]
        public string CardType { get; set; }

        /// <value>Expiration month.</value>
        [JsonProperty("exp_month")]
        public int? ExpMonth { get; set; }

        /// <value>Expiration year.</value>
        [JsonProperty("exp_year")]
        public int? ExpYear { get; set; }

        /// <value>Credit card number's first six digits.</value>
        [JsonProperty("first_six")]
        public string FirstSix { get; set; }

        /// <value>Credit card number's last four digits. Will refer to bank account if payment method is ACH.</value>
        [JsonProperty("last_four")]
        public string LastFour { get; set; }

        /// <value>The bank account's routing number. Only present for ACH payment methods.</value>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }

        /// <value>The bank name of this routing number.</value>
        [JsonProperty("routing_number_bank")]
        public string RoutingNumberBank { get; set; }

    }
}
