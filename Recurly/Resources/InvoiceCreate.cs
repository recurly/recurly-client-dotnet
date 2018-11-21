using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class InvoiceCreate : Request {
  
    [JsonProperty("charge_customer_notes")]
    public string ChargeCustomerNotes { get; set; }
  
    [JsonProperty("collection_method")]
    public string CollectionMethod { get; set; }
  
    [JsonProperty("credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    [JsonProperty("net_terms")]
    public int? NetTerms { get; set; }
  
    [JsonProperty("po_number")]
    public string PoNumber { get; set; }
  
    [JsonProperty("terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [JsonProperty("type")]
    public string Type { get; set; }
  
    [JsonProperty("vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
