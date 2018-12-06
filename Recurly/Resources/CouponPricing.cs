using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponPricing : Request {
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("discount")]
    public float? Discount { get; set; }
  
  }
}
