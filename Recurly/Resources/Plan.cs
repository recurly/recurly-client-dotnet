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
    public class Plan : Resource
    {

        /// <value>Accounting code for invoice line items for the plan. If no value is provided, it defaults to plan's code.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Unique code to identify the plan. This is used in Hosted Payment Page URLs and in the invoice exports.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Created at</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <value>Pricing</value>
        [JsonProperty("currencies")]
        public List<Dictionary<string, string>> Currencies { get; set; }

        /// <value>Deleted at</value>
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        /// <value>Optional description, not displayed.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Hosted pages settings</value>
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

        /// <value>The current state of the plan.</value>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <value>Used by Avalara, Vertex, and Recurly’s EU VAT tax feature. The tax code values are specific to each tax system. If you are using Recurly’s EU VAT feature `P0000000` is `physical`, `D0000000` is `digital`, and an empty string is `unknown`.</value>
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

        /// <value>Units for the plan's trial period.</value>
        [JsonProperty("trial_unit")]
        public string TrialUnit { get; set; }

        /// <value>Last updated at</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
