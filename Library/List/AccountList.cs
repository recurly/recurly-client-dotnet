using System.Xml;

namespace Recurly
{
    public class AccountList : RecurlyList<Account>
    {

        internal AccountList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
           
            while (reader.Read())
            {
                if (reader.Name.Equals("accounts") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("account"))
                {
                    Add(new Account(reader));
                }
            }

        }

        public override RecurlyList<Account> Start
        {
            get { return new AccountList(StartUrl); }
        }

        public override RecurlyList<Account> Next
        {
            get { return new AccountList(NextUrl); }
        }

        public override RecurlyList<Account> Prev
        {
            get { return new AccountList(PrevUrl); }
        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static AccountList List(Account.AccountState state = Account.AccountState.Active )
        {
            return new AccountList(Account.UrlPrefix + "?state=" + state.ToString().EnumNameToTransportCase());
        }

    }

}