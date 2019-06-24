using System.Collections.Generic;

namespace Recurly
{
    public interface ISubscriptionChange
    {
        SubscriptionAddOnList AddOns { get; set; }
        bool? AutoRenew { get; set; }
        string CollectionMethod { get; set; }
        string CouponCode { get; set; }
        List<CustomField> CustomFields { get; set; }
        bool? ImportedTrial { get; set; }
        int? NetTerms { get; set; }
        string PlanCode { get; set; }
        string PoNumber { get; set; }
        int? Quantity { get; set; }
        int? RemainingBillingCycles { get; set; }
        int? RenewalBillingCycles { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        SubscriptionChange.ChangeTimeframe TimeFrame { get; set; }
        int? UnitAmountInCents { get; set; }

        string ToString();
    }
}