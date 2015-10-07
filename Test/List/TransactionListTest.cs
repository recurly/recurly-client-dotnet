using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class TransactionListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListAllTransactions()
        {
            for (var x = 0; x < 5; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var transaction = new Transaction(account.AccountCode, 3000 + x, "USD");
                transaction.Create();
            }

            var transactions = Transactions.List();
            transactions.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListSuccessfulTransactions()
        {
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var transaction = new Transaction(account.AccountCode, 3000 + x, "USD");
                transaction.Create();
            }

            var transactions = Transactions.List(TransactionList.TransactionState.Successful);
            transactions.Should().NotBeEmpty();
        }

        [Fact(Skip = "This feature is deprecated and no longer supported for accounts where line item refunds are turned on.")]
        public void ListVoidedTransactions()
        {
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var transaction = new Transaction(account.AccountCode, 3000 + x, "USD");
                transaction.Create();

                transaction.Refund();


            }

            var list = Transactions.List(TransactionList.TransactionState.Voided);
            list.Should().NotBeEmpty();
        }

        [Fact(Skip = "This feature is deprecated and no longer supported for accounts where line item refunds are turned on.")]
        public void ListRefundedTransactions()
        {
            for (var x = 0; x < 2; x++)
            {
                var account = CreateNewAccountWithBillingInfo();
                var transaction = new Transaction(account.AccountCode, 3000 + x, "USD");
                transaction.Create();
                transaction.Refund(1500);
            }

            var list = Transactions.List(type: TransactionList.TransactionType.Refund);
            list.Should().NotBeEmpty();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListTransactionsForAccount()
        {
            var account = CreateNewAccountWithBillingInfo();

            var transaction1 = new Transaction(account.AccountCode, 3000, "USD");
            transaction1.Create();

            var transaction2 = new Transaction(account.AccountCode, 200, "USD");
            transaction2.Create();

            var list = account.GetTransactions();
            list.Should().NotBeEmpty();
        }
    }
}
