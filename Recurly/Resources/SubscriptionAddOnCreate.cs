using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
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
