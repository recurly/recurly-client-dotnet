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
    public class RecoveryPaymentMethodCreate : Request
    {

        /// <value>The card brand (e.g. `Visa`, `MasterCard`). Present for `credit_card`, `apple_pay`, and `google_pay`/`google_pay_device_pan`; omitted for `paypal_billing_agreement`.</value>
        [JsonProperty("card_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CardType? CardType { get; set; }

        /// <value>Expiration month.</value>
        [JsonProperty("exp_month")]
        public int? ExpMonth { get; set; }

        /// <value>Expiration year.</value>
        [JsonProperty("exp_year")]
        public int? ExpYear { get; set; }

        /// <value>
        /// For a plain card, the card's own first six digits (BIN).
        /// 
        /// For a tokenized wallet payment (`apple_pay`, `google_pay`, or
        /// `google_pay_device_pan`), this is the DPAN's (the wallet/device token's own
        /// number) first six digits — **not** the underlying card's (FPAN). The FPAN is
        /// never accepted or represented; no separate wallet-specific field is provided.
        /// </value>
        [JsonProperty("first_six")]
        public string FirstSix { get; set; }

        /// <value>The card's (or, for a tokenized wallet payment, the DPAN's) last four digits. See `first_six` for the DPAN-vs-FPAN distinction on wallets.</value>
        [JsonProperty("last_four")]
        public string LastFour { get; set; }

        /// <value>The payment method type.</value>
        [JsonProperty("object")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RecoveryPaymentMethod? Object { get; set; }

    }
}
