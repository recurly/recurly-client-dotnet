using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class LineItemList : Resource {
  
    
    [JsonProperty("data")]
    public List<LineItem> Data { get; set; }
  
    /// <value>Indicates there are more results on subsequent pages.</value>
    [JsonProperty("has_more")]
    public bool? HasMore { get; set; }
  
    /// <value>Path to subsequent page of results.</value>
    [JsonProperty("next")]
    public string Next { get; set; }
  
  }
}
