using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionAddOnCreate : Request {
  
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
