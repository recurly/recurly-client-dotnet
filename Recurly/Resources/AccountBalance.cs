using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountBalance : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>Account balance</value>
    [DeserializeAs(Name = "balances")]
    public Dictionary<string, string> Balances { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    
    [DeserializeAs(Name = "past_due")]
    public bool? PastDue { get; set; }
  
  }
}
