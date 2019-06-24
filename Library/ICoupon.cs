using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly
{
    public interface ICoupon : IRecurlyEntity, IEquatable<object>, IEquatable<ICoupon>
    {
        int? AppliesForMonths { get; set; }
        bool? AppliesToAllPlans { get; set; }
        bool? AppliesToNonPlanCharges { get; set; }
        string CouponCode { get; set; }
        DateTime CreatedAt { get; }
        Dictionary<string, int> DiscountInCents { get; }
        int? DiscountPercent { get; }
        Coupon.CouponDiscountType DiscountType { get; }
        Coupon.CouponDuration? Duration { get; set; }
        int? FreeTrialAmount { get; set; }
        Coupon.CouponTemporalUnit? FreeTrialUnit { get; set; }
        string HostedDescription { get; set; }
        long Id { get; }
        string InvoiceDescription { get; set; }
        int? MaxRedemptions { get; set; }
        int? MaxRedemptionsPerAccount { get; set; }
        string Name { get; set; }
        List<string> Plans { get; }
        DateTime? RedeemByDate { get; set; }
        Coupon.RedemptionResourceType RedemptionResource { get; set; }
        IRecurlyList<ICouponRedemption> Redemptions { get; }
        bool? SingleUse { get; set; }
        Coupon.CouponState State { get; }
        int? TemporalAmount { get; set; }
        Coupon.CouponTemporalUnit? TemporalUnit { get; set; }
        Coupon.CouponType Type { get; set; }
        string UniqueCodeTemplate { get; set; }
        DateTime UpdatedAt { get; }

        void Create();
        void Deactivate();
        IRecurlyList<ICoupon> Generate(int amount);
        int GetHashCode();
        IRecurlyList<ICoupon> GetUniqueCouponCodes();
        void Restore();
        string ToString();
        void Update();
        void WriteGenerateXml(XmlTextWriter xmlWriter);
    }
}