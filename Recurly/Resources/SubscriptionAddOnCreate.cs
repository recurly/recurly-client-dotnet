using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class SubscriptionAddOnCreate : Request {
  
    [JsonProperty("code")]
    public string Code { get; set; }
  
    [JsonProperty("id")]
    public string Id { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
