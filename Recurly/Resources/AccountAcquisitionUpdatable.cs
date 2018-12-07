using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AccountAcquisitionUpdatable : Request {
  
    /// <value>An arbitrary identifier for the marketing campaign that led to the acquisition of this account.</value>
    [JsonProperty("campaign")]
    public string Campaign { get; set; }
  
    /// <value>The channel through which the account was acquired.</value>
    [JsonProperty("channel")]
    public string Channel { get; set; }
  
    /// <value>Account balance</value>
    [JsonProperty("cost")]
    public Dictionary<string, string> Cost { get; set; }
  
    /// <value>An arbitrary subchannel string representing a distinction/subcategory within a broader channel.</value>
    [JsonProperty("subchannel")]
    public string Subchannel { get; set; }
  
  }
}
