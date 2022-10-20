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
  public class TaxInfo : Resource {
  
    /// <value>Rate</value>
    [JsonProperty("rate")]
    public decimal? Rate { get; set; }
  
    /// <value>Provides the tax region applied on an invoice. For U.S. Sales Tax, this will be the 2 letter state code. For EU VAT this will be the 2 letter country code. For all country level tax types, this will display the regional tax, like VAT, GST, or PST.</value>
    [JsonProperty("region")]
    public string Region { get; set; }
  
    /// <value>Provides additional tax details for Canadian Sales Tax when there is tax applied at both the country and province levels. This will only be populated for the Invoice response when fetching a single invoice and not for the InvoiceList or LineItem.</value>
    [JsonProperty("tax_details")]
    public List<TaxDetail> TaxDetails { get; set; }
  
    /// <value>Provides the tax type as "vat" for EU VAT, "usst" for U.S. Sales Tax, or the 2 letter country code for country level tax types like Canada, Australia, New Zealand, Israel, and all non-EU European countries.</value>
    [JsonProperty("type")]
    public string Type { get; set; }
  
  }
}
