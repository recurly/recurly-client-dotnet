using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponCreate : Request {
  
    [DeserializeAs(Name = "applies_to_all_plans")]
    public bool? AppliesToAllPlans { get; set; }
  
    [DeserializeAs(Name = "applies_to_non_plan_charges")]
    public bool? AppliesToNonPlanCharges { get; set; }
  
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    [DeserializeAs(Name = "coupon_type")]
    public string CouponType { get; set; }
  
    [DeserializeAs(Name = "currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    [DeserializeAs(Name = "discount_percent")]
    public int? DiscountPercent { get; set; }
  
    [DeserializeAs(Name = "discount_type")]
    public string DiscountType { get; set; }
  
    [DeserializeAs(Name = "duration")]
    public string Duration { get; set; }
  
    [DeserializeAs(Name = "free_trial_amount")]
    public int? FreeTrialAmount { get; set; }
  
    [DeserializeAs(Name = "free_trial_unit")]
    public string FreeTrialUnit { get; set; }
  
    [DeserializeAs(Name = "hosted_description")]
    public string HostedDescription { get; set; }
  
    [DeserializeAs(Name = "invoice_description")]
    public string InvoiceDescription { get; set; }
  
    [DeserializeAs(Name = "max_redemptions")]
    public int? MaxRedemptions { get; set; }
  
    [DeserializeAs(Name = "max_redemptions_per_account")]
    public int? MaxRedemptionsPerAccount { get; set; }
  
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    [DeserializeAs(Name = "plan_codes")]
    public List<string> PlanCodes { get; set; }
  
    [DeserializeAs(Name = "redeem_by_date")]
    public string RedeemByDate { get; set; }
  
    [DeserializeAs(Name = "redemption_resource")]
    public string RedemptionResource { get; set; }
  
    [DeserializeAs(Name = "temporal_amount")]
    public int? TemporalAmount { get; set; }
  
    [DeserializeAs(Name = "temporal_unit")]
    public string TemporalUnit { get; set; }
  
    [DeserializeAs(Name = "unique_code_template")]
    public string UniqueCodeTemplate { get; set; }
  
  }
}
