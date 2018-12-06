using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponCreate : Request {
  
    [JsonProperty("applies_to_all_plans")]
    public bool? AppliesToAllPlans { get; set; }
  
    [JsonProperty("applies_to_non_plan_charges")]
    public bool? AppliesToNonPlanCharges { get; set; }
  
    [JsonProperty("code")]
    public string Code { get; set; }
  
    [JsonProperty("coupon_type")]
    public string CouponType { get; set; }
  
    [JsonProperty("currencies")]
    public List<CouponPricing> Currencies { get; set; }
  
    [JsonProperty("discount_percent")]
    public int? DiscountPercent { get; set; }
  
    [JsonProperty("discount_type")]
    public string DiscountType { get; set; }
  
    [JsonProperty("duration")]
    public string Duration { get; set; }
  
    [JsonProperty("free_trial_amount")]
    public int? FreeTrialAmount { get; set; }
  
    [JsonProperty("free_trial_unit")]
    public string FreeTrialUnit { get; set; }
  
    [JsonProperty("hosted_description")]
    public string HostedDescription { get; set; }
  
    [JsonProperty("invoice_description")]
    public string InvoiceDescription { get; set; }
  
    [JsonProperty("max_redemptions")]
    public int? MaxRedemptions { get; set; }
  
    [JsonProperty("max_redemptions_per_account")]
    public int? MaxRedemptionsPerAccount { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("plan_codes")]
    public List<string> PlanCodes { get; set; }
  
    [JsonProperty("redeem_by_date")]
    public string RedeemByDate { get; set; }
  
    [JsonProperty("redemption_resource")]
    public string RedemptionResource { get; set; }
  
    [JsonProperty("temporal_amount")]
    public int? TemporalAmount { get; set; }
  
    [JsonProperty("temporal_unit")]
    public string TemporalUnit { get; set; }
  
    [JsonProperty("unique_code_template")]
    public string UniqueCodeTemplate { get; set; }
  
  }
}
