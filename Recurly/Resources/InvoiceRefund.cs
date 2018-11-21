using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class InvoiceRefund : Request {
  
    [JsonProperty("amount")]
    public int? Amount { get; set; }
  
    [JsonProperty("credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [JsonProperty("external_refund")]
    public Dictionary<string, string> ExternalRefund { get; set; }
  
    [JsonProperty("line_items")]
    public List<LineItemRefund> LineItems { get; set; }
  
    [JsonProperty("refund_method")]
    public string RefundMethod { get; set; }
  
    [JsonProperty("type")]
    public string Type { get; set; }
  
  }
}
