using Xunit;
using Recurly;
using Newtonsoft.Json;
using System;

namespace Recurly.UnitTests
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
    }
}
