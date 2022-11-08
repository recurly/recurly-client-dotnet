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
    public class ExternalProductReferenceMini : Resource
    {

        /// <value>When the external product was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Source connection platform.</value>
        [JsonProperty("external_connection_type")]
        public string ExternalConnectionType { get; set; }

        /// <value>System-generated unique identifier for an external product ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>object</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>A code which associates the external product to a corresponding object or resource in an external platform like the Apple App Store or Google Play Store.</value>
        [JsonProperty("reference_code")]
        public string ReferenceCode { get; set; }

        /// <value>When the external product was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
