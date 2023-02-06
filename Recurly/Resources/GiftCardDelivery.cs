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
    public class GiftCardDelivery : Resource
    {

        /// <value>When the gift card should be delivered to the recipient. If null, the gift card will be delivered immediately. If a datetime is provided, the delivery will be in an hourly window, rounding down. For example, 6:23 pm will be in the 6:00 pm hourly batch.</value>
        [JsonProperty("deliver_at")]
        public DateTime? DeliverAt { get; set; }

        /// <value>The email address of the recipient.</value>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        /// <value>The first name of the recipient.</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <value>The name of the gifter for the purpose of a message displayed to the recipient.</value>
        [JsonProperty("gifter_name")]
        public string GifterName { get; set; }

        /// <value>The last name of the recipient.</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <value>Whether the delivery method is email or postal service.</value>
        [JsonProperty("method")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.DeliveryMethod? Method { get; set; }

        /// <value>The personal message from the gifter to the recipient.</value>
        [JsonProperty("personal_message")]
        public string PersonalMessage { get; set; }

        /// <value>Address information for the recipient.</value>
        [JsonProperty("recipient_address")]
        public Address RecipientAddress { get; set; }

    }
}
