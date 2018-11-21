using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class InvoiceCollection : Resource {
  
    
    [JsonProperty("charge_invoice")]
    public Invoice ChargeInvoice { get; set; }
  
    /// <value>Credit invoices</value>
    [JsonProperty("credit_invoices")]
    public List<Invoice> CreditInvoices { get; set; }
  
  }
}
