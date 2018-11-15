using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class SubscriptionChangeCreate : Request {
  
    [JsonProperty("add_ons")]
    public List<SubscriptionAddOnCreate> AddOns { get; set; }
  
    [JsonProperty("collection_method")]
    public string CollectionMethod { get; set; }
  
    [JsonProperty("coupon_codes")]
    public List<string> CouponCodes { get; set; }
  
    [JsonProperty("net_terms")]
    public int? NetTerms { get; set; }
  
    [JsonProperty("plan_code")]
    public string PlanCode { get; set; }
  
    [JsonProperty("po_number")]
    public string PoNumber { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    [JsonProperty("timeframe")]
    public string Timeframe { get; set; }
  
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
