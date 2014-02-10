using System;
using System.Xml;

namespace Recurly
{
    public class TransactionList : RecurlyList<Transaction>
    {
        public enum TransactionState : short
        {
            All = 0,
            Successful,
            Failed,
            Voided
        }

        public enum TransactionType : short
        {
            All = 0,
            Authorization,
            Purchase,
            Refund
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
    }
}