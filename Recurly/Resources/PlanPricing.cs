using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class PlanPricing : Request {
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("setup_fee")]
    public float? SetupFee { get; set; }
  
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
