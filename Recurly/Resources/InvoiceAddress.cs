using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class InvoiceAddress : Request {
  
    /// <value>City</value>
    [JsonProperty("city")]
    public string City { get; set; }
  
    /// <value>Country, 2-letter ISO code.</value>
    [JsonProperty("country")]
    public string Country { get; set; }
  
    /// <value>First name</value>
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    /// <value>Last name</value>
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    /// <value>Phone number</value>
    [JsonProperty("phone")]
    public string Phone { get; set; }
  
    /// <value>Zip or postal code.</value>
    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }
  
    /// <value>State or province.</value>
    [JsonProperty("region")]
    public string Region { get; set; }
  
    /// <value>Street 1</value>
    [JsonProperty("street1")]
    public string Street1 { get; set; }
  
    /// <value>Street 2</value>
    [JsonProperty("street2")]
    public string Street2 { get; set; }
  
  }
}
