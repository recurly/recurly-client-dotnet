using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class PlanUpdate : Request {
  
    [JsonProperty("accounting_code")]
    public string AccountingCode { get; set; }
  
    [JsonProperty("add_ons")]
    public List<AddOnCreate> AddOns { get; set; }
  
    [JsonProperty("auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [JsonProperty("code")]
    public string Code { get; set; }
  
    [JsonProperty("currencies")]
    public List<PlanPricing> Currencies { get; set; }
  
    [JsonProperty("description")]
    public string Description { get; set; }
  
    [JsonProperty("hosted_pages")]
    public Dictionary<string, string> HostedPages { get; set; }
  
    [JsonProperty("id")]
    public string Id { get; set; }
  
    [JsonProperty("name")]
    public string Name { get; set; }
  
    [JsonProperty("setup_fee_accounting_code")]
    public string SetupFeeAccountingCode { get; set; }
  
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
    [JsonProperty("tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [JsonProperty("total_billing_cycles")]
    public int? TotalBillingCycles { get; set; }
  
    [JsonProperty("trial_length")]
    public int? TrialLength { get; set; }
  
    [JsonProperty("trial_unit")]
    public string TrialUnit { get; set; }
  
  }
}
