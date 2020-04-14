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
    public class AddOnUpdate : Request
    {

        /// <value>Accounting code for invoice line items for this add-on. If no value is provided, it defaults to add-on's code. If an `Item` is associated to the `AddOn` then `accounting code` must be absent.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>The unique identifier for the add-on within its plan. If an `Item` is associated to the `AddOn` then `code` must be absent.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>
        /// If the add-on's `tier_type` is `tiered`, `volume` or `stairstep`,
        /// then `currencies` must be absent.
        /// </value>
        [JsonProperty("currencies")]
        public List<AddOnPricing> Currencies { get; set; }

        /// <value>Default quantity for the hosted pages.</value>
        [JsonProperty("default_quantity")]
        public int? DefaultQuantity { get; set; }

        /// <value>Determines if the quantity field is displayed on the hosted pages for the add-on.</value>
        [JsonProperty("display_quantity")]
        public bool? DisplayQuantity { get; set; }

        /// <value>Add-on ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Describes your add-on and will appear in subscribers' invoices. If an `Item` is associated to the `AddOn` then `name` must be absent.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Whether the add-on is optional for the customer to include in their purchase on the hosted payment page. If false, the add-on will be included when a subscription is created through the Recurly UI. However, the add-on will not be included when a subscription is created through the API.</value>
        [JsonProperty("optional")]
        public bool? Optional { get; set; }

        /// <value>When this add-on is invoiced, the line item will use this revenue schedule. If an `Item` is associated to the `AddOn` then `revenue_schedule_type` must be absent in the request as the value will be set from the item.</value>
        [JsonProperty("revenue_schedule_type")]
        public string RevenueScheduleType { get; set; }

        /// <value>Optional field used by Avalara, Vertex, and Recurly's EU VAT tax feature to determine taxation rules. If you have your own AvaTax or Vertex account configured, use their tax codes to assign specific tax rules. If you are using Recurly's EU VAT feature, you can use values of `unknown`, `physical`, or `digital`. If an `Item` is associated to the `AddOn` then `tax code` must be absent.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>
        /// If tiers are provided in the request, all existing tiers on the Add-on will be
        /// removed and replaced by the tiers in the request.
        /// </value>
        [JsonProperty("tiers")]
        public List<Tier> Tiers { get; set; }

    }
}
