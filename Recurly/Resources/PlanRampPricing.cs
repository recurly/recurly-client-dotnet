/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class PlanRampPricing : Request {
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    /// <value>Represents the price for the Ramp Interval.</value>
    [JsonProperty("unit_amount")]
    public decimal? UnitAmount { get; set; }
  
  }
}
