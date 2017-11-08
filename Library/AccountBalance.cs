using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly
{
    public class AccountBalance : RecurlyEntity
    {
        public bool PastDue { get; internal set; }
        public Dictionary<string, int> BalanceInCents = new Dictionary<string, int>();
        private const string UrlPrefix = "/accounts/";

        public static AccountBalance Get(string accountCode)
        {
            var accountBalance = new AccountBalance();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(accountCode) + "/balance", accountBalance.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : accountBalance;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "account_balance" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "past_due":
                        bool b;
                        if (bool.TryParse(reader.ReadElementContentAsString(), out b))
                            PastDue = b;

                        break;
                    case "balance_in_cents":
                        while (reader.Read())
                        {
                            if (reader.Name == "balance_in_cents" && reader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                BalanceInCents.Add(reader.Name, reader.ReadElementContentAsInt());
                            }
                        }
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
