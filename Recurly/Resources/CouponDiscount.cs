using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponDiscount : Resource {
  
    /// <value>This is only present when `type=fixed`.</value>
    [DeserializeAs(Name = "currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    /// <value>This is only present when `type=percent`.</value>
    [DeserializeAs(Name = "percent")]
    public int? Percent { get; set; }
  
    /// <value>This is only present when `type=free_trial`.</value>
    [DeserializeAs(Name = "trial")]
    public Dictionary<string, string> Trial { get; set; }
  
    
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
  }
}
