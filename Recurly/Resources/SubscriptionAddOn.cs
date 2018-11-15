using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class SubscriptionAddOn : Resource {
  
    
    [JsonProperty("add_on")]
    public AddOnMini AddOn { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Expired at</value>
    [JsonProperty("expired_at")]
    public DateTime? ExpiredAt { get; set; }
  
    /// <value>Subscription Add-on ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>Add-on quantity</value>
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    /// <value>Subscription ID</value>
    [JsonProperty("subscription_id")]
    public string SubscriptionId { get; set; }
  
    /// <value>This is priced in the subscription's currency.</value>
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
    /// <value>Updated at</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
