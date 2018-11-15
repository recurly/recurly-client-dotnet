using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class InvoiceMini : Resource {
  
    /// <value>Invoice ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>Invoice number</value>
    [JsonProperty("number")]
    public string Number { get; set; }
  
    /// <value>Invoice state</value>
    [JsonProperty("state")]
    public string State { get; set; }
  
    /// <value>Invoice type</value>
    [JsonProperty("type")]
    public string Type { get; set; }
  
  }
}
