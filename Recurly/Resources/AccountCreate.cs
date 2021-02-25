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
    public class AccountCreate : Request
    {


        [JsonProperty("acquisition")]
        public AccountAcquisitionUpdate Acquisition { get; set; }


        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <value>An enumerable describing the billing behavior of the account, specifically whether the account is self-paying or will rely on the parent account to pay.</value>
        [JsonProperty("bill_to")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.BillTo? BillTo { get; set; }


        [JsonProperty("billing_info")]
        public BillingInfoCreate BillingInfo { get; set; }

        /// <value>Additional email address that should receive account correspondence. These should be separated only by commas. These CC emails will receive all emails that the `email` field also receives.</value>
        [JsonProperty("cc_emails")]
        public string CcEmails { get; set; }

        /// <value>The unique identifier of the account. This cannot be changed once the account is created.</value>
        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>The email address used for communicating with this customer. The customer will also use this email address to log into your hosted account management pages. This value does not need to be unique.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <value>The tax exemption certificate number for the account. If the merchant has an integration for the Vertex tax provider, this optional value will be sent in any tax calculation requests for the account.</value>
        [JsonProperty("exemption_certificate")]
        public string ExemptionCertificate { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>The account code of the parent account to be associated with this account. Passing an empty value removes any existing parent association from this account. If both `parent_account_code` and `parent_account_id` are passed, the non-blank value in `parent_account_id` will be used. Only one level of parent child relationship is allowed. You cannot assign a parent account that itself has a parent account.</value>
        [JsonProperty("parent_account_code")]
        public string ParentAccountCode { get; set; }

        /// <value>The UUID of the parent account to be associated with this account. Passing an empty value removes any existing parent association from this account. If both `parent_account_code` and `parent_account_id` are passed, the non-blank value in `parent_account_id` will be used. Only one level of parent child relationship is allowed. You cannot assign a parent account that itself has a parent account.</value>
        [JsonProperty("parent_account_id")]
        public string ParentAccountId { get; set; }

        /// <value>Used to determine the language and locale of emails sent on behalf of the merchant to the customer. The list of locales is restricted to those the merchant has enabled on the site.</value>
        [JsonProperty("preferred_locale")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.PreferredLocale? PreferredLocale { get; set; }


        [JsonProperty("shipping_addresses")]
        public List<ShippingAddressCreate> ShippingAddresses { get; set; }

        /// <value>The tax status of the account. `true` exempts tax on the account, `false` applies tax on the account.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>An optional type designation for the payment gateway transaction created by this request. Supports 'moto' value, which is the acronym for mail order and telephone transactions.</value>
        [JsonProperty("transaction_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.GatewayTransactionType? TransactionType { get; set; }

        /// <value>A secondary value for the account.</value>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <value>The VAT number of the account (to avoid having the VAT applied). This is only used for manually collected invoices.</value>
        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

    }
}
