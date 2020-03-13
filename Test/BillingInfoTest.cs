using System;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;
using CreditCardType = Recurly.BillingInfo.CreditCardType;

namespace Recurly.Test
{
    public class BillingInfoTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateBillingInfo()
        {
            var account = CreateNewAccount();

            var info = NewBillingInfo(account);
            info.FirstName = "Jane";
            info.LastName = "Smith";
            info.Company = "St Agatha's Home for the Bewildered";
            info.PhoneNumber = "020	7946 0001";
            info.VatNumber = "GB123456789";
            info.Address1 = "Parliament Square";
            info.Address2 = "Testminster";
            info.City = "London";
            info.PostalCode = "SW1A 0PW";
            info.State = "";
            info.Country = "GB";
            info.Currency = "USD";   // Should really be a different currency for testing but test environment doesn't seem set up for multi-currency
            info.IpAddress = "192.0.2.1";    // Reserved address for "TEST-NET-1" (so no country)
            info.CreditCardNumber = TestCreditCardNumbers.MasterCard1;
            info.VerificationValue = "321";
            info.ExpirationMonth = DateTime.Now.AddMonths(3).Month;
            info.ExpirationYear = DateTime.Now.AddYears(3).Year;
            info.Update();

            var get = Accounts.Get(account.AccountCode);

            get.BillingInfo.FirstName.Should().Be("Jane");
            get.BillingInfo.LastName.Should().Be("Smith");
            get.BillingInfo.ExpirationMonth.Should().Be(DateTime.Now.AddMonths(3).Month);
            get.BillingInfo.ExpirationYear.Should().Be(DateTime.Now.AddYears(3).Year);
            get.BillingInfo.AccountCode.Should().Be(info.AccountCode);
            get.BillingInfo.FirstName.Should().Be(info.FirstName);
            get.BillingInfo.LastName.Should().Be(info.LastName);
            get.BillingInfo.Company.Should().Be(info.Company);
            get.BillingInfo.PhoneNumber.Should().Be(info.PhoneNumber);
            get.BillingInfo.VatNumber.Should().Be(info.VatNumber);
            get.BillingInfo.Address1.Should().Be(info.Address1);
            get.BillingInfo.Address2.Should().Be(info.Address2);
            get.BillingInfo.City.Should().Be(info.City);
            get.BillingInfo.PostalCode.Should().Be(info.PostalCode);
            get.BillingInfo.State.Should().Be(info.State);
            get.BillingInfo.Country.Should().Be(info.Country);
            get.BillingInfo.Currency.Should().BeNull();   // Currency not returned unless not set to the default (and test environment doesn't seem set up for multi-currency)
            (DateTime.Now - get.BillingInfo.UpdatedAt).TotalMinutes.Should().BeLessThan(1.0);
            get.BillingInfo.IpAddress.Should().Be(info.IpAddress);
            get.BillingInfo.IpAddressCountry.Should().Be(string.Empty);
            get.BillingInfo.CreditCardNumber.Should().BeNull();
            get.BillingInfo.VerificationValue.Should().BeNull();
            get.BillingInfo.ExpirationMonth.Should().Be(info.ExpirationMonth);
            get.BillingInfo.ExpirationYear.Should().Be(info.ExpirationYear);
            get.BillingInfo.CardType.Should().Be(info.CardType);
            get.BillingInfo.FirstSix.Should().Be(info.CreditCardNumber.Substring(0, 6));
            get.BillingInfo.LastFour.Should().Be(info.CreditCardNumber.Last(4));
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateBillingInfoWithToken()
        {
            var account = CreateNewAccount();
            var billingInfo = new BillingInfo(account)
            {
                TokenId = "abc123"
            };
            var threw = false;

            try
            {
                billingInfo.Update();
            }
            catch (ValidationException exception)
            {
                threw = true;
                exception.Errors[0].Symbol.Should().Be("token_invalid");
            }

            threw.Should().Be(true);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateBillingInfoWithIban()
        {
            var account2 = CreateNewAccount();
            var ibanInfo = new BillingInfo(account2)
            {
                NameOnAccount = "Iban account name",
                Iban = "FR1420041010050500013M02606",
                Address1 = "123 Test St",
                Address2 = "The Test Cut",
                City = "San Francisco",
                PostalCode = "94105",
                State = "CA",
                Country = "US",
            };
            try {
                ibanInfo.Create();
            } catch (ValidationException exception) {
                System.Console.WriteLine(exception);
            }
            account2.BillingInfo.NameOnAccount.Should().Be("Iban account name");
        }
            
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupBillingInfo()
        {
            var accountCode = GetUniqueAccountCode();
            var info = NewBillingInfo(accountCode);
            var account = new Account(accountCode, info);
            account.Create();

            var get = Accounts.Get(accountCode);

            get.BillingInfo.AccountCode.Should().Be(info.AccountCode);
            get.BillingInfo.FirstName.Should().Be(info.FirstName);
            get.BillingInfo.LastName.Should().Be(info.LastName);
            get.BillingInfo.Company.Should().Be(info.Company);
            get.BillingInfo.PhoneNumber.Should().Be(info.PhoneNumber);
            get.BillingInfo.VatNumber.Should().Be(info.VatNumber);
            get.BillingInfo.Address1.Should().Be(info.Address1);
            get.BillingInfo.Address2.Should().Be(info.Address2);
            get.BillingInfo.City.Should().Be(info.City);
            get.BillingInfo.PostalCode.Should().Be(info.PostalCode);
            get.BillingInfo.State.Should().Be(info.State);
            get.BillingInfo.Country.Should().Be(info.Country);
            get.BillingInfo.Currency.Should().BeNull();   // Currency not returned unless not set to the default (and test environment doesn't seem set up for multi-currency)
            (DateTime.Now - get.BillingInfo.UpdatedAt).TotalMinutes.Should().BeLessThan(1.0);
            get.BillingInfo.IpAddress.Should().Be(info.IpAddress);
            get.BillingInfo.IpAddressCountry.Should().Be("US");
            get.BillingInfo.CreditCardNumber.Should().BeNull();
            get.BillingInfo.VerificationValue.Should().BeNull();
            get.BillingInfo.ExpirationMonth.Should().Be(info.ExpirationMonth);
            get.BillingInfo.ExpirationYear.Should().Be(info.ExpirationYear);
            get.BillingInfo.CardType.Should().Be(info.CardType);
            get.BillingInfo.FirstSix.Should().Be(info.CreditCardNumber.Substring(0, 6));
            get.BillingInfo.LastFour.Should().Be(info.CreditCardNumber.Last(4));
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupMissingInfo()
        {
            var newAcct = CreateNewAccount();

            Action getInfo = () => BillingInfo.Get(newAcct.AccountCode);
            getInfo.ShouldThrow<NotFoundException>();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void DeleteBillingInfo()
        {
            var account = CreateNewAccountWithBillingInfo();

            account.DeleteBillingInfo();

            account.BillingInfo.Should().BeNull();

            var fromNetwork = Accounts.Get(account.AccountCode);
            fromNetwork.BillingInfo.Should().BeNull();
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
}
