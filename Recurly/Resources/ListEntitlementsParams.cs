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
    public class ListEntitlementsParams : OptionalParams
    {

        /// <value>Filter the entitlements based on the state of the applicable subscription.    - When `state=active`, `state=canceled`, `state=expired`, or `state=future`, subscriptions with states that match the query and only those subscriptions will be returned.  - When no state is provided, subscriptions with active or canceled states will be returned.  </value>
        [JsonProperty("state")]
        public Constants.FilterLimitedSubscriptionState? State { get; set; }

    }
}

