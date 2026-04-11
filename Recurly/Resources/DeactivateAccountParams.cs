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
    public class DeactivateAccountParams : OptionalParams
    {

        /// <value>Permanently removes all personally identifiable information (PII) from this account after it has been deactivated, to fulfill a data subject's right to erasure under GDPR and similar privacy regulations (e.g. CCPA). Cannot be undone.</value>
        [JsonProperty("redact")]
        public bool? Redact { get; set; }

    }
}

