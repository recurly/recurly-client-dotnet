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
    public class TaxDetail : Resource
    {

        /// <value>Provides the tax rate for the region.</value>
        [JsonProperty("rate")]
        public decimal? Rate { get; set; }

        /// <value>Provides the tax region applied on an invoice. For Canadian Sales Tax, this will be either the 2 letter province code or country code.</value>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <value>The total tax applied for this tax type.</value>
        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        /// <value>Provides the tax type for the region. For Canadian Sales Tax, this will be GST, HST, QST or PST.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
