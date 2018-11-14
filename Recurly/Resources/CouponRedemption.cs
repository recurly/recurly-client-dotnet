using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponRedemption : Resource {
  
    /// <value>The Account ID on which the coupon was applied.</value>
    [DeserializeAs(Name = "account_id")]
    public string AccountId { get; set; }
  
    
    [DeserializeAs(Name = "coupon")]
    public Coupon Coupon { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>The amount that was discounted upon the application of the coupon, formatted with the currency.</value>
    [DeserializeAs(Name = "discounted")]
    public string Discounted { get; set; }
  
    /// <value>Coupon Redemption ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>The date and time the redemption was removed from the account (un-redeemed).</value>
    [DeserializeAs(Name = "removed_at")]
    public DateTime? RemovedAt { get; set; }
  
    /// <value>Coupon Redemption state</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
