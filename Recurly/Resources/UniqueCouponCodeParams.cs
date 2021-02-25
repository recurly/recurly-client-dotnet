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
    public class UniqueCouponCodeParams : Resource
    {

        /// <value>The date-time to be included when listing UniqueCouponCodes</value>
        [JsonProperty("begin_time")]
        public DateTime? BeginTime { get; set; }

        /// <value>The number of UniqueCouponCodes that will be generated</value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <value>Sort order to list newly generated UniqueCouponCodes (should always be `asc`)</value>
        [JsonProperty("order")]
        public string Order { get; set; }

        /// <value>Sort field to list newly generated UniqueCouponCodes (should always be `created_at`)</value>
        [JsonProperty("sort")]
        public string Sort { get; set; }

    }
}
