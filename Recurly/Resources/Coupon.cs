using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Coupon : Resource {
  
    /// <value>The coupon is valid for all plans if true. If false then `plans` and `plans_names` will list the applicable plans.</value>
    [DeserializeAs(Name = "applies_to_all_plans")]
    public bool? AppliesToAllPlans { get; set; }
  
    /// <value>The coupon is valid for one-time, non-plan charges if true.</value>
    [DeserializeAs(Name = "applies_to_non_plan_charges")]
    public bool? AppliesToNonPlanCharges { get; set; }
  
    /// <value>The code the customer enters to redeem the coupon.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    /// <value>Whether the coupon is "single_code" or "bulk". Bulk coupons will require a `unique_code_template` and will generate unique codes through the `/generate` endpoint.</value>
    [DeserializeAs(Name = "coupon_type")]
    public string CouponType { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "discount")]
    public CouponDiscount Discount { get; set; }
  
    /// <value>
    /// - "single_use" coupons applies to the first invoice only.
    /// - "temporal" coupons will apply to invoices for the duration determined by the `temporal_unit` and `temporal_amount` attributes.
    /// </value>
    [DeserializeAs(Name = "duration")]
    public string Duration { get; set; }
  
    /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
    [DeserializeAs(Name = "expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Sets the duration of time the `free_trial_unit` is for.</value>
    [DeserializeAs(Name = "free_trial_amount")]
    public int? FreeTrialAmount { get; set; }
  
    /// <value>Description of the unit of time the coupon is for. Used with `free_trial_amount` to determine the duration of time the coupon is for.</value>
    [DeserializeAs(Name = "free_trial_unit")]
    public string FreeTrialUnit { get; set; }
  
    /// <value>This description will show up when a customer redeems a coupon on your Hosted Payment Pages, or if you choose to show the description on your own checkout page.</value>
    [DeserializeAs(Name = "hosted_page_description")]
    public string HostedPageDescription { get; set; }
  
    /// <value>Coupon ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Description of the coupon on the invoice.</value>
    [DeserializeAs(Name = "invoice_description")]
    public string InvoiceDescription { get; set; }
  
    /// <value>A maximum number of redemptions for the coupon. The coupon will expire when it hits its maximum redemptions.</value>
    [DeserializeAs(Name = "max_redemptions")]
    public int? MaxRedemptions { get; set; }
  
    /// <value>Redemptions per account is the number of times a specific account can redeem the coupon. Set redemptions per account to `1` if you want to keep customers from gaming the system and getting more than one discount from the coupon campaign.</value>
    [DeserializeAs(Name = "max_redemptions_per_account")]
    public int? MaxRedemptionsPerAccount { get; set; }
  
    /// <value>The internal name for the coupon.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    /// <value>Plans</value>
    [DeserializeAs(Name = "plans")]
    public List<PlanMini> Plans { get; set; }
  
    /// <value>TODO</value>
    [DeserializeAs(Name = "plans_names")]
    public List<string> PlansNames { get; set; }
  
    /// <value>The date and time the coupon will expire and can no longer be redeemed. Time is always 11:59:59, the end-of-day Pacific time.</value>
    [DeserializeAs(Name = "redeem_by")]
    public DateTime? RedeemBy { get; set; }
  
    /// <value>Whether the discount is for all eligible charges on the account, or only a specific subscription.</value>
    [DeserializeAs(Name = "redemption_resource")]
    public string RedemptionResource { get; set; }
  
    /// <value>Indicates if the coupon is redeemable, and if it is not, why.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>If `duration` is "temporal" than `temporal_amount` is an integer which is multiplied by `temporal_unit` to define the duration that the coupon will be applied to invoices for.</value>
    [DeserializeAs(Name = "temporal_amount")]
    public int? TemporalAmount { get; set; }
  
    /// <value>If `duration` is "temporal" than `temporal_unit` is multiplied by `temporal_amount` to define the duration that the coupon will be applied to invoices for.</value>
    [DeserializeAs(Name = "temporal_unit")]
    public string TemporalUnit { get; set; }
  
    /// <value>When this number reaches `max_redemptions` the coupon will no longer be redeemable.</value>
    [DeserializeAs(Name = "unique_coupon_codes_count")]
    public int? UniqueCouponCodesCount { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
