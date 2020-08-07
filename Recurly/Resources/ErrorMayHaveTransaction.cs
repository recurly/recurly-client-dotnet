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
    public class ErrorMayHaveTransaction : Resource
    {

        /// <value>Message</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <value>Parameter specific errors</value>
        [JsonProperty("params")]
        public List<Dictionary<string, string>> Params { get; set; }

        /// <value>This is only included on errors with `type=transaction`.</value>
        [JsonProperty("transaction_error")]
        public TransactionError TransactionError { get; set; }

        /// <value>Type</value>
        [JsonProperty("type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.ErrorType? Type { get; set; }

    }
}
