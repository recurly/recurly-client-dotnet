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
    public class InvoiceUpdate : Request
    {


        [JsonProperty("address")]
        public InvoiceAddress Address { get; set; }

        /// <value>Customer notes are an optional note field.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. Changing Net terms changes due_on, and the invoice could move between past due and pending.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>This identifies the PO number associated with the invoice. Not editable for credit invoices.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Terms and conditions are an optional note field. Not editable for credit invoices.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>VAT Reverse Charge Notes are editable only if there was a VAT reverse charge applied to the invoice.</value>
        [JsonProperty("vat_reverse_charge_notes")]
        public string VatReverseChargeNotes { get; set; }

    }
}
