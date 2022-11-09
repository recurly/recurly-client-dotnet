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
    public class ExternalProduct : Resource
    {

        /// <value>When the external product was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>List of external product references of the external product.</value>
        [JsonProperty("external_product_references")]
        public List<ExternalProductReferenceMini> ExternalProductReferences { get; set; }

        /// <value>System-generated unique identifier for an external product ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Name to identify the external product in Recurly.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Just the important parts.</value>
        [JsonProperty("plan")]
        public PlanMini Plan { get; set; }

        /// <value>When the external product was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
