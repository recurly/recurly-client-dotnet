using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class SubscriptionUpdate : Request {
  
    [DeserializeAs(Name = "auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    [DeserializeAs(Name = "custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [DeserializeAs(Name = "customer_notes")]
    public string CustomerNotes { get; set; }
  
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    [DeserializeAs(Name = "next_bill_date")]
    public DateTime? NextBillDate { get; set; }
  
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    [DeserializeAs(Name = "remaining_billing_cycles")]
    public int? RemainingBillingCycles { get; set; }
  
    [DeserializeAs(Name = "renewal_billing_cycles")]
    public int? RenewalBillingCycles { get; set; }
  
    [DeserializeAs(Name = "shipping_address")]
    public Dictionary<string, string> ShippingAddress { get; set; }
  
    [DeserializeAs(Name = "shipping_address_id")]
    public string ShippingAddressId { get; set; }
  
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
  }
}
