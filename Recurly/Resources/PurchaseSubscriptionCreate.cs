using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class PurchaseSubscriptionCreate : Request {
  
    [DeserializeAs(Name = "add_ons")]
    public List<SubscriptionAddOnCreate> AddOns { get; set; }
  
    [DeserializeAs(Name = "auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [DeserializeAs(Name = "custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [DeserializeAs(Name = "next_bill_date")]
    public DateTime? NextBillDate { get; set; }
  
    [DeserializeAs(Name = "plan_code")]
    public string PlanCode { get; set; }
  
    [DeserializeAs(Name = "plan_id")]
    public string PlanId { get; set; }
  
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    [DeserializeAs(Name = "renewal_billing_cycles")]
    public int? RenewalBillingCycles { get; set; }
  
    [DeserializeAs(Name = "shipping_address")]
    public Dictionary<string, string> ShippingAddress { get; set; }
  
    [DeserializeAs(Name = "shipping_address_id")]
    public string ShippingAddressId { get; set; }
  
    [DeserializeAs(Name = "total_billing_cycles")]
    public int? TotalBillingCycles { get; set; }
  
    [DeserializeAs(Name = "trial_ends_at")]
    public DateTime? TrialEndsAt { get; set; }
  
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
