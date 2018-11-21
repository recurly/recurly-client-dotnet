using Xunit;
using Recurly;
using Newtonsoft.Json;
using System;

namespace Recurly.UnitTests
{
    public class JsonTest
    {
        private class MyResource : Recurly.Resource {
            [JsonProperty("my_string")]
            public string MyString { get; set; }

            [JsonProperty("nullable_prop")]
            public string NullableProp { get; set; }
        }

        private string jsonFixture = @"{
                'my_string': 'The String',
            }";

        private MyResource resourceFixture = new MyResource() {
            MyString = "The String",
            NullableProp = null
        };

        [Fact]
        public void DserializeTest()
        {
            // We should be converting from snake case to camel
            var myResource = Json.Deserialize<MyResource>(jsonFixture);
            Assert.Equal("The String", myResource.MyString);
        }

        [Fact]
        public void SerializeTest()
        {
            // We should be converting from camel case to snake
            // We should also not see `null`s
            var jsonString = Json.Serialize(resourceFixture);
            Assert.Equal("{\"my_string\":\"The String\"}", jsonString);

        }
    }
}
