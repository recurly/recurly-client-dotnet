using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class PlanMini : Resource {
  
    /// <value>Unique code to identify the plan. This is used in Hosted Payment Page URLs and in the invoice exports.</value>
    [JsonProperty("code")]
    public string Code { get; set; }
  
    /// <value>Plan ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>This name describes your plan and will appear on the Hosted Payment Page and the subscriber's invoice.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
  }
}
