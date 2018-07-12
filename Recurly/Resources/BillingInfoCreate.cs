using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class BillingInfoCreate : Request {
  
    [DeserializeAs(Name = "address")]
    public Address Address { get; set; }
  
    [DeserializeAs(Name = "amazon_billing_agreement_id")]
    public string AmazonBillingAgreementId { get; set; }
  
    [DeserializeAs(Name = "company")]
    public string Company { get; set; }
  
    [DeserializeAs(Name = "cvv")]
    public string Cvv { get; set; }
  
    [DeserializeAs(Name = "first_name")]
    public string FirstName { get; set; }
  
    [DeserializeAs(Name = "ip_address")]
    public string IpAddress { get; set; }
  
    [DeserializeAs(Name = "last_name")]
    public string LastName { get; set; }
  
    [DeserializeAs(Name = "month")]
    public string Month { get; set; }
  
    [DeserializeAs(Name = "number")]
    public string Number { get; set; }
  
    [DeserializeAs(Name = "paypal_billing_agreement_id")]
    public string PaypalBillingAgreementId { get; set; }
  
    [DeserializeAs(Name = "token_id")]
    public string TokenId { get; set; }
  
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
    [DeserializeAs(Name = "year")]
    public string Year { get; set; }
  
  }
}
