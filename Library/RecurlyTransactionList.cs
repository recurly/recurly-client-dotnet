using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyTransactionList : List<Transaction>
    {
        internal RecurlyTransactionList()
        { }

        public static Transaction[] GetTransactions(string accountCode)
        {
            RecurlyTransactionList transactionList = new RecurlyTransactionList();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                Transaction.TransactionsUrl(accountCode),
                new Client.ReadXmlDelegate(transactionList.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return transactionList.ToArray();
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if ((reader.Name == "transactions" || reader.Name == "payments" || reader.Name == "refunds") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "transaction":
                        case "payment":
                        case "refund":
                            this.Add(new Transaction(reader));
                            break;
                    }
                }
            }
        }
    }
}
