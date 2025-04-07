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
    public class PaymentGatewayReferences : Request
    {

        /// <value>The type of reference token. Required if token is passed in for Stripe Gateway or Ebanx UPI.</value>
        [JsonProperty("reference_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.PaymentGatewayReferences? ReferenceType { get; set; }

        /// <value>Reference value used when the external token was created. If a Stripe gateway or Ebanx gateway is used, this value will need to be accompanied by its reference_type.</value>
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
