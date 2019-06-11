using System;
using System.Collections.Generic;

namespace Recurly
{
    public interface IAccount : IRecurlyEntity
    {
        string AcceptLanguage { get; set; }
        IAccountAcquisition AccountAcquisition { get; set; }
        string AccountCode { get; }
        IAddress Address { get; set; }
        IAccountBalance Balance { get; set; }
        BillingInfo BillingInfo { get; set; }
        string CcEmails { get; set; }
        DateTime? ClosedAt { get; }
        string CompanyName { get; set; }
        DateTime CreatedAt { get; }
        List<CustomField> CustomFields { get; set; }
        string Email { get; set; }
        string EntityUseCode { get; set; }
        string ExemptionCertificate { get; set; }
        string FirstName { get; set; }
        bool HasActiveSubscription { get; }
        bool HasCanceledSubscription { get; }
        bool HasFutureSubscription { get; }
        bool HasLiveSubscription { get; }
        bool HasPastDueInvoice { get; }
        string HostedLoginToken { get; }
        string LastName { get; set; }
        string ParentAccountCode { get; set; }
        string PreferredLocale { get; set; }
        List<ShippingAddress> ShippingAddresses { get; set; }
        Account.AccountState State { get; }
        bool? TaxExempt { get; set; }
        DateTime UpdatedAt { get; }
        string Username { get; set; }
        bool VatLocationValid { get; }
        string VatNumber { get; set; }

        void Close();
        void Create();
        ShippingAddress CreateShippingAddress(ShippingAddress shippingAddress);
        void DeleteAccountAcquisition();
        void DeleteBillingInfo();
        void DeleteShippingAddress(long shippingAddressId);
        bool Equals(IAccount account);
        bool Equals(object obj);
        CouponRedemption GetActiveRedemption();
        IRecurlyList<CouponRedemption> GetActiveRedemptions();
        IRecurlyList<Adjustment> GetAdjustments(Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All, Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any);
        IRecurlyList<Adjustment> GetAdjustments(FilterCriteria filter, Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All, Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any);
        IRecurlyList<IAccount> GetChildAccounts();
        int GetHashCode();
        IRecurlyList<IInvoice> GetInvoices();
        IRecurlyList<Note> GetNotes();
        IAccount GetParentAccount();
        IRecurlyList<ShippingAddress> GetShippingAddresses();
        IRecurlyList<Subscription> GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.All);
        IRecurlyList<Transaction> GetTransactions(TransactionList.TransactionState state = TransactionList.TransactionState.All, TransactionList.TransactionType type = TransactionList.TransactionType.All);
        InvoiceCollection InvoicePendingCharges(IInvoice invoice = null);
        Adjustment NewAdjustment(string currency, int unitAmountInCents, string description = "", int quantity = 1, string accountingCode = "", bool taxExempt = false);
        InvoiceCollection PreviewInvoicePendingCharges(IInvoice invoice = null);
        CouponRedemption RedeemCoupon(string couponCode, string currency, string subscriptionUuid = null);
        void Reopen();
        string ToString();
        void Update();
        ShippingAddress UpdateShippingAddress(ShippingAddress shippingAddress);
    }
}