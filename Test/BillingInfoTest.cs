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
         InlineData(TestCreditCardNumbers.Visa1, true, CreditCardType.Visa),
         InlineData(TestCreditCardNumbers.Visa2, true, CreditCardType.Visa),
         InlineData(TestCreditCardNumbers.Visa3, true, CreditCardType.Visa),
         InlineData(TestCreditCardNumbers.Discover1, true, CreditCardType.Discover),
         InlineData(TestCreditCardNumbers.Discover2, true, CreditCardType.Discover),
         InlineData(TestCreditCardNumbers.AmericanExpress1, true, CreditCardType.AmericanExpress),
         InlineData(TestCreditCardNumbers.AmericanExpress2, true, CreditCardType.AmericanExpress),
         InlineData(TestCreditCardNumbers.AmericanExpressCorporate, true, CreditCardType.AmericanExpress),
         InlineData(TestCreditCardNumbers.MasterCard1, true, CreditCardType.MasterCard),
         InlineData(TestCreditCardNumbers.MasterCard2, true, CreditCardType.MasterCard),
         InlineData(TestCreditCardNumbers.JCB1, true, CreditCardType.JCB),
         InlineData(TestCreditCardNumbers.JCB2, true, CreditCardType.JCB),
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

        [Theory,
         InlineData(NullString, false),
         InlineData(EmptyString, false),
         InlineData("4111 1111 1111 1111", true),
         InlineData("4012 8888 8888 1881", true),
         InlineData("6011 1111 1111 1117", true),
         InlineData("6011 0009 9013 9424", true),
         InlineData("3782 822463 10005", true),
         InlineData("5105 1051 0510 5100", true),
         InlineData("1800 1234 1234 123", true),
         InlineData("3566 0020 2036 0505", true),
         InlineData("3530 1113 3330 0000", true),
         InlineData("not a card number", false)]
        public void LuhnsTest_behaves_correctly(string toTest, bool expected)
        {
            var actual = toTest.PassesLuhnsTest();
            actual.Should().Be(expected);
        }
    }

    public class TestCreditCardNumbers
    {
        // test numbers from http://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm

        public const string AmericanExpress1 = "378282246310005";
        public const string AmericanExpress2 = "371449635398431";
        public const string AmericanExpressCorporate = "378734493671000";

        public const string Discover1 = "6011111111111117";
        public const string Discover2 = "6011000990139424";

        public const string JCB1 = "3530111333300000";
        public const string JCB2 = "3566002020360505";

        public const string MasterCard1 = "5555555555554444";
        public const string MasterCard2 = "5555555555554444";

        public const string Visa1 = "4111111111111111";
        public const string Visa2 = "4012888888881881";
        public const string Visa3 = "4222222222222";
    }
}