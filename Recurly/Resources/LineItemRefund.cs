using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class LineItemRefund : Request {
  
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    [DeserializeAs(Name = "prorate")]
    public bool? Prorate { get; set; }
  
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
  }
}
