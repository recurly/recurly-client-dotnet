using System;

namespace Recurly
{
    public interface IGiftCard : IRecurlyEntity, IEquatable<object>, IEquatable<IGiftCard>
    {
        int? BalanceInCents { get; set; }
        DateTime? CanceledAt { get; }
        DateTime CreatedAt { get; }
        string Currency { get; set; }
        DateTime? DeliveredAt { get; }
        IDelivery Delivery { get; set; }
        IAccount GifterAccount { get; set; }
        long Id { get; }
        string ProductCode { get; set; }
        IInvoice PurchaseInvoice { get; set; }
        DateTime? RedeemedAt { get; }
        string RedemptionCode { get; }
        IInvoice RedemptionInvoice { get; set; }
        int UnitAmountInCents { get; set; }
        DateTime UpdatedAt { get; }

        void Create();
        int GetHashCode();
        void Preview();
        void Redeem(string accountCode);
        string ToString();
    }
}