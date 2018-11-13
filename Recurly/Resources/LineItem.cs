using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class LineItem : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>Internal accounting code to help you reconcile your revenue to the correct ledger. Line items created as part of a subscription invoice will use the plan or add-on's accounting code, otherwise the value will only be present if you define an accounting code when creating the line item.</value>
    [DeserializeAs(Name = "accounting_code")]
    public string AccountingCode { get; set; }
  
    /// <value>If the line item is a charge or credit for an add-on, this is its code.</value>
    [DeserializeAs(Name = "add_on_code")]
    public string AddOnCode { get; set; }
  
    /// <value>If the line item is a charge or credit for an add-on this is its ID.</value>
    [DeserializeAs(Name = "add_on_id")]
    public string AddOnId { get; set; }
  
    /// <value>`(quantity * unit_amount) - (discount + tax)`</value>
    [DeserializeAs(Name = "amount")]
    public float? Amount { get; set; }
  
    /// <value>When the line item was created.</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>The amount of credit from this line item that was applied to the invoice.</value>
    [DeserializeAs(Name = "credit_applied")]
    public float? CreditApplied { get; set; }
  
    /// <value>The reason the credit was given when line item is `type=credit`.</value>
    [DeserializeAs(Name = "credit_reason_code")]
    public string CreditReasonCode { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>Description that appears on the invoice. For subscription related items this will be filled in automatically.</value>
    [DeserializeAs(Name = "description")]
    public string Description { get; set; }
  
    /// <value>The discount applied to the line item.</value>
    [DeserializeAs(Name = "discount")]
    public float? Discount { get; set; }
  
    /// <value>If this date is provided, it indicates the end of a time range.</value>
    [DeserializeAs(Name = "end_date")]
    public DateTime? EndDate { get; set; }
  
    /// <value>Line item ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Once the line item has been invoiced this will be the invoice's ID.</value>
    [DeserializeAs(Name = "invoice_id")]
    public string InvoiceId { get; set; }
  
    /// <value>Once the line item has been invoiced this will be the invoice's number. If VAT taxation and the Country Invoice Sequencing feature are enabled, invoices will have country-specific invoice numbers for invoices billed to EU countries (ex: FR1001). Non-EU invoices will continue to use the site-level invoice number sequence.</value>
    [DeserializeAs(Name = "invoice_number")]
    public string InvoiceNumber { get; set; }
  
    /// <value>
    /// Category to describe the role of a line item on a legacy invoice:
    /// - "charges" refers to charges being billed for on this invoice.
    /// - "credits" refers to refund or proration credits. This portion of the invoice can be considered a credit memo.
    /// - "applied_credits" refers to previous credits applied to this invoice. See their original_line_item_id to determine where the credit first originated.
    /// - "carryforwards" can be ignored. They exist to consume any remaining credit balance. A new credit with the same amount will be created and placed back on the account.
    /// </value>
    [DeserializeAs(Name = "legacy_category")]
    public string LegacyCategory { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>A credit created from an original charge will have the value of the charge's origin.</value>
    [DeserializeAs(Name = "origin")]
    public string Origin { get; set; }
  
    /// <value>The invoice where the credit originated. Will only have a value if the line item is a credit created from a previous credit, or if the credit was created from a charge refund.</value>
    [DeserializeAs(Name = "original_line_item_invoice_id")]
    public string OriginalLineItemInvoiceId { get; set; }
  
    /// <value>If the line item is a charge or credit for a plan or add-on, this is the plan's code.</value>
    [DeserializeAs(Name = "plan_code")]
    public string PlanCode { get; set; }
  
    /// <value>If the line item is a charge or credit for a plan or add-on, this is the plan's ID.</value>
    [DeserializeAs(Name = "plan_id")]
    public string PlanId { get; set; }
  
    /// <value>Will only have a value if the line item is a credit created from a previous credit, or if the credit was created from a charge refund.</value>
    [DeserializeAs(Name = "previous_line_item_id")]
    public string PreviousLineItemId { get; set; }
  
    /// <value>For plan related line items this will be the plan's code, for add-on related line items it will be the add-on's code.</value>
    [DeserializeAs(Name = "product_code")]
    public string ProductCode { get; set; }
  
    /// <value>When a line item has been prorated, this is the rate of the proration. Proration rates were made available for line items created after March 30, 2017. For line items created prior to that date, the proration rate will be `null`, even if the line item was prorated.</value>
    [DeserializeAs(Name = "proration_rate")]
    public float? ProrationRate { get; set; }
  
    /// <value>This number will be multiplied by the unit amount to compute the subtotal before any discounts or taxes.</value>
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    /// <value>Refund?</value>
    [DeserializeAs(Name = "refund")]
    public bool? Refund { get; set; }
  
    /// <value>For refund charges, the quantity being refunded. For non-refund charges, the total quantity refunded (possibly over multiple refunds).</value>
    [DeserializeAs(Name = "refunded_quantity")]
    public int? RefundedQuantity { get; set; }
  
    
    [DeserializeAs(Name = "shipping_address")]
    public ShippingAddress ShippingAddress { get; set; }
  
    /// <value>If an end date is present, this is value indicates the beginning of a billing time range. If no end date is present it indicates billing for a specific date.</value>
    [DeserializeAs(Name = "start_date")]
    public DateTime? StartDate { get; set; }
  
    /// <value>Pending line items are charges or credits on an account that have not been applied to an invoice yet. Invoiced line items will always have an `invoice_id` value.</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>If the line item is a charge or credit for a subscription, this is its ID.</value>
    [DeserializeAs(Name = "subscription_id")]
    public string SubscriptionId { get; set; }
  
    /// <value>`quantity * unit_amount`</value>
    [DeserializeAs(Name = "subtotal")]
    public float? Subtotal { get; set; }
  
    /// <value>The tax amount for the line item.</value>
    [DeserializeAs(Name = "tax")]
    public float? Tax { get; set; }
  
    /// <value>Optional field for EU VAT merchants and Avalara AvaTax Pro merchants. If you are using Recurly's EU VAT feature, you can use values of unknown, physical, or digital. If you have your own AvaTax account configured, you can use Avalara tax codes to assign custom tax rules.</value>
    [DeserializeAs(Name = "tax_code")]
    public string TaxCode { get; set; }
  
    /// <value>`true` exempts tax on charges, `false` applies tax on charges. If not defined, then defaults to the Plan and Site settings. This attribute does not work for credits (negative line items). Credits are always applied post-tax. Pre-tax discounts should use the Coupons feature.</value>
    [DeserializeAs(Name = "tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    
    [DeserializeAs(Name = "tax_info")]
    public TaxInfo TaxInfo { get; set; }
  
    /// <value>`true` if the line item is taxable, `false` if it is not.</value>
    [DeserializeAs(Name = "taxable")]
    public bool? Taxable { get; set; }
  
    /// <value>Charges are positive line items that debit the account. Credits are negative line items that credit the account.</value>
    [DeserializeAs(Name = "type")]
    public string Type { get; set; }
  
    /// <value>Positive amount for a charge, negative amount for a credit.</value>
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
    /// <value>When the line item was last changed.</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
    [DeserializeAs(Name = "uuid")]
    public string Uuid { get; set; }
  
  }
}
