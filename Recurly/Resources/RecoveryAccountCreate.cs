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
    public class RecoveryAccountCreate : Request
    {


        [JsonProperty("address")]
        public RecoveryAddress Address { get; set; }

        /// <value>If the premium Wallet feature is enabled, more than one payment method can be associated with an account, and one can be designated as a primary and one as a backup. Without the Wallet feature, only one payment method will be accepted.</value>
        [JsonProperty("billing_infos")]
        public List<RecoveryBillingInfoCreate> BillingInfos { get; set; }

        /// <value>The unique identifier of the account. This cannot be changed once the account is created.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Unique ID to identify a dunning campaign. Used to specify if a non-default dunning campaign should be assigned to this account. For sites without multiple dunning campaigns enabled, the default dunning campaign will always be used.</value>
        [JsonProperty("dunning_campaign_id")]
        public string DunningCampaignId { get; set; }

        /// <value>The email address used for communicating with this customer.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
