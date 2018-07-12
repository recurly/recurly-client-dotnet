using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionPause : Request {
  
    [DeserializeAs(Name = "remaining_pause_cycles")]
    public int? RemainingPauseCycles { get; set; }
  
  }
}
