using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

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
                    this.Add(new Account(reader));
                }
            }

        }

        /// <summary>
        /// Lists accounts, limited to state
        /// </summary>
        /// <param name="state">Account state to retrieve</param>
        /// <returns></returns>
        public static AccountList List(Recurly.Account.AccountState state = Recurly.Account.AccountState.Active )
        {
            return new AccountList( Account.UrlPrefix + "?state=" + state.ToString() );
        }

    }

}