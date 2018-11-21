using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class SubscriptionPause : Request {
  
    [JsonProperty("remaining_pause_cycles")]
    public int? RemainingPauseCycles { get; set; }
  
  }
}
