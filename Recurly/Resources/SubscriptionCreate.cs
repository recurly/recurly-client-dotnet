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
    public class SubscriptionCreate : Request
    {


        [JsonProperty("account")]
        public AccountCreate Account { get; set; }

        /// <value>Add-ons</value>
        [JsonProperty("add_ons")]
        public List<SubscriptionAddOnCreate> AddOns { get; set; }

        /// <value>Collection method</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        /// <value>Optional coupon code to redeem on the account and discount the subscription. Please note, the subscription request will fail if the coupon is invalid.</value>
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }

        /// <value>If there are pending credits on the account that will be invoiced during the subscription creation, these will be used as the Customer Notes on the credit invoice.</value>
        [JsonProperty("credit_customer_notes")]
        public string CreditCustomerNotes { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>This will default to the Customer Notes text specified on the Invoice Settings. Specify custom notes to add or override Customer Notes. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>If set,indicates when the first renewal should occur. Subsequent renewals will be offset from this date. The first invoice will be prorated appropriately so that the customer only pays for the portion of the first billing period for which the subscription applies. Useful for forcing a subscription to renew on the first of the month.</value>
        [JsonProperty("first_renewal_date")]
        public DateTime? FirstRenewalDate { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>Plan code</value>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        /// <value>Plan ID</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Optionally override the default quantity of 1.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>Create a shipping address on the account and assign it to the subscription.</value>
        [JsonProperty("shipping_address")]
        public ShippingAddressCreate ShippingAddress { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses. If this and `shipping_address` are both present, `shipping_address` will take precedence.</value>
        [JsonProperty("shipping_address_id")]
        public string ShippingAddressId { get; set; }

        /// <value>If set, the subscription will begin in the future on this date. The subscription will apply the setup fee and trial period, unless the plan has no trial.</value>
        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        /// <value>This will default to the Terms and Conditions text specified on the Invoice Settings page in your Recurly admin. Specify custom notes to add or override Terms and Conditions. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>Renews the subscription for a specified number of total cycles, then automatically cancels. Defaults to the subscription renewing indefinitely.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>If set, overrides the default trial behavior for the subscription. The date must be in the future.</value>
        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        /// <value>Override the unit amount of the subscription plan by setting this value. If not provided, the subscription will inherit the price from the subscription plan for the provided currency.</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

    }
}
