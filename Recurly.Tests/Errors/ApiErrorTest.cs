using Xunit;
using Recurly;
using Newtonsoft.Json;
using System;

namespace Recurly.Tests
{
    public class ApiErrorTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var err = new Recurly.Resources.Error() {
                Message = "Something bad happened",
                Type = "my_api_error"
            };
            var ex = new MyApiError(err.Message) { Error = err };
            Assert.Equal(err.Message, ex.Message);
            Assert.Equal(err, ex.Error);
        }
    }
}
