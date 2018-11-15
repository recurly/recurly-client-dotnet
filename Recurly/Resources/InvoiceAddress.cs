using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recurly.Resources {
  public class InvoiceAddress : Request {
  
    [JsonProperty("city")]
    public string City { get; set; }
  
    [JsonProperty("country")]
    public string Country { get; set; }
  
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
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
  
  }
}
