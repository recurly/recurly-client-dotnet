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
    public class AddressWithName : Resource
    {

        /// <value>City</value>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <value>Country, 2-letter ISO 3166-1 alpha-2 code.</value>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <value>First name</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>Code that represents a geographic entity (location or object). Only returned for Sling Vertex Integration</value>
        [JsonProperty("geo_code")]
        public string GeoCode { get; set; }

        /// <value>Last name</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>Phone number</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <value>Zip or postal code.</value>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <value>State or province.</value>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <value>Street 1</value>
        [JsonProperty("street1")]
        public string Street1 { get; set; }

        /// <value>Street 2</value>
        [JsonProperty("street2")]
        public string Street2 { get; set; }

    }
}
