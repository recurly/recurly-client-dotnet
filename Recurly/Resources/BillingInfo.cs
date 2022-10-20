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
  public class BillingInfo : Resource {
  
    
    [JsonProperty("account_id")]
    public string AccountId { get; set; }
  
    
    [JsonProperty("address")]
    public Address Address { get; set; }
  
    /// <value>The `backup_payment_method` field is used to indicate a billing info as a backup on the account that will be tried if the initial billing info used for an invoice is declined.</value>
    [JsonProperty("backup_payment_method")]
    public bool? BackupPaymentMethod { get; set; }
  
    
    [JsonProperty("company")]
    public string Company { get; set; }
  
    /// <value>When the billing information was created.</value>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
  
    
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
  
    /// <value>Most recent fraud result.</value>
    [JsonProperty("fraud")]
    public FraudInfo Fraud { get; set; }
  
    
    [JsonProperty("id")]
    public string Id { get; set; }
  
    
    [JsonProperty("last_name")]
    public string LastName { get; set; }
  
    /// <value>Object type</value>
    [JsonProperty("object")]
    public string Object { get; set; }
  
    
    [JsonProperty("payment_method")]
    public PaymentMethod PaymentMethod { get; set; }
  
    /// <value>The `primary_payment_method` field is used to indicate the primary billing info on the account. The first billing info created on an account will always become primary. This payment method will be used</value>
    [JsonProperty("primary_payment_method")]
    public bool? PrimaryPaymentMethod { get; set; }
  
    /// <value>When the billing information was last changed.</value>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    
    [JsonProperty("updated_by")]
    public BillingInfoUpdatedBy UpdatedBy { get; set; }
  
    
    [JsonProperty("valid")]
    public bool? Valid { get; set; }
  
    /// <value>Customer's VAT number (to avoid having the VAT applied). This is only used for automatically collected invoices.</value>
    [JsonProperty("vat_number")]
    public string VatNumber { get; set; }
  
  }
}
