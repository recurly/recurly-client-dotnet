using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponRedemptionCreate : Request {
  
    [DeserializeAs(Name = "coupon_id")]
    public string CouponId { get; set; }
  
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
  }
}
