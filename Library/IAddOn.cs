using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface IAddOn : IRecurlyEntity, IEquatable<object>, IEquatable<IAddOn>
    {
        string AccountingCode { get; set; }
        string AddOnCode { get; set; }
        AddOn.Type? AddOnType { get; set; }
        DateTime CreatedAt { get; }
        int? DefaultQuantity { get; set; }
        bool? DisplayQuantityOnHostedPage { get; set; }
        long? MeasuredUnitId { get; set; }
        string Name { get; set; }
        bool? Optional { get; set; }
        string PlanCode { get; set; }
        Adjustment.RevenueSchedule? RevenueScheduleType { get; set; }
        string TaxCode { get; set; }
        Dictionary<string, int> UnitAmountInCents { get; }
        DateTime UpdatedAt { get; }
        Usage.Type? UsageType { get; set; }

        void Create();
        void Delete();
        int GetHashCode();
        string ToString();
        void Update();
    }
}