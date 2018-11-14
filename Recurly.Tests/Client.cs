using Xunit;
using Recurly;

namespace Recurly.UnitTests
{
    public class Client_Tests
    {
        private readonly Recurly.Client _client;

        public Client_Tests()
        {
            _client  = new Recurly.Client("subdomain-mysubdomain", "myapikey");
        }

        [Fact]
        public void CanInitialize()
        {
          Assert.Equal("subdomain-mysubdomain", _client.SiteId);
        }
    }
}
