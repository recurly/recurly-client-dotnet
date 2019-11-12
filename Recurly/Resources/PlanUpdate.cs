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
    public class PlanUpdate : Request
    {

        /// <value>Accounting code for invoice line items for the plan. If no value is provided, it defaults to plan's code.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Add Ons</value>
        [JsonProperty("add_ons")]
        public List<AddOnCreate> AddOns { get; set; }

        /// <value>Unique code to identify the plan. This is used in Hosted Payment Page URLs and in the invoice exports.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Pricing</value>
        [JsonProperty("currencies")]
        public List<PlanPricing> Currencies { get; set; }

        /// <value>Optional description, not displayed.</value>
        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("hosted_pages")]
        public PlanHostedPages HostedPages { get; set; }

        /// <value>Plan ID</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <value>Length of the plan's billing interval in `interval_unit`.</value>
        [JsonProperty("interval_length")]
        public int? IntervalLength { get; set; }

        /// <value>Unit for the plan's billing interval.</value>
        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }

        /// <value>This name describes your plan and will appear on the Hosted Payment Page and the subscriber's invoice.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Accounting code for invoice line items for the plan's setup fee. If no value is provided, it defaults to plan's accounting code.</value>
        [JsonProperty("setup_fee_accounting_code")]
        public string SetupFeeAccountingCode { get; set; }

        /// <value>Optional field used by Avalara, Vertex, and Recurly's EU VAT tax feature to determine taxation rules. If you have your own AvaTax or Vertex account configured, use their tax codes to assign specific tax rules. If you are using Recurly's EU VAT feature, you can use values of `unknown`, `physical`, or `digital`.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on the plan, `false` applies tax on the plan.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

        /// <value>Automatically terminate plans after a defined number of billing cycles.</value>
        [JsonProperty("total_billing_cycles")]
        public int? TotalBillingCycles { get; set; }

        /// <value>Length of plan's trial period in `trial_units`. `0` means `no trial`.</value>
        [JsonProperty("trial_length")]
        public int? TrialLength { get; set; }

        /// <value>Units for the plan's trial period.</value>
        [JsonProperty("trial_unit")]
        public string TrialUnit { get; set; }

    }
}
