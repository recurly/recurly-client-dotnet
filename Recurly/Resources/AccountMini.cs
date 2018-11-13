using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountMini : Resource {
  
    /// <value>The unique identifier of the account.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    /// <value>The email address used for communicating with this customer.</value>
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
  }
}
