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
    public class ShippingMethod : Resource
    {

        /// <value>Accounting code for shipping method.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>The internal name used identify the shipping method.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Deleted at</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>Shipping Method ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>The name of the shipping method displayed to customers.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>
        /// Used by Avalara, Vertex, and Recurly’s built-in tax feature. The tax
        /// code values are specific to each tax system. If you are using Recurly’s
        /// built-in taxes the values are:
        /// 
        /// - `FR` – Common Carrier FOB Destination
        /// - `FR022000` – Common Carrier FOB Origin
        /// - `FR020400` – Non Common Carrier FOB Destination
        /// - `FR020500` – Non Common Carrier FOB Origin
        /// - `FR010100` – Delivery by Company Vehicle Before Passage of Title
        /// - `FR010200` – Delivery by Company Vehicle After Passage of Title
        /// - `NT` – Non-Taxable
        /// </value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
