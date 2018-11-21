using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponMini : Resource {
  
    /// <value>The code the customer enters to redeem the coupon.</value>
    [JsonProperty("code")]
    public string Code { get; set; }
  
    /// <value>Whether the coupon is "single_code" or "bulk". Bulk coupons will require a `unique_code_template` and will generate unique codes through the `/generate` endpoint.</value>
    [JsonProperty("coupon_type")]
    public string CouponType { get; set; }
  
    
    [JsonProperty("discount")]
    public CouponDiscount Discount { get; set; }
  
    /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
    [JsonProperty("expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Coupon ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>The internal name for the coupon.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
    /// <value>Indicates if the coupon is redeemable, and if it is not, why.</value>
    [JsonProperty("state")]
    public string State { get; set; }
  
  }
}
