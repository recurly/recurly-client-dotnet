using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class LineItemRefund : Request {
  
    [JsonProperty("id")]
    public string Id { get; set; }
  
    [JsonProperty("prorate")]
    public bool? Prorate { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
  }
}
