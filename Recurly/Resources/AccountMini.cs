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
    public class AccountMini : Resource
    {

        /// <value>The unique identifier of the account.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>The email address used for communicating with this customer.</value>
        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

    }
}
