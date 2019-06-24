using System;

namespace Recurly
{
    public interface IAdjustment : IRecurlyEntity
    {
        string AccountCode { get; }
        string AccountingCode { get; set; }
        DateTime? CreatedAt { get; }
        string CreditReasonCode { get; set; }
        string Currency { get; set; }
        string Description { get; set; }
        int DiscountInCents { get; }
        DateTime? EndDate { get; }
        string Origin { get; }
        string OriginalAjustmentUuid { get; set; }
        string ProductCode { get; set; }
        bool? Prorate { get; set; }
        int Quantity { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        IShippingAddress ShippingAddress { get; }
        DateTime StartDate { get; }
        Adjustment.AdjustmentState State { get; }
        string TaxCode { get; set; }
        bool TaxExempt { get; set; }
        int TaxInCents { get; }
        decimal? TaxRate { get; }
        string TaxRegion { get; }
        string TaxType { get; }
        int TotalInCents { get; }
        int UnitAmountInCents { get; set; }
        DateTime UpdatedAt { get; }
        string Uuid { get; }

        void Create();
        void Delete();
    }
}