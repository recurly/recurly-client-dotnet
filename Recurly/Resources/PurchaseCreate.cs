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

        /// <value>Collection method</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

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

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }


        [JsonProperty("shipping_address")]
        public ShippingAddressCreate ShippingAddress { get; set; }

        /// <value>Assign a shipping address from the account's existing shipping addresses. If this and `shipping_address` are both present, `shipping_address` will take precedence.</value>
        [JsonProperty("shipping_address_id")]
        public string ShippingAddressId { get; set; }

        /// <value>A list of subscriptions to be created with the purchase.</value>
        [JsonProperty("subscriptions")]
        public List<SubscriptionPurchase> Subscriptions { get; set; }

        /// <value>Terms and conditions to be put on the purchase invoice.</value>
        [JsonProperty("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        /// <value>VAT reverse charge notes for cross border European tax settlement.</value>
        [JsonProperty("vat_reverse_charge_notes")]
        public string VatReverseChargeNotes { get; set; }

    }
}
