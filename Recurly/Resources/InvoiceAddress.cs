using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class InvoiceAddress : Request {
  
    [DeserializeAs(Name = "city")]
    public string City { get; set; }
  
    [DeserializeAs(Name = "country")]
    public string Country { get; set; }
  
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    [DeserializeAs(Name = "phone")]
    public string Phone { get; set; }
  
    [DeserializeAs(Name = "postal_code")]
    public string PostalCode { get; set; }
  
    [DeserializeAs(Name = "region")]
    public string Region { get; set; }
  
    [DeserializeAs(Name = "street1")]
    public string Street1 { get; set; }
  
    [DeserializeAs(Name = "street2")]
    public string Street2 { get; set; }
  
  }
}
