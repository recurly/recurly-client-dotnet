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
    public class GrantedBy : Resource
    {

        /// <value>The ID of the subscription or external subscription that grants the permission to the account.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Object Type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
