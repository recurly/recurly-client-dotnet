using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponRedemptionMini : Resource {
  
    
    [JsonProperty("coupon")]
    public CouponMini Coupon { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
    [JsonProperty("discounted")]
    public string Discounted { get; set; }
  
    /// <value>Coupon Redemption ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>Invoice state</value>
    [JsonProperty("state")]
    public string State { get; set; }
  
  }
}
