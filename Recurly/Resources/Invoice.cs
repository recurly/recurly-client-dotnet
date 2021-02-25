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
    public class Invoice : Resource
    {

        /// <value>Account mini details</value>
        [JsonProperty("account")]
        public AccountMini Account { get; set; }


        [JsonProperty("address")]
        public InvoiceAddress Address { get; set; }

        /// <value>The outstanding balance remaining on this invoice.</value>
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }

        /// <value>The `billing_info_id` is the value that represents a specific billing info for an end customer. When `billing_info_id` is used to assign billing info to the subscription, all future billing events for the subscription will bill to the specified billing info.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>Date invoice was marked paid or failed.</value>
        [JsonProperty("closed_at")]
        public DateTime? ClosedAt { get; set; }

        /// <value>An automatic invoice means a corresponding transaction is run using the account's billing information at the same time the invoice is created. Manual invoices are created without a corresponding transaction. The merchant must enter a manual payment transaction or have the customer pay the invoice with an automatic method, like credit card, PayPal, Amazon, or ACH bank payment.</value>
        [JsonProperty("collection_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CollectionMethod? CollectionMethod { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Credit payments</value>
        [JsonProperty("credit_payments")]
        public List<CreditPayment> CreditPayments { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>This will default to the Customer Notes text specified on the Invoice Settings. Specify custom notes to add or override Customer Notes.</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>Total discounts applied to this invoice.</value>
        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        /// <value>Date invoice is due. This is the date the net terms are reached.</value>
        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        /// <value>Identifies if the invoice has more line items than are returned in `line_items`. If `has_more_line_items` is `true`, then a request needs to be made to the `list_invoice_line_items` endpoint.</value>
        [JsonProperty("has_more_line_items")]
        public bool? HasMoreLineItems { get; set; }

        /// <value>Invoice ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Line Items</value>
        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>If VAT taxation and the Country Invoice Sequencing feature are enabled, invoices will have country-specific invoice numbers for invoices billed to EU countries (ex: FR1001). Non-EU invoices will continue to use the site-level invoice number sequence.</value>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <value>The event that created the invoice.</value>
        [JsonProperty("origin")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.Origin? Origin { get; set; }

        /// <value>The total amount of successful payments transaction on this invoice.</value>
        [JsonProperty("paid")]
        public decimal? Paid { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>On refund invoices, this value will exist and show the invoice ID of the purchase invoice the refund was created from.</value>
        [JsonProperty("previous_invoice_id")]
        public string PreviousInvoiceId { get; set; }

        /// <value>The refundable amount on a charge invoice. It will be null for all other invoices.</value>
        [JsonProperty("refundable_amount")]
        public decimal? RefundableAmount { get; set; }


        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        /// <value>Invoice state</value>
        [JsonProperty("state")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.InvoiceState? State { get; set; }

        /// <value>If the invoice is charging or refunding for one or more subscriptions, these are their IDs.</value>
        [JsonProperty("subscription_ids")]
        public List<string> SubscriptionIds { get; set; }

        /// <value>The summation of charges, discounts, and credits, before tax.</value>
        [JsonProperty("subtotal")]
        public decimal? Subtotal { get; set; }

        /// <value>The total tax on this invoice.</value>
        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        /// <value>Tax info</value>
        [JsonProperty("tax_info")]
        public TaxInfo TaxInfo { get; set; }

        /// <value>This will default to the Terms and Conditions text specified on the Invoice Settings page in your Recurly admin. Specify custom notes to add or override Terms and Conditions.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>The final total on this invoice. The summation of invoice charges, discounts, credits, and tax.</value>
        [JsonProperty("total")]
        public decimal? Total { get; set; }

        /// <value>Transactions</value>
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        /// <value>Invoices are either charge, credit, or legacy invoices.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.InvoiceType? Type { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <value>VAT registration number for the customer on this invoice. This will come from the VAT Number field in the Billing Info or the Account Info depending on your tax settings and the invoice collection method.</value>
        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

        /// <value>VAT Reverse Charge Notes only appear if you have EU VAT enabled or are using your own Avalara AvaTax account and the customer is in the EU, has a VAT number, and is in a different country than your own. This will default to the VAT Reverse Charge Notes text specified on the Tax Settings page in your Recurly admin, unless custom notes were created with the original subscription.</value>
        [JsonProperty("vat_reverse_charge_notes")]
        public string VatReverseChargeNotes { get; set; }

    }
}
