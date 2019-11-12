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
    public class Account : Resource
    {


        [JsonProperty("address")]
        public Address Address { get; set; }


        [JsonProperty("billing_info")]
        public BillingInfo BillingInfo { get; set; }

        /// <value>Additional email address that should receive account correspondence. These should be separated only by commas. These CC emails will receive all emails that the `email` field also receives.</value>
        [JsonProperty("cc_emails")]
        public string CcEmails { get; set; }

        /// <value>The unique identifier of the account. This cannot be changed once the account is created.</value>
        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>When the account was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>If present, when the account was last marked inactive.</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>The email address used for communicating with this customer. The customer will also use this email address to log into your hosted account management pages. This value does not need to be unique.</value>
        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>The unique token for automatically logging the account in to the hosted management pages. You may automatically log the user into their hosted management pages by directing the user to: `https://{subdomain}.recurly.com/account/{hosted_login_token}`.</value>
        [JsonProperty("hosted_login_token")]
        public string HostedLoginToken { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>The shipping addresses on the account.</value>
        [JsonProperty("shipping_addresses")]
        public List<ShippingAddress> ShippingAddresses { get; set; }

        /// <value>Accounts can be either active or inactive.</value>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <value>The tax status of the account. `true` exempts tax on the account, `false` applies tax on the account.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>When the account was last changed.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>A secondary value for the account.</value>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <value>The VAT number of the account (to avoid having the VAT applied). This is only used for manually collected invoices.</value>
        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

    }
}
