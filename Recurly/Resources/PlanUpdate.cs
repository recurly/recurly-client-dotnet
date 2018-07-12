using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class PlanUpdate : Request {
  
    [DeserializeAs(Name = "accounting_code")]
    public string AccountingCode { get; set; }
  
    [DeserializeAs(Name = "add_ons")]
    public List<AddOnCreate> AddOns { get; set; }
  
    [DeserializeAs(Name = "auto_renew")]
    public bool? AutoRenew { get; set; }
  
    [DeserializeAs(Name = "code")]
    public string Code { get; set; }
  
    [DeserializeAs(Name = "currencies")]
    public List<Dictionary<string, string>> Currencies { get; set; }
  
    [DeserializeAs(Name = "description")]
    public string Description { get; set; }
  
    [DeserializeAs(Name = "hosted_pages")]
    public Dictionary<string, string> HostedPages { get; set; }
  
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    [DeserializeAs(Name = "name")]
    public string Name { get; set; }
  
    [DeserializeAs(Name = "setup_fee_accounting_code")]
    public string SetupFeeAccountingCode { get; set; }
  
    [DeserializeAs(Name = "tax_code")]
    public string TaxCode { get; set; }
  
    [DeserializeAs(Name = "tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    [DeserializeAs(Name = "total_billing_cycles")]
    public int? TotalBillingCycles { get; set; }
  
    [DeserializeAs(Name = "trial_length")]
    public int? TrialLength { get; set; }
  
    [DeserializeAs(Name = "trial_unit")]
    public string TrialUnit { get; set; }
  
  }
}
