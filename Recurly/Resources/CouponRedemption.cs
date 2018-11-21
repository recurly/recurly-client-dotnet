using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponRedemption : Resource {
  
    /// <value>The Account ID on which the coupon was applied.</value>
    [JsonProperty("account_id")]
    public string AccountId { get; set; }
  
    
    [JsonProperty("coupon")]
    public Coupon Coupon { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
    [JsonProperty("discounted")]
    public string Discounted { get; set; }
  
    /// <value>Coupon Redemption ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>The date and time the redemption was removed from the account (un-redeemed).</value>
    [JsonProperty("removed_at")]
    public DateTime? RemovedAt { get; set; }
  
    /// <value>Coupon Redemption state</value>
    [JsonProperty("state")]
    public string State { get; set; }
  
    /// <value>Last updated at</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
