using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Site : Resource {
  
    
    [DeserializeAs(Name = "address")]
    public Address Address { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Deleted at</value>
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>A list of features enabled for the site.</value>
    [DeserializeAs(Name = "features")]
    public List<string> Features { get; set; }
  
    /// <value>Site ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Mode</value>
    [DeserializeAs(Name = "mode")]
    public string Mode { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>This value is used to configure RecurlyJS to submit tokenized billing information.</value>
    [DeserializeAs(Name = "public_api_key")]
    public string PublicApiKey { get; set; }
  
    
    [DeserializeAs(Name = "settings")]
    public Settings Settings { get; set; }
  
    
    [DeserializeAs(Name = "subdomain")]
    public string Subdomain { get; set; }
  
    /// <value>Updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
