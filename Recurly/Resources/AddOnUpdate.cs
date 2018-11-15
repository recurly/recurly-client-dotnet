using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class AddOnUpdate : Request {
  
    [JsonProperty("accounting_code")]
    public string AccountingCode { get; set; }
  
    [JsonProperty("code")]
    public string Code { get; set; }
  
    [JsonProperty("currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    [JsonProperty("default_quantity")]
    public int? DefaultQuantity { get; set; }
  
    [JsonProperty("display_quantity")]
    public bool? DisplayQuantity { get; set; }
  
    [JsonProperty("id")]
    public string Id { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
  }
}
