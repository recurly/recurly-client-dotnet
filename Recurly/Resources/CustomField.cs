using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CustomField : Resource {
  
    /// <value>Fields must be created in the UI before values can be assigned to them.</value>
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    /// <value>Any values that resemble a credit card number or security code (CVV/CVC) will be rejected.</value>
    [DeserializeAs(Name = "value")]
    public string Value { get; set; }
  
  }
}
