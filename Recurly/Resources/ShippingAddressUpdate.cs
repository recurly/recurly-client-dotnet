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
    public class ShippingAddressUpdate : Request
    {


        [JsonProperty("city")]
        public string City { get; set; }


        [JsonProperty("company")]
        public string Company { get; set; }

        /// <value>Country, 2-letter ISO code.</value>
        [JsonProperty("country")]
        public string Country { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>Shipping Address ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("last_name")]
        public string LastName { get; set; }


        [JsonProperty("nickname")]
        public string Nickname { get; set; }


        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <value>Zip or postal code.</value>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <value>State or province.</value>
        [JsonProperty("region")]
        public string Region { get; set; }


        [JsonProperty("street1")]
        public string Street1 { get; set; }


        [JsonProperty("street2")]
        public string Street2 { get; set; }


        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

    }
}
