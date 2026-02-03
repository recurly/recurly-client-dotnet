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
    public class CreditApplicationPolicy : Request
    {

        /// <value>
        /// Optional array of credit invoice origin types to allow when mode is `all`.
        /// If not specified when mode is `all`, credits from all origins are applied.
        /// Only valid when mode is `all`.
        /// </value>
        [JsonProperty("allowed_origins")]
        public List<Constants.CreditApplicationAllowedOriginType> AllowedOrigins { get; set; }

        /// <value>
        /// Determines which credit invoices are applied to invoices:
        /// - `all`: All available credit invoices are applied (default)
        /// - `none`: No credit invoices are applied automatically
        /// </value>
        [JsonProperty("mode")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.CreditApplicationMode? Mode { get; set; }

    }
}
