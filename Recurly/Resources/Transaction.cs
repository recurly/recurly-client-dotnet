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
    public class Transaction : Resource
    {


        [JsonProperty("account")]
        public AccountMini Account { get; set; }

        /// <value>Total transaction amount sent to the payment gateway.</value>
        [JsonProperty("amount")]
        public float? Amount { get; set; }

        /// <value>When processed, result from checking the overall AVS on the transaction.</value>
        [JsonProperty("avs_check")]
        public string AvsCheck { get; set; }


        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        /// <value>Collected at, or if not collected yet, the time the transaction was created.</value>
        [JsonProperty("collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <value>The method by which the payment was collected.</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>For declined (`success=false`) transactions, the message displayed to the customer.</value>
        [JsonProperty("customer_message")]
        public string CustomerMessage { get; set; }

        /// <value>Language code for the message</value>
        [JsonProperty("customer_message_locale")]
        public string CustomerMessageLocale { get; set; }

        /// <value>When processed, result from checking the CVV/CVC value on the transaction.</value>
        [JsonProperty("cvv_check")]
        public string CvvCheck { get; set; }

        /// <value>Transaction approval code from the payment gateway.</value>
        [JsonProperty("gateway_approval_code")]
        public string GatewayApprovalCode { get; set; }

        /// <value>Transaction message from the payment gateway.</value>
        [JsonProperty("gateway_message")]
        public string GatewayMessage { get; set; }

        /// <value>Transaction reference number from the payment gateway.</value>
        [JsonProperty("gateway_reference")]
        public string GatewayReference { get; set; }

        /// <value>For declined transactions (`success=false`), this field lists the gateway error code.</value>
        [JsonProperty("gateway_response_code")]
        public string GatewayResponseCode { get; set; }

        /// <value>Time, in seconds, for gateway to process the transaction.</value>
        [JsonProperty("gateway_response_time")]
        public float? GatewayResponseTime { get; set; }

        /// <value>The values in this field will vary from gateway to gateway.</value>
        [JsonProperty("gateway_response_values")]
        public Dictionary<string, string> GatewayResponseValues { get; set; }

        /// <value>Transaction ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("invoice")]
        public InvoiceMini Invoice { get; set; }

        /// <value>IP address's country</value>
        [JsonProperty("ip_address_country")]
        public string IpAddressCountry { get; set; }

        /// <value>
        /// IP address provided when the billing information was collected:
        /// 
        /// - When the customer enters billing information into the Recurly.JS or Hosted Payment Pages, Recurly records the IP address.
        /// - When the merchant enters billing information using the API, the merchant may provide an IP address.
        /// - When the merchant enters billing information using the UI, no IP address is recorded.
        /// </value>
        [JsonProperty("ip_address_v4")]
        public string IpAddressV4 { get; set; }

        /// <value>Describes how the transaction was triggered.</value>
        [JsonProperty("origin")]
        public string Origin { get; set; }

        /// <value>If this transaction is a refund (`type=refund`), this will be the ID of the original transaction on the invoice being refunded.</value>
        [JsonProperty("original_transaction_id")]
        public string OriginalTransactionId { get; set; }


        [JsonProperty("payment_gateway")]
        public Dictionary<string, string> PaymentGateway { get; set; }

        /// <value>Payment method (TODO: this overlaps with BillingInfo’s payment_method but only documents credit cards)</value>
        [JsonProperty("payment_method")]
        public Dictionary<string, string> PaymentMethod { get; set; }

        /// <value>Indicates if part or all of this transaction was refunded.</value>
        [JsonProperty("refunded")]
        public bool? Refunded { get; set; }

        /// <value>The current transaction status. Note that the status may change, e.g. a `pending` transaction may become `declined` or `success` may later become `void`.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <value>Status code</value>
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        /// <value>For declined (`success=false`) transactions, the message displayed to the merchant.</value>
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        /// <value>If the transaction is charging or refunding for one or more subscriptions, these are their IDs.</value>
        [JsonProperty("subscription_ids")]
        public List<string> SubscriptionIds { get; set; }

        /// <value>Did this transaction complete successfully?</value>
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <value>
        /// - `authorization` – verifies billing information and places a hold on money in the customer's account.
        /// - `capture` – captures funds held by an authorization and completes a purchase.
        /// - `purchase` – combines the authorization and capture in one transaction.
        /// - `refund` – returns all or a portion of the money collected in a previous transaction to the customer.
        /// - `verify` – a $0 or $1 transaction used to verify billing information which is immediately voided.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        /// <value>Voided at</value>
        [JsonProperty("voided_at")]
        public DateTime? VoidedAt { get; set; }


        [JsonProperty("voided_by_invoice")]
        public InvoiceMini VoidedByInvoice { get; set; }

    }
}
