using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace Recurly.Test
{
    public class QueryBuilderTest
    {
        private const string NullString = null;
        private const string EmptyString = "";
        private readonly QueryStringBuilder _queryStringBuilder;

        public QueryBuilderTest()
        {
            _queryStringBuilder = new QueryStringBuilder();
        }

        [Theory,
         InlineData(NullString),
         InlineData(EmptyString)]
        public void QueryBuilder_does_not_add_empty_or_null_strings(string content)
        {
            var actual = _queryStringBuilder.QueryStringWith(content).Build();
            actual.Should().BeNullOrEmpty();
        }

        [Theory,
         InlineData("", "state=all", "?state=all"),
         InlineData("state=all", "", "?state=all"),
         InlineData("state=all", "type=all", "?state=all&type=all")]
        public void QueryBuilder_builds_correctly(string firstContent, string secondContent, string expected)
        {
            var actual = _queryStringBuilder.QueryStringWith(firstContent).AndWith(secondContent).Build();
            actual.Should().Be(expected);
        }

        [Theory,
         InlineData(TestState.All, TestType.All, ""),
         InlineData(TestState.All, TestType.Some, "?type=some"),
         InlineData(TestState.All, TestType.None, "?type=none"),
         InlineData(TestState.Some, TestType.All, "?state=some"),
         InlineData(TestState.Some, TestType.Some, "?state=some&type=some"),
         InlineData(TestState.Some, TestType.None, "?state=some&type=none"),
         InlineData(TestState.None, TestType.All, "?state=none"),
         InlineData(TestState.None, TestType.Some, "?state=none&type=some"),
         InlineData(TestState.None, TestType.None, "?state=none&type=none")]
        public void Big_long_expressions_work(TestState testState, TestType testType, string expected)
        {

            var actual = _queryStringBuilder
                .QueryStringWith(testState == TestState.All ? "" : "state=" + testState.ToString().EnumNameToTransportCase())
                .AndWith(testType == TestType.All ? "" : "type=" + testType.ToString().EnumNameToTransportCase())
                .Build();
            actual.Should().Be(expected);
        }

        [Fact]
        public void QueryBuilder_ToString_means_Build_is_not_necessary()
        {
            var actual = "something" + _queryStringBuilder.QueryStringWith("and=another").AndWith("thing");
            actual.Should().Be("something?and=another&thing");
        }

        public enum TestState
        {
            All, Some, None
        }

        public enum TestType
        {
            All, Some, None
        }
    }
}
