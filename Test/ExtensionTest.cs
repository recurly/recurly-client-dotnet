using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
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
        public void GetHashCode_WorksOn_NullRef()
        {
            var sub = new Subscription();
            var hcode = sub.GetHashCode();
        }

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
        public void Int_ParseAsEnum_parses_enums_correctly<T>(int toParse, T expected)
        {
            var actual = toParse.ParseAsEnum<T>();
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

        [Theory,
         InlineData(NullString, 6, NullString),
         InlineData(EmptyString, 6, EmptyString),
         InlineData("1234567890", 4, "7890"),
         InlineData("word", 1, "d"),
         InlineData("word", 4, "word"),
         InlineData("word", 0, "word"),
         InlineData("short", 10, "short"),
         InlineData("3566002020360505", 4, "0505")]
        public void StringLast_gets_last_chars(string use, int count, string expected)
        {
            var actual = use.Last(count);

            actual.Should().Be(expected);
        }

        [Fact]
        public void WriteIfCollectionHasAny_renders_key_value_pair_collections_correctly()
        {
            var units = new Dictionary<string, int>
            {
                {"USD", 1000},
                {"EUR", 800}
            };

            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);
            xmlWriter.WriteIfCollectionHasAny("unit_amount_in_cents", units, pair => pair.Key, pair => pair.Value.AsString());
            xmlWriter.Flush();
            xmlWriter.Close();

            stringWriter.ToString().Should().Be(ValidKeyValueXml);
        }

        [Fact]
        public void WriteIfCollectionHasAny_renders_RecurlyEntity_lists_correctly()
        {
            var list = new List<SubscriptionAddOn>
            {
                new SubscriptionAddOn("addon1", AddOn.Type.Fixed, 100),
                new SubscriptionAddOn("addon2", AddOn.Type.Fixed, 200, 2)
            };

            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);
            xmlWriter.WriteIfCollectionHasAny("subscription_add_ons", list);
            xmlWriter.Flush();
            xmlWriter.Close();

            var actual = stringWriter.ToString();

            actual.Should().Be(ValidEntityXml);
        }

        [Fact]
        public void WriteIfCollectionHasAny_renders_static_names_correctly()
        {
            var list = new List<string>
            {
                "plan1",
                "plan2"
            };

            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);
            xmlWriter.WriteIfCollectionHasAny("plan_codes", list, s => "plan_code", s => s);
            xmlWriter.Flush();
            xmlWriter.Close();

            var actual = stringWriter.ToString();

            actual.Should().Be(StaticNamesXml);
        }

        public const string ValidKeyValueXml = "<unit_amount_in_cents>" +
                                               "<USD>1000</USD>" +
                                               "<EUR>800</EUR>" +
                                               "</unit_amount_in_cents>";

        public const string ValidEntityXml = "<subscription_add_ons>" +
                                             "<subscription_add_on><add_on_code>addon1</add_on_code><quantity>1</quantity><unit_amount_in_cents>100</unit_amount_in_cents></subscription_add_on>" +
                                             "<subscription_add_on><add_on_code>addon2</add_on_code><quantity>2</quantity><unit_amount_in_cents>200</unit_amount_in_cents></subscription_add_on>" +
                                             "</subscription_add_ons>";

        public const string StaticNamesXml = "<plan_codes>" +
                                             "<plan_code>plan1</plan_code>" +
                                             "<plan_code>plan2</plan_code>" +
                                             "</plan_codes>";
    }
}
