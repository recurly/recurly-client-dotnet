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
    public class Subscription : Resource
    {

        /// <value>Account mini details</value>
        [JsonProperty("account")]
        public AccountMini Account { get; set; }

        /// <value>Activated at</value>
        [JsonProperty("activated_at")]
        public DateTime? ActivatedAt { get; set; }

        /// <value>The invoice ID of the latest invoice created for an active subscription.</value>
        [JsonProperty("active_invoice_id")]
        public string ActiveInvoiceId { get; set; }

        /// <value>Add-ons</value>
        [JsonProperty("add_ons")]
        public List<SubscriptionAddOn> AddOns { get; set; }

        /// <value>Total price of add-ons</value>
        [JsonProperty("add_ons_total")]
        public decimal? AddOnsTotal { get; set; }

        /// <value>Whether the subscription renews at the end of its term.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>Recurring subscriptions paid with ACH will have this attribute set. This timestamp is used for alerting customers to reauthorize in 3 years in accordance with NACHA rules. If a subscription becomes inactive or the billing info is no longer a bank account, this timestamp is cleared.</value>
        [JsonProperty("bank_account_authorized_at")]
        public DateTime? BankAccountAuthorizedAt { get; set; }

        /// <value>Billing Info ID.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>Canceled at</value>
        [JsonProperty("canceled_at")]
        public DateTime? CanceledAt { get; set; }

        /// <value>Collection method</value>
        [JsonProperty("collection_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CollectionMethod? CollectionMethod { get; set; }

        /// <value>When the subscription was converted from a gift card.</value>
        [JsonProperty("converted_at")]
        public DateTime? ConvertedAt { get; set; }

        /// <value>Returns subscription level coupon redemptions that are tied to this subscription.</value>
        [JsonProperty("coupon_redemptions")]
        public List<CouponRedemptionMini> CouponRedemptions { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Current billing period ends at</value>
        [JsonProperty("current_period_ends_at")]
        public DateTime? CurrentPeriodEndsAt { get; set; }

        /// <value>Current billing period started at</value>
        [JsonProperty("current_period_started_at")]
        public DateTime? CurrentPeriodStartedAt { get; set; }

        /// <value>When the term ends. This is calculated by a plan's interval and `total_billing_cycles` in a term. Subscription changes with a `timeframe=renewal` will be applied on this date.</value>
        [JsonProperty("current_term_ends_at")]
        public DateTime? CurrentTermEndsAt { get; set; }

        /// <value>The start date of the term when the first billing period starts. The subscription term is the length of time that a customer will be committed to a subscription. A term can span multiple billing periods.</value>
        [JsonProperty("current_term_started_at")]
        public DateTime? CurrentTermStartedAt { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Customer notes</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>Expiration reason</value>
        [JsonProperty("expiration_reason")]
        public string ExpirationReason { get; set; }

        /// <value>Expires at</value>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <value>If present, this subscription's transactions will use the payment gateway with this code.</value>
        [JsonProperty("gateway_code")]
        public string GatewayCode { get; set; }

        /// <value>Subscription ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

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

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>Null unless subscription is paused or will pause at the end of the current billing period.</value>
        [JsonProperty("paused_at")]
        public DateTime? PausedAt { get; set; }

        /// <value>Subscription Change</value>
        [JsonProperty("pending_change")]
        public SubscriptionChange PendingChange { get; set; }

        /// <value>Just the important parts.</value>
        [JsonProperty("plan")]
        public PlanMini Plan { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Subscription quantity</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>The ramp intervals representing the pricing schedule for the subscription.</value>
        [JsonProperty("ramp_intervals")]
        public List<SubscriptionRampIntervalResponse> RampIntervals { get; set; }

        /// <value>The remaining billing cycles in the current term.</value>
        [JsonProperty("remaining_billing_cycles")]
        public int? RemainingBillingCycles { get; set; }

        /// <value>Null unless subscription is paused or will pause at the end of the current billing period.</value>
        [JsonProperty("remaining_pause_cycles")]
        public int? RemainingPauseCycles { get; set; }

        /// <value>If `auto_renew=true`, when a term completes, `total_billing_cycles` takes this value as the length of subsequent terms. Defaults to the plan's `total_billing_cycles`.</value>
        [JsonProperty("renewal_billing_cycles")]
        public int? RenewalBillingCycles { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Subscription shipping details</value>
        [JsonProperty("shipping")]
        public SubscriptionShipping Shipping { get; set; }

        /// <value>Whether the subscription was started with a gift certificate.</value>
        [JsonProperty("started_with_gift")]
        public bool? StartedWithGift { get; set; }

        /// <value>State</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.SubscriptionState? State { get; set; }

        /// <value>Estimated total, before tax.</value>
        [JsonProperty("subtotal")]
        public decimal? Subtotal { get; set; }

        /// <value>Estimated tax</value>
        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        /// <value>Determines whether or not tax is included in the unit amount. The Tax Inclusive Pricing feature (separate from the Mixed Tax Pricing feature) must be enabled to utilize this flag.</value>
        [JsonProperty("tax_inclusive")]
        public bool? TaxInclusive { get; set; }

        /// <value>Tax info</value>
        [JsonProperty("tax_info")]
        public TaxInfo TaxInfo { get; set; }

        /// <value>Terms and conditions</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>Estimated total</value>
        [JsonProperty("total")]
        public decimal? Total { get; set; }

        /// <value>The number of cycles/billing periods in a term. When `remaining_billing_cycles=0`, if `auto_renew=true` the subscription will renew and a new term will begin, otherwise the subscription will expire.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>Trial period ends at</value>
        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        /// <value>Trial period started at</value>
        [JsonProperty("trial_started_at")]
        public DateTime? TrialStartedAt { get; set; }

        /// <value>Subscription unit price</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

    }
}
