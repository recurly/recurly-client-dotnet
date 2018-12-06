using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponDiscount : Resource {
  
    /// <value>This is only present when `type=fixed`.</value>
    [JsonProperty("currencies")]
    public List<CouponDiscountPricing> Currencies { get; set; }
  
    /// <value>This is only present when `type=percent`.</value>
    [JsonProperty("percent")]
    public int? Percent { get; set; }
  
    /// <value>This is only present when `type=free_trial`.</value>
    [JsonProperty("trial")]
    public Dictionary<string, string> Trial { get; set; }
  
    
    [JsonProperty("type")]
    public string Type { get; set; }
  
  }
}
