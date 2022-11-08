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
    public class ExternalResourceMini : Resource
    {

        /// <value>Identifier or URL reference where the resource is canonically available in the external platform.</value>
        [JsonProperty("external_object_reference")]
        public string ExternalObjectReference { get; set; }

        /// <value>System-generated unique identifier for an external resource ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
