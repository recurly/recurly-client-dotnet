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
    public class ExternalProductCreate : Request
    {

        /// <value>List of external product references of the external product.</value>
        [JsonProperty("external_product_references")]
        public List<ExternalProductReferenceBase> ExternalProductReferences { get; set; }

        /// <value>External product name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Recurly plan UUID.</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

    }
}
