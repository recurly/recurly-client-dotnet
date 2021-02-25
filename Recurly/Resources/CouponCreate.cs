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
    public class CouponCreate : Request
    {

        /// <value>
        /// To apply coupon to Items in your Catalog, include a list
        /// of `item_codes` in the request that the coupon will apply to. Or set value
        /// to true to apply to all Items in your Catalog. The following values
        /// are not permitted when `applies_to_all_items` is included: `free_trial_amount`
        /// and `free_trial_unit`.
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

        /// <value>Fixed discount currencies by currency. Required if the coupon type is `fixed`. This parameter should contain the coupon discount values</value>
        [JsonProperty("currencies")]
        public List<CouponPricing> Currencies { get; set; }

        /// <value>The percent of the price discounted by the coupon.  Required if `discount_type` is `percent`.</value>
        [JsonProperty("discount_percent")]
        public int? DiscountPercent { get; set; }

        /// <value>The type of discount provided by the coupon (how the amount discounted is calculated)</value>
        [JsonProperty("discount_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.DiscountType? DiscountType { get; set; }

        /// <value>
        /// This field does not apply when the discount_type is `free_trial`.
        /// - "single_use" coupons applies to the first invoice only.
        /// - "temporal" coupons will apply to invoices for the duration determined by the `temporal_unit` and `temporal_amount` attributes.
        /// - "forever" coupons will apply to invoices forever.
        /// </value>
        [JsonProperty("duration")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CouponDuration? Duration { get; set; }

        /// <value>Sets the duration of time the `free_trial_unit` is for. Required if `discount_type` is `free_trial`.</value>
        [JsonProperty("free_trial_amount")]
        public int? FreeTrialAmount { get; set; }

        /// <value>Description of the unit of time the coupon is for. Used with `free_trial_amount` to determine the duration of time the coupon is for.  Required if `discount_type` is `free_trial`.</value>
        [JsonProperty("free_trial_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.FreeTrialUnit? FreeTrialUnit { get; set; }

        /// <value>This description will show up when a customer redeems a coupon on your Hosted Payment Pages, or if you choose to show the description on your own checkout page.</value>
        [JsonProperty("hosted_description")]
        public string HostedDescription { get; set; }

        /// <value>Description of the coupon on the invoice.</value>
        [JsonProperty("invoice_description")]
        public string InvoiceDescription { get; set; }

        /// <value>
        /// List of item codes to which this coupon applies. Sending
        /// `item_codes` is only permitted when `applies_to_all_items` is set to false.
        /// The following values are not permitted when `item_codes` is included:
        /// `free_trial_amount` and `free_trial_unit`.
        /// </value>
        [JsonProperty("item_codes")]
        public List<string> ItemCodes { get; set; }

        /// <value>A maximum number of redemptions for the coupon. The coupon will expire when it hits its maximum redemptions.</value>
        [JsonProperty("max_redemptions")]
        public int? MaxRedemptions { get; set; }

        /// <value>Redemptions per account is the number of times a specific account can redeem the coupon. Set redemptions per account to `1` if you want to keep customers from gaming the system and getting more than one discount from the coupon campaign.</value>
        [JsonProperty("max_redemptions_per_account")]
        public int? MaxRedemptionsPerAccount { get; set; }

        /// <value>The internal name for the coupon.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>
        /// List of plan codes to which this coupon applies. Required
        /// if `applies_to_all_plans` is false. Overrides `applies_to_all_plans`
        /// when `applies_to_all_plans` is true.
        /// </value>
        [JsonProperty("plan_codes")]
        public List<string> PlanCodes { get; set; }

        /// <value>The date and time the coupon will expire and can no longer be redeemed. Time is always 11:59:59, the end-of-day Pacific time.</value>
        [JsonProperty("redeem_by_date")]
        public string RedeemByDate { get; set; }

        /// <value>Whether the discount is for all eligible charges on the account, or only a specific subscription.</value>
        [JsonProperty("redemption_resource")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RedemptionResource? RedemptionResource { get; set; }

        /// <value>If `duration` is "temporal" than `temporal_amount` is an integer which is multiplied by `temporal_unit` to define the duration that the coupon will be applied to invoices for.</value>
        [JsonProperty("temporal_amount")]
        public int? TemporalAmount { get; set; }

        /// <value>If `duration` is "temporal" than `temporal_unit` is multiplied by `temporal_amount` to define the duration that the coupon will be applied to invoices for.</value>
        [JsonProperty("temporal_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.TemporalUnit? TemporalUnit { get; set; }

        /// <value>
        /// On a bulk coupon, the template from which unique coupon codes are generated.
        /// - You must start the template with your coupon_code wrapped in single quotes.
        /// - Outside of single quotes, use a 9 for a character that you want to be a random number.
        /// - Outside of single quotes, use an "x" for a character that you want to be a random letter.
        /// - Outside of single quotes, use an * for a character that you want to be a random number or letter.
        /// - Use single quotes ' ' for characters that you want to remain static. These strings can be alphanumeric and may contain a - _ or +.
        /// For example: "'abc-'****'-def'"
        /// </value>
        [JsonProperty("unique_code_template")]
        public string UniqueCodeTemplate { get; set; }

    }
}
