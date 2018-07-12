using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class ShippingAddress : Resource {
  
    /// <value>Account ID</value>
    [DeserializeAs(Name = "account_id")]
    public string AccountId { get; set; }
  
    
    [DeserializeAs(Name = "city")]
    public string City { get; set; }
  
    
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    /// <value>Country, 2-letter ISO code.</value>
    [DeserializeAs(Name = "country")]
    public string Country { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    /// <value>Shipping Address ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    
    [DeserializeAs(Name = "nickname")]
    public string Nickname { get; set; }
  
    
    [DeserializeAs(Name = "phone")]
    public string Phone { get; set; }
  
    /// <value>Zip or postal code.</value>
    [DeserializeAs(Name = "postal_code")]
    public string PostalCode { get; set; }
  
    /// <value>State or province.</value>
    [DeserializeAs(Name = "region")]
    public string Region { get; set; }
  
    
    [DeserializeAs(Name = "street1")]
    public string Street1 { get; set; }
  
    
    [DeserializeAs(Name = "street2")]
    public string Street2 { get; set; }
  
    /// <value>Updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
  }
}
