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
    public class AccountInvoiceTemplate : Resource
    {

        /// <value>Unique ID to identify the invoice template.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Template name</value>
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
