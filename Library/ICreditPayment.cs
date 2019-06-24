using System;

namespace Recurly
{
    public interface ICreditPayment : IRecurlyEntity
    {
        string Action { get; set; }
        string AppliedToInvoice { get; set; }
        DateTime CreatedAt { get; set; }
        string Currency { get; set; }
        int UnitAmountInCents { get; set; }
        DateTime UpdatedAt { get; set; }
        string Uuid { get; set; }
        DateTime VoidedAt { get; set; }
    }
}