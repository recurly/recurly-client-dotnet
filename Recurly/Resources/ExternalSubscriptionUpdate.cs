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
    public class ExternalSubscriptionUpdate : Request
    {

        /// <value>When the external subscription was activated in the external platform.</value>
        [JsonProperty("activated_at")]
        public DateTime? ActivatedAt { get; set; }

        /// <value>Identifier of the app that generated the external subscription.</value>
        [JsonProperty("app_identifier")]
        public string AppIdentifier { get; set; }

        /// <value>An indication of whether or not the external subscription will auto-renew at the expiration date.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>When the external subscription expires in the external platform.</value>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <value>Id of the subscription in the external system, i.e. Apple App Store or Google Play Store.</value>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }


        [JsonProperty("external_product_reference")]
        public ExternalProductReferenceUpdate ExternalProductReference { get; set; }

        /// <value>An indication of whether or not the external subscription was being created by a historical data import.</value>
        [JsonProperty("imported")]
        public bool? Imported { get; set; }

        /// <value>When a new billing event occurred on the external subscription in conjunction with a recent billing period, reactivation or upgrade/downgrade.</value>
        [JsonProperty("last_purchased")]
        public DateTime? LastPurchased { get; set; }

        /// <value>An indication of the quantity of a subscribed item's quantity.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>External subscriptions can be active, canceled, expired, past_due, voided, revoked, or paused.</value>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <value>When the external subscription trial period ends in the external platform.</value>
        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        /// <value>When the external subscription trial period started in the external platform.</value>
        [JsonProperty("trial_started_at")]
        public DateTime? TrialStartedAt { get; set; }

    }
}
