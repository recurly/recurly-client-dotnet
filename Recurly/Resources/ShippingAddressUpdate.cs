using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class ShippingAddressUpdate : Request {
  
    [DeserializeAs(Name = "city")]
    public string City { get; set; }
  
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    [DeserializeAs(Name = "country")]
    public string Country { get; set; }
  
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    [DeserializeAs(Name = "nickname")]
    public string Nickname { get; set; }
  
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
  
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
  }
}
