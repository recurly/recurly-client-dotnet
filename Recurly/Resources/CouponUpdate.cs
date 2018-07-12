using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponUpdate : Request {
  
    [DeserializeAs(Name = "hosted_description")]
    public string HostedDescription { get; set; }
  
    [DeserializeAs(Name = "invoice_description")]
    public string InvoiceDescription { get; set; }
  
    [DeserializeAs(Name = "max_redemptions")]
    public int? MaxRedemptions { get; set; }
  
    [DeserializeAs(Name = "max_redemptions_per_account")]
    public int? MaxRedemptionsPerAccount { get; set; }
  
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    [DeserializeAs(Name = "redeem_by_date")]
    public string RedeemByDate { get; set; }
  
  }
}
