using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AddOnMini : Resource {
  
    /// <value>Accounting code for invoice line items for this add-on. If no value is provided, it defaults to add-on's code.</value>
    [DeserializeAs(Name = "accounting_code")]
    public string AccountingCode { get; set; }
  
    /// <value>The unique identifier for the add-on within its plan.</value>
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    /// <value>Add-on ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Describes your add-on and will appear in subscribers' invoices.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
  }
}
