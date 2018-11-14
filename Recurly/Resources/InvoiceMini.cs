using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceMini : Resource {
  
    /// <value>Invoice ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Invoice number</value>
    [DeserializeAs(Name = "number")]
    public string Number { get; set; }
  
    /// <value>Invoice state</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>Invoice type</value>
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
  }
}
