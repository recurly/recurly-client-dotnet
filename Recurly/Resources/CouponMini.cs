using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponMini : Resource {
  
    /// <value>The code the customer enters to redeem the coupon.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    /// <value>Whether the coupon is "single_code" or "bulk". Bulk coupons will require a `unique_code_template` and will generate unique codes through the `/generate` endpoint.</value>
    [DeserializeAs(Name = "coupon_type")]
    public string CouponType { get; set; }
  
    
    [DeserializeAs(Name = "discount")]
    public CouponDiscount Discount { get; set; }
  
    /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
    [DeserializeAs(Name = "expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Coupon ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>The internal name for the coupon.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>Indicates if the coupon is redeemable, and if it is not, why.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
  }
}
