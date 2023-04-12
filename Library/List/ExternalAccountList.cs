using System;
using System.Xml;

namespace Recurly
{
    public class ExternalAccountList : RecurlyList<ExternalAccount>
    {
        internal ExternalAccountList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }
        public override RecurlyList<ExternalAccount> Start
        {
            get { return HasStartPage() ? new ExternalAccountList(StartUrl) : RecurlyList.Empty<ExternalAccount>(); }
        }

        public override RecurlyList<ExternalAccount> Next
        {
            get { return HasNextPage() ? new ExternalAccountList(NextUrl) : RecurlyList.Empty<ExternalAccount>(); }
        }

        public override RecurlyList<ExternalAccount> Prev
        {
            get { return HasPrevPage() ? new ExternalAccountList(PrevUrl) : RecurlyList.Empty<ExternalAccount>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_accounts" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_account")
                    Add(new ExternalAccount(reader));
            }
        }
    }
}
