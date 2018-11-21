using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class BillingInfo : Resource {
  
    
    [JsonProperty("account_id")]
    public string AccountId { get; set; }
  
    
    [JsonProperty("address")]
    public Address Address { get; set; }
  
    
    [JsonProperty("company")]
    public string Company { get; set; }
  
    /// <value>When the billing information was created.</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    /// <value>Most recent fraud result.</value>
    [JsonProperty("fraud")]
    public Dictionary<string, string> Fraud { get; set; }
  
    
    [JsonProperty("id")]
    public string Id { get; set; }
  
    
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    
    [JsonProperty("payment_method")]
    public Dictionary<string, string> PaymentMethod { get; set; }
  
    /// <value>When the billing information was last changed.</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    
    [JsonProperty("updated_by")]
    public Dictionary<string, string> UpdatedBy { get; set; }
  
    
    [JsonProperty("valid")]
    public bool? Valid { get; set; }
  
    /// <value>Customer's VAT number (to avoid having the VAT applied). This is only used for automatically collected invoices.</value>
    [JsonProperty("vat_number")]
    public string VatNumber { get; set; }
  
  }
}
