using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceCreate : Request {
  
    [DeserializeAs(Name = "charge_customer_notes")]
    public string ChargeCustomerNotes { get; set; }
  
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    [DeserializeAs(Name = "credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
    [DeserializeAs(Name = "vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
