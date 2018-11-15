using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class Site : Resource {
  
    
    [JsonProperty("address")]
    public Address Address { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Deleted at</value>
    [JsonProperty("deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>A list of features enabled for the site.</value>
    [JsonProperty("features")]
    public List<string> Features { get; set; }
  
    /// <value>Site ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>Mode</value>
    [JsonProperty("mode")]
    public string Mode { get; set; }
  
    /// <value>This value is used to configure RecurlyJS to submit tokenized billing information.</value>
    [JsonProperty("public_api_key")]
    public string PublicApiKey { get; set; }
  
    
    [JsonProperty("settings")]
    public Settings Settings { get; set; }
  
    
    [JsonProperty("subdomain")]
    public string Subdomain { get; set; }
  
    /// <value>Updated at</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
