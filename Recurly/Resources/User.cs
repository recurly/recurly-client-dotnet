using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class User : Resource {
  
    
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [JsonProperty("deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    
    [JsonProperty("email")]
    public string Email { get; set; }
  
    
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    
    [JsonProperty("id")]
    public string Id { get; set; }
  
    
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    
    [JsonProperty("time_zone")]
    public string TimeZone { get; set; }
  
  }
}
