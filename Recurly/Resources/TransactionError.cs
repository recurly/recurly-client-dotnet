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
    public class TransactionError : Resource
    {

        /// <value>Category</value>
        [JsonProperty("category")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ErrorCategory? Category { get; set; }

        /// <value>Code</value>
        [JsonProperty("code")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ErrorCode? Code { get; set; }

        /// <value>Merchant message</value>
        [JsonProperty("merchant_advice")]
        public string MerchantAdvice { get; set; }

        /// <value>Customer message</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Returned when 3-D Secure authentication is required for a transaction. Pass this value to Recurly.js so it can continue the challenge flow.</value>
        [JsonProperty("three_d_secure_action_token_id")]
        public string ThreeDSecureActionTokenId { get; set; }

        /// <value>Transaction ID</value>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

    }
}
