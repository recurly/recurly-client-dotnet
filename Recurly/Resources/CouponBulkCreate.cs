using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CouponBulkCreate : Request {
  
    [DeserializeAs(Name = "number_of_unique_codes")]
    public int? NumberOfUniqueCodes { get; set; }
  
  }
}
