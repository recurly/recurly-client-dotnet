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
    public class InvoiceTemplate : Resource
    {

        /// <value>Invoice template code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>When the invoice template was created in Recurly.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Invoice template description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Invoice template name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>When the invoice template was updated in Recurly.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
