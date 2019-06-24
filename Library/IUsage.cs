using System;

namespace Recurly
{
    public interface IUsage : IRecurlyEntity, IEquatable<object>, IEquatable<IUsage>
    {
        int Amount { get; set; }
        DateTime? BilledAt { get; set; }
        DateTime? CreatedAt { get; }
        long? Id { get; }
        string MerchantTag { get; set; }
        DateTime? RecordingTimestamp { get; set; }
        string SubscriptionAddOnCode { get; }
        string SubscriptionUuid { get; }
        int? UnitAmountInCents { get; set; }
        DateTime? UpdatedAt { get; }
        float? UsagePercentage { get; set; }
        DateTime? UsageTimestamp { get; set; }
        Usage.Type UsageType { get; set; }

        void Create();
        void Delete();
        int GetHashCode();
        string ToString();
        void Update();
    }
}