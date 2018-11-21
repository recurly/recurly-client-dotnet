using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
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
