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
    public class PriceSegment : Resource
    {

        /// <value>The price segment code, e.g. `my-price-segment`.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>The price segment ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
