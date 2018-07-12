using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CustomFieldDefinition : Resource {
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Definitions are initially soft deleted, and once all the values are removed from the accouts or subscriptions, will be hard deleted an no longer visible.</value>
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>Used to label the field when viewing and editing the field in Recurly's admin UI.</value>
    [DeserializeAs(Name = "display_name")]
    public string DisplayName { get; set; }
  
    /// <value>Custom field definition ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Used by the API to identify the field or reading and writing. The name can only be used once per Recurly object type.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>Related Recurly object type</value>
    [DeserializeAs(Name = "related_type")]
    public string RelatedType { get; set; }
  
    /// <value>Displayed as a tooltip when editing the field in the Recurly admin UI.</value>
    [DeserializeAs(Name = "tooltip")]
    public string Tooltip { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>
    /// The access control applied inside Recurly's admin UI:
    /// - `api_only` - No one will be able to view or edit this field's data via the admin UI.
    /// - `read_only` - Users with the Customers role will be able to view this field's data via the admin UI, but
    ///   editing will only be available via the API.
    /// - `write` - Users with the Customers role will be able to view and edit this field's data via the admin UI.
    /// </value>
    [DeserializeAs(Name = "user_access")]
    public string UserAccess { get; set; }
  
  }
}
