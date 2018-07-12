using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class AccountUpdate : Request {
  
    [DeserializeAs(Name = "address")]
    public Address Address { get; set; }
  
    [DeserializeAs(Name = "billing_info")]
    public BillingInfoCreate BillingInfo { get; set; }
  
    [DeserializeAs(Name = "cc_emails")]
    public string CcEmails { get; set; }
  
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    [DeserializeAs(Name = "custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [DeserializeAs(Name = "email")]
    public string Email { get; set; }
  
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    [DeserializeAs(Name = "preferred_locale")]
    public string PreferredLocale { get; set; }
  
    [DeserializeAs(Name = "tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [DeserializeAs(Name = "username")]
    public string Username { get; set; }
  
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
  }
}
