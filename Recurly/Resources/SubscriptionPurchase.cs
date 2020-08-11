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
    public class SubscriptionPurchase : Request
    {

        /// <value>Add-ons</value>
        [JsonProperty("add_ons")]
        public List<SubscriptionAddOnCreate> AddOns { get; set; }

        /// <value>Whether the subscription renews at the end of its term.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>If present, this sets the date the subscription's next billing period will start (`current_period_ends_at`). This can be used to align the subscription’s billing to a specific day of the month. The initial invoice will be prorated for the period between the subscription's activation date and the billing period end date. Subsequent periods will be based off the plan interval. For a subscription with a trial period, this will change when the trial expires.</value>
        [JsonProperty("next_bill_date")]
        public DateTime? NextBillDate { get; set; }

        /// <value>Plan code</value>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        /// <value>Plan ID</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>Optionally override the default quantity of 1.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>If `auto_renew=true`, when a term completes, `total_billing_cycles` takes this value as the length of subsequent terms. Defaults to the plan's `total_billing_cycles`.</value>
        [JsonProperty("renewal_billing_cycles")]
        public int? RenewalBillingCycles { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Create a shipping address on the account and assign it to the subscription.</value>
        [JsonProperty("shipping")]
        public SubscriptionShippingPurchase Shipping { get; set; }

        /// <value>If set, the subscription will begin in the future on this date. The subscription will apply the setup fee and trial period, unless the plan has no trial.</value>
        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        /// <value>The number of cycles/billing periods in a term. When `remaining_billing_cycles=0`, if `auto_renew=true` the subscription will renew and a new term will begin, otherwise the subscription will expire.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>If set, overrides the default trial behavior for the subscription. The date must be in the future.</value>
        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        /// <value>Override the unit amount of the subscription plan by setting this value in cents. If not provided, the subscription will inherit the price from the subscription plan for the provided currency.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

    }
}
