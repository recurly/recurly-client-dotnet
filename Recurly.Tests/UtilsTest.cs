using Xunit;
using Recurly;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Recurly.Tests
{
    public class UtilsTest
    {
        [Fact]
        public void Camelize()
        {
            var s = "test";
            Assert.Equal("Test", Utils.Camelize(s));
            s = "test_string";
            Assert.Equal("TestString", Utils.Camelize(s));
            s = "t_string";
            Assert.Equal("TString", Utils.Camelize(s));
        }

        [Fact]
        public void QueryString()
        {
            var d = new Dictionary<string, object>();
            d.Add("trueBool", true);
            d.Add("falseBool", false);
            d.Add("int", 123);
            d.Add("float", 123.456);
            d.Add("date", new DateTime(2020, 1, 1));
            var result = Utils.QueryString(d);
            Assert.Equal("?trueBool=true&falseBool=false&int=123&float=123.456&date=2020-01-01T00:00:00.000Z", result);
        }
    }
}
