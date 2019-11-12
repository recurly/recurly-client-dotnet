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
    public class SubscriptionUpdate : Request
    {

        /// <value>Change collection method</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        /// <value>Specify custom notes to add or override Customer Notes. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>For an active subscription, this will change the next renewal date. For a subscription in a trial period, modifying the renewal date will change when the trial expires.</value>
        [JsonProperty("next_renewal_at")]
        public DateTime? NextRenewalAt { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Renews the subscription for a specified number of cycles, then automatically cancels.</value>
        [JsonProperty("remaining_billing_cycles")]
        public int? RemainingBillingCycles { get; set; }

        /// <value>Create a shipping address on the account and assign it to the subscription. If this and `shipping_address_id` are both present, `shipping_address_id` will take precedence.</value>
        [JsonProperty("shipping_address")]
        public ShippingAddressCreate ShippingAddress { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses.</value>
        [JsonProperty("shipping_address_id")]
        public string ShippingAddressId { get; set; }

        /// <value>Specify custom notes to add or override Terms and Conditions. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

    }
}
