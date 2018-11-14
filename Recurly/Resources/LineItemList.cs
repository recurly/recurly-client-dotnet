using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class LineItemList : Resource {
  
    
    [DeserializeAs(Name = "data")]
    public List<LineItem> Data { get; set; }
  
    /// <value>Indicates there are more results on subsequent pages.</value>
    [DeserializeAs(Name = "has_more")]
    public bool? HasMore { get; set; }
  
    /// <value>Path to subsequent page of results.</value>
    [DeserializeAs(Name = "next")]
    public string Next { get; set; }
  
  }
}
