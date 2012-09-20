using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class TransactionList : RecurlyList<Transaction>
    {
        public enum TransactionState : short
        {
            all = 0,
            successful,
            failed,
            voided
        }

        public enum TransactionType : short
        {
            all = 0,
            authorization,
            purchase,
            refund
        }

        internal TransactionList() : base() { }

        internal TransactionList(string baseUrl)
            : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name.Equals("transactions") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("transaction"))
                {
                    this.Add(new Transaction(reader));
                }
            }

        }



        /// <summary>
        /// Lists transactions by state and type. Defaults to all.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TransactionList GetTransactions(TransactionState state = TransactionState.all,
            TransactionType type = TransactionType.all)
        {
            return new TransactionList("/transactions/?" +
                (state != TransactionState.all ? "state=" + System.Uri.EscapeUriString(state.ToString()) : "")
                + (type != TransactionType.all ? "&type=" + System.Uri.EscapeUriString(type.ToString()) : "")
            );
        }
    }
}