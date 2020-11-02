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
    public class BillingInfo : Resource
    {


        [JsonProperty("account_id")]
        public string AccountId { get; set; }


        [JsonProperty("address")]
        public Address Address { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>When the billing information was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>Most recent fraud result.</value>
        [JsonProperty("fraud")]
        public FraudInfo Fraud { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }


        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        /// <value>The `primary_payment_method` indicator is used to designate the primary billing info on the account. The first billing info created on an account will always become primary. Adding additional billing infos provides the flexibility to mark another billing info as primary, or adding additional non-primary billing infos. This can be accomplished by passing the `primary_payment_method` indicator. When adding billing infos via the billing_info and /accounts endpoints, this value is not permitted, and will return an error if provided.</value>
        [JsonProperty("primary_payment_method")]
        public bool? PrimaryPaymentMethod { get; set; }

        /// <value>When the billing information was last changed.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }


        [JsonProperty("updated_by")]
        public BillingInfoUpdatedBy UpdatedBy { get; set; }


        [JsonProperty("valid")]
        public bool? Valid { get; set; }

        /// <value>Customer's VAT number (to avoid having the VAT applied). This is only used for automatically collected invoices.</value>
        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

    }
}
