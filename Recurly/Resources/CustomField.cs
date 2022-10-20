/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class CustomField : Request {
  
    /// <value>Fields must be created in the UI before values can be assigned to them.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
    /// <value>Any values that resemble a credit card number or security code (CVV/CVC) will be rejected.</value>
    [JsonProperty("value")]
    public string Value { get; set; }
  
  }
}
