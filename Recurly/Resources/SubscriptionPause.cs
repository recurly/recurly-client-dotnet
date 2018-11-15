using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class SubscriptionPause : Request {
  
    [JsonProperty("remaining_pause_cycles")]
    public int? RemainingPauseCycles { get; set; }
  
  }
}
