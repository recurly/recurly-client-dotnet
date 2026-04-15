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
    public class CouponBulkCreateSync : Request
    {

        /// <value>The quantity of unique coupon codes to generate. A bulk coupon can have up to 100,000 unique codes (or your site's configured limit).</value>
        [JsonProperty("number_of_unique_codes")]
        public int? NumberOfUniqueCodes { get; set; }

    }
}
