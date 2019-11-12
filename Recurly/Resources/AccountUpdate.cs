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
    public class AccountUpdate : Request
    {


        [JsonProperty("address")]
        public Address Address { get; set; }


        [JsonProperty("billing_info")]
        public BillingInfoCreate BillingInfo { get; set; }

        /// <value>Additional email address that should receive account correspondence. These should be separated only by commas. These CC emails will receive all emails that the `email` field also receives.</value>
        [JsonProperty("cc_emails")]
        public string CcEmails { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>The email address used for communicating with this customer. The customer will also use this email address to log into your hosted account management pages. This value does not need to be unique.</value>
        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>The tax status of the account. `true` exempts tax on the account, `false` applies tax on the account.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>A secondary value for the account.</value>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <value>The VAT number of the account (to avoid having the VAT applied). This is only used for manually collected invoices.</value>
        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

    }
}
