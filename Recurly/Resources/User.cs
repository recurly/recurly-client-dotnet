using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class User : Resource {
  
    
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    
    [DeserializeAs(Name = "time_zone")]
    public string TimeZone { get; set; }
  
  }
}
