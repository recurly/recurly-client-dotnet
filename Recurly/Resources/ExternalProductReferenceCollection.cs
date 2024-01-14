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
    public class ExternalProductReferenceCollection : Resource
    {


        [JsonProperty("data")]
        public List<ExternalProductReferenceMini> Data { get; set; }

        /// <value>Indicates there are more results on subsequent pages.</value>
        [JsonProperty("has_more")]
        public bool? HasMore { get; set; }

        /// <value>Path to subsequent page of results.</value>
        [JsonProperty("next")]
        public string Next { get; set; }

        /// <value>Will always be List.</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
