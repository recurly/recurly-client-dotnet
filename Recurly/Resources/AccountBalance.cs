using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AccountBalance : Resource {
  
    
    [JsonProperty("account")]
    public AccountMini Account { get; set; }
  
    /// <value>Account balance</value>
    [JsonProperty("balances")]
    public Dictionary<string, string> Balances { get; set; }
  
    
    [JsonProperty("past_due")]
    public bool? PastDue { get; set; }
  
  }
}
