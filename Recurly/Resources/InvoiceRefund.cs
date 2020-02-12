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
    public class InvoiceRefund : Request
    {

        /// <value>
        /// The amount to be refunded. The amount will be split between the line items.
        /// If no amount is specified, it will default to refunding the total refundable amount on the invoice.
        /// </value>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <value>
        /// Used as the Customer Notes on the credit invoice.
        /// 
        /// This field can only be include when the Credit Invoices feature is enabled.
        /// </value>
        [JsonProperty("credit_customer_notes")]
        public string CreditCustomerNotes { get; set; }

        /// <value>
        /// Indicates that the refund was settled outside of Recurly, and a manual transaction should be created to track it in Recurly.
        /// 
        /// Required when:
        /// - refunding a manually collected charge invoice, and `refund_method` is not `all_credit`
        /// - refunding a credit invoice that refunded manually collecting invoices
        /// - refunding a credit invoice for a partial amount
        /// 
        /// This field can only be included when the Credit Invoices feature is enabled.
        /// </value>
        [JsonProperty("external_refund")]
        public ExternalRefund ExternalRefund { get; set; }

        /// <value>The line items to be refunded. This is required when `type=line_items`.</value>
        [JsonProperty("line_items")]
        public List<LineItemRefund> LineItems { get; set; }

        /// <value>
        /// Indicates how the invoice should be refunded when both a credit and transaction are present on the invoice:
        /// - `transaction_first` – Refunds the transaction first, then any amount is issued as credit back to the account. Default value when Credit Invoices feature is enabled.
        /// - `credit_first` – Issues credit back to the account first, then refunds any remaining amount back to the transaction. Default value when Credit Invoices feature is not enabled.
        /// - `all_credit` – Issues credit to the account for the entire amount of the refund. Only available when the Credit Invoices feature is enabled.
        /// - `all_transaction` – Refunds the entire amount back to transactions, using transactions from previous invoices if necessary. Only available when the Credit Invoices feature is enabled.
        /// </value>
        [JsonProperty("refund_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RefuneMethod? RefundMethod { get; set; }

        /// <value>The type of refund. Amount and line items cannot both be specified in the request.</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.InvoiceRefundType? Type { get; set; }

    }
}
