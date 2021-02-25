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
    public class AddOnCreate : Request
    {

        /// <value>Accounting code for invoice line items for this add-on. If no value is provided, it defaults to add-on's code. If `item_code`/`item_id` is part of the request then `accounting_code` must be absent.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Whether the add-on type is fixed, or usage-based.</value>
        [JsonProperty("add_on_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.AddOnTypeCreate? AddOnType { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the add-on is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types. If an `Item` is associated to the `AddOn`, then the `avalara_service_type` must be absent.</value>
        [JsonProperty("avalara_service_type")]
        public int? AvalaraServiceType { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the add-on is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types. If an `Item` is associated to the `AddOn`, then the `avalara_transaction_type` must be absent.</value>
        [JsonProperty("avalara_transaction_type")]
        public int? AvalaraTransactionType { get; set; }

        /// <value>The unique identifier for the add-on within its plan. If `item_code`/`item_id` is part of the request then `code` must be absent. If `item_code`/`item_id` is not present `code` is required.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>
        /// * If `item_code`/`item_id` is part of the request and the item
        /// has a default currency then `currencies` is optional. If the item does
        /// not have a default currency, then `currencies` is required. If `item_code`/`item_id`
        /// is not present `currencies` is required.
        /// * If the add-on's `tier_type` is `tiered`, `volume`, or `stairstep`,
        /// then `currencies` must be absent.
        /// * Must be absent if `add_on_type` is `usage` and `usage_type` is `percentage`.
        /// </value>
        [JsonProperty("currencies")]
        public List<AddOnPricing> Currencies { get; set; }

        /// <value>Default quantity for the hosted pages.</value>
        [JsonProperty("default_quantity")]
        public int? DefaultQuantity { get; set; }

        /// <value>Determines if the quantity field is displayed on the hosted pages for the add-on.</value>
        [JsonProperty("display_quantity")]
        public bool? DisplayQuantity { get; set; }

        /// <value>Unique code to identify an item. Available when the `Credit Invoices` and `Subscription Billing Terms` features are enabled. If `item_id` and `item_code` are both present, `item_id` will be used.</value>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <value>System-generated unique identifier for an item. Available when the `Credit Invoices` and `Subscription Billing Terms` features are enabled. If `item_id` and `item_code` are both present, `item_id` will be used.</value>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <value>System-generated unique identifier for a measured unit to be associated with the add-on. Either `measured_unit_id` or `measured_unit_name` are required when `add_on_type` is `usage`. If `measured_unit_id` and `measured_unit_name` are both present, `measured_unit_id` will be used.</value>
        [JsonProperty("measured_unit_id")]
        public string MeasuredUnitId { get; set; }

        /// <value>Name of a measured unit to be associated with the add-on. Either `measured_unit_id` or `measured_unit_name` are required when `add_on_type` is `usage`. If `measured_unit_id` and `measured_unit_name` are both present, `measured_unit_id` will be used.</value>
        [JsonProperty("measured_unit_name")]
        public string MeasuredUnitName { get; set; }

        /// <value>Describes your add-on and will appear in subscribers' invoices. If `item_code`/`item_id` is part of the request then `name` must be absent. If `item_code`/`item_id` is not present `name` is required.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Whether the add-on is optional for the customer to include in their purchase on the hosted payment page. If false, the add-on will be included when a subscription is created through the Recurly UI. However, the add-on will not be included when a subscription is created through the API.</value>
        [JsonProperty("optional")]
        public bool? Optional { get; set; }

        /// <value>Plan ID</value>
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        /// <value>When this add-on is invoiced, the line item will use this revenue schedule. If `item_code`/`item_id` is part of the request then `revenue_schedule_type` must be absent in the request as the value will be set from the item.</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Optional field used by Avalara, Vertex, and Recurly's EU VAT tax feature to determine taxation rules. If you have your own AvaTax or Vertex account configured, use their tax codes to assign specific tax rules. If you are using Recurly's EU VAT feature, you can use values of `unknown`, `physical`, or `digital`. If `item_code`/`item_id` is part of the request then `tax_code` must be absent.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>
        /// The pricing model for the add-on.  For more information,
        /// [click here](https://docs.recurly.com/docs/billing-models#section-quantity-based). See our
        /// [Guide](https://developers.recurly.com/guides/item-addon-guide.html) for an overview of how
        /// to configure quantity-based pricing models.
        /// </value>
        [JsonProperty("tier_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.TierType? TierType { get; set; }

        /// <value>
        /// If the tier_type is `flat`, then `tiers` must be absent. The `tiers` object
        /// must include one to many tiers with `ending_quantity` and `unit_amount` for
        /// the desired `currencies`. There must be one tier with an `ending_quantity`
        /// of 999999999 which is the default if not provided.
        /// </value>
        [JsonProperty("tiers")]
        public List<Tier> Tiers { get; set; }

        /// <value>The percentage taken of the monetary amount of usage tracked. This can be up to 4 decimal places. A value between 0.0 and 100.0. Required if `add_on_type` is usage and `usage_type` is percentage. Must be omitted otherwise. `usage_percentage` does not support tiers.</value>
        [JsonProperty("usage_percentage")]
        public decimal? UsagePercentage { get; set; }

        /// <value>
        /// Type of usage, required if `add_on_type` is `usage`. See our
        /// [Guide](https://developers.recurly.com/guides/usage-based-billing-guide.html) for an
        /// overview of how to configure usage add-ons.
        /// </value>
        [JsonProperty("usage_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.UsageTypeCreate? UsageType { get; set; }

    }
}
