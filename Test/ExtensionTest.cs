using System.Reflection;
using NUnit.Framework;
using AccountState = Recurly.Account.AccountState;

namespace Recurly.Test
{
    [TestFixture]
    public class EnumExtensionTest
    {
        private const string NullString = null;
        private const string EmptyString = "";

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

        [TestCase(NullString, NullString),
        TestCase(EmptyString, EmptyString),
        TestCase("maxed_out", "MaxedOut"),
        TestCase("past_due", "PastDue"),
        TestCase("all", "All"),
        TestCase("CLOSED", "Closed"),
        TestCase("PascalCase", "PascalCase"),
        TestCase("Notpascalcase", "Notpascalcase"),
        TestCase("Extra_long_string_WITH_varying_cASE", "ExtraLongStringWithVaryingCase")]
        public void ToPascalCaseConvertsCorrectly(string input, string expected)
        {
            var actual = input.ToPascalCase();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("past_due", AccountState.PastDue),
        TestCase("active", AccountState.Active)]
        public void ParseAsEnumParsesAccountStateCorrectly(string toParse, AccountState expected)
        {
            var actual = toParse.ParseAsEnum<AccountState>();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseAsEnumPreservesFlagsParsing()
        {
            const AccountState state = AccountState.Active | AccountState.PastDue;

            var stateString = state.ToString();

            var result = stateString.ParseAsEnum<AccountState>();

            Assert.AreEqual(state, result);
        }
    }
}
