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
    public class PlanCreate : Request
    {

        /// <value>Accounting code for invoice line items for the plan. If no value is provided, it defaults to plan's code.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Add Ons</value>
        [JsonProperty("add_ons")]
        public List<AddOnCreate> AddOns { get; set; }

        /// <value>
        /// Used to determine whether items can be assigned as add-ons to individual subscriptions.
        /// If `true`, items can be assigned as add-ons to individual subscription add-ons.
        /// If `false`, only plan add-ons can be used.
        /// </value>
        [JsonProperty("allow_any_item_on_subscriptions")]
        public bool? AllowAnyItemOnSubscriptions { get; set; }

        /// <value>Subscriptions will automatically inherit this value once they are active. If `auto_renew` is `true`, then a subscription will automatically renew its term at renewal. If `auto_renew` is `false`, then a subscription will expire at the end of its term. `auto_renew` can be overridden on the subscription record itself.</value>
        [JsonProperty("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the plan is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_service_type")]
        public int? AvalaraServiceType { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the plan is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_transaction_type")]
        public int? AvalaraTransactionType { get; set; }

        /// <value>Unique code to identify the plan. This is used in Hosted Payment Page URLs and in the invoice exports.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Required only when `pricing_model` is `'fixed'`.</value>
        [JsonProperty("currencies")]
        public List<PlanPricing> Currencies { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Optional description, not displayed.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Unique ID to identify a dunning campaign. Used to specify if a non-default dunning campaign should be assigned to this plan. For sites without multiple dunning campaigns enabled, the default dunning campaign will always be used.</value>
        [JsonProperty("dunning_campaign_id")]
        public string DunningCampaignId { get; set; }

        /// <value>The Harmonized System (HS) code is an internationally standardized system of names and numbers to classify traded products. The HS code, sometimes called Commodity Code, is used by customs authorities around the world to identify products when assessing duties and taxes. The HS code may also be referred to as the tariff code or customs code. Values should contain only digits and decimals.</value>
        [JsonProperty("harmonized_system_code")]
        public string HarmonizedSystemCode { get; set; }

        /// <value>Hosted pages settings</value>
        [JsonProperty("hosted_pages")]
        public PlanHostedPages HostedPages { get; set; }

        /// <value>Length of the plan's billing interval in `interval_unit`.</value>
        [JsonProperty("interval_length")]
        public int? IntervalLength { get; set; }

        /// <value>Unit for the plan's billing interval.</value>
        [JsonProperty("interval_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.IntervalUnit? IntervalUnit { get; set; }

        /// <value>
        /// The ID of a general ledger account. General ledger accounts are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("liability_gl_account_id")]
        public string LiabilityGlAccountId { get; set; }

        /// <value>This name describes your plan and will appear on the Hosted Payment Page and the subscriber's invoice.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>
        /// The ID of a performance obligation. Performance obligations are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("performance_obligation_id")]
        public string PerformanceObligationId { get; set; }

        /// <value>
        /// A fixed pricing model has the same price for each billing period.
        /// A ramp pricing model defines a set of Ramp Intervals, where a subscription changes price on
        /// a specified cadence of billing periods. The price change could be an increase or decrease.
        /// </value>
        [JsonProperty("pricing_model")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.PricingModelType? PricingModel { get; set; }

        /// <value>Ramp Intervals</value>
        [JsonProperty("ramp_intervals")]
        public List<PlanRampInterval> RampIntervals { get; set; }

        /// <value>
        /// The ID of a general ledger account. General ledger accounts are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("revenue_gl_account_id")]
        public string RevenueGlAccountId { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? RevenueScheduleType { get; set; }

        /// <value>Accounting code for invoice line items for the plan's setup fee. If no value is provided, it defaults to plan's accounting code.</value>
        [JsonProperty("setup_fee_accounting_code")]
        public string SetupFeeAccountingCode { get; set; }

        /// <value>
        /// The ID of a general ledger account. General ledger accounts are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("setup_fee_liability_gl_account_id")]
        public string SetupFeeLiabilityGlAccountId { get; set; }

        /// <value>
        /// The ID of a performance obligation. Performance obligations are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("setup_fee_performance_obligation_id")]
        public string SetupFeePerformanceObligationId { get; set; }

        /// <value>
        /// The ID of a general ledger account. General ledger accounts are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("setup_fee_revenue_gl_account_id")]
        public string SetupFeeRevenueGlAccountId { get; set; }

        /// <value>Setup fee revenue schedule type</value>
        [JsonProperty("setup_fee_revenue_schedule_type")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.RevenueScheduleType? SetupFeeRevenueScheduleType { get; set; }

        /// <value>Setup Fees</value>
        [JsonProperty("setup_fees")]
        public List<PlanSetupPricingCreate> SetupFees { get; set; }

        /// <value>Optional field used by Avalara, Vertex, and Recurly's In-the-Box tax solution to determine taxation rules. You can pass in specific tax codes using any of these tax integrations. For Recurly's In-the-Box tax offering you can also choose to instead use simple values of `unknown`, `physical`, or `digital` tax codes.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on the plan, `false` applies tax on the plan.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>Automatically terminate subscriptions after a defined number of billing cycles. Number of billing cycles before the plan automatically stops renewing, defaults to `null` for continuous, automatic renewal.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>Length of plan's trial period in `trial_units`. `0` means `no trial`.</value>
        [JsonProperty("trial_length")]
        public int? TrialLength { get; set; }

        /// <value>Allow free trial subscriptions to be created without billing info. Should not be used if billing info is needed for initial invoice due to existing uninvoiced charges or setup fee.</value>
        [JsonProperty("trial_requires_billing_info")]
        public bool? TrialRequiresBillingInfo { get; set; }

        /// <value>Units for the plan's trial period.</value>
        [JsonProperty("trial_unit")]
        [JsonConverter(typeof(RecurlyStringEnumConverter))]
        public Constants.IntervalUnit? TrialUnit { get; set; }

        /// <value>Used by Vertex for tax calculations. Possible values are `sale`, `rental`, `lease`.</value>
        [JsonProperty("vertex_transaction_type")]
        public string VertexTransactionType { get; set; }

    }
}
