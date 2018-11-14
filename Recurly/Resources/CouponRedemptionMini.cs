using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponRedemptionMini : Resource {
  
    
    [DeserializeAs(Name = "coupon")]
    public CouponMini Coupon { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
    [DeserializeAs(Name = "discounted")]
    public string Discounted { get; set; }
  
    /// <value>Coupon Redemption ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Invoice state</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
  }
}
