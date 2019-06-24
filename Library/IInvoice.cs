using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface IInvoice : IRecurlyEntity
    {
        string AccountCode { get; }
        IAddress Address { get; set; }
        IRecurlyList<IAdjustment> Adjustments { get; }
        string AllLineItemsLink { get; set; }
        DateTime? AttemptNextCollectionAt { get; set; }
        int? BalanceInCents { get; set; }
        DateTime? ClosedAt { get; }
        Invoice.Collection CollectionMethod { get; set; }
        DateTime? CreatedAt { get; }
        string Currency { get; }
        string CustomerNotes { get; set; }
        int? DiscountInCents { get; set; }
        DateTime? DueOn { get; set; }
        string GatewayCode { get; set; }
        int InvoiceNumber { get; }
        string InvoiceNumberPrefix { get; }
        int? NetTerms { get; set; }
        string Origin { get; set; }
        int OriginalInvoiceNumber { get; }
        string OriginalInvoiceNumberPrefix { get; }
        string PoNumber { get; set; }
        string RecoveryReason { get; set; }
        IShippingAddress ShippingAddress { get; }
        Invoice.InvoiceState State { get; }
        int SubtotalBeforeDiscountInCents { get; set; }
        int SubtotalInCents { get; }
        int TaxInCents { get; }
        decimal? TaxRate { get; }
        string TaxRegion { get; }
        string TaxType { get; }
        string TermsAndConditions { get; set; }
        int TotalInCents { get; }
        IRecurlyList<Transaction> Transactions { get; }
        string Type { get; set; }
        DateTime? UpdatedAt { get; }
        string Uuid { get; }
        string VatNumber { get; }
        string VatReverseChargeNotes { get; set; }

        void Create(string accountCode);
        Transaction EnterOfflinePayment(Transaction transaction);
        bool Equals(IInvoice invoice);
        bool Equals(object obj);
        IInvoice ForceCollect();
        int GetHashCode();
        IInvoice GetOriginalInvoice();
        byte[] GetPdf(string acceptLanguage = "en-US");
        ICouponRedemption GetRedemption();
        IRecurlyList<ICouponRedemption> GetRedemptions();
        IRecurlyList<ISubscription> GetSubscriptions();
        IRecurlyList<Transaction> GetTransactions();
        string InvoiceNumberWithPrefix();
        IInvoiceCollection MarkFailed();
        void MarkSuccessful();
        string OriginalInvoiceNumberWithPrefix();
        void Preview(string accountCode);
        IInvoice Refund(IAdjustment adjustment, bool prorate = false, int quantity = 0, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst);
        IInvoice Refund(IAdjustment adjustment, Invoice.RefundOptions options);
        IInvoice Refund(IEnumerable<IAdjustment> adjustments, bool prorate = false, int quantity = 0, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst);
        IInvoice Refund(IEnumerable<IAdjustment> adjustments, Invoice.RefundOptions options);
        IInvoice RefundAmount(int amountInCents, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst);
        IInvoice RefundAmount(int amountInCents, Invoice.RefundOptions options);
        string ToString();
        void Update();
        void Void();
    }
}