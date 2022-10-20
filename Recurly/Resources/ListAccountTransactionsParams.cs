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
    public class ListAccountTransactionsParams : OptionalParams
    {
        
        /// <value>Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </value>
        [JsonProperty("ids")]
        public IList<string> Ids { get; set; }
        
        /// <value>Limit number of records 1-200.</value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }
        
        /// <value>Sort order.</value>
        [JsonProperty("order")]
        public Constants.AlphanumericSort? Order { get; set; }
        
        /// <value>Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </value>
        [JsonProperty("sort")]
        public Constants.TimestampSort? Sort { get; set; }
        
        /// <value>Inclusively filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </value>
        [JsonProperty("begin_time")]
        public DateTime? BeginTime { get; set; }
        
        /// <value>Inclusively filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </value>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }
        
        /// <value>Filter by type field. The value `payment` will return both `purchase` and `capture` transactions.</value>
        [JsonProperty("type")]
        public Constants.FilterTransactionType? Type { get; set; }
        
        /// <value>Filter by success field.</value>
        [JsonProperty("success")]
        public Constants.True? Success { get; set; }
        
    }
}

