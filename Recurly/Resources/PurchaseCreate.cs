using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class PurchaseCreate : Request {
  
    [DeserializeAs(Name = "account")]
    public AccountCreate Account { get; set; }
  
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    [DeserializeAs(Name = "coupon_codes")]
    public List<string> CouponCodes { get; set; }
  
    [DeserializeAs(Name = "credit_customer_notes")]
    public string CreditCustomerNotes { get; set; }
  
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    [DeserializeAs(Name = "customer_notes")]
    public string CustomerNotes { get; set; }
  
    [DeserializeAs(Name = "gateway_code")]
    public string GatewayCode { get; set; }
  
    [DeserializeAs(Name = "gift_card_redemption_code")]
    public string GiftCardRedemptionCode { get; set; }
  
    [DeserializeAs(Name = "line_items")]
    public List<PurchaseLineItemCreate> LineItems { get; set; }
  
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    [DeserializeAs(Name = "shipping_address_id")]
    public string ShippingAddressId { get; set; }
  
    [DeserializeAs(Name = "subscriptions")]
    public List<PurchaseSubscriptionCreate> Subscriptions { get; set; }
  
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    [DeserializeAs(Name = "vat_reverse_charge_notes")]
    public string VatReverseChargeNotes { get; set; }
  
  }
}
