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
    public class ItemMini : Resource
    {

        /// <value>Unique code to identify the item.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Optional, description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Item ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>This name describes your item and will appear on the invoice when it's purchased on a one time basis.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>The current state of the item.</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ActiveState? State { get; set; }

    }
}
