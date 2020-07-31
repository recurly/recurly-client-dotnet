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
    public class MeasuredUnitCreate : Request
    {

        /// <value>Optional internal description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Display name for the measured unit.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <value>Unique internal name of the measured unit on your site.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
