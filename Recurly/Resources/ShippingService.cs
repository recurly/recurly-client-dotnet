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
  public class ShippingService : Resource {
  
    /// <value>The internal name used identify the shipping service.</value>
    [JsonProperty("code")]
    public string Code { get; set; }
  
    /// <value>Created at</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Deleted at</value>
    [JsonProperty("deleted_at")]
    public DateTime? DeletedAt { get; set; }
  
    /// <value>Shipping Service ID</value>
    [JsonProperty("id")]
    public string Id { get; set; }
  
    /// <value>The name of the shipping service displayed to customers.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  
    /// <value>Optional field for EU VAT merchants, Vertex and Avalara AvaTax Pro merchants.</value>
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
    /// <value>Last updated at</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
  }
}
