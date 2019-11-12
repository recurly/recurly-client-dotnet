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
    public class LineItemCreate : Request
    {

        /// <value>3-letter ISO 4217 currency code.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <value>Description that appears on the invoice.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>If this date is provided, it indicates the end of a time range.</value>
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        /// <value>This number will be multiplied by the unit amount to compute the subtotal before any discounts or taxes.</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <value>If an end date is present, this is value indicates the beginning of a billing time range. If no end date is present it indicates billing for a specific date. Defaults to the current date-time.</value>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        /// <value>Optional field used by Avalara, Vertex, and Recurly's EU VAT tax feature to determine taxation rules. If you have your own AvaTax or Vertex account configured, use their tax codes to assign specific tax rules. If you are using Recurly's EU VAT feature, you can use values of `unknown`, `physical`, or `digital`.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on charges, `false` applies tax on charges. If not defined, then defaults to the Plan and Site settings. This attribute does not work for credits (negative line items). Credits are always applied post-tax. Pre-tax discounts should use the Coupons feature.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>Line item type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <value>
        /// A positive or negative amount with `type=charge` will result in a positive `unit_amount`.
        /// A positive or negative amount with `type=credit` will result in a negative `unit_amount`.
        /// </value>
        [JsonProperty("unit_amount")]
        public float? UnitAmount { get; set; }

    }
}
