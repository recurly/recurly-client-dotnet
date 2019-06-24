using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface IPlan : IRecurlyEntity, IEquatable<object>, IEquatable<IPlan>
    {
        string AccountingCode { get; set; }
        IRecurlyList<IAddOn> AddOns { get; }
        bool? AutoRenew { get; set; }
        bool? BypassHostedConfirmation { get; set; }
        string CancelUrl { get; set; }
        DateTime CreatedAt { get; }
        string Description { get; set; }
        bool? DisplayDonationAmounts { get; set; }
        bool? DisplayPhoneNumber { get; set; }
        bool? DisplayQuantity { get; set; }
        string Name { get; set; }
        string PaymentPageTOSLink { get; set; }
        string PlanCode { get; set; }
        int? PlanIntervalLength { get; set; }
        Plan.IntervalUnit PlanIntervalUnit { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        string SetupFeeAccountingCode { get; set; }
        Dictionary<string, int> SetupFeeInCents { get; }
        Adjustment.RevenueSchedule? SetupFeeRevenueScheduleType { get; set; }
        string SuccessUrl { get; set; }
        string TaxCode { get; set; }
        bool? TaxExempt { get; set; }
        int? TotalBillingCycles { get; set; }
        int? TrialIntervalLength { get; set; }
        Plan.IntervalUnit TrialIntervalUnit { get; set; }
        bool? TrialRequiresBillingInfo { get; set; }
        Dictionary<string, int> UnitAmountInCents { get; }
        string UnitName { get; set; }
        DateTime UpdatedAt { get; }

        void Create();
        void Deactivate();
        IAddOn GetAddOn(string addOnCode);
        int GetHashCode();
        IAddOn NewAddOn(string addOnCode, string name);
        string ToString();
        void Update();
    }
}