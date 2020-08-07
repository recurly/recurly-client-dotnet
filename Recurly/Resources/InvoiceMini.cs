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
    public class InvoiceMini : Resource
    {

        /// <value>Invoice ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Invoice number</value>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Invoice state</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.InvoiceState? State { get; set; }

        /// <value>Invoice type</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.InvoiceType? Type { get; set; }

    }
}
