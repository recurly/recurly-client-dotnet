using Recurly.Configuration;
using Xunit;

namespace Recurly.Test
{
    public class SettingsManagerTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void SetApidKey()
        {
            SettingsManager.Initialize("api", "subdomain", "private", 100);

            Assert.True("api" == Settings.Instance.ApiKey);
            Assert.True("subdomain" == Settings.Instance.Subdomain);
            Assert.True("private" == Settings.Instance.PrivateKey);
            Assert.True(100 == Settings.Instance.PageSize);
        }
    }
}