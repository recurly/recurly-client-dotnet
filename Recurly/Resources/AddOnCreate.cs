using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AddOnCreate : Request {
  
    [JsonProperty("accounting_code")]
    public string AccountingCode { get; set; }
  
    [JsonProperty("code")]
    public string Code { get; set; }
  
    [JsonProperty("currencies")]
    public List<AddOnPricing> Currencies { get; set; }
  
    [JsonProperty("default_quantity")]
    public int? DefaultQuantity { get; set; }
  
    [JsonProperty("display_quantity")]
    public bool? DisplayQuantity { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("plan_id")]
    public string PlanId { get; set; }
  
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
  }
}
