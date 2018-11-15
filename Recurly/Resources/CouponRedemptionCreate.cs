using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class CouponRedemptionCreate : Request {
  
    [JsonProperty("coupon_id")]
    public string CouponId { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
  }
}
