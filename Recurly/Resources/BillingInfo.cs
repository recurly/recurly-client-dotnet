using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class BillingInfo : Resource {
  
    
    [DeserializeAs(Name = "account_id")]
    public string AccountId { get; set; }
  
    
    [DeserializeAs(Name = "address")]
    public Address Address { get; set; }
  
    
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    /// <value>When the billing information was created.</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    /// <value>Most recent fraud result.</value>
    [DeserializeAs(Name = "fraud")]
    public Dictionary<string, string> Fraud { get; set; }
  
    
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    
    [DeserializeAs(Name = "payment_method")]
    public Dictionary<string, string> PaymentMethod { get; set; }
  
    /// <value>When the billing information was last changed.</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    
    [DeserializeAs(Name = "updated_by")]
    public Dictionary<string, string> UpdatedBy { get; set; }
  
    
    [DeserializeAs(Name = "valid")]
    public bool? Valid { get; set; }
  
    /// <value>Customer's VAT number (to avoid having the VAT applied). This is only used for automatically collected invoices.</value>
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
  }
}
