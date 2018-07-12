using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountAcquisition : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>An arbitrary identifier for the marketing campaign that led to the acquisition of this account.</value>
    [DeserializeAs(Name = "campaign")]
    public string Campaign { get; set; }
  
    /// <value>The channel through which the account was acquired.</value>
    [DeserializeAs(Name = "channel")]
    public string Channel { get; set; }
  
    /// <value>Account balance</value>
    [DeserializeAs(Name = "cost")]
    public Dictionary<string, string> Cost { get; set; }
  
    /// <value>When the account acquisition data was created.</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>An arbitrary subchannel string representing a distinction/subcategory within a broader channel.</value>
    [DeserializeAs(Name = "subchannel")]
    public string Subchannel { get; set; }
  
    /// <value>When the account acquisition data was last changed.</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
