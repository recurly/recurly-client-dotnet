using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Transaction : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>Total transaction amount sent to the payment gateway.</value>
    [DeserializeAs(Name = "amount")]
    public float? Amount { get; set; }
  
    /// <value>When processed, result from checking the overall AVS on the transaction.</value>
    [DeserializeAs(Name = "avs_check")]
    public string AvsCheck { get; set; }
  
    
    [DeserializeAs(Name = "billing_address")]
    public Address BillingAddress { get; set; }
  
    /// <value>Collected at, or if not collected yet, the time the transaction was created.</value>
    [DeserializeAs(Name = "collected_at")]
    public DateTime? CollectedAt { get; set; }
  
    /// <value>The method by which the payment was collected.</value>
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>For declined (`success=false`) transactions, the message displayed to the customer.</value>
    [DeserializeAs(Name = "customer_message")]
    public string CustomerMessage { get; set; }
  
    /// <value>Language code for the message</value>
    [DeserializeAs(Name = "customer_message_locale")]
    public string CustomerMessageLocale { get; set; }
  
    /// <value>When processed, result from checking the CVV/CVC value on the transaction.</value>
    [DeserializeAs(Name = "cvv_check")]
    public string CvvCheck { get; set; }
  
    /// <value>Transaction approval code from the payment gateway.</value>
    [DeserializeAs(Name = "gateway_approval_code")]
    public string GatewayApprovalCode { get; set; }
  
    /// <value>Transaction message from the payment gateway.</value>
    [DeserializeAs(Name = "gateway_message")]
    public string GatewayMessage { get; set; }
  
    /// <value>Transaction reference number from the payment gateway.</value>
    [DeserializeAs(Name = "gateway_reference")]
    public string GatewayReference { get; set; }
  
    /// <value>For declined transactions (`success=false`), this field lists the gateway error code.</value>
    [DeserializeAs(Name = "gateway_response_code")]
    public string GatewayResponseCode { get; set; }
  
    /// <value>Time, in seconds, for gateway to process the transaction.</value>
    [DeserializeAs(Name = "gateway_response_time")]
    public int? GatewayResponseTime { get; set; }
  
    /// <value>The values in this field will vary from gateway to gateway.</value>
    [DeserializeAs(Name = "gateway_response_values")]
    public Dictionary<string, string> GatewayResponseValues { get; set; }
  
    /// <value>Transaction ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "invoice")]
    public InvoiceMini Invoice { get; set; }
  
    /// <value>IP address's country</value>
    [DeserializeAs(Name = "ip_address_country")]
    public string IpAddressCountry { get; set; }
  
    /// <value>
    /// IP address provided when the billing information was collected:
    /// 
    /// - When the customer enters billing information into the Recurly.JS or Hosted Payment Pages, Recurly records the IP address.
    /// - When the merchant enters billing information using the API, the merchant may provide an IP address.
    /// - When the merchant enters billing information using the UI, no IP address is recorded.
    /// </value>
    [DeserializeAs(Name = "ip_address_v4")]
    public string IpAddressV4 { get; set; }
  
    /// <value>Describes how the transaction was triggered.</value>
    [DeserializeAs(Name = "origin")]
    public string Origin { get; set; }
  
    /// <value>If this transaction is a refund (`type=refund`), this will be the ID of the original transaction on the invoice being refunded.</value>
    [DeserializeAs(Name = "original_transaction_id")]
    public string OriginalTransactionId { get; set; }
  
    
    [DeserializeAs(Name = "payment_gateway")]
    public Dictionary<string, string> PaymentGateway { get; set; }
  
    /// <value>Payment method (TODO: this overlaps with BillingInfo’s payment_method but only documents credit cards)</value>
    [DeserializeAs(Name = "payment_method")]
    public Dictionary<string, string> PaymentMethod { get; set; }
  
    /// <value>Indicates if part or all of this transaction was refunded.</value>
    [DeserializeAs(Name = "refunded")]
    public bool? Refunded { get; set; }
  
    /// <value>The current transaction status. Note that the status may change, e.g. a `pending` transaction may become `declined` or `success` may later become `void`.</value>
    [DeserializeAs(Name = "status")]
    public string Status { get; set; }
  
    /// <value>Status code</value>
    [DeserializeAs(Name = "status_code")]
    public string StatusCode { get; set; }
  
    /// <value>For declined (`success=false`) transactions, the message displayed to the merchant.</value>
    [DeserializeAs(Name = "status_message")]
    public string StatusMessage { get; set; }
  
    /// <value>If the transaction is charging or refunding for one or more subscriptions, these are their IDs.</value>
    [DeserializeAs(Name = "subscription_ids")]
    public List<string> SubscriptionIds { get; set; }
  
    /// <value>Did this transaction complete successfully?</value>
    [DeserializeAs(Name = "success")]
    public bool? Success { get; set; }
  
    /// <value>Transaction type</value>
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
    /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
    [DeserializeAs(Name = "uuid")]
    public string Uuid { get; set; }
  
    /// <value>Voided at</value>
    [DeserializeAs(Name = "voided_at")]
    public DateTime? VoidedAt { get; set; }
  
    
    [DeserializeAs(Name = "voided_by_invoice")]
    public InvoiceMini VoidedByInvoice { get; set; }
  
  }
}
