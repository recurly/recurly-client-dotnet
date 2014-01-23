namespace Recurly.Test
{
    public abstract class BaseTest
    {
        internal readonly TestClient ClientInstance;
        protected BaseTest()
        {
            ClientInstance = new TestClient(SettingsFixture.TestSettings);
            Client.ChangeInstance(ClientInstance);
        }
    }
}
