using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class Settings : Resource {
  
    
    [JsonProperty("accepted_currencies")]
    public List<string> AcceptedCurrencies { get; set; }
  
    /// <value>
    /// - full:      Full Address (Street, City, State, Postal Code and Country)
    /// - streetzip: Street and Postal Code only
    /// - zip:       Postal Code only
    /// - none:      No Address
    /// </value>
    [JsonProperty("billing_address_requirement")]
    public string BillingAddressRequirement { get; set; }
  
    /// <value>The default 3-letter ISO 4217 currency code.</value>
    [JsonProperty("default_currency")]
    public string DefaultCurrency { get; set; }
  
  }
}
