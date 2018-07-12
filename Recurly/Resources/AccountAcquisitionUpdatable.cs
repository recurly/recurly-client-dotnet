using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountAcquisitionUpdatable : Request {
  
    [DeserializeAs(Name = "campaign")]
    public string Campaign { get; set; }
  
    [DeserializeAs(Name = "channel")]
    public string Channel { get; set; }
  
    [DeserializeAs(Name = "cost")]
    public Dictionary<string, string> Cost { get; set; }
  
    [DeserializeAs(Name = "subchannel")]
    public string Subchannel { get; set; }
  
  }
}
