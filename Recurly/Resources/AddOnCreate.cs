using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AddOnCreate : Request {
  
    [DeserializeAs(Name = "accounting_code")]
    public string AccountingCode { get; set; }
  
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    [DeserializeAs(Name = "currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    [DeserializeAs(Name = "default_quantity")]
    public int? DefaultQuantity { get; set; }
  
    [DeserializeAs(Name = "display_quantity")]
    public bool? DisplayQuantity { get; set; }
  
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    [DeserializeAs(Name = "plan_id")]
    public string PlanId { get; set; }
  
    [DeserializeAs(Name = "tax_code")]
    public string TaxCode { get; set; }
  
  }
}
