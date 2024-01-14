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
    public class ListExternalInvoicesParams : OptionalParams
    {

        /// <value>Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </value>
        [JsonProperty("sort")]
        public Constants.TimestampSort? Sort { get; set; }

        /// <value>Limit number of records 1-200.</value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <value>Sort order.</value>
        [JsonProperty("order")]
        public Constants.AlphanumericSort? Order { get; set; }

    }
}

