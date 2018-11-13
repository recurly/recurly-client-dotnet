using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Invoice : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    
    [DeserializeAs(Name = "address")]
    public InvoiceAddress Address { get; set; }
  
    /// <value>The outstanding balance remaining on this invoice.</value>
    [DeserializeAs(Name = "balance")]
    public float? Balance { get; set; }
  
    /// <value>Date invoice was marked paid or failed.</value>
    [DeserializeAs(Name = "closed_at")]
    public DateTime? ClosedAt { get; set; }
  
    /// <value>An automatic invoice means a corresponding transaction is run using the account's billing information at the same time the invoice is created. Manual invoices are created without a corresponding transaction. The merchant must enter a manual payment transaction or have the customer pay the invoice with an automatic method, like credit card, PayPal, Amazon, or ACH bank payment.</value>
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>Credit payments</value>
    [DeserializeAs(Name = "credit_payments")]
    public List<CreditPayment> CreditPayments { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>This will default to the Customer Notes text specified on the Invoice Settings. Specify custom notes to add or override Customer Notes.</value>
    [DeserializeAs(Name = "customer_notes")]
    public string CustomerNotes { get; set; }
  
    /// <value>Total discounts applied to this invoice.</value>
    [DeserializeAs(Name = "discount")]
    public float? Discount { get; set; }
  
    /// <value>Date invoice is due. This is the date the net terms are reached.</value>
    [DeserializeAs(Name = "due_at")]
    public DateTime? DueAt { get; set; }
  
    /// <value>Invoice ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    
    [DeserializeAs(Name = "line_items")]
    public LineItemList LineItems { get; set; }
  
    /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    /// <value>If VAT taxation and the Country Invoice Sequencing feature are enabled, invoices will have country-specific invoice numbers for invoices billed to EU countries (ex: FR1001). Non-EU invoices will continue to use the site-level invoice number sequence.</value>
    [DeserializeAs(Name = "number")]
    public string Number { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>The event that created the invoice.</value>
    [DeserializeAs(Name = "origin")]
    public string Origin { get; set; }
  
    /// <value>The total amount of successful payments transaction on this invoice.</value>
    [DeserializeAs(Name = "paid")]
    public float? Paid { get; set; }
  
    /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    /// <value>On refund invoices, this value will exist and show the invoice ID of the purchase invoice the refund was created from.</value>
    [DeserializeAs(Name = "previous_invoice_id")]
    public string PreviousInvoiceId { get; set; }
  
    /// <value>The refundable amount on a charge invoice. It will be null for all other invoices.</value>
    [DeserializeAs(Name = "refundable_amount")]
    public float? RefundableAmount { get; set; }
  
    
    [DeserializeAs(Name = "shipping_address")]
    public ShippingAddress ShippingAddress { get; set; }
  
    /// <value>Invoice state</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>If the invoice is charging or refunding for one or more subscriptions, these are their IDs.</value>
    [DeserializeAs(Name = "subscription_ids")]
    public List<string> SubscriptionIds { get; set; }
  
    /// <value>The summation of charges, discounts, and credits, before tax.</value>
    [DeserializeAs(Name = "subtotal")]
    public float? Subtotal { get; set; }
  
    /// <value>The total tax on this invoice.</value>
    [DeserializeAs(Name = "tax")]
    public float? Tax { get; set; }
  
    
    [DeserializeAs(Name = "tax_info")]
    public TaxInfo TaxInfo { get; set; }
  
    /// <value>This will default to the Terms and Conditions text specified on the Invoice Settings page in your Recurly admin. Specify custom notes to add or override Terms and Conditions.</value>
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    /// <value>The final total on this invoice. The summation of invoice charges, discounts, credits, and tax.</value>
    [DeserializeAs(Name = "total")]
    public float? Total { get; set; }
  
    /// <value>Transactions</value>
    [DeserializeAs(Name = "transactions")]
    public List<Transaction> Transactions { get; set; }
  
    /// <value>Invoices are either charge, credit, or legacy invoices.</value>
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>VAT registration number for the customer on this invoice. This will come from the VAT Number field in the Billing Info or the Account Info depending on your tax settings and the invoice collection method.</value>
    [DeserializeAs(Name = "vat_number")]
    public string VatNumber { get; set; }
  
    /// <value>VAT Reverse Charge Notes only appear if you have EU VAT enabled or are using your own Avalara AvaTax account and the customer is in the EU, has a VAT number, and is in a different country than your own. This will default to the VAT Reverse Charge Notes text specified on the Tax Settings page in your Recurly admin, unless custom notes were created with the original subscription.</value>
    [DeserializeAs(Name = "vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
