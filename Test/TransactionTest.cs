using System;
using NUnit.Framework;

namespace Recurly.Test
{
    [TestFixture]
    public class TransactionTest : BaseTest
    {

        [Test]
        public void LookupTransaction()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Transaction t = new Transaction(acct, 5000, "USD");

            t.Create();

            Transaction t2 = Transaction.Get(t.Uuid);

            Assert.AreEqual(t, t2);


        }


        [Test]
        public void CreateTransactionNewAccount()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Transaction t = new Transaction(acct, 5000, "USD");

            t.Create();

            Assert.IsNotNull(t.CreatedAt);
        }


        [Test]
        public void CreateTransactionExistingAccount()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
            acct.Create();


            Transaction t = new Transaction(acct.AccountCode, 3000, "USD");

            t.Create();

            Assert.IsNotNull(t.CreatedAt);
            
        }

        [Test]
        public void CreateTransactionExistingAccountNewBillingInfo()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "Change Billing Info", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);
            acct.Create();

            acct.BillingInfo = NewBillingInfo(acct);

            Transaction t = new Transaction(acct, 5000, "USD");

            t.Create();

            Assert.IsNotNull(t.CreatedAt);
        }

        [Test]
        public void RefundTransactionFull()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Transaction t = new Transaction(acct, 5000, "USD");

            t.Create();

            t.Refund();

            Assert.AreEqual(t.Status, Transaction.TransactionState.Voided);

        }

        [Test]
        public void RefundTransactionPartial()
        {
            String a = GetMockAccountName();
            Account acct = new Account(a, "New Txn", "User",
                "4111111111111111", DateTime.Now.Month, DateTime.Now.Year + 1);

            Transaction t = new Transaction(acct, 5000, "USD");

            t.Create();

            t.Refund(2500);

            Assert.Fail("Need to check for a new refund transaction.");
        }

    }
}
