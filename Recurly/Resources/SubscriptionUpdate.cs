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

        /// <value>The `billing_info_id` is the value that represents a specific billing info for an end customer. When `billing_info_id` is used to assign billing info to the subscription, all future billing events for the subscription will bill to the specified billing info. `billing_info_id` can ONLY be used for sites utilizing the Wallet feature.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>Change collection method</value>
        [JsonProperty("collection_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CollectionMethod? CollectionMethod { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Specify custom notes to add or override Customer Notes. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>If present, this subscription's transactions will use the payment gateway with this code.</value>
        [JsonProperty("gateway_code")]
        public string GatewayCode { get; set; }

        /// <value>
        /// Integer paired with `Net Terms Type` and representing the number
        /// of days past the current date (for `net` Net Terms Type) or days after
        /// the last day of the current month (for `eom` Net Terms Type) that the
        /// invoice will become past due. For any value, an additional 24 hours is
        /// added to ensure the customer has the entire last day to make payment before
        /// becoming past due.  For example:
        /// 
        /// If an invoice is due `net 0`, it is due 'On Receipt' and will become past due 24 hours after it's created.
        /// If an invoice is due `net 30`, it will become past due at 31 days exactly.
        /// If an invoice is due `eom 30`, it will become past due 31 days from the last day of the current month.
        /// 
        /// When `eom` Net Terms Type is passed, the value for `Net Terms` is restricted to `0, 15, 30, 45, 60, or 90`.
        /// For more information please visit our docs page (https://docs.recurly.com/docs/manual-payments#section-collection-terms)</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>
        /// Optionally supplied string that may be either `net` or `eom` (end-of-month).
        /// When `net`, an invoice becomes past due the specified number of `Net Terms` days from the current date.
        /// When `eom` an invoice becomes past due the specified number of `Net Terms` days from the last day of the current month.
        /// 
        /// This field is only available when the EOM Net Terms feature is enabled.
        /// </value>
        [JsonProperty("net_terms_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.NetTermsType? NetTermsType { get; set; }

        /// <value>If present, this sets the date the subscription's next billing period will start (`current_period_ends_at`). This can be used to align the subscription’s billing to a specific day of the month. For a subscription in a trial period, this will change when the trial expires. This parameter is useful for postponement of a subscription to change its billing date without proration.</value>
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

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Subscription shipping details</value>
        [JsonProperty("shipping")]
        public SubscriptionShippingUpdate Shipping { get; set; }

        /// <value>This field is deprecated. Please do not use it.</value>
        [JsonProperty("tax_inclusive")]
        public bool? TaxInclusive { get; set; }

        /// <value>Specify custom notes to add or override Terms and Conditions. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

    }
}
