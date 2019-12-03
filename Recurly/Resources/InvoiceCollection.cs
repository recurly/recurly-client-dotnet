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
    public class InvoiceCollection : Resource
    {


        [JsonProperty("charge_invoice")]
        public Invoice ChargeInvoice { get; set; }

        /// <value>Credit invoices</value>
        [JsonProperty("credit_invoices")]
        public List<Invoice> CreditInvoices { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

    }
}
