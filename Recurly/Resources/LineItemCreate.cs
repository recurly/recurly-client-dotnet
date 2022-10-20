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

namespace Recurly.Resources {
  [ExcludeFromCodeCoverage] 
  public class LineItemCreate : Request {
  
    /// <value>Accounting Code for the `LineItem`. If `item_code`/`item_id` is part of the request then `accounting_code` must be absent.</value>
    [JsonProperty("accounting_code")]
    public string AccountingCode { get; set; }
  
    /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the line item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types. If an `Item` is associated to the `LineItem`, then the `avalara_service_type` must be absent.</value>
    [JsonProperty("avalara_service_type")]
    public int? AvalaraServiceType { get; set; }
  
    /// <value>Used by Avalara for Communications taxes. The transaction type in combination with the service type describe how the line item is taxed. Refer to [the documentation](https://help.avalara.com/AvaTax_for_Communications/Tax_Calculation/AvaTax_for_Communications_Tax_Engine/Mapping_Resources/TM_00115_AFC_Modules_Corresponding_Transaction_Types) for more available t/s types. If an `Item` is associated to the `LineItem`, then the `avalara_transaction_type` must be absent.</value>
    [JsonProperty("avalara_transaction_type")]
    public int? AvalaraTransactionType { get; set; }
  
    /// <value>The reason the credit was given when line item is `type=credit`. When the Credit Invoices feature is enabled, the value can be set and will default to `general`. When the Credit Invoices feature is not enabled, the value will always be `null`.</value>
    [JsonProperty("credit_reason_code")]
[JsonConverter(typeof(RecurlyStringEnumConverter))]
    public Constants.PartialCreditReasonCode? CreditReasonCode { get; set; }
  
    /// <value>3-letter ISO 4217 currency code. If `item_code`/`item_id` is part of the request then `currency` is optional, if the site has a single default currency. `currency` is required if `item_code`/`item_id` is present, and there are multiple currencies defined on the site. If `item_code`/`item_id` is not present `currency` is required.</value>
    [JsonProperty("currency")]
    public string Currency { get; set; }
  
    /// <value>Description that appears on the invoice. If `item_code`/`item_id` is part of the request then `description` must be absent.</value>
    [JsonProperty("description")]
    public string Description { get; set; }
  
    /// <value>If this date is provided, it indicates the end of a time range.</value>
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
  
    /// <value>Unique code to identify an item. Available when the Credit Invoices feature is enabled.</value>
    [JsonProperty("item_code")]
    public string ItemCode { get; set; }
  
    /// <value>System-generated unique identifier for an item. Available when the Credit Invoices feature is enabled.</value>
    [JsonProperty("item_id")]
    public string ItemId { get; set; }
  
    /// <value>Origin `external_gift_card` is allowed if the Gift Cards feature is enabled on your site and `type` is `credit`. Set this value in order to track gift card credits from external gift cards (like InComm). It also skips billing information requirements.  Origin `prepayment` is only allowed if `type` is `charge` and `tax_exempt` is left blank or set to true.  This origin creates a charge and opposite credit on the account to be used for future invoices.</value>
    [JsonProperty("origin")]
[JsonConverter(typeof(RecurlyStringEnumConverter))]
    public Constants.LineItemCreateOrigin? Origin { get; set; }
  
    /// <value>Optional field to track a product code or SKU for the line item. This can be used to later reporting on product purchases. For Vertex tax calculations, this field will be used as the Vertex `product` field. If `item_code`/`item_id` is part of the request then `product_code` must be absent.</value>
    [JsonProperty("product_code")]
    public string ProductCode { get; set; }
  
    /// <value>This number will be multiplied by the unit amount to compute the subtotal before any discounts or taxes.</value>
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
  
    /// <value>Revenue schedule type</value>
    [JsonProperty("revenue_schedule_type")]
[JsonConverter(typeof(RecurlyStringEnumConverter))]
    public Constants.LineItemRevenueScheduleType? RevenueScheduleType { get; set; }
  
    /// <value>If an end date is present, this is value indicates the beginning of a billing time range. If no end date is present it indicates billing for a specific date. Defaults to the current date-time.</value>
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }
  
    /// <value>Optional field used by Avalara, Vertex, and Recurly's EU VAT tax feature to determine taxation rules. If you have your own AvaTax or Vertex account configured, use their tax codes to assign specific tax rules. If you are using Recurly's EU VAT feature, you can use values of `unknown`, `physical`, or `digital`.</value>
    [JsonProperty("tax_code")]
    public string TaxCode { get; set; }
  
    /// <value>`true` exempts tax on charges, `false` applies tax on charges. If not defined, then defaults to the Plan and Site settings. This attribute does not work for credits (negative line items). Credits are always applied post-tax. Pre-tax discounts should use the Coupons feature.</value>
    [JsonProperty("tax_exempt")]
    public bool? TaxExempt { get; set; }
  
    /// <value>Determines whether or not tax is included in the unit amount. The Tax Inclusive Pricing feature (separate from the Mixed Tax Pricing feature) must be enabled to use this flag.</value>
    [JsonProperty("tax_inclusive")]
    public bool? TaxInclusive { get; set; }
  
    /// <value>Line item type. If `item_code`/`item_id` is present then `type` should not be present. If `item_code`/`item_id` is not present then `type` is required.</value>
    [JsonProperty("type")]
[JsonConverter(typeof(RecurlyStringEnumConverter))]
    public Constants.LineItemType? Type { get; set; }
  
    /// <value>
    /// A positive or negative amount with `type=charge` will result in a positive `unit_amount`.
    /// A positive or negative amount with `type=credit` will result in a negative `unit_amount`.
    /// If `item_code`/`item_id` is present, `unit_amount` can be passed in, to override the
    /// `Item`'s `unit_amount`. If `item_code`/`item_id` is not present then `unit_amount` is required.
    /// </value>
    [JsonProperty("unit_amount")]
    public decimal? UnitAmount { get; set; }
  
  }
}
