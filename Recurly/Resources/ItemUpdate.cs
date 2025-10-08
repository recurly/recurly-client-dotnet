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
    public class ItemUpdate : Request
    {

        /// <value>Accounting code for invoice line items.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_service_type")]
        public int? AvalaraServiceType { get; set; }

        /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types.</value>
        [JsonProperty("avalara_transaction_type")]
        public int? AvalaraTransactionType { get; set; }

        /// <value>Unique code to identify the item.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Item Pricing</value>
        [JsonProperty("currencies")]
        public List<Pricing> Currencies { get; set; }

        /// <value>The custom fields will only be altered when they are included in a request. Sending an empty array will not remove any existing values. To remove a field send the name with a null or empty value.</value>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Optional, description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Optional, stock keeping unit to link the item to other inventory systems.</value>
        [JsonProperty("external_sku")]
        public string ExternalSku { get; set; }

        /// <value>The Harmonized System (HS) code is an internationally standardized system of names and numbers to classify traded products. The HS code, sometimes called Commodity Code, is used by customs authorities around the world to identify products when assessing duties and taxes. The HS code may also be referred to as the tariff code or customs code. Values should contain only digits and decimals.</value>
        [JsonProperty("harmonized_system_code")]
        public string HarmonizedSystemCode { get; set; }

        /// <value>
        /// The ID of a general ledger account. General ledger accounts are
        /// only accessible as a part of the Recurly RevRec Standard and
        /// Recurly RevRec Advanced features.
        /// </value>
        [JsonProperty("liability_gl_account_id")]
        public string LiabilityGlAccountId { get; set; }

        /// <value>This name describes your item and will appear on the invoice when it's purchased on a one time basis.</value>
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

        /// <value>Optional field used by Avalara, Vertex, and Recurly's In-the-Box tax solution to determine taxation rules. You can pass in specific tax codes using any of these tax integrations. For Recurly's In-the-Box tax offering you can also choose to instead use simple values of `unknown`, `physical`, or `digital` tax codes.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on the item, `false` applies tax on the item.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

    }
}
