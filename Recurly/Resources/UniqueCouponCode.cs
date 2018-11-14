using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class UniqueCouponCode : Resource {
  
    /// <value>The code the customer enters to redeem the coupon.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
    [DeserializeAs(Name = "expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Unique Coupon Code ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>The date and time the unique coupon code was redeemed.</value>
    [DeserializeAs(Name = "redeemed_at")]
    public DateTime? RedeemedAt { get; set; }
  
    /// <value>Indicates if the unique coupon code is redeemable or why not.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>Updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
