using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class CouponUpdate : Request {
  
    [JsonProperty("hosted_description")]
    public string HostedDescription { get; set; }
  
    [JsonProperty("invoice_description")]
    public string InvoiceDescription { get; set; }
  
    [JsonProperty("max_redemptions")]
    public int? MaxRedemptions { get; set; }
  
    [JsonProperty("max_redemptions_per_account")]
    public int? MaxRedemptionsPerAccount { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("redeem_by_date")]
    public string RedeemByDate { get; set; }
  
  }
}
