using System;
using System.Xml;

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

        internal TransactionList()
        {
        }

        internal TransactionList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Transaction> Start
        {
            get { return new TransactionList(StartUrl); }
        }

        public override RecurlyList<Transaction> Next
        {
            get { return new TransactionList(NextUrl); }
        }

        public override RecurlyList<Transaction> Prev
        {
            get { return new TransactionList(PrevUrl); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "transactions" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "transaction")
                {
                    Add(new Transaction(reader));
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
                (state != TransactionState.all ? "state=" + Uri.EscapeUriString(state.ToString()) : "")
                + (type != TransactionType.all ? "&type=" + Uri.EscapeUriString(type.ToString()) : "")
            );
        }
    }
}