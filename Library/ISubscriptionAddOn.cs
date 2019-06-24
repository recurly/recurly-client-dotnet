namespace Recurly
{
    public interface ISubscriptionAddOn : IRecurlyEntity
    {
        string AddOnCode { get; set; }
        AddOn.Type? AddOnType { get; set; }
        int Quantity { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        int? UnitAmountInCents { get; set; }
        float? UsagePercentage { get; set; }
    }
}