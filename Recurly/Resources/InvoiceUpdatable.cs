using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class InvoiceUpdatable : Request {
  
    [JsonProperty("address")]
    public InvoiceAddress Address { get; set; }
  
    [JsonProperty("customer_notes")]
    public string CustomerNotes { get; set; }
  
    [JsonProperty("net_terms")]
    public int? NetTerms { get; set; }
  
    [JsonProperty("po_number")]
    public string PoNumber { get; set; }
  
    [JsonProperty("terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [JsonProperty("vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
