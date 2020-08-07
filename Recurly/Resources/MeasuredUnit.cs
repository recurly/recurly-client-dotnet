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
    public class MeasuredUnit : Resource
    {

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Deleted at</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>Optional internal description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Display name for the measured unit. Can only contain spaces, underscores and must be alphanumeric.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <value>Item ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Unique internal name of the measured unit on your site.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>The current state of the measured unit.</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ActiveState? State { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
