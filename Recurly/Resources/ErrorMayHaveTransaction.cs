using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class ErrorMayHaveTransaction : Resource {
  
    /// <value>Message</value>
    [DeserializeAs(Name = "message")]
    public string Message { get; set; }
  
    /// <value>Parameter specific errors</value>
    [DeserializeAs(Name = "params")]
    public List<Dictionary<string, string>> Params { get; set; }
  
    /// <value>This is only included on errors with `type=transaction`.</value>
    [DeserializeAs(Name = "transaction_error")]
    public Dictionary<string, string> TransactionError { get; set; }
  
    /// <value>Type</value>
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
  }
}
