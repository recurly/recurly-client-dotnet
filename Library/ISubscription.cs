using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface ISubscription : IRecurlyEntity, IEquatable<object>, IEquatable<ISubscription>
    {
        IAccount Account { get; }
        string AccountCode { get; }
        DateTime? ActivatedAt { get; }
        SubscriptionAddOnList AddOns { get; set; }
        IAddress Address { get; set; }
        bool? AutoRenew { get; set; }
        DateTime? BankAccountAuthorizedAt { get; set; }
        bool? Bulk { get; set; }
        DateTime? CanceledAt { get; }
        string CollectionMethod { get; set; }
        DateTime? ConvertedAt { get; }
        ICoupon Coupon { get; set; }
        ICoupon[] Coupons { get; set; }
        string Currency { get; set; }
        DateTime? CurrentPeriodEndsAt { get; }
        DateTime? CurrentPeriodStartedAt { get; }
        DateTime CurrentTermEndsAt { get; }
        DateTime CurrentTermStartedAt { get; }
        string CustomerNotes { get; set; }
        List<CustomField> CustomFields { get; set; }
        DateTime? ExpiresAt { get; }
        DateTime FirstBillDate { get; }
        DateTime? FirstRenewalDate { get; set; }
        string GatewayCode { get; set; }
        bool? ImportedTrial { get; set; }
        IInvoice Invoice { get; }
        IInvoiceCollection InvoiceCollection { get; }
        IInvoice InvoicePreview { get; }
        int? NetTerms { get; set; }
        DateTime NextBillDate { get; }
        string NoBillingInfoReason { get; }
        ISubscription PendingSubscription { get; }
        IPlan Plan { get; set; }
        string PlanCode { get; }
        string PoNumber { get; set; }
        int Quantity { get; set; }
        int? RemainingBillingCycles { get; set; }
        int? RemainingPauseCycles { get; }
        int? RenewalBillingCycles { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        IShippingAddress ShippingAddress { get; set; }
        long? ShippingAddressId { get; set; }
        int? ShippingAmountInCents { get; set; }
        string ShippingMethodCode { get; set; }
        bool StartedWithGiftCard { get; }
        DateTime? StartsAt { get; set; }
        Subscription.SubscriptionState State { get; }
        int? TaxInCents { get; }
        decimal? TaxRate { get; }
        string TaxType { get; }
        string TermsAndConditions { get; set; }
        int? TotalBillingCycles { get; set; }
        DateTime? TrialPeriodEndsAt { get; set; }
        DateTime? TrialPeriodStartedAt { get; }
        int? UnitAmountInCents { get; set; }
        DateTime? UpdatedAt { get; }
        string Uuid { get; }
        string VatReverseChargeNotes { get; set; }

        void Cancel();
        void Create();
        int GetHashCode();
        IRecurlyList<ICouponRedemption> GetRedemptions();
        void Pause(int remainingPauseCycles);
        void Postpone(DateTime nextRenewalDate, bool bulk = false);
        void Preview();
        void Reactivate();
        void Resume();
        void Terminate(Subscription.RefundType refund);
        string ToString();
        bool UpdateNotes(Dictionary<string, string> notes);
    }
}