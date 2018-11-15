using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class ErrorMayHaveTransaction : Resource {
  
    /// <value>Message</value>
    [JsonProperty("message")]
    public string Message { get; set; }
  
    /// <value>Parameter specific errors</value>
    [JsonProperty("params")]
    public List<Dictionary<string, string>> Params { get; set; }
  
    /// <value>This is only included on errors with `type=transaction`.</value>
    [JsonProperty("transaction_error")]
    public Dictionary<string, string> TransactionError { get; set; }
  
    /// <value>Type</value>
    [JsonProperty("type")]
    public string Type { get; set; }
  
  }
}
