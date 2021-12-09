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
    public class InvoiceCollect : Request
    {

        /// <value>The `billing_info_id` is the value that represents a specific billing info for an end customer. When `billing_info_id` is used to assign billing info to the subscription, all future billing events for the subscription will bill to the specified billing info. `billing_info_id` can ONLY be used for sites utilizing the Wallet feature.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>A token generated by Recurly.js after completing a 3-D Secure device fingerprinting or authentication challenge.</value>
        [JsonProperty("three_d_secure_action_result_token_id")]
        public string ThreeDSecureActionResultTokenId { get; set; }

        /// <value>An optional type designation for the payment gateway transaction created by this request. Supports 'moto' value, which is the acronym for mail order and telephone transactions.</value>
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

    }
}
