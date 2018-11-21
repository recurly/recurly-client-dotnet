using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class UniqueCouponCode : Resource {
  
    /// <value>The code the customer enters to redeem the coupon.</value>
    [JsonProperty("code")]
    public string Code { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>The date and time the coupon was expired early or reached its `max_redemptions`.</value>
    [JsonProperty("expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Unique Coupon Code ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>The date and time the unique coupon code was redeemed.</value>
    [JsonProperty("redeemed_at")]
    public DateTime? RedeemedAt { get; set; }
  
    /// <value>Indicates if the unique coupon code is redeemable or why not.</value>
    [JsonProperty("state")]
    public string State { get; set; }
  
    /// <value>Updated at</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
