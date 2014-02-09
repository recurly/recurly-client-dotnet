namespace Recurly.Test
{
    public abstract class BaseTest
    {
        protected const string NullString = null;
        protected const string EmptyString = "";

        //internal readonly TestClient ClientInstance;
        protected BaseTest()
        {
            //ClientInstance = new TestClient(SettingsFixture.TestSettings);
            //Client.ChangeInstance(ClientInstance);

            Client.Instance.ApplySettings(SettingsFixture.TestSettings);
        }
    }
}
