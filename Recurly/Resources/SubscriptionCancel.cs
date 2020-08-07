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
    public class SubscriptionCancel : Request
    {

        /// <value>The timeframe parameter controls when the expiration takes place. The `bill_date` timeframe causes the subscription to expire when the subscription is scheduled to bill next. The `term_end` timeframe causes the subscription to continue to bill until the end of the subscription term, then expire.</value>
        [JsonProperty("timeframe")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.Timeframe? Timeframe { get; set; }

    }
}
