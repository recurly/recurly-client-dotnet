using System.Collections.Generic;

namespace Recurly
{
    public interface IPurchase : IRecurlyEntity
    {
        IAccount Account { get; set; }
        List<IAdjustment> Adjustments { get; set; }
        Invoice.Collection CollectionMethod { get; set; }
        List<string> CouponCodes { get; set; }
        string Currency { get; set; }
        string CustomerNotes { get; set; }
        string GatewayCode { get; set; }
        string GiftCardRedemptionCode { get; set; }
        int? NetTerms { get; set; }
        string PoNumber { get; set; }
        long? ShippingAddressId { get; set; }
        List<IShippingFee> ShippingFees { get; set; }
        List<ISubscription> Subscriptions { get; set; }
        string TermsAndConditions { get; set; }
        string VatReverseChargeNotes { get; set; }
    }
}