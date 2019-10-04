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

        /// <value>Whether the subscription renews at the end of its term.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>Change collection method</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }


        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Specify custom notes to add or override Customer Notes. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>If present, this sets the date the subscription's next billing period will start (`current_period_ends_at`). This can be used to align the subscription’s billing to a specific day of the month. For a subscription in a trial period, this will change when the trial expires.</value>
        [JsonProperty("next_bill_date")]
        public DateTime? NextBillDate { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>The remaining billing cycles in the current term.</value>
        [JsonProperty("remaining_billing_cycles")]
        public int? RemainingBillingCycles { get; set; }

        /// <value>If `auto_renew=true`, when a term completes, `total_billing_cycles` takes this value as the length of subsequent terms. Defaults to the plan's `total_billing_cycles`.</value>
        [JsonProperty("renewal_billing_cycles")]
        public int? RenewalBillingCycles { get; set; }


        [JsonProperty("shipping")]
        public SubscriptionShippingUpdate Shipping { get; set; }

        /// <value>Specify custom notes to add or override Terms and Conditions. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

    }
}
