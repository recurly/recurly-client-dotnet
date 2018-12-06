using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class AccountUpdate : Request {
  
    [JsonProperty("address")]
    public Address Address { get; set; }
  
    [JsonProperty("bill_to")]
    public string BillTo { get; set; }
  
    [JsonProperty("billing_info")]
    public BillingInfoCreate BillingInfo { get; set; }
  
    [JsonProperty("cc_emails")]
    public string CcEmails { get; set; }
  
    [JsonProperty("company")]
    public string Company { get; set; }
  
    [JsonProperty("custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    [JsonProperty("email")]
    public string Email { get; set; }
  
    [JsonProperty("exemption_certificate")]
    public string ExemptionCertificate { get; set; }
  
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    [JsonProperty("parent_account_code")]
    public string ParentAccountCode { get; set; }
  
    [JsonProperty("parent_account_id")]
    public string ParentAccountId { get; set; }
  
    [JsonProperty("preferred_locale")]
    public string PreferredLocale { get; set; }
  
    [JsonProperty("tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [JsonProperty("username")]
    public string Username { get; set; }
  
    [JsonProperty("vat_number")]
    public string VatNumber { get; set; }
  
  }
}
