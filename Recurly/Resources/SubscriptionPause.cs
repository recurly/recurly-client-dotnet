using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class SubscriptionPause : Request {
  
    /// <value>Number of billing cycles to pause the subscriptions.</value>
    [JsonProperty("remaining_pause_cycles")]
    public int? RemainingPauseCycles { get; set; }
  
  }
}
