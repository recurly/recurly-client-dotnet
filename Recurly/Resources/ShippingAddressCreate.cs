using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class ShippingAddressCreate : Request {
  
    [JsonProperty("city")]
    public string City { get; set; }
  
    [JsonProperty("company")]
    public string Company { get; set; }
  
    [JsonProperty("country")]
    public string Country { get; set; }
  
    [JsonProperty("email")]
    public string Email { get; set; }
  
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
  
    [JsonProperty("phone")]
    public string Phone { get; set; }
  
    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }
  
    [JsonProperty("region")]
    public string Region { get; set; }
  
    [JsonProperty("street1")]
    public string Street1 { get; set; }
  
    [JsonProperty("street2")]
    public string Street2 { get; set; }
  
    [JsonProperty("vat_number")]
    public string VatNumber { get; set; }
  
  }
}
