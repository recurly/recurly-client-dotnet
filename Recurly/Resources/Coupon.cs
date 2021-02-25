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
    public class Coupon : Resource
    {

        /// <value>
        /// The coupon is valid for all items if true. If false then `items`
        /// will list the applicable items.
        /// </value>
        [JsonProperty("applies_to_all_items")]
        public bool? AppliesToAllItems { get; set; }

        /// <value>The coupon is valid for all plans if true. If false then `plans` will list the applicable plans.</value>
        [JsonProperty("applies_to_all_plans")]
        public bool? AppliesToAllPlans { get; set; }

        /// <value>The coupon is valid for one-time, non-plan charges if true.</value>
        [JsonProperty("applies_to_non_plan_charges")]
        public bool? AppliesToNonPlanCharges { get; set; }

        /// <value>The code the customer enters to redeem the coupon.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Whether the coupon is "single_code" or "bulk". Bulk coupons will require a `unique_code_template` and will generate unique codes through the `/generate` endpoint.</value>
        [JsonProperty("coupon_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponType? CouponType { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>
        /// Details of the discount a coupon applies. Will contain a `type`
        /// property and one of the following properties: `percent`, `fixed`, `trial`.
        /// </value>
        [JsonProperty("discount")]
        public CouponDiscount Discount { get; set; }

        /// <value>
        /// - "single_use" coupons applies to the first invoice only.
        /// - "temporal" coupons will apply to invoices for the duration determined by the `temporal_unit` and `temporal_amount` attributes.
        /// </value>
        [JsonProperty("duration")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponDuration? Duration { get; set; }

        /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
        [JsonProperty("expired_at")]
        public DateTime? ExpiredAt { get; set; }

        /// <value>Sets the duration of time the `free_trial_unit` is for.</value>
        [JsonProperty("free_trial_amount")]
        public int? FreeTrialAmount { get; set; }

        /// <value>Description of the unit of time the coupon is for. Used with `free_trial_amount` to determine the duration of time the coupon is for.</value>
        [JsonProperty("free_trial_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.FreeTrialUnit? FreeTrialUnit { get; set; }

        /// <value>This description will show up when a customer redeems a coupon on your Hosted Payment Pages, or if you choose to show the description on your own checkout page.</value>
        [JsonProperty("hosted_page_description")]
        public string HostedPageDescription { get; set; }

        /// <value>Coupon ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Description of the coupon on the invoice.</value>
        [JsonProperty("invoice_description")]
        public string InvoiceDescription { get; set; }

        /// <value>
        /// A list of items for which this coupon applies. This will be
        /// `null` if `applies_to_all_items=true`.
        /// </value>
        [JsonProperty("items")]
        public List<ItemMini> Items { get; set; }

        /// <value>A maximum number of redemptions for the coupon. The coupon will expire when it hits its maximum redemptions.</value>
        [JsonProperty("max_redemptions")]
        public int? MaxRedemptions { get; set; }

        /// <value>Redemptions per account is the number of times a specific account can redeem the coupon. Set redemptions per account to `1` if you want to keep customers from gaming the system and getting more than one discount from the coupon campaign.</value>
        [JsonProperty("max_redemptions_per_account")]
        public int? MaxRedemptionsPerAccount { get; set; }

        /// <value>The internal name for the coupon.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>A list of plans for which this coupon applies. This will be `null` if `applies_to_all_plans=true`.</value>
        [JsonProperty("plans")]
        public List<PlanMini> Plans { get; set; }

        /// <value>The date and time the coupon will expire and can no longer be redeemed. Time is always 11:59:59, the end-of-day Pacific time.</value>
        [JsonProperty("redeem_by")]
        public DateTime? RedeemBy { get; set; }

        /// <value>Whether the discount is for all eligible charges on the account, or only a specific subscription.</value>
        [JsonProperty("redemption_resource")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RedemptionResource? RedemptionResource { get; set; }

        /// <value>Indicates if the coupon is redeemable, and if it is not, why.</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponState? State { get; set; }

        /// <value>If `duration` is "temporal" than `temporal_amount` is an integer which is multiplied by `temporal_unit` to define the duration that the coupon will be applied to invoices for.</value>
        [JsonProperty("temporal_amount")]
        public int? TemporalAmount { get; set; }

        /// <value>If `duration` is "temporal" than `temporal_unit` is multiplied by `temporal_amount` to define the duration that the coupon will be applied to invoices for.</value>
        [JsonProperty("temporal_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.TemporalUnit? TemporalUnit { get; set; }

        /// <value>On a bulk coupon, the template from which unique coupon codes are generated.</value>
        [JsonProperty("unique_code_template")]
        public string UniqueCodeTemplate { get; set; }

        /// <value>Will be populated when the Coupon being returned is a `UniqueCouponCode`.</value>
        [JsonProperty("unique_coupon_code")]
        public Dictionary<string, string> UniqueCouponCode { get; set; }

        /// <value>When this number reaches `max_redemptions` the coupon will no longer be redeemable.</value>
        [JsonProperty("unique_coupon_codes_count")]
        public int? UniqueCouponCodesCount { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
