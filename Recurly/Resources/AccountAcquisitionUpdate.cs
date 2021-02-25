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
    public class AccountAcquisitionUpdate : Request
    {

        /// <value>An arbitrary identifier for the marketing campaign that led to the acquisition of this account.</value>
        [JsonProperty("campaign")]
        public string Campaign { get; set; }

        /// <value>The channel through which the account was acquired.</value>
        [JsonProperty("channel")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.Channel? Channel { get; set; }

        /// <value>Account balance</value>
        [JsonProperty("cost")]
        public AccountAcquisitionCost Cost { get; set; }

        /// <value>An arbitrary subchannel string representing a distinction/subcategory within a broader channel.</value>
        [JsonProperty("subchannel")]
        public string Subchannel { get; set; }

    }
}
