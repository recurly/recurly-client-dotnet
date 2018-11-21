using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AddOnMini : Resource {
  
    /// <value>Accounting code for invoice line items for this add-on. If no value is provided, it defaults to add-on's code.</value>
    [JsonProperty("accounting_code")]
    public string AccountingCode { get; set; }
  
    /// <value>The unique identifier for the add-on within its plan.</value>
    [JsonProperty("code")]
    public string Code { get; set; }
  
    /// <value>Add-on ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>Describes your add-on and will appear in subscribers' invoices.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
  }
}
