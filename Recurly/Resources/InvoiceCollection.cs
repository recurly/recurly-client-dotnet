using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class InvoiceCollection : Resource {
  
    
    [JsonProperty("charge_invoice")]
    public Invoice ChargeInvoice { get; set; }
  
    /// <value>Credit invoices</value>
    [JsonProperty("credit_invoices")]
    public List<Invoice> CreditInvoices { get; set; }
  
  }
}
