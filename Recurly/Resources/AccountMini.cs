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
    public class AccountMini : Resource
    {


        [JsonProperty("bill_to")]
        public string BillTo { get; set; }

        /// <value>The unique identifier of the account.</value>
        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>Unique ID to identify a dunning campaign. Used to specify if a non-default dunning campaign should be assigned to this account. For sites without multiple dunning campaigns enabled, the default dunning campaign will always be used.</value>
        [JsonProperty("dunning_campaign_id")]
        public string DunningCampaignId { get; set; }

        /// <value>The email address used for communicating with this customer.</value>
        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>Object type</value>
        [JsonProperty("object")]
        public string Object { get; set; }


        [JsonProperty("parent_account_id")]
        public string ParentAccountId { get; set; }

    }
}
