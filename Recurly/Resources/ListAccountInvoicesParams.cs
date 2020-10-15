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
    public class ListAccountInvoicesParams : OptionalParams
    {

        [JsonProperty("ids")]
        public IList<string> Ids { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("order")]
        public Constants.AlphanumericSort? Order { get; set; }

        [JsonProperty("sort")]
        public Constants.TimestampSort? Sort { get; set; }

        [JsonProperty("begin_time")]
        public DateTime? BeginTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("type")]
        public Constants.FilterInvoiceType? Type { get; set; }

    }
}

