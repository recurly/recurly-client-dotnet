using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionAddOn : Resource {
  
    
    [DeserializeAs(Name = "add_on")]
    public AddOnMini AddOn { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Expired at</value>
    [DeserializeAs(Name = "expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Subscription Add-on ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Add-on quantity</value>
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    /// <value>Subscription ID</value>
    [DeserializeAs(Name = "subscription_id")]
    public string SubscriptionId { get; set; }
  
    /// <value>This is priced in the subscription's currency.</value>
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
    /// <value>Updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
