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
    public class PurchaseCreate : Request
    {


        [JsonProperty("account")]
        public AccountPurchase Account { get; set; }

        /// <value>The `billing_info_id` is the value that represents a specific billing info for an end customer. When `billing_info_id` is used to assign billing info to the subscription, all future billing events for the subscription will bill to the specified billing info. `billing_info_id` can ONLY be used for sites utilizing the Wallet feature.</value>
        [JsonProperty("billing_info_id")]
        public string BillingInfoId { get; set; }

        /// <value>Must be set to manual in order to preview a purchase for an Account that does not have payment information associated with the Billing Info.</value>
        [JsonProperty("collection_method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CollectionMethod? CollectionMethod { get; set; }

        /// <value>A list of coupon_codes to be redeemed on the subscription or account during the purchase.</value>
        [JsonProperty("coupon_codes")]
        public List<string> CouponCodes { get; set; }

        /// <value>Notes to be put on the credit invoice resulting from credits in the purchase, if any.</value>
        [JsonProperty("credit_customer_notes")]
        public string CreditCustomerNotes { get; set; }

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Customer notes</value>
        [JsonProperty("customer_notes")]
        public string CustomerNotes { get; set; }

        /// <value>The default payment gateway identifier to be used for the purchase transaction.  This will also be applied as the default for any subscriptions included in the purchase request.</value>
        [JsonProperty("gateway_code")]
        public string GatewayCode { get; set; }

        /// <value>A gift card redemption code to be redeemed on the purchase invoice.</value>
        [JsonProperty("gift_card_redemption_code")]
        public string GiftCardRedemptionCode { get; set; }

        /// <value>A list of one time charges or credits to be created with the purchase.</value>
        [JsonProperty("line_items")]
        public List<LineItemCreate> LineItems { get; set; }

        /// <value>
        /// Integer paired with `Net Terms Type` and representing the number
        /// of days past the current date (for `net` Net Terms Type) or days after
        /// the last day of the current month (for `eom` Net Terms Type) that the
        /// invoice will become past due. For any value, an additional 24 hours is
        /// added to ensure the customer has the entire last day to make payment before
        /// becoming past due.  For example:
        /// 
        /// If an invoice is due `net 0`, it is due 'On Receipt' and will become past due 24 hours after it's created.
        /// If an invoice is due `net 30`, it will become past due at 31 days exactly.
        /// If an invoice is due `eom 30`, it will become past due 31 days from the last day of the current month.
        /// 
        /// When `eom` Net Terms Type is passed, the value for `Net Terms` is restricted to `0, 15, 30, 45, 60, or 90`.
        /// For more information please visit our docs page (https://docs.recurly.com/docs/manual-payments#section-collection-terms)</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>
        /// Optionally supplied string that may be either `net` or `eom` (end-of-month).
        /// When `net`, an invoice becomes past due the specified number of `Net Terms` days from the current date.
        /// When `eom` an invoice becomes past due the specified number of `Net Terms` days from the last day of the current month.
        /// 
        /// This field is only available when the EOM Net Terms feature is enabled.
        /// </value>
        [JsonProperty("net_terms_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.NetTermsType? NetTermsType { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }


        [JsonProperty("shipping")]
        public ShippingPurchase Shipping { get; set; }

        /// <value>A list of subscriptions to be created with the purchase.</value>
        [JsonProperty("subscriptions")]
        public List<SubscriptionPurchase> Subscriptions { get; set; }

        /// <value>Terms and conditions to be put on the purchase invoice.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>An optional type designation for the payment gateway transaction created by this request. Supports 'moto' value, which is the acronym for mail order and telephone transactions.</value>
        [JsonProperty("transaction_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.GatewayTransactionType? TransactionType { get; set; }

        /// <value>VAT reverse charge notes for cross border European tax settlement.</value>
        [JsonProperty("vat_reverse_charge_notes")]
        public string VatReverseChargeNotes { get; set; }

    }
}
