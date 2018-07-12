using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceCollection : Resource {
  
    
    [DeserializeAs(Name = "charge_invoice")]
    public Invoice ChargeInvoice { get; set; }
  
    /// <value>Credit invoices</value>
    [DeserializeAs(Name = "credit_invoices")]
    public List<Invoice> CreditInvoices { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
  }
}
