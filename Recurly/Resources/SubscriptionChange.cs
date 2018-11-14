using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionChange : Resource {
  
    /// <value>Activated at</value>
    [DeserializeAs(Name = "activate_at")]
    public DateTime? ActivateAt { get; set; }
  
    /// <value>Returns `true` if the subscription change is activated.</value>
    [DeserializeAs(Name = "activated")]
    public bool? Activated { get; set; }
  
    /// <value>These add-ons will be used when the subscription renews.</value>
    [DeserializeAs(Name = "add_ons")]
    public List<SubscriptionAddOn> AddOns { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Deleted at</value>
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>The ID of the Subscription Change.</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "plan")]
    public PlanMini Plan { get; set; }
  
    /// <value>Subscription quantity</value>
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    /// <value>The ID of the subscription that is going to be changed.</value>
    [DeserializeAs(Name = "subscription_id")]
    public string SubscriptionId { get; set; }
  
    /// <value>Unit amount</value>
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
    /// <value>Updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
