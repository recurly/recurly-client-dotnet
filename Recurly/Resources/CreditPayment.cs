using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class CreditPayment : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>The action for which the credit was created.</value>
    [DeserializeAs(Name = "action")]
    public string Action { get; set; }
  
    /// <value>Total credit payment amount applied to the charge invoice.</value>
    [DeserializeAs(Name = "amount")]
    public float? Amount { get; set; }
  
    
    [DeserializeAs(Name = "applied_to_invoice")]
    public InvoiceMini AppliedToInvoice { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>Credit Payment ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>For credit payments with action `refund`, this is the credit payment that was refunded.</value>
    [DeserializeAs(Name = "original_credit_payment_id")]
    public string OriginalCreditPaymentId { get; set; }
  
    
    [DeserializeAs(Name = "original_invoice")]
    public InvoiceMini OriginalInvoice { get; set; }
  
    
    [DeserializeAs(Name = "refund_transaction")]
    public Transaction RefundTransaction { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
    [DeserializeAs(Name = "uuid")]
    public string Uuid { get; set; }
  
    /// <value>Voided at</value>
    [DeserializeAs(Name = "voided_at")]
    public DateTime? VoidedAt { get; set; }
  
  }
}
