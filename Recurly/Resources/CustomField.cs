using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class CustomField : Resource {
  
    /// <value>Fields must be created in the UI before values can be assigned to them.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
    /// <value>Any values that resemble a credit card number or security code (CVV/CVC) will be rejected.</value>
    [JsonProperty("value")]
    public string Value { get; set; }
  
  }
}
