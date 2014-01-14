using System.Reflection;
using NUnit.Framework;
using AccountState = Recurly.Account.AccountState;

namespace Recurly.Test
{
    [TestFixture]
    public class EnumExtensionTest
    {
        [Test]
        public void IsDetectsFlagOverlap()
        {
            const AccountState state = AccountState.Active | AccountState.PastDue;

            Assert.IsTrue(state.Is(AccountState.PastDue));
            Assert.IsTrue(state.Is(AccountState.Active));
            Assert.IsFalse(state.Is(AccountState.Closed));
        }

        [Test]
        public void RemoveProperlyRemovesFlags()
        {
            var state = AccountState.Active | AccountState.PastDue;
            state = state.Remove(AccountState.PastDue);

            Assert.IsFalse(state.Is(AccountState.PastDue));
            Assert.IsTrue(state.Is(AccountState.Active));
            Assert.IsFalse(state.Is(AccountState.Closed));
        }

        [Test]
        public void RemoveMatchesBitwiseOperation()
        {
            const AccountState bitwise = (AccountState.Closed | AccountState.PastDue) ^ AccountState.PastDue;
            var declarative = (AccountState.Closed | AccountState.PastDue).Remove(AccountState.PastDue);

            Assert.AreEqual(bitwise, declarative);
        }

        [Test]
        public void AddProperlyAddsFlags()
        {
            var state = AccountState.Active;
            state = state.Add(AccountState.PastDue);

            Assert.IsTrue(state.Is(AccountState.PastDue));
            Assert.IsTrue(state.Is(AccountState.Active));
            Assert.IsFalse(state.Is(AccountState.Closed));
        }

        [Test]
        public void AddMatchesBitwiseOperation()
        {
            const AccountState bitOperation = AccountState.Closed | AccountState.PastDue;
            var declarative = AccountState.Closed.Add(AccountState.PastDue);

            Assert.AreEqual(bitOperation, declarative);
        }
    }
}
