using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class SubscriptionCreate : Request {
  
    [JsonProperty("account")]
    public AccountCreate Account { get; set; }
  
    [JsonProperty("add_ons")]
    public List<SubscriptionAddOnCreate> AddOns { get; set; }
  
    [JsonProperty("auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [JsonProperty("collection_method")]
    public string CollectionMethod { get; set; }
  
    [JsonProperty("coupon_code")]
    public string CouponCode { get; set; }
  
    [JsonProperty("credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [JsonProperty("customer_notes")]
    public string CustomerNotes { get; set; }
  
    [JsonProperty("net_terms")]
    public int? NetTerms { get; set; }
  
    [JsonProperty("next_bill_date")]
    public DateTime? NextBillDate { get; set; }
  
    [JsonProperty("plan_code")]
    public string PlanCode { get; set; }
  
    [JsonProperty("plan_id")]
    public string PlanId { get; set; }
  
    [JsonProperty("po_number")]
    public string PoNumber { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    [JsonProperty("renewal_billing_cycles")]
    public int? RenewalBillingCycles { get; set; }
  
    [JsonProperty("shipping_address")]
    public Dictionary<string, string> ShippingAddress { get; set; }
  
    [JsonProperty("shipping_address_id")]
    public string ShippingAddressId { get; set; }
  
    [JsonProperty("starts_at")]
    public DateTime? StartsAt { get; set; }
  
    [JsonProperty("terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [JsonProperty("total_billing_cycles")]
    public int? TotalBillingCycles { get; set; }
  
    [JsonProperty("trial_ends_at")]
    public DateTime? TrialEndsAt { get; set; }
  
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
