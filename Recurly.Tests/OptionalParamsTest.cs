using System;
using System.Collections.Generic;
using Moq;
using Recurly;
using Xunit;

namespace Recurly.Tests
{
    public class OptionalParamsTest
    {
        public OptionalParamsTest() { }

        [Fact]
        public void CanConvertToDictionary()
        {
            var optionalParams = new ListResourcesParams()
            {
                Limit = 200
            };
            var paramsDict = optionalParams.ToDictionary();

            Assert.IsType<Dictionary<string, object>>(paramsDict);
            var expectedKeys = new[] { "ids", "limit", "allowed", "begin_time" };
            foreach (var key in expectedKeys)
            {
                Assert.Contains(key, paramsDict.Keys);
            }
            Assert.Equal(200, paramsDict["limit"]);
        }

        [Fact]
        public void CanConvertStringLists()
        {
            var optionalParams = new ListResourcesParams()
            {
                Ids = new List<string>() { "one", "two", "three" }
            };
            var paramsDict = optionalParams.ToDictionary();

            Assert.IsType<Dictionary<string, object>>(paramsDict);
            Assert.Contains("ids", paramsDict.Keys);
            Assert.Equal("one,two,three", paramsDict["ids"]);
        }
    }
}
