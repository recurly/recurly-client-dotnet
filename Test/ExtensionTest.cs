using System;
using System.Net;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;
using AccountState = Recurly.Account.AccountState;
using CreditCardType = Recurly.BillingInfo.CreditCardType;

namespace Recurly.Test
{
    public class ExtensionTest
    {
        private const string NullString = null;
        private const string EmptyString = "";
        private const string WhiteSpaceString = "  \n  ";

        [Fact]
        public void Enum_Is_detects_overlap()
        {
            const AccountState state = AccountState.Active | AccountState.PastDue;

            state.Is(AccountState.PastDue).Should().BeTrue();
            state.Is(AccountState.Active).Should().BeTrue();
            state.Is(AccountState.Closed).Should().BeFalse();
        }

        [Fact]
        public void Enum_Remove_properly_removes_flags()
        {
            var state = AccountState.Active | AccountState.PastDue;
            state = state.Remove(AccountState.PastDue);

            state.Is(AccountState.PastDue).Should().BeFalse();
            state.Is(AccountState.Active).Should().BeTrue();
            state.Is(AccountState.Closed).Should().BeFalse();
        }

        [Fact]
        public void Enum_Remove_matches_bitwise_operation()
        {
            const AccountState bitwise = (AccountState.Closed | AccountState.PastDue) ^ AccountState.PastDue;
            var declarative = (AccountState.Closed | AccountState.PastDue).Remove(AccountState.PastDue);

            bitwise.Should().Be(declarative);
        }

        [Fact]
        public void Enum_Add_properly_adds_flags()
        {
            var state = AccountState.Active;
            state = state.Add(AccountState.PastDue);

            state.Is(AccountState.PastDue).Should().BeTrue();
            state.Is(AccountState.Active).Should().BeTrue();
            state.Is(AccountState.Closed).Should().BeFalse();
        }

        [Fact]
        public void Enum_Add_matches_bitwise_operation()
        {
            const AccountState bitOperation = AccountState.Closed | AccountState.PastDue;
            var declarative = AccountState.Closed.Add(AccountState.PastDue);

            bitOperation.Should().Be(declarative);
        }

        [Theory,
        InlineData(NullString, NullString),
        InlineData(EmptyString, EmptyString),
        InlineData("maxed_out", "MaxedOut"),
        InlineData("past_due", "PastDue"),
        InlineData("all", "All"),
        InlineData("CLOSED", "Closed"),
        InlineData("PascalCase", "PascalCase"),
        InlineData("Notpascalcase", "Notpascalcase"),
        InlineData("Extra_long_string_WITH_varying_cASE", "ExtraLongStringWithVaryingCase")]
        public void ToPascalCase_converts_correctly(string input, string expected)
        {
            var actual = input.ToPascalCase();
            actual.Should().Be(expected);
        }

        [Theory,
        InlineData(NullString),
        InlineData(EmptyString),
        InlineData("NotAMember")]
        public void String_ParseAsEnum_throws_exception_with_invalid_members(string toParse)
        {
            Action parse = () => toParse.ParseAsEnum<AccountState>();
            parse.ShouldThrow<ArgumentException>();
        }

        [Theory,
        InlineData("past_due", AccountState.PastDue),
        InlineData("active", AccountState.Active)]
        public void String_ParseAsEnum_parses_AccountState_correctly(string toParse, AccountState expected)
        {
            var actual = toParse.ParseAsEnum<AccountState>();
            actual.Should().Be(expected);
        }

        [Theory,
        InlineData("jcb", CreditCardType.JCB),
        InlineData("master_card", CreditCardType.MasterCard)]
        public void String_ParseAsEnum_parses_CreditCardType_correctly(string toParse, CreditCardType expected)
        {
            var actual = toParse.ParseAsEnum<CreditCardType>();
            actual.Should().Be(expected);
        }

        [Fact]
        public void String_ParseAsEnum_preserves_flags_parsing()
        {
            const AccountState state = AccountState.Active | AccountState.PastDue;

            var stateString = state.ToString();

            var result = stateString.ParseAsEnum<AccountState>();

            result.Should().Be(state);
        }

        [Theory,
        InlineData(1, TestEnum.One),
        InlineData(2, TestEnum.Two),
        InlineData(3, TestEnum.Three),
        InlineData(200, HttpStatusCode.OK),
        InlineData(304, HttpStatusCode.NotModified)]
        public void Int_ParseAsEnum_parses_enums_correctly(int toParse, TestEnum expected)
        {
            var actual = toParse.ParseAsEnum<TestEnum>();
            actual.Should().Be(expected);
        }

        public enum TestEnum
        {
            One = 1,
            Two = 2,
            Three
        }

        [Theory,
        InlineData(NullString),
        InlineData(EmptyString),
        InlineData(WhiteSpaceString)]
        public void EnumNameToTransportCase_throws_exception_with_null_or_whitespace(string enumName)
        {
            Action a = () => enumName.EnumNameToTransportCase();
            a.ShouldThrow<ArgumentException>();
        }

        [Theory,
        InlineData("MaxedOut", "maxed_out"),
        InlineData("Active", "active"),
        InlineData("Closed, PastDue", "closed,past_due"),
        InlineData("JCB", "jcb")]
        public void EnumNameToTransportCase_should_remove_uppercase_and_add_underscores_at_words(string toConvert, string expected)
        {
            var actual = toConvert.EnumNameToTransportCase();
            actual.Should().Be(expected);
        }

        [Theory,
        InlineData(NullString, NullString),
        InlineData(EmptyString, EmptyString),
        InlineData(FullLinkHeader, NullString),
        InlineData(FullLinkHeader, EmptyString)]
        public void GetUrlFromLinkHeader_throws_exception_when_passed_null_or_empty(string linkHeader, string name)
        {
            Action a = () => linkHeader.GetUrlFromLinkHeader(name);
            a.ShouldThrow<ArgumentNullException>();
        }

        [Theory,
        InlineData(FullLinkHeader, "prev", "https://your-subdomain.recurly.com/v2/transactions?cursor=-1318344434"),
        InlineData(FullLinkHeader, "next", "https://your-subdomain.recurly.com/v2/transactions?cursor=1318388868"),
        InlineData(FullLinkHeader, "start", "https://your-subdomain.recurly.com/v2/transactions")]
        public void GetUrlFromLinkHeader_extracts_correctly(string linkHeader, string name, string expected)
        {
            var actual = linkHeader.GetUrlFromLinkHeader(name);

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetUrlFromLinkHeader_returns_null_when_name_is_not_found()
        {
            var actual = LinkHeaderOnlyNext.GetUrlFromLinkHeader("prev");
            actual.Should().BeNull();
        }

        public const string FullLinkHeader = @"<https://your-subdomain.recurly.com/v2/transactions>; rel=""start"",
  <https://your-subdomain.recurly.com/v2/transactions?cursor=-1318344434>; rel=""prev"",
  <https://your-subdomain.recurly.com/v2/transactions?cursor=1318388868>; rel=""next""";
  
        public const string LinkHeaderOnlyNext = "<https://your-subdomain.recurly.com/v2/transactions?cursor=1318388868>; rel=\"next\"";
    }
}
