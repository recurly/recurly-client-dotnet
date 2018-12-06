using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponDiscountPricing : Resource {
  
    /// <value>Value of the fixed discount that this coupon applies.</value>
    [JsonProperty("amount")]
    public float? Amount { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
  }
}
