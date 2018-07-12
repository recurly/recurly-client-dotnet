using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionChangeCreate : Request {
  
    [DeserializeAs(Name = "add_ons")]
    public List<SubscriptionAddOnCreate> AddOns { get; set; }
  
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    [DeserializeAs(Name = "coupon_codes")]
    public List<string> CouponCodes { get; set; }
  
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    [DeserializeAs(Name = "plan_code")]
    public string PlanCode { get; set; }
  
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    [DeserializeAs(Name = "timeframe")]
    public string Timeframe { get; set; }
  
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
