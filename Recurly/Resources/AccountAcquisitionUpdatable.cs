using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AccountAcquisitionUpdatable : Request {
  
    [JsonProperty("campaign")]
    public string Campaign { get; set; }
  
    [JsonProperty("channel")]
    public string Channel { get; set; }
  
    [JsonProperty("cost")]
    public Dictionary<string, string> Cost { get; set; }
  
    [JsonProperty("subchannel")]
    public string Subchannel { get; set; }
  
  }
}
