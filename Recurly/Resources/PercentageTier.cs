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
  public class PercentageTier : Request {
  
    /// <value>Ending amount for the tier. Allows up to 2 decimal places. Must be left empty if it is the final tier.</value>
    [JsonProperty("ending_amount")]
    public decimal? EndingAmount { get; set; }
  
    /// <value>
    /// The percentage taken of the monetary amount of usage tracked.
    /// This can be up to 4 decimal places represented as a string.
    /// </value>
    [JsonProperty("usage_percentage")]
    public string UsagePercentage { get; set; }
  
  }
}
