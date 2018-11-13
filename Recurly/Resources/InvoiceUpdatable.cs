using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceUpdatable : Request {
  
    [DeserializeAs(Name = "address")]
    public InvoiceAddress Address { get; set; }
  
    [DeserializeAs(Name = "customer_notes")]
    public string CustomerNotes { get; set; }
  
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [DeserializeAs(Name = "vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
