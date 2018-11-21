using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class Error : Resource {
  
    /// <value>Message</value>
    [JsonProperty("message")]
    public string Message { get; set; }
  
    /// <value>Parameter specific errors</value>
    [JsonProperty("params")]
    public List<Dictionary<string, string>> Params { get; set; }
  
    /// <value>Type</value>
    [JsonProperty("type")]
    public ApiErrorType Type { get; set; }
  
  }
}
