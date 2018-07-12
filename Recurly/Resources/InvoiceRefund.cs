using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceRefund : Request {
  
    [DeserializeAs(Name = "amount")]
    public int? Amount { get; set; }
  
    [DeserializeAs(Name = "credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [DeserializeAs(Name = "external_refund")]
    public Dictionary<string, string> ExternalRefund { get; set; }
  
    [DeserializeAs(Name = "line_items")]
    public List<LineItemRefund> LineItems { get; set; }
  
    [DeserializeAs(Name = "refund_method")]
    public string RefundMethod { get; set; }
  
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
  }
}
