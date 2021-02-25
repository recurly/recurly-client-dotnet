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

namespace Recurly.Resources
{
    [ExcludeFromCodeCoverage]
    public class LineItem : Resource
    {

        /// <value>Account mini details</value>
        [JsonProperty("account")]
        public AccountMini Account { get; set; }

        /// <value>Internal accounting code to help you reconcile your revenue to the correct ledger. Line items created as part of a subscription invoice will use the plan or add-on's accounting code, otherwise the value will only be present if you define an accounting code when creating the line item.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>If the line item is a charge or credit for an add-on, this is its code.</value>
        [JsonProperty("add_on_code")]
        public string AddOnCode { get; set; }

        /// <value>If the line item is a charge or credit for an add-on this is its ID.</value>
        [JsonProperty("add_on_id")]
        public string AddOnId { get; set; }

        /// <value>`(quantity * unit_amount) - (discount + tax)`</value>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the line item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_service_type")]
        public int? AvalaraServiceType { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the line item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_transaction_type")]
        public int? AvalaraTransactionType { get; set; }

        /// <value>When the line item was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>The amount of credit from this line item that was applied to the invoice.</value>
        [JsonProperty("credit_applied")]
        public decimal? CreditApplied { get; set; }

        /// <value>The reason the credit was given when line item is `type=credit`.</value>
        [JsonProperty("credit_reason_code")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.FullCreditReasonCode? CreditReasonCode { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Description that appears on the invoice. For subscription related items this will be filled in automatically.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>The discount applied to the line item.</value>
        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        /// <value>If this date is provided, it indicates the end of a time range.</value>
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        /// <value>Optional Stock Keeping Unit assigned to an item. Available when the Credit Invoices and Subscription Billing Terms features are enabled.</value>
        [JsonProperty("external_sku")]
        public string ExternalSku { get; set; }

        /// <value>Line item ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Once the line item has been invoiced this will be the invoice's ID.</value>
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        /// <value>Once the line item has been invoiced this will be the invoice's number. If VAT taxation and the Country Invoice Sequencing feature are enabled, invoices will have country-specific invoice numbers for invoices billed to EU countries (ex: FR1001). Non-EU invoices will continue to use the site-level invoice number sequence.</value>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        /// <value>Unique code to identify an item. Available when the Credit Invoices and Subscription Billing Terms features are enabled.</value>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <value>System-generated unique identifier for an item. Available when the Credit Invoices and Subscription Billing Terms features are enabled.</value>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <value>
        /// Category to describe the role of a line item on a legacy invoice:
        /// - "charges" refers to charges being billed for on this invoice.
        /// - "credits" refers to refund or proration credits. This portion of the invoice can be considered a credit memo.
        /// - "applied_credits" refers to previous credits applied to this invoice. See their original_line_item_id to determine where the credit first originated.
        /// - "carryforwards" can be ignored. They exist to consume any remaining credit balance. A new credit with the same amount will be created and placed back on the account.
        /// </value>
        [JsonProperty("legacy_category")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.LegacyCategory? LegacyCategory { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>A credit created from an original charge will have the value of the charge's origin.</value>
        [JsonProperty("origin")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.LineItemOrigin? Origin { get; set; }

        /// <value>The invoice where the credit originated. Will only have a value if the line item is a credit created from a previous credit, or if the credit was created from a charge refund.</value>
        [JsonProperty("original_line_item_invoice_id")]
        public string OriginalLineItemInvoiceId { get; set; }

        /// <value>If the line item is a charge or credit for a plan or add-on, this is the plan's code.</value>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        /// <value>If the line item is a charge or credit for a plan or add-on, this is the plan's ID.</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>Will only have a value if the line item is a credit created from a previous credit, or if the credit was created from a charge refund.</value>
        [JsonProperty("previous_line_item_id")]
        public string PreviousLineItemId { get; set; }

        /// <value>For plan-related line items this will be the plan's code, for add-on related line items it will be the add-on's code. For item-related line items it will be the item's `external_sku`.</value>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <value>When a line item has been prorated, this is the rate of the proration. Proration rates were made available for line items created after March 30, 2017. For line items created prior to that date, the proration rate will be `null`, even if the line item was prorated.</value>
        [JsonProperty("proration_rate")]
        public decimal? ProrationRate { get; set; }

        /// <value>This number will be multiplied by the unit amount to compute the subtotal before any discounts or taxes.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>Refund?</value>
        [JsonProperty("refund")]
        public bool? Refund { get; set; }

        /// <value>For refund charges, the quantity being refunded. For non-refund charges, the total quantity refunded (possibly over multiple refunds).</value>
        [JsonProperty("refunded_quantity")]
        public int? RefundedQuantity { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.LineItemRevenueScheduleType? RevenueScheduleType { get; set; }


        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        /// <value>If an end date is present, this is value indicates the beginning of a billing time range. If no end date is present it indicates billing for a specific date.</value>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        /// <value>Pending line items are charges or credits on an account that have not been applied to an invoice yet. Invoiced line items will always have an `invoice_id` value.</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.LineItemState? State { get; set; }

        /// <value>If the line item is a charge or credit for a subscription, this is its ID.</value>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <value>`quantity * unit_amount`</value>
        [JsonProperty("subtotal")]
        public decimal? Subtotal { get; set; }

        /// <value>The tax amount for the line item.</value>
        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        /// <value>Used by Avalara, Vertex, and Recurly’s EU VAT tax feature. The tax code values are specific to each tax system. If you are using Recurly’s EU VAT feature you can use `unknown`, `physical`, or `digital`.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on charges, `false` applies tax on charges. If not defined, then defaults to the Plan and Site settings. This attribute does not work for credits (negative line items). Credits are always applied post-tax. Pre-tax discounts should use the Coupons feature.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>Tax info</value>
        [JsonProperty("tax_info")]
        public TaxInfo TaxInfo { get; set; }

        /// <value>`true` if the line item is taxable, `false` if it is not.</value>
        [JsonProperty("taxable")]
        public bool? Taxable { get; set; }

        /// <value>Charges are positive line items that debit the account. Credits are negative line items that credit the account.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.LineItemType? Type { get; set; }

        /// <value>Positive amount for a charge, negative amount for a credit.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

        /// <value>Positive amount for a charge, negative amount for a credit.</value>
        [JsonProperty("unit_amount_decimal")]
        public string UnitAmountDecimal { get; set; }

        /// <value>When the line item was last changed.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

    }
}
