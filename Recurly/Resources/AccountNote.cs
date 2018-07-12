using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountNote : Resource {
  
    
    [DeserializeAs(Name = "account_id")]
    public string AccountId { get; set; }
  
    
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "message")]
    public string Message { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    
    [DeserializeAs(Name = "user")]
    public User User { get; set; }
  
  }
}
