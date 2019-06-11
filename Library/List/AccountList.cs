using System.Xml;

namespace Recurly
{
    public class AccountList : RecurlyList<IAccount>
    {
        internal AccountList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "accounts" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "account")
                {
                    Add(new Account(reader));
                }
            }

        }

        public override IRecurlyList<IAccount> Start
        {
            get { return HasStartPage() ? new AccountList(StartUrl) : RecurlyList.Empty<IAccount>(); }
        }

        public override IRecurlyList<IAccount> Next
        {
            get { return HasNextPage() ? new AccountList(NextUrl) : RecurlyList.Empty<IAccount>(); }
        }

        public override IRecurlyList<IAccount> Prev
        {
            get { return HasPrevPage() ? new AccountList(PrevUrl) : RecurlyList.Empty<IAccount>(); }
        }
    }
}