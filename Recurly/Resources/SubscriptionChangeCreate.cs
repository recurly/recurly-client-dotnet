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
    public class SubscriptionChangeCreate : Request
    {

        /// <value>If you provide a value for this field it will replace any existing add-ons. So, when adding or modifying an add-on, you need to include the existing subscription add-ons. Unchanged add-ons can be included just using the subscription add-on's ID: `{"id": "abc123"}`.</value>
        [JsonProperty("add_ons")]
        public List<SubscriptionAddOnUpdate> AddOns { get; set; }

        /// <value>Collection method</value>
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        /// <value>A list of coupon_codes to be redeemed on the subscription during the change. Only allowed if timeframe is now and you change something about the subscription that creates an invoice.</value>
        [JsonProperty("coupon_codes")]
        public List<string> CouponCodes { get; set; }

        /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
        [JsonProperty("net_terms")]
        public int? NetTerms { get; set; }

        /// <value>If you want to change to a new plan, you can provide the plan's code or id. If both are provided the `plan_id` will be used.</value>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        /// <value>If you want to change to a new plan, you can provide the plan's code or id. If both are provided the `plan_id` will be used.</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        /// <value>Optionally override the default quantity of 1.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>The timeframe parameter controls when the upgrade or downgrade takes place. The subscription change can occur now or when the subscription renews. Generally, if you're performing an upgrade, you will want the change to occur immediately (now). If you're performing a downgrade, you should set the timeframe to "renewal" so the change takes affect at the end of the current billing cycle.</value>
        [JsonProperty("timeframe")]
        public string Timeframe { get; set; }

        /// <value>Optionally, sets custom pricing for the subscription, overriding the plan's default unit amount. The subscription's current currency will be used.</value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

    }
}
