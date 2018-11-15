using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class LineItemCreate : Request {
  
    [JsonProperty("credit_reason_code")]
    public string CreditReasonCode { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("description")]
    public string Description { get; set; }
  
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
  
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }
  
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
    [JsonProperty("tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [JsonProperty("type")]
    public string Type { get; set; }
  
    [JsonProperty("unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
