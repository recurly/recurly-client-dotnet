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
    public class RecoveryLineItemCreate : Request
    {

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Description that appears on the invoice.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>The Harmonized System (HS) code is an internationally standardized system of names and numbers to classify traded products. The HS code, sometimes called Commodity Code, is used by customs authorities around the world to identify products when assessing duties and taxes. The HS code may also be referred to as the tariff code or customs code. Values should contain only digits and decimals.</value>
        [JsonProperty("harmonized_system_code")]
        public string HarmonizedSystemCode { get; set; }

        /// <value>Optional field to track a product code or SKU for the line item. This can be used to later reporting on product purchases.</value>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <value>This number will be multiplied by the unit amount to compute the subtotal before any discounts or taxes.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>The tax amount for the line item.</value>
        [JsonProperty("tax")]
        public decimal? Tax { get; set; }

        /// <value>A positive or negative amount will result in a positive `unit_amount`.</value>
        [JsonProperty("unit_amount")]
        public decimal? UnitAmount { get; set; }

    }
}
