using System;
using System.Collections.Generic;
using System.Text;
using Recurly;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class TransactionListTest
    {


        [Test]
        public void ListAllTransactions()
        {
            for (int x = 0; x < 5; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
                acct.Create();

                Transaction t = new Transaction(acct.AccountCode, 3000 + x, "USD");

                t.Create();

            }

            TransactionList list = TransactionList.GetTransactions();

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void ListSuccessfulTransactions()
        {

            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
                acct.Create();

                Transaction t = new Transaction(acct.AccountCode, 3000 + x, "USD");

                t.Create();

            }

            TransactionList list = TransactionList.GetTransactions(TransactionList.TransactionState.successful);

            Assert.IsTrue(list.Count > 0);

        }

        [Test]
        public void ListFailedTransactions()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void ListVoidedTransactions()
        {
            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
                acct.Create();

                Transaction t = new Transaction(acct.AccountCode, 3000 + x, "USD");

                t.Create();
                t.Refund();
            }

            TransactionList list = TransactionList.GetTransactions(TransactionList.TransactionState.successful);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void ListAuthorizationTransactions()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void ListRefundedTransactions()
        {
            for (int x = 0; x < 2; x++)
            {
                String a = Factories.GetMockAccountName();
                Account acct = new Account(a, "New Txn", "User",
                    "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
                acct.Create();

                Transaction t = new Transaction(acct.AccountCode, 3000 + x, "USD");

                t.Create();

                t.Refund(1500);


            }

            TransactionList list = TransactionList.GetTransactions(TransactionList.TransactionState.successful);

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void ListPurchaseTransactions()
        {
            Assert.Fail("Not written");
        }

        [Test]
        public void ListTransactionsForAccount()
        {

            String a = Factories.GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
            acct.Create();

            Transaction t = new Transaction(acct.AccountCode, 3000, "USD");
            t.Create();

            Transaction t2 = new Transaction(acct.AccountCode, 200, "USD");
            t2.Create();


            TransactionList list = acct.GetTransactions();
            Assert.IsTrue(list.Count > 0);

        }

    }
}
