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
    public class CouponDiscountTrial : Resource
    {

        /// <value>Trial length measured in the units specified by the sibling `unit` property</value>
        [JsonProperty("length")]
        public int? Length { get; set; }

        /// <value>Temporal unit of the free trial</value>
        [JsonProperty("unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.FreeTrialUnit? Unit { get; set; }

    }
}
