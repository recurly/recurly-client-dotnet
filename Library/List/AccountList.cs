using System.Xml;

namespace Recurly
{
    public class AccountList : RecurlyList<Account>
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

        public override IRecurlyList<Account> Start
        {
            get { return HasStartPage() ? new AccountList(StartUrl) : RecurlyList.Empty<Account>(); }
        }

        public override IRecurlyList<Account> Next
        {
            get { return HasNextPage() ? new AccountList(NextUrl) : RecurlyList.Empty<Account>(); }
        }

        public override IRecurlyList<Account> Prev
        {
            get { return HasPrevPage() ? new AccountList(PrevUrl) : RecurlyList.Empty<Account>(); }
        }
    }
}