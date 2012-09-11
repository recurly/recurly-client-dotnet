using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class AccountList : RecurlyList<Account>
    {

        internal void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if (reader.Name.Equals("accounts") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    this.Add(new Account(reader));
                    break;
                }
            }

        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static AccountList List(Recurly.Account.AccountState state = Recurly.Account.AccountState.active)
        {
            AccountList l = new AccountList();
            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                Account.UrlPrefix + "?state=" + state.ToString(),
                new Client.ReadXmlDelegate(l.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return l;
        }
    }

}