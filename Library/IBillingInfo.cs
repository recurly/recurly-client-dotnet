using System;

namespace Recurly
{
    public interface IBillingInfo : IRecurlyEntity, IEquatable<object>, IEquatable<IBillingInfo>
    {
        string AccountCode { get; }
        string AccountNumber { get; set; }
        BillingInfo.BankAccountType AccountType { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string AmazonBillingAgreementId { get; set; }
        string AmazonRegion { get; set; }
        BillingInfo.CreditCardType CardType { get; set; }
        string City { get; set; }
        string Company { get; set; }
        string Country { get; set; }
        string CreditCardNumber { get; set; }
        string Currency { get; set; }
        int ExpirationMonth { get; set; }
        int ExpirationYear { get; set; }
        BillingInfo.HppType? ExternalHppType { get; set; }
        string FirstName { get; set; }
        string FirstSix { get; set; }
        string GatewayCode { get; set; }
        string GatewayToken { get; set; }
        string IpAddress { get; set; }
        string IpAddressCountry { get; }
        string LastFour { get; set; }
        string LastName { get; set; }
        string NameOnAccount { get; set; }
        string PaypalBillingAgreementId { get; set; }
        string PhoneNumber { get; set; }
        string PostalCode { get; set; }
        string RoutingNumber { get; set; }
        string State { get; set; }
        string TokenId { get; set; }
        DateTime UpdatedAt { get; set; }
        string VatNumber { get; set; }
        string VerificationValue { get; set; }

        void Create();
        int GetHashCode();
        string ToString();
        void Update();
    }
}