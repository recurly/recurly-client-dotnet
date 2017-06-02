using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AccountTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateAccount()
        {
            var acct = new Account(GetUniqueAccountCode());
            acct.Create();
            acct.CreatedAt.Should().NotBe(default(DateTime));
            Assert.False(acct.TaxExempt.Value);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateAccountWithParameters()
        {
            var acct = new Account(GetUniqueAccountCode())
            {
                Username = "testuser1",
                Email = "testemail@test.com",
                FirstName = "Test",
                LastName = "User",
                CompanyName = "Test Company",
                AcceptLanguage = "en",
                VatNumber = "my-vat-number",
                TaxExempt = true,
                EntityUseCode = "I",
                CcEmails = "cc1@test.com,cc2@test.com",
                Address = new Address()
            };

            string address = "123 Faux Street";
            acct.Address.Address1 = address;

            acct.Create();

            acct.Username.Should().Be("testuser1");
            acct.Email.Should().Be("testemail@test.com");
            acct.FirstName.Should().Be("Test");
            acct.LastName.Should().Be("User");
            acct.CompanyName.Should().Be("Test Company");
            acct.AcceptLanguage.Should().Be("en");
            acct.CcEmails.Should().Be("cc1@test.com,cc2@test.com");
            Assert.Equal("my-vat-number", acct.VatNumber);
            Assert.True(acct.TaxExempt.Value);
            Assert.Equal("I", acct.EntityUseCode);
            Assert.Equal(address, acct.Address.Address1);
            Assert.False(acct.VatLocationValid);
        }

        [Fact]
        public void DontSerializeNullAddress()
        {
            var account = new Account("testAcct");
            account.Address.Should().BeNull();
        }

        [Fact]
        public void CreateAccountWithBillingInfo()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode, NewBillingInfo(accountCode));

            Action create = account.Create;

            create.ShouldNotThrow<ValidationException>();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LookupAccount()
        {
            var newAcct = new Account(GetUniqueAccountCode())
            {
                Email = "testemail@recurly.com"
            };
            newAcct.Create();

            var account = Accounts.Get(newAcct.AccountCode);

            account.Should().NotBeNull();
            account.AccountCode.Should().Be(newAcct.AccountCode);
            account.Email.Should().Be(newAcct.Email);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void FindNonExistentAccount()
        {
            Action get = () => Accounts.Get("totallynotfound!@#$");
            get.ShouldThrow<NotFoundException>();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void UpdateAccount()
        {
            var acct = new Account(GetUniqueAccountCode());
            acct.Create();

            acct.LastName = "UpdateTest123";
            acct.TaxExempt = true;
            acct.VatNumber = "woot";
            acct.Update();

            var getAcct = Accounts.Get(acct.AccountCode);
            acct.LastName.Should().Be(getAcct.LastName);
            Assert.True(acct.TaxExempt.Value);
            Assert.Equal("woot", acct.VatNumber);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CloseAccount()
        {
            var accountCode = GetUniqueAccountCode();
            var acct = new Account(accountCode);
            acct.Create();

            acct.Close();

            var getAcct = Accounts.Get(accountCode);
            getAcct.State.Should().Be(Account.AccountState.Closed);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ReopenAccount()
        {
            var accountCode = GetUniqueAccountCode();
            var acct = new Account(accountCode);
            acct.Create();
            acct.Close();

            acct.Reopen();

            var test = Accounts.Get(accountCode);
            acct.State.Should().Be(test.State).And.Be(Account.AccountState.Active);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetAccountNotes()
        {
            var account = CreateNewAccount();

            var notes = account.GetNotes();

            notes.Should().BeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void Balance()
        {
            var acct = CreateNewAccountWithBillingInfo();
            var adjustment = acct.NewAdjustment("USD", 5000, "Past Due", 1);
            adjustment.Create();

            acct.InvoicePendingCharges();
            var balance = acct.Balance;

            balance.Should().NotBeNull();
            balance.BalanceInCents.First().Value.Should().BeGreaterThan(0);
        }
    }
}
