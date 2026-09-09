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
    public class RecoveryBillingInfoCreate : Request
    {


        [JsonProperty("address")]
        public RecoveryAddress Address { get; set; }

        /// <value>The `backup_payment_method` field is used to designate a billing info as a backup on the account that will be tried if the initial billing info used for an invoice is declined. All payment methods, including the billing info marked `primary_payment_method` can be set as a backup. An account can have a maximum of 1 backup, if a user sets a different payment method as a backup, the existing backup will no longer be marked as such.</value>
        [JsonProperty("backup_payment_method")]
        public bool? BackupPaymentMethod { get; set; }

        /// <value>Company name</value>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>First name</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>An identifier for a specific payment gateway.</value>
        [JsonProperty("gateway_code")]
        public string GatewayCode { get; set; }

        /// <value>*STRONGLY RECOMMENDED* Customer's IP address when updating their billing information.</value>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <value>Last name</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>
        /// Network transaction ID from the previous customer-in-session subscription signup or billing info storage.
        /// 
        /// - 10-15 alphanumeric characters for Mastercard
        /// - 14-15 alphanumeric for Visa
        /// - 15 digits for all other brands
        /// - 16 alphanumeric characters for Cartes Bancaires, which are processed as Visa or Mastercard
        /// </value>
        [JsonProperty("network_transaction_id")]
        public string NetworkTransactionId { get; set; }

        /// <value>Array of Payment Gateway References, each a reference to a third-party gateway object of varying types.</value>
        [JsonProperty("payment_gateway_references")]
        public List<PaymentGatewayReferences> PaymentGatewayReferences { get; set; }

        /// <value>Merchant-supplied fallback payment method metadata. Recurly's own gateway-token lookup is authoritative and will override any of these fields it can determine itself; these fields are only used to fill gaps when that lookup is unavailable.</value>
        [JsonProperty("payment_method")]
        public RecoveryPaymentMethodCreate PaymentMethod { get; set; }

        /// <value>The `primary_payment_method` field is used to designate the primary billing info on the account. An account can have a maximum of 1 primary. If a user sets a different payment method as a primary, then the existing primary will no longer be marked as such.</value>
        [JsonProperty("primary_payment_method")]
        public bool? PrimaryPaymentMethod { get; set; }

        /// <value>Transactions from previous collection attempts for this payment method. Optional, unless this billing_info is the primary payment method and the account's dunning campaign skips Recurly's own retry attempts entirely -- in that case at least one entry is required.</value>
        [JsonProperty("transactions")]
        public List<RecoveryTransactionCreate> Transactions { get; set; }

    }
}
