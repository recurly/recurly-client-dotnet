using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponPricing : Request {
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    /// <value>The fixed discount (in dollars) for the corresponding currency.</value>
    [JsonProperty("discount")]
    public float? Discount { get; set; }
  
  }
}
