using System.Xml;

namespace Recurly
{
    public class GeneralLedgerAccountList : RecurlyList<GeneralLedgerAccount>
    {
        internal GeneralLedgerAccountList()
        {
        }

        internal GeneralLedgerAccountList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<GeneralLedgerAccount> Start
        {
            get { return HasStartPage() ? new GeneralLedgerAccountList(StartUrl) : RecurlyList.Empty<GeneralLedgerAccount>(); }
        }

        public override RecurlyList<GeneralLedgerAccount> Next
        {
            get { return HasNextPage() ? new GeneralLedgerAccountList(NextUrl) : RecurlyList.Empty<GeneralLedgerAccount>(); }
        }

        public override RecurlyList<GeneralLedgerAccount> Prev
        {
            get { return HasPrevPage() ? new GeneralLedgerAccountList(PrevUrl) : RecurlyList.Empty<GeneralLedgerAccount>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "general_ledger_accounts" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "general_ledger_account")
                {
                    Add(new GeneralLedgerAccount(reader));
                }
            }
        }
    }
}
