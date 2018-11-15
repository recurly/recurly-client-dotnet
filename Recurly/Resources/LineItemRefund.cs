using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class LineItemRefund : Request {
  
    [JsonProperty("id")]
    public string Id { get; set; }
  
    [JsonProperty("prorate")]
    public bool? Prorate { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
  }
}
