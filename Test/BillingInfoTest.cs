using System;
using FluentAssertions;
using NUnit.Framework.Constraints;
using Xunit;
using Xunit.Extensions;
using CreditCardType = Recurly.BillingInfo.CreditCardType;

namespace Recurly.Test
{
    public class BillingInfoTest : BaseTest
    {
        [Fact]
        public void UpdateBillingInfo()
        {
            string s = Factories.GetMockAccountName("Update Billing Info");
            Account acct = new Account(s,
                "John","Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year+2);
            acct.Create();

            BillingInfo billingInfo = new BillingInfo(acct);
            billingInfo.FirstName = "Jane";
            billingInfo.LastName = "Smith";
            billingInfo.CreditCardNumber = "4111111111111111";
            billingInfo.ExpirationMonth = DateTime.Now.AddMonths(3).Month;
            billingInfo.ExpirationYear = DateTime.Now.AddYears(3).Year;
            billingInfo.Update();

            Account a = Account.Get(s);

            Assert.Equal(a.BillingInfo.FirstName, "Jane");
            Assert.Equal(a.BillingInfo.LastName, "Smith");
            Assert.Equal(a.BillingInfo.ExpirationMonth, DateTime.Now.AddMonths(3).Month);
            Assert.Equal(a.BillingInfo.ExpirationYear, DateTime.Now.AddYears(3).Year);

        }

        [Fact]
        public void LookupBillingInfo()
        {
            string s = Factories.GetMockAccountName("Update Billing Info");
            Account acct = new Account(s,
                "John", "Doe", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            acct.Create();

            Account a = Account.Get(s);

            Assert.Equal(a.BillingInfo.FirstName, "John");
            Assert.Equal(a.BillingInfo.LastName, "Doe");
            Assert.Equal(a.BillingInfo.ExpirationMonth, DateTime.Now.Month);
            Assert.Equal(a.BillingInfo.ExpirationYear, DateTime.Now.Year+2);
        }

        [Fact]
        public void LookupMissingInfo()
        {
            Account newAcct = new Account(Factories.GetMockAccountName("Lookup Missing Billing Info"));
            newAcct.Create();

            Assert.Throws(typeof(NotFoundException), delegate
            {
                BillingInfo.Get(newAcct.AccountCode);
            });
        }

        [Fact]
        
        public void ClearBillingInfo()
        {
            string s = Factories.GetMockAccountName("Clear Billing Info");

            Account newAcct = new Account(s,
                "George", "Jefferson", "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 2);
            newAcct.Create();

            newAcct.ClearBillingInfo();

            Assert.Null(newAcct.BillingInfo);
            Account t = Account.Get(s);
            Assert.Null(t.BillingInfo);

        }

        [Theory,
        InlineData(NullString, false, CreditCardType.Invalid),
        InlineData(EmptyString, false, CreditCardType.Invalid),
        InlineData("4234 1234 1234 1234", true, CreditCardType.Visa),
        InlineData("6011 1234 1234 1234", true, CreditCardType.Discover),
        InlineData("3434 1234 1234 123", true, CreditCardType.AmericanExpress),
        InlineData("5134 1234 1234 1234", true, CreditCardType.MasterCard),
        InlineData("1800 1234 1234 123", true, CreditCardType.JCB),
        InlineData("2131 1234 1234 123", true, CreditCardType.JCB),
        InlineData("3131 1234 1234 1234", true, CreditCardType.JCB),
        InlineData("not a card number", false, CreditCardType.Invalid),
        InlineData("1801 1234 1234 1234", false, CreditCardType.Invalid),
        InlineData("too short", false, CreditCardType.Invalid),
        InlineData("6011 1234 123", false, CreditCardType.Invalid)]
        public void IsValidCreditCreditCardNumber_behaves_as_expected(string toTest, bool expectedResult, CreditCardType expectedType)
        {
            CreditCardType actualType;
            var actualResult = toTest.IsValidCreditCardNumber(out actualType);

            actualResult.Should().Be(expectedResult);
            actualType.Should().Be(expectedType);
        }
    }
}