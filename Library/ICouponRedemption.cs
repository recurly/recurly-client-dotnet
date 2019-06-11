using System;

namespace Recurly
{
    public interface ICouponRedemption : IRecurlyEntity, IEquatable<ICouponRedemption>
    {
        string AccountCode { get; set; }
        string CouponCode { get; }
        DateTime CreatedAt { get; }
        string Currency { get; set; }
        bool SingleUse { get; }
        string State { get; }
        string SubscriptionUuid { get; set; }
        int TotalDiscountedInCents { get; }
        DateTime UpdatedAt { get; }
        string Uuid { get; }

        void Delete();
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}