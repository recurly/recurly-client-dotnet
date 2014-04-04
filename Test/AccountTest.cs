using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AccountTest : BaseTest
    {
        [Fact]
        public void CreateAccount()
        {
            var acct = new Account(GetUniqueAccountCode());
            acct.Create();
            acct.CreatedAt.Should().NotBe(default(DateTime));
            Assert.False(acct.TaxExempt);
        }

        [Fact]
        public void CreateAccountWithParameters()
        {
            var acct = new Account(GetUniqueAccountCode())
            {
                Username = "testuser1",
                Email = "testemail@recurly.com",
                FirstName = "Test",
                LastName = "User",
                CompanyName = "Test Company",
                AcceptLanguage = "en",
                VatNumber = "my-vat-number",
                TaxExempt = true
            };

            acct.Create();

            acct.Username.Should().Be("testuser1");
            acct.Email.Should().Be("testemail@recurly.com");
            acct.FirstName.Should().Be("Test");
            acct.LastName.Should().Be("User");
            acct.CompanyName.Should().Be("Test Company");
            acct.AcceptLanguage.Should().Be("en");
            Assert.Equal("my-vat-number", acct.VatNumber);
            Assert.True(acct.TaxExempt);
        }

        [Fact]
        public void CreateAccountWithBillingInfo()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode, NewBillingInfo(accountCode));

            Action create = account.Create;

            create.ShouldNotThrow<ValidationException>();
        }

        [Fact]
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

        [Fact]
        public void FindNonExistentAccount()
        {
            Action get = () => Accounts.Get("totallynotfound!@#$");
            get.ShouldThrow<NotFoundException>();
        }

        [Fact]
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
            Assert.True(acct.TaxExempt);
            Assert.Equal("woot", acct.VatNumber);
        }

        [Fact]
        public void CloseAccount()
        {
            var accountCode = GetUniqueAccountCode();
            var acct = new Account(accountCode);
            acct.Create();

            acct.Close();

            var getAcct = Accounts.Get(accountCode);
            getAcct.State.Should().Be(Account.AccountState.Closed);
        }

        [Fact]
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

        [Fact]
        public void GetAccountNotes()
        {
            var account = CreateNewAccount();

            var notes = account.GetNotes();

            notes.Should().BeEmpty();
        }
    }
}