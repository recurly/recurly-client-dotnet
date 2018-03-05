using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class AccountAcquisitionTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void FindNonExistentAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            Action get = () => AccountAcquisition.Get(account.AccountCode);
            get.ShouldThrow<NotFoundException>();
        }

        [Fact]
        public void AccountAcquisitionShouldBeNullIfNotCreated()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.Create();
            account.AccountAcquisition.Should().BeNull();
        }

        [Fact]
        public void CreateAccountWithAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.AccountAcquisition = NewAccountAcquisition(accountCode);
            account.Create();

            var acquisition = AccountAcquisition.Get(accountCode);
            VerifyTestAccountAcquisition(acquisition);
        }

        [Fact]
        public void UpdateAccountAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.AccountAcquisition = NewAccountAcquisition(accountCode);
            account.Create();

            ModifyAccountAcquisition(account.AccountAcquisition);
            account.Update();

            var acquisition = AccountAcquisition.Get(accountCode);
            VerifyModifiedAccountAcquisition(acquisition);
        }

        [Fact]
        public void DeleteAccountAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.AccountAcquisition = NewAccountAcquisition(accountCode);
            account.Create();

            account.DeleteAccountAcquisition();
            account.AccountAcquisition.Should().BeNull();

            Action get = () => AccountAcquisition.Get(account.AccountCode);
            get.ShouldThrow<NotFoundException>();
        }

        [Fact]
        public void CreateAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.Create();

            var acquisition = NewAccountAcquisition(accountCode);
            acquisition.Create();

            acquisition = AccountAcquisition.Get(account.AccountCode);
            VerifyTestAccountAcquisition(acquisition);
        }

        [Fact]
        public void CreateAccountAcquisitionWithMandatoryParameters()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.Create();

            var acquisition = new AccountAcquisition(accountCode);
            acquisition.Create();

            acquisition = AccountAcquisition.Get(account.AccountCode);
            acquisition.Should().NotBeNull();
        }

        [Fact]
        public void UpdateAccountAcquisition()
        {
            var accountCode = GetUniqueAccountCode();
            var account = new Account(accountCode);
            account.AccountAcquisition = NewAccountAcquisition(accountCode);
            account.Create();

            var acquisition = AccountAcquisition.Get(account.AccountCode);
            ModifyAccountAcquisition(acquisition);
            acquisition.Update();

            acquisition = AccountAcquisition.Get(account.AccountCode);
            VerifyModifiedAccountAcquisition(acquisition);
        }

        private AccountAcquisition NewAccountAcquisition(string accountCode)
        {
            return new AccountAcquisition(accountCode)
            {
                CostInCents = 1000,
                Currency = "USD",
                Channel = AccountAcquisition.AccountAcquisitionChannel.MarketingContent,
                Campaign = "Test Campaign",
                SubChannel = "Test Sub Channel"
            };
        }

        private void VerifyTestAccountAcquisition(AccountAcquisition acquisition)
        {
            acquisition.CostInCents.Should().Be(1000);
            acquisition.Currency.Should().Be("USD");
            acquisition.Channel.Should().Be(AccountAcquisition.AccountAcquisitionChannel.MarketingContent);
            acquisition.Campaign.Should().Be("Test Campaign");
            acquisition.SubChannel.Should().Be("Test Sub Channel");
        }

        private void ModifyAccountAcquisition(AccountAcquisition acquisition)
        {
            acquisition.CostInCents = 2002;
            acquisition.Currency = "CAD";
            acquisition.Channel = AccountAcquisition.AccountAcquisitionChannel.Blog;
            acquisition.Campaign = "Modified Campaign";
            acquisition.SubChannel = "Modified Sub Channel";
        }

        private void VerifyModifiedAccountAcquisition(AccountAcquisition acquisition)
        {
            acquisition.CostInCents.Should().Be(2002);
            acquisition.Currency.Should().Be("CAD");
            acquisition.Channel.Should().Be(AccountAcquisition.AccountAcquisitionChannel.Blog);
            acquisition.Campaign.Should().Be("Modified Campaign");
            acquisition.SubChannel.Should().Be("Modified Sub Channel");
        }
    }
}
