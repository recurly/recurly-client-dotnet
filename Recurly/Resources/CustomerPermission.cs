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
    public class CustomerPermission : Resource
    {

        /// <value>Customer permission code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Description of customer permission.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Customer permission ID.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Customer permission name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>It will always be "customer_permission".</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
