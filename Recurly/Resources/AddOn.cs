using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AddOn : Resource {
  
    /// <value>Accounting code for invoice line items for this add-on. If no value is provided, it defaults to add-on's code.</value>
    [DeserializeAs(Name = "accounting_code")]
    public string AccountingCode { get; set; }
  
    /// <value>The unique identifier for the add-on within its plan.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Add-on pricing</value>
    [DeserializeAs(Name = "currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    /// <value>Default quantity for the hosted pages.</value>
    [DeserializeAs(Name = "default_quantity")]
    public int? DefaultQuantity { get; set; }
  
    /// <value>Deleted at</value>
    [DeserializeAs(Name = "deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>Determines if the quantity field is displayed on the hosted pages for the add-on.</value>
    [DeserializeAs(Name = "display_quantity")]
    public bool? DisplayQuantity { get; set; }
  
    /// <value>Add-on ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Describes your add-on and will appear in subscribers' invoices.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>Plan ID</value>
    [DeserializeAs(Name = "plan_id")]
    public string PlanId { get; set; }
  
    /// <value>Add-ons can be either active or inactive.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>Optional field for EU VAT merchants and Avalara AvaTax Pro merchants. If you are using Recurly's EU VAT feature, you can use values of 'unknown', 'physical', or 'digital'. If you have your own AvaTax account configured, you can use Avalara tax codes to assign custom tax rules.</value>
    [DeserializeAs(Name = "tax_code")]
    public string TaxCode { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
