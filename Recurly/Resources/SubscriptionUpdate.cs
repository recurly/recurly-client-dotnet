using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class SubscriptionUpdate : Request {
  
    [JsonProperty("auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [JsonProperty("collection_method")]
    public string CollectionMethod { get; set; }
  
    [JsonProperty("custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [JsonProperty("customer_notes")]
    public string CustomerNotes { get; set; }
  
    [JsonProperty("net_terms")]
    public int? NetTerms { get; set; }
  
    [JsonProperty("next_bill_date")]
    public DateTime? NextBillDate { get; set; }
  
    [JsonProperty("po_number")]
    public string PoNumber { get; set; }
  
    [JsonProperty("remaining_billing_cycles")]
    public int? RemainingBillingCycles { get; set; }
  
    [JsonProperty("renewal_billing_cycles")]
    public int? RenewalBillingCycles { get; set; }
  
    [JsonProperty("shipping_address")]
    public Dictionary<string, string> ShippingAddress { get; set; }
  
    [JsonProperty("shipping_address_id")]
    public string ShippingAddressId { get; set; }
  
    [JsonProperty("terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
  }
}
