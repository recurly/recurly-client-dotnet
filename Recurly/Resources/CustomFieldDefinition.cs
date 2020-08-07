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
    public class CustomFieldDefinition : Resource
    {

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Definitions are initially soft deleted, and once all the values are removed from the accouts or subscriptions, will be hard deleted an no longer visible.</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>Used to label the field when viewing and editing the field in Recurly's admin UI.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <value>Custom field definition ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Used by the API to identify the field or reading and writing. The name can only be used once per Recurly object type.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Related Recurly object type</value>
        [JsonProperty("related_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RelatedType? RelatedType { get; set; }

        /// <value>Displayed as a tooltip when editing the field in the Recurly admin UI.</value>
        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>
        /// The access control applied inside Recurly's admin UI:
        /// - `api_only` - No one will be able to view or edit this field's data via the admin UI.
        /// - `read_only` - Users with the Customers role will be able to view this field's data via the admin UI, but
        ///   editing will only be available via the API.
        /// - `write` - Users with the Customers role will be able to view and edit this field's data via the admin UI.
        /// </value>
        [JsonProperty("user_access")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.UserAccess? UserAccess { get; set; }

    }
}
