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
    public class ExternalProductReferenceBase : Request
    {


        [JsonProperty("external_connection_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ExternalProductReferenceConnectionType? ExternalConnectionType { get; set; }

        /// <value>A code which associates the external product to a corresponding object or resource in an external platform like the Apple App Store or Google Play Store.</value>
        [JsonProperty("reference_code")]
        public string ReferenceCode { get; set; }

    }
}
