using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class LineItemCreate : Request {
  
    [DeserializeAs(Name = "credit_reason_code")]
    public string CreditReasonCode { get; set; }
  
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    [DeserializeAs(Name = "description")]
    public string Description { get; set; }
  
    [DeserializeAs(Name = "end_date")]
    public DateTime? EndDate { get; set; }
  
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    [DeserializeAs(Name = "start_date")]
    public DateTime? StartDate { get; set; }
  
    [DeserializeAs(Name = "tax_code")]
    public string TaxCode { get; set; }
  
    [DeserializeAs(Name = "tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
  }
}
