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

        /// <value>Whether the subscription renews at the end of its term.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>The `billing_info_id` is the value that represents a specific billing info for an end customer. When `billing_info_id` is used to assign billing info to the subscription, all future billing events for the subscription will bill to the specified billing info. `billing_info_id` can ONLY be used for sites utilizing the Wallet feature.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>Optional field to be used only when needing to bypass the 60 second limit on creating subscriptions. Should only be used when creating subscriptions in bulk from the API.</value>
        [JsonProperty("bulk")]
        public bool? Bulk { get; set; }

        /// <value>The `business_entity_code` is the value that represents a specific business entity for an end customer. When `business_entity_code` is used to assign a business entity to the subscription, all future billing events for the subscription will bill to the specified business entity. Available when the `Multiple Business Entities` feature is enabled. If both `business_entity_id` and `business_entity_code` are present, `business_entity_id` will be used.</value>
        [JsonProperty("business_entity_code")]
        public string BusinessEntityCode { get; set; }

        /// <value>The `business_entity_id` is the value that represents a specific business entity for an end customer. When `business_entity_id` is used to assign a business entity to the subscription, all future billing events for the subscription will bill to the specified business entity. Available when the `Multiple Business Entities` feature is enabled. If both `business_entity_id` and `business_entity_code` are present, `business_entity_id` will be used.</value>
        [JsonProperty("business_entity_id")]
        public string BusinessEntityId { get; set; }

        /// <value>Collection method</value>
        [JsonProperty("collection_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CollectionMethod? CollectionMethod { get; set; }

        /// <value>A list of coupon_codes to be redeemed on the subscription or account during the purchase.</value>
        [JsonProperty("coupon_codes")]
        public List<string> CouponCodes { get; set; }

        /// <value>
        /// Controls whether credit invoices are automatically applied to new invoices.
        /// The `mode` field determines the application behavior. When mode is `all`,
        /// the optional `allowed_origins` array can restrict which credit invoice origins
        /// are applied.
        /// </value>
        [JsonProperty("credit_application_policy")]
        public CreditApplicationPolicy CreditApplicationPolicy { get; set; }

        /// <value>If there are pending credits on the account that will be invoiced during the subscription creation, these will be used as the Customer Notes on the credit invoice.</value>
        [JsonProperty("credit_customer_notes")]
        public string CreditCustomerNotes { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>This will default to the Customer Notes text specified on the Invoice Settings. Specify custom notes to add or override Customer Notes. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>If present, this subscription's subsequent transactions will use the payment gateway with this code. To select a payment gateway to use when creating a Subscription, be sure to set the `account.billing_info.gateway_code` as well.</value>
        [JsonProperty("gateway_code")]
        public string GatewayCode { get; set; }

        /// <value>A gift card redemption code to be redeemed on the purchase invoice.</value>
        [JsonProperty("gift_card_redemption_code")]
        public string GiftCardRedemptionCode { get; set; }

        /// <value>
        /// Integer paired with `Net Terms Type` and representing the number
        /// of days past the current date (for `net` Net Terms Type) or days after
        /// the last day of the current month (for `eom` Net Terms Type) that the
        /// invoice will become past due. For `manual` collection method, an additional 24 hours is
        /// added to ensure the customer has the entire last day to make payment before
        /// becoming past due. For example:
        /// 
        /// If an invoice is due `net 0`, it is due 'On Receipt' and will become past due 24 hours after it's created.
        /// If an invoice is due `net 30`, it will become past due at 31 days exactly.
        /// If an invoice is due `eom 30`, it will become past due 31 days from the last day of the current month.
        /// 
        /// For `automatic` collection method, the additional 24 hours is not added. For example, On-Receipt is due immediately, and `net 30` will become due exactly 30 days from invoice generation, at which point Recurly will attempt collection.
        /// When `eom` Net Terms Type is passed, the value for `Net Terms` is restricted to `0, 15, 30, 45, 60, or 90`.
        /// 
        /// For more information on how net terms work with `manual` collection visit our docs page (https://docs.recurly.com/docs/manual-payments#section-collection-terms)
        /// or visit (https://docs.recurly.com/docs/automatic-invoicing-terms#section-collection-terms) for information about net terms using `automatic` collection.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>
        /// Optionally supplied string that may be either `net` or `eom` (end-of-month).
        /// When `net`, an invoice becomes past due the specified number of `Net Terms` days from the current date.
        /// When `eom` an invoice becomes past due the specified number of `Net Terms` days from the last day of the current month.
        /// </value>
        [JsonProperty("net_terms_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.NetTermsType? NetTermsType { get; set; }

        /// <value>If present, this sets the date the subscription's next billing period will start (`current_period_ends_at`). This can be used to align the subscription’s billing to a specific day of the month. The initial invoice will be prorated for the period between the subscription's activation date and the billing period end date. Subsequent periods will be based off the plan interval. For a subscription with a trial period, this will change when the trial expires.</value>
        [JsonProperty("next_bill_date")]
        public DateTime? NextBillDate { get; set; }

        /// <value>You must provide either a `plan_code` or `plan_id`. If both are provided the `plan_id` will be used.</value>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        /// <value>You must provide either a `plan_code` or `plan_id`. If both are provided the `plan_id` will be used.</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>The price segment ID, e.g. `e28zov4fw0v2`.</value>
        [JsonProperty("price_segment_id")]
        public string PriceSegmentId { get; set; }

        /// <value>Allows you to control how any resulting charges will be calculated and prorated.</value>
        [JsonProperty("proration_settings")]
        public SubscriptionCreateProrationSettings ProrationSettings { get; set; }

        /// <value>Optionally override the default quantity of 1.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>The new set of ramp intervals for the subscription.</value>
        [JsonProperty("ramp_intervals")]
        public List<SubscriptionRampInterval> RampIntervals { get; set; }

        /// <value>If `auto_renew=true`, when a term completes, `total_billing_cycles` takes this value as the length of subsequent terms. Defaults to the plan's `total_billing_cycles`.</value>
        [JsonProperty("renewal_billing_cycles")]
        public int? RenewalBillingCycles { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Create a shipping address on the account and assign it to the subscription.</value>
        [JsonProperty("shipping")]
        public SubscriptionShippingCreate Shipping { get; set; }

        /// <value>If set, the subscription will begin on this specified date. The subscription will apply the setup fee and trial period, unless the plan has no trial. Omit this field if the subscription should be started immediately.</value>
        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        /// <value>Determines whether or not tax is included in the unit amount. The Tax Inclusive Pricing feature (separate from the Mixed Tax Pricing feature) must be enabled to use this flag.</value>
        [JsonProperty("tax_inclusive")]
        public bool? TaxInclusive { get; set; }

        /// <value>This will default to the Terms and Conditions text specified on the Invoice Settings page in your Recurly admin. Specify custom notes to add or override Terms and Conditions. Custom notes will stay with a subscription on all renewals.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>The number of cycles/billing periods in a term. When `remaining_billing_cycles=0`, if `auto_renew=true` the subscription will renew and a new term will begin, otherwise the subscription will expire.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>An optional type designation for the payment gateway transaction created by this request. Supports 'moto' value, which is the acronym for mail order and telephone transactions.</value>
        [JsonProperty("transaction_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.GatewayTransactionType? TransactionType { get; set; }

        /// <value>If set, overrides the default trial behavior for the subscription. When the current date time or a past date time is provided the subscription will begin with no trial phase (overriding any plan default trial). When a future date time is provided the subscription will begin with a trial phase ending at the specified date time.</value>
        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        /// <value>Override the unit amount of the subscription plan by setting this value. If not provided, the subscription will inherit the price from the subscription plan for the provided currency.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

    }
}
