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
  public class TransactionPaymentMethod : Resource {
  
    /// <value>Visa, MasterCard, American Express, Discover, JCB, etc.</value>
    [JsonProperty("card_type")]
    public string CardType { get; set; }
  
    /// <value>Expiration month.</value>
    [JsonProperty("exp_month")]
    public int? ExpMonth { get; set; }
  
    /// <value>Expiration year.</value>
    [JsonProperty("exp_year")]
    public int? ExpYear { get; set; }
  
    /// <value>Credit card number's first six digits.</value>
    [JsonProperty("first_six")]
    public string FirstSix { get; set; }
  
    /// <value>Credit card number's last four digits.</value>
    [JsonProperty("last_four")]
    public string LastFour { get; set; }
  
  }
}
