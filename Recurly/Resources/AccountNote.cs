using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AccountNote : Resource {
  
    
    [JsonProperty("account_id")]
    public string AccountId { get; set; }
  
    
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [JsonProperty("id")]
    public string Id { get; set; }
  
    
    [JsonProperty("message")]
    public string Message { get; set; }
  
    
    [JsonProperty("user")]
    public User User { get; set; }
  
  }
}
