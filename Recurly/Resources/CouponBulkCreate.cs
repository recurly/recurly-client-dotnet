using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CouponBulkCreate : Request {
  
    [JsonProperty("number_of_unique_codes")]
    public int? NumberOfUniqueCodes { get; set; }
  
  }
}
