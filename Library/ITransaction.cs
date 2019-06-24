using System;

namespace Recurly
{
    public interface ITransaction : IRecurlyEntity, IEquatable<object>, IEquatable<ITransaction>
    {
        IAccount Account { get; set; }
        string AccountCode { get; }
        string AccountingCode { get; set; }
        Transaction.TransactionType Action { get; set; }
        int AmountInCents { get; set; }
        string ApprovalCode { get; set; }
        string AvsResult { get; }
        string AvsResultPostal { get; }
        string AvsResultStreet { get; }
        string CCVResult { get; }
        DateTime CollectedAt { get; set; }
        DateTime CreatedAt { get; }
        string Currency { get; set; }
        string Description { get; set; }
        TransactionError Error { get; }
        string GatewayType { get; set; }
        int? Invoice { get; }
        string InvoicePrefix { get; }
        string IpAddress { get; }
        string Message { get; set; }
        string Origin { get; set; }
        string PaymentMethod { get; set; }
        string Reference { get; set; }
        bool Refundable { get; }
        Transaction.TransactionState Status { get; }
        string TaxCode { get; set; }
        bool TaxExempt { get; set; }
        int TaxInCents { get; set; }
        bool Test { get; }
        DateTime UpdatedAt { get; }
        string Uuid { get; }
        bool Voidable { get; }

        void Create();
        int GetHashCode();
        IInvoice GetInvoice();
        string InvoiceNumberWithPrefix();
        void Refund(int? refund = null);
        string ToString();
    }
}