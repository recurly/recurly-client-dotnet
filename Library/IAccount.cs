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
        IBillingInfo BillingInfo { get; set; }
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
        List<IShippingAddress> ShippingAddresses { get; set; }
        Account.AccountState State { get; }
        bool? TaxExempt { get; set; }
        DateTime UpdatedAt { get; }
        string Username { get; set; }
        bool VatLocationValid { get; }
        string VatNumber { get; set; }

        void Close();
        void Create();
        IShippingAddress CreateShippingAddress(IShippingAddress shippingAddress);
        void DeleteAccountAcquisition();
        void DeleteBillingInfo();
        void DeleteShippingAddress(long shippingAddressId);
        bool Equals(IAccount account);
        bool Equals(object obj);
        ICouponRedemption GetActiveRedemption();
        IRecurlyList<ICouponRedemption> GetActiveRedemptions();
        IRecurlyList<IAdjustment> GetAdjustments(Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All, Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any);
        IRecurlyList<IAdjustment> GetAdjustments(FilterCriteria filter, Adjustment.AdjustmentType type = Adjustment.AdjustmentType.All, Adjustment.AdjustmentState state = Adjustment.AdjustmentState.Any);
        IRecurlyList<IAccount> GetChildAccounts();
        int GetHashCode();
        IRecurlyList<IInvoice> GetInvoices();
        IRecurlyList<INote> GetNotes();
        IAccount GetParentAccount();
        IRecurlyList<IShippingAddress> GetShippingAddresses();
        IRecurlyList<ISubscription> GetSubscriptions(Subscription.SubscriptionState state = Subscription.SubscriptionState.All);
        IRecurlyList<ITransaction> GetTransactions(TransactionList.TransactionState state = TransactionList.TransactionState.All, TransactionList.TransactionType type = TransactionList.TransactionType.All);
        IInvoiceCollection InvoicePendingCharges(IInvoice invoice = null);
        IAdjustment NewAdjustment(string currency, int unitAmountInCents, string description = "", int quantity = 1, string accountingCode = "", bool taxExempt = false);
        IInvoiceCollection PreviewInvoicePendingCharges(IInvoice invoice = null);
        ICouponRedemption RedeemCoupon(string couponCode, string currency, string subscriptionUuid = null);
        void Reopen();
        string ToString();
        void Update();
        IShippingAddress UpdateShippingAddress(IShippingAddress shippingAddress);
    }
}