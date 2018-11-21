using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponRedemptionCreate : Request {
  
    [JsonProperty("coupon_id")]
    public string CouponId { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
  }
}
