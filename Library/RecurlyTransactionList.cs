using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyTransactionList : List<RecurlyTransaction>
    {
        internal RecurlyTransactionList()
        { }

        public static RecurlyTransaction[] GetTransactions(string accountCode)
        {
            RecurlyTransactionList transactionList = new RecurlyTransactionList();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                RecurlyTransaction.TransactionsUrl(accountCode),
                new RecurlyClient.ReadXmlDelegate(transactionList.ReadXml));

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
                            this.Add(new RecurlyTransaction(reader));
                            break;
                    }
                }
            }
        }
    }
}