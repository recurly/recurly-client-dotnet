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
    public class GatewayAttributes : Request
    {

        /// <value>Used by Adyen gateways. The Shopper Reference value used when the external token was created. Must be used in conjunction with gateway_token and gateway_code.</value>
        [JsonProperty("account_reference")]
        public string AccountReference { get; set; }

    }
}
