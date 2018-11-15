using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class CouponBulkCreate : Request {
  
    [JsonProperty("number_of_unique_codes")]
    public int? NumberOfUniqueCodes { get; set; }
  
  }
}
