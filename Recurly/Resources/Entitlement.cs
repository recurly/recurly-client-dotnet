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
    public class Entitlement : Resource
    {

        /// <value>Time object was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }


        [JsonProperty("customer_permission")]
        public CustomerPermission CustomerPermission { get; set; }

        /// <value>Subscription or item that granted the customer permission.</value>
        [JsonProperty("granted_by")]
        public List<GrantedBy> GrantedBy { get; set; }

        /// <value>Entitlement</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Time the object was last updated</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
