using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class BillingInfoCreate : Request {
  
    [JsonProperty("address")]
    public Address Address { get; set; }
  
    [JsonProperty("amazon_billing_agreement_id")]
    public string AmazonBillingAgreementId { get; set; }
  
    [JsonProperty("company")]
    public string Company { get; set; }
  
    [JsonProperty("cvv")]
    public string Cvv { get; set; }
  
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    [JsonProperty("ip_address")]
    public string IpAddress { get; set; }
  
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    [JsonProperty("month")]
    public string Month { get; set; }
  
    [JsonProperty("number")]
    public string Number { get; set; }
  
    [JsonProperty("paypal_billing_agreement_id")]
    public string PaypalBillingAgreementId { get; set; }
  
    [JsonProperty("token_id")]
    public string TokenId { get; set; }
  
    [JsonProperty("vat_number")]
    public string VatNumber { get; set; }
  
    [JsonProperty("year")]
    public string Year { get; set; }
  
  }
}
