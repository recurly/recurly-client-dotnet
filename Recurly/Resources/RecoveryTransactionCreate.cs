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
    public class RecoveryTransactionCreate : Request
    {

        /// <value>The date the original payment collection was attempted.</value>
        [JsonProperty("attempted_collection_date")]
        public DateTime? AttemptedCollectionDate { get; set; }

        /// <value>The error code returned by the payment gateway for the original payment collection attempt.</value>
        [JsonProperty("gateway_error_code")]
        public string GatewayErrorCode { get; set; }

        /// <value>The advice code returned by the payment gateway for the original payment collection attempt. This field is only applicable for certain gateways.</value>
        [JsonProperty("merchant_advice_code")]
        public string MerchantAdviceCode { get; set; }

    }
}
